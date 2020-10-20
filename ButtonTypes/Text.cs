using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace UmbraMenu
{
    public class Text : IButton
    {
        public Menu parentMenu;
        public int position { get; set; }
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

        public void Draw()
        {
            parentMenu.NumberOfButtons = position;
            int btnY = 5 + 45 * parentMenu.NumberOfButtons;
            rect = new Rect(parentMenu.GetRect().x + 5, parentMenu.GetRect().y + btnY, parentMenu.widthSize, 40);

            GUI.Button(rect, text, style);
        }
    }
}
