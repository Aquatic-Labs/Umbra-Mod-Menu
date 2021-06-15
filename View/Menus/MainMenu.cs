using System;
using System.Collections.Generic;
using UnityEngine;
using RoR2;

namespace UmbraMenu.View
{
    public sealed class MainMenu : NormalMenu
    {
        public TogglableButton togglePlayer;
        public TogglableButton toggleMovement;
        public TogglableButton toggleItems;
        public TogglableButton toggleSpawn;
        public TogglableButton toggleTeleporter;
        public TogglableButton toggleRender;
        public TogglableButton toggleSettings;
        public TogglableButton unloadMenu;

        public MainMenu() : base(0, 0, new Rect(10, 10, 20, 20), "UMBRA MENU")
        {
            if (Loader.updateAvailable)
            {
                SetTitle($"UMBRA\n<color=yellow>OUTDATED</color>");
            }
            else if (Loader.upToDate)
            {
                SetTitle($"UMBRA\n<color=grey>v{Model.UmbraMod.VERSION}</color>");
            }
            else if (Loader.devBuild)
            {
                SetTitle($"UMBRA\n<color=yellow>DEV</color>");
            }

            togglePlayer = new TogglableButton(this, 1, "PLAYER : OFF", "PLAYER : ON", PlayerButtonAction, PlayerButtonAction);
            toggleMovement = new TogglableButton(this, 2, "MOVEMENT : OFF", "MOVEMENT : ON", MovementButtonAction, MovementButtonAction);
            toggleItems = new TogglableButton(this, 3, "ITEMS : OFF", "ITEMS : ON", ItemsButtonAction, ItemsButtonAction);
            toggleSpawn = new TogglableButton(this, 4, "SPAWN : OFF", "SPAWN : ON", SpawnButtonAction, SpawnButtonAction);
            toggleTeleporter = new TogglableButton(this, 5, "TELEPORTER : OFF", "TELEPORTER : ON", TeleporterButtonAction, TeleporterButtonAction);
            toggleRender = new TogglableButton(this, 6, "RENDER : OFF", "RENDER: ON", RenderButtonAction, RenderButtonAction);
            toggleSettings = new TogglableButton(this, 7, "SETTINGS : OFF", "SETTINGS : ON", SettingsButtonAction, SettingsButtonAction);
            unloadMenu = new TogglableButton(this, 8, "UNLOAD MENU", "CONFIRM?", () => { return; }, UnloadMenu);

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

        public override void Draw()
        {
            SetWindow();
            if (IsEnabled())
            {
                base.Draw();
            }
        }

        private static void PlayerButtonAction() => UmbraModGUI.Instance.menus[1].ToggleMenu();
        private static void MovementButtonAction() => UmbraModGUI.Instance.menus[2].ToggleMenu();
        private static void ItemsButtonAction() => UmbraModGUI.Instance.menus[3].ToggleMenu();
        private static void SpawnButtonAction() => UmbraModGUI.Instance.menus[4].ToggleMenu();
        private static void TeleporterButtonAction() => UmbraModGUI.Instance.menus[5].ToggleMenu();
        private static void RenderButtonAction() => UmbraModGUI.Instance.menus[6].ToggleMenu();
        private static void SettingsButtonAction() => UmbraModGUI.Instance.menus[7].ToggleMenu();
        private static void UnloadMenu() => Loader.Unload();
    }
}
