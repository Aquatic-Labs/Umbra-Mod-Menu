using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UmbraMenu.MenuButtons
{
    public class Spawn
    {
        private static readonly Menu currentMenu = Utility.FindMenuById(4);

        public static MulButton minDistance = new MulButton(currentMenu, 1, $"M I N   D I S T A N C E : ", null, null, null);
        public static MulButton maxDistance = new MulButton(currentMenu, 2, $"M A X   D I S T A N C E : ", null, null, null);
        public static MulButton teamIndex = new MulButton(currentMenu, 3, $"T E A M : ", null, null, null);
        public static TogglableButton toggleSpawnListMenu = new TogglableButton(currentMenu, 4, "S P A W N   L I S T : O F F", "S P A W N   L I S T : O N", null, null);
        public static Button killAll = new Button(currentMenu, 5, "K I L L   A L L", null);
        public static Button destroyInteractables = new Button(currentMenu, 6, "D E S T R O Y   I N T E R A C T A B L E S", null);

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
