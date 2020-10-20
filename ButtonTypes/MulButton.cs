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
        public string text;
        public bool enabled = false;
        public GUIStyle style = Styles.BtnStyle;
        public Action Action { get; set; }
        public Action IncreaseAction, DecreaseAction;
        private bool highlighted = false;

        public bool Highlighted
        {
            get
            {
                return highlighted;
            }
            set
            {
                enabled = value;
                if (highlighted)
                {

                }
                else
                {

                }
            }
        }

        public MulButton(Menu parentMenu, int position, string text, Action Action, Action IncreaseAction, Action DecreaseAction)
        {
            this.parentMenu = parentMenu;
            this.position = position;
            this.text = text;
            this.Action = Action;
            this.IncreaseAction = IncreaseAction;
            this.DecreaseAction = DecreaseAction;
        }

        public void Draw()
        {
            parentMenu.NumberOfButtons = position;
            int btnY = 5 + 45 * parentMenu.NumberOfButtons;
            rect = new Rect(parentMenu.GetRect().x + 5, parentMenu.GetRect().y + btnY, parentMenu.widthSize - 90, 40);

            if (GUI.Button(rect, text, style))
            {
                Action?.Invoke();
                Draw();
            }
            DrawMulButtons();
        }

        private void DrawMulButtons()
        {
            Rect menuBg = parentMenu.GetRect();
            int btnY = 5 + 45 * position;
            if (GUI.Button(new Rect(menuBg.x + parentMenu.widthSize - 80, menuBg.y + btnY, 40, 40), "-", Styles.OffStyle))
            {
                DecreaseAction?.Invoke();
                Draw();
            }
            if (GUI.Button(new Rect(menuBg.x + parentMenu.widthSize - 35, menuBg.y + btnY, 40, 40), "+", Styles.OffStyle))
            {
                IncreaseAction?.Invoke();
                Draw();
            }
        }
    }
}
