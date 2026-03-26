using System;
using System.Data;
using System.Data.SQLite;
using System.Windows.Forms;

namespace Gestion_Lockers
{
    public partial class frmGestionUsuarios : Form
    {
        private DataTable? _usuariosTable;

        public frmGestionUsuarios()
        {
            InitializeComponent();
            Load += FrmGestionUsuarios_Load;
            btnEliminar.Click += BtnEliminar_Click;
            btnCambiarPass.Click += BtnCambiarPass_Click;
            btnCerrar.Click += (s, e) => Close();
        }

        // ─────────────────────────────────────────────
        // Carga
        // ─────────────────────────────────────────────

        private void FrmGestionUsuarios_Load(object? sender, EventArgs e)
            => CargarUsuarios();

        private void CargarUsuarios()
        {
            try
            {
                using var conn = DBConnection.GetConnection();
                using var da = new SQLiteDataAdapter(
                    "SELECT id_usuario, nombre, tipo_usuario FROM usuarios_sistema ORDER BY id_usuario ASC;",
                    conn);

                _usuariosTable = new DataTable();
                da.Fill(_usuariosTable);
                dgvUsuarios.DataSource = _usuariosTable;

                // Encabezados legibles
                if (dgvUsuarios.Columns["id_usuario"] != null) { dgvUsuarios.Columns["id_usuario"].HeaderText = "ID"; dgvUsuarios.Columns["id_usuario"].Width = 60; }
                if (dgvUsuarios.Columns["nombre"] != null) { dgvUsuarios.Columns["nombre"].HeaderText = "Nombre"; dgvUsuarios.Columns["nombre"].Width = 260; }
                if (dgvUsuarios.Columns["tipo_usuario"] != null) { dgvUsuarios.Columns["tipo_usuario"].HeaderText = "Rol"; dgvUsuarios.Columns["tipo_usuario"].Width = 160; }

                // Estilo mínimo
                dgvUsuarios.DefaultCellStyle.Font = new System.Drawing.Font("Century Gothic", 11F);
                dgvUsuarios.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Century Gothic", 11F, System.Drawing.FontStyle.Bold);
                dgvUsuarios.RowTemplate.Height = 30;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error cargando usuarios: {ex.Message}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ─────────────────────────────────────────────
        // Helpers
        // ─────────────────────────────────────────────

        private int? GetSelectedUserId()
        {
            if (dgvUsuarios.SelectedRows.Count == 0) return null;
            var row = dgvUsuarios.SelectedRows[0].DataBoundItem as DataRowView;
            if (row == null) return null;
            var val = row["id_usuario"];
            return val == DBNull.Value ? null : Convert.ToInt32(val);
        }

        // ─────────────────────────────────────────────
        // Eliminar usuario
        // ─────────────────────────────────────────────

        private void BtnEliminar_Click(object? sender, EventArgs e)
        {
            var id = GetSelectedUserId();
            if (!id.HasValue)
            {
                MessageBox.Show("Seleccione un usuario para eliminar.",
                    "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (Funciones.GetUsuariosCount() <= 1)
            {
                MessageBox.Show("No se puede eliminar el último usuario del sistema.",
                    "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var dr = MessageBox.Show("¿Confirma eliminar el usuario seleccionado?",
                "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr != DialogResult.Yes) return;

            try
            {
                using var conn = DBConnection.GetConnection();
                using var cmd = new SQLiteCommand(
                    "DELETE FROM usuarios_sistema WHERE id_usuario = @id;", conn);
                cmd.Parameters.AddWithValue("@id", id.Value);

                if (cmd.ExecuteNonQuery() > 0)
                {
                    MessageBox.Show("Usuario eliminado.", "Éxito",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    CargarUsuarios();
                }
                else
                {
                    MessageBox.Show("No se encontró el usuario para eliminar.",
                        "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error eliminando usuario: {ex.Message}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ─────────────────────────────────────────────
        // Cambiar contraseña
        // ─────────────────────────────────────────────

        private void BtnCambiarPass_Click(object? sender, EventArgs e)
        {
            var id = GetSelectedUserId();
            if (!id.HasValue)
            {
                MessageBox.Show("Seleccione un usuario para cambiar contraseña.",
                    "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using var dlg = new CambiarPasswordDialog();
            if (dlg.ShowDialog(this) != DialogResult.OK) return;

            string nueva = dlg.NuevaPassword;
            if (string.IsNullOrEmpty(nueva))
            {
                MessageBox.Show("Contraseña no válida.",
                    "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using var conn = DBConnection.GetConnection();
                using var cmd = new SQLiteCommand(
                    "UPDATE usuarios_sistema SET contrasena = @pass WHERE id_usuario = @id;", conn);
                cmd.Parameters.AddWithValue("@pass", Funciones.HashPassword(nueva));
                cmd.Parameters.AddWithValue("@id", id.Value);

                if (cmd.ExecuteNonQuery() > 0)
                    MessageBox.Show("Contraseña actualizada correctamente.", "Éxito",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                else
                    MessageBox.Show("No se encontró el usuario seleccionado.",
                        "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error actualizando contraseña: {ex.Message}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }

    // ─────────────────────────────────────────────
    // Diálogo para cambio de contraseña
    // ─────────────────────────────────────────────

    internal class CambiarPasswordDialog : Form
    {
        private readonly TextBox txtPass;
        private readonly TextBox txtConfirm;
        public string NuevaPassword { get; private set; } = string.Empty;

        public CambiarPasswordDialog()
        {
            Text = "Cambiar contraseña";
            StartPosition = FormStartPosition.CenterParent;
            ClientSize = new System.Drawing.Size(420, 200);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;

            var font = new System.Drawing.Font("Century Gothic", 11F);

            var lbl1 = new Label { Text = "Nueva contraseña:", AutoSize = true, Font = font, Location = new System.Drawing.Point(16, 18) };
            txtPass = new TextBox { Font = font, Location = new System.Drawing.Point(16, 42), Width = 376, UseSystemPasswordChar = true };
            var lbl2 = new Label { Text = "Confirmar contraseña:", AutoSize = true, Font = font, Location = new System.Drawing.Point(16, 86) };
            txtConfirm = new TextBox { Font = font, Location = new System.Drawing.Point(16, 110), Width = 376, UseSystemPasswordChar = true };

            var btnOk = new Button { Text = "Aceptar", Font = font, Location = new System.Drawing.Point(16, 152), Size = new System.Drawing.Size(130, 36), DialogResult = DialogResult.OK };
            var btnCancel = new Button { Text = "Cancelar", Font = font, Location = new System.Drawing.Point(270, 152), Size = new System.Drawing.Size(130, 36), DialogResult = DialogResult.Cancel };

            Controls.AddRange(new System.Windows.Forms.Control[] { lbl1, txtPass, lbl2, txtConfirm, btnOk, btnCancel });
            AcceptButton = btnOk;
            CancelButton = btnCancel;

            btnOk.Click += BtnOk_Click;
            btnCancel.Click += (s, e) => { DialogResult = DialogResult.Cancel; Close(); };
        }

        private void BtnOk_Click(object? sender, EventArgs e)
        {
            string p = txtPass.Text;
            string c = txtConfirm.Text;

            if (string.IsNullOrEmpty(p))
            {
                MessageBox.Show("Introduce la nueva contraseña.", "Validación",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPass.Focus();
                return;
            }

            if (p.Length < 4)
            {
                MessageBox.Show("La contraseña debe tener al menos 4 caracteres.", "Validación",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPass.Focus();
                return;
            }

            if (p != c)
            {
                MessageBox.Show("Las contraseñas no coinciden.", "Validación",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtConfirm.Focus();
                return;
            }

            NuevaPassword = p;
            DialogResult = DialogResult.OK;
            Close();
        }
    }
}