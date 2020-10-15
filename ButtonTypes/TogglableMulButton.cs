using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace UmbraMenu
{
    public class TogglableMulButton : Buttons
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
                Add();
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
                Add();
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

        public void Add()
        {
            parentMenu.numberOfButtons = position;
            int btnY = 5 + 45 * parentMenu.numberOfButtons;
            rect = new Rect(parentMenu.rect.x + 5, parentMenu.rect.y + btnY, parentMenu.widthSize - 90, 40);

            if (GUI.Button(rect, text, style))
            {
                Action?.Invoke();
                Enabled = !Enabled;
                Add();
            }
            DrawMulButtons();
        }

        private void DrawMulButtons()
        {
            Rect menuBg = parentMenu.rect;
            int btnY = 5 + 45 * position;
            if (GUI.Button(new Rect(menuBg.x + parentMenu.widthSize - 80, menuBg.y + btnY, 40, 40), "-", Styles.OffStyle))
            {
                DecreaseAction?.Invoke();
                Add();
            }
            if (GUI.Button(new Rect(menuBg.x + parentMenu.widthSize - 35, menuBg.y + btnY, 40, 40), "+", Styles.OffStyle))
            {
                IncreaseAction?.Invoke();
                Add();
            }
        }
    }
}
