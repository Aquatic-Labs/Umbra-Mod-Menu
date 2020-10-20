using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace UmbraMenu
{
    public class ListMenu : Menus
    {
        public float delay = 0, widthSize = 350, heightMulY = 15;
        public int id { get; set; }
        public string menuTitle = "Title";
        public bool enabled { get; set; }
        public Rect rect { get; set; }
        public bool ifDragged { get; set; }
        public int numberOfButtons { get; set; }
        public TogglableButton activatingButton { get; set; }
        public bool highlighted = false;
        public List<Buttons> buttons { get; set; }
        public Vector2 currentScrollPosition = Vector2.zero;
        public Vector2 endScrollPosition = Vector2.zero;
        public Vector2 startScrollPosition = Vector2.zero;

        public void SetWindow()
        {
            rect = GUI.Window(id, rect, new GUI.WindowFunction(SetBackground), "", new GUIStyle());
        }

        private void DrawTitle()
        {
            GUI.Label(new Rect(rect.x + 5f, rect.y + 5f, widthSize + 5, 85f), menuTitle, Styles.TitleStyle);
        }

        public void DrawMenu()
        {
            if (enabled)
            {
                GUI.Box(new Rect(rect.x + 0f, rect.y + 0f, widthSize + 10, 50f + 45 * heightMulY), "", Styles.MainBgStyle);
                DrawTitle();
            }
        }

        public void DrawAllButtons()
        {
            currentScrollPosition = GUI.BeginScrollView(new Rect(rect.x + 0f, rect.y + 0f, widthSize + 10, 50f + 45 * heightMulY), currentScrollPosition, new Rect(rect.x + 0f, rect.y + 0f, widthSize + 10, 50f + 45 * numberOfButtons), false, true);
            for (int i = 0; i < buttons.Count; i++)
            {
                buttons[i].Add();
            }
            GUI.EndScrollView();
        }

        private void SetBackground(int windowID)
        {
            GUI.Box(new Rect(0f, 0f, widthSize + 10, 50f + 45 * numberOfButtons), "", Styles.CornerStyle);
            if (Event.current.type == EventType.MouseDrag)
            {
                delay += Time.deltaTime;
                if (delay > 0.3f)
                {
                    ifDragged = true;
                }
            }
            else if (Event.current.type == EventType.MouseUp)
            {
                delay = 0;
                if (!ifDragged)
                {
                    enabled = !enabled;
                    if (activatingButton != null)
                    {
                        activatingButton.Enabled = !activatingButton.Enabled;
                    }
                    UmbraMenu.GetCharacter();
                }
                ifDragged = false;
            }
            GUI.DragWindow();
        }
    }
}
