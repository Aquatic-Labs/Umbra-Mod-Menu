using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Umbra_Mod_Menu.Model
{
    internal class TextStyle : Style
    {
        public Font Font { get; }
        public ContentAlignment Alignment { get; }
        public TextStyle(Font font, ContentAlignment alignment, string backColor, string foreColor, Size size) : base(backColor, foreColor, size)
        {
            Font = font;
            Alignment = alignment;
        }
    }
}
