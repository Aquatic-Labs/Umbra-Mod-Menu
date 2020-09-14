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
        public Rect buttonRect;
        public string offText;
        public string onText;
        public bool enabled;
        public GUIStyle defaultStyle;
        public Action offAction;
        public Action OnAction;
        public Action IncreaseAction;
        public Action DecreaseAction;

        public TogglableMulButton(Menu parentMenu, int position, string offText, string onText, GUIStyle defaultStyle, Action offAction, Action OnAction, Action DecreaseAction, Action IncreaseAction, bool enabled = false)
        {
            this.parentMenu = parentMenu;
            this.position = position;
            this.offText = offText;
            this.onText = onText;
            this.enabled = enabled;
            this.defaultStyle = defaultStyle;
            this.offAction = offAction;
            this.OnAction = OnAction;
            this.IncreaseAction = IncreaseAction;
            this.DecreaseAction = DecreaseAction;
        }
    }
}
