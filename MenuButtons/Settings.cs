using System;
using System.Collections.Generic;
using System.Linq;
using RoR2;
using UnityEngine;
using System.Text;
using System.Threading.Tasks;

namespace UmbraMenu.MenuButtons
{
    public class Settings
    {
        private static readonly Menu currentMenu = (Menu)Utility.FindMenuById(7);
        private static List<Buttons> buttons = new List<Buttons>();

        public static TogglableButton ToggleKeybindsMenu = new TogglableButton(currentMenu, 1, "", "", null, null);

        public static void AddButtonsToMenu()
        {
            currentMenu.buttons = buttons;
        }
    }
}
