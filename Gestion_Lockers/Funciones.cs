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
    internal static class Funciones
    {
        // ─────────────────────────────────────────────
        // Tipos de datos
        // ─────────────────────────────────────────────

        internal record AsignacionInfo(string Nombre, string Matricula, string Telefono);

        // ─────────────────────────────────────────────
        // Configuración visual del DataGridView
        // ─────────────────────────────────────────────

        /// <summary>
        /// Aplica fuente grande, alto de fila y estilo general al grid de lockers.
        /// Llamar una sola vez en Principal_Load.
        /// </summary>
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
        // Carga de pisos en ComboBox
        // ─────────────────────────────────────────────

        public static void CargarPisos(ComboBox cbUbicacion)
        {
            try
            {
                using var conn = DBConnection.GetConnection();
                using var cmd = new SQLiteCommand(
                    "SELECT DISTINCT piso FROM lockers ORDER BY piso", conn);
                using var reader = cmd.ExecuteReader();

                cbUbicacion.Items.Clear();
                while (reader.Read())
                    cbUbicacion.Items.Add("Piso " + reader["piso"]);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar pisos: " + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ─────────────────────────────────────────────
        // Carga de estados desde BD al diccionario
        // ─────────────────────────────────────────────

        public static void CargarEstadosDesdeBD(Diccionario dic)
            => dic.CargarEstados();

        // ─────────────────────────────────────────────
        // MAPA GENÉRICO — lee estructura desde la BD
        // ─────────────────────────────────────────────

        /// <summary>
        /// Dibuja el mapa de lockers de un piso leyendo la BD.
        /// Los lockers numéricos se organizan en filas (centenas del id).
        /// Los lockers con id alfanumérico (SA_*) se añaden al final como columnas extra.
        /// </summary>
        public static void DibujarMapaPiso(DataGridView grid, Diccionario dic, int piso)
        {
            // 1. Leer todos los lockers del piso
            var numericos = new SortedDictionary<int, SortedSet<int>>(); // fila → columnas
            var alfanumericos = new List<string>();                          // SA_*, SA-DAVID_*, etc.

            try
            {
                using var conn = DBConnection.GetConnection();
                using var cmd = new SQLiteCommand(
                    "SELECT id_locker FROM lockers WHERE piso = @piso ORDER BY id_locker ASC", conn);
                cmd.Parameters.AddWithValue("@piso", piso);
                using var reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    string raw = reader["id_locker"]?.ToString() ?? string.Empty;
                    if (string.IsNullOrEmpty(raw)) continue;

                    if (int.TryParse(raw, out int id))
                    {
                        // id numérico: extraer fila (centenas) y columna (decenas+unidades)
                        int fila = (id / 100) % 10;   // p.e. 2304 → 3
                        int columna = id % 100;           // p.e. 2304 → 4
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
                MessageBox.Show("Error leyendo lockers del piso: " + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (numericos.Count == 0 && alfanumericos.Count == 0) return;

            // 2. Calcular dimensiones del grid
            int totalFilas = numericos.Count;
            int maxColumna = 0;
            foreach (var fila in numericos.Values)
                foreach (int col in fila)
                    if (col > maxColumna) maxColumna = col;

            // Determinar ancho de columna según cantidad
            int colWidth = maxColumna <= 60 ? 52 : 44;

            // 3. Construir el grid base (solo numércos)
            grid.SuspendLayout();
            grid.DataSource = null;
            grid.Rows.Clear();
            grid.Columns.Clear();

            for (int c = 1; c <= maxColumna; c++)
            {
                grid.Columns.Add("col" + c, "");
                grid.Columns[c - 1].Width = colWidth;
            }

            grid.Rows.Add(totalFilas);
            grid.RowHeadersVisible = false;

            // 4. Rellenar valores numéricos
            int rowIdx = 0;
            foreach (var kvp in numericos)
            {
                int fila = kvp.Key;
                int pisoBase = piso * 1000;
                int filaBase = pisoBase + fila * 100;

                for (int c = 1; c <= maxColumna; c++)
                {
                    int idLocker = filaBase + c;
                    // Solo poner valor si ese locker existe en BD
                    if (kvp.Value.Contains(c))
                        grid.Rows[rowIdx].Cells[c - 1].Value = idLocker.ToString();
                }
                rowIdx++;
            }

            // 5. Agregar columnas extra para SA_* (grupos separados por fila)
            if (alfanumericos.Count > 0)
            {
                // Agrupar SA por posición de fila implícita (mismo dígito de centena que los numéricos)
                // Colocarlos en columnas extra al final, agrupados en filas equivalentes
                var saGrid = OrganizarSAEnFilas(alfanumericos, totalFilas);

                int saColCount = saGrid.GetLength(1);
                int startCol = grid.Columns.Count;

                // Columna separadora vacía
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

            // 6. Aplicar colores de estado
            ApplyEstadosEnGrid(grid, dic);
        }

        /// <summary>
        /// Organiza los lockers SA en una matriz [filas x columnas] deduciendo la fila
        /// a partir del dígito de centena embebido en el nombre (SA_3261 → fila 2 del piso 3).
        /// </summary>
        private static string[,] OrganizarSAEnFilas(List<string> alfanumericos, int totalFilas)
        {
            // Construir diccionario fila → lista de ids
            var porFila = new SortedDictionary<int, List<string>>();
            foreach (string id in alfanumericos)
            {
                int fila = ExtraerFilaDeSA(id, totalFilas);
                if (!porFila.ContainsKey(fila))
                    porFila[fila] = new List<string>();
                porFila[fila].Add(id);
            }

            // Máximo de SA por fila → número de columnas
            int maxCols = 1;
            foreach (var v in porFila.Values)
                if (v.Count > maxCols) maxCols = v.Count;

            var resultado = new string[totalFilas, maxCols];
            foreach (var kvp in porFila)
            {
                // Mapear fila del SA (1-based centenas) a rowIndex (0-based)
                int rowIdx = kvp.Key - 1;
                if (rowIdx < 0 || rowIdx >= totalFilas) rowIdx = 0;
                for (int i = 0; i < kvp.Value.Count; i++)
                    resultado[rowIdx, i] = kvp.Value[i];
            }

            return resultado;
        }

        /// <summary>
        /// Extrae el índice de fila (1-4) de un id SA_* buscando el dígito de centena
        /// dentro del número embebido al final del string (ej. SA_3261 → 2).
        /// </summary>
        private static int ExtraerFilaDeSA(string id, int totalFilas)
        {
            // Buscar secuencia de 4 dígitos al final del string
            int numStart = -1;
            for (int i = id.Length - 1; i >= 0; i--)
            {
                if (!char.IsDigit(id[i])) { numStart = i + 1; break; }
            }
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
        // Aplicar colores de estado al grid
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
                        // id existe en el grid pero no en BD → celda hueca
                        cell.Style.BackColor = Color.WhiteSmoke;
                        cell.Style.ForeColor = Color.LightGray;
                    }
                }
            }
        }

        // ─────────────────────────────────────────────
        // Consultas de alumnos / asignaciones
        // ─────────────────────────────────────────────

        /// <summary>
        /// Devuelve la info del alumno con asignación activa en ese locker, o null.
        /// </summary>
        public static AsignacionInfo? ObtenerAlumnoAsignadoPorLocker(int idLocker)
        {
            try
            {
                using var conn = DBConnection.GetConnection();
                const string sql = @"
                    SELECT al.nombre, al.matricula, al.telefono
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
                        reader["telefono"]?.ToString() ?? string.Empty);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al obtener asignación: " + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return null;
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
                return estado.Equals("Disponible", StringComparison.OrdinalIgnoreCase)
                    || estado == "0";
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
    }
}