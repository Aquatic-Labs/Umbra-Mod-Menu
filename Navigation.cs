using System.Linq;
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
            if (UmbraMenu.menus[menuId].GetButtons()[btnId - 1] is TogglableButton button)
            {
                button.NavUpdate();
            } 
            else
            {
                UmbraMenu.menus[menuId].GetButtons()[btnId - 1]?.GetAction()?.Invoke();
                UmbraMenu.menus[menuId].GetButtons()[btnId - 1]?.NavUpdate();
            }
        }

        public static void IncreaseValue(int menuId, int btnId)
        {
            if (UmbraMenu.menus[menuId].GetButtons()[btnId - 1] is MulButton button)
            {
                button.GetIncreaseAction().Invoke();
                button.NavMulUpdate();
            }
        }

        public static void DecreaseValue(int menuId, int btnId)
        {
            if (UmbraMenu.menus[menuId].GetButtons()[btnId - 1] is MulButton button)
            {
                button.GetDecreaseAction().Invoke();
                button.NavMulUpdate();
            }
        }

        public static void GoBackAMenu()
        {
            if (menuIndex == 0 && buttonIndex == 8)
            {
                if (UmbraMenu.menus[menuIndex].GetButtons()[buttonIndex] is TogglableButton button)
                {
                    button.SetEnabled(false);
                }
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
                if (UmbraMenu.menus[menuIndex].GetButtons()[buttonIndex] is TogglableButton button)
                {
                    button.SetEnabled(false);
                }
                return;
            }

            if (!UmbraMenu.lowResolutionMonitor)
            {
                Menu menu = UmbraMenu.menus[menuIndex];
                menu.SetEnabled(false);
                menuIndex = menu.GetPrevMenuId();
            }
            else
            {
                Menu menu = UmbraMenu.menus[menuIndex];
                menu.SetEnabled(false);
                bool mainMenusIndex = Enumerable.Range(1, 7).Contains(menuIndex);
                if (mainMenusIndex)
                {
                    menuIndex = menu.GetPrevMenuId();
                }
                else
                {
                    UmbraMenu.menus[menu.GetPrevMenuId()].SetEnabled(true);
                }
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
            int menuLength = UmbraMenu.menus[menuIndex].GetButtons().Count;
            if (UmbraMenu.menus[menuIndex] is ListMenu listMenu)
            {
                if (!UmbraMenu.scrolled)
                {
                    listMenu.SetScrollPosition(new Vector2(0, 40 * (buttonIndex - 1)));
                }

                if (buttonIndex > menuLength)
                {
                    if (!UmbraMenu.scrolled)
                    {
                        listMenu.SetScrollPosition(Vector2.zero);
                    }
                }

                if (buttonIndex < 1)
                {
                    if (!UmbraMenu.scrolled)
                    {
                        listMenu.SetScrollPosition(new Vector2(0, listMenu.GetNumberOfButtons() * 40));
                    }
                }
            }

            if (buttonIndex > menuLength)
            {
                buttonIndex = 1;
            }

            if (buttonIndex < 1)
            {
                buttonIndex = menuLength;
            }

            if (menuIndex == 9)
            {
                menuIndex = 8;
                buttonIndex = 7;
            }
        }
    }
}
