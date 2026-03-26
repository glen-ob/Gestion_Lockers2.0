namespace Gestion_Lockers
{
    partial class FrmAsignacion
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            cbUbicacion = new ComboBox();
            btnRegresarMapa = new Button();
            dataGridView1 = new DataGridView();
            btnBuscar = new Button();
            textBox1 = new TextBox();
            label1 = new Label();
            lblMatricula = new Label();
            lblCasillero = new Label();
            lblNombre = new Label();
            label5 = new Label();
            label6 = new Label();
            label7 = new Label();
            btnAsignar = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // cbUbicacion
            // 
            cbUbicacion.Font = new Font("Century Gothic", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            cbUbicacion.FormattingEnabled = true;
            cbUbicacion.Location = new Point(12, 12);
            cbUbicacion.Name = "cbUbicacion";
            cbUbicacion.Size = new Size(267, 38);
            cbUbicacion.TabIndex = 6;
            // 
            // btnRegresarMapa
            // 
            btnRegresarMapa.Font = new Font("Century Gothic", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnRegresarMapa.Location = new Point(12, 502);
            btnRegresarMapa.Name = "btnRegresarMapa";
            btnRegresarMapa.Size = new Size(202, 43);
            btnRegresarMapa.TabIndex = 5;
            btnRegresarMapa.Text = "Regresar";
            btnRegresarMapa.UseVisualStyleBackColor = true;
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(12, 65);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.Size = new Size(1107, 431);
            dataGridView1.TabIndex = 4;
            // 
            // btnBuscar
            // 
            btnBuscar.Font = new Font("Century Gothic", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnBuscar.Location = new Point(12, 651);
            btnBuscar.Name = "btnBuscar";
            btnBuscar.Size = new Size(202, 43);
            btnBuscar.TabIndex = 7;
            btnBuscar.Text = "Buscar";
            btnBuscar.UseVisualStyleBackColor = true;
            // 
            // textBox1
            // 
            textBox1.Font = new Font("Century Gothic", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            textBox1.Location = new Point(151, 608);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(317, 37);
            textBox1.TabIndex = 8;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Century Gothic", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(12, 615);
            label1.Name = "label1";
            label1.Size = new Size(133, 30);
            label1.TabIndex = 9;
            label1.Text = "Matricula:";
            // 
            // lblMatricula
            // 
            lblMatricula.AutoSize = true;
            lblMatricula.Font = new Font("Century Gothic", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblMatricula.Location = new Point(763, 608);
            lblMatricula.Name = "lblMatricula";
            lblMatricula.Size = new Size(104, 30);
            lblMatricula.TabIndex = 10;
            lblMatricula.Text = "0000000";
            // 
            // lblCasillero
            // 
            lblCasillero.AutoSize = true;
            lblCasillero.Font = new Font("Century Gothic", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblCasillero.Location = new Point(763, 515);
            lblCasillero.Name = "lblCasillero";
            lblCasillero.Size = new Size(104, 30);
            lblCasillero.TabIndex = 11;
            lblCasillero.Text = "9999999";
            // 
            // lblNombre
            // 
            lblNombre.AutoSize = true;
            lblNombre.Font = new Font("Century Gothic", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblNombre.Location = new Point(763, 562);
            lblNombre.Name = "lblNombre";
            lblNombre.Size = new Size(133, 30);
            lblNombre.TabIndex = 12;
            lblNombre.Text = "************";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Century Gothic", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label5.Location = new Point(628, 515);
            label5.Name = "label5";
            label5.Size = new Size(123, 30);
            label5.TabIndex = 13;
            label5.Text = "Casillero:";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Century Gothic", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label6.Location = new Point(534, 562);
            label6.Name = "label6";
            label6.Size = new Size(217, 30);
            label6.TabIndex = 14;
            label6.Text = "Nombre Alumno:";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Century Gothic", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label7.Location = new Point(618, 608);
            label7.Name = "label7";
            label7.Size = new Size(133, 30);
            label7.TabIndex = 15;
            label7.Text = "Matricula:";
            // 
            // btnAsignar
            // 
            btnAsignar.Font = new Font("Century Gothic", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnAsignar.Location = new Point(694, 651);
            btnAsignar.Name = "btnAsignar";
            btnAsignar.Size = new Size(202, 43);
            btnAsignar.TabIndex = 16;
            btnAsignar.Text = "Asignar";
            btnAsignar.UseVisualStyleBackColor = true;
            // 
            // FrmAsignacion
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1138, 939);
            Controls.Add(btnAsignar);
            Controls.Add(label7);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(lblNombre);
            Controls.Add(lblCasillero);
            Controls.Add(lblMatricula);
            Controls.Add(label1);
            Controls.Add(textBox1);
            Controls.Add(btnBuscar);
            Controls.Add(cbUbicacion);
            Controls.Add(btnRegresarMapa);
            Controls.Add(dataGridView1);
            Name = "FrmAsignacion";
            Text = "Asignacion";
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ComboBox cbUbicacion;
        private Button btnRegresarMapa;
        private DataGridView dataGridView1;
        private Button btnBuscar;
        private TextBox textBox1;
        private Label label1;
        private Label lblMatricula;
        private Label lblCasillero;
        private Label lblNombre;
        private Label label5;
        private Label label6;
        private Label label7;
        private Button btnAsignar;
    }
}