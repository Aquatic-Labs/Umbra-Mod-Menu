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
                        menu.AddButton(new Button(menu, 2, "<color=yellow>Buttons will be availble in game.</color>", Styles.LabelStyle, justText: true));
                        menu.AddButton(new Button(menu, 3, "<color=#11ccee>Created By Neonix#1337.\n Feel Free to Message me on discord.</color>", Styles.LabelStyle, justText: true));
                        menu.AddButton(new Button(menu, 4, "<color=#11ccee>Download the latest version on my github.\nAcher0ns/Umbra-Mod-Menu</color>", Styles.LabelStyle, justText: true));
                    }

                    if (Loader.upToDate || Loader.devBuild)
                    {
                        menu.AddButton(new Button(menu, 2, "<color=yellow>Buttons will be availble in game.</color>", Styles.LabelStyle, justText: true));
                        menu.AddButton(new Button(menu, 3, "<color=#11ccee>Created By Neonix#1337.\n Feel Free to Message me on discord.</color>", Styles.LabelStyle, justText: true));
                        menu.AddButton(new Button(menu, 4, "<color=#11ccee>with bug Reports or suggestions.</color>", Styles.LabelStyle, justText: true));
                    }
                }
                if (UmbraMenu._CharacterCollected)
                {
                    Button togglePlayer = new Button(menu, 1, "P L A Y E R : O F F", Styles.BtnStyle, togglable: true, onText: "P L A Y E R : O N");
                    Button toggleMovement = new Button(menu, 2, "M O V E M E N T : O F F", Styles.BtnStyle, togglable: true, onText: "M O V E M E N T : O N");
                    Button toggleItems = new Button(menu, 3, "I T E M S : O F F", Styles.BtnStyle, togglable: true, onText: "I T E M S : O N");
                    Button toggleSpawn = new Button(menu, 4, "S P A W N : O F F", Styles.BtnStyle, togglable: true, onText: "S P A W N : O N");
                    Button toggleTeleporter = new Button(menu, 5, "T E L E P O R T E R : O F F", Styles.BtnStyle, togglable: true, onText: "T E L E P O R T E R : O N");
                    Button toggleESP = new Button(menu, 6, "R E N D E R : O F F", Styles.BtnStyle, togglable: true, onText: "R E N D E R: O N");
                    Button toggleLobby = new Button(menu, 7, "", Styles.BtnStyle, togglable: true);
                    Button unloadMenu = new Button(menu, 8, "", Styles.BtnStyle, togglable: true);
                    Button unloadConfirm = new Button(menu, 8, "", Styles.BtnStyle, togglable: true);

                    menu.AddButton(togglePlayer);
                    menu.AddButton(toggleMovement);
                    menu.AddButton(toggleItems);
                    menu.AddButton(toggleSpawn);
                    menu.AddButton(toggleTeleporter);
                    menu.AddButton(toggleESP);

                    if (toggleLobby.enabled)
                    {
                        menu.AddButton(toggleLobby);
                        DrawButton(7, "main", "L O B B Y : O N", OnStyle);
                    }
                    else
                    {
                        menu.AddButton(toggleLobby);
                        DrawButton(7, "main", "L O B B Y : O F F", OffStyle);
                    }

                    if (unloadConfirm.enabled)
                    {
                        menu.AddButton(unloadConfirm);
                        DrawButton(8, "main", "C O N F I R M ?", ButtonStyle);
                    }
                    else
                    {
                        menu.AddButton(unloadConfirm);
                        DrawButton(8, "main", "U N L O A D   M E N U", ButtonStyle);
                    }
                }
            }
        }
    }
}
