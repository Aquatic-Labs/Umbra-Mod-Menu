using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UmbraMenu.MenuButtons
{
    public class Render
    {
        private static readonly Menu currentMenu = Utility.FindMenuById(6);

        public static TogglableButton toggleActiveMods = new TogglableButton(currentMenu, 1, "A C T I V E   M O D S : O F F", "A C T I V E   M O D S : O N", null, null);
        public static TogglableButton toggleInteractESP = new TogglableButton(currentMenu, 2, "I N T E R A C T A B L E S   E S P : O F F", "I N T E R A C T A B L E S   E S P : O N", null, null);
        public static TogglableButton toggleMobESP = new TogglableButton(currentMenu, 3, "M O B   E S P : O F F\n<color=red>Warning: May lag/crash game </color>", "M O B   E S P : O N\n<color=red>Warning: May lag/crash game </color>", null, null);

        public static List<Button> buttons = new List<Button>()
        {
            Button.ConvertTogglableButtonToButton(toggleActiveMods),
            Button.ConvertTogglableButtonToButton(toggleInteractESP),
            Button.ConvertTogglableButtonToButton(toggleMobESP),
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
