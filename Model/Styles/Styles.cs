using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Umbra_Mod_Menu.Model
{
    internal static class Styles
    {
        public static MenuStyle DefaultMenuStyle = new MenuStyle("#222222", null, new Size(650, 400), 0.8, Properties.Resources.AquaticLabs_logo, FormBorderStyle.None, FormStartPosition.Manual, true, true);
        public static TextStyle DefaultTitleStyle = new TextStyle(new Font("Arial", 14, FontStyle.Regular), ContentAlignment.BottomRight, null, "#FFFFFF", new Size(160, 25));
        public static TextStyle DefaultFooterStyle = new TextStyle(new Font("Arial", 7, FontStyle.Regular), ContentAlignment.BottomCenter, null, "#FFFFFF", new Size(155, 10));
        public static RadioButtonStyle DefaultMainNavButtonStyle = new RadioButtonStyle("#363d6e", "#FFFFFF", "#585174", "#000000", new Size(83, 45), ContentAlignment.MiddleCenter, FlatStyle.Flat, Appearance.Button, 1);
    }
}
