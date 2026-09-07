namespace Gestion_Lockers
{
    partial class Renovacion
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
            btnBuscar = new Button();
            label1 = new Label();
            txtRenovacion = new TextBox();
            btnCancelar = new Button();
            SuspendLayout();
            // 
            // btnBuscar
            // 
            btnBuscar.Font = new Font("Century Gothic", 18F);
            btnBuscar.Location = new Point(127, 187);
            btnBuscar.Margin = new Padding(3, 4, 3, 4);
            btnBuscar.Name = "btnBuscar";
            btnBuscar.Size = new Size(206, 77);
            btnBuscar.TabIndex = 2;
            btnBuscar.Text = "Buscar";
            btnBuscar.UseVisualStyleBackColor = true;
            btnBuscar.Click += btnBuscar_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Century Gothic", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(190, 47);
            label1.Name = "label1";
            label1.Size = new Size(312, 37);
            label1.TabIndex = 3;
            label1.Text = "Matricula a Renovar";
            // 
            // txtRenovacion
            // 
            txtRenovacion.Font = new Font("Century Gothic", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtRenovacion.Location = new Point(127, 129);
            txtRenovacion.Margin = new Padding(3, 4, 3, 4);
            txtRenovacion.Name = "txtRenovacion";
            txtRenovacion.Size = new Size(418, 44);
            txtRenovacion.TabIndex = 4;
            // 
            // btnCancelar
            // 
            btnCancelar.Font = new Font("Century Gothic", 18F);
            btnCancelar.Location = new Point(339, 187);
            btnCancelar.Margin = new Padding(3, 4, 3, 4);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(206, 77);
            btnCancelar.TabIndex = 5;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = true;
            // 
            // Renovacion
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(685, 325);
            Controls.Add(btnCancelar);
            Controls.Add(txtRenovacion);
            Controls.Add(label1);
            Controls.Add(btnBuscar);
            Margin = new Padding(3, 4, 3, 4);
            Name = "Renovacion";
            Text = "Renovacion";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnBuscar;
        private Label label1;
        private TextBox txtRenovacion;
        private Button btnCancelar;
    }
}