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
            alumnosToolStripMenuItem = new ToolStripMenuItem();
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
            label2 = new Label();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            txtMatricula = new TextBox();
            txtTelefono = new TextBox();
            TXTNombre = new TextBox();
            btnAsignar = new Button();
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
            label13 = new Label();
            txtAtendio = new TextBox();
            dataGridView1 = new DataGridView();
            rbGrupoAcademico = new RadioButton();
            rbGrupoCultural = new RadioButton();
            pictureBox1 = new PictureBox();
            pictureBox2 = new PictureBox();
            pictureBox3 = new PictureBox();
            label7 = new Label();
            menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).BeginInit();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.BackColor = Color.MidnightBlue;
            menuStrip1.Dock = DockStyle.None;
            menuStrip1.Font = new Font("Century Gothic", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            menuStrip1.ImageScalingSize = new Size(20, 20);
            menuStrip1.Items.AddRange(new ToolStripItem[] { mapaToolStripMenuItem, alumnosToolStripMenuItem, usuariosToolStripMenuItem, funcionalidadesToolStripMenuItem });
            menuStrip1.LayoutStyle = ToolStripLayoutStyle.VerticalStackWithOverflow;
            menuStrip1.Location = new Point(1072, 9);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Padding = new Padding(7, 3, 0, 3);
            menuStrip1.Size = new Size(279, 196);
            menuStrip1.TabIndex = 0;
            menuStrip1.Text = "menuStrip1";
            // 
            // mapaToolStripMenuItem
            // 
            mapaToolStripMenuItem.ForeColor = Color.White;
            mapaToolStripMenuItem.Name = "mapaToolStripMenuItem";
            mapaToolStripMenuItem.Size = new Size(271, 41);
            mapaToolStripMenuItem.Text = "Mapa";
            // 
            // alumnosToolStripMenuItem
            // 
            alumnosToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { renovarToolStripMenuItem, ingresarToolStripMenuItem, actualizarToolStripMenuItem1 });
            alumnosToolStripMenuItem.ForeColor = SystemColors.ButtonHighlight;
            alumnosToolStripMenuItem.Name = "alumnosToolStripMenuItem";
            alumnosToolStripMenuItem.Size = new Size(271, 41);
            alumnosToolStripMenuItem.Text = "Alumnos";
            // 
            // renovarToolStripMenuItem
            // 
            renovarToolStripMenuItem.BackColor = Color.MidnightBlue;
            renovarToolStripMenuItem.ForeColor = SystemColors.ButtonHighlight;
            renovarToolStripMenuItem.Name = "renovarToolStripMenuItem";
            renovarToolStripMenuItem.Size = new Size(251, 42);
            renovarToolStripMenuItem.Text = "Renovar";
            renovarToolStripMenuItem.Click += renovarToolStripMenuItem_Click;
            // 
            // ingresarToolStripMenuItem
            // 
            ingresarToolStripMenuItem.BackColor = Color.MidnightBlue;
            ingresarToolStripMenuItem.ForeColor = SystemColors.ButtonHighlight;
            ingresarToolStripMenuItem.Name = "ingresarToolStripMenuItem";
            ingresarToolStripMenuItem.Size = new Size(251, 42);
            ingresarToolStripMenuItem.Text = "Ingresar";
            ingresarToolStripMenuItem.Click += ingresarToolStripMenuItem_Click;
            // 
            // actualizarToolStripMenuItem1
            // 
            actualizarToolStripMenuItem1.BackColor = Color.MidnightBlue;
            actualizarToolStripMenuItem1.ForeColor = SystemColors.ButtonHighlight;
            actualizarToolStripMenuItem1.Name = "actualizarToolStripMenuItem1";
            actualizarToolStripMenuItem1.Size = new Size(251, 42);
            actualizarToolStripMenuItem1.Text = "Actualizar";
            actualizarToolStripMenuItem1.Click += actualizarToolStripMenuItem1_Click;
            // 
            // usuariosToolStripMenuItem
            // 
            usuariosToolStripMenuItem.BackColor = Color.MidnightBlue;
            usuariosToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { ingresarToolStripMenuItem1, eliminarToolStripMenuItem });
            usuariosToolStripMenuItem.ForeColor = SystemColors.ButtonHighlight;
            usuariosToolStripMenuItem.Name = "usuariosToolStripMenuItem";
            usuariosToolStripMenuItem.Size = new Size(271, 41);
            usuariosToolStripMenuItem.Text = "Usuarios";
            // 
            // ingresarToolStripMenuItem1
            // 
            ingresarToolStripMenuItem1.BackColor = Color.MidnightBlue;
            ingresarToolStripMenuItem1.ForeColor = SystemColors.ButtonHighlight;
            ingresarToolStripMenuItem1.Name = "ingresarToolStripMenuItem1";
            ingresarToolStripMenuItem1.Size = new Size(375, 42);
            ingresarToolStripMenuItem1.Text = "Ingresar";
            ingresarToolStripMenuItem1.Click += ingresarToolStripMenuItem1_Click;
            // 
            // eliminarToolStripMenuItem
            // 
            eliminarToolStripMenuItem.BackColor = Color.MidnightBlue;
            eliminarToolStripMenuItem.ForeColor = SystemColors.ButtonHighlight;
            eliminarToolStripMenuItem.Name = "eliminarToolStripMenuItem";
            eliminarToolStripMenuItem.Size = new Size(375, 42);
            eliminarToolStripMenuItem.Text = "Eliminar/Actualizar";
            eliminarToolStripMenuItem.Click += eliminarToolStripMenuItem_Click;
            // 
            // funcionalidadesToolStripMenuItem
            // 
            funcionalidadesToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { periodoDeRenovacionToolStripMenuItem, cancelarRenovacionToolStripMenuItem, reportesToolStripMenuItem });
            funcionalidadesToolStripMenuItem.ForeColor = SystemColors.ButtonHighlight;
            funcionalidadesToolStripMenuItem.Name = "funcionalidadesToolStripMenuItem";
            funcionalidadesToolStripMenuItem.Size = new Size(271, 41);
            funcionalidadesToolStripMenuItem.Text = "Funcionalidades";
            funcionalidadesToolStripMenuItem.Click += funcionalidadesToolStripMenuItem_Click;
            // 
            // periodoDeRenovacionToolStripMenuItem
            // 
            periodoDeRenovacionToolStripMenuItem.BackColor = Color.MidnightBlue;
            periodoDeRenovacionToolStripMenuItem.ForeColor = SystemColors.ButtonHighlight;
            periodoDeRenovacionToolStripMenuItem.Name = "periodoDeRenovacionToolStripMenuItem";
            periodoDeRenovacionToolStripMenuItem.Size = new Size(445, 42);
            periodoDeRenovacionToolStripMenuItem.Text = "Periodo de renovacion";
            periodoDeRenovacionToolStripMenuItem.Click += periodoDeRenovacionToolStripMenuItem_Click;
            // 
            // cancelarRenovacionToolStripMenuItem
            // 
            cancelarRenovacionToolStripMenuItem.BackColor = Color.MidnightBlue;
            cancelarRenovacionToolStripMenuItem.ForeColor = SystemColors.ButtonHighlight;
            cancelarRenovacionToolStripMenuItem.Name = "cancelarRenovacionToolStripMenuItem";
            cancelarRenovacionToolStripMenuItem.Size = new Size(445, 42);
            cancelarRenovacionToolStripMenuItem.Text = "Cancelar Renovacion";
            cancelarRenovacionToolStripMenuItem.Click += cancelarRenovacionToolStripMenuItem_Click;
            // 
            // reportesToolStripMenuItem
            // 
            reportesToolStripMenuItem.BackColor = Color.MidnightBlue;
            reportesToolStripMenuItem.ForeColor = SystemColors.ButtonHighlight;
            reportesToolStripMenuItem.Name = "reportesToolStripMenuItem";
            reportesToolStripMenuItem.Size = new Size(445, 42);
            reportesToolStripMenuItem.Text = "Reportes";
            reportesToolStripMenuItem.Click += reportesToolStripMenuItem_Click;
            // 
            // label1
            // 
            label1.BackColor = Color.MidnightBlue;
            label1.Font = new Font("Century Gothic", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.ForeColor = SystemColors.ButtonHighlight;
            label1.Location = new Point(1072, 326);
            label1.Name = "label1";
            label1.Size = new Size(279, 37);
            label1.TabIndex = 1;
            label1.Text = "Hoy es:";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblFechaRenovacion
            // 
            lblFechaRenovacion.AutoSize = true;
            lblFechaRenovacion.Font = new Font("Century Gothic", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblFechaRenovacion.Location = new Point(443, 9);
            lblFechaRenovacion.Name = "lblFechaRenovacion";
            lblFechaRenovacion.Size = new Size(123, 37);
            lblFechaRenovacion.TabIndex = 2;
            lblFechaRenovacion.Text = "--/--/----";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Century Gothic", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.Location = new Point(12, 9);
            label3.Name = "label3";
            label3.Size = new Size(410, 37);
            label3.TabIndex = 3;
            label3.Text = "Fin Periodo de renovacion:";
            // 
            // lblFecha
            // 
            lblFecha.BackColor = Color.MidnightBlue;
            lblFecha.Font = new Font("Century Gothic", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblFecha.ForeColor = SystemColors.ButtonHighlight;
            lblFecha.Location = new Point(1072, 363);
            lblFecha.Name = "lblFecha";
            lblFecha.Size = new Size(279, 37);
            lblFecha.TabIndex = 4;
            lblFecha.Text = "Fecha";
            lblFecha.TextAlign = ContentAlignment.MiddleCenter;
            lblFecha.Click += lblFecha_Click;
            // 
            // cbUbicacion
            // 
            cbUbicacion.Font = new Font("Century Gothic", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            cbUbicacion.FormattingEnabled = true;
            cbUbicacion.Location = new Point(693, 135);
            cbUbicacion.Margin = new Padding(3, 4, 3, 4);
            cbUbicacion.Name = "cbUbicacion";
            cbUbicacion.Size = new Size(305, 45);
            cbUbicacion.TabIndex = 8;
            // 
            // label2
            // 
            label2.Font = new Font("Century Gothic", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.Location = new Point(693, 94);
            label2.Name = "label2";
            label2.Size = new Size(305, 37);
            label2.TabIndex = 9;
            label2.Text = "Area:";
            label2.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Century Gothic", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label4.Location = new Point(12, 516);
            label4.Name = "label4";
            label4.Size = new Size(149, 37);
            label4.TabIndex = 16;
            label4.Text = "Telefóno:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Century Gothic", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label5.Location = new Point(12, 460);
            label5.Name = "label5";
            label5.Size = new Size(163, 37);
            label5.TabIndex = 15;
            label5.Text = "Matricula:";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Century Gothic", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label6.Location = new Point(484, 460);
            label6.Name = "label6";
            label6.Size = new Size(143, 37);
            label6.TabIndex = 14;
            label6.Text = "Nombre:";
            // 
            // txtMatricula
            // 
            txtMatricula.Font = new Font("Century Gothic", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtMatricula.Location = new Point(188, 460);
            txtMatricula.Margin = new Padding(3, 4, 3, 4);
            txtMatricula.Name = "txtMatricula";
            txtMatricula.Size = new Size(282, 44);
            txtMatricula.TabIndex = 13;
            // 
            // txtTelefono
            // 
            txtTelefono.Font = new Font("Century Gothic", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtTelefono.Location = new Point(187, 517);
            txtTelefono.Margin = new Padding(3, 4, 3, 4);
            txtTelefono.Name = "txtTelefono";
            txtTelefono.Size = new Size(282, 44);
            txtTelefono.TabIndex = 12;
            // 
            // TXTNombre
            // 
            TXTNombre.Font = new Font("Century Gothic", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            TXTNombre.Location = new Point(633, 460);
            TXTNombre.Margin = new Padding(3, 4, 3, 4);
            TXTNombre.Name = "TXTNombre";
            TXTNombre.Size = new Size(365, 44);
            TXTNombre.TabIndex = 11;
            // 
            // btnAsignar
            // 
            btnAsignar.Font = new Font("Century Gothic", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnAsignar.Location = new Point(580, 738);
            btnAsignar.Margin = new Padding(3, 4, 3, 4);
            btnAsignar.Name = "btnAsignar";
            btnAsignar.Size = new Size(206, 77);
            btnAsignar.TabIndex = 19;
            btnAsignar.Text = "Asignar";
            btnAsignar.UseVisualStyleBackColor = true;
            // 
            // btnRenovar
            // 
            btnRenovar.Font = new Font("Century Gothic", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnRenovar.Location = new Point(792, 739);
            btnRenovar.Margin = new Padding(3, 4, 3, 4);
            btnRenovar.Name = "btnRenovar";
            btnRenovar.Size = new Size(206, 77);
            btnRenovar.TabIndex = 26;
            btnRenovar.Text = "Renovar";
            btnRenovar.UseVisualStyleBackColor = true;
            btnRenovar.Click += btnRenovar_Click_1;
            // 
            // txtBusquedaNombre
            // 
            txtBusquedaNombre.Font = new Font("Century Gothic", 13F);
            txtBusquedaNombre.Location = new Point(12, 345);
            txtBusquedaNombre.Margin = new Padding(3, 4, 3, 4);
            txtBusquedaNombre.Name = "txtBusquedaNombre";
            txtBusquedaNombre.PlaceholderText = "Buscar por #locker o nombre de estudiante";
            txtBusquedaNombre.Size = new Size(651, 34);
            txtBusquedaNombre.TabIndex = 30;
            // 
            // btnBuscar
            // 
            btnBuscar.Font = new Font("Century Gothic", 12F);
            btnBuscar.Location = new Point(12, 387);
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
            btnLimpiarBusqueda.Location = new Point(260, 387);
            btnLimpiarBusqueda.Margin = new Padding(3, 4, 3, 4);
            btnLimpiarBusqueda.Name = "btnLimpiarBusqueda";
            btnLimpiarBusqueda.Size = new Size(209, 48);
            btnLimpiarBusqueda.TabIndex = 32;
            btnLimpiarBusqueda.Text = "Limpiar";
            btnLimpiarBusqueda.UseVisualStyleBackColor = true;
            // 
            // lblCarrera
            // 
            lblCarrera.AutoSize = true;
            lblCarrera.Font = new Font("Century Gothic", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblCarrera.Location = new Point(492, 516);
            lblCarrera.Name = "lblCarrera";
            lblCarrera.Size = new Size(135, 37);
            lblCarrera.TabIndex = 33;
            lblCarrera.Text = "Carrera:";
            // 
            // cbCarrera
            // 
            cbCarrera.Font = new Font("Century Gothic", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            cbCarrera.FormattingEnabled = true;
            cbCarrera.Location = new Point(633, 516);
            cbCarrera.Margin = new Padding(3, 4, 3, 4);
            cbCarrera.Name = "cbCarrera";
            cbCarrera.Size = new Size(365, 45);
            cbCarrera.TabIndex = 34;
            // 
            // cbPrecio
            // 
            cbPrecio.Font = new Font("Century Gothic", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            cbPrecio.FormattingEnabled = true;
            cbPrecio.Location = new Point(693, 246);
            cbPrecio.Margin = new Padding(3, 4, 3, 4);
            cbPrecio.Name = "cbPrecio";
            cbPrecio.Size = new Size(305, 45);
            cbPrecio.TabIndex = 35;
            // 
            // label10
            // 
            label10.Font = new Font("Century Gothic", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label10.Location = new Point(693, 205);
            label10.Name = "label10";
            label10.Size = new Size(305, 37);
            label10.TabIndex = 36;
            label10.Text = "Precio:";
            label10.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label11
            // 
            label11.BackColor = Color.MidnightBlue;
            label11.Font = new Font("Century Gothic", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label11.ForeColor = SystemColors.ButtonHighlight;
            label11.Location = new Point(1072, 258);
            label11.Name = "label11";
            label11.Size = new Size(279, 37);
            label11.TabIndex = 38;
            label11.Text = "Usuario";
            label11.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label12
            // 
            label12.BackColor = Color.MidnightBlue;
            label12.Font = new Font("Century Gothic", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label12.ForeColor = SystemColors.ButtonHighlight;
            label12.Location = new Point(1072, 221);
            label12.Name = "label12";
            label12.Size = new Size(279, 37);
            label12.TabIndex = 37;
            label12.Text = "¡Hola!";
            label12.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // btnVaciarLocker
            // 
            btnVaciarLocker.Font = new Font("Century Gothic", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnVaciarLocker.Location = new Point(15, 739);
            btnVaciarLocker.Margin = new Padding(3, 4, 3, 4);
            btnVaciarLocker.Name = "btnVaciarLocker";
            btnVaciarLocker.Size = new Size(206, 77);
            btnVaciarLocker.TabIndex = 39;
            btnVaciarLocker.Text = "Vaciar";
            btnVaciarLocker.UseVisualStyleBackColor = true;
            btnVaciarLocker.Click += btnVaciarLocker_Click;
            // 
            // btnEditar
            // 
            btnEditar.Font = new Font("Century Gothic", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnEditar.Location = new Point(227, 738);
            btnEditar.Margin = new Padding(3, 4, 3, 4);
            btnEditar.Name = "btnEditar";
            btnEditar.Size = new Size(206, 77);
            btnEditar.TabIndex = 40;
            btnEditar.Text = "Actualizar";
            btnEditar.UseVisualStyleBackColor = true;
            btnEditar.Click += btnEditar_Click;
            // 
            // label13
            // 
            label13.Font = new Font("Century Gothic", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label13.Location = new Point(316, 610);
            label13.Name = "label13";
            label13.Size = new Size(384, 37);
            label13.TabIndex = 44;
            label13.Text = "Atendió:";
            label13.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // txtAtendio
            // 
            txtAtendio.Font = new Font("Century Gothic", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtAtendio.Location = new Point(316, 651);
            txtAtendio.Margin = new Padding(3, 4, 3, 4);
            txtAtendio.Name = "txtAtendio";
            txtAtendio.Size = new Size(384, 44);
            txtAtendio.TabIndex = 43;
            // 
            // dataGridView1
            // 
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridView1.AllowUserToResizeColumns = false;
            dataGridView1.AllowUserToResizeRows = false;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
            dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.DisplayedCells;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(12, 60);
            dataGridView1.Margin = new Padding(3, 4, 3, 4);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.ReadOnly = true;
            dataGridView1.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.AutoSizeToFirstHeader;
            dataGridView1.Size = new Size(651, 277);
            dataGridView1.TabIndex = 7;
            // 
            // rbGrupoAcademico
            // 
            rbGrupoAcademico.Anchor = AnchorStyles.Bottom;
            rbGrupoAcademico.AutoCheck = false;
            rbGrupoAcademico.BackColor = SystemColors.Control;
            rbGrupoAcademico.Enabled = false;
            rbGrupoAcademico.Location = new Point(149, 823);
            rbGrupoAcademico.Name = "rbGrupoAcademico";
            rbGrupoAcademico.Size = new Size(1, 1);
            rbGrupoAcademico.TabIndex = 46;
            rbGrupoAcademico.Text = "radioButton2";
            rbGrupoAcademico.UseVisualStyleBackColor = false;
            rbGrupoAcademico.Visible = false;
            // 
            // rbGrupoCultural
            // 
            rbGrupoCultural.Anchor = AnchorStyles.Bottom;
            rbGrupoCultural.AutoCheck = false;
            rbGrupoCultural.BackColor = SystemColors.Control;
            rbGrupoCultural.Enabled = false;
            rbGrupoCultural.Location = new Point(272, 823);
            rbGrupoCultural.Name = "rbGrupoCultural";
            rbGrupoCultural.Size = new Size(1, 1);
            rbGrupoCultural.TabIndex = 49;
            rbGrupoCultural.Text = "radioButton4";
            rbGrupoCultural.UseVisualStyleBackColor = false;
            rbGrupoCultural.Visible = false;
            // 
            // pictureBox1
            // 
            pictureBox1.BackColor = Color.MidnightBlue;
            pictureBox1.Location = new Point(1026, -3);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(416, 1063);
            pictureBox1.TabIndex = 50;
            pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            pictureBox2.BackColor = Color.MidnightBlue;
            pictureBox2.BackgroundImageLayout = ImageLayout.None;
            pictureBox2.Image = Properties.Resources.sefcfm_blanco1;
            pictureBox2.Location = new Point(1044, 438);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(333, 330);
            pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox2.TabIndex = 51;
            pictureBox2.TabStop = false;
            pictureBox2.Click += pictureBox2_Click;
            // 
            // pictureBox3
            // 
            pictureBox3.BackColor = Color.MidnightBlue;
            pictureBox3.Location = new Point(12, 60);
            pictureBox3.Name = "pictureBox3";
            pictureBox3.Size = new Size(651, 277);
            pictureBox3.TabIndex = 52;
            pictureBox3.TabStop = false;
            // 
            // label7
            // 
            label7.BackColor = Color.MidnightBlue;
            label7.Font = new Font("Century Gothic", 18F, FontStyle.Italic, GraphicsUnit.Point, 0);
            label7.ForeColor = SystemColors.ButtonHighlight;
            label7.Location = new Point(15, 60);
            label7.Name = "label7";
            label7.Size = new Size(648, 277);
            label7.TabIndex = 53;
            label7.Text = "Selecciona el área para ver los lockers :)";
            label7.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // Principal
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Control;
            ClientSize = new Size(1397, 859);
            Controls.Add(pictureBox2);
            Controls.Add(rbGrupoCultural);
            Controls.Add(rbGrupoAcademico);
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
            Controls.Add(btnAsignar);
            Controls.Add(label4);
            Controls.Add(label5);
            Controls.Add(label6);
            Controls.Add(txtMatricula);
            Controls.Add(txtTelefono);
            Controls.Add(TXTNombre);
            Controls.Add(label2);
            Controls.Add(cbUbicacion);
            Controls.Add(lblFecha);
            Controls.Add(label3);
            Controls.Add(lblFechaRenovacion);
            Controls.Add(label1);
            Controls.Add(menuStrip1);
            Controls.Add(txtBusquedaNombre);
            Controls.Add(btnBuscar);
            Controls.Add(btnLimpiarBusqueda);
            Controls.Add(pictureBox1);
            Controls.Add(dataGridView1);
            Controls.Add(label7);
            Controls.Add(pictureBox3);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MainMenuStrip = menuStrip1;
            Margin = new Padding(3, 4, 3, 4);
            Name = "Principal";
            Text = "Bienvenido";
            Load += Principal_Load_1;
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip menuStrip1;
        private ToolStripMenuItem mapaToolStripMenuItem;
        private ToolStripMenuItem alumnosToolStripMenuItem;
        private ToolStripMenuItem usuariosToolStripMenuItem;
        private ToolStripMenuItem funcionalidadesToolStripMenuItem;
        private ToolStripMenuItem ingresarToolStripMenuItem;
        private ToolStripMenuItem renovarToolStripMenuItem;
        private ToolStripMenuItem actualizarToolStripMenuItem1;
        private ToolStripMenuItem ingresarToolStripMenuItem1;
        private ToolStripMenuItem eliminarToolStripMenuItem;
        private Label label1;
        private Label lblFechaRenovacion;
        private Label label3;
        private Label lblFecha;
        private ComboBox cbUbicacion;
        private Label label2;
        private Label label4;
        private Label label5;
        private Label label6;
        private TextBox txtMatricula;
        private TextBox txtTelefono;
        private TextBox TXTNombre;
        private Button btnAsignar;
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
        private Label label13;
        private TextBox txtAtendio;
        private DataGridView dataGridView1;
        private RadioButton rbGrupoAcademico;
        private RadioButton rbGrupoCultural;
        private ToolStripMenuItem periodoDeRenovacionToolStripMenuItem;
        private ToolStripMenuItem cancelarRenovacionToolStripMenuItem;
        private ToolStripMenuItem reportesToolStripMenuItem;
        private PictureBox pictureBox1;
        private PictureBox pictureBox2;
        private PictureBox pictureBox3;
        private Label label7;
    }
}