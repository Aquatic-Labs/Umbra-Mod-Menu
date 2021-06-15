using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UmbraMenu.View
{
    public static class GUIUtility
    {
        #region Menu Resets
        public static void ResetMenu()
        {
            for (int i = 0; i < UmbraModGUI.Instance.menus.Count; i++)
            {
                Menu currentMenu = UmbraModGUI.Instance.menus[i];
                currentMenu.Reset();
            }
            Model.UmbraMod.Instance.characterCollected = false;
            UmbraModGUI.Instance.scrolled = false;
            UmbraModGUI.Instance.navigationToggle = false;
            Navigation.menuIndex = 0;
            Navigation.buttonIndex = 0;
        }

        public static void CloseOpenMenus()
        {
            for (int i = 0; i < UmbraModGUI.Instance.menus.Count; i++)
            {
                if (UmbraModGUI.Instance.menus[i].GetId() != 9 && UmbraModGUI.Instance.menus[i].GetId() != 0 && UmbraModGUI.Instance.menus[i].IsEnabled())
                {
                    UmbraModGUI.Instance.menus[i].SetEnabled(false);
                }
            }
        }
        #endregion

        #region Keybind Button Utility
        public static Button GetEnabledKeybindButton()
        {
            ListMenu keybindMenu = UmbraModGUI.Instance.keybindListMenu;
            for (int i = 0; i < keybindMenu.GetNumberOfButtons(); i++)
            {
                if (keybindMenu.GetButtons()[i] is TogglableButton button && button.IsEnabled())
                {
                    return button;
                }
            }
            throw new NullReferenceException($"No buttons are enabled in the keybind menu");
        }
        #endregion

        #region Menu Utility
        public static List<Menu> GetMenusOpen()
        {
            List<Menu> openMenus = new List<Menu>();
            for (int i = 1; i < UmbraModGUI.Instance.menus.Count; i++)
            {
                if (UmbraModGUI.Instance.menus[i].IsEnabled() && UmbraModGUI.Instance.menus[i].GetId() != 9)
                {
                    openMenus.Add(UmbraModGUI.Instance.menus[i]);
                }
            }
            return openMenus;
        }

        public static bool CursorIsVisible()
        {
            for (int i = 0; i < RoR2.UI.MPEventSystem.readOnlyInstancesList.Count; i++)
            {
                var mpeventSystem = RoR2.UI.MPEventSystem.readOnlyInstancesList[i];
                if (mpeventSystem.isCursorVisible)
                {
                    return true;
                }
            }
            return false;
        }
        #endregion
    }
}
