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
        public Rect buttonRect;
        public string offText, onText;
        public bool enabled;
        public GUIStyle defaultStyle;
        public Action OffAction;
        public Action OnAction;

        public TogglableButton(Menu parentMenu, int position, string offText, string onText, GUIStyle defaultStyle, Action OffAction, Action OnAction, bool enabled = false)
        {
            this.parentMenu = parentMenu;
            this.position = position;
            this.offText = offText;
            this.onText = onText;
            this.enabled = enabled;
            this.defaultStyle = defaultStyle;
            this.OffAction = OffAction;
            this.OnAction = OnAction;
        }
    }
}
