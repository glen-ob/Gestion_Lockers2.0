using System;
using System.Data.SQLite;
using System.Windows.Forms;

namespace Gestion_Lockers
{
    public partial class frm_Inicio : Form
    {
        public int UserId { get; private set; }
        public string UserRole { get; private set; } = string.Empty;

        public frm_Inicio()
        {
            InitializeComponent();
            txtContra.UseSystemPasswordChar = true;

            // Un único punto de suscripción — el Designer no debe tener otro Click aquí
            btnicio.Click += Btnicio_Click;
        }

        private void Btnicio_Click(object? sender, EventArgs e)
        {
            string usuario = txtUsu.Text.Trim();
            string contrasena = txtContra.Text;

            if (string.IsNullOrEmpty(usuario))
            {
                MessageBox.Show("Introduce el usuario.", "Validación",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtUsu.Focus();
                return;
            }

            if (string.IsNullOrEmpty(contrasena))
            {
                MessageBox.Show("Introduce la contraseña.", "Validación",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtContra.Focus();
                return;
            }

            try
            {
                using var conn = DBConnection.GetConnection();
                using var cmd = new SQLiteCommand(
                    "SELECT id_usuario, contrasena, tipo_usuario FROM usuarios_sistema WHERE nombre = @nombre LIMIT 1;",
                    conn);
                cmd.Parameters.AddWithValue("@nombre", usuario);

                using var reader = cmd.ExecuteReader();
                if (!reader.Read())
                {
                    MessageBox.Show("Usuario o contraseña incorrectos.", "Error de autenticación",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                int id = reader["id_usuario"] != DBNull.Value ? Convert.ToInt32(reader["id_usuario"]) : 0;
                string contrasenaAlmacenada = reader["contrasena"]?.ToString() ?? string.Empty;
                string rol = reader["tipo_usuario"]?.ToString() ?? string.Empty;

                if (!string.Equals(contrasenaAlmacenada, Funciones.HashPassword(contrasena),
                        StringComparison.OrdinalIgnoreCase))
                {
                    MessageBox.Show("Usuario o contraseña incorrectos.", "Error de autenticación",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                UserId = id;
                UserRole = rol;
                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al autenticar: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Stub vacío que el Designer conectó — ya no hace nada
        private void label1_Click(object sender, EventArgs e) { }

        // Stub vacío — el Designer lo generó pero el clic real lo maneja Btnicio_Click
        private void btnicio_Click_1(object sender, EventArgs e) { }
    }
}