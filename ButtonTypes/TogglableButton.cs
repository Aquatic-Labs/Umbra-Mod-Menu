using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace UmbraMenu
{
    public class TogglableButton : Buttons
    {
        public Menu parentMenu;
        public int position;
        public Rect rect;
        public string offText, onText, text;
        public GUIStyle style = Styles.OffStyle;
        public Action Action, OffAction, OnAction;
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

        public TogglableButton(Menu parentMenu, int position, string offText, string onText, Action OffAction, Action OnAction, bool defaultEnable = false)
        {
            Enabled = defaultEnable;
            this.parentMenu = parentMenu;
            this.position = position;
            text = offText;
            this.offText = offText;
            this.onText = onText;
            Action = OffAction;
            this.OffAction = OffAction;
            this.OnAction = OnAction;
        }

        public void Add()
        {
            parentMenu.numberOfButtons = position;
            int btnY = 5 + 45 * parentMenu.numberOfButtons;
            rect = new Rect(parentMenu.rect.x + 5, parentMenu.rect.y + btnY, parentMenu.widthSize, 40);

            if (GUI.Button(rect, text, style))
            {
                Action?.Invoke();
                Enabled = !Enabled;
                Add();
            }
        }
    }
}
