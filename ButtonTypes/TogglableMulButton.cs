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
        public Menu ParentMenu { get; set; }
        public int Position { get; set; }
        public Rect rect;
        public string Text { get; set; }
        public GUIStyle style = Styles.OffStyle;
        public Action Action { get; set; }
        public Action OffAction, OnAction, IncreaseAction, DecreaseAction;
        private bool enabled = false;

        public string OnText { get; set; }
        public string OffText { get; set; }

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
                    Text = OnText;
                    Action = OnAction;
                    style = Styles.OnStyle;
                }
                else
                {
                    Text = OffText;
                    Action = OffAction;
                    style = Styles.OffStyle;
                }
            }
        }

        public TogglableMulButton(Menu parentMenu, int position, string offText, string onText, Action OffAction, Action OnAction, Action IncreaseAction, Action DecreaseAction)
        {
            this.ParentMenu = parentMenu;
            this.Position = position;
            Text = offText;
            this.OffText = offText;
            this.OnText = onText;
            Action = OffAction;
            this.OffAction = OffAction;
            this.OnAction = OnAction;
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
                Enabled = !Enabled;
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
