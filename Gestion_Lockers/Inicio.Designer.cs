namespace Gestion_Lockers
{
    partial class frm_Inicio
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            txtUsu = new TextBox();
            txtContra = new TextBox();
            btnicio = new Button();
            pictureBox1 = new PictureBox();
            label1 = new Label();
            label2 = new Label();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // txtUsu
            // 
            txtUsu.BackColor = SystemColors.HighlightText;
            txtUsu.Font = new Font("Century Gothic", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtUsu.Location = new Point(473, 174);
            txtUsu.Margin = new Padding(3, 4, 3, 4);
            txtUsu.Name = "txtUsu";
            txtUsu.PlaceholderText = "Usuario";
            txtUsu.Size = new Size(276, 44);
            txtUsu.TabIndex = 2;
            txtUsu.TextChanged += txtUsu_TextChanged;
            // 
            // txtContra
            // 
            txtContra.BackColor = SystemColors.HighlightText;
            txtContra.Font = new Font("Century Gothic", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtContra.Location = new Point(473, 244);
            txtContra.Margin = new Padding(3, 4, 3, 4);
            txtContra.Name = "txtContra";
            txtContra.PlaceholderText = "Contraseña";
            txtContra.Size = new Size(276, 44);
            txtContra.TabIndex = 3;
            // 
            // btnicio
            // 
            btnicio.BackColor = Color.White;
            btnicio.FlatStyle = FlatStyle.System;
            btnicio.Font = new Font("Century Gothic", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnicio.Location = new Point(473, 322);
            btnicio.Margin = new Padding(3, 4, 3, 4);
            btnicio.Name = "btnicio";
            btnicio.Size = new Size(276, 85);
            btnicio.TabIndex = 4;
            btnicio.Text = "INICIO";
            btnicio.UseVisualStyleBackColor = false;
            btnicio.Click += btnicio_Click_1;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.images;
            pictureBox1.Location = new Point(-5, -2);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(450, 450);
            pictureBox1.TabIndex = 5;
            pictureBox1.TabStop = false;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Century Gothic", 18F);
            label1.ForeColor = SystemColors.ButtonHighlight;
            label1.Location = new Point(451, 56);
            label1.Name = "label1";
            label1.Size = new Size(328, 37);
            label1.TabIndex = 6;
            label1.Text = "GESTIÓN DE LOCKERS";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Century Gothic", 18F);
            label2.ForeColor = SystemColors.ButtonHighlight;
            label2.Location = new Point(548, 102);
            label2.Name = "label2";
            label2.Size = new Size(131, 37);
            label2.TabIndex = 7;
            label2.Text = "SEFCFM";
            // 
            // frm_Inicio
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.MidnightBlue;
            ClientSize = new Size(787, 440);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(pictureBox1);
            Controls.Add(btnicio);
            Controls.Add(txtContra);
            Controls.Add(txtUsu);
            Margin = new Padding(3, 4, 3, 4);
            Name = "frm_Inicio";
            Text = "Inicio";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private TextBox txtUsu;
        private TextBox txtContra;
        private Button btnicio;
        private PictureBox pictureBox1;
        private Label label1;
        private Label label2;
    }
}
