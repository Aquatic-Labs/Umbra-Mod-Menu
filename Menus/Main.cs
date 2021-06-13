using System.Collections.Generic;
using UnityEngine;

namespace UmbraMenu.Menus
{
    public sealed class Main : NormalMenu
    {
        public Main() : base(0, 0, new Rect(10, 10, 20, 20), "UMBRA MENU")
        {
            if (Loader.updateAvailable)
            {
                SetTitle($"UMBRA\n<color=yellow>OUTDATED</color>");
            }
            else if (Loader.upToDate)
            {
                SetTitle($"UMBRA\n<color=grey>v{UmbraMenu.VERSION}</color>");
            }
            else if (Loader.devBuild)
            {
                SetTitle($"UMBRA\n<color=yellow>DEV</color>");
            }

            if (UmbraMenu.characterCollected || UmbraMenu.forceFullModMenu)
            {
                TogglableButton togglePlayer = new TogglableButton(this, 1, "PLAYER : OFF", "PLAYER : ON", PlayerButtonAction, PlayerButtonAction);
                TogglableButton toggleMovement = new TogglableButton(this, 2, "MOVEMENT : OFF", "MOVEMENT : ON", MovementButtonAction, MovementButtonAction);
                TogglableButton toggleItems = new TogglableButton(this, 3, "ITEMS : OFF", "ITEMS : ON", ItemsButtonAction, ItemsButtonAction);
                TogglableButton toggleSpawn = new TogglableButton(this, 4, "SPAWN : OFF", "SPAWN : ON", SpawnButtonAction, SpawnButtonAction);
                TogglableButton toggleTeleporter = new TogglableButton(this, 5, "TELEPORTER : OFF", "TELEPORTER : ON", TeleporterButtonAction, TeleporterButtonAction);
                TogglableButton toggleRender = new TogglableButton(this, 6, "RENDER : OFF", "RENDER: ON", RenderButtonAction, RenderButtonAction);
                TogglableButton toggleSettings = new TogglableButton(this, 7, "SETTINGS : OFF", "SETTINGS : ON", SettingsButtonAction, SettingsButtonAction);
                TogglableButton unloadMenu = new TogglableButton(this, 8, "UNLOAD MENU", "CONFIRM?", DoNothing, UnloadMenu);

                AddButtons(new List<Button>
                {
                    togglePlayer,
                    toggleMovement,
                    toggleItems,
                    toggleSpawn,
                    toggleTeleporter,
                    toggleRender,
                    toggleSettings,
                    unloadMenu
                });
            }
            else
            {
                if (Loader.updateAvailable)
                {
                    TextButton text1 = new TextButton(this, 2, "<color=yellow>Buttons will be availble in game.</color>");
                    TextButton text2 = new TextButton(this, 3, "<color=#11ccee>Created By Neonix#1337 and Snow#8008.\n Feel Free to Message me on discord.</color>");
                    TextButton text3 = new TextButton(this, 4, "<color=#11ccee>Download the latest version on my github.\nAcher0ns/Umbra-Mod-Menu</color>");
                    AddButtons(new List<Button>
                    {
                        text1,
                        text2,
                        text3
                    });
                }

                if (Loader.upToDate || Loader.devBuild)
                {
                    TextButton text1 = new TextButton(this, 2, "<color=yellow>Buttons will be availble in game.</color>");
                    TextButton text2 = new TextButton(this, 3, "<color=#11ccee>Created By Neonix#1337 and Snow#8008.\n Feel Free to Message me on discord.</color>");
                    TextButton text3 = new TextButton(this, 4, "<color=#11ccee>with bug Reports or suggestions.</color>");
                    AddButtons(new List<Button>
                    {
                        text1,
                        text2,
                        text3
                    });
                }
            }
        }

        public override void Draw()
        {
            SetWindow();
            if (IsEnabled())
            {
                base.Draw();
            }
        }

        private static void PlayerButtonAction() => UmbraMenu.menus[1].ToggleMenu();
        private static void MovementButtonAction() => UmbraMenu.menus[2].ToggleMenu();
        private static void ItemsButtonAction() => UmbraMenu.menus[3].ToggleMenu();
        private static void SpawnButtonAction() => UmbraMenu.menus[4].ToggleMenu();
        private static void TeleporterButtonAction() => UmbraMenu.menus[5].ToggleMenu();
        private static void RenderButtonAction() => UmbraMenu.menus[6].ToggleMenu();
        private static void SettingsButtonAction() => UmbraMenu.menus[7].ToggleMenu();
        private static void UnloadMenu() => Loader.Unload();
        private static void DoNothing() => Utility.StubbedFunction();
    }
}
