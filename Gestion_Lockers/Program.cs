using System;
using System.Windows.Forms;

namespace Gestion_Lockers
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();

            try
            {
                int usuariosCount = Funciones.GetUsuariosCount();
                if (usuariosCount == 0)
                {
                    using (var frm = new frmaltausuario(initialSetup: true))
                    {
                        var dr = frm.ShowDialog();
                        if (dr != DialogResult.OK)
                        {
                            return;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error comprobando usuarios: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Pedir login antes de abrir Principal
            using (var login = new frm_Inicio())
            {
                var dr = login.ShowDialog();
                if (dr != DialogResult.OK)
                {
                    // si cancela el login, salir
                    return;
                }

                // Abrir principal pasando usuario y rol
                Application.Run(new Principal(login.UserId, login.UserRole));
            }
        }
    }
}