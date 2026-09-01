using System;
using System.IO;
using System.Data.SQLite;

namespace Gestion_Lockers
{
    public class DBConnection
    {
        private static readonly string _rutaDB = ObtenerRuta();

        private static string ObtenerRuta()
        {
            // Busca la BD en la carpeta Data/ relativa al ejecutable.
            // Funciona tanto en desarrollo (bin/Debug) como en producción (publish/).
            string carpetaEjecutable = AppDomain.CurrentDomain.BaseDirectory;
            string rutaDB = Path.Combine(carpetaEjecutable, "Data", "LockersV2.0.db");

            if (!File.Exists(rutaDB))
            {
                throw new FileNotFoundException(
                    $"No se encontró la base de datos en:\n{rutaDB}\n\n" +
                    "Verifica que el archivo LockersV2.0.db esté en la carpeta Data/ " +
                    "junto al ejecutable.",
                    rutaDB);
            }

            return $"Data Source={rutaDB};Version=3;";
        }

        public static SQLiteConnection GetConnection()
        {
            var conn = new SQLiteConnection(_rutaDB);
            conn.Open();
            return conn;
        }
    }
}