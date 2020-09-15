using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UmbraMenu
{
    class Navigation
    {
        public void PressButton(int menuId, int buttonId)
        {
            Menu menu = Utility.FindMenuById(menuId);
            //Button button = Utility.FindButtonById(menu, buttonId);
            //button.buttonAction();
        }
    }
}
