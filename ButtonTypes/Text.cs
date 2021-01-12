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
            parentMenu.SetNumberOfButtons(position);
            int btnY = 5 + 45 * parentMenu.GetNumberOfButtons();
            rect = new Rect(parentMenu.GetRect().x + 5, parentMenu.GetRect().y + btnY, parentMenu.GetWidthSize(), 40);

            GUI.Button(rect, Text, style);
        }
    }
}
