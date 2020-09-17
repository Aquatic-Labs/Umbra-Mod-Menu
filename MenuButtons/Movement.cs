using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UmbraMenu.MenuButtons
{
    public class Movement
    {
        private static readonly Menu currentMenu = Utility.FindMenuById(2);

        public static TogglableButton toggleAlwaysSprint = new TogglableButton(currentMenu, 1, "A L W A Y S   S P R I N T : O F F", "A L W A Y S   S P R I N T : O N", null, null);
        public static TogglableButton toggleFlight = new TogglableButton(currentMenu, 2, "F L I G H T : O F F", "F L I G H T : O N", null, null);
        public static TogglableButton toggleJumpPack = new TogglableButton(currentMenu, 3, "J U M P - P A C K : O F F", "J U M P - P A C K : O N", null, null);

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
