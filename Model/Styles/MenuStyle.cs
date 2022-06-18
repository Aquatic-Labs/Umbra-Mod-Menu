using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Umbra_Mod_Menu.Model
{
    internal class MenuStyle : Style
    {
        public double Opacity { get; }
        public FormBorderStyle BorderStyle { get; }
        public FormStartPosition FormStartPosition { get; }
        public bool TopMost { get; }
        public bool Draggable { get; }
        public Image Logo { get; }

        public MenuStyle(string backColor, string foreColor, Size size, double opacity, Image image, FormBorderStyle borderStyle, FormStartPosition formStartPosition, bool topMost, bool draggable) : base(backColor, foreColor, size)
        {
            Opacity = opacity;
            BorderStyle = borderStyle;
            FormStartPosition = formStartPosition;
            TopMost = topMost;
            Draggable = draggable;
            Logo = image;
        }
    }
}
