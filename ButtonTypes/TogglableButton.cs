using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace UmbraMenu
{
    public class TogglableButton
    {
        public Menu parentMenu;
        public int position;
        public Rect rect;
        public string offText, onText, text;
        public GUIStyle style = Styles.OffStyle;
        public Action Action, OffAction, OnAction;
        private bool enabled;

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
                parentMenu.AddTogglableButton(this);
            }
        }

        public TogglableButton(Menu parentMenu, int position, string offText, string onText, Action OffAction, Action OnAction)
        {
            this.parentMenu = parentMenu;
            this.position = position;
            text = offText;
            this.offText = offText;
            this.onText = onText;
            Action = OffAction;
            this.OffAction = OffAction;
            this.OnAction = OnAction;
        }
    }
}
