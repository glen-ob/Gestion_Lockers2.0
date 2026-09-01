using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;

namespace Gestion_Lockers
{
    public static class Funciones
    {
        // ─────────────────────────────────────────────
        // Tipos de datos
        // ─────────────────────────────────────────────

        public record AsignacionInfo(string Nombre, string Matricula, string Telefono, string Atendio, int? IdCarrera);

        public record BusquedaLockerInfo(
            int IdLocker,
            string Estado,
            string Nombre,
            string Matricula,
            string Telefono, 
            string Atendio
            );

        public record PrecioItem(int IdPrecio, string Nombre, decimal Monto)
        {
            public override string ToString() => $"{Nombre}  (${Monto:0.00})";
        }

        public record CarreraItem(int IdCarrera, string Nombre)
        {
            public override string ToString() => Nombre;
        }

        // ─────────────────────────────────────────────
        // Configuración visual del DataGridView
        // ─────────────────────────────────────────────

        public static void ConfigurarGridLockers(DataGridView grid)
        {
            grid.DefaultCellStyle.Font = new Font("Century Gothic", 11F);
            grid.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            grid.RowTemplate.Height = 34;
            grid.ColumnHeadersVisible = false;
            grid.RowHeadersVisible = false;
            grid.AllowUserToAddRows = false;
            grid.AllowUserToResizeRows = false;
            grid.AllowUserToResizeColumns = false;
            grid.ReadOnly = true;
            grid.SelectionMode = DataGridViewSelectionMode.CellSelect;
            grid.MultiSelect = false;
            grid.BorderStyle = BorderStyle.None;
            grid.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            grid.GridColor = Color.LightGray;
            grid.BackgroundColor = SystemColors.Control;
        }

        // ─────────────────────────────────────────────
        // ComboBox jerárquico: Piso → Zona
        // ─────────────────────────────────────────────

        public class UbicacionItem
        {
            public string Texto { get; }
            public int Piso { get; }
            public string Zona { get; }
            public bool EsEncabezado { get; }

            public UbicacionItem(string texto, int piso, string zona, bool esEncabezado = false)
            {
                Texto = texto;
                Piso = piso;
                Zona = zona;
                EsEncabezado = esEncabezado;
            }

            public override string ToString() => Texto;
        }


        /// <summary>
        /// Rellena el ComboBox con entradas jerárquicas Piso → Zona.
        /// Las zonas se leen de la columna `zona` de la tabla lockers.
        /// </summary>
        public static void CargarZonasEnCombo(ComboBox cbUbicacion)
        {
            cbUbicacion.Items.Clear();

            try
            {
                using var conn = DBConnection.GetConnection();

                var pisos = new List<int>();
                using (var cmd = new SQLiteCommand(
                    "SELECT DISTINCT piso FROM lockers ORDER BY piso;", conn))
                using (var r = cmd.ExecuteReader())
                    while (r.Read())
                        pisos.Add(Convert.ToInt32(r["piso"]));

                foreach (int piso in pisos)
                {
                    // Encabezado visual (no seleccionable)
                    cbUbicacion.Items.Add(new UbicacionItem($"── Piso {piso} ──", piso, "", esEncabezado: true));

                    // Todo el piso
                    cbUbicacion.Items.Add(new UbicacionItem($"   Piso {piso} — Todo", piso, ""));

                    // Zonas definidas para este piso
                    using var cmdZ = new SQLiteCommand(@"
                        SELECT DISTINCT zona FROM lockers
                        WHERE piso = @p AND zona IS NOT NULL AND zona <> ''
                        ORDER BY zona;", conn);
                    cmdZ.Parameters.AddWithValue("@p", piso);
                    using var rz = cmdZ.ExecuteReader();
                    while (rz.Read())
                    {
                        string zona = rz["zona"]?.ToString() ?? string.Empty;
                        cbUbicacion.Items.Add(new UbicacionItem($"   Piso {piso} — {zona}", piso, zona));
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar zonas: " + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ─────────────────────────────────────────────
        // Carga de estados desde BD
        // ─────────────────────────────────────────────

        public static void CargarEstadosDesdeBD(Diccionario dic)
            => dic.CargarEstados();

        // ─────────────────────────────────────────────
        // MAPA GENÉRICO — lee estructura desde BD
        // ─────────────────────────────────────────────

        public static void DibujarMapaPiso(DataGridView grid, Diccionario dic, int piso, string zona = "")
        {
            var numericos = new SortedDictionary<int, SortedSet<int>>();
            var alfanumericos = new List<string>();

            try
            {
                using var conn = DBConnection.GetConnection();

                string sql = string.IsNullOrEmpty(zona)
                    ? "SELECT id_locker FROM lockers WHERE piso = @piso ORDER BY id_locker ASC"
                    : "SELECT id_locker FROM lockers WHERE piso = @piso AND zona = @zona ORDER BY id_locker ASC";

                using var cmd = new SQLiteCommand(sql, conn);
                cmd.Parameters.AddWithValue("@piso", piso);
                if (!string.IsNullOrEmpty(zona))
                    cmd.Parameters.AddWithValue("@zona", zona);

                using var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    string raw = reader["id_locker"]?.ToString() ?? string.Empty;
                    if (string.IsNullOrEmpty(raw)) continue;

                    if (int.TryParse(raw, out int id))
                    {
                        int fila = (id / 100) % 10;
                        int columna = id % 100;
                        if (!numericos.ContainsKey(fila))
                            numericos[fila] = new SortedSet<int>();
                        numericos[fila].Add(columna);
                    }
                    else
                    {
                        alfanumericos.Add(raw);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error leyendo lockers: " + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (numericos.Count == 0 && alfanumericos.Count == 0) return;

            int totalFilas = numericos.Count;
            int minColumna = 0;
            int totalCols = 0;

            // Validación agregada: Si hay elementos numéricos, se calcula en función a ellos.
            if (totalFilas > 0)
            {
                minColumna = int.MaxValue;
                int maxColumna = 0;
                foreach (var fila in numericos.Values)
                {
                    foreach (int col in fila)
                    {
                        if (col < minColumna) minColumna = col;
                        if (col > maxColumna) maxColumna = col;
                    }
                }
                totalCols = maxColumna - minColumna + 1;
            }
            else
            {
                // Si solo hay elementos alfanuméricos, necesitamos por lo menos 1 fila base y 0 cols.
                totalFilas = 1;
            }

            int colWidth = totalCols <= 60 ? 52 : 44;

            grid.SuspendLayout();
            grid.DataSource = null;
            grid.Rows.Clear();
            grid.Columns.Clear();

            for (int c = 0; c < totalCols; c++)
            {
                grid.Columns.Add("col" + c, "");
                grid.Columns[c].Width = colWidth;
            }

            // DataGridView arroja ArgumentOutOfRangeException si agregas 0 filas
            if (totalFilas > 0)
            {
                grid.Rows.Add(totalFilas);
            }
            grid.RowHeadersVisible = false;

            int rowIdx = 0;
            foreach (var kvp in numericos)
            {
                int fila = kvp.Key;
                int filaBase = piso * 1000 + fila * 100;

                // Reindexar: columna real → posición en el grid (offset por minColumna)
                foreach (int col in kvp.Value)
                {
                    int gridCol = col - minColumna;
                    if (gridCol >= 0 && gridCol < totalCols)
                        grid.Rows[rowIdx].Cells[gridCol].Value = (filaBase + col).ToString();
                }

                rowIdx++;
            }

            if (alfanumericos.Count > 0)
            {
                var saGrid = OrganizarSAEnFilas(alfanumericos, totalFilas);
                int saColCount = saGrid.GetLength(1);
                int startCol = grid.Columns.Count;

                grid.Columns.Add("sep", "");
                grid.Columns[startCol].Width = 10;
                startCol++;

                for (int sc = 0; sc < saColCount; sc++)
                {
                    grid.Columns.Add("sa" + sc, "");
                    grid.Columns[startCol + sc].Width = 110;
                }

                for (int r = 0; r < totalFilas && r < saGrid.GetLength(0); r++)
                    for (int sc = 0; sc < saColCount; sc++)
                        if (saGrid[r, sc] != null)
                            grid.Rows[r].Cells[startCol + sc].Value = saGrid[r, sc];
            }

            grid.ResumeLayout();
            ApplyEstadosEnGrid(grid, dic);
        }

        private static string[,] OrganizarSAEnFilas(List<string> alfanumericos, int totalFilas)
        {
            var porFila = new SortedDictionary<int, List<string>>();
            foreach (string id in alfanumericos)
            {
                int fila = ExtraerFilaDeSA(id, totalFilas);
                if (!porFila.ContainsKey(fila))
                    porFila[fila] = new List<string>();
                porFila[fila].Add(id);
            }

            int maxCols = 1;
            foreach (var v in porFila.Values)
                if (v.Count > maxCols) maxCols = v.Count;

            var resultado = new string[totalFilas, maxCols];
            foreach (var kvp in porFila)
            {
                int r = kvp.Key - 1;
                if (r < 0 || r >= totalFilas) r = 0;
                for (int i = 0; i < kvp.Value.Count; i++)
                    resultado[r, i] = kvp.Value[i];
            }
            return resultado;
        }

        private static int ExtraerFilaDeSA(string id, int totalFilas)
        {
            int numStart = -1;
            for (int i = id.Length - 1; i >= 0; i--)
                if (!char.IsDigit(id[i])) { numStart = i + 1; break; }
            if (numStart < 0) numStart = 0;

            string numPart = id.Substring(numStart);
            if (numPart.Length >= 4 && int.TryParse(numPart, out int num))
            {
                int fila = (num / 100) % 10;
                if (fila >= 1 && fila <= totalFilas) return fila;
            }
            return 1;
        }

        // ─────────────────────────────────────────────
        // Colores de estado
        // ─────────────────────────────────────────────

        public static void ApplyEstadosEnGrid(DataGridView grid, Diccionario dic)
        {
            if (dic == null || grid.Rows == null) return;

            foreach (DataGridViewRow row in grid.Rows)
            {
                foreach (DataGridViewCell cell in row.Cells)
                {
                    string id = cell.Value?.ToString();
                    if (string.IsNullOrEmpty(id))
                    {
                        cell.Style.BackColor = grid.BackgroundColor;
                        continue;
                    }

                    if (dic.EstadosLockers.TryGetValue(id, out string? estado))
                    {
                        cell.Style.BackColor = estado switch
                        {
                            var e when e.Equals("Disponible", StringComparison.OrdinalIgnoreCase) || e == "0" => Color.FromArgb(180, 230, 180),
                            var e when e.Equals("Ocupado", StringComparison.OrdinalIgnoreCase) || e == "1" => Color.FromArgb(173, 214, 241),
                            var e when e.Equals("Renovacion", StringComparison.OrdinalIgnoreCase) || e == "2" => Color.FromArgb(255, 229, 153),
                            _ => Color.LightGray
                        };
                        cell.Style.ForeColor = Color.FromArgb(40, 40, 40);
                    }
                    else
                    {
                        cell.Style.BackColor = Color.WhiteSmoke;
                        cell.Style.ForeColor = Color.LightGray;
                    }
                }
            }
        }

        // ─────────────────────────────────────────────
        // Búsqueda de locker
        // ─────────────────────────────────────────────

        /// <summary>
        /// Busca un locker por id numérico, nombre o matrícula del alumno asignado.
        /// Devuelve null si no encuentra resultado.
        /// </summary>
        public static List<BusquedaLockerInfo> BuscarLockers(string termino)
        {
            if (string.IsNullOrWhiteSpace(termino)) return new List<BusquedaLockerInfo>();
            string t = termino.Trim();

            try
            {
                using var conn = DBConnection.GetConnection();

                // busca por id 
                if (int.TryParse(t, out int idNum))
                {
                    const string sqlId = @"
                        SELECT l.id_locker, l.estado, l.atendido_por,
                               COALESCE(al.nombre,    '') AS nombre,
                               COALESCE(al.matricula, '') AS matricula,
                               COALESCE(al.telefono,  '') AS telefono
                        FROM   lockers l
                        LEFT JOIN asignaciones a  ON l.id_locker = a.id_locker AND a.activa = 1 AND a.atendio = 1
                        LEFT JOIN alumnos      al ON a.matricula  = al.matricula
                        WHERE  l.id_locker = @id;";
                    using var cmd = new SQLiteCommand(sqlId, conn);
                    cmd.Parameters.AddWithValue("@id", idNum);
                    using var r = cmd.ExecuteReader();
                    var resultados = new List<BusquedaLockerInfo>();
                    while (r.Read())
                    {
                        resultados.Add(new BusquedaLockerInfo(
                            Convert.ToInt32(r["id_locker"]),
                            r["estado"]?.ToString() ?? string.Empty,
                            r["nombre"]?.ToString() ?? string.Empty,
                            r["matricula"]?.ToString() ?? string.Empty,
                            r["telefono"]?.ToString() ?? string.Empty,
                            r["atendio"]?.ToString() ?? string.Empty
                            ));
                    }

                    if (resultados.Count == 0)
                    {
                        MessageBox.Show($"No se encontró el locker {idNum}.",
                            "Sin resultados", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else if (resultados.Count > 1)
                    {
                        MessageBox.Show($"Se encontraron {resultados.Count} lockers con el ID {idNum}.",
                            "Múltiples resultados", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }

                    return resultados;
                }

                // busca por nombre o matrícula (devuelve todos los resultados)
                const string sqlNombre = @"
                    SELECT l.id_locker, l.estado,  l.atendido_por,
                           al.nombre, al.matricula, al.telefono
                    FROM   asignaciones a
                    JOIN   alumnos al ON a.matricula = al.matricula
                    JOIN   lockers l  ON a.id_locker = l.id_locker
                    WHERE  a.activa = 1
                      AND  (al.nombre    LIKE @term COLLATE NOCASE
                         OR al.matricula LIKE @term COLLATE NOCASE)
                    ORDER  BY al.nombre ASC;";
                using var cmd2 = new SQLiteCommand(sqlNombre, conn);
                cmd2.Parameters.AddWithValue("@term", "%" + t + "%");
                using var r2 = cmd2.ExecuteReader();
                var resultadosNombre = new List<BusquedaLockerInfo>();
                while (r2.Read())
                {
                    resultadosNombre.Add(new BusquedaLockerInfo(
                        Convert.ToInt32(r2["id_locker"]),
                        r2["estado"]?.ToString() ?? string.Empty,
                        r2["nombre"]?.ToString() ?? string.Empty,
                        r2["matricula"]?.ToString() ?? string.Empty,
                        r2["telefono"]?.ToString() ?? string.Empty,
                        r2["atendio"]?.ToString() ?? string.Empty
                        ));
                }

                if (resultadosNombre.Count == 0)
                {
                    MessageBox.Show($"No se encontró ningún alumno con '{t}'.",
                        "Sin resultados", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else if (resultadosNombre.Count > 1)
                {
                    MessageBox.Show($"Se encontraron {resultadosNombre.Count} lockers para '{t}'.",
                        "Múltiples resultados", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                return resultadosNombre;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error en búsqueda: " + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return new List<BusquedaLockerInfo>(); // Devuelve una lista vacía en caso de error
            }
        }

        // ─────────────────────────────────────────────
        // Verificación automática de vencimiento
        // ─────────────────────────────────────────────

        /// <summary>
        /// Verifica si existe un periodo de renovación vencido.
        /// Si es así, muestra aviso al usuario y, si confirma, cierra el periodo:
        ///   - Asignaciones de lockers en estado Renovación → inactivas
        ///   - Lockers en estado Renovación → Disponible (estado 0)
        ///   - Periodo → marcado como procesado
        /// </summary>
        public static bool VerificarYCerrarVencimiento(IWin32Window owner)
        {
            try
            {
                using var conn = DBConnection.GetConnection();

                // Buscar periodo vencido usando rowid como clave interna
                // (id_renovacion puede ser NULL si no tiene AUTOINCREMENT configurado)
                const string sqlCheck = @"
                    SELECT rowid, fecha_fin
                    FROM   Renovacion
                    WHERE  fecha_fin IS NOT NULL
                      AND  date(fecha_fin) < date('now')
                    ORDER  BY fecha_fin DESC
                    LIMIT  1;";

                long? idRenovacion = null;
                string? fechaFinStr = null;

                using (var cmd = new SQLiteCommand(sqlCheck, conn))
                using (var r = cmd.ExecuteReader())
                {
                    if (r.Read())
                    {
                        var rawId = r["rowid"];
                        if (rawId != DBNull.Value && rawId != null)
                            idRenovacion = Convert.ToInt64(rawId);
                        var rawFin = r["fecha_fin"];
                        if (rawFin != DBNull.Value && rawFin != null)
                            fechaFinStr = rawFin.ToString();
                    }
                }

                if (!idRenovacion.HasValue) return false;

                string fechaMostrar = "--/--/----";
                if (DateTime.TryParse(fechaFinStr, out DateTime ff))
                    fechaMostrar = ff.ToLocalTime().ToString("dd/MM/yyyy");

                var dr = MessageBox.Show(
                    $"El periodo de renovación venció el {fechaMostrar}.\n\n" +
                    "Los lockers que NO renovaron quedarán DISPONIBLES y sus asignaciones se cerrarán.\n" +
                    "Los lockers que sí renovaron (estado Ocupado) no se verán afectados.\n\n" +
                    "¿Desea cerrar el periodo ahora?",
                    "Periodo de renovación vencido",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning,
                    MessageBoxDefaultButton.Button1);

                if (dr != DialogResult.Yes) return false;

                using var tran = conn.BeginTransaction();

                // PASO 1: Desactivar asignaciones de lockers en Renovacion
                using (var cmd = new SQLiteCommand(@"
                    UPDATE asignaciones
                    SET    activa = 0, fecha_fin = date('now')
                    WHERE  activa = 1
                      AND  id_locker IN (
                               SELECT id_locker FROM lockers
                               WHERE  estado = 'Renovacion' OR estado = '2'
                           );", conn, tran))
                    cmd.ExecuteNonQuery();

                // PASO 2: Lockers en Renovacion → Disponible
                using (var cmd = new SQLiteCommand(@"
                    UPDATE lockers
                    SET    estado = 'Disponible'
                    WHERE  estado = 'Renovacion' OR estado = '2';", conn, tran))
                    cmd.ExecuteNonQuery();

                // PASO 3: Eliminar registro de Renovacion
                using (var cmd = new SQLiteCommand(
                    "DELETE FROM Renovacion WHERE rowid = @id;", conn, tran))
                {
                    cmd.Parameters.AddWithValue("@id", idRenovacion.Value);
                    cmd.ExecuteNonQuery();
                }

                tran.Commit();

                MessageBox.Show(
                    "Periodo cerrado correctamente.\nLos lockers sin renovar están disponibles.",
                    "Periodo cerrado", MessageBoxButtons.OK, MessageBoxIcon.Information);

                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cerrar el periodo: " + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        // ─────────────────────────────────────────────
        // Consultas de alumnos / asignaciones
        // ─────────────────────────────────────────────

        public static AsignacionInfo? ObtenerAlumnoAsignadoPorLocker(int idLocker)
        {
            try
            {
                using var conn = DBConnection.GetConnection();
                const string sql = @"
                    SELECT al.nombre, al.matricula, al.telefono, atendido_por, al.id_carrera
                    FROM   asignaciones a
                    JOIN   alumnos al ON a.matricula = al.matricula
                    WHERE  a.id_locker = @id AND a.activa = 1
                    LIMIT  1;";
                using var cmd = new SQLiteCommand(sql, conn);
                cmd.Parameters.AddWithValue("@id", idLocker);
                using var reader = cmd.ExecuteReader();
                if (reader.Read())
                    return new AsignacionInfo(
                        reader["nombre"]?.ToString() ?? string.Empty,
                        reader["matricula"]?.ToString() ?? string.Empty,
                        reader["telefono"]?.ToString() ?? string.Empty,
                        reader["atendido_por"]?.ToString() ?? string.Empty,
                        reader["id_carrera"] != DBNull.Value ? 
                        Convert.ToInt32(reader["id_carrera"]) : (int?)null);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al obtener asignación: " + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return null;
        }

        /// <summary>
        /// Devuelve la matrícula del alumno con asignación activa en ese locker, o null.
        /// Funciona tanto con lockers numéricos como alfanuméricos (SA_*).
        /// </summary>
        public static string? ObtenerMatriculaPorLocker(string idLocker)
        {
            try
            {
                using var conn = DBConnection.GetConnection();
                using var cmd = new SQLiteCommand(
                    "SELECT matricula FROM asignaciones WHERE id_locker = @id AND activa = 1 LIMIT 1;", conn);
                cmd.Parameters.AddWithValue("@id", idLocker);
                return cmd.ExecuteScalar()?.ToString();
            }
            catch { return null; }
        }

        /// <summary>
        /// Devuelve el id_locker actual activo de un alumno, o null si no tiene.
        /// Devuelve el valor como string para soportar IDs alfanuméricos.
        /// </summary>
        public static string? ObtenerLockerActivoPorMatricula(string matricula)
        {
            try
            {
                using var conn = DBConnection.GetConnection();
                using var cmd = new SQLiteCommand(
                    "SELECT id_locker FROM asignaciones WHERE matricula = @mat AND activa = 1 LIMIT 1;", conn);
                cmd.Parameters.AddWithValue("@mat", matricula);
                return cmd.ExecuteScalar()?.ToString();
            }
            catch { return null; }
        }

        /// <summary>
        /// Ejecuta la renovación: cierra la asignación anterior y abre una nueva
        /// en el locker destino (puede ser el mismo u otro distinto).
        /// Actualiza el estado de ambos lockers si cambian.
        /// </summary>
        public static bool EjecutarRenovacion(string matricula, string lockerAnterior, int lockerNuevo, string atendido_por)
        {
            try
            {
                using var conn = DBConnection.GetConnection();
                using var tran = conn.BeginTransaction();

                // Cerrar asignación anterior
                using (var cmd = new SQLiteCommand(@"
                    UPDATE asignaciones SET activa = 0, fecha_fin = date('now')
                    WHERE  matricula = @mat AND id_locker = @lockerViejo AND activa = 1;",
                    conn, tran))
                {
                    cmd.Parameters.AddWithValue("@mat", matricula);
                    cmd.Parameters.AddWithValue("@lockerViejo", lockerAnterior);
                    cmd.ExecuteNonQuery();
                }

                // Si cambió de locker, liberar el anterior
                if (lockerAnterior != lockerNuevo.ToString())
                {
                    using var liberar = new SQLiteCommand(
                        "UPDATE lockers SET estado = 'Disponible' WHERE id_locker = @id;", conn, tran);
                    liberar.Parameters.AddWithValue("@id", lockerAnterior);
                    liberar.ExecuteNonQuery();
                }

                // Crear nueva asignación en el locker nuevo
                using (var ins = new SQLiteCommand(@"
                    INSERT INTO asignaciones (matricula, id_locker, fecha_inicio, fecha_fin, activa, atendio)
                    VALUES (@mat, @locker, date('now'), NULL, 1, @atendio);", conn, tran))
                {
                    ins.Parameters.AddWithValue("@mat", matricula);
                    ins.Parameters.AddWithValue("@locker", lockerNuevo);
                    ins.Parameters.AddWithValue("@atendio", atendido_por);
                    ins.ExecuteNonQuery();
                }

                // Marcar locker nuevo como Ocupado
                using (var upd = new SQLiteCommand(
                    "UPDATE lockers SET estado = 'Ocupado' WHERE id_locker = @id;", conn, tran))
                {
                    upd.Parameters.AddWithValue("@id", lockerNuevo);
                    upd.ExecuteNonQuery();
                }

                tran.Commit();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al renovar: " + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        public static bool ExisteAlumno(string matricula, SQLiteConnection conn)
        {
            using var cmd = new SQLiteCommand(
                "SELECT COUNT(1) FROM alumnos WHERE matricula = @mat LIMIT 1;", conn);
            cmd.Parameters.AddWithValue("@mat", matricula);
            return Convert.ToInt32(cmd.ExecuteScalar()) > 0;
        }

        public static bool AlumnoTieneAsignacionActiva(string matricula)
        {
            try
            {
                using var conn = DBConnection.GetConnection();
                using var cmd = new SQLiteCommand(
                    "SELECT COUNT(1) FROM asignaciones WHERE matricula = @mat AND activa = 1;", conn);
                cmd.Parameters.AddWithValue("@mat", matricula);
                return Convert.ToInt32(cmd.ExecuteScalar()) > 0;
            }
            catch { return false; }
        }

        public static bool EsLockerDisponible(int idLocker)
        {
            try
            {
                using var conn = DBConnection.GetConnection();
                using var cmd = new SQLiteCommand(
                    "SELECT estado FROM lockers WHERE id_locker = @id LIMIT 1;", conn);
                cmd.Parameters.AddWithValue("@id", idLocker);
                var estado = cmd.ExecuteScalar()?.ToString() ?? string.Empty;
                return estado.Equals("Disponible", StringComparison.OrdinalIgnoreCase) || estado == "0";
            }
            catch { return false; }
        }

        // ─────────────────────────────────────────────
        // Usuarios del sistema
        // ─────────────────────────────────────────────

        public static void InsertUsuario(string nombre, string contrasenaHash, string rol)
        {
            using var conn = DBConnection.GetConnection();
            using var cmd = new SQLiteCommand(
                "INSERT INTO usuarios_sistema (nombre, contrasena, tipo_usuario) VALUES (@nombre, @contrasena, @rol);",
                conn);
            cmd.Parameters.AddWithValue("@nombre", nombre);
            cmd.Parameters.AddWithValue("@contrasena", contrasenaHash);
            cmd.Parameters.AddWithValue("@rol", rol);
            cmd.ExecuteNonQuery();
        }

        public static int GetUsuariosCount()
        {
            using var conn = DBConnection.GetConnection();
            using var cmd = new SQLiteCommand("SELECT COUNT(*) FROM usuarios_sistema;", conn);
            return Convert.ToInt32(cmd.ExecuteScalar());
        }

        public static string HashPassword(string input)
        {
            using var sha = SHA256.Create();
            byte[] hash = sha.ComputeHash(Encoding.UTF8.GetBytes(input));
            var sb = new StringBuilder(hash.Length * 2);
            foreach (byte b in hash) sb.AppendFormat("{0:x2}", b);
            return sb.ToString();
        }

        // ─────────────────────────────────────────────
        // Precios
        // ─────────────────────────────────────────────

        public static List<PrecioItem> CargarPrecios()
        {
            var lista = new List<PrecioItem>();
            try
            {
                using var conn = DBConnection.GetConnection();
                using var cmd = new SQLiteCommand(
                    "SELECT id_precio, nombre, monto FROM precios WHERE activo = 1 ORDER BY monto ASC;", conn);
                using var r = cmd.ExecuteReader();
                while (r.Read())
                    lista.Add(new PrecioItem(
                        Convert.ToInt32(r["id_precio"]),
                        r["nombre"]?.ToString() ?? string.Empty,
                        Convert.ToDecimal(r["monto"])));
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error cargando precios: " + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return lista;
        }

        public static void GuardarPrecio(string nombre, decimal monto, string descripcion, int? idExistente = null)
        {
            using var conn = DBConnection.GetConnection();
            if (idExistente.HasValue)
            {
                using var cmd = new SQLiteCommand(
                    "UPDATE precios SET nombre=@n, monto=@m, descripcion=@d WHERE id_precio=@id;", conn);
                cmd.Parameters.AddWithValue("@n", nombre);
                cmd.Parameters.AddWithValue("@m", monto);
                cmd.Parameters.AddWithValue("@d", descripcion);
                cmd.Parameters.AddWithValue("@id", idExistente.Value);
                cmd.ExecuteNonQuery();
            }
            else
            {
                using var cmd = new SQLiteCommand(
                    "INSERT INTO precios (nombre, monto, descripcion, activo) VALUES (@n, @m, @d, 1);", conn);
                cmd.Parameters.AddWithValue("@n", nombre);
                cmd.Parameters.AddWithValue("@m", monto);
                cmd.Parameters.AddWithValue("@d", descripcion);
                cmd.ExecuteNonQuery();
            }
        }

        public static void TogglePrecioActivo(int idPrecio, bool activo)
        {
            using var conn = DBConnection.GetConnection();
            using var cmd = new SQLiteCommand(
                "UPDATE precios SET activo = @a WHERE id_precio = @id;", conn);
            cmd.Parameters.AddWithValue("@a", activo ? 1 : 0);
            cmd.Parameters.AddWithValue("@id", idPrecio);
            cmd.ExecuteNonQuery();
        }

        // ─────────────────────────────────────────────
        // Carreras
        // ─────────────────────────────────────────────

        public static List<CarreraItem> CargarCarreras()
        {
            var lista = new List<CarreraItem>();
            try
            {
                using var conn = DBConnection.GetConnection();
                using var cmd = new SQLiteCommand(
                    "SELECT id_carrera, nombre FROM carreras WHERE activa = 1 ORDER BY nombre ASC;", conn);
                using var r = cmd.ExecuteReader();
                while (r.Read())
                    lista.Add(new CarreraItem(
                        Convert.ToInt32(r["id_carrera"]),
                        r["nombre"]?.ToString() ?? string.Empty));
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error cargando carreras: " + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return lista;
        }

        public static void AgregarCarrera(string nombre)
        {
            using var conn = DBConnection.GetConnection();
            using var cmd = new SQLiteCommand(
                "INSERT OR IGNORE INTO carreras (nombre, activa) VALUES (@n, 1);", conn);
            cmd.Parameters.AddWithValue("@n", nombre.Trim().ToUpper());
            cmd.ExecuteNonQuery();
        }

        // ─────────────────────────────────────────────
        // Actualizar alumno con carrera
        // ─────────────────────────────────────────────

        public static void ActualizarCarreraAlumno(string matricula, int idCarrera)
        {
            using var conn = DBConnection.GetConnection();
            using var cmd = new SQLiteCommand(
                "UPDATE alumnos SET id_carrera = @c WHERE matricula = @m;", conn);
            cmd.Parameters.AddWithValue("@c", idCarrera);
            cmd.Parameters.AddWithValue("@m", matricula);
            cmd.ExecuteNonQuery();
        }

        // ─────────────────────────────────────────────
        // Reporte CSV ampliado
        // ─────────────────────────────────────────────

        public static string GenerarReporteCSV()
        {
            var sb = new StringBuilder();

            // Encabezados
            sb.AppendLine("Locker,Piso,Zona,Nombre,Matricula,Telefono,Carrera,Fecha Asignacion,Fecha Ultima Renovacion,Periodos Renovados,Precio,Monto Pagado,Total Acumulado");

            using var conn = DBConnection.GetConnection();
            const string sql = @"
                SELECT
                    a.id_locker,
                    l.piso,
                    l.zona,
                    al.nombre,
                    al.matricula,
                    al.telefono,
                    COALESCE(c.nombre, '') AS carrera,
                    a.fecha_inicio,
                    (SELECT MAX(a2.fecha_inicio)
                     FROM asignaciones a2
                     WHERE a2.matricula = a.matricula
                       AND a2.id_locker = a.id_locker
                       AND a2.activa = 0) AS ultima_renovacion,
                    (SELECT COUNT(*)
                     FROM asignaciones a3
                     WHERE a3.matricula = a.matricula
                       AND a3.activa = 0) AS periodos_renovados,
                    COALESCE(p.nombre, '') AS precio_nombre,
                    COALESCE(a.monto_pagado, 0) AS monto_pagado,
                    (SELECT COALESCE(SUM(a4.monto_pagado), 0)
                     FROM asignaciones a4
                     WHERE a4.matricula = a.matricula) AS total_acumulado
                FROM asignaciones a
                JOIN alumnos al ON a.matricula = al.matricula
                JOIN lockers  l  ON a.id_locker = l.id_locker
                LEFT JOIN carreras c ON al.id_carrera = c.id_carrera
                LEFT JOIN precios  p ON a.id_precio   = p.id_precio
                WHERE a.activa = 1
                ORDER BY l.piso, l.zona, CAST(a.id_locker AS INTEGER);";

            using var cmd = new SQLiteCommand(sql, conn);
            using var reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                sb.AppendLine(string.Join(",",
                    EscapeCsv(reader["id_locker"]?.ToString()),
                    EscapeCsv(reader["piso"]?.ToString()),
                    EscapeCsv(reader["zona"]?.ToString()),
                    EscapeCsv(reader["nombre"]?.ToString()),
                    EscapeCsv(reader["matricula"]?.ToString()),
                    EscapeCsv(reader["telefono"]?.ToString()),
                    EscapeCsv(reader["carrera"]?.ToString()),
                    EscapeCsv(reader["fecha_inicio"]?.ToString()),
                    EscapeCsv(reader["ultima_renovacion"]?.ToString()),
                    EscapeCsv(reader["periodos_renovados"]?.ToString()),
                    EscapeCsv(reader["precio_nombre"]?.ToString()),
                    EscapeCsv(reader["monto_pagado"]?.ToString()),
                    EscapeCsv(reader["total_acumulado"]?.ToString())
                ));
            }

            return sb.ToString();
        }


        // ─────────────────────────────────────────────
        // Actualizar datos del alumno
        // ─────────────────────────────────────────────

        /// <summary>
        /// Actualiza nombre, teléfono y carrera del alumno.
        /// Se usa durante el flujo de renovación para permitir correcciones.
        /// </summary>
        public static void ActualizarDatosAlumno(string matricula, string nombre, string telefono, int? idCarrera)
        {
            using var conn = DBConnection.GetConnection();
            using var cmd = new SQLiteCommand(@"
                UPDATE alumnos
                SET nombre    = @nombre,
                    telefono  = @telefono,
                    id_carrera = @carrera
                WHERE matricula = @mat;", conn);
            cmd.Parameters.AddWithValue("@nombre", nombre);
            cmd.Parameters.AddWithValue("@telefono", telefono);
            cmd.Parameters.AddWithValue("@carrera", idCarrera.HasValue ? (object)idCarrera.Value : DBNull.Value);
            cmd.Parameters.AddWithValue("@mat", matricula);
            cmd.ExecuteNonQuery();
        }

        private static string EscapeCsv(string? value)
        {
            if (string.IsNullOrEmpty(value)) return string.Empty;
            string esc = value.Replace("\"", "\"\"");
            return (esc.Contains(',') || esc.Contains('"') || esc.Contains('\n') || esc.Contains('\r'))
                ? $"\"{esc}\"" : esc;
        }

    }
}