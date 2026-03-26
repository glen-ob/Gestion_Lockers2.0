namespace Gestion_Lockers
{
    partial class frmAltaAlumno
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
            textBox1 = new TextBox();
            textBox2 = new TextBox();
            textBox3 = new TextBox();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            btnagregar = new Button();
            btnLimpiar = new Button();
            btnRegresar = new Button();
            rbGrupoAcademico = new RadioButton();
            rbGrupoCultural = new RadioButton();
            SuspendLayout();
            // 
            // textBox1
            // 
            textBox1.Font = new Font("Century Gothic", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            textBox1.Location = new Point(168, 39);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(283, 37);
            textBox1.TabIndex = 0;
            // 
            // textBox2
            // 
            textBox2.Font = new Font("Century Gothic", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            textBox2.Location = new Point(168, 125);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(283, 37);
            textBox2.TabIndex = 1;
            // 
            // textBox3
            // 
            textBox3.Font = new Font("Century Gothic", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            textBox3.Location = new Point(168, 82);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(283, 37);
            textBox3.TabIndex = 2;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Century Gothic", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(45, 46);
            label1.Name = "label1";
            label1.Size = new Size(117, 30);
            label1.TabIndex = 3;
            label1.Text = "Nombre:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Century Gothic", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.Location = new Point(29, 89);
            label2.Name = "label2";
            label2.Size = new Size(133, 30);
            label2.TabIndex = 4;
            label2.Text = "Matricula:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Century Gothic", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.Location = new Point(38, 132);
            label3.Name = "label3";
            label3.Size = new Size(124, 30);
            label3.TabIndex = 5;
            label3.Text = "Telefóno:";
            // 
            // btnagregar
            // 
            btnagregar.Font = new Font("Century Gothic", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnagregar.Location = new Point(12, 383);
            btnagregar.Name = "btnagregar";
            btnagregar.Size = new Size(127, 55);
            btnagregar.TabIndex = 6;
            btnagregar.Text = "Asignar";
            btnagregar.UseVisualStyleBackColor = true;
            // 
            // btnLimpiar
            // 
            btnLimpiar.Font = new Font("Century Gothic", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnLimpiar.Location = new Point(145, 383);
            btnLimpiar.Name = "btnLimpiar";
            btnLimpiar.Size = new Size(127, 55);
            btnLimpiar.TabIndex = 7;
            btnLimpiar.Text = "Limpiar";
            btnLimpiar.UseVisualStyleBackColor = true;
            // 
            // btnRegresar
            // 
            btnRegresar.Font = new Font("Century Gothic", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnRegresar.Location = new Point(278, 383);
            btnRegresar.Name = "btnRegresar";
            btnRegresar.Size = new Size(127, 55);
            btnRegresar.TabIndex = 8;
            btnRegresar.Text = "Regresar";
            btnRegresar.UseVisualStyleBackColor = true;
            // 
            // rbGrupoAcademico
            // 
            rbGrupoAcademico.AutoSize = true;
            rbGrupoAcademico.Font = new Font("Century Gothic", 18F);
            rbGrupoAcademico.Location = new Point(93, 196);
            rbGrupoAcademico.Name = "rbGrupoAcademico";
            rbGrupoAcademico.Size = new Size(256, 34);
            rbGrupoAcademico.TabIndex = 9;
            rbGrupoAcademico.TabStop = true;
            rbGrupoAcademico.Text = "Grupo Academico";
            rbGrupoAcademico.UseVisualStyleBackColor = true;
            // 
            // rbGrupoCultural
            // 
            rbGrupoCultural.AutoSize = true;
            rbGrupoCultural.Font = new Font("Century Gothic", 18F);
            rbGrupoCultural.Location = new Point(355, 196);
            rbGrupoCultural.Name = "rbGrupoCultural";
            rbGrupoCultural.Size = new Size(206, 34);
            rbGrupoCultural.TabIndex = 10;
            rbGrupoCultural.TabStop = true;
            rbGrupoCultural.Text = "Grupo Cultural";
            rbGrupoCultural.UseVisualStyleBackColor = true;
            // 
            // frmAltaAlumno
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(rbGrupoCultural);
            Controls.Add(rbGrupoAcademico);
            Controls.Add(btnRegresar);
            Controls.Add(btnLimpiar);
            Controls.Add(btnagregar);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(textBox3);
            Controls.Add(textBox2);
            Controls.Add(textBox1);
            Name = "frmAltaAlumno";
            Text = "Alta Alumno";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox textBox1;
        private TextBox textBox2;
        private TextBox textBox3;
        private Label label1;
        private Label label2;
        private Label label3;
        private Button btnagregar;
        private Button btnLimpiar;
        private Button btnRegresar;
        private RadioButton rbGrupoAcademico;
        private RadioButton rbGrupoCultural;
    }
}