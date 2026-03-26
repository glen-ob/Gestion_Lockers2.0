using System;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Windows.Forms;

namespace Gestion_Lockers
{
    public partial class frmGestionUsuarios : Form
    {
        private DataTable usuariosTable;

        public frmGestionUsuarios()
        {
            InitializeComponent();

            Load += FrmGestionUsuarios_Load;
            btnEliminar.Click += BtnEliminar_Click;
            btnCambiarPass.Click += BtnCambiarPass_Click;
            btnCerrar.Click += (s, e) => Close();
        }

        private void FrmGestionUsuarios_Load(object? sender, EventArgs e)
        {
            CargarUsuarios();
        }

        private void CargarUsuarios()
        {
            try
            {
                using (var conn = DBConnection.GetConnection())
                using (var da = new SQLiteDataAdapter("SELECT id_usuario, nombre, tipo_usuario FROM usuarios_sistema ORDER BY id_usuario ASC;", conn))
                {
                    usuariosTable = new DataTable();
                    da.Fill(usuariosTable);
                    dgvUsuarios.DataSource = usuariosTable;

                    // Ajustes visuales mínimos
                    if (dgvUsuarios.Columns["id_usuario"] != null)
                    {
                        dgvUsuarios.Columns["id_usuario"].HeaderText = "ID";
                        dgvUsuarios.Columns["id_usuario"].Width = 80;
                    }
                    if (dgvUsuarios.Columns["nombre"] != null)
                        dgvUsuarios.Columns["nombre"].HeaderText = "Nombre";
                    if (dgvUsuarios.Columns["tipo_usuario"] != null)
                        dgvUsuarios.Columns["tipo_usuario"].HeaderText = "Rol";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error cargando usuarios: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private int? GetSelectedUserId()
        {
            if (dgvUsuarios.SelectedRows.Count == 0) return null;
            var row = dgvUsuarios.SelectedRows[0].DataBoundItem as DataRowView;
            if (row == null) return null;
            if (row.Row.Table.Columns.Contains("id_usuario"))
            {
                var val = row["id_usuario"];
                if (val == DBNull.Value) return null;
                return Convert.ToInt32(val);
            }
            return null;
        }

        private void BtnEliminar_Click(object? sender, EventArgs e)
        {
            var id = GetSelectedUserId();
            if (!id.HasValue)
            {
                MessageBox.Show("Seleccione un usuario para eliminar.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                int total = Funciones.GetUsuariosCount();
                if (total <= 1)
                {
                    MessageBox.Show("No se puede eliminar el último usuario del sistema.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var dr = MessageBox.Show("¿Confirma eliminar el usuario seleccionado?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dr != DialogResult.Yes) return;

                using (var conn = DBConnection.GetConnection())
                using (var cmd = new SQLiteCommand("DELETE FROM usuarios_sistema WHERE id_usuario = @id;", conn))
                {
                    cmd.Parameters.AddWithValue("@id", id.Value);
                    int affected = cmd.ExecuteNonQuery();
                    if (affected > 0)
                    {
                        MessageBox.Show("Usuario eliminado.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        CargarUsuarios();
                    }
                    else
                    {
                        MessageBox.Show("No se encontró el usuario para eliminar.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error eliminando usuario: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnCambiarPass_Click(object? sender, EventArgs e)
        {
            var id = GetSelectedUserId();
            if (!id.HasValue)
            {
                MessageBox.Show("Seleccione un usuario para cambiar contraseña.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (var dlg = new CambiarPasswordDialog())
            {
                if (dlg.ShowDialog(this) != DialogResult.OK) return;

                string nueva = dlg.NuevaPassword;
                if (string.IsNullOrEmpty(nueva))
                {
                    MessageBox.Show("Contraseña no válida.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                try
                {
                    string hash = Funciones.HashPassword(nueva);
                    using (var conn = DBConnection.GetConnection())
                    using (var cmd = new SQLiteCommand("UPDATE usuarios_sistema SET contrasena = @pass WHERE id_usuario = @id;", conn))
                    {
                        cmd.Parameters.AddWithValue("@pass", hash);
                        cmd.Parameters.AddWithValue("@id", id.Value);
                        int affected = cmd.ExecuteNonQuery();
                        if (affected > 0)
                        {
                            MessageBox.Show("Contraseña actualizada.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("No se encontró el usuario seleccionado.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error actualizando contraseña: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }

    // Dialogo simple para cambiar contraseña
    internal class CambiarPasswordDialog : Form
    {
        private TextBox txtPass;
        private TextBox txtConfirm;
        private Button btnOk;
        private Button btnCancel;
        public string NuevaPassword { get; private set; }

        public CambiarPasswordDialog()
        {
            Text = "Cambiar contraseña";
            StartPosition = FormStartPosition.CenterParent;
            ClientSize = new System.Drawing.Size(360, 160);

            var lbl1 = new Label { Text = "Nueva contraseña:", AutoSize = true, Location = new System.Drawing.Point(12, 15) };
            txtPass = new TextBox { Location = new System.Drawing.Point(12, 40), Width = 320, UseSystemPasswordChar = true };
            var lbl2 = new Label { Text = "Confirmar:", AutoSize = true, Location = new System.Drawing.Point(12, 70) };
            txtConfirm = new TextBox { Location = new System.Drawing.Point(12, 95), Width = 320, UseSystemPasswordChar = true };

            btnOk = new Button { Text = "Aceptar", Location = new System.Drawing.Point(12, 125), Size = new System.Drawing.Size(120, 28) };
            btnCancel = new Button { Text = "Cancelar", Location = new System.Drawing.Point(212, 125), Size = new System.Drawing.Size(120, 28) };

            Controls.Add(lbl1);
            Controls.Add(txtPass);
            Controls.Add(lbl2);
            Controls.Add(txtConfirm);
            Controls.Add(btnOk);
            Controls.Add(btnCancel);

            btnOk.Click += BtnOk_Click;
            btnCancel.Click += (s, e) => { DialogResult = DialogResult.Cancel; Close(); };
        }

        private void BtnOk_Click(object? sender, EventArgs e)
        {
            var p = txtPass.Text ?? string.Empty;
            var c = txtConfirm.Text ?? string.Empty;
            if (string.IsNullOrEmpty(p))
            {
                MessageBox.Show("Introduce la nueva contraseña.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPass.Focus();
                return;
            }
            if (p != c)
            {
                MessageBox.Show("Las contraseñas no coinciden.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtConfirm.Focus();
                return;
            }

            NuevaPassword = p;
            DialogResult = DialogResult.OK;
            Close();
        }
    }
}