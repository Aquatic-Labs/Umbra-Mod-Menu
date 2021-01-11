using JetBrains.Annotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace UmbraMenu
{
    public class NormalButton : IButton
    {
        public Menu parentMenu;
        public int position { get; set; }
        public Rect rect;
        public string Text { get; set; }
        public bool Enabled { get; set; }
        public GUIStyle style = Styles.BtnStyle;
        public Action Action { get; set; }

        public NormalButton(Menu parentMenu, int position, string text, Action Action) 
        {
            this.parentMenu = parentMenu;
            this.position = position;
            this.Text = text;
            this.Action = Action;
        }

        public void Draw()
        {
            if (parentMenu != null)
            {
                parentMenu.NumberOfButtons = position;
                int btnY = 5 + 45 * parentMenu.NumberOfButtons;
                rect = new Rect(parentMenu.Rect.x + 5, parentMenu.Rect.y + btnY, parentMenu.WidthSize, 40);

                if (GUI.Button(rect, Text, style))
                {
                    Action?.Invoke();
                    Draw();
                }
            }
        }
    }
}
