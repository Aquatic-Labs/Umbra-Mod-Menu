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
        public string Text { get; set; }
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
                    Text = onText;
                    Action = OnAction;
                    style = Styles.OnStyle;
                }
                else
                {
                    Text = offText;
                    Action = OffAction;
                    style = Styles.OffStyle;
                }
            }
        }

        public TogglableMulButton(Menu parentMenu, int position, string offText, string onText, Action OffAction, Action OnAction, Action IncreaseAction, Action DecreaseAction)
        {
            this.parentMenu = parentMenu;
            this.position = position;
            Text = offText;
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
            parentMenu.SetNumberOfButtons(position);
            int btnY = 5 + 45 * parentMenu.GetNumberOfButtons();
            rect = new Rect(parentMenu.GetRect().x + 5, parentMenu.GetRect().y + btnY, parentMenu.GetWidthSize() - 90, 40);

            if (GUI.Button(rect, Text, style))
            {
                Action?.Invoke();
                Enabled = !Enabled;
                Draw();
            }
            DrawMulButtons();
        }

        private void DrawMulButtons()
        {
            Rect menuBg = parentMenu.GetRect();
            int btnY = 5 + 45 * position;
            if (GUI.Button(new Rect(menuBg.x + parentMenu.GetWidthSize() - 80, menuBg.y + btnY, 40, 40), "-", Styles.OffStyle))
            {
                DecreaseAction?.Invoke();
                Draw();
            }
            if (GUI.Button(new Rect(menuBg.x + parentMenu.GetWidthSize() - 35, menuBg.y + btnY, 40, 40), "+", Styles.OffStyle))
            {
                IncreaseAction?.Invoke();
                Draw();
            }
        }
    }
}
