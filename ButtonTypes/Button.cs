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
        public Rect buttonRect;
        public string text;
        public bool enabled;
        public GUIStyle defaultStyle;
        public Action buttonAction;

        public bool isMul, isTogglable, isText, isTogglableMul;
        public string onText, offText;
        public Action OnAction, OffAction, IncreaseAction, DecreaseAction;

        public Button(Menu parentMenu, int position, string text, GUIStyle defaultStyle, Action buttonAction, bool enabled = false) 
        {
            this.parentMenu = parentMenu;
            this.position = position;
            this.text = text;
            this.enabled = enabled;
            this.defaultStyle = defaultStyle;
            this.buttonAction = buttonAction;
        }

        public static Button ConvertTogglableButtonToButton(TogglableButton togglableButton)
        {
            Button button = new Button(togglableButton.parentMenu, togglableButton.position, togglableButton.text, togglableButton.style, togglableButton.Action)
            {
                isTogglable = true,
                onText = togglableButton.onText,
                offText = togglableButton.offText,
                OnAction = togglableButton.OnAction,
                OffAction = togglableButton.OffAction
            };
            return button;
        }

        public static Button ConvertTogglableMulButtonToButton(TogglableMulButton togglableMulButton)
        {
            Button button = new Button(togglableMulButton.parentMenu, togglableMulButton.position, togglableMulButton.text, togglableMulButton.style, togglableMulButton.Action)
            {
                isTogglableMul = true,
                onText = togglableMulButton.onText,
                offText = togglableMulButton.offText,
                OnAction = togglableMulButton.OnAction,
                OffAction = togglableMulButton.OffAction,
                DecreaseAction = togglableMulButton.DecreaseAction,
                IncreaseAction = togglableMulButton.IncreaseAction
            };
            return button;
        }

        public static Button ConvertMulButtonToButton(MulButton mulButton)
        {
            Button button = new Button(mulButton.parentMenu, mulButton.position, mulButton.text, mulButton.style, mulButton.Action)
            {
                isMul = true,
                DecreaseAction = mulButton.DecreaseAction,
                IncreaseAction = mulButton.IncreaseAction
            };
            return button;
        }

        public static Button ConvertTextToButton(Text text)
        {
            Button button = new Button(text.parentMenu, text.position, text.text, text.style, null)
            {
                isText = true
            };
            return button;
        }
    }
}
