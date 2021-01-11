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
        public int position { get; set; }
        public Rect rect;
        public string offText, onText;
        public string Text { get; set; }
        public GUIStyle style = Styles.OffStyle;
        public Action Action { get; set; }
        public Action OffAction, OnAction;
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

        public TogglableButton(Menu parentMenu, int position, string offText, string onText, Action OffAction, Action OnAction, bool defaultEnable = false)
        {
            Enabled = defaultEnable;
            this.parentMenu = parentMenu;
            this.position = position;
            Text = offText;
            this.offText = offText;
            this.onText = onText;
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
            parentMenu.NumberOfButtons = position;
            int btnY = 5 + 45 * parentMenu.NumberOfButtons;
            rect = new Rect(parentMenu.Rect.x + 5, parentMenu.Rect.y + btnY, parentMenu.WidthSize, 40);

            if (GUI.Button(rect, Text, style))
            {
                Action?.Invoke();
                Enabled = !Enabled;
                Draw();
            }
        }
    }
}
