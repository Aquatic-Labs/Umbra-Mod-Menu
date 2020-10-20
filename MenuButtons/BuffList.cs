using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RoR2;
using UnityEngine;

namespace UmbraMenu.MenuButtons
{
    public class BuffList
    {
        private static readonly ListMenu currentMenu = (ListMenu)Utility.FindMenuById(11);

        public static void AddButtonsToMenu()
        {
            List<IButton> buttons = new List<IButton>();
            for (int i = 0; i < Enum.GetNames(typeof(BuffIndex)).ToList().Count; i++)
            {
                int buffIndexInt = i;
                void ButtonAction() => ApplyBuff(buffIndexInt);
                Button button = new Button(currentMenu, i + 1, Enum.GetNames(typeof(BuffIndex)).ToList()[i], ButtonAction);
                buttons.Add(button);
            }
            currentMenu.buttons = buttons;
        }

        private static void ApplyBuff(int buffIndexInt)
        {
            BuffIndex buffIndex = (BuffIndex)Enum.Parse(typeof(BuffIndex), Enum.GetNames(typeof(BuffIndex))[buffIndexInt]);
            var localUser = LocalUserManager.GetFirstLocalUser();
            if (localUser.cachedMasterController && localUser.cachedMasterController.master)
            {
                UmbraMenu.LocalPlayerBody.AddBuff(buffIndex);
            }
        }
    }
}
