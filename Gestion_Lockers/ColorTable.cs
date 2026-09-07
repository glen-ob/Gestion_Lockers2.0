using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace Gestion_Lockers
{


    public class CustomMenuColorTable : ProfessionalColorTable
    {
        public override Color MenuItemSelected => Color.MediumPurple;

        public override Color MenuItemBorder => Color.Purple;

        public override Color ToolStripDropDownBackground => Color.DarkSlateBlue;

        public override Color MenuItemSelectedGradientBegin => Color.MediumPurple;
        public override Color MenuItemSelectedGradientEnd => Color.MediumPurple;
    }
}
