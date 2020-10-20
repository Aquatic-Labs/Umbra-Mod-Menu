using System;
using UnityEngine;

namespace UmbraMenu
{
    public class BuildMenus
    {
        public static void BuildMainMenu(Menu menu)
        {
            if (menu.enabled)
            {
                menu.DrawMenu();
                if (!UmbraMenu.characterCollected)
                {
                    if (Loader.updateAvailable)
                    {
                        new Text(menu, 2, "<color=yellow>Buttons will be availble in game.</color>").Draw();
                        new Text(menu, 3, "<color=#11ccee>Created By Neonix#1337.\n Feel Free to Message me on discord.</color>").Draw();
                        new Text(menu, 4, "<color=#11ccee>Download the latest version on my github.\nAcher0ns/Umbra-Mod-Menu</color>").Draw();
                    }

                    if (Loader.upToDate || Loader.devBuild)
                    {
                        new Text(menu, 2, "<color=yellow>Buttons will be availble in game.</color>").Draw();
                        new Text(menu, 3, "<color=#11ccee>Created By Neonix#1337.\n Feel Free to Message me on discord.</color>").Draw();
                        new Text(menu, 4, "<color=#11ccee>with bug Reports or suggestions.</color>").Draw();
                    }

                    for (int i = 0; i < UmbraMenu.menus.Count; i++)
                    {
                        if (UmbraMenu.menus[i].id != 0)
                        {
                            UmbraMenu.menus[i].enabled = false;
                        }
                    }
                }

                if (UmbraMenu.characterCollected)
                {
                    menu.DrawAllButtons();
                }
            }
        }

        public static void BuildMenu(Menu menu, TogglableButton activatingButton, Action AddButtons)
        {
            menu.activatingButton = activatingButton;
            if (menu.enabled)
            {
                AddButtons();
                menu.SetWindow();
                menu.DrawMenu();
                menu.DrawAllButtons();
            }
        }

        public static void BuildMenu(ListMenu menu, TogglableButton activatingButton, Action AddButtons)
        {
            menu.activatingButton = activatingButton;
            if (menu.enabled)
            {
                AddButtons();
                menu.SetWindow();
                menu.DrawMenu();
                menu.DrawAllButtons();
            }
        }
    }
}
