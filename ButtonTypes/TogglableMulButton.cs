using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace UmbraMenu
{
    public class TogglableMulButton
    {
        public Menu parentMenu;
        public int position;
        public Rect rect;
        public string text, offText ,onText;
        public GUIStyle style = Styles.OffStyle;
        public Action Action, OffAction, OnAction, IncreaseAction, DecreaseAction;
        private bool highlighted = false;
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
                parentMenu.AddTogglableMulButton(this);
            }
        }

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
                    style = Styles.HighlightBtnStyle;
                }
                else
                {

                }
                parentMenu.AddTogglableMulButton(this);
            }
        }


        public TogglableMulButton(Menu parentMenu, int position, string offText, string onText, GUIStyle style, Action OffAction, Action OnAction, Action DecreaseAction, Action IncreaseAction)
        {
            this.parentMenu = parentMenu;
            this.position = position;
            text = offText;
            this.offText = offText;
            this.onText = onText;
            this.style = style;
            Action = OffAction;
            this.OffAction = OffAction;
            this.OnAction = OnAction;
            this.IncreaseAction = IncreaseAction;
            this.DecreaseAction = DecreaseAction;
        }
    }
}
