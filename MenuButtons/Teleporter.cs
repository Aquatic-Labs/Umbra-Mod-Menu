using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UmbraMenu.MenuButtons
{
    class Teleporter
    {
        private static readonly Menu currentMenu = Utility.FindMenuById(5);

        public static Button skipStage = new Button(currentMenu, 1, "P L A Y E R : O F F", null);
        public static Button instaTele = new Button(currentMenu, 2, "M O V E M E N T : O F F", null);
        public static Button addMountain = new Button(currentMenu, 3, "I T E M S : O F F", null);
        public static Button spawnAll = new Button(currentMenu, 4, "S P A W N : O F F", null);
        public static Button spawnBlue = new Button(currentMenu, 5, "T E L E P O R T E R : O F F", null);
        public static Button spawnCele = new Button(currentMenu, 6, "R E N D E R : O F F", null);
        public static Button spawnGold = new Button(currentMenu, 7, "L O B B Y : O F F", null);

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
