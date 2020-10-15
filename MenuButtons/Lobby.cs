using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UmbraMenu.MenuButtons
{
    public class Lobby
    {
        private static readonly Menu currentMenu = (Menu)Utility.FindMenuById(1);

        public static Button Player1 = new Button(currentMenu, 1, "P L A Y E R   O N E", null);
        public static Button Player2 = new Button(currentMenu, 2, "P L A Y E R   T W O", null);
        public static Button Player3 = new Button(currentMenu, 3, "P L A Y E R   T H R E E", null);
        public static Button Player4 = new Button(currentMenu, 4, "P L A Y E R   F O U R", null);

        public static List<Buttons> buttons = new List<Buttons>();

        public static void AddButtonsToMenu()
        {
            currentMenu.buttons = buttons;
        }
    }
}
