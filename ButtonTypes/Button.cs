using JetBrains.Annotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace UmbraMenu
{
    public class Button
    {
        public Menu parentMenu;
        public int position;
        public Rect rect;
        public string text;
        public bool enabled = false;
        public GUIStyle style = Styles.BtnStyle;
        public Action Action;
        private bool highlighted = false;

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
                    text = onText;
                    Action = OnAction;
                    style = Styles.HighlightBtnStyle;
                }
                else
                {
                    text = offText;
                    Action = OffAction;
                    style = Styles.OffStyle;
                }
                parentMenu.AddButton(this);
            }
        }

        public bool isMul, isTogglable, isText, isTogglableMul;
        public string onText, offText;
        public Action OnAction, OffAction, IncreaseAction, DecreaseAction;

        public Button(Menu parentMenu, int position, string text, Action Action) 
        {
            this.parentMenu = parentMenu;
            this.position = position;
            this.text = text;
            this.Action = Action;
            int btnY = 5 + 45 * position;
            rect = new Rect(parentMenu.rect.x + 5, parentMenu.rect.y + btnY, parentMenu.widthSize, 40);
        }

        public static Button ConvertTogglableButtonToButton(TogglableButton togglableButton)
        {
            Button button = new Button(togglableButton.parentMenu, togglableButton.position, togglableButton.text, togglableButton.Action)
            {
                isTogglable = true,
                onText = togglableButton.onText,
                offText = togglableButton.offText,
                OnAction = togglableButton.OnAction,
                OffAction = togglableButton.OffAction,
                style = togglableButton.style
            };
            return button;
        }

        public static Button ConvertTogglableMulButtonToButton(TogglableMulButton togglableMulButton)
        {
            Button button = new Button(togglableMulButton.parentMenu, togglableMulButton.position, togglableMulButton.text, togglableMulButton.Action)
            {
                isTogglableMul = true,
                onText = togglableMulButton.onText,
                offText = togglableMulButton.offText,
                OnAction = togglableMulButton.OnAction,
                OffAction = togglableMulButton.OffAction,
                DecreaseAction = togglableMulButton.DecreaseAction,
                IncreaseAction = togglableMulButton.IncreaseAction,
                style = togglableMulButton.style
            };
            return button;
        }

        public static Button ConvertMulButtonToButton(MulButton mulButton)
        {
            Button button = new Button(mulButton.parentMenu, mulButton.position, mulButton.text, mulButton.Action)
            {
                isMul = true,
                DecreaseAction = mulButton.DecreaseAction,
                IncreaseAction = mulButton.IncreaseAction,
                style = mulButton.style
            };
            return button;
        }

        public static Button ConvertTextToButton(Text text)
        {
            Button button = new Button(text.parentMenu, text.position, text.text, null)
            {
                isText = true,
                style = text.style
            };
            return button;
        }
    }
}
