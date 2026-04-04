namespace Gestion_Lockers
{
    partial class Principal
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
            menuStrip1 = new MenuStrip();
            mapaToolStripMenuItem = new ToolStripMenuItem();
            verToolStripMenuItem = new ToolStripMenuItem();
            alumnosToolStripMenuItem = new ToolStripMenuItem();
            asignarToolStripMenuItem = new ToolStripMenuItem();
            renovarToolStripMenuItem = new ToolStripMenuItem();
            ingresarToolStripMenuItem = new ToolStripMenuItem();
            actualizarToolStripMenuItem1 = new ToolStripMenuItem();
            usuariosToolStripMenuItem = new ToolStripMenuItem();
            ingresarToolStripMenuItem1 = new ToolStripMenuItem();
            eliminarToolStripMenuItem = new ToolStripMenuItem();
            funcionalidadesToolStripMenuItem = new ToolStripMenuItem();
            periodoDeRenovacionToolStripMenuItem = new ToolStripMenuItem();
            cancelarRenovacionToolStripMenuItem = new ToolStripMenuItem();
            reportesToolStripMenuItem = new ToolStripMenuItem();
            label1 = new Label();
            lblFechaRenovacion = new Label();
            label3 = new Label();
            lblFecha = new Label();
            cbUbicacion = new ComboBox();
            dataGridView1 = new DataGridView();
            label2 = new Label();
            rbGrupoCultural = new RadioButton();
            rbGrupoAcademico = new RadioButton();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            txtMatricula = new TextBox();
            txtTelefono = new TextBox();
            TXTNombre = new TextBox();
            btnAsignar = new Button();
            label7 = new Label();
            label8 = new Label();
            label9 = new Label();
            lblNombre = new Label();
            lblCasillero = new Label();
            lblMatricula = new Label();
            btnRenovar = new Button();
            txtBusqueda = new TextBox();
            btnBuscar = new Button();
            btnLimpiarBusqueda = new Button();
            menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.Font = new Font("Century Gothic", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            menuStrip1.ImageScalingSize = new Size(20, 20);
            menuStrip1.Items.AddRange(new ToolStripItem[] { mapaToolStripMenuItem, alumnosToolStripMenuItem, usuariosToolStripMenuItem, funcionalidadesToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Padding = new Padding(7, 3, 0, 3);
            menuStrip1.Size = new Size(1299, 47);
            menuStrip1.TabIndex = 0;
            menuStrip1.Text = "menuStrip1";
            // 
            // mapaToolStripMenuItem
            // 
            mapaToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { verToolStripMenuItem });
            mapaToolStripMenuItem.Name = "mapaToolStripMenuItem";
            mapaToolStripMenuItem.Size = new Size(120, 41);
            mapaToolStripMenuItem.Text = "Mapa";
            // 
            // verToolStripMenuItem
            // 
            verToolStripMenuItem.Name = "verToolStripMenuItem";
            verToolStripMenuItem.Size = new Size(91, 26);
            // 
            // alumnosToolStripMenuItem
            // 
            alumnosToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { asignarToolStripMenuItem, renovarToolStripMenuItem, ingresarToolStripMenuItem, actualizarToolStripMenuItem1 });
            alumnosToolStripMenuItem.Name = "alumnosToolStripMenuItem";
            alumnosToolStripMenuItem.Size = new Size(154, 41);
            alumnosToolStripMenuItem.Text = "Alumnos";
            // 
            // asignarToolStripMenuItem
            // 
            asignarToolStripMenuItem.Name = "asignarToolStripMenuItem";
            asignarToolStripMenuItem.Size = new Size(251, 42);
            // 
            // renovarToolStripMenuItem
            // 
            renovarToolStripMenuItem.Name = "renovarToolStripMenuItem";
            renovarToolStripMenuItem.Size = new Size(251, 42);
            renovarToolStripMenuItem.Text = "Renovar";
            renovarToolStripMenuItem.Click += renovarToolStripMenuItem_Click;
            // 
            // ingresarToolStripMenuItem
            // 
            ingresarToolStripMenuItem.Name = "ingresarToolStripMenuItem";
            ingresarToolStripMenuItem.Size = new Size(251, 42);
            ingresarToolStripMenuItem.Text = "Ingresar";
            ingresarToolStripMenuItem.Click += ingresarToolStripMenuItem_Click;
            // 
            // actualizarToolStripMenuItem1
            // 
            actualizarToolStripMenuItem1.Name = "actualizarToolStripMenuItem1";
            actualizarToolStripMenuItem1.Size = new Size(251, 42);
            actualizarToolStripMenuItem1.Text = "Actualizar";
            actualizarToolStripMenuItem1.Click += actualizarToolStripMenuItem1_Click;
            // 
            // usuariosToolStripMenuItem
            // 
            usuariosToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { ingresarToolStripMenuItem1, eliminarToolStripMenuItem });
            usuariosToolStripMenuItem.Name = "usuariosToolStripMenuItem";
            usuariosToolStripMenuItem.Size = new Size(149, 41);
            usuariosToolStripMenuItem.Text = "Usuarios";
            // 
            // ingresarToolStripMenuItem1
            // 
            ingresarToolStripMenuItem1.Name = "ingresarToolStripMenuItem1";
            ingresarToolStripMenuItem1.Size = new Size(375, 42);
            ingresarToolStripMenuItem1.Text = "Ingresar";
            ingresarToolStripMenuItem1.Click += ingresarToolStripMenuItem1_Click;
            // 
            // eliminarToolStripMenuItem
            // 
            eliminarToolStripMenuItem.Name = "eliminarToolStripMenuItem";
            eliminarToolStripMenuItem.Size = new Size(375, 42);
            eliminarToolStripMenuItem.Text = "Eliminar/Actualizar";
            eliminarToolStripMenuItem.Click += eliminarToolStripMenuItem_Click;
            // 
            // funcionalidadesToolStripMenuItem
            // 
            funcionalidadesToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { periodoDeRenovacionToolStripMenuItem, cancelarRenovacionToolStripMenuItem, reportesToolStripMenuItem });
            funcionalidadesToolStripMenuItem.Name = "funcionalidadesToolStripMenuItem";
            funcionalidadesToolStripMenuItem.Size = new Size(272, 41);
            funcionalidadesToolStripMenuItem.Text = "Funcionalidades";
            funcionalidadesToolStripMenuItem.Click += funcionalidadesToolStripMenuItem_Click;
            // 
            // periodoDeRenovacionToolStripMenuItem
            // 
            periodoDeRenovacionToolStripMenuItem.Name = "periodoDeRenovacionToolStripMenuItem";
            periodoDeRenovacionToolStripMenuItem.Size = new Size(445, 42);
            periodoDeRenovacionToolStripMenuItem.Text = "Periodo de renovacion";
            periodoDeRenovacionToolStripMenuItem.Click += periodoDeRenovacionToolStripMenuItem_Click;
            // 
            // cancelarRenovacionToolStripMenuItem
            // 
            cancelarRenovacionToolStripMenuItem.Name = "cancelarRenovacionToolStripMenuItem";
            cancelarRenovacionToolStripMenuItem.Size = new Size(445, 42);
            cancelarRenovacionToolStripMenuItem.Text = "Cancelar Renovacion";
            cancelarRenovacionToolStripMenuItem.Click += cancelarRenovacionToolStripMenuItem_Click;
            // 
            // reportesToolStripMenuItem
            // 
            reportesToolStripMenuItem.Name = "reportesToolStripMenuItem";
            reportesToolStripMenuItem.Size = new Size(445, 42);
            reportesToolStripMenuItem.Text = "Reportes";
            reportesToolStripMenuItem.Click += reportesToolStripMenuItem_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Century Gothic", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(25, 67);
            label1.Name = "label1";
            label1.Size = new Size(116, 37);
            label1.TabIndex = 1;
            label1.Text = "Fecha:";
            // 
            // lblFechaRenovacion
            // 
            lblFechaRenovacion.AutoSize = true;
            lblFechaRenovacion.Font = new Font("Century Gothic", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblFechaRenovacion.Location = new Point(459, 145);
            lblFechaRenovacion.Name = "lblFechaRenovacion";
            lblFechaRenovacion.Size = new Size(123, 37);
            lblFechaRenovacion.TabIndex = 2;
            lblFechaRenovacion.Text = "--/--/----";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Century Gothic", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.Location = new Point(25, 145);
            label3.Name = "label3";
            label3.Size = new Size(410, 37);
            label3.TabIndex = 3;
            label3.Text = "Fin Periodo de renovacion:";
            // 
            // lblFecha
            // 
            lblFecha.AutoSize = true;
            lblFecha.Font = new Font("Century Gothic", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblFecha.Location = new Point(141, 67);
            lblFecha.Name = "lblFecha";
            lblFecha.Size = new Size(108, 37);
            lblFecha.TabIndex = 4;
            lblFecha.Text = "Fecha";
            // 
            // cbUbicacion
            // 
            cbUbicacion.Font = new Font("Century Gothic", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            cbUbicacion.FormattingEnabled = true;
            cbUbicacion.Location = new Point(127, 204);
            cbUbicacion.Margin = new Padding(3, 4, 3, 4);
            cbUbicacion.Name = "cbUbicacion";
            cbUbicacion.Size = new Size(305, 45);
            cbUbicacion.TabIndex = 8;
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(25, 277);
            dataGridView1.Margin = new Padding(3, 4, 3, 4);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.Size = new Size(1265, 202);
            dataGridView1.TabIndex = 7;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Century Gothic", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.Location = new Point(33, 215);
            label2.Name = "label2";
            label2.Size = new Size(94, 37);
            label2.TabIndex = 9;
            label2.Text = "Area:";
            // 
            // rbGrupoCultural
            // 
            rbGrupoCultural.AutoSize = true;
            rbGrupoCultural.Font = new Font("Century Gothic", 18F);
            rbGrupoCultural.Location = new Point(392, 1069);
            rbGrupoCultural.Margin = new Padding(3, 4, 3, 4);
            rbGrupoCultural.Name = "rbGrupoCultural";
            rbGrupoCultural.Size = new Size(250, 41);
            rbGrupoCultural.TabIndex = 18;
            rbGrupoCultural.TabStop = true;
            rbGrupoCultural.Text = "Grupo Cultural";
            rbGrupoCultural.UseVisualStyleBackColor = true;
            // 
            // rbGrupoAcademico
            // 
            rbGrupoAcademico.AutoSize = true;
            rbGrupoAcademico.Font = new Font("Century Gothic", 18F);
            rbGrupoAcademico.Location = new Point(93, 1069);
            rbGrupoAcademico.Margin = new Padding(3, 4, 3, 4);
            rbGrupoAcademico.Name = "rbGrupoAcademico";
            rbGrupoAcademico.Size = new Size(313, 41);
            rbGrupoAcademico.TabIndex = 17;
            rbGrupoAcademico.TabStop = true;
            rbGrupoAcademico.Text = "Grupo Academico";
            rbGrupoAcademico.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Century Gothic", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label4.Location = new Point(45, 727);
            label4.Name = "label4";
            label4.Size = new Size(149, 37);
            label4.TabIndex = 16;
            label4.Text = "Telefóno:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Century Gothic", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label5.Location = new Point(34, 670);
            label5.Name = "label5";
            label5.Size = new Size(163, 37);
            label5.TabIndex = 15;
            label5.Text = "Matricula:";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Century Gothic", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label6.Location = new Point(53, 612);
            label6.Name = "label6";
            label6.Size = new Size(143, 37);
            label6.TabIndex = 14;
            label6.Text = "Nombre:";
            // 
            // txtMatricula
            // 
            txtMatricula.Font = new Font("Century Gothic", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtMatricula.Location = new Point(193, 660);
            txtMatricula.Margin = new Padding(3, 4, 3, 4);
            txtMatricula.Name = "txtMatricula";
            txtMatricula.Size = new Size(323, 44);
            txtMatricula.TabIndex = 13;
            // 
            // txtTelefono
            // 
            txtTelefono.Font = new Font("Century Gothic", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtTelefono.Location = new Point(193, 718);
            txtTelefono.Margin = new Padding(3, 4, 3, 4);
            txtTelefono.Name = "txtTelefono";
            txtTelefono.Size = new Size(323, 44);
            txtTelefono.TabIndex = 12;
            // 
            // TXTNombre
            // 
            TXTNombre.Font = new Font("Century Gothic", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            TXTNombre.Location = new Point(193, 603);
            TXTNombre.Margin = new Padding(3, 4, 3, 4);
            TXTNombre.Name = "TXTNombre";
            TXTNombre.Size = new Size(323, 44);
            TXTNombre.TabIndex = 11;
            // 
            // btnAsignar
            // 
            btnAsignar.Font = new Font("Century Gothic", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnAsignar.Location = new Point(345, 790);
            btnAsignar.Margin = new Padding(3, 4, 3, 4);
            btnAsignar.Name = "btnAsignar";
            btnAsignar.Size = new Size(157, 77);
            btnAsignar.TabIndex = 19;
            btnAsignar.Text = "Asignar";
            btnAsignar.UseVisualStyleBackColor = true;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Century Gothic", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label7.Location = new Point(726, 617);
            label7.Name = "label7";
            label7.Size = new Size(163, 37);
            label7.TabIndex = 25;
            label7.Text = "Matricula:";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Century Gothic", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label8.Location = new Point(630, 556);
            label8.Name = "label8";
            label8.Size = new Size(262, 37);
            label8.TabIndex = 24;
            label8.Text = "Nombre Alumno:";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Century Gothic", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label9.Location = new Point(737, 493);
            label9.Name = "label9";
            label9.Size = new Size(148, 37);
            label9.TabIndex = 23;
            label9.Text = "Casillero:";
            // 
            // lblNombre
            // 
            lblNombre.AutoSize = true;
            lblNombre.Font = new Font("Century Gothic", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblNombre.Location = new Point(891, 556);
            lblNombre.Name = "lblNombre";
            lblNombre.Size = new Size(173, 37);
            lblNombre.TabIndex = 22;
            lblNombre.Text = "************";
            // 
            // lblCasillero
            // 
            lblCasillero.AutoSize = true;
            lblCasillero.Font = new Font("Century Gothic", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblCasillero.Location = new Point(891, 493);
            lblCasillero.Name = "lblCasillero";
            lblCasillero.Size = new Size(136, 37);
            lblCasillero.TabIndex = 21;
            lblCasillero.Text = "9999999";
            // 
            // lblMatricula
            // 
            lblMatricula.AutoSize = true;
            lblMatricula.Font = new Font("Century Gothic", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblMatricula.Location = new Point(891, 617);
            lblMatricula.Name = "lblMatricula";
            lblMatricula.Size = new Size(136, 37);
            lblMatricula.TabIndex = 20;
            lblMatricula.Text = "0000000";
            // 
            // btnRenovar
            // 
            btnRenovar.Font = new Font("Century Gothic", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnRenovar.Location = new Point(182, 790);
            btnRenovar.Margin = new Padding(3, 4, 3, 4);
            btnRenovar.Name = "btnRenovar";
            btnRenovar.Size = new Size(157, 77);
            btnRenovar.TabIndex = 26;
            btnRenovar.Text = "Renovar";
            btnRenovar.UseVisualStyleBackColor = true;
            // 
            // txtBusqueda
            // 
            txtBusqueda.Font = new Font("Century Gothic", 13F);
            txtBusqueda.Location = new Point(25, 496);
            txtBusqueda.Margin = new Padding(3, 4, 3, 4);
            txtBusqueda.Name = "txtBusqueda";
            txtBusqueda.PlaceholderText = "Buscar por #locker, nombre o matrícula";
            txtBusqueda.Size = new Size(434, 34);
            txtBusqueda.TabIndex = 30;
            // 
            // btnBuscar
            // 
            btnBuscar.Font = new Font("Century Gothic", 12F);
            btnBuscar.Location = new Point(25, 547);
            btnBuscar.Margin = new Padding(3, 4, 3, 4);
            btnBuscar.Name = "btnBuscar";
            btnBuscar.Size = new Size(209, 48);
            btnBuscar.TabIndex = 31;
            btnBuscar.Text = "Buscar";
            btnBuscar.UseVisualStyleBackColor = true;
            // 
            // btnLimpiarBusqueda
            // 
            btnLimpiarBusqueda.Font = new Font("Century Gothic", 12F);
            btnLimpiarBusqueda.Location = new Point(251, 547);
            btnLimpiarBusqueda.Margin = new Padding(3, 4, 3, 4);
            btnLimpiarBusqueda.Name = "btnLimpiarBusqueda";
            btnLimpiarBusqueda.Size = new Size(209, 48);
            btnLimpiarBusqueda.TabIndex = 32;
            btnLimpiarBusqueda.Text = "Limpiar";
            btnLimpiarBusqueda.UseVisualStyleBackColor = true;
            // 
            // Principal
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1299, 1055);
            Controls.Add(btnRenovar);
            Controls.Add(label7);
            Controls.Add(label8);
            Controls.Add(label9);
            Controls.Add(lblNombre);
            Controls.Add(lblCasillero);
            Controls.Add(lblMatricula);
            Controls.Add(btnAsignar);
            Controls.Add(rbGrupoCultural);
            Controls.Add(rbGrupoAcademico);
            Controls.Add(label4);
            Controls.Add(label5);
            Controls.Add(label6);
            Controls.Add(txtMatricula);
            Controls.Add(txtTelefono);
            Controls.Add(TXTNombre);
            Controls.Add(label2);
            Controls.Add(cbUbicacion);
            Controls.Add(dataGridView1);
            Controls.Add(lblFecha);
            Controls.Add(label3);
            Controls.Add(lblFechaRenovacion);
            Controls.Add(label1);
            Controls.Add(menuStrip1);
            Controls.Add(txtBusqueda);
            Controls.Add(btnBuscar);
            Controls.Add(btnLimpiarBusqueda);
            MainMenuStrip = menuStrip1;
            Margin = new Padding(3, 4, 3, 4);
            Name = "Principal";
            Text = "Bienvenido";
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip menuStrip1;
        private ToolStripMenuItem mapaToolStripMenuItem;
        private ToolStripMenuItem alumnosToolStripMenuItem;
        private ToolStripMenuItem usuariosToolStripMenuItem;
        private ToolStripMenuItem verToolStripMenuItem;
        private ToolStripMenuItem funcionalidadesToolStripMenuItem;
        private ToolStripMenuItem periodoDeRenovacionToolStripMenuItem;
        private ToolStripMenuItem reportesToolStripMenuItem;
        private ToolStripMenuItem ingresarToolStripMenuItem;
        private ToolStripMenuItem asignarToolStripMenuItem;
        private ToolStripMenuItem renovarToolStripMenuItem;
        private ToolStripMenuItem actualizarToolStripMenuItem1;
        private ToolStripMenuItem ingresarToolStripMenuItem1;
        private ToolStripMenuItem eliminarToolStripMenuItem;
        private Label label1;
        private Label lblFechaRenovacion;
        private Label label3;
        private Label lblFecha;
        private ToolStripMenuItem cancelarRenovacionToolStripMenuItem;
        private ComboBox cbUbicacion;
        private DataGridView dataGridView1;
        private Label label2;
        private RadioButton rbGrupoCultural;
        private RadioButton rbGrupoAcademico;
        private Label label4;
        private Label label5;
        private Label label6;
        private TextBox txtMatricula;
        private TextBox txtTelefono;
        private TextBox TXTNombre;
        private Button btnAsignar;
        private Label label7;
        private Label label8;
        private Label label9;
        private Label lblNombre;
        private Label lblCasillero;
        private Label lblMatricula;
        private Button btnRenovar;
        private TextBox txtBusqueda;
        private Button btnBuscar;
        private Button btnLimpiarBusqueda;
    }
}