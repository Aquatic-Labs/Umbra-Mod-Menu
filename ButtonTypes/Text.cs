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
        public Rect rect;
        public string text;
        public bool enabled = false;
        public GUIStyle style = Styles.LabelStyle;

        public Text(Menu parentMenu, int position, string text)
        {
            this.parentMenu = parentMenu;
            this.position = position;
            this.text = text;
        }
    }
}
