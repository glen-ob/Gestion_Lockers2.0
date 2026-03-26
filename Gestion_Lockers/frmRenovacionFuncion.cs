using System;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Windows.Forms;
using System.Globalization;

namespace Gestion_Lockers
{
    public partial class frmRenovacionFuncion : Form
    {
        private DataGridView dgv;
        private Button btnEditar;
        private DataTable table;
        private readonly string tableName;
        private TextBox txtMatricula;
        private Button btnContinuar;
        private Label label1;
        private Button btnCancelar;

        public frmRenovacionFuncion(DataTable dt, string tableName)
        {
            this.table = dt ?? throw new ArgumentNullException(nameof(dt));
            this.tableName = tableName ?? "asignaciones";

            Text = "Renovación - Resultados";
            Size = new Size(800, 400);
            StartPosition = FormStartPosition.CenterParent;

            dgv = new DataGridView { Dock = DockStyle.Top, Height = 300, ReadOnly = true, SelectionMode = DataGridViewSelectionMode.FullRowSelect, AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill };
            btnEditar = new Button { Text = "Editar fila seleccionada", Dock = DockStyle.Bottom, Height = 40 };

            Controls.Add(dgv);
            Controls.Add(btnEditar);

            dgv.DataSource = table;

            btnEditar.Click += BtnEditar_Click;
        }

        public frmRenovacionFuncion()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            txtMatricula = new TextBox();
            btnContinuar = new Button();
            label1 = new Label();
            btnCancelar = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new System.Drawing.Font("Century Gothic", 12F);
            label1.Location = new System.Drawing.Point(12, 18);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(144, 21);
            label1.Text = "Ingrese matrícula:";
            // 
            // txtMatricula
            // 
            txtMatricula.Font = new System.Drawing.Font("Century Gothic", 12F);
            txtMatricula.Location = new System.Drawing.Point(16, 50);
            txtMatricula.Name = "txtMatricula";
            txtMatricula.Size = new System.Drawing.Size(260, 27);
            // 
            // btnContinuar
            // 
            btnContinuar.Font = new System.Drawing.Font("Century Gothic", 12F);
            btnContinuar.Location = new System.Drawing.Point(16, 90);
            btnContinuar.Name = "btnContinuar";
            btnContinuar.Size = new System.Drawing.Size(120, 35);
            btnContinuar.Text = "Continuar";
            btnContinuar.Click += BtnContinuar_Click;
            // 
            // btnCancelar
            // 
            btnCancelar.Font = new System.Drawing.Font("Century Gothic", 12F);
            btnCancelar.Location = new System.Drawing.Point(156, 90);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new System.Drawing.Size(120, 35);
            btnCancelar.Text = "Cancelar";
            btnCancelar.Click += (s, e) => this.Close();
            // 
            // frmRenovacionFuncion
            // 
            ClientSize = new System.Drawing.Size(300, 145);
            Controls.Add(label1);
            Controls.Add(txtMatricula);
            Controls.Add(btnContinuar);
            Controls.Add(btnCancelar);
            Name = "frmRenovacionFuncion";
            Text = "Renovación por matrícula";
            ResumeLayout(false);
            PerformLayout();
        }

        private void BtnEditar_Click(object? sender, EventArgs e)
        {
            if (dgv.SelectedRows.Count == 0)
            {
                MessageBox.Show("Selecciona una fila para editar.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var row = ((DataRowView)dgv.SelectedRows[0].DataBoundItem).Row;
            var editor = new frmEditarRegistro(tableName, row, table);
            if (editor.ShowDialog() == DialogResult.OK)
            {
                // recargar la fila desde BD para mostrar cambios
                // Si prefieres, puedes recargar todo el DataTable. Aquí recargamos la tabla entera por simplicidad.
                try
                {
                    using (var conn = DBConnection.GetConnection())
                    using (var cmd = new SQLiteCommand($"SELECT * FROM {tableName} WHERE matricula = @matricula;", conn))
                    {
                        cmd.Parameters.AddWithValue("@matricula", row["matricula"].ToString());
                        using (var da = new SQLiteDataAdapter(cmd))
                        {
                            var dt = new DataTable();
                            da.Fill(dt);
                            table.Clear();
                            foreach (DataRow r in dt.Rows) table.ImportRow(r);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error recargando datos: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void BtnContinuar_Click(object? sender, EventArgs e)
        {
            string matricula = txtMatricula.Text.Trim();
            if (string.IsNullOrEmpty(matricula))
            {
                MessageBox.Show("Ingrese la matrícula.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMatricula.Focus();
                return;
            }

            try
            {
                // 1) Obtener último registro de renovacion
                DateTime inicioRen = DateTime.MinValue;
                DateTime finRen = DateTime.MinValue;
                using (var conn = DBConnection.GetConnection())
                using (var cmd = new SQLiteCommand("SELECT fecha_inicio, fecha_fin FROM renovacion ORDER BY fecha_inicio DESC LIMIT 1;", conn))
                using (var dr = cmd.ExecuteReader())
                {
                    if (dr.Read())
                    {
                        var sInicio = dr["fecha_inicio"]?.ToString();
                        var sFin = dr["fecha_fin"]?.ToString();
                        if (!DateTime.TryParse(sInicio, null, DateTimeStyles.RoundtripKind, out inicioRen) ||
                            !DateTime.TryParse(sFin, null, DateTimeStyles.RoundtripKind, out finRen))
                        {
                            // intentar parseo más permisivo
                            DateTime.TryParse(sInicio, out inicioRen);
                            DateTime.TryParse(sFin, out finRen);
                        }
                    }
                    else
                    {
                        MessageBox.Show("No hay periodos de renovación definidos.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                }

                // verificar si hoy está dentro del periodo
                DateTime hoy = DateTime.UtcNow.Date;
                if (hoy < inicioRen.Date || hoy > finRen.Date)
                {
                    MessageBox.Show("No hay una renovación vigente hoy.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                // 2) Comprobar que el alumno tuvo asignación durante ese periodo (ciclo pasado)
                int? lockerAnterior = null;
                using (var conn = DBConnection.GetConnection())
                using (var cmd = new SQLiteCommand("SELECT id_locker FROM asignaciones WHERE matricula = @mat AND fecha_inicio BETWEEN @f1 AND @f2 LIMIT 1;", conn))
                {
                    cmd.Parameters.AddWithValue("@mat", matricula);
                    cmd.Parameters.AddWithValue("@f1", inicioRen.ToString("o"));
                    cmd.Parameters.AddWithValue("@f2", finRen.ToString("o"));
                    cmd.Connection = DBConnection.GetConnection();
                    // NOTE: DBConnection.GetConnection() returns an open connection; avoid opening twice
                }

                // mejor usar una única conexión
                using (var conn2 = DBConnection.GetConnection())
                using (var cmd2 = new SQLiteCommand("SELECT id_locker FROM asignaciones WHERE matricula = @mat AND fecha_inicio BETWEEN @f1 AND @f2 LIMIT 1;", conn2))
                {
                    cmd2.Parameters.AddWithValue("@mat", matricula);
                    cmd2.Parameters.AddWithValue("@f1", inicioRen.ToString("o"));
                    cmd2.Parameters.AddWithValue("@f2", finRen.ToString("o"));
                    using (var dr2 = cmd2.ExecuteReader())
                    {
                        if (dr2.Read())
                        {
                            lockerAnterior = dr2["id_locker"] != DBNull.Value ? Convert.ToInt32(dr2["id_locker"]) : (int?)null;
                        }
                    }
                }

                if (!lockerAnterior.HasValue)
                {
                    MessageBox.Show("El alumno no tiene asignación en el ciclo pasado; no puede renovar automáticamente.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                // 3) Verificar que el locker tenga estatus de renovación (o icono)
                string estadoLocker = string.Empty;
                using (var conn = DBConnection.GetConnection())
                using (var cmd = new SQLiteCommand("SELECT estado FROM lockers WHERE id_locker = @id LIMIT 1;", conn))
                {
                    cmd.Parameters.AddWithValue("@id", lockerAnterior.Value);
                    var obj = cmd.ExecuteScalar();
                    estadoLocker = obj?.ToString() ?? string.Empty;
                }

                // Aceptar si contiene "renov" (case-insensitive) o es '2' (posible código)
                bool esRenovacion = !string.IsNullOrEmpty(estadoLocker) &&
                    (estadoLocker.IndexOf("renov", StringComparison.OrdinalIgnoreCase) >= 0 || estadoLocker.Equals("2"));

                if (!esRenovacion)
                {
                    MessageBox.Show("El locker anterior no está marcado para renovación.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                // Todo OK: abrir FrmAsignacion en modo renovación precargado
                using (var frm = new FrmAsignacion(matricula, lockerAnterior, true))
                {
                    frm.StartPosition = FormStartPosition.CenterParent;
                    frm.ShowDialog(this);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error en flujo de renovación: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}