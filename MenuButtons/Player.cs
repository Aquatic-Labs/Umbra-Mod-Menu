using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UmbraMenu.MenuButtons
{
    class Player
    {
        private static readonly Menu currentMenu = Utility.FindMenuById(1);

        public static MulButton giveMoney = new MulButton(currentMenu, 1, "P L A Y E R : O F F", "P L A Y E R : O N", null, null, null);
        public static MulButton giveCoins = new MulButton(currentMenu, 2, "M O V E M E N T : O F F", "M O V E M E N T : O N", null, null, null);
        public static MulButton giveExperience = new MulButton(currentMenu, 3, "I T E M S : O F F", "I T E M S : O N", null, null, null);
        public static TogglableButton toggleStatsMod = new TogglableButton(currentMenu, 4, "S P A W N : O F F", "S P A W N : O N", null, null);
        public static TogglableButton toggleChangeCharacter = new TogglableButton(currentMenu, 5, "T E L E P O R T E R : O F F", "T E L E P O R T E R : O N", null, null);
        public static TogglableButton toggleBuff = new TogglableButton(currentMenu, 6, "R E N D E R : O F F", "R E N D E R: O N", null, null);
        public static Button removeBuffs = new Button(currentMenu, 7, "L O B B Y : O F F", "L O B B Y : O N", null);
        public static TogglableButton toggleAimbot = new TogglableButton(currentMenu, 8, "U N L O A D   M E N U", "C O N F I R M ?", null, null);
        public static TogglableButton toggleGod = new TogglableButton(currentMenu, 9, "U N L O A D   M E N U", "C O N F I R M ?", null, null);
        public static TogglableButton toggleSkillCD = new TogglableButton(currentMenu, 10, "U N L O A D   M E N U", "C O N F I R M ?", null, null);
        public static Button unlockAll = new Button(currentMenu, 11, "U N L O A D   M E N U", "C O N F I R M ?", null);

        public static List<Button> buttons = new List<Button>()
        {
            Button.ConvertMulButtonToButton(giveMoney),
            Button.ConvertMulButtonToButton(giveCoins),
            Button.ConvertMulButtonToButton(giveExperience),
            Button.ConvertTogglableButtonToButton(toggleStatsMod),
            Button.ConvertTogglableButtonToButton(toggleChangeCharacter),
            Button.ConvertTogglableButtonToButton(toggleBuff),
            removeBuffs,
            Button.ConvertTogglableButtonToButton(toggleAimbot),
            Button.ConvertTogglableButtonToButton(toggleGod),
            Button.ConvertTogglableButtonToButton(toggleSkillCD),
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
