using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UmbraMenu.MenuButtons
{
    public static class Main
    {
        private static readonly Menu currentMenu = (Menu)Utility.FindMenuById(0);

        private static void PlayerButtonAction() => ToggleMenu(UmbraMenu.menus[1]);
        private static void MovementButtonAction() => ToggleMenu(UmbraMenu.menus[2]);
        private static void ItemsButtonAction() => ToggleMenu(UmbraMenu.menus[3]);
        private static void SpawnButtonAction() => ToggleMenu(UmbraMenu.menus[4]);
        private static void TeleporterButtonAction() => ToggleMenu(UmbraMenu.menus[5]);
        private static void RenderButtonAction() => ToggleMenu(UmbraMenu.menus[6]);
        private static void SettingsButtonAction() => ToggleMenu(UmbraMenu.menus[7]);
        private static void UnloadMenu() => Loader.Unload();

        private static void DoNothing() => Utility.StubbedFunction();

        public static TogglableButton togglePlayer = new TogglableButton(currentMenu, 1, "P L A Y E R : O F F", "P L A Y E R : O N", PlayerButtonAction, PlayerButtonAction);
        public static TogglableButton toggleMovement = new TogglableButton(currentMenu, 2, "M O V E M E N T : O F F", "M O V E M E N T : O N", MovementButtonAction, MovementButtonAction);
        public static TogglableButton toggleItems = new TogglableButton(currentMenu, 3, "I T E M S : O F F", "I T E M S : O N", ItemsButtonAction, ItemsButtonAction);
        public static TogglableButton toggleSpawn = new TogglableButton(currentMenu, 4, "S P A W N : O F F", "S P A W N : O N", SpawnButtonAction, SpawnButtonAction);
        public static TogglableButton toggleTeleporter = new TogglableButton(currentMenu, 5, "T E L E P O R T E R : O F F", "T E L E P O R T E R : O N", TeleporterButtonAction, TeleporterButtonAction);
        public static TogglableButton toggleRender = new TogglableButton(currentMenu, 6, "R E N D E R : O F F", "R E N D E R: O N", RenderButtonAction, RenderButtonAction);
        public static TogglableButton toggleSettings = new TogglableButton(currentMenu, 7, "L O B B Y : O F F", "L O B B Y : O N", SettingsButtonAction, SettingsButtonAction);
        public static TogglableButton unloadMenu = new TogglableButton(currentMenu, 8, "U N L O A D   M E N U", "C O N F I R M ?", DoNothing, UnloadMenu);

        private static List<Buttons> buttons = new List<Buttons>()
        {
            togglePlayer,
            toggleMovement,
            toggleItems,
            toggleSpawn,
            toggleTeleporter,
            toggleRender,
            toggleSettings,
            unloadMenu
        };

        public static void AddButtonsToMenu()
        {
            currentMenu.buttons = buttons;
        }

        public static void ToggleMenu(Menu menu)
        {
            menu.enabled = !menu.enabled;
        }
    }
}
