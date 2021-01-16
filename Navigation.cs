using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace UmbraMenu
{
    static class Navigation
    {
        public static int menuIndex = 0;
        public static int buttonIndex = 0;
        public static int prevButtonIndex;

        public static void PressBtn(int menuId, int btnId)
        {

            Button button = Utility.FindButtonById(menuId, btnId);
            button?.GetAction()?.Invoke();
            button.ToggleButton();
            if (menuIndex != 9)
            {
                prevButtonIndex = buttonIndex;
            }
            if (menuIndex == 9)
            {
                menuIndex = 8;
            }
        }

        public static void IncreaseValue(int menuId, int btnId)
        {
            Utility.FindButtonById(menuId, btnId)?.GetIncreaseAction()?.Invoke();
        }

        public static void DecreaseValue(int menuId, int btnId)
        {
            Utility.FindButtonById(menuId, btnId)?.GetDecreaseAction()?.Invoke();
        }

        public static void GoBackAMenu()
        {
            if (menuIndex == 0 && buttonIndex == 8)
            {
                Utility.FindButtonById(0, 8).SetEnabled(false);
                return;
            }
            else if (menuIndex == 0)
            {
                UmbraMenu.navigationToggle = false;
                menuIndex = 0;
                buttonIndex = 0;
                return;
            }
            else if (menuIndex == 1 && buttonIndex == 11)
            {
                Utility.FindButtonById(1, 11).SetEnabled(false);
                return;
            }


            if (!UmbraMenu.lowResolutionMonitor)
            {
                Menu menu = Utility.FindMenuById(menuIndex);
                menu.SetEnabled(false);
                menuIndex = menu.GetPrevMenuId();
                buttonIndex = prevButtonIndex;
            }
            else
            {
                Menu menu = Utility.FindMenuById(menuIndex);
                menu.SetEnabled(false);
                bool mainMenusIndex = Enumerable.Range(1, 7).Contains(menuIndex);
                if (mainMenusIndex)
                {
                    menuIndex = menu.GetPrevMenuId();
                }
                else
                {
                    Utility.FindMenuById(menu.GetPrevMenuId()).SetEnabled(true);
                }
                buttonIndex = prevButtonIndex;
            }
        }

        public static GUIStyle HighlighedCheck(GUIStyle defaultStyle, int currentMenu, int currentBtn)
        {
            if (UmbraMenu.navigationToggle)
            {
                if (currentBtn == buttonIndex && currentMenu == menuIndex)
                {
                    return Styles.HighlightBtnStyle;
                }
                else
                {
                    return defaultStyle;
                }
            }
            return defaultStyle;
        }

        public static void UpdateIndexValues()
        {
            Menu menu = Utility.FindMenuById(menuIndex);
            int menuLength = menu.GetNumberOfButtons();
            bool listMenuHighlighted = Enumerable.Range(10, 17).Contains(menuIndex);

            if (!UmbraMenu.scrolled && listMenuHighlighted)
            {
                menu.SetScrollPosition(new Vector2(0, 40 * (buttonIndex - 1)));
            }

            if (buttonIndex > menuLength)
            {
                buttonIndex = 1;
                if (!UmbraMenu.scrolled && listMenuHighlighted)
                {
                    menu.SetScrollPosition(Vector2.zero);
                }

            }
            if (buttonIndex < 1)
            {
                buttonIndex = menuLength;
                if (!UmbraMenu.scrolled && listMenuHighlighted)
                {
                    menu.SetScrollPosition(new Vector2(0, menu.GetNumberOfButtons() * 40));
                }
            }
        }
    }
}
