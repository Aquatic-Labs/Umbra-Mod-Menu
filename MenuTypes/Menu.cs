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
    public class Menu
    {
        public float delay = 0, widthSize = 350;
        public int id;
        public string menuTitle = "Title";
        public bool enabled = false;
        public Rect rect;
        public bool ifDragged = false;
        public int numberOfButtons = 0;
        public List<Button> buttons = new List<Button>();

        public void AddButton(Button button)
        {
            numberOfButtons = button.position;
            int btnY = 5 + 45 * numberOfButtons;
            button.buttonRect = new Rect(rect.x + 5, rect.y + btnY, widthSize, 40);

            if (GUI.Button(button.buttonRect, button.text, button.defaultStyle))
            {
                button.buttonAction();
            }
        }

        public void AddText(Text text)
        {
            numberOfButtons = text.position;
            int btnY = 5 + 45 * numberOfButtons;
            text.rect = new Rect(rect.x + 5, rect.y + btnY, widthSize, 40);

            GUI.Button(text.rect, text.text, text.style);
        }

        public void AddMulButton(MulButton mulButton)
        {
            numberOfButtons = mulButton.position;
            int btnY = 5 + 45 * numberOfButtons;
            mulButton.rect = new Rect(rect.x + 5, rect.y + btnY, widthSize - 90, 40);

            if (GUI.Button(mulButton.rect, mulButton.text, mulButton.style))
            {
                mulButton.Action();
            }
            DrawMulButtons(mulButton);
        }

        public void AddTogglableButton(TogglableButton togglableButton)
        {
            numberOfButtons = togglableButton.position;
            int btnY = 5 + 45 * numberOfButtons;
            togglableButton.rect = new Rect(rect.x + 5, rect.y + btnY, widthSize, 40);

            if (GUI.Button(togglableButton.rect, togglableButton.text, togglableButton.style))
            {
                togglableButton.Action?.Invoke();
                togglableButton.Enabled = !togglableButton.Enabled;
            }
        }

        public void AddTogglableMulButton(TogglableMulButton togglableMulButton)
        {
            numberOfButtons = togglableMulButton.position;
            int btnY = 5 + 45 * numberOfButtons;
            togglableMulButton.rect = new Rect(rect.x + 5, rect.y + btnY, widthSize - 90, 40);

            if (GUI.Button(togglableMulButton.rect, togglableMulButton.text, togglableMulButton.style))
            {
                togglableMulButton.Action?.Invoke();
                togglableMulButton.Enabled = !togglableMulButton.Enabled;
            }
            DrawMulButtons(togglableMulButton: togglableMulButton);
        }

        private void DrawMulButtons(MulButton mulButton = null, TogglableMulButton togglableMulButton = null)
        {
            Rect menuBg = rect;
            if (mulButton != null)
            {
                int btnY = mulButton.position;
                if (GUI.Button(new Rect(menuBg.x + widthSize - 80, menuBg.y + btnY, 40, 40), "-", Styles.OffStyle))
                {
                    mulButton.DecreaseAction();
                }
                if (GUI.Button(new Rect(menuBg.x + widthSize - 35, menuBg.y + btnY, 40, 40), "+", Styles.OffStyle))
                {
                    mulButton.IncreaseAction();
                }
            }
            else if (togglableMulButton != null)
            {
                int btnY = togglableMulButton.position;
                if (GUI.Button(new Rect(menuBg.x + widthSize - 80, menuBg.y + btnY, 40, 40), "-", Styles.OffStyle))
                {
                    togglableMulButton.DecreaseAction();
                }
                if (GUI.Button(new Rect(menuBg.x + widthSize - 35, menuBg.y + btnY, 40, 40), "+", Styles.OffStyle))
                {
                    togglableMulButton.IncreaseAction();
                }
            }
        }

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
                }
                ifDragged = false;
            }
            GUI.DragWindow();
        }
    }
}
