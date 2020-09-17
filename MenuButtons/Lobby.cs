using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UmbraMenu.MenuButtons
{
    public class Lobby
    {
        private static readonly Menu currentMenu = Utility.FindMenuById(1);

        public static Button unlockAll = new Button(currentMenu, 1, "U N L O A D   M E N U", null);
        public static Button unlockAll1 = new Button(currentMenu, 2, "U N L O A D   M E N U", null);
        public static Button unlockAll2 = new Button(currentMenu, 3, "U N L O A D   M E N U", null);
        public static Button unlockAll3 = new Button(currentMenu, 4, "U N L O A D   M E N U", null);

        public static List<Button> buttons = new List<Button>()
        {
        };
    }
}
