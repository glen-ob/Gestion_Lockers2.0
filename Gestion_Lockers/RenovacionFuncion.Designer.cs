namespace Gestion_Lockers
{
    partial class RenovacionFuncion
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
            label7 = new Label();
            label6 = new Label();
            label5 = new Label();
            lblNombre = new Label();
            lblCasillero = new Label();
            lblMatricula = new Label();
            cbUbicacion = new ComboBox();
            btnRegresarMapa = new Button();
            dataGridView1 = new DataGridView();
            btnRenovar = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Century Gothic", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label7.Location = new Point(618, 604);
            label7.Name = "label7";
            label7.Size = new Size(133, 30);
            label7.TabIndex = 26;
            label7.Text = "Matricula:";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Century Gothic", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label6.Location = new Point(534, 558);
            label6.Name = "label6";
            label6.Size = new Size(217, 30);
            label6.TabIndex = 25;
            label6.Text = "Nombre Alumno:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Century Gothic", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label5.Location = new Point(628, 511);
            label5.Name = "label5";
            label5.Size = new Size(123, 30);
            label5.TabIndex = 24;
            label5.Text = "Casillero:";
            // 
            // lblNombre
            // 
            lblNombre.AutoSize = true;
            lblNombre.Font = new Font("Century Gothic", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblNombre.Location = new Point(763, 558);
            lblNombre.Name = "lblNombre";
            lblNombre.Size = new Size(133, 30);
            lblNombre.TabIndex = 23;
            lblNombre.Text = "************";
            // 
            // lblCasillero
            // 
            lblCasillero.AutoSize = true;
            lblCasillero.Font = new Font("Century Gothic", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblCasillero.Location = new Point(763, 511);
            lblCasillero.Name = "lblCasillero";
            lblCasillero.Size = new Size(104, 30);
            lblCasillero.TabIndex = 22;
            lblCasillero.Text = "9999999";
            // 
            // lblMatricula
            // 
            lblMatricula.AutoSize = true;
            lblMatricula.Font = new Font("Century Gothic", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblMatricula.Location = new Point(763, 604);
            lblMatricula.Name = "lblMatricula";
            lblMatricula.Size = new Size(104, 30);
            lblMatricula.TabIndex = 21;
            lblMatricula.Text = "0000000";
            // 
            // cbUbicacion
            // 
            cbUbicacion.Font = new Font("Century Gothic", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            cbUbicacion.FormattingEnabled = true;
            cbUbicacion.Location = new Point(12, 8);
            cbUbicacion.Name = "cbUbicacion";
            cbUbicacion.Size = new Size(267, 38);
            cbUbicacion.TabIndex = 18;
            // 
            // btnRegresarMapa
            // 
            btnRegresarMapa.Font = new Font("Century Gothic", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnRegresarMapa.Location = new Point(12, 498);
            btnRegresarMapa.Name = "btnRegresarMapa";
            btnRegresarMapa.Size = new Size(202, 43);
            btnRegresarMapa.TabIndex = 17;
            btnRegresarMapa.Text = "Regresar";
            btnRegresarMapa.UseVisualStyleBackColor = true;
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(12, 61);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.Size = new Size(1107, 431);
            dataGridView1.TabIndex = 16;
            // 
            // btnRenovar
            // 
            btnRenovar.Font = new Font("Century Gothic", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnRenovar.Location = new Point(220, 498);
            btnRenovar.Name = "btnRenovar";
            btnRenovar.Size = new Size(202, 43);
            btnRenovar.TabIndex = 27;
            btnRenovar.Text = "Renovar";
            btnRenovar.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1141, 708);
            Controls.Add(btnRenovar);
            Controls.Add(label7);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(lblNombre);
            Controls.Add(lblCasillero);
            Controls.Add(lblMatricula);
            Controls.Add(cbUbicacion);
            Controls.Add(btnRegresarMapa);
            Controls.Add(dataGridView1);
            Name = "Form1";
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label7;
        private Label label6;
        private Label label5;
        private Label lblNombre;
        private Label lblCasillero;
        private Label lblMatricula;
        private ComboBox cbUbicacion;
        private Button btnRegresarMapa;
        private DataGridView dataGridView1;
        private Button btnRenovar;
    }
}