namespace Gestion_Lockers
{
    partial class frmaltausuario
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            lblNombreUsu = new Label();
            lblContrasenaUsu = new Label();
            lblConfirmarUsu = new Label();
            lblRolUsu = new Label();
            txtNombreUsu = new TextBox();
            txtContrasenaUsu = new TextBox();
            txtConfirmarUsu = new TextBox();
            rbAdminUsu = new RadioButton();
            rbUsuarioUsu = new RadioButton();
            btnAgregarUsu = new Button();
            btnLimpiarUsu = new Button();
            btnRegresarUsu = new Button();
            SuspendLayout();

            // lblNombreUsu
            lblNombreUsu.AutoSize = true;
            lblNombreUsu.Font = new Font("Century Gothic", 14F);
            lblNombreUsu.Location = new Point(40, 50);
            lblNombreUsu.Text = "Nombre de usuario:";

            // txtNombreUsu
            txtNombreUsu.Font = new Font("Century Gothic", 14F);
            txtNombreUsu.Location = new Point(260, 44);
            txtNombreUsu.Size = new Size(280, 30);
            txtNombreUsu.TabIndex = 0;

            // lblContrasenaUsu
            lblContrasenaUsu.AutoSize = true;
            lblContrasenaUsu.Font = new Font("Century Gothic", 14F);
            lblContrasenaUsu.Location = new Point(40, 100);
            lblContrasenaUsu.Text = "Contraseña:";

            // txtContrasenaUsu
            txtContrasenaUsu.Font = new Font("Century Gothic", 14F);
            txtContrasenaUsu.Location = new Point(260, 94);
            txtContrasenaUsu.Size = new Size(280, 30);
            txtContrasenaUsu.UseSystemPasswordChar = true;
            txtContrasenaUsu.TabIndex = 1;

            // lblConfirmarUsu
            lblConfirmarUsu.AutoSize = true;
            lblConfirmarUsu.Font = new Font("Century Gothic", 14F);
            lblConfirmarUsu.Location = new Point(40, 150);
            lblConfirmarUsu.Text = "Confirmar contraseña:";

            // txtConfirmarUsu
            txtConfirmarUsu.Font = new Font("Century Gothic", 14F);
            txtConfirmarUsu.Location = new Point(260, 144);
            txtConfirmarUsu.Size = new Size(280, 30);
            txtConfirmarUsu.UseSystemPasswordChar = true;
            txtConfirmarUsu.TabIndex = 2;

            // lblRolUsu
            lblRolUsu.AutoSize = true;
            lblRolUsu.Font = new Font("Century Gothic", 14F);
            lblRolUsu.Location = new Point(40, 210);
            lblRolUsu.Text = "Rol:";

            // rbAdminUsu
            rbAdminUsu.AutoSize = true;
            rbAdminUsu.Font = new Font("Century Gothic", 14F);
            rbAdminUsu.Location = new Point(260, 206);
            rbAdminUsu.Text = "Administrador";
            rbAdminUsu.TabIndex = 3;

            // rbUsuarioUsu
            rbUsuarioUsu.AutoSize = true;
            rbUsuarioUsu.Font = new Font("Century Gothic", 14F);
            rbUsuarioUsu.Location = new Point(450, 206);
            rbUsuarioUsu.Text = "Usuario";
            rbUsuarioUsu.Checked = true;
            rbUsuarioUsu.TabIndex = 4;

            // btnAgregarUsu
            btnAgregarUsu.Font = new Font("Century Gothic", 13F);
            btnAgregarUsu.Location = new Point(40, 280);
            btnAgregarUsu.Size = new Size(140, 48);
            btnAgregarUsu.TabIndex = 5;
            btnAgregarUsu.Text = "Agregar";
            btnAgregarUsu.UseVisualStyleBackColor = true;

            // btnLimpiarUsu
            btnLimpiarUsu.Font = new Font("Century Gothic", 13F);
            btnLimpiarUsu.Location = new Point(200, 280);
            btnLimpiarUsu.Size = new Size(140, 48);
            btnLimpiarUsu.TabIndex = 6;
            btnLimpiarUsu.Text = "Limpiar";
            btnLimpiarUsu.UseVisualStyleBackColor = true;

            // btnRegresarUsu
            btnRegresarUsu.Font = new Font("Century Gothic", 13F);
            btnRegresarUsu.Location = new Point(360, 280);
            btnRegresarUsu.Size = new Size(140, 48);
            btnRegresarUsu.TabIndex = 7;
            btnRegresarUsu.Text = "Regresar";
            btnRegresarUsu.UseVisualStyleBackColor = true;

            // frmaltausuario
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(580, 360);
            Text = "Alta de usuario";
            StartPosition = FormStartPosition.CenterParent;

            Controls.Add(lblNombreUsu);
            Controls.Add(txtNombreUsu);
            Controls.Add(lblContrasenaUsu);
            Controls.Add(txtContrasenaUsu);
            Controls.Add(lblConfirmarUsu);
            Controls.Add(txtConfirmarUsu);
            Controls.Add(lblRolUsu);
            Controls.Add(rbAdminUsu);
            Controls.Add(rbUsuarioUsu);
            Controls.Add(btnAgregarUsu);
            Controls.Add(btnLimpiarUsu);
            Controls.Add(btnRegresarUsu);

            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblNombreUsu;
        private Label lblContrasenaUsu;
        private Label lblConfirmarUsu;
        private Label lblRolUsu;
        private TextBox txtNombreUsu;
        private TextBox txtContrasenaUsu;
        private TextBox txtConfirmarUsu;
        private RadioButton rbAdminUsu;
        private RadioButton rbUsuarioUsu;
        private Button btnAgregarUsu;
        private Button btnLimpiarUsu;
        private Button btnRegresarUsu;
    }
}