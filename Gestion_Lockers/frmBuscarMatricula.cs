using System;
using System.Data.SQLite;
using System.Drawing;
using System.Windows.Forms;

namespace Gestion_Lockers
{
    public partial class FrmBuscarMatricula : Form
    {
        private TextBox txtMatricula;
        private Button btnBuscar;
        private Button btnCancelar;
        private Label lbl;

        public string Matricula { get; private set; }

        public FrmBuscarMatricula()
        {
            InitializeComponent();

            Text = "Buscar matrícula";
            StartPosition = FormStartPosition.CenterParent;
            ClientSize = new Size(340, 130);

            lbl = new Label { Text = "Matrícula:", Location = new Point(12, 15), AutoSize = true, Font = new Font("Century Gothic", 10F) };
            txtMatricula = new TextBox { Location = new Point(12, 40), Width = 300, Font = new Font("Century Gothic", 10F) };
            btnBuscar = new Button { Text = "Buscar", Location = new Point(12, 75), Size = new Size(120, 35), Font = new Font("Century Gothic", 10F) };
            btnCancelar = new Button { Text = "Cancelar", Location = new Point(192, 75), Size = new Size(120, 35), Font = new Font("Century Gothic", 10F) };

            Controls.Add(lbl);
            Controls.Add(txtMatricula);
            Controls.Add(btnBuscar);
            Controls.Add(btnCancelar);

            btnBuscar.Click += BtnBuscar_Click;
            btnCancelar.Click += (s, e) => { DialogResult = DialogResult.Cancel; Close(); };
        }

        private void BtnBuscar_Click(object? sender, EventArgs e)
        {
            string m = txtMatricula.Text.Trim();
            if (string.IsNullOrEmpty(m))
            {
                MessageBox.Show("Ingrese la matrícula.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMatricula.Focus();
                return;
            }

            try
            {
                using (var conn = DBConnection.GetConnection())
                using (var cmd = new SQLiteCommand("SELECT nombre FROM alumnos WHERE matricula = @mat LIMIT 1;", conn))
                {
                    cmd.Parameters.AddWithValue("@mat", m);
                    var obj = cmd.ExecuteScalar();
                    if (obj != null && obj != DBNull.Value)
                    {
                        // Existe alumno: preguntar si desea editar
                        var drEdit = MessageBox.Show("Alumno encontrado. ¿Desea editar sus datos?", "Alumno encontrado", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (drEdit == DialogResult.Yes)
                        {
                            try
                            {
                                using (var frm = new frmAltaAlumno(m, closeOnSuccess: true, isEditMode: true))
                                {
                                    frm.StartPosition = FormStartPosition.CenterParent;
                                    var res = frm.ShowDialog(this);
                                    if (res == DialogResult.OK)
                                    {
                                        Matricula = frm.CreatedMatricula ?? m;
                                        DialogResult = DialogResult.OK;
                                        Close();
                                        return;
                                    }
                                    else
                                    {
                                        MessageBox.Show("Edición cancelada o no se guardaron cambios.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                        return;
                                    }
                                }
                            }
                            catch (Exception exInner)
                            {
                                MessageBox.Show($"Error al abrir frmAltaAlumno: {exInner.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }
                        }
                        else
                        {
                            // No desea editar: devolver matrícula directamente
                            Matricula = m;
                            DialogResult = DialogResult.OK;
                            Close();
                            return;
                        }
                    }
                }

                // No existe: preguntar si desea dar de alta
                var dr = MessageBox.Show("La matrícula no existe. ¿Desea dar de alta al alumno?", "Alumno no encontrado", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dr == DialogResult.Yes)
                {
                    try
                    {
                        using (var frm = new frmAltaAlumno(m, closeOnSuccess: true))
                        {
                            frm.StartPosition = FormStartPosition.CenterParent;
                            var result = frm.ShowDialog(this);
                            if (result == DialogResult.OK)
                            {
                                Matricula = frm.CreatedMatricula ?? m;
                                DialogResult = DialogResult.OK;
                                Close();
                                return;
                            }
                            else
                            {
                                MessageBox.Show("No se creó el alumno.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        }
                    }
                    catch (Exception exInner)
                    {
                        MessageBox.Show($"Error al abrir frmAltaAlumno: {exInner.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    txtMatricula.Focus();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error consultando la matrícula: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
