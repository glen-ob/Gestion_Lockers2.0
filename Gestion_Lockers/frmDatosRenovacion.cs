using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Gestion_Lockers
{
    /// <summary>
    /// Diálogo que aparece al renovar. Muestra los datos actuales del alumno,
    /// permite editarlos, y pregunta si renueva en el mismo locker o uno diferente.
    /// </summary>
    public class frmDatosRenovacion : Form
    {
        // ── Resultados que leerá Principal ────────────────────────────────
        public string NombreActualizado { get; private set; } = string.Empty;
        public string TelefonoActualizado { get; private set; } = string.Empty;
        public int? IdCarreraSeleccionada { get; private set; } = null;
        public bool MismoLocker { get; private set; } = true;

        // ── Controles ─────────────────────────────────────────────────────
        private readonly TextBox txtNombre;
        private readonly TextBox txtTelefono;
        private readonly ComboBox cbCarrera;
        private readonly Label lblLocker;
        private readonly Button btnMismoLocker;
        private readonly Button btnOtroLocker;
        private readonly Button btnCancelar;

        public frmDatosRenovacion(
            string matricula,
            string nombre,
            string telefono,
            int idLocker)
        {
            Text = "Renovación de locker";
            StartPosition = FormStartPosition.CenterParent;
            ClientSize = new System.Drawing.Size(480, 340);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;

            var font = new System.Drawing.Font("Century Gothic", 11F);
            var fontBold = new System.Drawing.Font("Century Gothic", 11F, System.Drawing.FontStyle.Bold);

            // Encabezado
            var lblTitulo = new Label
            {
                Text = $"Alumno: {matricula}   |   Locker actual: {idLocker}",
                Font = fontBold,
                Location = new System.Drawing.Point(12, 14),
                Size = new System.Drawing.Size(450, 26),
                ForeColor = System.Drawing.Color.FromArgb(40, 80, 160)
            };

            // Nombre
            var lblNombre = new Label { Text = "Nombre:", Font = font, Location = new System.Drawing.Point(12, 58), AutoSize = true };
            txtNombre = new TextBox { Font = font, Location = new System.Drawing.Point(120, 54), Size = new System.Drawing.Size(340, 28), Text = nombre };

            // Teléfono
            var lblTel = new Label { Text = "Teléfono:", Font = font, Location = new System.Drawing.Point(12, 100), AutoSize = true };
            txtTelefono = new TextBox { Font = font, Location = new System.Drawing.Point(120, 96), Size = new System.Drawing.Size(200, 28), Text = telefono };

            // Carrera
            var lblCarrera = new Label { Text = "Carrera:", Font = font, Location = new System.Drawing.Point(12, 142), AutoSize = true };
            cbCarrera = new ComboBox
            {
                Font = font,
                Location = new System.Drawing.Point(120, 138),
                Size = new System.Drawing.Size(240, 28),
                DropDownStyle = ComboBoxStyle.DropDownList
            };
            CargarCarreras(matricula);

            // Separador
            var sep = new Label
            {
                Text = "─────────────────────────────────────────",
                Font = new System.Drawing.Font("Century Gothic", 9F),
                Location = new System.Drawing.Point(12, 184),
                AutoSize = true,
                ForeColor = System.Drawing.Color.Gray
            };

            // Locker
            lblLocker = new Label
            {
                Text = "¿Renovar en el mismo locker o elegir otro?",
                Font = font,
                Location = new System.Drawing.Point(12, 210),
                AutoSize = true
            };

            // Botones de decisión
            btnMismoLocker = new Button
            {
                Text = $"Mismo locker ({idLocker})",
                Font = font,
                Location = new System.Drawing.Point(12, 244),
                Size = new System.Drawing.Size(200, 40),
                UseVisualStyleBackColor = true
            };

            btnOtroLocker = new Button
            {
                Text = "Elegir otro locker",
                Font = font,
                Location = new System.Drawing.Point(222, 244),
                Size = new System.Drawing.Size(160, 40),
                UseVisualStyleBackColor = true
            };

            btnCancelar = new Button
            {
                Text = "Cancelar",
                Font = font,
                Location = new System.Drawing.Point(392, 244),
                Size = new System.Drawing.Size(80, 40),
                UseVisualStyleBackColor = true,
                DialogResult = DialogResult.Cancel
            };

            Controls.AddRange(new System.Windows.Forms.Control[]
            {
                lblTitulo, lblNombre, txtNombre,
                lblTel, txtTelefono,
                lblCarrera, cbCarrera,
                sep, lblLocker,
                btnMismoLocker, btnOtroLocker, btnCancelar
            });

            CancelButton = btnCancelar;

            btnMismoLocker.Click += (s, e) => ConfirmarYCerrar(mismoLocker: true);
            btnOtroLocker.Click += (s, e) => ConfirmarYCerrar(mismoLocker: false);
            btnCancelar.Click += (s, e) => { DialogResult = DialogResult.Cancel; Close(); };
        }

        private void CargarCarreras(string matricula)
        {
            cbCarrera.Items.Clear();
            cbCarrera.Items.Add("— Sin especificar —");
            cbCarrera.SelectedIndex = 0;

            int? idCarreraActual = null;

            // Obtener carrera actual del alumno
            try
            {
                using var conn = DBConnection.GetConnection();
                using var cmd = new System.Data.SQLite.SQLiteCommand(
                    "SELECT id_carrera FROM alumnos WHERE matricula = @m LIMIT 1;", conn);
                cmd.Parameters.AddWithValue("@m", matricula);
                var obj = cmd.ExecuteScalar();
                if (obj != null && obj != System.DBNull.Value)
                    idCarreraActual = Convert.ToInt32(obj);
            }
            catch { }

            // Cargar lista de carreras
            foreach (var c in Funciones.CargarCarreras())
            {
                cbCarrera.Items.Add(c);
                if (c.IdCarrera == idCarreraActual)
                    cbCarrera.SelectedItem = c;
            }
        }

        private void ConfirmarYCerrar(bool mismoLocker)
        {
            // Validar nombre
            string nombre = txtNombre.Text.Trim();
            if (string.IsNullOrEmpty(nombre))
            {
                MessageBox.Show("El nombre no puede estar vacío.", "Validación",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNombre.Focus();
                return;
            }

            // Validar teléfono
            string tel = txtTelefono.Text.Trim();
            if (!System.Text.RegularExpressions.Regex.IsMatch(tel, @"^\d{10}$"))
            {
                MessageBox.Show("El teléfono debe tener exactamente 10 dígitos.", "Validación",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTelefono.Focus();
                return;
            }

            NombreActualizado = nombre;
            TelefonoActualizado = tel;
            MismoLocker = mismoLocker;

            // Carrera seleccionada
            if (cbCarrera.SelectedItem is Funciones.CarreraItem carrera)
                IdCarreraSeleccionada = carrera.IdCarrera;
            else
                IdCarreraSeleccionada = null;

            DialogResult = DialogResult.OK;
            Close();
        }
    }
}