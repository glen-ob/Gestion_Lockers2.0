using System;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Windows.Forms;

namespace Gestion_Lockers
{
    public class frmRenovacion : Form
    {
        private TextBox txtMatricula;
        private ContextMenuStrip contextMenuStrip1;
        private System.ComponentModel.IContainer components;
        private TextBox textBox1;
        private Button btnActu;
        private Label label1;
        private Button btnClose;
        private Button btnBuscar;

        public frmRenovacion()
        {
            Text = "Renovación - Buscar matrícula";
            Size = new Size(420, 160);
            StartPosition = FormStartPosition.CenterParent;

            var lbl = new Label { Text = "Matrícula:", Location = new Point(20, 20), AutoSize = true, Font = new Font(FontFamily.GenericSansSerif, 10) };
            txtMatricula = new TextBox { Location = new Point(100, 16), Size = new Size(280, 26) };
            btnBuscar = new Button { Text = "Buscar", Location = new Point(150, 60), Size = new Size(100, 30) };

            Controls.AddRange(new Control[] { lbl, txtMatricula, btnBuscar });

            btnBuscar.Click += BtnBuscar_Click;
        }

        private void BtnBuscar_Click(object? sender, EventArgs e)
        {
            string matricula = txtMatricula.Text.Trim();
            if (string.IsNullOrEmpty(matricula))
            {
                MessageBox.Show("Introduce la matrícula.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMatricula.Focus();
                return;
            }

            try
            {
                using (var conn = DBConnection.GetConnection())
                using (var cmd = new SQLiteCommand("SELECT * FROM asignaciones WHERE matricula = @matricula;", conn))
                {
                    cmd.Parameters.AddWithValue("@matricula", matricula);
                    using (var da = new SQLiteDataAdapter(cmd))
                    {
                        var dt = new DataTable();
                        da.Fill(dt);

                        if (dt.Rows.Count == 0)
                        {
                            MessageBox.Show($"No se encontró ninguna asignación para la matrícula '{matricula}'.", "No encontrado", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }

                        // Abrir ventana con resultados para permitir edición/renovación
                        var f = new frmRenovacionFuncion(dt, "asignaciones");
                        f.ShowDialog();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error buscando asignación: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnActu_Click(object sender, EventArgs e)
        {

        }

        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            contextMenuStrip1 = new ContextMenuStrip(components);
            textBox1 = new TextBox();
            btnActu = new Button();
            label1 = new Label();
            btnClose = new Button();
            SuspendLayout();
            // 
            // contextMenuStrip1
            // 
            contextMenuStrip1.Name = "contextMenuStrip1";
            contextMenuStrip1.Size = new Size(61, 4);
            // 
            // textBox1
            // 
            textBox1.Font = new Font("Century Gothic", 18F);
            textBox1.Location = new Point(12, 56);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(323, 37);
            textBox1.TabIndex = 1;
            // 
            // btnActu
            // 
            btnActu.Font = new Font("Century Gothic", 18F);
            btnActu.Location = new Point(12, 111);
            btnActu.Name = "btnActu";
            btnActu.Size = new Size(144, 49);
            btnActu.TabIndex = 2;
            btnActu.Text = "Actualizar";
            btnActu.UseVisualStyleBackColor = true;
            btnActu.Click += btnActu_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Century Gothic", 18F);
            label1.Location = new Point(12, 6);
            label1.Name = "label1";
            label1.Size = new Size(133, 30);
            label1.TabIndex = 3;
            label1.Text = "Matricula:";
            // 
            // btnClose
            // 
            btnClose.Font = new Font("Century Gothic", 18F);
            btnClose.Location = new Point(191, 111);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(144, 49);
            btnClose.TabIndex = 4;
            btnClose.Text = "Cerrar";
            btnClose.UseVisualStyleBackColor = true;
            // 
            // frmRenovacion
            // 
            ClientSize = new Size(356, 226);
            Controls.Add(btnClose);
            Controls.Add(label1);
            Controls.Add(btnActu);
            Controls.Add(textBox1);
            Name = "frmRenovacion";
            Load += frmRenovacion_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        private void frmRenovacion_Load(object sender, EventArgs e)
        {

        }
    }
}