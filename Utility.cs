using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UmbraMenu
{
    public static class Utility
    {
        public static Button FindButtonById(Menu menu, int id)
        {
            for (int i = 0; i < menu.buttons.Count; i++)
            {
                if (menu.buttons[i].position == id)
                {
                    return menu.buttons[i];
                }
            }
            return null;
        }

        public static Menu FindMenuById(int id)
        {
            for (int i = 0; i < UmbraMenu.menus.Count; i++)
            {
                Menu currentMenu = UmbraMenu.menus[i];
                if (currentMenu.id == id)
                {
                    return currentMenu;
                }
            }
            return null;
        }
    }
}
