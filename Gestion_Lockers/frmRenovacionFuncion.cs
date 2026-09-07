using System;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Windows.Forms;
using System.Globalization;

namespace Gestion_Lockers
{
    public partial class frmRenovacionFuncion : Form
    {
        private DataGridView dgv;
        private Button btnEditar;
        private DataTable table;
        private readonly string tableName;
        private TextBox txtMatricula;
        private Button btnContinuar;
        private Label label1;
        private Button btnCancelar;
        private string? alumnoId = string.Empty;
        private Principal? _ownerPrincipal;


        public frmRenovacionFuncion(DataTable dt, string tableName)
        {
            this.table = dt ?? throw new ArgumentNullException(nameof(dt));
            this.tableName = tableName ?? "asignaciones";

            Text = "Renovación - Resultados";
            Size = new Size(800, 400);
            StartPosition = FormStartPosition.CenterParent;

            dgv = new DataGridView { Dock = DockStyle.Top, Height = 300, ReadOnly = true, SelectionMode = DataGridViewSelectionMode.FullRowSelect, AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill };
            btnEditar = new Button { Text = "Editar fila seleccionada", Dock = DockStyle.Bottom, Height = 40 };

            Controls.Add(dgv);
            Controls.Add(btnEditar);

            dgv.DataSource = table;

            btnEditar.Click += BtnEditar_Click;
        }

        public frmRenovacionFuncion()
        {
            InitializeComponent();
        }

        public frmRenovacionFuncion(Principal owner) : this()
        {
            _ownerPrincipal = owner;
        }

        private void InitializeComponent()
        {
            txtMatricula = new TextBox();
            btnContinuar = new Button();
            label1 = new Label();
            btnCancelar = new Button();
            SuspendLayout();
            // 
            // txtMatricula
            // 
            txtMatricula.Font = new Font("Century Gothic", 12F);
            txtMatricula.Location = new Point(47, 50);
            txtMatricula.Name = "txtMatricula";
            txtMatricula.Size = new Size(260, 32);
            txtMatricula.TabIndex = 1;
            // 
            // btnContinuar
            // 
            btnContinuar.Font = new Font("Century Gothic", 12F);
            btnContinuar.Location = new Point(47, 90);
            btnContinuar.Name = "btnContinuar";
            btnContinuar.Size = new Size(120, 35);
            btnContinuar.TabIndex = 2;
            btnContinuar.Text = "Continuar";
            btnContinuar.Click += BtnContinuar_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Century Gothic", 12F);
            label1.Location = new Point(43, 18);
            label1.Name = "label1";
            label1.Size = new Size(186, 23);
            label1.TabIndex = 0;
            label1.Text = "Ingrese matrícula:";
            // 
            // btnCancelar
            // 
            btnCancelar.Font = new Font("Century Gothic", 12F);
            btnCancelar.Location = new Point(173, 90);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(134, 35);
            btnCancelar.TabIndex = 3;
            btnCancelar.Text = "Cancelar";
            btnCancelar.Click += btnCancelar_Click;
            // 
            // frmRenovacionFuncion
            // 
            ClientSize = new Size(352, 145);
            Controls.Add(label1);
            Controls.Add(txtMatricula);
            Controls.Add(btnContinuar);
            Controls.Add(btnCancelar);
            Name = "frmRenovacionFuncion";
            Text = "Renovación por matrícula";
            ResumeLayout(false);
            PerformLayout();
        }

        private void BtnEditar_Click(object? sender, EventArgs e)
        {
            if (dgv.SelectedRows.Count == 0)
            {
                MessageBox.Show("Selecciona una fila para editar.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var row = ((DataRowView)dgv.SelectedRows[0].DataBoundItem).Row;
            var editor = new frmEditarRegistro(tableName, row, table);
            if (editor.ShowDialog() == DialogResult.OK)
            {
                // recargar la fila desde BD para mostrar cambios
                try
                {
                    using (var conn = DBConnection.GetConnection())
                    using (var cmd = new SQLiteCommand($"SELECT * FROM {tableName} WHERE matricula = @matricula;", conn))
                    {
                        cmd.Parameters.AddWithValue("@matricula", row["matricula"].ToString());
                        using (var da = new SQLiteDataAdapter(cmd))
                        {
                            var dt = new DataTable();
                            da.Fill(dt);
                            table.Clear();
                            foreach (DataRow r in dt.Rows) table.ImportRow(r);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error recargando datos: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void BtnContinuar_Click(object? sender, EventArgs e)
        {
            string matricula = txtMatricula.Text.Trim();
            if (string.IsNullOrEmpty(matricula))
            {
                MessageBox.Show("Ingrese la matrícula.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMatricula.Focus();
                return;
            }

            try
            {
                // 1) Obtener id_alumno desde la matricula
                using (var conn = DBConnection.GetConnection())
                using (var cmd = new SQLiteCommand("SELECT id_alumno, nombre, telefono FROM alumnos WHERE matricula = @mat LIMIT 1;", conn))
                {
                    cmd.Parameters.AddWithValue("@mat", matricula);
                    using var r = cmd.ExecuteReader();
                    if (r.Read())
                    {
                        alumnoId = r["id_alumno"]?.ToString();
                    }
                    else
                    {
                        MessageBox.Show("No se encontró ningún alumno con esa matrícula.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                }

                if (string.IsNullOrEmpty(alumnoId))
                {
                    MessageBox.Show("No se pudo resolver el alumno.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // 2) Obtener asignaciones activas del alumno que están marcadas para renovación (o todas activas si lo prefieres)
                var dt = new DataTable();
                using (var conn = DBConnection.GetConnection())
                using (var da = new SQLiteDataAdapter(@"
            SELECT a.id_locker AS id_locker, l.estado AS estado, a.fecha_inicio, al.nombre AS nombre, al.telefono AS telefono
            FROM asignaciones a
            JOIN lockers l ON a.id_locker = l.id_locker
            JOIN alumnos al ON a.id_alumno = al.id_alumno
            WHERE a.id_alumno = @id_alumno
              AND a.activa = 1
              AND (l.estado LIKE '%Renov%' COLLATE NOCASE OR l.estado = '2' OR l.estado = 'Renovacion')
            ORDER BY a.id_locker ASC;", conn))
                {
                    da.SelectCommand.Parameters.AddWithValue("@id_alumno", alumnoId);
                    da.Fill(dt);
                }

                if (dt.Rows.Count == 0)
                {
                    MessageBox.Show("El alumno no tiene lockers marcados para renovación.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                // 3) Si hay una sola asignación -> abrir frmDatosRenovacion directamente (similar a Principal.BtnRenovar_Click)
                if (dt.Rows.Count == 1)
                {
                    var row = dt.Rows[0];
                    int lockerId = Convert.ToInt32(row["id_locker"]);
                    string nombre = row["nombre"]?.ToString() ?? string.Empty;
                    string telefono = row["telefono"]?.ToString() ?? string.Empty;
                    // traer el id de carrera del alumno desde la tabla alumnos
                    int carreraId = 0;
                    using (var conn = DBConnection.GetConnection())
                    using (var cmd = new SQLiteCommand("SELECT id_carrera FROM alumnos WHERE id_alumno = @id_alumno LIMIT 1;", conn))
                    {
                        cmd.Parameters.AddWithValue("@id_alumno", alumnoId);
                        carreraId = Convert.ToInt32(cmd.ExecuteScalar());
                    }
                    if (carreraId != 0)
                    {
                        carreraId = 0;
                    }

                    using var dlg = new frmDatosRenovacion(alumnoId, matricula, nombre, telefono, carreraId, lockerId);

                    if (dlg.ShowDialog(this) != DialogResult.OK) return;

                    // Guardar datos actualizados
                    Funciones.ActualizarDatosAlumno(alumnoId!, dlg.NombreActualizado, dlg.TelefonoActualizado, dlg.IdCarreraSeleccionada);

                    // Si se renueva manteniendo el mismo locker, ejecutar la renovación (cierra y crea nueva asignación)
                    if (dlg.MismoLocker)
                    {
                        if (Funciones.EjecutarRenovacion(alumnoId!, lockerId.ToString(), lockerId, dlg.AtendidoPor ?? string.Empty))
                        {
                            MessageBox.Show("Renovación realizada correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;
                        }
                        else
                        {
                            MessageBox.Show("Error al realizar la renovación.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                    }
                    else
                    {
                        if (_ownerPrincipal != null)
                        {
                            _ownerPrincipal.ActivateRenovationSelection(alumnoId, lockerId.ToString(), dlg.AtendidoPor ?? string.Empty);

                            this.Close();
                            return;
                        }

                        MessageBox.Show("Para cambiar de locker debe abrir esta pantalla desde la ventana principal (Menú → Renovar) para poder seleccionar el nuevo locker en el mapa.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                }

                // 4) Si hay varias asignaciones -> mostrar selector con opciones (Renovar todos / Seleccionar uno)
                using (var selector = new Form())
                {
                    selector.Text = $"Asignaciones en renovación - {matricula}";
                    selector.StartPosition = FormStartPosition.CenterParent;
                    selector.Size = new Size(600, 400);
                    selector.FormBorderStyle = FormBorderStyle.Sizable;

                    var dgvSel = new DataGridView
                    {
                        Dock = DockStyle.Top,
                        Height = 280,
                        ReadOnly = true,
                        SelectionMode = DataGridViewSelectionMode.FullRowSelect,
                        AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill,
                        DataSource = dt
                    };
                    selector.Controls.Add(dgvSel);

                    var btnPanel = new FlowLayoutPanel { Dock = DockStyle.Bottom, Height = 60, FlowDirection = FlowDirection.RightToLeft, Padding = new Padding(8) };
                    selector.Controls.Add(btnPanel);

                    var btnRenovarTodos = new Button { Text = "Renovar todos", Width = 140, Height = 36 };
                    var btnSeleccionar = new Button { Text = "Seleccionar uno", Width = 140, Height = 36 };
                    var btnCancelar = new Button { Text = "Cancelar", Width = 100, Height = 36 };

                    btnPanel.Controls.Add(btnCancelar);
                    btnPanel.Controls.Add(btnSeleccionar);
                    btnPanel.Controls.Add(btnRenovarTodos);

                    btnCancelar.Click += (_, _) => selector.DialogResult = DialogResult.Cancel;

                    // Renovar todos: iterar y ejecutar renovación manteniendo cada locker
                    btnRenovarTodos.Click += (_, _) =>
                    {
                        int success = 0, fail = 0;
                        foreach (DataRow r in dt.Rows)
                        {
                            if (!int.TryParse(r["id_locker"].ToString(), out int lid)) { fail++; continue; }
                            // Ejecutar renovacion manteniendo el mismo locker
                            if (Funciones.EjecutarRenovacion(alumnoId!, lid.ToString(), lid, string.Empty)) success++; else fail++;
                        }

                        MessageBox.Show($"Renovaciones completadas: {success}. Fallidas: {fail}.", "Resultado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        selector.DialogResult = DialogResult.OK;
                    };

                    // Seleccionar uno: abrir frmDatosRenovacion para la fila seleccionada
                    btnSeleccionar.Click += (_, _) =>
                    {
                        if (dgvSel.SelectedRows.Count == 0)
                        {
                            MessageBox.Show("Seleccione una fila primero.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }

                        var selRow = ((DataRowView)dgvSel.SelectedRows[0].DataBoundItem).Row;
                        if (!int.TryParse(selRow["id_locker"].ToString(), out int lockerSel))
                        {
                            MessageBox.Show("Id de locker inválido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }

                        string nombre = selRow["nombre"]?.ToString() ?? string.Empty;
                        string telefono = selRow["telefono"]?.ToString() ?? string.Empty;
                        // traer el id de carrera del alumno desde la tabla alumnos
                        int carreraId = 0;
                        using (var conn = DBConnection.GetConnection())
                        using (var cmd = new SQLiteCommand("SELECT id_carrera FROM alumnos WHERE id_alumno = @id_alumno LIMIT 1;", conn))
                        {
                            cmd.Parameters.AddWithValue("@id_alumno", alumnoId);
                            carreraId = Convert.ToInt32(cmd.ExecuteScalar());
                        }
                        if (carreraId != 0)
                        {
                            carreraId = 0;
                        }

                        using var dlg = new frmDatosRenovacion(alumnoId, matricula, nombre, telefono, carreraId, lockerSel);
                        if (dlg.ShowDialog(this) != DialogResult.OK) return;

                        // Actualizar datos alumno
                        Funciones.ActualizarDatosAlumno(alumnoId!, dlg.NombreActualizado, dlg.TelefonoActualizado, dlg.IdCarreraSeleccionada);

                        if (dlg.MismoLocker)
                        {
                            if (Funciones.EjecutarRenovacion(alumnoId!, lockerSel.ToString(), lockerSel, dlg.AtendidoPor ?? string.Empty))
                            {
                                MessageBox.Show("Renovación realizada correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            else
                            {
                                MessageBox.Show("Error al realizar la renovación.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                        else
                        {
                            if (_ownerPrincipal != null) //REF PRINCIPAL
                            {
                                _ownerPrincipal.ActivateRenovationSelection(alumnoId, lockerSel.ToString(), dlg.AtendidoPor ?? string.Empty);

                                this.Close();
                                return;
                            }

                            MessageBox.Show("Para reasignar a otro locker, abra la renovación desde la ventana principal para poder seleccionar el destino en el mapa.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }

                        selector.DialogResult = DialogResult.OK;
                    };

                    if (selector.ShowDialog(this) == DialogResult.OK)
                    {
                        return;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error en flujo de renovación: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}