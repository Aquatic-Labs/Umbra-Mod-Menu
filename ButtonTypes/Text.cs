using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace UmbraMenu
{
    public class Text : IButtons
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

        public void Draw()
        {
            parentMenu.numberOfButtons = position;
            int btnY = 5 + 45 * parentMenu.numberOfButtons;
            rect = new Rect(parentMenu.rect.x + 5, parentMenu.rect.y + btnY, parentMenu.widthSize, 40);

            GUI.Button(rect, text, style);
        }

        public void Add()
        {
            parentMenu.buttons.Add(this);
        }
    }
}
