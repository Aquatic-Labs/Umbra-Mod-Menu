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
        public IMenu _menu;

        public Menu(IMenu menu)
        {
            _menu = menu;
        }

        public void SetWindow()
        {
            _menu.SetWindow();
        }

        public virtual void Draw()
        {
            _menu.Draw();
        }

        public void AddButtons(List<Button> buttonList)
        {
            _menu.Buttons = buttonList;
            _menu.NumberOfButtons = buttonList.Count;
        }

        public int GetId()
        {
            return _menu.Id;
        }
        public bool IsEnabled()
        {
            return _menu.Enabled;
        }
        
        public Rect GetRect()
        {
            return _menu.Rect;
        }
        
        public string GetTitle()
        {
            return _menu.Title;
        }

        public void SetTitle(string newTitle)
        {
            _menu.Title = newTitle;
        }

        public List<Button> GetButtons()
        {
            return _menu.Buttons;
        }

        public void ToggleMenu()
        {
            _menu.Enabled = !_menu.Enabled;
        }

        public void SetEnabled(bool value)
        {
            _menu.ActivatingButton.SetEnabled(false);
            _menu.Enabled = value;
        }

        public void SetIfDragged(bool value)
        {
            _menu.IfDragged = value;
        }

        public void SetRect(Rect rect)
        {
            _menu.Rect = rect;
        }

        public int GetNumberOfButtons()
        {
            return _menu.NumberOfButtons;
        }

        public void SetNumberOfButtons(int value)
        {
            _menu.NumberOfButtons = value;
        }

        public float GetWidthSize()
        {
            return _menu.WidthSize;
        }

        public void SetActivatingButton(Button button)
        {
            _menu.ActivatingButton = button;
        }

        public Button GetActivatingButton()
        {
            return _menu.ActivatingButton;
        }

        public virtual void Reset()
        {
            _menu.Reset();
        }

        public int GetPrevMenuId()
        {
            return _menu.PrevMenuId;
        }

        public void SetPrevMenuId(int value)
        {
            _menu.PrevMenuId = value;
        }

        public void SetScrollPosition(Vector2 value) 
        {
            _menu.CurrentScrollPosition = value;
        }

        public Vector2 GetScrollPosition()
        {
            return _menu.CurrentScrollPosition;
        }
    }
}
