using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Umbra_Mod_Menu.Model.Controls
{
    internal class Text : Label
    {
        public Text(string title, Point position, TextStyle style)
        {
            Size = style.Size;
            Location = position;
            Text = title;
            Font = style.Font;
            TextAlign = style.Alignment;
            ForeColor = style.ForeColor;
        }
    }
}
