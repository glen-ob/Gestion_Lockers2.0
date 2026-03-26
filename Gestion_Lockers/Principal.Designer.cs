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
            menuStrip1.Items.AddRange(new ToolStripItem[] { mapaToolStripMenuItem, alumnosToolStripMenuItem, usuariosToolStripMenuItem, funcionalidadesToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(1137, 38);
            menuStrip1.TabIndex = 0;
            menuStrip1.Text = "menuStrip1";
            // 
            // mapaToolStripMenuItem
            // 
            mapaToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { verToolStripMenuItem });
            mapaToolStripMenuItem.Name = "mapaToolStripMenuItem";
            mapaToolStripMenuItem.Size = new Size(96, 34);
            mapaToolStripMenuItem.Text = "Mapa";
            // 
            // verToolStripMenuItem
            // 
            verToolStripMenuItem.Name = "verToolStripMenuItem";
            verToolStripMenuItem.Size = new Size(73, 22);
            // 
            // alumnosToolStripMenuItem
            // 
            alumnosToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { asignarToolStripMenuItem, renovarToolStripMenuItem, ingresarToolStripMenuItem, actualizarToolStripMenuItem1 });
            alumnosToolStripMenuItem.Name = "alumnosToolStripMenuItem";
            alumnosToolStripMenuItem.Size = new Size(128, 34);
            alumnosToolStripMenuItem.Text = "Alumnos";
            // 
            // asignarToolStripMenuItem
            // 
            asignarToolStripMenuItem.Name = "asignarToolStripMenuItem";
            asignarToolStripMenuItem.Size = new Size(203, 34);
            // 
            // renovarToolStripMenuItem
            // 
            renovarToolStripMenuItem.Name = "renovarToolStripMenuItem";
            renovarToolStripMenuItem.Size = new Size(203, 34);
            renovarToolStripMenuItem.Text = "Renovar";
            renovarToolStripMenuItem.Click += renovarToolStripMenuItem_Click;
            // 
            // ingresarToolStripMenuItem
            // 
            ingresarToolStripMenuItem.Name = "ingresarToolStripMenuItem";
            ingresarToolStripMenuItem.Size = new Size(203, 34);
            ingresarToolStripMenuItem.Text = "Ingresar";
            ingresarToolStripMenuItem.Click += ingresarToolStripMenuItem_Click;
            // 
            // actualizarToolStripMenuItem1
            // 
            actualizarToolStripMenuItem1.Name = "actualizarToolStripMenuItem1";
            actualizarToolStripMenuItem1.Size = new Size(203, 34);
            actualizarToolStripMenuItem1.Text = "Actualizar";
            actualizarToolStripMenuItem1.Click += actualizarToolStripMenuItem1_Click;
            // 
            // usuariosToolStripMenuItem
            // 
            usuariosToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { ingresarToolStripMenuItem1, eliminarToolStripMenuItem });
            usuariosToolStripMenuItem.Name = "usuariosToolStripMenuItem";
            usuariosToolStripMenuItem.Size = new Size(121, 34);
            usuariosToolStripMenuItem.Text = "Usuarios";
            // 
            // ingresarToolStripMenuItem1
            // 
            ingresarToolStripMenuItem1.Name = "ingresarToolStripMenuItem1";
            ingresarToolStripMenuItem1.Size = new Size(306, 34);
            ingresarToolStripMenuItem1.Text = "Ingresar";
            ingresarToolStripMenuItem1.Click += ingresarToolStripMenuItem1_Click;
            // 
            // eliminarToolStripMenuItem
            // 
            eliminarToolStripMenuItem.Name = "eliminarToolStripMenuItem";
            eliminarToolStripMenuItem.Size = new Size(306, 34);
            eliminarToolStripMenuItem.Text = "Eliminar/Actualizar";
            eliminarToolStripMenuItem.Click += eliminarToolStripMenuItem_Click;
            // 
            // funcionalidadesToolStripMenuItem
            // 
            funcionalidadesToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { periodoDeRenovacionToolStripMenuItem, cancelarRenovacionToolStripMenuItem, reportesToolStripMenuItem });
            funcionalidadesToolStripMenuItem.Name = "funcionalidadesToolStripMenuItem";
            funcionalidadesToolStripMenuItem.Size = new Size(222, 34);
            funcionalidadesToolStripMenuItem.Text = "Funcionalidades";
            funcionalidadesToolStripMenuItem.Click += funcionalidadesToolStripMenuItem_Click;
            // 
            // periodoDeRenovacionToolStripMenuItem
            // 
            periodoDeRenovacionToolStripMenuItem.Name = "periodoDeRenovacionToolStripMenuItem";
            periodoDeRenovacionToolStripMenuItem.Size = new Size(361, 34);
            periodoDeRenovacionToolStripMenuItem.Text = "Periodo de renovacion";
            periodoDeRenovacionToolStripMenuItem.Click += periodoDeRenovacionToolStripMenuItem_Click;
            // 
            // cancelarRenovacionToolStripMenuItem
            // 
            cancelarRenovacionToolStripMenuItem.Name = "cancelarRenovacionToolStripMenuItem";
            cancelarRenovacionToolStripMenuItem.Size = new Size(361, 34);
            cancelarRenovacionToolStripMenuItem.Text = "Cancelar Renovacion";
            cancelarRenovacionToolStripMenuItem.Click += cancelarRenovacionToolStripMenuItem_Click;
            // 
            // reportesToolStripMenuItem
            // 
            reportesToolStripMenuItem.Name = "reportesToolStripMenuItem";
            reportesToolStripMenuItem.Size = new Size(361, 34);
            reportesToolStripMenuItem.Text = "Reportes";
            reportesToolStripMenuItem.Click += reportesToolStripMenuItem_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Century Gothic", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(22, 50);
            label1.Name = "label1";
            label1.Size = new Size(95, 30);
            label1.TabIndex = 1;
            label1.Text = "Fecha:";
            // 
            // lblFechaRenovacion
            // 
            lblFechaRenovacion.AutoSize = true;
            lblFechaRenovacion.Font = new Font("Century Gothic", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblFechaRenovacion.Location = new Point(402, 109);
            lblFechaRenovacion.Name = "lblFechaRenovacion";
            lblFechaRenovacion.Size = new Size(97, 30);
            lblFechaRenovacion.TabIndex = 2;
            lblFechaRenovacion.Text = "--/--/----";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Century Gothic", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.Location = new Point(22, 109);
            label3.Name = "label3";
            label3.Size = new Size(335, 30);
            label3.TabIndex = 3;
            label3.Text = "Fin Periodo de renovacion:";
            // 
            // lblFecha
            // 
            lblFecha.AutoSize = true;
            lblFecha.Font = new Font("Century Gothic", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblFecha.Location = new Point(123, 50);
            lblFecha.Name = "lblFecha";
            lblFecha.Size = new Size(88, 30);
            lblFecha.TabIndex = 4;
            lblFecha.Text = "Fecha";
            // 
            // cbUbicacion
            // 
            cbUbicacion.Font = new Font("Century Gothic", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            cbUbicacion.FormattingEnabled = true;
            cbUbicacion.Location = new Point(111, 153);
            cbUbicacion.Name = "cbUbicacion";
            cbUbicacion.Size = new Size(267, 38);
            cbUbicacion.TabIndex = 8;
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(22, 208);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.Size = new Size(1107, 276);
            dataGridView1.TabIndex = 7;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Century Gothic", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.Location = new Point(29, 161);
            label2.Name = "label2";
            label2.Size = new Size(76, 30);
            label2.TabIndex = 9;
            label2.Text = "Area:";
            // 
            // rbGrupoCultural
            // 
            rbGrupoCultural.AutoSize = true;
            rbGrupoCultural.Font = new Font("Century Gothic", 18F);
            rbGrupoCultural.Location = new Point(343, 802);
            rbGrupoCultural.Name = "rbGrupoCultural";
            rbGrupoCultural.Size = new Size(206, 34);
            rbGrupoCultural.TabIndex = 18;
            rbGrupoCultural.TabStop = true;
            rbGrupoCultural.Text = "Grupo Cultural";
            rbGrupoCultural.UseVisualStyleBackColor = true;
            // 
            // rbGrupoAcademico
            // 
            rbGrupoAcademico.AutoSize = true;
            rbGrupoAcademico.Font = new Font("Century Gothic", 18F);
            rbGrupoAcademico.Location = new Point(81, 802);
            rbGrupoAcademico.Name = "rbGrupoAcademico";
            rbGrupoAcademico.Size = new Size(256, 34);
            rbGrupoAcademico.TabIndex = 17;
            rbGrupoAcademico.TabStop = true;
            rbGrupoAcademico.Text = "Grupo Academico";
            rbGrupoAcademico.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Century Gothic", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label4.Location = new Point(26, 738);
            label4.Name = "label4";
            label4.Size = new Size(124, 30);
            label4.TabIndex = 16;
            label4.Text = "Telefóno:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Century Gothic", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label5.Location = new Point(17, 695);
            label5.Name = "label5";
            label5.Size = new Size(133, 30);
            label5.TabIndex = 15;
            label5.Text = "Matricula:";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Century Gothic", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label6.Location = new Point(33, 652);
            label6.Name = "label6";
            label6.Size = new Size(117, 30);
            label6.TabIndex = 14;
            label6.Text = "Nombre:";
            // 
            // txtMatricula
            // 
            txtMatricula.Font = new Font("Century Gothic", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtMatricula.Location = new Point(156, 688);
            txtMatricula.Name = "txtMatricula";
            txtMatricula.Size = new Size(283, 37);
            txtMatricula.TabIndex = 13;
            // 
            // txtTelefono
            // 
            txtTelefono.Font = new Font("Century Gothic", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtTelefono.Location = new Point(156, 731);
            txtTelefono.Name = "txtTelefono";
            txtTelefono.Size = new Size(283, 37);
            txtTelefono.TabIndex = 12;
            // 
            // TXTNombre
            // 
            TXTNombre.Font = new Font("Century Gothic", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            TXTNombre.Location = new Point(156, 645);
            TXTNombre.Name = "TXTNombre";
            TXTNombre.Size = new Size(283, 37);
            TXTNombre.TabIndex = 11;
            // 
            // btnAsignar
            // 
            btnAsignar.Font = new Font("Century Gothic", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnAsignar.Location = new Point(302, 851);
            btnAsignar.Name = "btnAsignar";
            btnAsignar.Size = new Size(137, 58);
            btnAsignar.TabIndex = 19;
            btnAsignar.Text = "Asignar";
            btnAsignar.UseVisualStyleBackColor = true;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Century Gothic", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label7.Location = new Point(852, 745);
            label7.Name = "label7";
            label7.Size = new Size(133, 30);
            label7.TabIndex = 25;
            label7.Text = "Matricula:";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Century Gothic", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label8.Location = new Point(768, 699);
            label8.Name = "label8";
            label8.Size = new Size(217, 30);
            label8.TabIndex = 24;
            label8.Text = "Nombre Alumno:";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Century Gothic", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label9.Location = new Point(862, 652);
            label9.Name = "label9";
            label9.Size = new Size(123, 30);
            label9.TabIndex = 23;
            label9.Text = "Casillero:";
            // 
            // lblNombre
            // 
            lblNombre.AutoSize = true;
            lblNombre.Font = new Font("Century Gothic", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblNombre.Location = new Point(997, 699);
            lblNombre.Name = "lblNombre";
            lblNombre.Size = new Size(133, 30);
            lblNombre.TabIndex = 22;
            lblNombre.Text = "************";
            // 
            // lblCasillero
            // 
            lblCasillero.AutoSize = true;
            lblCasillero.Font = new Font("Century Gothic", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblCasillero.Location = new Point(997, 652);
            lblCasillero.Name = "lblCasillero";
            lblCasillero.Size = new Size(104, 30);
            lblCasillero.TabIndex = 21;
            lblCasillero.Text = "9999999";
            // 
            // lblMatricula
            // 
            lblMatricula.AutoSize = true;
            lblMatricula.Font = new Font("Century Gothic", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblMatricula.Location = new Point(997, 745);
            lblMatricula.Name = "lblMatricula";
            lblMatricula.Size = new Size(104, 30);
            lblMatricula.TabIndex = 20;
            lblMatricula.Text = "0000000";
            // 
            // btnRenovar
            // 
            btnRenovar.Font = new Font("Century Gothic", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnRenovar.Location = new Point(159, 851);
            btnRenovar.Name = "btnRenovar";
            btnRenovar.Size = new Size(137, 58);
            btnRenovar.TabIndex = 26;
            btnRenovar.Text = "Renovar";
            btnRenovar.UseVisualStyleBackColor = true;
            // 
            // txtBusqueda
            // 
            txtBusqueda.Font = new Font("Century Gothic", 13F);
            txtBusqueda.Location = new Point(17, 490);
            txtBusqueda.Name = "txtBusqueda";
            txtBusqueda.PlaceholderText = "Buscar por #locker, nombre o matrícula";
            txtBusqueda.Size = new Size(380, 29);
            txtBusqueda.TabIndex = 30;
            // 
            // btnBuscar
            // 
            btnBuscar.Font = new Font("Century Gothic", 12F);
            btnBuscar.Location = new Point(17, 528);
            btnBuscar.Name = "btnBuscar";
            btnBuscar.Size = new Size(183, 36);
            btnBuscar.TabIndex = 31;
            btnBuscar.Text = "Buscar";
            btnBuscar.UseVisualStyleBackColor = true;
            // 
            // btnLimpiarBusqueda
            // 
            btnLimpiarBusqueda.Font = new Font("Century Gothic", 12F);
            btnLimpiarBusqueda.Location = new Point(214, 528);
            btnLimpiarBusqueda.Name = "btnLimpiarBusqueda";
            btnLimpiarBusqueda.Size = new Size(183, 36);
            btnLimpiarBusqueda.TabIndex = 32;
            btnLimpiarBusqueda.Text = "Limpiar";
            btnLimpiarBusqueda.UseVisualStyleBackColor = true;
            // 
            // Principal
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1137, 939);
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
        private Button  btnBuscar;
        private Button  btnLimpiarBusqueda;
    }
}