using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Umbra_Mod_Menu.Model
{
    internal class Style
    {
        public Color BackColor { get; }
        public Color ForeColor { get; }
        public Size Size { get; }
        
        public Style(string backColor, string foreColor, Size size)
        {
            if (backColor != null)
            {
                BackColor = ColorTranslator.FromHtml(backColor);
            }

            if (foreColor != null)
            {
                ForeColor = ColorTranslator.FromHtml(foreColor);
            }
            Size = size;
        }
    }
}
