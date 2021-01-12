using System;
using System.Collections.Generic;
using System.Linq;
using RoR2;
using UnityEngine;
using System.Text;
using System.Threading.Tasks;

namespace UmbraMenu.Menus
{
    public class Settings
    {
        private static readonly Menu currentMenu = null; // (Menu)Utility.FindMenuById(7);
        private static List<IButton> buttons = new List<IButton>();

        public static TogglableButton toggleKeybindsMenu = new TogglableButton(currentMenu, 1, "", "", null, null);
        //public static Button changeGodModeType = new Button(currentMenu, 1, "", null);

        public static void AddButtonsToMenu()
        {
            //currentMenu.Buttons = buttons;
        }
    }
}
