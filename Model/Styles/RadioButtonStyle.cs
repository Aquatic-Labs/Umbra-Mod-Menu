using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Umbra_Mod_Menu.Model
{
    internal class RadioButtonStyle : Style
    {
        public Color DefaultBack { get; set; }
        public Color DefaultFore { get; set; }
        public Color CheckedBack { get; set; }
        public Color CheckedFore { get; set; }

        public Appearance Appearance { get; set; }
        public ContentAlignment ContentAlignment { get; set; }
        public FlatStyle FlatStyle { get; set; }
        public int BorderSize { get; set; }
        public RadioButtonStyle(string backColor, string foreColor, string checkedBack, string checkedFore, Size size, ContentAlignment contentAlignment, FlatStyle flatStyle, Appearance appearance, int borderSize) : base(backColor, foreColor, size)
        {
            DefaultBack = ColorTranslator.FromHtml(backColor);
            DefaultFore = ColorTranslator.FromHtml(foreColor);
            CheckedBack = ColorTranslator.FromHtml(checkedBack);
            CheckedFore = ColorTranslator.FromHtml(checkedFore);
            Appearance = appearance;
            ContentAlignment = contentAlignment;
            FlatStyle = flatStyle;
            BorderSize = borderSize;
        }
    }
}
