using System;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Windows.Forms;

namespace Gestion_Lockers
{
    public partial class Mapa : Form
    {
        // Instancia de Diccionario para consultar estados
        private readonly Diccionario diccionario = new Diccionario();

        public Mapa()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Evitar cabeceras
            if (e.RowIndex < 0 || e.ColumnIndex < 0) return;

            var cell = dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex];
            string valor = cell.Value?.ToString();
            if (string.IsNullOrWhiteSpace(valor))
            {
                LimpiarLabels();
                return;
            }

            // intentar interpretar como id numérico
            if (int.TryParse(valor, out int idLocker))
            {
                var info = Funciones.ObtenerAlumnoAsignadoPorLocker(idLocker);
                if (info is not null)
                {
                    lblnombre.Text = info.Nombre;
                    lblmatricula.Text = info.Matricula;
                    lbltelefono.Text = info.Telefono;
                }
                else
                {
                    // Sin asignación activa
                    lblnombre.Text = "Sin asignar";
                    lblmatricula.Text = "-";
                    lbltelefono.Text = "-";
                }
            }
            else
            {
                // valores especiales (SA_3161...) no son numéricos: limpiar o mostrar info distinta
                LimpiarLabels();
            }
        }

        private void LimpiarLabels()
        {
            lblnombre.Text = "******************";
            lblmatricula.Text = "0000000";
            lbltelefono.Text = "0000000000";
        }

        private void CargarLockers()
        {
            Funciones.CargarLockers(dataGridView1, diccionario);
        }

        private void CargarPisos()
        {
            Funciones.CargarPisos(cbUbicacion);
        }

        private void DibujarMapaPiso2()
        {
            Funciones.DibujarMapaPiso2(dataGridView1, diccionario);
        }

        private void DibujarMapaPiso3()
        {
            Funciones.DibujarMapaPiso3(dataGridView1, diccionario);
        }

        private void Mapa_Load_1(object sender, EventArgs e)
        {
            // Primero carga los estados en el diccionario
            Funciones.CargarEstadosDesdeBD(diccionario);

            CargarLockers();
            CargarPisos();
        }

        private void cbUbicacion_SelectedIndexChanged(object sender, EventArgs e)
        {
            string pisoSeleccionado = cbUbicacion.Text;

            if (pisoSeleccionado == "Piso 2")
            {
                DibujarMapaPiso2();
            }
            else if (pisoSeleccionado == "Piso 3")
            {
                DibujarMapaPiso3();
            }
        }


        private void btnRegresarMapa_Click(object sender, EventArgs e)
        {
            try
            {
                // Si el formulario tiene un Owner (p. ej. se abrió con ShowDialog(this)),
                // basta con cerrarlo para regresar a la ventana propietaria.
                if (this.Owner != null)
                {
                    this.Close();
                    return;
                }

                // Si no tiene Owner, intentar encontrar una instancia abierta de Principal y mostrarla.
                foreach (Form frm in Application.OpenForms)
                {
                    if (frm is Principal principal)
                    {
                        principal.StartPosition = FormStartPosition.CenterScreen;
                        principal.Show();
                        this.Close();
                        return;
                    }
                }

                // Si no hay ninguna instancia abierta, crear una nueva Principal.
                var ventanaPrincipal = new Principal();
                ventanaPrincipal.StartPosition = FormStartPosition.CenterScreen;
                ventanaPrincipal.Show();
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"No se pudo regresar al formulario principal: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}