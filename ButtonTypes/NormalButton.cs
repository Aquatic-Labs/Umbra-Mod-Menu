using System;
using UnityEngine;

namespace UmbraMenu
{
    public class NormalButton : IButton
    {
        public Menu ParentMenu { get; set; }
        public int Position { get; set; }
        public Rect rect;
        public string Text { get; set; }
        public bool Enabled { get; set; }
        public GUIStyle style = Styles.BtnStyle;
        public Action Action { get; set; }

        public string OnText { get; set; }
        public string OffText { get; set; }
        public Action IncreaseAction { get; set; }
        public Action DecreaseAction { get; set; }

        public NormalButton(Menu parentMenu, int position, string text, Action Action) 
        {
            this.ParentMenu = parentMenu;
            this.Position = position;
            this.Text = text;
            this.Action = Action;
        }

        public void Draw()
        {
            if (ParentMenu != null)
            {
                ParentMenu.SetNumberOfButtons(Position);
                int btnY = 5 + 45 * ParentMenu.GetNumberOfButtons();
                rect = new Rect(ParentMenu.GetRect().x + 5, ParentMenu.GetRect().y + btnY, ParentMenu.GetWidthSize(), 40);

                if (GUI.Button(rect, Text, Navigation.HighlighedCheck(style, ParentMenu.GetId(), Position)))
                {
                    Action?.Invoke();
                    Draw();
                }
            }
        }
    }
}
