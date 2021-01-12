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
    public class NormalMenu : IMenu
    {
        public float delay = 0;
        public float WidthSize { get; set; }
        public int Id { get; set; }
        public string Title { get; set; }
        public bool Enabled { get; set; }
        public Rect Rect { get; set; }
        public bool IfDragged { get; set; }
        public int NumberOfButtons { get; set; }
        public Button ActivatingButton { get; set; }
        public bool highlighted = false;
        public List<Button> Buttons { get; set; }

        public NormalMenu(int id, Rect rect, string title)
        {
            Id = id;
            Rect = rect;
            Title = title;
            NumberOfButtons = 0;
            WidthSize = 350;
        }

        public void SetWindow()
        {
            Rect = GUI.Window(Id, Rect, new GUI.WindowFunction(SetBackground), "", new GUIStyle());
        }

        public void Draw()
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

        private void SetBackground(int windowID)
        {
            GUI.Box(new Rect(0f, 0f, WidthSize + 10, 50f + 45 * NumberOfButtons), "", Styles.CornerStyle);
            if (Event.current.type == EventType.MouseDrag)
            {
                delay += Time.deltaTime;
                if (delay > 0.3f)
                {
                    IfDragged = true;
                }
            }
            else if (Event.current.type == EventType.MouseUp)
            {
                delay = 0;
                if (!IfDragged)
                {
                    Enabled = !Enabled;
                    if (ActivatingButton != null)
                    {
                        ActivatingButton.SetEnabled(!ActivatingButton.IsEnabled());
                    }
                    UmbraMenu.GetCharacter();
                }
                IfDragged = false;
            }
            GUI.DragWindow();
        }
    }
}
