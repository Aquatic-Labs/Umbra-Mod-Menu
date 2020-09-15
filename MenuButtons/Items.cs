using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UmbraMenu.MenuButtons
{
    class Items
    {
        private static readonly Menu currentMenu = Utility.FindMenuById(3);

        public static MulButton giveAllItems = new MulButton(currentMenu, 1, "P L A Y E R : O F F", "P L A Y E R : O N", null, null, null);
        public static MulButton rollItems = new MulButton(currentMenu, 2, "M O V E M E N T : O F F", "M O V E M E N T : O N", null, null, null);
        public static TogglableButton toggleItemListMenu = new TogglableButton(currentMenu, 3, "S P A W N : O F F", "S P A W N : O N", null, null);
        public static TogglableButton toggleEquipmentListMenu = new TogglableButton(currentMenu, 4, "T E L E P O R T E R : O F F", "T E L E P O R T E R : O N", null, null);
        public static TogglableButton toggleDropItems = new TogglableButton(currentMenu, 5, "R E N D E R : O F F", "R E N D E R: O N", null, null);
        public static TogglableButton toggleDropInvItems = new TogglableButton(currentMenu, 6, "L O B B Y : O F F", "L O B B Y : O N", null, null);
        public static TogglableButton toggleEquipmentCD = new TogglableButton(currentMenu, 7, "U N L O A D   M E N U", "C O N F I R M ?", null, null);
        public static Button stackInventory = new Button(currentMenu, 8, "U N L O A D   M E N U", null);
        public static Button clearInventory = new Button(currentMenu, 9, "U N L O A D   M E N U", null);
        public static TogglableButton toggleChestItemMenu = new TogglableButton(currentMenu, 10, "U N L O A D   M E N U", "C O N F I R M ?", null, null);

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
