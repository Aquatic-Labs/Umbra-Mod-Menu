using RewiredConsts;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Runtime.CompilerServices;
using System.Text;
using UnityEngine;

namespace UmbraMenu
{
    public interface Buttons { void Add(); };
    public class Menu
    {
        public float delay = 0, widthSize = 350;
        public int id;
        public string menuTitle = "Title";
        public bool enabled = false;
        public Rect rect;
        public bool ifDragged = false;
        public int numberOfButtons = 0;
        public TogglableButton activatingButton;
        public bool highlighted = false;
        public List<Buttons> buttons = new List<Buttons>();

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
                GUI.Box(new Rect(rect.x + 0f, rect.y + 0f, widthSize + 10, 50f + 45 * numberOfButtons), "", Styles.MainBgStyle);
                DrawTitle();
            }
        }

        public void DrawAllButtons()
        {
            for (int i = 0; i < buttons.Count; i++)
            {
                buttons[i].Add();
            }
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
