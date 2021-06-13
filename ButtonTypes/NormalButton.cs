using System;
using UnityEngine;

namespace UmbraMenu
{
    public class NormalButton : Button
    {
        public NormalButton(Menu parentMenu, int position, string text, Action Action) : base(parentMenu, position, text, Action) {}

        public override void Draw()
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
