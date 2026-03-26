namespace Gestion_Lockers
{
    partial class frmGestionUsuarios
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.dgvUsuarios = new System.Windows.Forms.DataGridView();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.btnCambiarPass = new System.Windows.Forms.Button();
            this.btnCerrar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUsuarios)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvUsuarios
            // 
            this.dgvUsuarios.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
                        | System.Windows.Forms.AnchorStyles.Left) 
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvUsuarios.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvUsuarios.Location = new System.Drawing.Point(12, 12);
            this.dgvUsuarios.Name = "dgvUsuarios";
            this.dgvUsuarios.ReadOnly = true;
            this.dgvUsuarios.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvUsuarios.Size = new System.Drawing.Size(660, 360);
            this.dgvUsuarios.TabIndex = 0;
            // 
            // btnEliminar
            // 
            this.btnEliminar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnEliminar.Location = new System.Drawing.Point(12, 385);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(160, 36);
            this.btnEliminar.TabIndex = 1;
            this.btnEliminar.Text = "Eliminar usuario";
            this.btnEliminar.UseVisualStyleBackColor = true;
            // 
            // btnCambiarPass
            // 
            this.btnCambiarPass.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnCambiarPass.Location = new System.Drawing.Point(178, 385);
            this.btnCambiarPass.Name = "btnCambiarPass";
            this.btnCambiarPass.Size = new System.Drawing.Size(200, 36);
            this.btnCambiarPass.TabIndex = 2;
            this.btnCambiarPass.Text = "Cambiar contraseña";
            this.btnCambiarPass.UseVisualStyleBackColor = true;
            // 
            // btnCerrar
            // 
            this.btnCerrar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCerrar.Location = new System.Drawing.Point(512, 385);
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Size = new System.Drawing.Size(160, 36);
            this.btnCerrar.TabIndex = 3;
            this.btnCerrar.Text = "Cerrar";
            this.btnCerrar.UseVisualStyleBackColor = true;
            // 
            // frmGestionUsuarios
            // 
            this.ClientSize = new System.Drawing.Size(684, 433);
            this.Controls.Add(this.btnCerrar);
            this.Controls.Add(this.btnCambiarPass);
            this.Controls.Add(this.btnEliminar);
            this.Controls.Add(this.dgvUsuarios);
            this.Name = "frmGestionUsuarios";
            this.Text = "Gestión de usuarios";
            ((System.ComponentModel.ISupportInitialize)(this.dgvUsuarios)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvUsuarios;
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.Button btnCambiarPass;
        private System.Windows.Forms.Button btnCerrar;
    }
}