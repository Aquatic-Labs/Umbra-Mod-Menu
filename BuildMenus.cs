using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UmbraMenu
{
    public class BuildMenus
    {
        public static void BuildMainMenu(Menu menu)
        {
            if (menu.enabled)
            {
                menu.DrawMenu();
                if (!UmbraMenu._CharacterCollected)
                {
                    if (Loader.updateAvailable)
                    {
                        menu.AddText(new Text(menu, 2, "<color=yellow>Buttons will be availble in game.</color>"));
                        menu.AddText(new Text(menu, 3, "<color=#11ccee>Created By Neonix#1337.\n Feel Free to Message me on discord.</color>"));
                        menu.AddText(new Text(menu, 4, "<color=#11ccee>Download the latest version on my github.\nAcher0ns/Umbra-Mod-Menu</color>"));
                    }

                    if (Loader.upToDate || Loader.devBuild)
                    {
                        menu.AddText(new Text(menu, 2, "<color=yellow>Buttons will be availble in game.</color>"));
                        menu.AddText(new Text(menu, 3, "<color=#11ccee>Created By Neonix#1337.\n Feel Free to Message me on discord.</color>"));
                        menu.AddText(new Text(menu, 4, "<color=#11ccee>with bug Reports or suggestions.</color>"));
                    }
                }

                if (UmbraMenu._CharacterCollected)
                {
                    menu.AddTogglableButton(MenuButtons.Main.togglePlayer);
                    menu.AddTogglableButton(MenuButtons.Main.toggleMovement);
                    menu.AddTogglableButton(MenuButtons.Main.toggleItems);
                    menu.AddTogglableButton(MenuButtons.Main.toggleSpawn);
                    menu.AddTogglableButton(MenuButtons.Main.toggleTeleporter);
                    menu.AddTogglableButton(MenuButtons.Main.toggleRender);
                    menu.AddTogglableButton(MenuButtons.Main.toggleLobby);
                    menu.AddTogglableButton(MenuButtons.Main.unloadMenu);
                }
            }
        }

        public static void BuildPlayerMenu(Menu menu)
        {
            if (menu.enabled)
            {
                menu.SetWindow();
                menu.DrawMenu();
            }
        }
        public static void BuildMovementMenu(Menu menu)
        {
            if (menu.enabled)
            {
                menu.SetWindow();
                menu.DrawMenu();
            }
        }

        public static void BuildItemMenu(Menu menu)
        {
            if (menu.enabled)
            {
                menu.SetWindow();
                menu.DrawMenu();
            }
        }

        public static void BuildSpawnMenu(Menu menu)
        {
            if (menu.enabled)
            {
                menu.SetWindow();
                menu.DrawMenu();
            }
        }

        public static void BuildTeleporterMenu(Menu menu)
        {
            if (menu.enabled)
            {
                menu.SetWindow();
                menu.DrawMenu();
            }
        }

        public static void BuildRenderMenu(Menu menu)
        {
            if (menu.enabled)
            {
                menu.SetWindow();
                menu.DrawMenu();
            }
        }

        public static void BuildLobbyMenu(Menu menu)
        {
            if (menu.enabled)
            {
                menu.SetWindow();
                menu.DrawMenu();
            }
        }
    }
}
