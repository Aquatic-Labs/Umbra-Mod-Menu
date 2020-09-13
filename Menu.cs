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
        public LinkedList<Button> buttons = new LinkedList<Button>();

        public void AddButton(Button button)
        {
            numberOfButtons = button.position;
            Rect menuBg = rect;
            int btnY = 5 + 45 * numberOfButtons;
            if (button.isMulButton)
            {
                button.buttonRect = new Rect(menuBg.x + 5, menuBg.y + btnY, widthSize - 90, 40);
            }
            else
            {
                button.buttonRect = new Rect(menuBg.x + 5, menuBg.y + btnY, widthSize, 40);
            }

            if (button.justText && button.isMulButton)
            {
                throw new Exception($"justText and isMulButton cannot both be true. Thrown in \"{button.buttonText}\" button.");
            }
            else if (button.justText)
            {
                GUI.Button(button.buttonRect, button.buttonText, button.defaultStyle);
            }
            else if (button.togglable)
            {
                if (button.enabled)
                {
                    if (GUI.Button(button.buttonRect, button.onText, Styles.OnStyle))
                    {
                        button.OnAction();
                    }
                    if (button.isMulButton)
                    {
                        DrawMulButtons(button);
                    }
                }
                else
                {
                    if (GUI.Button(button.buttonRect, button.buttonText, Styles.OffStyle))
                    {
                        button.buttonAction();
                    }
                    if (button.isMulButton)
                    {
                        DrawMulButtons(button);
                    }
                }
            }
            else
            {
                if (GUI.Button(button.buttonRect, button.buttonText, button.defaultStyle))
                {
                    button.buttonAction();
                }
                if (button.isMulButton)
                {
                    DrawMulButtons(button);
                }
            }
            buttons.AddLast(button);
        }

        private void DrawMulButtons(Button button)
        {
            Rect menuBg = button.parentMenu.rect;
            int btnY = button.position;
            if (GUI.Button(new Rect(menuBg.x + widthSize - 80, menuBg.y + btnY, 40, 40), "-", Styles.OffStyle))
            {
                button.DecreaseAction();
            }
            if (GUI.Button(new Rect(menuBg.x + widthSize - 35, menuBg.y + btnY, 40, 40), "+", Styles.OffStyle))
            {
                button.IncreaseAction();
            }
        }

        private void SetWindow()
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
                SetWindow();
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
