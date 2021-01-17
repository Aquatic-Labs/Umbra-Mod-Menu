using System;
using UnityEngine;

namespace UmbraMenu
{
    public class TextButton : IButton
    {
        public Menu ParentMenu { get; set; }
        public int Position { get; set; }
        public Rect rect;
        public string Text { get; set; }
        public Action Action { get; set; }
        public bool Enabled { get; set; }
        public GUIStyle style = Styles.LabelStyle;

        public string OnText { get; set; }
        public string OffText { get; set; }
        public Action IncreaseAction { get; set; }
        public Action DecreaseAction { get; set; }

        public TextButton(Menu parentMenu, int position, string text)
        {
            this.ParentMenu = parentMenu;
            this.Position = position;
            this.Text = text;
        }

        public void Draw()
        {
            ParentMenu.SetNumberOfButtons(Position);
            int btnY = 5 + 45 * ParentMenu.GetNumberOfButtons();
            rect = new Rect(ParentMenu.GetRect().x + 5, ParentMenu.GetRect().y + btnY, ParentMenu.GetWidthSize(), 40);

            GUI.Button(rect, Text, style);
        }
    }
}
