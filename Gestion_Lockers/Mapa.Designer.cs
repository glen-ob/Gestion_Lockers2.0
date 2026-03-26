namespace Gestion_Lockers
{
    partial class Mapa
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
            dataGridView1 = new DataGridView();
            btnRegresarMapa = new Button();
            cbUbicacion = new ComboBox();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            lblnombre = new Label();
            lblmatricula = new Label();
            lbltelefono = new Label();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(12, 65);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.Size = new Size(1107, 431);
            dataGridView1.TabIndex = 0;
            dataGridView1.CellContentClick += dataGridView1_CellContentClick;
            // 
            // btnRegresarMapa
            // 
            btnRegresarMapa.Font = new Font("Century Gothic", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnRegresarMapa.Location = new Point(12, 502);
            btnRegresarMapa.Name = "btnRegresarMapa";
            btnRegresarMapa.Size = new Size(202, 43);
            btnRegresarMapa.TabIndex = 2;
            btnRegresarMapa.Text = "Regresar";
            btnRegresarMapa.UseVisualStyleBackColor = true;
            btnRegresarMapa.Click += btnRegresarMapa_Click;
            // 
            // cbUbicacion
            // 
            cbUbicacion.Font = new Font("Century Gothic", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            cbUbicacion.FormattingEnabled = true;
            cbUbicacion.Location = new Point(84, 12);
            cbUbicacion.Name = "cbUbicacion";
            cbUbicacion.Size = new Size(267, 38);
            cbUbicacion.TabIndex = 3;
            cbUbicacion.SelectedIndexChanged += cbUbicacion_SelectedIndexChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Century Gothic", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(12, 20);
            label1.Name = "label1";
            label1.Size = new Size(66, 30);
            label1.TabIndex = 4;
            label1.Text = "Piso:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Century Gothic", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.Location = new Point(472, 515);
            label2.Name = "label2";
            label2.Size = new Size(117, 30);
            label2.TabIndex = 5;
            label2.Text = "Nombre:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Century Gothic", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.Location = new Point(456, 575);
            label3.Name = "label3";
            label3.Size = new Size(133, 30);
            label3.TabIndex = 6;
            label3.Text = "Matricula:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Century Gothic", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label4.Location = new Point(465, 633);
            label4.Name = "label4";
            label4.Size = new Size(124, 30);
            label4.TabIndex = 7;
            label4.Text = "Teléfono:";
            // 
            // lblnombre
            // 
            lblnombre.AutoSize = true;
            lblnombre.Font = new Font("Century Gothic", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblnombre.Location = new Point(595, 515);
            lblnombre.Name = "lblnombre";
            lblnombre.Size = new Size(193, 30);
            lblnombre.TabIndex = 8;
            lblnombre.Text = "******************";
            // 
            // lblmatricula
            // 
            lblmatricula.AutoSize = true;
            lblmatricula.Font = new Font("Century Gothic", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblmatricula.Location = new Point(595, 575);
            lblmatricula.Name = "lblmatricula";
            lblmatricula.Size = new Size(104, 30);
            lblmatricula.TabIndex = 9;
            lblmatricula.Text = "0000000";
            // 
            // lbltelefono
            // 
            lbltelefono.AutoSize = true;
            lbltelefono.Font = new Font("Century Gothic", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lbltelefono.Location = new Point(595, 633);
            lbltelefono.Name = "lbltelefono";
            lbltelefono.Size = new Size(143, 30);
            lbltelefono.TabIndex = 10;
            lbltelefono.Text = "0000000000";
            // 
            // Mapa
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1131, 712);
            Controls.Add(lbltelefono);
            Controls.Add(lblmatricula);
            Controls.Add(lblnombre);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(cbUbicacion);
            Controls.Add(btnRegresarMapa);
            Controls.Add(dataGridView1);
            Name = "Mapa";
            Text = "Mapa";
            Load += Mapa_Load_1;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dataGridView1;
        private ComboBox comboBox1;
        private Button btnRegresarMapa;
        private ComboBox cbUbicacion;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label lblnombre;
        private Label lblmatricula;
        private Label lbltelefono;
    }
}