using System;
using UnityEngine;

namespace UmbraMenu.View
{
    public class TextButton : Button
    {
        public TextButton(Menu parentMenu, int position, string text) : base(parentMenu, position, text, () => { return; }, Styles.LabelStyle) { }

        public override void Draw()
        {
            int btnY = 5 + 45 * Position;
            rect = new Rect(ParentMenu.GetRect().x + 5, ParentMenu.GetRect().y + btnY, ParentMenu.GetWidthSize(), 40);

            GUI.Button(rect, Text, style);
        }
    }
}
