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
            lblNombre = new Label();
            label2 = new Label();
            txtUsu = new TextBox();
            txtContra = new TextBox();
            btnicio = new Button();
            SuspendLayout();
            // 
            // lblNombre
            // 
            lblNombre.AutoSize = true;
            lblNombre.Font = new Font("Century Gothic", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblNombre.Location = new Point(221, 124);
            lblNombre.Name = "lblNombre";
            lblNombre.Size = new Size(106, 30);
            lblNombre.TabIndex = 0;
            lblNombre.Text = "Usuario:";
            lblNombre.Click += label1_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Century Gothic", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.Location = new Point(168, 190);
            label2.Name = "label2";
            label2.Size = new Size(159, 30);
            label2.TabIndex = 1;
            label2.Text = "Contraseña:";
            // 
            // txtUsu
            // 
            txtUsu.Font = new Font("Century Gothic", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtUsu.Location = new Point(333, 117);
            txtUsu.Name = "txtUsu";
            txtUsu.Size = new Size(242, 37);
            txtUsu.TabIndex = 2;
            // 
            // txtContra
            // 
            txtContra.Font = new Font("Century Gothic", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtContra.Location = new Point(333, 183);
            txtContra.Name = "txtContra";
            txtContra.Size = new Size(242, 37);
            txtContra.TabIndex = 3;
            // 
            // btnicio
            // 
            btnicio.Font = new Font("Century Gothic", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnicio.Location = new Point(315, 254);
            btnicio.Name = "btnicio";
            btnicio.Size = new Size(142, 64);
            btnicio.TabIndex = 4;
            btnicio.Text = "INICIO";
            btnicio.UseVisualStyleBackColor = true;
            btnicio.Click += btnicio_Click_1;
            // 
            // frm_Inicio
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnicio);
            Controls.Add(txtContra);
            Controls.Add(txtUsu);
            Controls.Add(label2);
            Controls.Add(lblNombre);
            Name = "frm_Inicio";
            Text = "Inicio";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblNombre;
        private Label label2;
        private TextBox txtUsu;
        private TextBox txtContra;
        private Button btnicio;
    }
}
