using System;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Windows.Forms;

namespace Gestion_Lockers
{
    public partial class FrmAsignacion : Form
    {
        private readonly Diccionario dic = new Diccionario();
        private int? selectedLockerId = null;
        private string selectedMatricula = string.Empty;

        // Soporte para prepararlo desde la rutina de renovación
        private string initialMatricula = null;
        private int? initialLocker = null;
        private bool initialIsRenovation = false;

        private bool isRenovationFlow = false;
        private int? originalLockerId = null;

        public FrmAsignacion()
        {
            InitializeComponent();

            // Eventos
            Load += FrmAsignacion_Load;
            cbUbicacion.SelectedIndexChanged += CbUbicacion_SelectedIndexChanged;
            dataGridView1.CellContentClick += DataGridView1_CellContentClick;
            btnRegresarMapa.Click += BtnRegresarMapa_Click;
            btnBuscar.Click += BtnBuscar_Click;
            btnAsignar.Click += BtnAsignar_Click;

            btnAsignar.Enabled = false;
            LimpiarLabels();
        }

        // Nuevo constructor conveniente (llama al ctor por defecto)
        public FrmAsignacion(string matricula, int? lockerId, bool isRenovation) : this()
        {
            initialMatricula = matricula;
            initialLocker = lockerId;
            initialIsRenovation = isRenovation;
        }

        private void FrmAsignacion_Load(object? sender, EventArgs e)
        {
            try
            {
                Funciones.CargarEstadosDesdeBD(dic);
                Funciones.CargarPisos(cbUbicacion);

                // Si vinimos con datos iniciales (renovación), aplicarlos ahora que todo está cargado
                if (!string.IsNullOrEmpty(initialMatricula))
                {
                    textBox1.Text = initialMatricula;
                    if (TryGetAlumno(initialMatricula, out string nombre, out string telefono))
                    {
                        selectedMatricula = initialMatricula;
                        lblMatricula.Text = initialMatricula;
                        lblNombre.Text = nombre;
                    }
                }

                if (initialLocker.HasValue)
                {
                    // Elegir el "Piso X" según el id del locker (ej: 2101 -> Piso 2)
                    int locker = initialLocker.Value;
                    int pisoPrefix = locker / 1000;
                    string pisoText = "Piso " + pisoPrefix;
                    if (cbUbicacion.Items.Contains(pisoText))
                        cbUbicacion.SelectedItem = pisoText;
                    else
                        cbUbicacion.SelectedIndex = 0;

                    // Dibujar el mapa y seleccionar el casillero
                    RedibujarMapa();

                    // Buscar la celda con ese número y seleccionarla
                    bool encontrado = false;
                    for (int r = 0; r < dataGridView1.Rows.Count && !encontrado; r++)
                    {
                        for (int c = 0; c < dataGridView1.Columns.Count; c++)
                        {
                            var cellVal = dataGridView1.Rows[r].Cells[c].Value?.ToString();
                            if (cellVal == locker.ToString())
                            {
                                dataGridView1.CurrentCell = dataGridView1.Rows[r].Cells[c];
                                // Llamar al handler para que setee etiquetas/estado
                                DataGridView1_CellContentClick(this, new DataGridViewCellEventArgs(c, r));
                                encontrado = true;
                                break;
                            }
                        }
                    }

                    // Marcar que venimos en flujo de renovación
                    isRenovationFlow = initialIsRenovation;
                    originalLockerId = initialLocker;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al inicializar asignación: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CbUbicacion_SelectedIndexChanged(object? sender, EventArgs e)
        {
            RedibujarMapa();
            selectedLockerId = null;
            LimpiarLabels();
        }

        private void RedibujarMapa()
        {
            string piso = cbUbicacion.Text?.Trim() ?? string.Empty;

            try
            {
                if (piso.Equals("Piso 2", StringComparison.OrdinalIgnoreCase))
                    Funciones.DibujarMapaPiso2(dataGridView1, dic);
                else if (piso.Equals("Piso 3", StringComparison.OrdinalIgnoreCase))
                    Funciones.DibujarMapaPiso3(dataGridView1, dic);
                else
                    Funciones.CargarLockers(dataGridView1, dic);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al dibujar mapa: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DataGridView1_CellContentClick(object? sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0) return;

            var cell = dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex];
            string valor = cell.Value?.ToString() ?? string.Empty;

            if (string.IsNullOrWhiteSpace(valor))
            {
                selectedLockerId = null;
                LimpiarLabels();
                return;
            }

            // intentar interpretar como id numérico
            if (int.TryParse(valor, out int idLocker))
            {
                selectedLockerId = idLocker;
                lblCasillero.Text = idLocker.ToString();

                // Mostrar información del alumno asignado si existe
                var info = Funciones.ObtenerAlumnoAsignadoPorLocker(idLocker);
                if (info is not null)
                {
                    lblNombre.Text = info.Nombre;
                    lblMatricula.Text = info.Matricula;
                }
                else
                {
                    lblNombre.Text = "Sin asignar";
                    lblMatricula.Text = "-";
                }

                // Validar si se permite asignar ese locker:
                // - Si venimos de renovación y es el locker original, permitir.
                // - Si se selecciona otro locker, sólo permitir si está disponible.
                bool permiteSeleccion = false;
                string estado = string.Empty;

                if (dic.EstadosLockers.TryGetValue(idLocker.ToString(), out estado))
                {
                    if (isRenovationFlow && originalLockerId.HasValue && originalLockerId.Value == idLocker)
                    {
                        permiteSeleccion = true;
                    }
                    else
                    {
                        // Considerar disponible si estado == "Disponible" o "0"
                        permiteSeleccion = estado.Equals("Disponible", StringComparison.OrdinalIgnoreCase) || estado.Equals("0");
                    }
                }
                else
                {
                    // Si no hay estado en el diccionario, considerar no disponible por seguridad
                    permiteSeleccion = false;
                }

                // Habilitar asignar sólo si hay matrícula y el locker seleccionado es válido según reglas
                btnAsignar.Enabled = !string.IsNullOrEmpty(selectedMatricula) && permiteSeleccion;
            }
            else
            {
                // valores especiales (SA_...) no son asignables
                selectedLockerId = null;
                LimpiarLabels();
            }
        }

        private void BtnBuscar_Click(object? sender, EventArgs e)
        {
            string matricula = textBox1.Text.Trim();
            if (string.IsNullOrEmpty(matricula))
            {
                MessageBox.Show("Ingrese la matrícula.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBox1.Focus();
                return;
            }

            try
            {
                if (TryGetAlumno(matricula, out string nombre, out string telefono))
                {
                    selectedMatricula = matricula;
                    lblMatricula.Text = matricula;
                    lblNombre.Text = nombre;
                    // habilitar asignar sólo si hay casillero seleccionado y si cumple reglas (DataGridView handler las aplica)
                    btnAsignar.Enabled = selectedLockerId.HasValue && btnAsignar.Enabled;
                }
                else
                {
                    var dr = MessageBox.Show("La matrícula no existe. ¿Desea dar de alta al alumno?", "Alumno no encontrado", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (dr == DialogResult.Yes)
                    {
                        try
                        {
                            using (var frm = new frmAltaAlumno())
                            {
                                frm.StartPosition = FormStartPosition.CenterParent;
                                frm.ShowDialog(this);
                            }

                            // Reintentar búsqueda después de cerrar el alta
                            if (TryGetAlumno(matricula, out string nombre2, out string telefono2))
                            {
                                selectedMatricula = matricula;
                                lblMatricula.Text = matricula;
                                lblNombre.Text = nombre2;
                                btnAsignar.Enabled = selectedLockerId.HasValue;
                            }
                            else
                            {
                                MessageBox.Show("No se pudo crear el alumno o la matrícula sigue sin existir.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                selectedMatricula = string.Empty;
                                btnAsignar.Enabled = false;
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show($"Error al abrir el formulario de alta: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        textBox1.Focus();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al buscar alumno: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool TryGetAlumno(string matricula, out string nombre, out string telefono)
        {
            nombre = string.Empty;
            telefono = string.Empty;

            try
            {
                using (var conn = DBConnection.GetConnection())
                using (var cmd = new SQLiteCommand("SELECT nombre, telefono FROM alumnos WHERE matricula = @mat LIMIT 1;", conn))
                {
                    cmd.Parameters.AddWithValue("@mat", matricula);
                    using (var dr = cmd.ExecuteReader())
                    {
                        if (dr.Read())
                        {
                            nombre = dr["nombre"]?.ToString() ?? string.Empty;
                            telefono = dr["telefono"]?.ToString() ?? string.Empty;
                            return true;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error consultando alumno: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return false;
        }

        private void BtnAsignar_Click(object? sender, EventArgs e)
        {
            if (!selectedLockerId.HasValue)
            {
                MessageBox.Show("Seleccione un casillero válido antes de asignar.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrEmpty(selectedMatricula))
            {
                MessageBox.Show("Busque y seleccione una matrícula válida antes de asignar.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                // Comprobar estado actual del locker en BD
                using (var conn = DBConnection.GetConnection())
                using (var cmd = new SQLiteCommand("SELECT estado FROM lockers WHERE id_locker = @id LIMIT 1;", conn))
                {
                    cmd.Parameters.AddWithValue("@id", selectedLockerId.Value);
                    var estadoObj = cmd.ExecuteScalar();
                    string estado = estadoObj?.ToString() ?? string.Empty;

                    bool disponible = estado.Equals("Disponible", StringComparison.OrdinalIgnoreCase) || estado.Equals("0");

                    // Permitir en flujo de renovación si es el locker original del alumno
                    if (!disponible)
                    {
                        if (!(isRenovationFlow && originalLockerId.HasValue && originalLockerId.Value == selectedLockerId.Value))
                        {
                            MessageBox.Show("El casillero seleccionado no está disponible y no puede ser asignado.", "No disponible", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                    }
                }

                // Realizar inserción y actualización en una transacción
                using (var conn = DBConnection.GetConnection())
                using (var tran = conn.BeginTransaction())
                {
                    using (var ins = new SQLiteCommand("INSERT INTO asignaciones (matricula, id_locker, fecha_inicio, fecha_fin, activa) VALUES (@matricula, @id_locker, @fecha_inicio, NULL, 1);", conn, tran))
                    {
                        ins.Parameters.AddWithValue("@matricula", selectedMatricula);
                        ins.Parameters.AddWithValue("@id_locker", selectedLockerId.Value);
                        ins.Parameters.AddWithValue("@fecha_inicio", DateTime.UtcNow.ToString("o")); // ISO 8601 UTC
                        ins.ExecuteNonQuery();
                    }

                    using (var upd = new SQLiteCommand("UPDATE lockers SET estado = 1 WHERE id_locker = @id;", conn, tran))
                    {
                        upd.Parameters.AddWithValue("@id", selectedLockerId.Value);
                        upd.ExecuteNonQuery();
                    }

                    tran.Commit();
                }

                MessageBox.Show("Asignación realizada correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Refrescar estados y mapa
                Funciones.CargarEstadosDesdeBD(dic);
                RedibujarMapa();

                // Mostrar info final y deshabilitar asignar hasta nueva selección
                btnAsignar.Enabled = false;
                selectedMatricula = string.Empty;
                textBox1.Clear();
                lblMatricula.Text = "-";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al asignar casillero: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnRegresarMapa_Click(object? sender, EventArgs e)
        {
            this.Close();
        }

        private void LimpiarLabels()
        {
            lblCasillero.Text = "----";
            lblNombre.Text = "************";
            lblMatricula.Text = "0000000";
        }
    }
}
