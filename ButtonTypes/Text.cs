using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace UmbraMenu
{
    public class TextButton : IButton
    {
        public Menu parentMenu;
        public int position { get; set; }
        public Rect rect;
        public string Text { get; set; }
        public Action Action { get; set; }
        public bool Enabled { get; set; }
        public GUIStyle style = Styles.LabelStyle;

        public TextButton(Menu parentMenu, int position, string text)
        {
            this.parentMenu = parentMenu;
            this.position = position;
            this.Text = text;
        }

        public void Draw()
        {
            parentMenu.NumberOfButtons = position;
            int btnY = 5 + 45 * parentMenu.NumberOfButtons;
            rect = new Rect(parentMenu.Rect.x + 5, parentMenu.Rect.y + btnY, parentMenu.WidthSize, 40);

            GUI.Button(rect, Text, style);
        }
    }
}
