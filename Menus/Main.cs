using System.Collections.Generic;
using UnityEngine;

namespace UmbraMenu.Menus
{
    public sealed class Main : Menu
    {
        private static readonly IMenu main = new NormalMenu(0, new Rect(10, 10, 20, 20), "UMBRA MENU");

        public Main() : base(main)
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
                Button togglePlayer = new Button(new TogglableButton(this, 1, "PLAYER : OFF", "PLAYER : ON", PlayerButtonAction, PlayerButtonAction));
                Button toggleMovement = new Button(new TogglableButton(this, 2, "MOVEMENT : OFF", "MOVEMENT : ON", MovementButtonAction, MovementButtonAction));
                Button toggleItems = new Button(new TogglableButton(this, 3, "ITEMS : OFF", "ITEMS : ON", ItemsButtonAction, ItemsButtonAction));
                Button toggleSpawn = new Button(new TogglableButton(this, 4, "SPAWN : OFF", "SPAWN : ON", SpawnButtonAction, SpawnButtonAction));
                Button toggleTeleporter = new Button(new TogglableButton(this, 5, "TELEPORTER : OFF", "TELEPORTER : ON", TeleporterButtonAction, TeleporterButtonAction));
                Button toggleRender = new Button(new TogglableButton(this, 6, "RENDER : OFF", "RENDER: ON", RenderButtonAction, RenderButtonAction));
                Button toggleSettings = new Button(new TogglableButton(this, 7, "SETTINGS : OFF", "SETTINGS : ON", SettingsButtonAction, SettingsButtonAction));
                Button unloadMenu = new Button(new TogglableButton(this, 8, "UNLOAD MENU", "CONFIRM?", DoNothing, UnloadMenu));

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
                    Button text1 = new Button(new TextButton(this, 2, "<color=yellow>Buttons will be availble in game.</color>"));
                    AddButtons(new List<Button>
                    {
                        text1,
                    });
                }

                if (Loader.upToDate || Loader.devBuild)
                {
                    Button text1 = new Button(new TextButton(this, 2, "<color=yellow>Buttons will be availble in game.</color>"));
                    AddButtons(new List<Button>
                    {
                        text1,
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
