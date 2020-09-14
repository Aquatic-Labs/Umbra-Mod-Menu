using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UmbraMenu.ButtonActions
{
    public static class MainMenu
    {
        private static readonly Menu currentMenu = Utility.FindMenuById(0);
        public static void ToggleMenu(Menu menu)
        {
            menu.enabled = !menu.enabled;
        }
    }
}
