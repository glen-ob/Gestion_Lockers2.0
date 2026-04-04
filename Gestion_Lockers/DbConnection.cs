using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data.SQLite;

public class DBConnection
{
    private static string ruta = "Data Source=D:\\LockersDB\\LockersDBPG.db;Version=3;";

    public static SQLiteConnection GetConnection()
    {
        SQLiteConnection conn = new SQLiteConnection(ruta);
        conn.Open();
        return conn;
    }
}

