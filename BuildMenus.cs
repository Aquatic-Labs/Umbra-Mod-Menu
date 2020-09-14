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
                    void PlayerButtonAction() => ButtonActions.MainMenu.ToggleMenu(UmbraMenu.menus[1]);

                    void UnloadMenu() => Loader.Unload();
                    TogglableButton togglePlayer = new TogglableButton(menu, 1, "P L A Y E R : O F F", "P L A Y E R : O N", Styles.BtnStyle, OffAction: PlayerButtonAction, OnAction: PlayerButtonAction);
                    TogglableButton toggleMovement = new TogglableButton(menu, 2, "M O V E M E N T : O F F", "M O V E M E N T : O N", Styles.BtnStyle, null, null);
                    TogglableButton toggleItems = new TogglableButton(menu, 3, "I T E M S : O F F", "I T E M S : O N", Styles.BtnStyle, null, null);
                    TogglableButton toggleSpawn = new TogglableButton(menu, 4, "S P A W N : O F F", "S P A W N : O N", Styles.BtnStyle, null, null);
                    TogglableButton toggleTeleporter = new TogglableButton(menu, 5, "T E L E P O R T E R : O F F", "T E L E P O R T E R : O N", Styles.BtnStyle, null, null);
                    TogglableButton toggleESP = new TogglableButton(menu, 6, "R E N D E R : O F F", "R E N D E R: O N", Styles.BtnStyle, null, null);
                    TogglableButton toggleLobby = new TogglableButton(menu, 7, "L O B B Y : O F F", "L O B B Y : O N", Styles.BtnStyle, null, null);
                    TogglableButton unloadMenu = new TogglableButton(menu, 8, "U N L O A D   M E N U", "C O N F I R M ?", Styles.OffStyle, null, UnloadMenu);

                    menu.AddTogglableButton(togglePlayer);
                    menu.AddTogglableButton(toggleMovement);
                    menu.AddTogglableButton(toggleItems);
                    menu.AddTogglableButton(toggleSpawn);
                    menu.AddTogglableButton(toggleTeleporter);
                    menu.AddTogglableButton(toggleESP);
                    menu.AddTogglableButton(toggleLobby);
                    menu.AddTogglableButton(unloadMenu);
                }
            }
        }

        public static void BuildPlayerMenu(Menu menu)
        {
            if (menu.enabled)
            {
                menu.SetWindow();
                menu.DrawMenu();
                menu.AddButton(new Button(menu, 1, "Test Player Button", Styles.BtnStyle, null));
            }
        }
    }
}
