using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UmbraMenu.MenuButtons
{
    public class Teleporter
    {
        private static readonly Menu currentMenu = Utility.FindMenuById(5);

        public static Button skipStage = new Button(currentMenu, 1, "S K I P   S T A G E", null);
        public static Button instaTele = new Button(currentMenu, 2, "I N S T A N T   T E L E P O R T E R", null);
        public static Button addMountain = new Button(currentMenu, 3, $"A D D   M O U N T A I N - C O U N T : ", null);
        public static Button spawnAll = new Button(currentMenu, 4, "S P A W N   A L L   P O R T A L S", null);
        public static Button spawnBlue = new Button(currentMenu, 5, "S P A W N   B L U E   P O R T A L", null);
        public static Button spawnCele = new Button(currentMenu, 6, "S P A W N   C E L E S T A L   P O R T A L", null);
        public static Button spawnGold = new Button(currentMenu, 7, "S P A W N   G O L D   P O R T A L", null);

        public static List<Button> buttons = new List<Button>()
        {
            skipStage,
            instaTele,
            addMountain,
            spawnAll,
            spawnBlue,
            spawnCele,
            spawnGold
        };

        public static void ToggleMenu(Menu menu)
        {
            menu.enabled = !menu.enabled;
        }

        public static void ToggleButton(TogglableButton togglableButton)
        {

        }

        public static void ToggleMulButton(TogglableMulButton togglableMulButton)
        {

        }

        public static void PressButton(Button button)
        {

        }

        public static void PressMulButton(MulButton mulButton)
        {

        }
    }
}
