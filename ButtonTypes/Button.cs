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
        protected Rect rect;
        protected GUIStyle style;

        public abstract void Draw();

        public Button(Menu parentMenu, int position, string text, Action Action, GUIStyle defualtStyle)
        {
            this.ParentMenu = parentMenu;
            this.Position = position;
            this.Text = text;
            this.Action = Action;
            this.style = defualtStyle;
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
