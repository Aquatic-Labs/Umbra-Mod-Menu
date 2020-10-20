using JetBrains.Annotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RoR2;
using UnityEngine;

namespace UmbraMenu
{
    public class Menu
    {
        public static List<IMenu> menus = new List<IMenu>();

        public float widthSize = 350;
        private int Id { get; set; }
        public string Title { get; set; }
        public bool Enabled { get; set; }
        private Rect Rect { get; set; }
        public int NumberOfButtons { get; set; }
        public TogglableButton ActivatingButton { get; set; }
        public bool Highlighted = false;
        private readonly List<IButton> Buttons = new List<IButton>();

        IMenu _menu;

        public Menu(IMenu menu)
        {
            _menu = menu;
            menus.Add(menu);
        }

        public void SetWindow()
        {
            _menu.SetWindow();
        }

        public void Draw()
        {
            _menu.Draw();
        }

        public int GetId()
        {
            return Id;
        }

        public Rect GetRect()
        {
            return Rect;
        }

        public List<IButton> GetButtons()
        {
            return Buttons;
        }
    }
}
