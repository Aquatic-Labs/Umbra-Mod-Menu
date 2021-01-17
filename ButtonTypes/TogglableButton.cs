using System;
using UnityEngine;

namespace UmbraMenu
{
    public class TogglableButton : IButton
    {
        public Menu ParentMenu { get; set; }
        public int Position { get; set; }
        public Rect rect;
        public string Text { get; set; }
        public GUIStyle style = Styles.OffStyle;
        public Action Action { get; set; }
        public Action OnAction, OffAction;
        public Action IncreaseAction { get; set; }
        public Action DecreaseAction { get; set; }
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

        public TogglableButton(Menu parentMenu, int position, string offText, string onText, Action OffAction, Action OnAction, bool defaultEnable = false)
        {
            Enabled = defaultEnable;
            this.ParentMenu = parentMenu;
            this.Position = position;
            Text = offText;
            this.OffText = offText;
            this.OnText = onText;
            Action = OffAction;
            this.OffAction = OffAction;
            this.OnAction = OnAction;

            if (defaultEnable)
            {
                Text = onText;
                Action = OnAction;
            }
        }

        public void Draw()
        {
            ParentMenu.SetNumberOfButtons(Position);
            int btnY = 5 + 45 * ParentMenu.GetNumberOfButtons();
            rect = new Rect(ParentMenu.GetRect().x + 5, ParentMenu.GetRect().y + btnY, ParentMenu.GetWidthSize(), 40);

            if (GUI.Button(rect, Text, Navigation.HighlighedCheck(style, ParentMenu.GetId(), Position)))
            {
                Enabled = !Enabled;
                Action?.Invoke();
                Draw();
            }
        }
    }
}
