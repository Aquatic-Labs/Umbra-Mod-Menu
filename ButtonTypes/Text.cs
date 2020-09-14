using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace UmbraMenu
{
    public class Text
    {
        public Menu parentMenu;
        public int position;
        public Rect textRect;
        public string text;
        public bool enabled;
        public GUIStyle defaultStyle = Styles.LabelStyle;

        public Text(Menu parentMenu, int position, string text, bool enabled = false)
        {
            this.parentMenu = parentMenu;
            this.position = position;
            this.text = text;
            this.enabled = enabled;
        }
    }
}
