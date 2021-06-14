using System;
using System.Collections.Generic;
using System.Linq;
using RoR2;
using UnityEngine;

namespace UmbraMenu.Menus
{
    public class BuffList : ListMenu
    {
        public BuffList() : base(11, 1, new Rect(1503, 10, 20, 20), "BUFFS MENU")
        {
            List<Button> buttons = new List<Button>();
            int i = 0;
            foreach (BuffDef buffDef in UmbraMenu.buffs)
            {  
                void ButtonAction() => ApplyBuff(buffDef);
                Button button = new NormalButton(this, i + 1, buffDef.name, ButtonAction);
                buttons.Add(button);
                i++;
            }
            AddButtons(buttons);
            ActivatingButton = UmbraMenu.playerMenu.toggleBuff;
        }

        public override void Draw()
        {
            if (IsEnabled())
            {
                SetWindow();
                base.Draw();
            }
        }

        private void ApplyBuff(BuffDef buffDef)
        {
            var localUser = LocalUserManager.GetFirstLocalUser();
            if (localUser.cachedMasterController && localUser.cachedMasterController.master)
            {
                UmbraMenu.LocalPlayerBody.AddBuff(buffDef);
            }
        }
    }
}
