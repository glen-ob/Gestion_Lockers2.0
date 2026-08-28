using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Gestion_Lockers
{
    public class Diccionario
    {
        public readonly Dictionary<string, string> estadosLockers = new Dictionary<string, string>();

        // Exponer lectura si lo necesitas desde fuera
        public IReadOnlyDictionary<string, string> EstadosLockers => estadosLockers;

        public void CargarEstados()
        {
            estadosLockers.Clear();

            try
            {
                using (var conn = DBConnection.GetConnection())
                using (var cmd = new SQLiteCommand("SELECT id_locker, estado FROM lockers", conn))
                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        string id = dr["id_locker"].ToString();
                        string estado = dr["estado"].ToString();

                        if (!estadosLockers.ContainsKey(id))
                            estadosLockers.Add(id, estado);
                        else
                            estadosLockers[id] = estado;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error al cargar estados", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
