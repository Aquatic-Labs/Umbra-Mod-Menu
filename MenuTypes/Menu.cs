using JetBrains.Annotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RoR2;
using UnityEngine;
using System.Reflection;

namespace UmbraMenu
{
    public class Menu
    {
        public static List<Menu> menus = new List<Menu>();

        public IMenu _menu;
        public float Delay = 0, WidthSize = 350;
        public int Id { get; set; }
        public int NumberOfButtons { get; set; }
        public Rect Rect { get; set; }
        public string Title { get; set; }
        public bool Enabled { get; set; }
        public bool IfDragged { get; set; }
        public TogglableButton ActivatingButton { get; set; }
        public List<Button> Buttons { get; set; }

        public Menu(IMenu menu)
        {
            _menu = menu;
            //menus.Add(this);
        }

        public void SetWindow()
        {
            Rect = GUI.Window(Id, Rect, new GUI.WindowFunction(SetBackground), "", new GUIStyle());
        }

        public virtual void Draw()
        {
            if (Enabled)
            {
                GUI.Box(new Rect(Rect.x + 0f, Rect.y + 0f, WidthSize + 10, 50f + 45 * NumberOfButtons), "", Styles.MainBgStyle);
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
                Delay += Time.deltaTime;
                if (Delay > 0.3f)
                {
                    IfDragged = true;
                }
            }
            else if (Event.current.type == EventType.MouseUp)
            {
                Delay = 0;
                if (!IfDragged)
                {
                    Enabled = !Enabled;
                    if (ActivatingButton != null)
                    {
                        ActivatingButton.Enabled = !ActivatingButton.Enabled;
                    }
                    UmbraMenu.GetCharacter();
                }
                IfDragged = false;
            }
            GUI.DragWindow();
        }
    }
}
