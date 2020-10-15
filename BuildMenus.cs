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
                    /*menu.AddTogglableButton(MenuButtons.Main.togglePlayer);
                    menu.AddTogglableButton(MenuButtons.Main.toggleMovement);
                    menu.AddTogglableButton(MenuButtons.Main.toggleItems);
                    menu.AddTogglableButton(MenuButtons.Main.toggleSpawn);
                    menu.AddTogglableButton(MenuButtons.Main.toggleTeleporter);
                    menu.AddTogglableButton(MenuButtons.Main.toggleRender);
                    menu.AddTogglableButton(MenuButtons.Main.toggleLobby);
                    menu.AddTogglableButton(MenuButtons.Main.unloadMenu);*/
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
                /*.AddMulButton(MenuButtons.Player.giveMoney);
                menu.AddMulButton(MenuButtons.Player.giveCoins);
                menu.AddMulButton(MenuButtons.Player.giveExperience);
                menu.AddTogglableButton(MenuButtons.Player.toggleStatsMod);
                menu.AddTogglableButton(MenuButtons.Player.toggleChangeCharacter);
                menu.AddTogglableButton(MenuButtons.Player.toggleBuff);
                menu.AddButton(MenuButtons.Player.removeBuffs);
                menu.AddTogglableButton(MenuButtons.Player.toggleAimbot);
                menu.AddTogglableButton(MenuButtons.Player.toggleGod);
                menu.AddTogglableButton(MenuButtons.Player.toggleSkillCD);
                menu.AddButton(MenuButtons.Player.unlockAll);*/
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
                /*menu.AddTogglableButton(MenuButtons.Movement.toggleAlwaysSprint);
                menu.AddTogglableButton(MenuButtons.Movement.toggleFlight);
                menu.AddTogglableButton(MenuButtons.Movement.toggleJumpPack);*/
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
                /*menu.AddMulButton(MenuButtons.Items.giveAllItems);
                menu.AddMulButton(MenuButtons.Items.rollItems);
                menu.AddTogglableButton(MenuButtons.Items.toggleItemListMenu);
                menu.AddTogglableButton(MenuButtons.Items.toggleEquipmentListMenu);
                menu.AddTogglableButton(MenuButtons.Items.toggleDropItems);
                menu.AddTogglableButton(MenuButtons.Items.toggleDropInvItems);
                menu.AddTogglableButton(MenuButtons.Items.toggleEquipmentCD);
                menu.AddButton(MenuButtons.Items.stackInventory);
                menu.AddButton(MenuButtons.Items.clearInventory);
                menu.AddTogglableButton(MenuButtons.Items.toggleChestItemMenu);*/
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
                /*menu.AddMulButton(MenuButtons.Spawn.minDistance);
                menu.AddMulButton(MenuButtons.Spawn.maxDistance);
                menu.AddMulButton(MenuButtons.Spawn.teamIndex);
                menu.AddTogglableButton(MenuButtons.Spawn.toggleSpawnListMenu);
                menu.AddButton(MenuButtons.Spawn.killAll);
                menu.AddButton(MenuButtons.Spawn.destroyInteractables);*/
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
                /*menu.AddButton(MenuButtons.Teleporter.skipStage);
                menu.AddButton(MenuButtons.Teleporter.instaTele);
                menu.AddButton(MenuButtons.Teleporter.addMountain);
                menu.AddButton(MenuButtons.Teleporter.spawnAll);
                menu.AddButton(MenuButtons.Teleporter.spawnBlue);
                menu.AddButton(MenuButtons.Teleporter.spawnCele);
                menu.AddButton(MenuButtons.Teleporter.spawnGold);*/
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
                /*menu.AddTogglableButton(MenuButtons.Render.toggleActiveMods);
                menu.AddTogglableButton(MenuButtons.Render.toggleInteractESP);
                menu.AddTogglableButton(MenuButtons.Render.toggleMobESP);*/
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
    }
}
