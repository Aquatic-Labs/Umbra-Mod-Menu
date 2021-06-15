using System;
using UnityEngine;

namespace UmbraMenu.View
{
    public class TogglableButton : Button
    {
        public Action OnAction, OffAction;
        public string OnText, OffText;

        private bool enabled;
        private bool Enabled
        {
            get
            {
                return enabled;
            }
            set
            {
                enabled = value;
                Text = IsEnabled() ? OnText : OffText;
                style = IsEnabled() ? Styles.OnStyle : Styles.OffStyle;
                Action = IsEnabled() ? OnAction : OffAction;
            }
        }

        public TogglableButton(Menu parentMenu, int position, string offText, string onText, Action OffAction, Action OnAction, bool defaultEnable = false) : base(parentMenu, position, offText, OffAction, Styles.OffStyle)
        {
            this.OnAction = OnAction;
            this.OffAction = OffAction;
            this.OnText = onText;
            this.OffText = offText;
            style = Styles.OffStyle;

            Enabled = defaultEnable;
            if (defaultEnable)
            {
                Text = onText;
                Action = OnAction;
                style = Styles.OnStyle;
            }
        }

        public override void Draw()
        {
            int btnY = 5 + 45 * Position;
            rect = new Rect(ParentMenu.GetRect().x + 5, ParentMenu.GetRect().y + btnY, ParentMenu.GetWidthSize(), 40);

            if (GUI.Button(rect, Text, Navigation.HighlighedCheck(style, ParentMenu.GetId(), Position)))
            {
                enabled = !enabled; // if toggle button opens a menu, needs to change enable state before opening the menu
                Action?.Invoke();
                OnClick();
            }
        }

        protected override void OnClick()
        {
            base.OnClick();
            Text = IsEnabled() ? OnText : OffText;
            style = IsEnabled() ? Styles.OnStyle : Styles.OffStyle;
            Action = IsEnabled() ? OnAction : OffAction;
            Draw();
        }

        public override void NavUpdate()
        {
            enabled = !enabled;
            Action?.Invoke();
            OnClick();
        }

        public bool IsEnabled()
        {
            return Enabled;
        }

        public string GetOffText()
        {
            return OffText;
        }

        public string GetOnText()
        {
            return OnText;
        }

        public void SetEnabled(bool value)
        {
            Enabled = value;
        }
    }
}
