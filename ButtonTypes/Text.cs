using System;
using UnityEngine;

namespace UmbraMenu
{
    public class TextButton : Button
    {
        public TextButton(Menu parentMenu, int position, string text) : base(parentMenu, position, text, Utility.StubbedFunction)
        {
            this.ParentMenu = parentMenu;
            this.Position = position;
            this.Text = text;
        }

        public override void Draw()
        {
            ParentMenu.SetNumberOfButtons(Position);
            int btnY = 5 + 45 * ParentMenu.GetNumberOfButtons();
            rect = new Rect(ParentMenu.GetRect().x + 5, ParentMenu.GetRect().y + btnY, ParentMenu.GetWidthSize(), 40);

            GUI.Button(rect, Text, style);
        }
    }
}
