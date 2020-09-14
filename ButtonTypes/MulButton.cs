using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace UmbraMenu
{
    public class MulButton
    {
        public Menu parentMenu;
        public int position;
        public Rect buttonRect;
        public string buttonText;
        public bool enabled;
        public GUIStyle defaultStyle;
        public Action ButtonAction;
        public Action IncreaseAction;
        public Action DecreaseAction;

        public MulButton(Menu parentMenu, int position, string buttonText, GUIStyle defaultStyle, Action ButtonAction, Action IncreaseAction, Action DecreaseAction, bool enabled = false)
        {
            this.parentMenu = parentMenu;
            this.position = position;
            this.buttonText = buttonText;
            this.enabled = enabled;
            this.defaultStyle = defaultStyle;
            this.ButtonAction = ButtonAction;
            this.IncreaseAction = IncreaseAction;
            this.DecreaseAction = DecreaseAction;
        }
    }
}
