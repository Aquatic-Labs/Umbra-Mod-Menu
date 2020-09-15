using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UmbraMenu.MenuButtons
{
    class Movement
    {
        private static readonly Menu currentMenu = Utility.FindMenuById(2);

        public static TogglableButton toggleAlwaysSprint = new TogglableButton(currentMenu, 4, "S P A W N : O F F", "S P A W N : O N", null, null);
        public static TogglableButton toggleFlight = new TogglableButton(currentMenu, 5, "T E L E P O R T E R : O F F", "T E L E P O R T E R : O N", null, null);
        public static TogglableButton toggleJumpPack = new TogglableButton(currentMenu, 6, "R E N D E R : O F F", "R E N D E R: O N", null, null);

        public static List<Button> buttons = new List<Button>()
        {
            Button.ConvertTogglableButtonToButton(toggleAlwaysSprint),
            Button.ConvertTogglableButtonToButton(toggleFlight),
            Button.ConvertTogglableButtonToButton(toggleJumpPack)
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
