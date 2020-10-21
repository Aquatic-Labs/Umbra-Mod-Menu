using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace UmbraMenu
{
    public class TogglableMulButton : IButton
    {
        public Menu parentMenu { get; set; }
        public int position { get; set; }
        public Rect rect;
        public string offText, onText;
        public string text { get; set; }
        public GUIStyle style = Styles.OffStyle;
        public Action Action { get; set; }
        public Action OffAction, OnAction, IncreaseAction, DecreaseAction;
        private bool enabled = false;

        public bool Enabled
        {
            get
            {
                return enabled;
            }
            set
            {
                enabled = value;
                if (enabled)
                {
                    text = onText;
                    Action = OnAction;
                    style = Styles.OnStyle;
                }
                else
                {
                    text = offText;
                    Action = OffAction;
                    style = Styles.OffStyle;
                }
            }
        }

        public TogglableMulButton(Menu parentMenu, int position, string offText, string onText, Action OffAction, Action OnAction, Action IncreaseAction, Action DecreaseAction)
        {
            this.parentMenu = parentMenu;
            this.position = position;
            text = offText;
            this.offText = offText;
            this.onText = onText;
            Action = OffAction;
            this.OffAction = OffAction;
            this.OnAction = OnAction;
            this.IncreaseAction = IncreaseAction;
            this.DecreaseAction = DecreaseAction;
        }

        public void Draw()
        {
            parentMenu.NumberOfButtons = position;
            int btnY = 5 + 45 * parentMenu.NumberOfButtons;
            rect = new Rect(parentMenu.Rect.x + 5, parentMenu.Rect.y + btnY, parentMenu.WidthSize - 90, 40);

            if (GUI.Button(rect, text, style))
            {
                Action?.Invoke();
                Enabled = !Enabled;
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
