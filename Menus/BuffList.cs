using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RoR2;
using UnityEngine;

namespace UmbraMenu.Menus
{
    public class BuffList : Menu
    {
        private static readonly IMenu buffList = new ListMenu(11, new Rect(1503, 10, 20, 20), "B U F F S   M E N U");

        public BuffList() : base(buffList)
        {
            if (UmbraMenu.characterCollected)
            {
                List<Button> buttons = new List<Button>();
                for (int i = 0; i < Enum.GetNames(typeof(BuffIndex)).ToList().Count; i++)
                {  
                    int buffIndexInt = i;
                    void ButtonAction() => ApplyBuff(buffIndexInt);
                    Button button = new Button(new NormalButton(this, i + 1, Enum.GetNames(typeof(BuffIndex)).ToList()[i], ButtonAction));
                    buttons.Add(button);
                }
                AddButtons(buttons);
                SetActivatingButton(Utility.FindButtonById(1, 6));
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

        private void ApplyBuff(int buffIndexInt)
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
