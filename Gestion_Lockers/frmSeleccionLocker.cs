using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Gestion_Lockers.Funciones;

namespace Gestion_Lockers
{
    public partial class frmSeleccionLocker : Form
    {
        public BusquedaLockerInfo LockerSeleccionado { get; private set; }
        private readonly List<BusquedaLockerInfo> _lockers;

        public frmSeleccionLocker(List<BusquedaLockerInfo> lockers)
        {
            InitializeComponent();
            _lockers = lockers ?? throw new ArgumentNullException(nameof(lockers));
            CargarDatos();
        }

        private void CargarDatos()
        {
            dgvLockers.DataSource = _lockers;
            dgvLockers.Columns["IdLocker"].HeaderText = "ID Locker";
            dgvLockers.Columns["Estado"].HeaderText = "Estado";
            dgvLockers.Columns["Nombre"].HeaderText = "Nombre";
            dgvLockers.Columns["Matricula"].HeaderText = "Matrícula";
            dgvLockers.Columns["Telefono"].HeaderText = "Teléfono";

            // Ajustar el ancho de las columnas
            dgvLockers.AutoResizeColumns();
        }
        private void btnSeleccionar_Click(object sender, EventArgs e)
        {
            if (dgvLockers.CurrentRow == null)
            {
                MessageBox.Show("Seleccione un locker de la lista.", "Advertencia",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            LockerSeleccionado = _lockers[dgvLockers.CurrentRow.Index];
            DialogResult = DialogResult.OK;
            Close();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void lblSelect_Click(object sender, EventArgs e)
        {

        }

        private void InitializeComponent()
        {
            dgvLockers = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)dgvLockers).BeginInit();
            SuspendLayout();
            // 
            // dgvLockers
            // 
            dgvLockers.AllowUserToAddRows = false;
            dgvLockers.AllowUserToDeleteRows = false;
            dgvLockers.AllowUserToResizeColumns = false;
            dgvLockers.AllowUserToResizeRows = false;
            dgvLockers.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvLockers.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvLockers.Enabled = false;
            dgvLockers.Location = new Point(41, 41);
            dgvLockers.Name = "dgvLockers";
            dgvLockers.RowHeadersWidth = 51;
            dgvLockers.Size = new Size(822, 244);
            dgvLockers.TabIndex = 8;
            // 
            // frmSeleccionLocker
            // 
            ClientSize = new Size(928, 321);
            Controls.Add(dgvLockers);
            Name = "frmSeleccionLocker";
            ((System.ComponentModel.ISupportInitialize)dgvLockers).EndInit();
            ResumeLayout(false);
        }

        private DataGridView dgvLockers;
        private Label lblSelect;
        private Button btnSeleccionar;
        private Button btnCancelar;
    }
}
