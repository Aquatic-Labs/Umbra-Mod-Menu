using System.Collections.Generic;
using UnityEngine;

namespace UmbraMenu
{
    public class ListMenu : Menu
    {
        public float heightMulY;
        public Vector2 CurrentScrollPosition;

        public ListMenu(int id, int prevMenuId, Rect rect, string title) : base(id, prevMenuId, rect, title)
        {
            heightMulY = 15;
            if (UmbraMenu.lowResolutionMonitor)
            {
                heightMulY = 10;
            }
        }

        public override void Draw()
        {
            if (Enabled)
            {
                GUI.Box(new Rect(Rect.x, Rect.y, WidthSize + 10, 50f + 45 * heightMulY), "", Styles.MainBgStyle);
                GUI.Label(new Rect(Rect.x + 5f, Rect.y + 5f, WidthSize + 5, 85f), Title, Styles.TitleStyle);
                DrawAllButtons();
            }
        }

        private void DrawAllButtons()
        {
            CurrentScrollPosition = GUI.BeginScrollView(new Rect(Rect.x, Rect.y, WidthSize + 10, 50f + 45 * heightMulY), CurrentScrollPosition, new Rect(Rect.x, Rect.y, WidthSize + 10, 50f + 45 * NumberOfButtons), false, true);
            for (int i = 0; i < Buttons.Count; i++)
            {
                Buttons[i].Draw();
            }
            GUI.EndScrollView();
        }
        public override void Reset()
        {
            Enabled = false;
            IfDragged = false;
        }
    }
}
