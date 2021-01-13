using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace UmbraMenu
{
    public class TogglableButton : IButton
    {
        public Menu parentMenu;
        public int Position { get; set; }
        public Rect rect;
        public string Text { get; set; }
        public GUIStyle style = Styles.OffStyle;
        public Action Action { get; set; }
        public Action OffAction, OnAction;
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
            this.parentMenu = parentMenu;
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
            parentMenu.SetNumberOfButtons(Position);
            int btnY = 5 + 45 * parentMenu.GetNumberOfButtons();
            rect = new Rect(parentMenu.GetRect().x + 5, parentMenu.GetRect().y + btnY, parentMenu.GetWidthSize(), 40);

            if (GUI.Button(rect, Text, style))
            {
                Enabled = !Enabled;
                Action?.Invoke();
                Draw();
            }
        }
    }
}
