using System;
using System.Data.SQLite;
using System.Diagnostics;
using System.Drawing;
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
        // Suscripción de eventos
        // ─────────────────────────────────────────────

        private void SuscribirEventos()
        {
            Load += Principal_Load;
            cbUbicacion.SelectedIndexChanged += CbUbicacion_SelectedIndexChanged;
            cbUbicacion.DrawItem += CbUbicacion_DrawItem;
            dataGridView1.CellClick += DataGridView1_CellClick;
            btnAsignar.Click += BtnAsignar_Click;
            btnRenovar.Click += BtnRenovar_Click;

            // Búsqueda: Enter en el TextBox o clic en el botón
            txtBusqueda.KeyDown += TxtBusqueda_KeyDown;
            btnBuscar.Click += BtnBuscar_Click;
            btnLimpiarBusqueda.Click += BtnLimpiarBusqueda_Click;
        }

        // ─────────────────────────────────────────────
        // Carga inicial
        // ─────────────────────────────────────────────

        private void Principal_Load(object? sender, EventArgs e)
        {
            lblFecha.Text = DateTime.Now.ToString("dd/MM/yyyy");

            // Label de renovación: visible solo si hay un periodo activo vigente
            try
            {
                using var conn = DBConnection.GetConnection();
                using var cmd = new SQLiteCommand(@"
                    SELECT fecha_fin FROM Renovacion
                    WHERE date(fecha_fin) >= date('now')
                    ORDER BY fecha_fin ASC LIMIT 1;", conn);
                var obj = cmd.ExecuteScalar();

                if (obj != null && obj != DBNull.Value
                    && DateTime.TryParse(obj.ToString(), out DateTime ff))
                {
                    lblFechaRenovacion.Text = ff.ToString("dd/MM/yyyy");
                    lblFechaRenovacion.Visible = true;
                    label3.Visible = true;
                }
                else
                {
                    lblFechaRenovacion.Visible = false;
                    label3.Visible = false;
                }
            }
            catch
            {
                lblFechaRenovacion.Visible = false;
                label3.Visible = false;
            }

            // Configurar grid
            Funciones.ConfigurarGridLockers(dataGridView1);

            // Configurar combo con owner-draw para encabezados
            cbUbicacion.DrawMode = DrawMode.OwnerDrawFixed;

            // Cargar datos
            try
            {
                Funciones.CargarZonasEnCombo(cbUbicacion);
                Funciones.CargarEstadosDesdeBD(diccionario);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error inicializando interfaz: {ex.Message}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            AplicarPermisosRol();

            // Verificar vencimiento de renovación (solo admin puede cerrar)
            if (EsAdmin())
                Funciones.VerificarYCerrarVencimiento(this);
        }

        // ─────────────────────────────────────────────
        // ComboBox jerárquico — dibujo y selección
        // ─────────────────────────────────────────────

        private void CbUbicacion_DrawItem(object? sender, DrawItemEventArgs e)
        {
            if (e.Index < 0 || e.Index >= cbUbicacion.Items.Count) return;

            var item = cbUbicacion.Items[e.Index] as Funciones.UbicacionItem;
            if (item == null) return;

            e.DrawBackground();

            if (item.EsEncabezado)
            {
                // Encabezado: fondo gris, texto en negrita
                using var bgBrush = new SolidBrush(Color.FromArgb(220, 220, 220));
                e.Graphics.FillRectangle(bgBrush, e.Bounds);
                using var font = new Font(cbUbicacion.Font, FontStyle.Bold);
                using var brush = new SolidBrush(Color.FromArgb(70, 70, 70));
                e.Graphics.DrawString(item.Texto, font, brush,
                    new Rectangle(e.Bounds.X + 4, e.Bounds.Y, e.Bounds.Width - 4, e.Bounds.Height),
                    StringFormat.GenericDefault);
            }
            else
            {
                bool selected = (e.State & DrawItemState.Selected) == DrawItemState.Selected;
                using var brush = new SolidBrush(selected
                    ? SystemColors.HighlightText
                    : cbUbicacion.ForeColor);
                e.Graphics.DrawString(item.Texto, cbUbicacion.Font, brush,
                    new Rectangle(e.Bounds.X + 4, e.Bounds.Y, e.Bounds.Width - 4, e.Bounds.Height),
                    StringFormat.GenericDefault);
            }

            e.DrawFocusRectangle();
        }

        private void CbUbicacion_SelectedIndexChanged(object? sender, EventArgs e)
        {
            // Evitar que el usuario seleccione un encabezado
            if (cbUbicacion.SelectedItem is Funciones.UbicacionItem item && item.EsEncabezado)
            {
                cbUbicacion.SelectedIndex = -1;
                return;
            }

            if (cbUbicacion.SelectedItem is not Funciones.UbicacionItem sel) return;

            try
            {
                Funciones.CargarEstadosDesdeBD(diccionario);
                Funciones.DibujarMapaPiso(dataGridView1, diccionario, sel.Piso, sel.Zona);
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
                if (_modoSeleccionRenovacion) return; // ignorar clics en celdas vacías durante selección
                selectedLockerId = null;
                LimpiarLabels();
                return;
            }

            if (!int.TryParse(valor, out int idLocker))
            {
                // Locker alfanumérico SA_* — no asignable
                selectedLockerId = null;
                LimpiarLabels();
                return;
            }

            // ── Modo selección de locker para renovación ────────────────────
            if (_modoSeleccionRenovacion)
            {
                // Verificar que el locker seleccionado esté disponible
                if (!Funciones.EsLockerDisponible(idLocker))
                {
                    MessageBox.Show("Solo puede elegir un locker disponible (verde).\nEse locker no está disponible.",
                        "No disponible", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Confirmar la reasignación
                var confirm = MessageBox.Show(
                    $"¿Reasignar a  {_matriculaEnRenovacion}  al locker {idLocker}?",
                    "Confirmar cambio de locker", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (confirm == DialogResult.Yes)
                {
                    if (Funciones.EjecutarRenovacion(_matriculaEnRenovacion!, _lockerAnteriorRenovacion!, idLocker))
                    {
                        MessageBox.Show("Renovación con cambio de locker realizada correctamente.", "Éxito",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                        CancelarModoRenovacion();
                        RefrescarMapa();
                        LimpiarLabels();
                        LimpiarCamposAlumno();
                        txtBusqueda.Clear();
                    }
                }
                // Si cancela la confirmación se mantiene el modo activo para elegir otro
                return;
            }

            // ── Flujo normal ────────────────────────────────────────────────
            MostrarInfoLocker(idLocker);
        }

        /// <summary>Carga info de un locker en el panel lateral y lo marca como seleccionado.</summary>
        private void MostrarInfoLocker(int idLocker)
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

        // ─────────────────────────────────────────────
        // Búsqueda en panel lateral
        // ─────────────────────────────────────────────

        private void TxtBusqueda_KeyDown(object? sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                EjecutarBusqueda();
            }
        }

        private void BtnBuscar_Click(object? sender, EventArgs e)
            => EjecutarBusqueda();

        private void BtnLimpiarBusqueda_Click(object? sender, EventArgs e)
        {
            txtBusqueda.Clear();
            selectedLockerId = null;
            LimpiarLabels();
            LimpiarCamposAlumno();
            DesaltarCeldas();
        }

        private void EjecutarBusqueda()
        {
            string termino = txtBusqueda.Text.Trim();
            if (string.IsNullOrEmpty(termino)) return;

            var resultado = Funciones.BuscarLocker(termino);
            if (resultado == null) return;

            // Mostrar datos en panel lateral
            MostrarInfoLocker(resultado.IdLocker);

            // Resaltar la celda en el grid si es visible en el piso actual
            ResaltarLockerEnGrid(resultado.IdLocker);
        }

        /// <summary>
        /// Resalta visualmente la celda del locker encontrado si está en el grid actual.
        /// Si el piso del locker no está cargado, cambia el combo automáticamente.
        /// </summary>
        private void ResaltarLockerEnGrid(int idLocker)
        {
            // Intentar encontrar la celda en el grid ya dibujado
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                foreach (DataGridViewCell cell in row.Cells)
                {
                    if (cell.Value?.ToString() == idLocker.ToString())
                    {
                        // Limpiar selección previa y resaltar esta
                        DesaltarCeldas();
                        dataGridView1.CurrentCell = cell;
                        cell.Style.BackColor = Color.Orange;
                        cell.Style.ForeColor = Color.White;
                        dataGridView1.FirstDisplayedScrollingColumnIndex =
                            Math.Max(0, cell.ColumnIndex - 5);
                        return;
                    }
                }
            }

            // No está en el grid actual — cambiar al piso correspondiente
            int piso = idLocker / 1000;
            for (int i = 0; i < cbUbicacion.Items.Count; i++)
            {
                if (cbUbicacion.Items[i] is Funciones.UbicacionItem it
                    && it.Piso == piso && !it.EsEncabezado && string.IsNullOrEmpty(it.Zona))
                {
                    cbUbicacion.SelectedIndex = i;
                    // Después del redibujo, volver a resaltar
                    ResaltarLockerEnGrid(idLocker);
                    return;
                }
            }
        }

        /// <summary>Quita el color naranja de búsqueda y restaura el color de estado.</summary>
        private void DesaltarCeldas()
        {
            ApplyEstadosEnGrid();
        }

        private void ApplyEstadosEnGrid()
        {
            Funciones.ApplyEstadosEnGrid(dataGridView1, diccionario);
        }

        // ─────────────────────────────────────────────
        // Asignar locker
        // ─────────────────────────────────────────────

        private void BtnAsignar_Click(object? sender, EventArgs e)
        {
            string nombre = TXTNombre.Text.Trim();
            string telefono = txtTelefono.Text.Trim();
            string matricula = txtMatricula.Text.Trim();

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
                MessageBox.Show("Seleccione un casillero en el mapa o búsquelo antes de asignar.",
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

            try
            {
                using var conn = DBConnection.GetConnection();
                using var tran = conn.BeginTransaction();

                bool gAcad = EsAdmin() && grupoAcademico;
                bool gCult = EsAdmin() && grupoCultural;

                if (Funciones.ExisteAlumno(matricula, conn))
                {
                    using var upd = new SQLiteCommand(@"
                        UPDATE alumnos SET nombre=@nombre, telefono=@telefono,
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
            txtBusqueda.Clear();
        }

        // ─────────────────────────────────────────────
        // Renovar — flujo completo en ventana principal
        // ─────────────────────────────────────────────

        // Bandera que indica que el siguiente clic en el mapa es para elegir locker de renovación
        private bool _modoSeleccionRenovacion = false;
        private string? _matriculaEnRenovacion = null;
        private string? _lockerAnteriorRenovacion = null;

        private void BtnRenovar_Click(object? sender, EventArgs e)
        {
            // Si está en modo selección, este clic cancela
            if (_modoSeleccionRenovacion)
            {
                CancelarModoRenovacion();
                return;
            }

            // ── Paso 1: necesitamos un locker seleccionado ──────────────────
            if (!selectedLockerId.HasValue)
            {
                MessageBox.Show("Busque o seleccione el locker del alumno que desea renovar.",
                    "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // ── Paso 2: verificar que el locker está en Renovación ──────────
            string idLockerStr = selectedLockerId.Value.ToString();
            string? matricula = Funciones.ObtenerMatriculaPorLocker(idLockerStr);

            if (string.IsNullOrEmpty(matricula))
            {
                MessageBox.Show("El locker seleccionado no tiene un alumno asignado activo.",
                    "Sin asignación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Obtener info del alumno para mostrar en el diálogo
            var info = Funciones.ObtenerAlumnoAsignadoPorLocker(selectedLockerId.Value);
            string nombreAlumno = info?.Nombre ?? matricula;

            // ── Paso 3: preguntar si reasigna al mismo locker u otro ────────
            var respuesta = MessageBox.Show(
                $"El alumno  {nombreAlumno}  está asignado al locker {selectedLockerId.Value}.\n\n" +
                "¿Desea reasignarlo al MISMO locker?\n\n" +
                "  [Sí]  → Mismo locker\n" +
                "  [No]  → Elegir un locker diferente en el mapa\n" +
                "  [Cancelar] → Salir",
                "Renovación de locker",
                MessageBoxButtons.YesNoCancel,
                MessageBoxIcon.Question);

            if (respuesta == DialogResult.Cancel) return;

            if (respuesta == DialogResult.Yes)
            {
                // ── Mismo locker ────────────────────────────────────────────
                var confirm = MessageBox.Show(
                    $"¿Confirma la renovación de {nombreAlumno} en el locker {selectedLockerId.Value}?",
                    "Confirmar renovación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (confirm != DialogResult.Yes) return;

                if (Funciones.EjecutarRenovacion(matricula, idLockerStr, selectedLockerId.Value))
                {
                    MessageBox.Show("Renovación realizada correctamente.", "Éxito",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    RefrescarMapa();
                    LimpiarLabels();
                    LimpiarCamposAlumno();
                    txtBusqueda.Clear();
                }
            }
            else
            {
                // ── Locker diferente: activar modo selección en el mapa ─────
                _modoSeleccionRenovacion = true;
                _matriculaEnRenovacion = matricula;
                _lockerAnteriorRenovacion = idLockerStr;

                // Indicar visualmente al usuario qué hacer
                MessageBox.Show(
                    $"Haga clic en el locker disponible (verde) al que desea reasignar a {nombreAlumno}.\n\n" +
                    "Solo se permitirá seleccionar lockers disponibles.",
                    "Seleccione el nuevo locker",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                // Cambiar el texto del botón para indicar el modo activo
                btnRenovar.Text = "Cancelar selección";
                btnRenovar.BackColor = Color.FromArgb(255, 180, 0);
            }
        }

        /// <summary>
        /// Cancela el modo de selección de locker para renovación.
        /// </summary>
        private void CancelarModoRenovacion()
        {
            _modoSeleccionRenovacion = false;
            _matriculaEnRenovacion = null;
            _lockerAnteriorRenovacion = null;
            btnRenovar.Text = "Renovar";
            btnRenovar.BackColor = SystemColors.Control;
        }

        // ─────────────────────────────────────────────
        // Menú — Mapa
        // ─────────────────────────────────────────────

        //private void verToolStripMenuItem_Click(object sender, EventArgs e)
        //{
        //    try { var m = new Mapa(); m.StartPosition = FormStartPosition.CenterParent; m.ShowDialog(this); }
        //    catch (Exception ex) { MostrarErrorFormulario(ex); }
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
                    MessageBox.Show("No existe ningún periodo para cancelar.",
                        "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                using (var del = new SQLiteCommand(
                    "DELETE FROM Renovacion WHERE id_renovacion = @id;", conn, tran))
                { del.Parameters.AddWithValue("@id", lastId.Value); del.ExecuteNonQuery(); }

                using (var u1 = new SQLiteCommand(
                    "UPDATE lockers SET estado = '1' WHERE id_locker IN (SELECT id_locker FROM asignaciones WHERE activa = 1);",
                    conn, tran)) u1.ExecuteNonQuery();

                using (var u2 = new SQLiteCommand(
                    "UPDATE lockers SET estado = '0' WHERE estado = '2' AND id_locker NOT IN (SELECT id_locker FROM asignaciones WHERE activa = 1);",
                    conn, tran)) u2.ExecuteNonQuery();

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
                { if (i > 0) sb.Append(','); sb.Append(EscapeCsv(reader.GetName(i))); }
                sb.AppendLine();

                while (reader.Read())
                {
                    for (int i = 0; i < reader.FieldCount; i++)
                    { if (i > 0) sb.Append(','); sb.Append(EscapeCsv(reader.IsDBNull(i) ? "" : reader.GetValue(i).ToString())); }
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

        private void AbrirFormulario<T>(Func<T> factory) where T : Form
        {
            try
            {
                using var frm = factory();
                frm.StartPosition = FormStartPosition.CenterParent;
                frm.ShowDialog(this);
                RefrescarMapa();
            }
            catch (Exception ex) { MostrarErrorFormulario(ex); }
        }

        private static void MostrarErrorFormulario(Exception ex)
            => MessageBox.Show($"No se pudo abrir el formulario: {ex.Message}",
                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

        private static string EscapeCsv(string? value)
        {
            if (string.IsNullOrEmpty(value)) return string.Empty;
            string esc = value.Replace("\"", "\"\"");
            return (esc.Contains(',') || esc.Contains('"') || esc.Contains('\n') || esc.Contains('\r'))
                ? $"\"{esc}\"" : esc;
        }
    }
}