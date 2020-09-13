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
        public string buttonText;
        public string onText;
        public bool isMulButton;
        public bool justText;
        public bool togglable;
        public bool enabled;
        public GUIStyle defaultStyle;
        public Action buttonAction;
        public Action OnAction;
        public Action IncreaseAction;
        public Action DecreaseAction;

        public Button(Menu parentMenu, int position, string buttonText, GUIStyle defaultStyle, Action buttonAction = null, bool isMulButton = false, bool justText = false, bool enabled = false, bool togglable = false, string onText = null, Action OnAction = null, Action DecreaseAction = null, Action IncreaseAction = null) 
        {
            this.parentMenu = parentMenu;
            this.position = position;
            this.buttonText = buttonText;
            this.onText = onText;
            this.isMulButton = isMulButton;
            this.justText = justText;
            this.enabled = enabled;
            this.togglable = togglable;
            this.defaultStyle = defaultStyle;
            this.buttonAction = buttonAction;
            this.OnAction = OnAction;
            this.IncreaseAction = IncreaseAction;
            this.DecreaseAction = DecreaseAction;
        }
    }
}
