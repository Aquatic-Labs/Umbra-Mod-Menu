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
        public Menu parentMenu;
        public int position { get; set; }
        public Rect rect;
        public string Text { get; set; }
        public bool Enabled { get; set; }
        public GUIStyle style = Styles.BtnStyle;
        public Action Action { get; set; }
        public Action IncreaseAction { get; set; }
        public Action DecreaseAction{ get; set; }

    public MulButton(Menu parentMenu, int position, string text, Action Action, Action IncreaseAction, Action DecreaseAction)
        {
            this.parentMenu = parentMenu;
            this.position = position;
            this.Text = text;
            this.Action = Action;
            this.IncreaseAction = IncreaseAction;
            this.DecreaseAction = DecreaseAction;
        }

        public void Draw()
        {
            parentMenu.NumberOfButtons = position;
            int btnY = 5 + 45 * parentMenu.NumberOfButtons;
            rect = new Rect(parentMenu.Rect.x + 5, parentMenu.Rect.y + btnY, parentMenu.WidthSize - 90, 40);

            if (GUI.Button(rect, Text, style))
            {
                Action?.Invoke();
                Draw();
            }
            DrawMulButtons();
        }

        private void DrawMulButtons()
        {
            Rect menuBg = parentMenu.Rect;
            int btnY = 5 + 45 * position;
            if (GUI.Button(new Rect(menuBg.x + parentMenu.WidthSize - 80, menuBg.y + btnY, 40, 40), "-", Styles.OffStyle))
            {
                DecreaseAction?.Invoke();
                Draw();
            }
            if (GUI.Button(new Rect(menuBg.x + parentMenu.WidthSize - 35, menuBg.y + btnY, 40, 40), "+", Styles.OffStyle))
            {
                IncreaseAction?.Invoke();
                Draw();
            }
        }
    }
}
