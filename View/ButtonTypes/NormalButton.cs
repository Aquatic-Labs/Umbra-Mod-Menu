using System;
using UnityEngine;

namespace UmbraMenu.View
{
    public class NormalButton : Button
    {
        public NormalButton(Menu parentMenu, int position, string text, Action Action) : base(parentMenu, position, text, Action, Styles.BtnStyle) 
        {
            void clickEvent(object sender, EventArgs e) => Action?.Invoke();
            Click += clickEvent;
        }

        public override void Draw()
        {
            int btnY = 5 + 45 * Position;
            rect = new Rect(ParentMenu.GetRect().x + 5, ParentMenu.GetRect().y + btnY, ParentMenu.GetWidthSize(), 40);

            if (GUI.Button(rect, Text, Navigation.HighlighedCheck(style, ParentMenu.GetId(), Position)))
            {
                OnClick();
            }
        }
    }
}
