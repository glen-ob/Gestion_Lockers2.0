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
            txtBusquedaNombre = new TextBox();
            btnBuscar = new Button();
            btnLimpiarBusqueda = new Button();
            lblCarrera = new Label();
            cbCarrera = new ComboBox();
            cbPrecio = new ComboBox();
            label10 = new Label();
            label11 = new Label();
            label12 = new Label();
            btnVaciarLocker = new Button();
            btnEditar = new Button();
            rbGrupoAcademico = new RadioButton();
            rbGrupoCultural = new RadioButton();
            label13 = new Label();
            txtAtendio = new TextBox();
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
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.Size = new Size(1107, 152);
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
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Century Gothic", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label4.Location = new Point(39, 514);
            label4.Name = "label4";
            label4.Size = new Size(124, 30);
            label4.TabIndex = 16;
            label4.Text = "Telefóno:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Century Gothic", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label5.Location = new Point(574, 459);
            label5.Name = "label5";
            label5.Size = new Size(133, 30);
            label5.TabIndex = 15;
            label5.Text = "Matricula:";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Century Gothic", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label6.Location = new Point(46, 459);
            label6.Name = "label6";
            label6.Size = new Size(117, 30);
            label6.TabIndex = 14;
            label6.Text = "Nombre:";
            // 
            // txtMatricula
            // 
            txtMatricula.Font = new Font("Century Gothic", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtMatricula.Location = new Point(713, 452);
            txtMatricula.Name = "txtMatricula";
            txtMatricula.Size = new Size(374, 37);
            txtMatricula.TabIndex = 13;
            // 
            // txtTelefono
            // 
            txtTelefono.Font = new Font("Century Gothic", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtTelefono.Location = new Point(169, 507);
            txtTelefono.Name = "txtTelefono";
            txtTelefono.Size = new Size(374, 37);
            txtTelefono.TabIndex = 12;
            // 
            // TXTNombre
            // 
            TXTNombre.Font = new Font("Century Gothic", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            TXTNombre.Location = new Point(169, 452);
            TXTNombre.Name = "TXTNombre";
            TXTNombre.Size = new Size(374, 37);
            TXTNombre.TabIndex = 11;
            // 
            // btnAsignar
            // 
            btnAsignar.Font = new Font("Century Gothic", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnAsignar.Location = new Point(688, 640);
            btnAsignar.Name = "btnAsignar";
            btnAsignar.Size = new Size(180, 58);
            btnAsignar.TabIndex = 19;
            btnAsignar.Text = "Asignar";
            btnAsignar.UseVisualStyleBackColor = true;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Century Gothic", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label7.Location = new Point(619, 818);
            label7.Name = "label7";
            label7.Size = new Size(133, 30);
            label7.TabIndex = 25;
            label7.Text = "Matricula:";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Century Gothic", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label8.Location = new Point(639, 775);
            label8.Name = "label8";
            label8.Size = new Size(113, 30);
            label8.TabIndex = 24;
            label8.Text = "Alumno:";
            label8.Click += label8_Click;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Century Gothic", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label9.Location = new Point(629, 861);
            label9.Name = "label9";
            label9.Size = new Size(123, 30);
            label9.TabIndex = 23;
            label9.Text = "Casillero:";
            // 
            // lblNombre
            // 
            lblNombre.AutoSize = true;
            lblNombre.Font = new Font("Century Gothic", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblNombre.Location = new Point(764, 775);
            lblNombre.Name = "lblNombre";
            lblNombre.Size = new Size(133, 30);
            lblNombre.TabIndex = 22;
            lblNombre.Text = "************";
            // 
            // lblCasillero
            // 
            lblCasillero.AutoSize = true;
            lblCasillero.Font = new Font("Century Gothic", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblCasillero.Location = new Point(764, 861);
            lblCasillero.Name = "lblCasillero";
            lblCasillero.Size = new Size(104, 30);
            lblCasillero.TabIndex = 21;
            lblCasillero.Text = "9999999";
            // 
            // lblMatricula
            // 
            lblMatricula.AutoSize = true;
            lblMatricula.Font = new Font("Century Gothic", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblMatricula.Location = new Point(764, 818);
            lblMatricula.Name = "lblMatricula";
            lblMatricula.Size = new Size(104, 30);
            lblMatricula.TabIndex = 20;
            lblMatricula.Text = "0000000";
            // 
            // btnRenovar
            // 
            btnRenovar.Font = new Font("Century Gothic", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnRenovar.Location = new Point(907, 640);
            btnRenovar.Name = "btnRenovar";
            btnRenovar.Size = new Size(180, 58);
            btnRenovar.TabIndex = 26;
            btnRenovar.Text = "Renovar";
            btnRenovar.UseVisualStyleBackColor = true;
            btnRenovar.Click += btnRenovar_Click_1;
            // 
            // txtBusquedaNombre
            // 
            txtBusquedaNombre.Font = new Font("Century Gothic", 13F);
            txtBusquedaNombre.Location = new Point(22, 372);
            txtBusquedaNombre.Name = "txtBusquedaNombre";
            txtBusquedaNombre.PlaceholderText = "Buscar por #locker o nombre de estudiante";
            txtBusquedaNombre.Size = new Size(400, 29);
            txtBusquedaNombre.TabIndex = 30;
            // 
            // btnBuscar
            // 
            btnBuscar.Font = new Font("Century Gothic", 12F);
            btnBuscar.Location = new Point(22, 410);
            btnBuscar.Name = "btnBuscar";
            btnBuscar.Size = new Size(183, 36);
            btnBuscar.TabIndex = 31;
            btnBuscar.Text = "Buscar";
            btnBuscar.UseVisualStyleBackColor = true;
            // 
            // btnLimpiarBusqueda
            // 
            btnLimpiarBusqueda.Font = new Font("Century Gothic", 12F);
            btnLimpiarBusqueda.Location = new Point(239, 410);
            btnLimpiarBusqueda.Name = "btnLimpiarBusqueda";
            btnLimpiarBusqueda.Size = new Size(183, 36);
            btnLimpiarBusqueda.TabIndex = 32;
            btnLimpiarBusqueda.Text = "Limpiar";
            btnLimpiarBusqueda.UseVisualStyleBackColor = true;
            // 
            // lblCarrera
            // 
            lblCarrera.AutoSize = true;
            lblCarrera.Font = new Font("Century Gothic", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblCarrera.Location = new Point(598, 509);
            lblCarrera.Name = "lblCarrera";
            lblCarrera.Size = new Size(109, 30);
            lblCarrera.TabIndex = 33;
            lblCarrera.Text = "Carrera:";
            // 
            // cbCarrera
            // 
            cbCarrera.Font = new Font("Century Gothic", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            cbCarrera.FormattingEnabled = true;
            cbCarrera.Location = new Point(713, 506);
            cbCarrera.Name = "cbCarrera";
            cbCarrera.Size = new Size(374, 38);
            cbCarrera.TabIndex = 34;
            // 
            // cbPrecio
            // 
            cbPrecio.Font = new Font("Century Gothic", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            cbPrecio.FormattingEnabled = true;
            cbPrecio.Location = new Point(485, 153);
            cbPrecio.Name = "cbPrecio";
            cbPrecio.Size = new Size(267, 38);
            cbPrecio.TabIndex = 35;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Font = new Font("Century Gothic", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label10.Location = new Point(384, 161);
            label10.Name = "label10";
            label10.Size = new Size(95, 30);
            label10.TabIndex = 36;
            label10.Text = "Precio:";
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Font = new Font("Century Gothic", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label11.Location = new Point(878, 50);
            label11.Name = "label11";
            label11.Size = new Size(99, 30);
            label11.TabIndex = 38;
            label11.Text = "Usuario";
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Font = new Font("Century Gothic", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label12.Location = new Point(777, 50);
            label12.Name = "label12";
            label12.Size = new Size(106, 30);
            label12.TabIndex = 37;
            label12.Text = "Usuario:";
            // 
            // btnVaciarLocker
            // 
            btnVaciarLocker.Font = new Font("Century Gothic", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnVaciarLocker.Location = new Point(39, 640);
            btnVaciarLocker.Name = "btnVaciarLocker";
            btnVaciarLocker.Size = new Size(180, 58);
            btnVaciarLocker.TabIndex = 39;
            btnVaciarLocker.Text = "Vaciar";
            btnVaciarLocker.UseVisualStyleBackColor = true;
            btnVaciarLocker.Click += btnVaciarLocker_Click;
            // 
            // btnEditar
            // 
            btnEditar.Font = new Font("Century Gothic", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnEditar.Location = new Point(258, 640);
            btnEditar.Name = "btnEditar";
            btnEditar.Size = new Size(180, 58);
            btnEditar.TabIndex = 40;
            btnEditar.Text = "Actualizar";
            btnEditar.UseVisualStyleBackColor = true;
            btnEditar.Click += btnEditar_Click;
            // 
            // rbGrupoAcademico
            // 
            rbGrupoAcademico.AutoSize = true;
            rbGrupoAcademico.Font = new Font("Century Gothic", 18F);
            rbGrupoAcademico.Location = new Point(82, 824);
            rbGrupoAcademico.Name = "rbGrupoAcademico";
            rbGrupoAcademico.Size = new Size(256, 34);
            rbGrupoAcademico.TabIndex = 17;
            rbGrupoAcademico.TabStop = true;
            rbGrupoAcademico.Text = "Grupo Academico";
            rbGrupoAcademico.UseVisualStyleBackColor = true;
            // 
            // rbGrupoCultural
            // 
            rbGrupoCultural.AutoSize = true;
            rbGrupoCultural.Font = new Font("Century Gothic", 18F);
            rbGrupoCultural.Location = new Point(344, 824);
            rbGrupoCultural.Name = "rbGrupoCultural";
            rbGrupoCultural.Size = new Size(206, 34);
            rbGrupoCultural.TabIndex = 18;
            rbGrupoCultural.TabStop = true;
            rbGrupoCultural.Text = "Grupo Cultural";
            rbGrupoCultural.UseVisualStyleBackColor = true;
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Font = new Font("Century Gothic", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label13.Location = new Point(49, 565);
            label13.Name = "label13";
            label13.Size = new Size(114, 30);
            label13.TabIndex = 44;
            label13.Text = "Atendió:";
            // 
            // txtAtendio
            // 
            txtAtendio.Font = new Font("Century Gothic", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtAtendio.Location = new Point(169, 562);
            txtAtendio.Name = "txtAtendio";
            txtAtendio.Size = new Size(374, 37);
            txtAtendio.TabIndex = 43;
            // 
            // Principal
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1137, 728);
            Controls.Add(label13);
            Controls.Add(txtAtendio);
            Controls.Add(btnEditar);
            Controls.Add(btnVaciarLocker);
            Controls.Add(label11);
            Controls.Add(label12);
            Controls.Add(label10);
            Controls.Add(cbPrecio);
            Controls.Add(cbCarrera);
            Controls.Add(lblCarrera);
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
            Controls.Add(txtBusquedaNombre);
            Controls.Add(btnBuscar);
            Controls.Add(btnLimpiarBusqueda);
            MainMenuStrip = menuStrip1;
            Name = "Principal";
            Text = "Bienvenido";
            Load += Principal_Load_1;
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
        private TextBox txtBusquedaNombre;
        private Button btnBuscar;
        private Button btnLimpiarBusqueda;
        private Label lblCarrera;
        private ComboBox cbCarrera;
        private ComboBox cbPrecio;
        private Label label10;
        private Label label11;
        private Label label12;
        private Button btnVaciarLocker;
        private Button btnEditar;
        private RadioButton rbGrupoAcademico;
        private RadioButton rbGrupoCultural;
        private Label label13;
        private TextBox txtAtendio;
    }
}