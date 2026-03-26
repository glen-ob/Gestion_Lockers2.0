using System;
using System.Drawing;
using System.Windows.Forms;

namespace Gestion_Lockers
{
    public class frm_Principal : Form
    {
        private Button btnMapa;
        private Button btnAlumnos;
        private Button btnAsignar;
        private Button btnRenovacion;

        public frm_Principal()
        {
            Text = "Principal";
            Size = new Size(400, 300);
            StartPosition = FormStartPosition.CenterScreen;

            btnMapa = new Button { Text = "Mapa", Location = new Point(50, 40), Size = new Size(120, 50) };
            btnAlumnos = new Button { Text = "Alumnos", Location = new Point(210, 40), Size = new Size(120, 50) };
            btnAsignar = new Button { Text = "Asignar", Location = new Point(50, 120), Size = new Size(120, 50) };
            btnRenovacion = new Button { Text = "Renovación", Location = new Point(210, 120), Size = new Size(120, 50) };

            Controls.AddRange(new Control[] { btnMapa, btnAlumnos, btnAsignar, btnRenovacion });

            //btnMapa.Click += (s, e) => { var f = new Mapa(); f.ShowDialog(); };
            btnAlumnos.Click += (s, e) => { MessageBox.Show("Abrir formulario de Alumnos (implementar frmalumnos).", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information); };
            btnAsignar.Click += (s, e) => { MessageBox.Show("Abrir formulario de Asignar (implementar frmAsignar).", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information); };
            btnRenovacion.Click += (s, e) => { var f = new RenovacionFuncion(); f.ShowDialog(); };
        }
    }
}