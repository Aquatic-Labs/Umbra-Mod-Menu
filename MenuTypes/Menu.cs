using System;
using System.Collections.Generic;
using UnityEngine;

namespace UmbraMenu
{
    public abstract class Menu
    {
        protected float WidthSize, Delay = 0;
        protected int Id, PrevMenuId, NumberOfButtons;

        private bool enabled;
        protected bool Enabled 
        {
            get { return enabled; }
            set 
            {
                enabled = value;
                if (enabled) OnEnable(); else OnDisable();
            }

        }

        protected bool IfDragged;
        protected string Title;
        protected Rect Rect;
        protected List<Button> Buttons;

        protected TogglableButton ActivatingButton;

        public delegate void EnableEventHandler(object sender, EventArgs e);
        public event EnableEventHandler Opened;

        public delegate void DisabledEventHandler(object sender, EventArgs e);
        public event DisabledEventHandler Closed;

        public abstract void Draw();
        public abstract void Reset();

        public Menu(int id, int prevMenuId, Rect rect, string title)
        {
            Id = id;
            PrevMenuId = prevMenuId;
            Rect = rect;
            Title = title;
            NumberOfButtons = 0;
            WidthSize = UmbraMenu.Width;
            Buttons = new List<Button>();
        }

        protected virtual void OnEnable()
        {
            UmbraMenu.previousMenuOpen = Id;
            if (UmbraMenu.navigationToggle)
            {
                Navigation.menuIndex = Id;
                Navigation.prevButtonIndex = Navigation.buttonIndex;
                Navigation.buttonIndex = 1;
            }

            if (ActivatingButton != null && ActivatingButton.IsEnabled() != Enabled) ActivatingButton.SetEnabled(true);
            Opened?.Invoke(this, EventArgs.Empty);
        }

        protected virtual void OnDisable()
        {
            int temp = Navigation.buttonIndex;
            Navigation.buttonIndex = Navigation.prevButtonIndex;
            Navigation.prevButtonIndex = temp;

            if (ActivatingButton != null && ActivatingButton.IsEnabled() != Enabled) ActivatingButton.SetEnabled(false);
            Closed?.Invoke(this, EventArgs.Empty);
        }

        public void SetWindow()
        {
            Rect = GUI.Window(Id, Rect, new GUI.WindowFunction(SetBackground), "", new GUIStyle());
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
                }
                IfDragged = false;
            }
            GUI.DragWindow();
        }

        public void AddButtons(List<Button> buttonList)
        {
            Buttons = buttonList;

            int high = 0;
            foreach (Button button in Buttons)
            {
                if (button.GetId() > high)
                {
                    high = button.GetId();
                }
            }
            NumberOfButtons = high;

        }

        public void ToggleMenu()
        {
            Enabled = !Enabled;
        }

        public bool IsEnabled()
        {
            return Enabled;
        }

        public int GetId()
        {
            return Id;
        }
        
        public Rect GetRect()
        {
            return Rect;
        }
        
        public string GetTitle()
        {
            return Title;
        }

        public List<Button> GetButtons()
        {
            return Buttons;
        }

        public int GetPrevMenuId()
        {
            return PrevMenuId;
        }

        public int GetNumberOfButtons()
        {
            return NumberOfButtons;
        }

        public float GetWidthSize()
        {
            return WidthSize;
        }

        public void SetTitle(string newTitle)
        {
            Title = newTitle;
        }

        public void SetEnabled(bool value)
        {
            Enabled = value;
        }

        public void SetIfDragged(bool value)
        {
            IfDragged = value;
        }

        public void SetRect(Rect rect)
        {
            Rect = rect;
        }

        public void SetNumberOfButtons(int value)
        {
            NumberOfButtons = value;
        }

        public void SetWidthSize(float value)
        {
            WidthSize = value;
        }

        public void SetButtons(List<Button> buttons)
        {
            Buttons = buttons;
        }
    }
}
