using System;
using System.Collections.Generic;
using System.Linq;
using RoR2;
using UnityEngine;

namespace UmbraMenu.Menus
{
    public class BuffList : Menu
    {
        private static readonly IMenu buffList = new ListMenu(11, new Rect(1503, 10, 20, 20), "BUFFS MENU");

        public BuffList() : base(buffList)
        {
            if (UmbraMenu.characterCollected)
            {
                List<Button> buttons = new List<Button>();
                int i = 0;
                foreach (BuffDef buffDef in UmbraMenu.buffs)
                {  
                    void ButtonAction() => ApplyBuff(buffDef);
                    Button button = new Button(new NormalButton(this, i + 1, buffDef.name.Substring(2), ButtonAction));
                    buttons.Add(button);
                    i++;
                }
                AddButtons(buttons);
                SetActivatingButton(Utility.FindButtonById(1, 6));
                SetPrevMenuId(1);
            }
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
