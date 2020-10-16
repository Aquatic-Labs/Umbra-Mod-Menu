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
                if (!UmbraMenu.characterCollected)
                {
                    if (Loader.updateAvailable)
                    {
                        new Text(menu, 2, "<color=yellow>Buttons will be availble in game.</color>").Add();
                        new Text(menu, 3, "<color=#11ccee>Created By Neonix#1337.\n Feel Free to Message me on discord.</color>").Add();
                        new Text(menu, 4, "<color=#11ccee>Download the latest version on my github.\nAcher0ns/Umbra-Mod-Menu</color>").Add();
                    }

                    if (Loader.upToDate || Loader.devBuild)
                    {
                        new Text(menu, 2, "<color=yellow>Buttons will be availble in game.</color>").Add();
                        new Text(menu, 3, "<color=#11ccee>Created By Neonix#1337.\n Feel Free to Message me on discord.</color>").Add();
                        new Text(menu, 4, "<color=#11ccee>with bug Reports or suggestions.</color>").Add();
                    }
                }

                if (UmbraMenu.characterCollected)
                {
                    menu.DrawAllButtons();
                }
            }
        }

        public static void BuildPlayerMenu(Menu menu)
        {
            menu.activatingButton = MenuButtons.Main.togglePlayer;
            if (menu.enabled)
            {
                menu.SetWindow();
                menu.DrawMenu();
                menu.DrawAllButtons();
            }
        }

        public static void BuildMovementMenu(Menu menu)
        {
            menu.activatingButton = MenuButtons.Main.toggleMovement;
            if (menu.enabled)
            {
                menu.SetWindow();
                menu.DrawMenu();
                menu.DrawAllButtons();
            }
        }

        public static void BuildItemMenu(Menu menu)
        {
            menu.activatingButton = MenuButtons.Main.toggleItems;
            if (menu.enabled)
            {
                menu.SetWindow();
                menu.DrawMenu();
                menu.DrawAllButtons();
            }
        }

        public static void BuildSpawnMenu(Menu menu)
        {
            menu.activatingButton = MenuButtons.Main.toggleSpawn;
            if (menu.enabled)
            {
                menu.SetWindow();
                menu.DrawMenu();
                menu.DrawAllButtons();
            }
        }

        public static void BuildTeleporterMenu(Menu menu)
        {
            menu.activatingButton = MenuButtons.Main.toggleTeleporter;
            if (menu.enabled)
            {
                menu.SetWindow();
                menu.DrawMenu();
                menu.DrawAllButtons();
            }
        }

        public static void BuildRenderMenu(Menu menu)
        {
            menu.activatingButton = MenuButtons.Main.toggleRender;
            if (menu.enabled)
            {
                menu.SetWindow();
                menu.DrawMenu();
                menu.DrawAllButtons();
            }
        }

        public static void BuildLobbyMenu(Menu menu)
        {
            menu.activatingButton = MenuButtons.Main.toggleLobby;
            if (menu.enabled)
            {
                menu.SetWindow();
                menu.DrawMenu();
                menu.DrawAllButtons();
            }
        }

        public static void BuildStatsModMenu(Menu menu)
        {
            menu.activatingButton = MenuButtons.Player.toggleStatsMod;
            if (menu.enabled)
            {
                menu.SetWindow();
                menu.DrawMenu();
                menu.DrawAllButtons();
            }
        }

        public static void BuildCharacterListMenu(ListMenu menu)
        {
            menu.activatingButton = MenuButtons.Player.toggleChangeCharacter;
            if (menu.enabled)
            {
                menu.SetWindow();
                menu.DrawMenu();
            }
        }

        public static void BuildBuffListMenu(ListMenu menu)
        {
            menu.activatingButton = MenuButtons.Player.toggleBuff;
            if (menu.enabled)
            {
                menu.SetWindow();
                menu.DrawMenu();
            }
        }

        public static void BuildItemListMenu(ListMenu menu)
        {
            menu.activatingButton = MenuButtons.Items.toggleItemListMenu;
            if (menu.enabled)
            {
                menu.SetWindow();
                menu.DrawMenu();
            }
        }

        public static void BuildEquipmentListMenu(ListMenu menu)
        {
            menu.activatingButton = MenuButtons.Items.toggleEquipmentListMenu;
            if (menu.enabled)
            {
                menu.SetWindow();
                menu.DrawMenu();
            }
        }

        public static void BuildChestItemsListMenu(ListMenu menu)
        {
            menu.activatingButton = MenuButtons.Items.toggleChestItemMenu;
            if (menu.enabled)
            {
                menu.SetWindow();
                menu.DrawMenu();
            }
        }

        public static void BuildSpawnListMenu(ListMenu menu)
        {
            menu.activatingButton = MenuButtons.Spawn.toggleSpawnListMenu;
            if (menu.enabled)
            {
                menu.SetWindow();
                menu.DrawMenu();
            }
        }

        public static void BuildViewStatsMenu(Menu menu)
        {
            menu.activatingButton = MenuButtons.StatsMod.toggleViewStatsMenu;
            if (menu.enabled)
            {
                menu.SetWindow();
                menu.DrawMenu();
                menu.DrawAllButtons();
            }
        }
    }
}
