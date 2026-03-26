using System;
using System.Data.SQLite;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace Gestion_Lockers
{
    public partial class frmAltaAlumno : Form
    {
        public string CreatedMatricula { get; private set; }
        public bool CloseOnSuccess { get; set; } = false;
        private bool IsEditMode { get; set; } = false;

        public frmAltaAlumno()
        {
            InitializeComponent();

            // Asociar manejadores de eventos
            btnagregar.Click += Btnagregar_Click;
            btnLimpiar.Click += BtnLimpiar_Click;
            btnRegresar.Click += BtnRegresar_Click;
        }

        // Constructor para prellenar matrícula y configurar cierre al crear/editar
        public frmAltaAlumno(string initialMatricula, bool closeOnSuccess = false, bool isEditMode = false) : this()
        {
            CloseOnSuccess = closeOnSuccess;
            IsEditMode = isEditMode;

            if (!string.IsNullOrEmpty(initialMatricula))
            {
                textBox3.Text = initialMatricula;
                if (IsEditMode)
                {
                    // matrícula no editable en modo edición
                    try
                    {
                        textBox3.ReadOnly = true;
                    }
                    catch { }
                    btnagregar.Text = "Guardar";
                    CargarAlumno(initialMatricula);
                }
            }
        }

        private void CargarAlumno(string matricula)
        {
            try
            {
                using (var conn = DBConnection.GetConnection())
                using (var cmd = new SQLiteCommand("SELECT nombre, telefono, grupo_academico, grupo_cultural FROM alumnos WHERE matricula = @mat LIMIT 1;", conn))
                {
                    cmd.Parameters.AddWithValue("@mat", matricula);
                    using (var dr = cmd.ExecuteReader())
                    {
                        if (dr.Read())
                        {
                            textBox1.Text = dr["nombre"]?.ToString() ?? string.Empty;
                            textBox2.Text = dr["telefono"]?.ToString() ?? string.Empty;
                            var gAcad = dr["grupo_academico"]?.ToString() ?? "0";
                            var gCult = dr["grupo_cultural"]?.ToString() ?? "0";
                            try { rbGrupoAcademico.Checked = gAcad == "1"; } catch { }
                            try { rbGrupoCultural.Checked = gCult == "1"; } catch { }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error cargando alumno: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Btnagregar_Click(object? sender, EventArgs e)
        {
            string nombre = textBox1.Text.Trim();    // Nombre
            string telefono = textBox2.Text.Trim();  // Teléfono
            string matricula = textBox3.Text.Trim(); // Matrícula

            // Validaciones básicas
            if (string.IsNullOrEmpty(nombre) || string.IsNullOrEmpty(matricula) || string.IsNullOrEmpty(telefono))
            {
                MessageBox.Show("Todos los campos son obligatorios.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!Regex.IsMatch(matricula, @"^[a-zA-Z0-9]+$"))
            {
                MessageBox.Show("La matrícula solo puede contener caracteres alfanuméricos.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!Regex.IsMatch(telefono, @"^\d{10}$"))
            {
                MessageBox.Show("El teléfono debe contener exactamente 10 dígitos.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Los grupos son opcionales: si no se marcan, se guardan como 0.
            bool academico = rbGrupoAcademico != null && rbGrupoAcademico.Checked;
            bool cultural = rbGrupoCultural != null && rbGrupoCultural.Checked;

            int grupoAcademico = academico ? 1 : 0;
            int grupoCultural = cultural ? 1 : 0;

            try
            {
                if (IsEditMode)
                {
                    using (var conn = DBConnection.GetConnection())
                    using (var cmd = new SQLiteCommand("UPDATE alumnos SET nombre=@nombre, telefono=@telefono, grupo_academico=@gAcad, grupo_cultural=@gCult WHERE matricula=@matricula;", conn))
                    {
                        cmd.Parameters.AddWithValue("@matricula", matricula);
                        cmd.Parameters.AddWithValue("@nombre", nombre);
                        cmd.Parameters.AddWithValue("@telefono", telefono);
                        cmd.Parameters.AddWithValue("@gAcad", grupoAcademico);
                        cmd.Parameters.AddWithValue("@gCult", grupoCultural);
                        int affected = cmd.ExecuteNonQuery();
                        if (affected > 0)
                        {
                            CreatedMatricula = matricula;
                            MessageBox.Show("Alumno actualizado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            if (CloseOnSuccess)
                            {
                                DialogResult = DialogResult.OK;
                                Close();
                                return;
                            }
                            LimpiarCampos();
                        }
                        else
                        {
                            MessageBox.Show("No se encontró la matrícula para actualizar.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                else
                {
                    using (var conn = DBConnection.GetConnection())
                    using (var cmd = new SQLiteCommand("INSERT INTO alumnos (matricula, nombre, telefono, grupo_academico, grupo_cultural) VALUES (@matricula, @nombre, @telefono, @gAcad, @gCult);", conn))
                    {
                        cmd.Parameters.AddWithValue("@matricula", matricula);
                        cmd.Parameters.AddWithValue("@nombre", nombre);
                        cmd.Parameters.AddWithValue("@telefono", telefono);
                        cmd.Parameters.AddWithValue("@gAcad", grupoAcademico);
                        cmd.Parameters.AddWithValue("@gCult", grupoCultural);
                        cmd.ExecuteNonQuery();
                    }

                    CreatedMatricula = matricula;

                    MessageBox.Show("Alumno registrado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    if (CloseOnSuccess)
                    {
                        DialogResult = DialogResult.OK;
                        Close();
                        return;
                    }

                    // Limpiar para permitir otro alta
                    LimpiarCampos();
                }
            }
            catch (SQLiteException ex) when (ex.ResultCode == SQLiteErrorCode.Constraint || ex.ResultCode == SQLiteErrorCode.Constraint_PrimaryKey)
            {
                MessageBox.Show("La matrícula ya existe en la base de datos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al insertar/actualizar el alumno: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnLimpiar_Click(object? sender, EventArgs e)
        {
            LimpiarCampos();
        }

        private void BtnRegresar_Click(object? sender, EventArgs e)
        {
            this.Close();
        }

        private void LimpiarCampos()
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            if (rbGrupoAcademico != null) rbGrupoAcademico.Checked = false;
            if (rbGrupoCultural != null) rbGrupoCultural.Checked = false;
            textBox1.Focus();
            CreatedMatricula = null;
        }
    }
}