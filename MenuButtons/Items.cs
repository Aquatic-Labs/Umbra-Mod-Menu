using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UmbraMenu.MenuButtons
{
    public class Items
    {
        private static readonly Menu currentMenu = Utility.FindMenuById(3);

        public static MulButton giveAllItems = new MulButton(currentMenu, 1, $"G I V E   A L L   I T E M S : ", null, null, null);
        public static MulButton rollItems = new MulButton(currentMenu, 2, $"R O L L   I T E M S : ", null, null, null);
        public static TogglableButton toggleItemListMenu = new TogglableButton(currentMenu, 3, "I T E M   S P A W N   M E N U : O F F", "I T E M   S P A W N   M E N U : O N", null, null);
        public static TogglableButton toggleEquipmentListMenu = new TogglableButton(currentMenu, 4, "E Q U I P M E N T   S P A W N   M E N U : O F F", "E Q U I P M E N T   S P A W N   M E N U : O N", null, null);
        public static TogglableButton toggleDropItems = new TogglableButton(currentMenu, 5, "D R O P   I T E M S / E Q U I P M E N T : O F F", "D R O P   I T E M S / E Q U I P M E N T : O N", null, null);
        public static TogglableButton toggleDropInvItems = new TogglableButton(currentMenu, 6, "D R O P   F R O M   I N V E N T O R Y : O F F", "D R O P   F R O M   I N V E N T O R Y : O N", null, null);
        public static TogglableButton toggleEquipmentCD = new TogglableButton(currentMenu, 7, "I N F I N I T E   E Q U I P M E N T : O F F", "I N F I N I T E   E Q U I P M E N T : O N", null, null);
        public static Button stackInventory = new Button(currentMenu, 8, "S T A C K   I N V E N T O R Y", null);
        public static Button clearInventory = new Button(currentMenu, 9, "C L E A R   I N V E N T O R Y", null);
        public static TogglableButton toggleChestItemMenu = new TogglableButton(currentMenu, 10, "C H A N G E   C H E S T   I T E M : O F F", "C H A N G E   C H E S T   I T E M : O N", null, null);

        public static List<Button> buttons = new List<Button>()
        {
            Button.ConvertMulButtonToButton(giveAllItems),
            Button.ConvertMulButtonToButton(rollItems),
            Button.ConvertTogglableButtonToButton(toggleItemListMenu),
            Button.ConvertTogglableButtonToButton(toggleEquipmentListMenu),
            Button.ConvertTogglableButtonToButton(toggleDropItems),
            Button.ConvertTogglableButtonToButton(toggleDropInvItems),
            Button.ConvertTogglableButtonToButton(toggleEquipmentCD),
            stackInventory,
            clearInventory,
            Button.ConvertTogglableButtonToButton(toggleChestItemMenu)
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
