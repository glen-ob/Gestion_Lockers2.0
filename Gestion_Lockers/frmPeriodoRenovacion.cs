using System;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Windows.Forms;

namespace Gestion_Lockers
{
    public partial class frmPeriodoRenovacion : Form
    {
        public frmPeriodoRenovacion()
        {
            InitializeComponent();

            // Asociar el evento aquí para mantener el diseñador separado
            button1.Click += Button1_Click;
            button2.Click += (s, e) => this.Close();
        }

        private void Button1_Click(object? sender, EventArgs e)
        {
            try
            {
                DateTime fechaInicio = DateTime.UtcNow;
                DateTime fechaFin = dateTimePicker1.Value.Date;

                using (var conn = DBConnection.GetConnection())
                using (var tran = conn.BeginTransaction())
                {
                    // Calcular siguiente id_renovacion
                    long nextId = 1;
                    using (var cmdId = new SQLiteCommand("SELECT COALESCE(MAX(id_renovacion), 0) + 1 FROM Renovacion;", conn, tran))
                    {
                        var obj = cmdId.ExecuteScalar();
                        nextId = Convert.ToInt64(obj);
                    }

                    // Insertar registro de renovación. id_usu_renovacion se guarda como NULL porque no hay sesión en este punto.
                    using (var ins = new SQLiteCommand("INSERT INTO Renovacion (id_renovacion, fecha_inicio, fecha_fin, id_usu_renovacion) VALUES (@id, @inicio, @fin, @user);", conn, tran))
                    {
                        ins.Parameters.AddWithValue("@id", nextId);
                        ins.Parameters.AddWithValue("@inicio", fechaInicio.ToString("o"));
                        ins.Parameters.AddWithValue("@fin", fechaFin.ToString("o"));
                        ins.Parameters.AddWithValue("@user", DBNull.Value);
                        ins.ExecuteNonQuery();
                    }

                    // Opcional: marcar lockers vinculados a asignaciones activas como '2' (estado de renovación)
                    // Ajusta el valor '2' si en tu esquema el código es distinto o prefieres otro valor/texto.
                    using (var upd = new SQLiteCommand("UPDATE lockers SET estado = 'Renovacion' WHERE id_locker IN (SELECT id_locker FROM asignaciones WHERE activa = 1);", conn, tran))
                    {
                        upd.ExecuteNonQuery();
                    }

                    tran.Commit();
                }

                MessageBox.Show("Periodo de renovación iniciado y lockers marcados correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al iniciar período de renovación: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
