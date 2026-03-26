using System;
using System.Data.SQLite;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;

namespace Gestion_Lockers
{
    public partial class frmaltausuario : Form
    {
        private readonly bool _initialSetup;

        public frmaltausuario()
        {
            InitializeComponent();
            WireEvents();
        }

        // Nuevo constructor para modo inicial
        public frmaltausuario(bool initialSetup) : this()
        {
            _initialSetup = initialSetup;
            if (_initialSetup)
            {
                Text = "Configuración inicial - Crear Administrador";
                // Seleccionar Admin y bloquear selección
                rbGrupoAcademico.Checked = true; // Administrador
                rbGrupoAcademico.Enabled = false;
                rbGrupoCultural.Enabled = false;

                // Opcional: deshabilitar botón regresar para forzar creación
                btnRegresar.Enabled = false;
            }
        }

        private void WireEvents()
        {
            btnagregar.Click += Btnagregar_Click;
            btnRegresar.Click += BtnRegresar_Click;
            btnLimpiar.Click += BtnLimpiar_Click;
        }

        private void BtnLimpiar_Click(object? sender, EventArgs e)
        {
            textBox1.Clear();
            textBox3.Clear();
            textBox2.Clear();
        }

        private void BtnRegresar_Click(object? sender, EventArgs e)
        {
            // Si estamos en configuración inicial no permitir regresar
            if (_initialSetup)
            {
                MessageBox.Show("Debe crear el usuario administrador para continuar.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            Close();
        }

        private void Btnagregar_Click(object? sender, EventArgs e)
        {
            string nombre = textBox1.Text.Trim();
            string clave = textBox3.Text;
            string confirmar = textBox2.Text;

            if (string.IsNullOrEmpty(nombre))
            {
                MessageBox.Show("Introduce el nombre.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (string.IsNullOrEmpty(clave))
            {
                MessageBox.Show("Introduce la contraseña.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (clave != confirmar)
            {
                MessageBox.Show("Las contraseñas no coinciden.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string rol = rbGrupoAcademico.Checked ? "Administrador" : "Usuario";

            try
            {
                Funciones.InsertUsuario(nombre, Funciones.HashPassword(clave), rol);
                MessageBox.Show("Usuario creado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Si venimos de la configuración inicial, devolver OK para que Program continúe
                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al crear usuario: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnagregar_Click_1(object sender, EventArgs e)
        {

        }
    }
}
