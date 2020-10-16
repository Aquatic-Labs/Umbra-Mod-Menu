using JetBrains.Annotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace UmbraMenu
{
    public class Button : Buttons
    {
        public Menu parentMenu;
        public ListMenu parentListMenu;
        public int position;
        public Rect rect;
        public string text;
        public bool enabled = false;
        public GUIStyle style = Styles.BtnStyle;
        public Action Action;

        public Button(Menu parentMenu, int position, string text, Action Action) 
        {
            this.parentMenu = parentMenu;
            this.position = position;
            this.text = text;
            this.Action = Action;
        }

        public Button(ListMenu parentListMenu, int position, string text, Action Action)
        {
            this.parentListMenu = parentListMenu;
            this.position = position;
            this.text = text;
            this.Action = Action;
        }

        public void Add()
        {
            if (parentMenu != null)
            {
                parentMenu.numberOfButtons = position;
                int btnY = 5 + 45 * parentMenu.numberOfButtons;
                rect = new Rect(parentMenu.rect.x + 5, parentMenu.rect.y + btnY, parentMenu.widthSize, 40);

                if (GUI.Button(rect, text, style))
                {
                    Action?.Invoke();
                    Add();
                }
            }
            else
            {
                parentListMenu.numberOfButtons = position;
                int btnY = 5 + 45 * parentListMenu.numberOfButtons;
                rect = new Rect(parentListMenu.rect.x + 5, parentListMenu.rect.y + btnY, parentListMenu.widthSize, 40);

                if (GUI.Button(rect, text, style))
                {
                    Action?.Invoke();
                    Add();
                }
            }
        }
    }
}
