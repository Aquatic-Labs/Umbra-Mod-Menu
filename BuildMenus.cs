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
                    //menu.AddTogglableButton(MenuButtons.Main.unloadMenu);
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
                menu.AddMulButton(MenuButtons.Player.giveMoney);
                menu.AddMulButton(MenuButtons.Player.giveCoins);
                menu.AddMulButton(MenuButtons.Player.giveExperience);
                menu.AddTogglableButton(MenuButtons.Player.toggleStatsMod);
                menu.AddTogglableButton(MenuButtons.Player.toggleChangeCharacter);
                menu.AddTogglableButton(MenuButtons.Player.toggleBuff);
                menu.AddButton(MenuButtons.Player.removeBuffs);
                menu.AddTogglableButton(MenuButtons.Player.toggleAimbot);
                menu.AddTogglableButton(MenuButtons.Player.toggleGod);
                menu.AddTogglableButton(MenuButtons.Player.toggleSkillCD);
                menu.AddButton(MenuButtons.Player.unlockAll);
            }
        }
        public static void BuildMovementMenu(Menu menu)
        {
            menu.activatingButton = MenuButtons.Main.toggleMovement;
            if (menu.enabled)
            {
                menu.SetWindow();
                menu.DrawMenu();
            }
        }

        public static void BuildItemMenu(Menu menu)
        {
            menu.activatingButton = MenuButtons.Main.toggleItems;
            if (menu.enabled)
            {
                menu.SetWindow();
                menu.DrawMenu();
            }
        }

        public static void BuildSpawnMenu(Menu menu)
        {
            menu.activatingButton = MenuButtons.Main.toggleSpawn;
            if (menu.enabled)
            {
                menu.SetWindow();
                menu.DrawMenu();
            }
        }

        public static void BuildTeleporterMenu(Menu menu)
        {
            menu.activatingButton = MenuButtons.Main.toggleTeleporter;
            if (menu.enabled)
            {
                menu.SetWindow();
                menu.DrawMenu();
            }
        }

        public static void BuildRenderMenu(Menu menu)
        {
            menu.activatingButton = MenuButtons.Main.toggleRender;
            if (menu.enabled)
            {
                menu.SetWindow();
                menu.DrawMenu();
            }
        }

        public static void BuildLobbyMenu(Menu menu)
        {
            menu.activatingButton = MenuButtons.Main.toggleLobby;
            if (menu.enabled)
            {
                menu.SetWindow();
                menu.DrawMenu();
            }
        }
    }
}
