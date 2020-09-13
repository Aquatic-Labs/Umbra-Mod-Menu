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
                        menu.AddButton(2, "<color=yellow>Buttons will be availble in game.</color>", justText: true);
                        menu.AddButton(3, "<color=#11ccee>Created By Neonix#1337.\n Feel Free to Message me on discord.</color>", justText: true);
                        menu.AddButton(4, "<color=#11ccee>Download the latest version on my github.\nAcher0ns/Umbra-Mod-Menu</color>", justText: true);
                    }

                    if (Loader.upToDate || Loader.devBuild)
                    {
                        menu.AddButton(2, "<color=yellow>Buttons will be availble in game.</color>", justText: true);
                        menu.AddButton(3, "<color=#11ccee>Created By Neonix#1337.\n Feel Free to Message me on discord.</color>", justText: true);
                        menu.AddButton(4, "<color=#11ccee>with bug Reports or suggestions.</color>", justText: true);
                    }
                }
                if (UmbraMenu._CharacterCollected)
                {
                    menu.AddButton(2, "<color=red>ThIS IS A SUCCESS?</color>", justText: true);
                    menu.AddButton(3, "<color=#11ccee>Created By Neonix#1337.\n Feel Free to Message me on discord.</color>", justText: true);
                    menu.AddButton(4, "<color=#11ccee>with bug Reports or suggestions.</color>", justText: true);
                }
            }
        }
    }
}
