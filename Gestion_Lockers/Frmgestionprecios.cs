using System;
using System.Data;
using System.Data.SQLite;
using System.Windows.Forms;

namespace Gestion_Lockers
{
    public class frmGestionPrecios : Form
    {
        private DataGridView dgv;
        private TextBox txtNombre;
        private TextBox txtMonto;
        private TextBox txtDescripcion;
        private Button btnAgregar;
        private Button btnGuardar;
        private Button btnToggle;
        private Button btnCerrar;
        private Label lblNombre;
        private Label lblMonto;
        private Label lblDesc;
        private Label lblCarreras;
        private TextBox txtNuevaCarrera;
        private Button btnAgregarCarrera;
        private DataGridView dgvCarreras;

        private int? _idPrecioSeleccionado = null;

        public frmGestionPrecios()
        {
            Text = "Gestión de precios y carreras";
            StartPosition = FormStartPosition.CenterParent;
            ClientSize = new System.Drawing.Size(700, 600);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;

            var font = new System.Drawing.Font("Century Gothic", 11F);

            // ── Panel precios ──────────────────────────────────────────────
            var grpPrecios = new GroupBox
            {
                Text = "Precios",
                Font = font,
                Location = new System.Drawing.Point(12, 12),
                Size = new System.Drawing.Size(670, 320)
            };

            dgv = new DataGridView
            {
                Location = new System.Drawing.Point(8, 24),
                Size = new System.Drawing.Size(650, 140),
                ReadOnly = true,
                SelectionMode = DataGridViewSelectionMode.FullRowSelect,
                AllowUserToAddRows = false,
                Font = new System.Drawing.Font("Century Gothic", 10F)
            };
            dgv.SelectionChanged += Dgv_SelectionChanged;

            lblNombre = new Label { Text = "Nombre:", Font = font, Location = new System.Drawing.Point(8, 174), AutoSize = true };
            lblMonto = new Label { Text = "Monto ($):", Font = font, Location = new System.Drawing.Point(8, 206), AutoSize = true };
            lblDesc = new Label { Text = "Descripción:", Font = font, Location = new System.Drawing.Point(8, 238), AutoSize = true };

            txtNombre = new TextBox { Font = font, Location = new System.Drawing.Point(130, 170), Size = new System.Drawing.Size(220, 28) };
            txtMonto = new TextBox { Font = font, Location = new System.Drawing.Point(130, 202), Size = new System.Drawing.Size(100, 28) };
            txtDescripcion = new TextBox { Font = font, Location = new System.Drawing.Point(130, 234), Size = new System.Drawing.Size(380, 28) };

            btnAgregar = new Button { Text = "Nuevo precio", Font = font, Location = new System.Drawing.Point(8, 276), Size = new System.Drawing.Size(140, 34), UseVisualStyleBackColor = true };
            btnGuardar = new Button { Text = "Guardar", Font = font, Location = new System.Drawing.Point(158, 276), Size = new System.Drawing.Size(120, 34), UseVisualStyleBackColor = true };
            btnToggle = new Button { Text = "Desactivar", Font = font, Location = new System.Drawing.Point(288, 276), Size = new System.Drawing.Size(130, 34), UseVisualStyleBackColor = true };

            grpPrecios.Controls.AddRange(new System.Windows.Forms.Control[]
                { dgv, lblNombre, lblMonto, lblDesc, txtNombre, txtMonto, txtDescripcion, btnAgregar, btnGuardar, btnToggle });

            // ── Panel carreras ─────────────────────────────────────────────
            var grpCarreras = new GroupBox
            {
                Text = "Carreras",
                Font = font,
                Location = new System.Drawing.Point(12, 340),
                Size = new System.Drawing.Size(670, 200)
            };

            dgvCarreras = new DataGridView
            {
                Location = new System.Drawing.Point(8, 24),
                Size = new System.Drawing.Size(430, 160),
                ReadOnly = true,
                SelectionMode = DataGridViewSelectionMode.FullRowSelect,
                AllowUserToAddRows = false,
                Font = new System.Drawing.Font("Century Gothic", 10F)
            };

            lblCarreras = new Label { Text = "Nueva carrera:", Font = font, Location = new System.Drawing.Point(450, 30), AutoSize = true };
            txtNuevaCarrera = new TextBox { Font = font, Location = new System.Drawing.Point(450, 58), Size = new System.Drawing.Size(200, 28) };
            btnAgregarCarrera = new Button { Text = "Agregar", Font = font, Location = new System.Drawing.Point(450, 96), Size = new System.Drawing.Size(120, 34), UseVisualStyleBackColor = true };

            grpCarreras.Controls.AddRange(new System.Windows.Forms.Control[]
                { dgvCarreras, lblCarreras, txtNuevaCarrera, btnAgregarCarrera });

            btnCerrar = new Button
            {
                Text = "Cerrar",
                Font = font,
                Location = new System.Drawing.Point(570, 558),
                Size = new System.Drawing.Size(112, 36),
                UseVisualStyleBackColor = true
            };

            Controls.AddRange(new System.Windows.Forms.Control[] { grpPrecios, grpCarreras, btnCerrar });

            btnAgregar.Click += BtnAgregar_Click;
            btnGuardar.Click += BtnGuardar_Click;
            btnToggle.Click += BtnToggle_Click;
            btnAgregarCarrera.Click += BtnAgregarCarrera_Click;
            btnCerrar.Click += (s, e) => Close();

            Load += (s, e) => { CargarPrecios(); CargarCarreras(); };
        }

        // ── Precios ────────────────────────────────────────────────────────

        private void CargarPrecios()
        {
            using var conn = DBConnection.GetConnection();
            using var da = new SQLiteDataAdapter(
                "SELECT id_precio AS ID, nombre AS Nombre, monto AS Monto, descripcion AS Descripción, activo AS Activo FROM precios ORDER BY monto;",
                conn);
            var dt = new DataTable();
            da.Fill(dt);
            dgv.DataSource = dt;
            if (dgv.Columns["ID"] != null) dgv.Columns["ID"].Width = 40;
            if (dgv.Columns["Activo"] != null) dgv.Columns["Activo"].Width = 55;
            _idPrecioSeleccionado = null;
            LimpiarFormPrecio();
        }

        private void Dgv_SelectionChanged(object? sender, EventArgs e)
        {
            if (dgv.SelectedRows.Count == 0) return;
            var row = dgv.SelectedRows[0].DataBoundItem as DataRowView;
            if (row == null) return;

            _idPrecioSeleccionado = Convert.ToInt32(row["ID"]);
            txtNombre.Text = row["Nombre"]?.ToString() ?? string.Empty;
            txtMonto.Text = row["Monto"]?.ToString() ?? "0";
            txtDescripcion.Text = row["Descripción"]?.ToString() ?? string.Empty;
            bool activo = Convert.ToInt32(row["Activo"]) == 1;
            btnToggle.Text = activo ? "Desactivar" : "Activar";
        }

        private void BtnAgregar_Click(object? sender, EventArgs e)
        {
            _idPrecioSeleccionado = null;
            LimpiarFormPrecio();
            txtNombre.Focus();
        }

        private void BtnGuardar_Click(object? sender, EventArgs e)
        {
            string nombre = txtNombre.Text.Trim();
            if (string.IsNullOrEmpty(nombre))
            {
                MessageBox.Show("El nombre es obligatorio.", "Validación",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!decimal.TryParse(txtMonto.Text.Trim(), out decimal monto) || monto < 0)
            {
                MessageBox.Show("Ingrese un monto válido (número mayor o igual a 0).", "Validación",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Funciones.GuardarPrecio(nombre, monto, txtDescripcion.Text.Trim(), _idPrecioSeleccionado);
            MessageBox.Show("Precio guardado correctamente.", "Éxito",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
            CargarPrecios();
        }

        private void BtnToggle_Click(object? sender, EventArgs e)
        {
            if (!_idPrecioSeleccionado.HasValue) return;
            bool activar = btnToggle.Text == "Activar";
            Funciones.TogglePrecioActivo(_idPrecioSeleccionado.Value, activar);
            CargarPrecios();
        }

        private void LimpiarFormPrecio()
        {
            txtNombre.Clear();
            txtMonto.Text = "0";
            txtDescripcion.Clear();
            btnToggle.Text = "Desactivar";
        }

        // ── Carreras ───────────────────────────────────────────────────────

        private void CargarCarreras()
        {
            using var conn = DBConnection.GetConnection();
            using var da = new SQLiteDataAdapter(
                "SELECT id_carrera AS ID, nombre AS Carrera, activa AS Activa FROM carreras ORDER BY nombre;",
                conn);
            var dt = new DataTable();
            da.Fill(dt);
            dgvCarreras.DataSource = dt;
            if (dgvCarreras.Columns["ID"] != null) dgvCarreras.Columns["ID"].Width = 40;
        }

        private void BtnAgregarCarrera_Click(object? sender, EventArgs e)
        {
            string nombre = txtNuevaCarrera.Text.Trim().ToUpper();
            if (string.IsNullOrEmpty(nombre))
            {
                MessageBox.Show("Escribe el nombre de la carrera.", "Validación",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Funciones.AgregarCarrera(nombre);
            txtNuevaCarrera.Clear();
            CargarCarreras();
            MessageBox.Show($"Carrera '{nombre}' agregada.", "Éxito",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}