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

        public void AddButton(int position, string buttonText, bool isMulButton = false, bool justText = false)
        {
            numberOfButtons = position;
            Rect buttonRect;
            Rect menuBg = rect;
            int btnY = 5 + 45 * numberOfButtons;
            if (isMulButton)
            {
                buttonRect = new Rect(menuBg.x + 5, menuBg.y + btnY, widthSize - 90, 40);
            }
            else
            {
                buttonRect = new Rect(menuBg.x + 5, menuBg.y + btnY, widthSize, 40);
            }

            if (justText && isMulButton)
            {
                throw new Exception($"justText and isMultButton cannot both be true. Thrown in \"{buttonText}\" button.");
            }
            else if (justText)
            {
                GUI.Button(buttonRect, buttonText, Styles.BtnStyle);
            }
            else if (isMulButton)
            {
                if (GUI.Button(buttonRect, buttonText, Styles.BtnStyle))
                {
                    
                }
                if (GUI.Button(new Rect(menuBg.x + widthSize - 80, menuBg.y + btnY, 40, 40), "-", Styles.OffStyle))
                {
                    DecreaseValue(id);
                }
                if (GUI.Button(new Rect(menuBg.x + widthSize - 35, menuBg.y + btnY, 40, 40), "+", Styles.OffStyle))
                {
                    IncreaseValue(id);
                }
            }
            else
            {
                if (GUI.Button(buttonRect, buttonText, Styles.StatsStyle))
                {
                    
                }
            }
        }

        private void DecreaseValue(int id)
        {

        }

        private void IncreaseValue(int id)
        {

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
