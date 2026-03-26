using System;
using System.Windows.Forms;

namespace Gestion_Lockers
{
    public partial class frmaltausuario : Form
    {
        private readonly bool _initialSetup;

        public frmaltausuario()
        {
            InitializeComponent();
            SuscribirEventos();
        }

        public frmaltausuario(bool initialSetup) : this()
        {
            _initialSetup = initialSetup;
            if (!_initialSetup) return;

            Text = "Configuración inicial — Crear administrador";
            rbAdminUsu.Checked = true;
            rbAdminUsu.Enabled = false;
            rbUsuarioUsu.Enabled = false;
            btnRegresarUsu.Enabled = false;
        }

        private void SuscribirEventos()
        {
            btnAgregarUsu.Click += BtnAgregar_Click;
            btnLimpiarUsu.Click += BtnLimpiar_Click;
            btnRegresarUsu.Click += BtnRegresar_Click;
        }

        private void BtnLimpiar_Click(object? sender, EventArgs e)
        {
            txtNombreUsu.Clear();
            txtContrasenaUsu.Clear();
            txtConfirmarUsu.Clear();
            txtNombreUsu.Focus();
        }

        private void BtnRegresar_Click(object? sender, EventArgs e)
        {
            if (_initialSetup)
            {
                MessageBox.Show("Debe crear el usuario administrador para continuar.",
                    "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            Close();
        }

        private void BtnAgregar_Click(object? sender, EventArgs e)
        {
            string nombre = txtNombreUsu.Text.Trim();
            string clave = txtContrasenaUsu.Text;
            string confirmar = txtConfirmarUsu.Text;

            if (string.IsNullOrEmpty(nombre))
            {
                MessageBox.Show("Introduce el nombre de usuario.", "Validación",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNombreUsu.Focus();
                return;
            }

            if (string.IsNullOrEmpty(clave))
            {
                MessageBox.Show("Introduce la contraseña.", "Validación",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtContrasenaUsu.Focus();
                return;
            }

            if (clave.Length < 4)
            {
                MessageBox.Show("La contraseña debe tener al menos 4 caracteres.", "Validación",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtContrasenaUsu.Focus();
                return;
            }

            if (clave != confirmar)
            {
                MessageBox.Show("Las contraseñas no coinciden.", "Validación",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtConfirmarUsu.Focus();
                return;
            }

            string rol = rbAdminUsu.Checked ? "Administrador" : "Usuario";

            try
            {
                Funciones.InsertUsuario(nombre, Funciones.HashPassword(clave), rol);
                MessageBox.Show($"Usuario '{nombre}' ({rol}) creado correctamente.", "Éxito",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al crear usuario: " + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}