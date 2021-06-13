using System;
using UnityEngine;

namespace UmbraMenu
{
    public abstract class Button
    {
        protected Menu ParentMenu;
        protected int Position;
        protected string Text;
        protected Action Action;
        protected Rect rect; // Should be set in Draw method
        protected GUIStyle style; // default Should be set in constructor

        public abstract void Draw();

        public Button(Menu parentMenu, int position, string text, Action Action)
        {
            this.ParentMenu = parentMenu;
            this.Position = position;
            this.Text = text;
            this.Action = Action;
            this.style = Styles.BtnStyle;
        }

        public int GetId()
        {
            return Position;
        }

        public Menu GetParentMenu()
        {
            return ParentMenu;
        }

        public Action GetAction()
        {
            return Action;
        }

        public void SetText(string newText)
        {
            Text = newText;
        }
    }
}
