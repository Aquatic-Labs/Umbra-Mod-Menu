using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace UmbraMenu
{
    public class MulButton : IButton
    {
        public Menu ParentMenu { get; set; }
        public int Position { get; set; }
        public Rect rect;
        public string Text { get; set; }
        public bool Enabled { get; set; }
        public GUIStyle style = Styles.BtnStyle;
        public Action Action { get; set; }
        public Action IncreaseAction { get; set; }
        public Action DecreaseAction{ get; set; }

        public string OnText { get; set; }
        public string OffText { get; set; }

        public MulButton(Menu parentMenu, int position, string text, Action Action, Action IncreaseAction, Action DecreaseAction)
        {
            this.ParentMenu = parentMenu;
            this.Position = position;
            this.Text = text;
            this.Action = Action;
            this.IncreaseAction = IncreaseAction;
            this.DecreaseAction = DecreaseAction;
        }

        public void Draw()
        {
            ParentMenu.SetNumberOfButtons(Position);
            int btnY = 5 + 45 * ParentMenu.GetNumberOfButtons();
            rect = new Rect(ParentMenu.GetRect().x + 5, ParentMenu.GetRect().y + btnY, ParentMenu.GetWidthSize() - 90, 40);

            if (GUI.Button(rect, Text, style))
            {
                Action?.Invoke();
                Draw();
            }
            DrawMulButtons();
        }

        private void DrawMulButtons()
        {
            Rect menuBg = ParentMenu.GetRect();
            int btnY = 5 + 45 * Position;
            if (GUI.Button(new Rect(menuBg.x + ParentMenu.GetWidthSize() - 80, menuBg.y + btnY, 40, 40), "-", Styles.OffStyle))
            {
                DecreaseAction?.Invoke();
                Draw();
            }
            if (GUI.Button(new Rect(menuBg.x + ParentMenu.GetWidthSize() - 35, menuBg.y + btnY, 40, 40), "+", Styles.OffStyle))
            {
                IncreaseAction?.Invoke();
                Draw();
            }
        }
    }
}
