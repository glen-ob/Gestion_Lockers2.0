namespace Gestion_Lockers
{
    partial class frmaltausuario
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
            btnRegresar = new Button();
            btnLimpiar = new Button();
            btnagregar = new Button();
            label2 = new Label();
            label1 = new Label();
            textBox3 = new TextBox();
            textBox1 = new TextBox();
            rbGrupoCultural = new RadioButton();
            rbGrupoAcademico = new RadioButton();
            label3 = new Label();
            textBox2 = new TextBox();
            SuspendLayout();
            // 
            // btnRegresar
            // 
            btnRegresar.Font = new Font("Century Gothic", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnRegresar.Location = new Point(278, 383);
            btnRegresar.Name = "btnRegresar";
            btnRegresar.Size = new Size(127, 55);
            btnRegresar.TabIndex = 17;
            btnRegresar.Text = "Regresar";
            btnRegresar.UseVisualStyleBackColor = true;
            // 
            // btnLimpiar
            // 
            btnLimpiar.Font = new Font("Century Gothic", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnLimpiar.Location = new Point(145, 383);
            btnLimpiar.Name = "btnLimpiar";
            btnLimpiar.Size = new Size(127, 55);
            btnLimpiar.TabIndex = 16;
            btnLimpiar.Text = "Limpiar";
            btnLimpiar.UseVisualStyleBackColor = true;
            // 
            // btnagregar
            // 
            btnagregar.Font = new Font("Century Gothic", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnagregar.Location = new Point(12, 383);
            btnagregar.Name = "btnagregar";
            btnagregar.Size = new Size(127, 55);
            btnagregar.TabIndex = 15;
            btnagregar.Text = "Asignar";
            btnagregar.UseVisualStyleBackColor = true;
            btnagregar.Click += btnagregar_Click_1;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Century Gothic", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.Location = new Point(191, 127);
            label2.Name = "label2";
            label2.Size = new Size(159, 30);
            label2.TabIndex = 13;
            label2.Text = "Contraseña:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Century Gothic", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(233, 84);
            label1.Name = "label1";
            label1.Size = new Size(117, 30);
            label1.TabIndex = 12;
            label1.Text = "Nombre:";
            // 
            // textBox3
            // 
            textBox3.Font = new Font("Century Gothic", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            textBox3.Location = new Point(356, 120);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(283, 37);
            textBox3.TabIndex = 11;
            // 
            // textBox1
            // 
            textBox1.Font = new Font("Century Gothic", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            textBox1.Location = new Point(356, 77);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(283, 37);
            textBox1.TabIndex = 9;
            // 
            // rbGrupoCultural
            // 
            rbGrupoCultural.AutoSize = true;
            rbGrupoCultural.Font = new Font("Century Gothic", 18F);
            rbGrupoCultural.Location = new Point(522, 243);
            rbGrupoCultural.Name = "rbGrupoCultural";
            rbGrupoCultural.Size = new Size(117, 34);
            rbGrupoCultural.TabIndex = 19;
            rbGrupoCultural.TabStop = true;
            rbGrupoCultural.Text = "Usuario";
            rbGrupoCultural.UseVisualStyleBackColor = true;
            // 
            // rbGrupoAcademico
            // 
            rbGrupoAcademico.AutoSize = true;
            rbGrupoAcademico.Font = new Font("Century Gothic", 18F);
            rbGrupoAcademico.Location = new Point(260, 243);
            rbGrupoAcademico.Name = "rbGrupoAcademico";
            rbGrupoAcademico.Size = new Size(195, 34);
            rbGrupoAcademico.TabIndex = 18;
            rbGrupoAcademico.TabStop = true;
            rbGrupoAcademico.Text = "Administrador";
            rbGrupoAcademico.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Century Gothic", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.Location = new Point(65, 170);
            label3.Name = "label3";
            label3.Size = new Size(285, 30);
            label3.TabIndex = 21;
            label3.Text = "Confirmar Contraseña:";
            // 
            // textBox2
            // 
            textBox2.Font = new Font("Century Gothic", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            textBox2.Location = new Point(356, 163);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(283, 37);
            textBox2.TabIndex = 20;
            // 
            // frmaltausuario
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(label3);
            Controls.Add(textBox2);
            Controls.Add(rbGrupoCultural);
            Controls.Add(rbGrupoAcademico);
            Controls.Add(btnRegresar);
            Controls.Add(btnLimpiar);
            Controls.Add(btnagregar);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(textBox3);
            Controls.Add(textBox1);
            Name = "frmaltausuario";
            Text = "Alta Usuario";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnRegresar;
        private Button btnLimpiar;
        private Button btnagregar;
        private Label label2;
        private Label label1;
        private TextBox textBox3;
        private TextBox textBox1;
        private RadioButton rbGrupoCultural;
        private RadioButton rbGrupoAcademico;
        private Label label3;
        private TextBox textBox2;
    }
}