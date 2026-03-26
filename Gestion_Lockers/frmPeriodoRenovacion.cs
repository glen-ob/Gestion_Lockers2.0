using System;
using System.Data.SQLite;
using System.Windows.Forms;

namespace Gestion_Lockers
{
    public partial class frmPeriodoRenovacion : Form
    {
        public frmPeriodoRenovacion()
        {
            InitializeComponent();
            button1.Click += BtnIniciar_Click;
            button2.Click += (s, e) => Close();

            // El picker no debe permitir fechas pasadas
            dateTimePicker1.MinDate = DateTime.Today.AddDays(1);
            dateTimePicker1.Value = DateTime.Today.AddDays(1);
        }

        private void BtnIniciar_Click(object? sender, EventArgs e)
        {
            DateTime fechaFin = dateTimePicker1.Value.Date;

            // Validar que la fecha fin sea futura
            if (fechaFin <= DateTime.Today)
            {
                MessageBox.Show("La fecha de fin debe ser posterior a hoy.",
                    "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Advertir si ya existe un periodo activo (no procesado)
            try
            {
                using var connCheck = DBConnection.GetConnection();
                using var cmdCheck = new SQLiteCommand(@"
                    SELECT COUNT(*) FROM Renovacion
                    WHERE (procesado IS NULL OR procesado = 0)
                      AND date(fecha_fin) >= date('now');", connCheck);
                int activos = Convert.ToInt32(cmdCheck.ExecuteScalar());
                if (activos > 0)
                {
                    var dr = MessageBox.Show(
                        "Ya existe un periodo de renovación activo.\n¿Desea crear uno nuevo de todas formas?",
                        "Periodo activo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (dr != DialogResult.Yes) return;
                }
            }
            catch { /* no bloquear si falla la verificación previa */ }

            try
            {
                using var conn = DBConnection.GetConnection();
                using var tran = conn.BeginTransaction();

                // Insertar periodo — fecha guardada en formato YYYY-MM-DD (compatible con date() de SQLite)
                using (var ins = new SQLiteCommand(@"
                    INSERT INTO Renovacion (fecha_inicio, fecha_fin, id_usu_renovacion, procesado)
                    VALUES (date('now'), @fin, NULL, 0);", conn, tran))
                {
                    ins.Parameters.AddWithValue("@fin", fechaFin.ToString("yyyy-MM-dd"));
                    ins.ExecuteNonQuery();
                }

                // Marcar lockers con asignación activa como "Renovacion"
                using (var upd = new SQLiteCommand(@"
                    UPDATE lockers SET estado = 'Renovacion'
                    WHERE id_locker IN (SELECT id_locker FROM asignaciones WHERE activa = 1);",
                    conn, tran))
                    upd.ExecuteNonQuery();

                tran.Commit();

                MessageBox.Show(
                    $"Periodo de renovación iniciado.\nFecha límite: {fechaFin:dd/MM/yyyy}",
                    "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al iniciar el periodo de renovación: {ex.Message}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}