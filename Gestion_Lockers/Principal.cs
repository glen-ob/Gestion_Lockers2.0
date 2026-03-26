using System;
using System.Data.SQLite;
using System.Diagnostics;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace Gestion_Lockers
{
    public partial class Principal : Form
    {
        private int? selectedLockerId = null;
        private int currentUserId;
        private string currentUserRole = string.Empty;

        private readonly Diccionario diccionario = new Diccionario();

        // ─────────────────────────────────────────────
        // Constructores
        // ─────────────────────────────────────────────

        public Principal()
        {
            InitializeComponent();
            SuscribirEventos();
            LimpiarLabels();
        }

        public Principal(int userId, string role) : this()
        {
            currentUserId = userId;
            currentUserRole = role;
        }

        // ─────────────────────────────────────────────
        // Suscripción de eventos (una sola vez)
        // ─────────────────────────────────────────────

        private void SuscribirEventos()
        {
            Load += Principal_Load;
            cbUbicacion.SelectedIndexChanged += CbUbicacion_SelectedIndexChanged;
            dataGridView1.CellClick += DataGridView1_CellClick;
            btnAsignar.Click += BtnAsignar_Click;
            btnRenovar.Click += BtnRenovar_Click;
        }

        // ─────────────────────────────────────────────
        // Carga inicial
        // ─────────────────────────────────────────────

        private void Principal_Load(object? sender, EventArgs e)
        {
            lblFecha.Text = DateTime.Now.ToString("dd/MM/yyyy");

            // Fecha fin de renovación más reciente
            try
            {
                using var conn = DBConnection.GetConnection();
                using var cmd = new SQLiteCommand(
                    "SELECT fecha_fin FROM Renovacion ORDER BY fecha_inicio DESC LIMIT 1;", conn);
                var obj = cmd.ExecuteScalar();
                lblFechaRenovacion.Text =
                    obj != null && obj != DBNull.Value && DateTime.TryParse(obj.ToString(), out DateTime ff)
                        ? ff.ToString("dd/MM/yyyy")
                        : "--/--/----";
            }
            catch
            {
                lblFechaRenovacion.Text = "--/--/----";
            }

            // Configurar apariencia del grid (fuente, alto de fila, etc.)
            Funciones.ConfigurarGridLockers(dataGridView1);

            // Cargar datos iniciales
            try
            {
                Funciones.CargarPisos(cbUbicacion);
                Funciones.CargarEstadosDesdeBD(diccionario);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error inicializando interfaz: {ex.Message}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            AplicarPermisosRol();
        }

        // ─────────────────────────────────────────────
        // Permisos según rol
        // ─────────────────────────────────────────────

        private void AplicarPermisosRol()
        {
            bool esAdmin = EsAdmin();

            ingresarToolStripMenuItem1.Enabled = esAdmin;
            eliminarToolStripMenuItem.Enabled = esAdmin;
            periodoDeRenovacionToolStripMenuItem.Enabled = esAdmin;
            cancelarRenovacionToolStripMenuItem.Enabled = esAdmin;
            reportesToolStripMenuItem.Enabled = esAdmin;
            usuariosToolStripMenuItem.Enabled = esAdmin;
            funcionalidadesToolStripMenuItem.Enabled = esAdmin;
        }

        // ─────────────────────────────────────────────
        // Selección de piso — dibuja el mapa
        // ─────────────────────────────────────────────

        private void CbUbicacion_SelectedIndexChanged(object? sender, EventArgs e)
        {
            string texto = cbUbicacion.Text?.Trim() ?? string.Empty;

            try
            {
                // Extraer el número de piso del texto "Piso X"
                if (texto.StartsWith("Piso ", StringComparison.OrdinalIgnoreCase)
                    && int.TryParse(texto.Substring(5).Trim(), out int numeroPiso))
                {
                    Funciones.CargarEstadosDesdeBD(diccionario);
                    Funciones.DibujarMapaPiso(dataGridView1, diccionario, numeroPiso);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error dibujando mapa: {ex.Message}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            selectedLockerId = null;
            LimpiarLabels();
        }

        // ─────────────────────────────────────────────
        // Clic en celda del grid
        // ─────────────────────────────────────────────

        private void DataGridView1_CellClick(object? sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0) return;

            var valor = dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value?.ToString();
            if (string.IsNullOrWhiteSpace(valor))
            {
                selectedLockerId = null;
                LimpiarLabels();
                return;
            }

            if (int.TryParse(valor, out int idLocker))
            {
                selectedLockerId = idLocker;
                lblCasillero.Text = idLocker.ToString();

                var info = Funciones.ObtenerAlumnoAsignadoPorLocker(idLocker);
                if (info is not null)
                {
                    lblNombre.Text = info.Nombre;
                    lblMatricula.Text = info.Matricula;
                    TXTNombre.Text = info.Nombre;
                    txtMatricula.Text = info.Matricula;
                    txtTelefono.Text = info.Telefono;
                }
                else
                {
                    lblNombre.Text = "Sin asignar";
                    lblMatricula.Text = "-";
                    LimpiarCamposAlumno();
                }
            }
            else
            {
                // Locker alfanumérico (SA_*) — no asignable por el momento
                selectedLockerId = null;
                LimpiarLabels();
            }
        }

        // ─────────────────────────────────────────────
        // Asignar locker
        // ─────────────────────────────────────────────

        private void BtnAsignar_Click(object? sender, EventArgs e)
        {
            string nombre = TXTNombre.Text.Trim();
            string telefono = txtTelefono.Text.Trim();
            string matricula = txtMatricula.Text.Trim();

            // Validaciones de campos
            if (string.IsNullOrEmpty(nombre) || string.IsNullOrEmpty(matricula) || string.IsNullOrEmpty(telefono))
            {
                MessageBox.Show("Todos los campos (Nombre, Matrícula, Teléfono) son obligatorios.",
                    "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!Regex.IsMatch(matricula, @"^[a-zA-Z0-9]+$"))
            {
                MessageBox.Show("La matrícula solo puede contener caracteres alfanuméricos.",
                    "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!Regex.IsMatch(telefono, @"^\d{10}$"))
            {
                MessageBox.Show("El teléfono debe tener exactamente 10 dígitos.",
                    "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!selectedLockerId.HasValue)
            {
                MessageBox.Show("Seleccione un casillero en el mapa antes de asignar.",
                    "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (Funciones.AlumnoTieneAsignacionActiva(matricula))
            {
                MessageBox.Show("El alumno ya tiene un locker asignado activo.",
                    "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            bool grupoAcademico = rbGrupoAcademico?.Checked ?? false;
            bool grupoCultural = rbGrupoCultural?.Checked ?? false;

            // Grupos especiales requieren administrador
            if ((grupoAcademico || grupoCultural) && !EsAdmin())
            {
                var dr = MessageBox.Show(
                    "Para asignar grupos académico/cultural se requiere inicio de sesión de administrador. ¿Desea continuar?",
                    "Requiere administrador", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (dr != DialogResult.Yes) return;

                using var login = new frm_Inicio();
                if (login.ShowDialog(this) != DialogResult.OK
                    || !login.UserRole.Equals("Administrador", StringComparison.OrdinalIgnoreCase))
                {
                    MessageBox.Show("Inicio de sesión fallido o usuario no es administrador.",
                        "Permiso denegado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                currentUserId = login.UserId;
                currentUserRole = login.UserRole;
            }

            if (!Funciones.EsLockerDisponible(selectedLockerId.Value))
            {
                MessageBox.Show("El casillero seleccionado no está disponible.",
                    "No disponible", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Persistir asignación
            try
            {
                using var conn = DBConnection.GetConnection();
                using var tran = conn.BeginTransaction();

                bool gAcad = EsAdmin() && grupoAcademico;
                bool gCult = EsAdmin() && grupoCultural;

                if (Funciones.ExisteAlumno(matricula, conn))
                {
                    using var upd = new SQLiteCommand(@"
                        UPDATE alumnos
                        SET nombre=@nombre, telefono=@telefono,
                            grupo_academico=@gAcad, grupo_cultural=@gCult
                        WHERE matricula=@mat;", conn, tran);
                    upd.Parameters.AddWithValue("@nombre", nombre);
                    upd.Parameters.AddWithValue("@telefono", telefono);
                    upd.Parameters.AddWithValue("@gAcad", gAcad ? 1 : 0);
                    upd.Parameters.AddWithValue("@gCult", gCult ? 1 : 0);
                    upd.Parameters.AddWithValue("@mat", matricula);
                    upd.ExecuteNonQuery();
                }
                else
                {
                    using var ins = new SQLiteCommand(@"
                        INSERT INTO alumnos (matricula, nombre, telefono, grupo_academico, grupo_cultural)
                        VALUES (@mat, @nombre, @telefono, @gAcad, @gCult);", conn, tran);
                    ins.Parameters.AddWithValue("@mat", matricula);
                    ins.Parameters.AddWithValue("@nombre", nombre);
                    ins.Parameters.AddWithValue("@telefono", telefono);
                    ins.Parameters.AddWithValue("@gAcad", gAcad ? 1 : 0);
                    ins.Parameters.AddWithValue("@gCult", gCult ? 1 : 0);
                    ins.ExecuteNonQuery();
                }

                using var insAsig = new SQLiteCommand(@"
                    INSERT INTO asignaciones (matricula, id_locker, fecha_inicio, fecha_fin, activa)
                    VALUES (@mat, @id, @fecha, NULL, 1);", conn, tran);
                insAsig.Parameters.AddWithValue("@mat", matricula);
                insAsig.Parameters.AddWithValue("@id", selectedLockerId.Value);
                insAsig.Parameters.AddWithValue("@fecha", DateTime.UtcNow.ToString("o"));
                insAsig.ExecuteNonQuery();

                using var updLocker = new SQLiteCommand(
                    "UPDATE lockers SET estado = '1' WHERE id_locker = @id;", conn, tran);
                updLocker.Parameters.AddWithValue("@id", selectedLockerId.Value);
                updLocker.ExecuteNonQuery();

                tran.Commit();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error realizando la asignación: {ex.Message}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            MessageBox.Show("Asignación realizada correctamente.", "Éxito",
                MessageBoxButtons.OK, MessageBoxIcon.Information);

            RefrescarMapa();
            LimpiarCamposAlumno();
            LimpiarLabels();
        }

        // ─────────────────────────────────────────────
        // Renovar locker seleccionado
        // ─────────────────────────────────────────────

        private void BtnRenovar_Click(object? sender, EventArgs e)
        {
            if (!selectedLockerId.HasValue)
            {
                MessageBox.Show("Seleccione un casillero en el mapa para renovar.",
                    "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                var frmRev = new frmRenovacionFuncion();
                frmRev.StartPosition = FormStartPosition.CenterParent;
                frmRev.ShowDialog(this);
                RefrescarMapa();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"No se pudo abrir el formulario de renovación: {ex.Message}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ─────────────────────────────────────────────
        // Menú — Mapa
        // ─────────────────────────────────────────────

        //private void verToolStripMenuItem_Click(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        var mapa = new Mapa();
        //        mapa.StartPosition = FormStartPosition.CenterParent;
        //        mapa.ShowDialog(this);
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show($"No se pudo abrir el mapa: {ex.Message}",
        //            "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //    }
        //}

        // ─────────────────────────────────────────────
        // Menú — Alumnos
        // ─────────────────────────────────────────────

        //private void asignarToolStripMenuItem_Click(object sender, EventArgs e)
        //    => AbrirFormulario(() => new FrmAsignacion());

        private void renovarToolStripMenuItem_Click(object sender, EventArgs e)
            => AbrirFormulario(() => new frmRenovacionFuncion());

        private void ingresarToolStripMenuItem_Click(object sender, EventArgs e)
            => AbrirFormulario(() => new frmAltaAlumno());

        private void actualizarToolStripMenuItem1_Click(object sender, EventArgs e)
            => AbrirFormulario(() => new FrmBuscarMatricula());

        // ─────────────────────────────────────────────
        // Menú — Usuarios
        // ─────────────────────────────────────────────

        private void ingresarToolStripMenuItem1_Click(object sender, EventArgs e)
            => AbrirFormulario(() => new frmaltausuario());

        private void eliminarToolStripMenuItem_Click(object sender, EventArgs e)
            => AbrirFormulario(() => new frmGestionUsuarios());

        // ─────────────────────────────────────────────
        // Menú — Funcionalidades
        // ─────────────────────────────────────────────

        private void funcionalidadesToolStripMenuItem_Click(object sender, EventArgs e) { }

        private void periodoDeRenovacionToolStripMenuItem_Click(object sender, EventArgs e)
            => AbrirFormulario(() => new frmPeriodoRenovacion());

        private void cancelarRenovacionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var dr = MessageBox.Show(
                "¿Desea cancelar la renovación más reciente? Se revertirán los estados relacionados.",
                "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr != DialogResult.Yes) return;

            try
            {
                using var conn = DBConnection.GetConnection();
                using var tran = conn.BeginTransaction();

                long? lastId = null;
                using (var cmd = new SQLiteCommand(
                    "SELECT id_renovacion FROM Renovacion ORDER BY fecha_inicio DESC LIMIT 1;", conn, tran))
                {
                    var obj = cmd.ExecuteScalar();
                    if (obj != null && obj != DBNull.Value) lastId = Convert.ToInt64(obj);
                }

                if (!lastId.HasValue)
                {
                    MessageBox.Show("No existe ningún periodo de renovación para cancelar.",
                        "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                using (var del = new SQLiteCommand(
                    "DELETE FROM Renovacion WHERE id_renovacion = @id;", conn, tran))
                {
                    del.Parameters.AddWithValue("@id", lastId.Value);
                    del.ExecuteNonQuery();
                }

                using (var updOcc = new SQLiteCommand(
                    "UPDATE lockers SET estado = '1' WHERE id_locker IN (SELECT id_locker FROM asignaciones WHERE activa = 1);",
                    conn, tran))
                    updOcc.ExecuteNonQuery();

                using (var updFree = new SQLiteCommand(
                    "UPDATE lockers SET estado = '0' WHERE estado = '2' AND id_locker NOT IN (SELECT id_locker FROM asignaciones WHERE activa = 1);",
                    conn, tran))
                    updFree.ExecuteNonQuery();

                tran.Commit();

                MessageBox.Show("Renovación cancelada y estados revertidos.", "Éxito",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                RefrescarMapa();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cancelar la renovación: {ex.Message}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void reportesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                using var conn = DBConnection.GetConnection();
                using var cmd = new SQLiteCommand("SELECT * FROM asignaciones;", conn);
                using var reader = cmd.ExecuteReader();

                var sb = new System.Text.StringBuilder();

                for (int i = 0; i < reader.FieldCount; i++)
                {
                    if (i > 0) sb.Append(',');
                    sb.Append(EscapeCsv(reader.GetName(i)));
                }
                sb.AppendLine();

                while (reader.Read())
                {
                    for (int i = 0; i < reader.FieldCount; i++)
                    {
                        if (i > 0) sb.Append(',');
                        sb.Append(EscapeCsv(reader.IsDBNull(i) ? string.Empty : reader.GetValue(i).ToString()));
                    }
                    sb.AppendLine();
                }

                string path = System.IO.Path.Combine(
                    Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments),
                    $"asignaciones_{DateTime.Now:yyyyMMdd_HHmmss}.csv");

                System.IO.File.WriteAllText(path, sb.ToString(), System.Text.Encoding.UTF8);
                Process.Start(new ProcessStartInfo(path) { UseShellExecute = true });

                MessageBox.Show($"Reporte exportado:\n{path}", "Exportado",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error generando el reporte: {ex.Message}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ─────────────────────────────────────────────
        // Helpers privados
        // ─────────────────────────────────────────────

        private bool EsAdmin()
            => !string.IsNullOrEmpty(currentUserRole)
               && currentUserRole.Equals("Administrador", StringComparison.OrdinalIgnoreCase);

        private void RefrescarMapa()
        {
            try
            {
                Funciones.CargarEstadosDesdeBD(diccionario);
                CbUbicacion_SelectedIndexChanged(this, EventArgs.Empty);
            }
            catch { }
        }

        private void LimpiarCamposAlumno()
        {
            TXTNombre.Clear();
            txtMatricula.Clear();
            txtTelefono.Clear();
            if (rbGrupoAcademico != null) rbGrupoAcademico.Checked = false;
            if (rbGrupoCultural != null) rbGrupoCultural.Checked = false;
        }

        private void LimpiarLabels()
        {
            lblNombre.Text = "----";
            lblMatricula.Text = "----";
            lblCasillero.Text = "----";
        }

        /// <summary>Abre un Form centrado en el padre con manejo de errores estándar.</summary>
        private void AbrirFormulario<T>(Func<T> factory) where T : Form
        {
            try
            {
                using var frm = factory();
                frm.StartPosition = FormStartPosition.CenterParent;
                frm.ShowDialog(this);
                RefrescarMapa();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"No se pudo abrir el formulario: {ex.Message}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private static string EscapeCsv(string? value)
        {
            if (string.IsNullOrEmpty(value)) return string.Empty;
            string escaped = value.Replace("\"", "\"\"");
            return (escaped.Contains(',') || escaped.Contains('"')
                    || escaped.Contains('\n') || escaped.Contains('\r'))
                ? $"\"{escaped}\""
                : escaped;
        }
    }
}