using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UmbraMenu.MenuButtons
{
    class Spawn
    {
        private static readonly Menu currentMenu = Utility.FindMenuById(4);

        public static MulButton minDistance = new MulButton(currentMenu, 1, "P L A Y E R : O F F", "P L A Y E R : O N", null, null, null);
        public static MulButton maxDistance = new MulButton(currentMenu, 2, "M O V E M E N T : O F F", "M O V E M E N T : O N", null, null, null);
        public static MulButton teamIndex = new MulButton(currentMenu, 3, "I T E M S : O F F", "I T E M S : O N", null, null, null);
        public static TogglableButton toggleSpawnListMenu = new TogglableButton(currentMenu, 4, "S P A W N : O F F", "S P A W N : O N", null, null);
        public static Button killAll = new Button(currentMenu, 5, "T E L E P O R T E R : O F F", null);
        public static Button destroyInteractables = new Button(currentMenu, 6, "R E N D E R : O F F", null);

        public static List<Button> buttons = new List<Button>()
        {
            Button.ConvertMulButtonToButton(minDistance),
            Button.ConvertMulButtonToButton(maxDistance),
            Button.ConvertMulButtonToButton(teamIndex),
            Button.ConvertTogglableButtonToButton(toggleSpawnListMenu),
            killAll,
            destroyInteractables
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
