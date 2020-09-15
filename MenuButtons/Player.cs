using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace UmbraMenu.MenuButtons
{
    class Player
    {
        private static readonly Menu currentMenu = Utility.FindMenuById(1);

        private static void StubbedFunc() => Utility.StubbedFunction();
        public static MulButton giveMoney = new MulButton(currentMenu, 1, $"G I V E   M O N E Y : ", Styles.BtnStyle, StubbedFunc, StubbedFunc, StubbedFunc);
        public static MulButton giveCoins = new MulButton(currentMenu, 2, $"G I V E   L U N A R   C O I N S : ", Styles.BtnStyle, StubbedFunc, StubbedFunc, StubbedFunc);
        public static MulButton giveExperience = new MulButton(currentMenu, 3, $"G I V E   E X P E R I E N C E : ", Styles.BtnStyle, StubbedFunc, StubbedFunc, StubbedFunc);
        public static TogglableButton toggleStatsMod = new TogglableButton(currentMenu, 4, "S T A T S   M E N U : O F F", "S T A T S   M E N U : O N", StubbedFunc, StubbedFunc);
        public static TogglableButton toggleChangeCharacter = new TogglableButton(currentMenu, 5, "C H A N G E   C H A R A C T E R : O F F", "C H A N G E   C H A R A C T E R : O N", StubbedFunc, StubbedFunc);
        public static TogglableButton toggleBuff = new TogglableButton(currentMenu, 6, "G I V E   B U F F   M E N U : O F F", "G I V E   B U F F   M E N U : O N", StubbedFunc, StubbedFunc);
        public static Button removeBuffs = new Button(currentMenu, 7, "R E M O V E   A L L   B U F F S", StubbedFunc);
        public static TogglableButton toggleAimbot = new TogglableButton(currentMenu, 8, "A I M B O T : O F F", "A I M B O T : O N", StubbedFunc, StubbedFunc);
        public static TogglableButton toggleGod = new TogglableButton(currentMenu, 9, "G O D   M O D E : O F F", "G O D   M O D E : O N", StubbedFunc, StubbedFunc);
        public static TogglableButton toggleSkillCD = new TogglableButton(currentMenu, 10, "I N F I N I T E   S K I L L S : O F F", "I N F I N I T E   S K I L L S : O N", StubbedFunc, StubbedFunc);
        public static Button unlockAll = new Button(currentMenu, 11, "U N L O C K   A L L", StubbedFunc);

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
            unlockAll
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
