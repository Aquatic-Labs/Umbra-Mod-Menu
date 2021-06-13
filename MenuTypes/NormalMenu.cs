using UnityEngine;

namespace UmbraMenu
{
    public class NormalMenu : Menu
    {
        public NormalMenu(int id, int prevMenuId, Rect rect, string title) : base (id, prevMenuId, rect, title) {}

        public override void Draw()
        {
            if (Enabled)
            {
                GUI.Box(new Rect(Rect.x, Rect.y, WidthSize + 10, 50f + 45 * NumberOfButtons), "", Styles.MainBgStyle);
                GUI.Label(new Rect(Rect.x + 5f, Rect.y + 5f, WidthSize + 5, 85f), Title, Styles.TitleStyle);
                DrawAllButtons();
            }
        }

        private void DrawAllButtons()
        {
            for (int i = 0; i < Buttons.Count; i++)
            {
                Buttons[i].Draw();
            }
        }

        public override void Reset()
        {
            Enabled = false;
            IfDragged = false;
        }
    }
}
