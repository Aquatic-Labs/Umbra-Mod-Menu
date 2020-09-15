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
        public Rect rect;
        public string text;
        public bool enabled;
        public GUIStyle style;
        public Action Action;
        public Action IncreaseAction;
        public Action DecreaseAction;

        public MulButton(Menu parentMenu, int position, string buttonText, GUIStyle defaultStyle, Action ButtonAction, Action IncreaseAction, Action DecreaseAction, bool enabled = false)
        {
            this.parentMenu = parentMenu;
            this.position = position;
            this.text = buttonText;
            this.enabled = enabled;
            this.style = defaultStyle;
            this.Action = ButtonAction;
            this.IncreaseAction = IncreaseAction;
            this.DecreaseAction = DecreaseAction;
        }
    }
}
