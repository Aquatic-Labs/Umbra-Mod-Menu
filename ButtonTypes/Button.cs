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
        public bool enabled;
        public GUIStyle defaultStyle;
        public Action buttonAction;

        public Button(Menu parentMenu, int position, string buttonText, GUIStyle defaultStyle, Action buttonAction, bool enabled = false) 
        {
            this.parentMenu = parentMenu;
            this.position = position;
            this.buttonText = buttonText;
            this.enabled = enabled;
            this.defaultStyle = defaultStyle;
            this.buttonAction = buttonAction;
        }
    }
}
