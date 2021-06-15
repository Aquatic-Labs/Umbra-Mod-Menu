using System;
using System.Collections.Generic;
using System.Linq;
using RoR2;
using UnityEngine;
using Umbra = UmbraMenu.Model.UmbraMod;
using Player = UmbraMenu.Model.Cheats.Player;

namespace UmbraMenu.View
{
    public class BuffListMenu : ListMenu
    {
        public BuffListMenu() : base(11, 1, new Rect(1503, 10, 20, 20), "BUFFS MENU")
        {
            List<Button> buttons = new List<Button>();
            int i = 0;
            foreach (BuffDef buffDef in Umbra.Instance.buffs)
            {  
                void ButtonAction() => Player.ApplyBuff(buffDef);
                Button button = new NormalButton(this, i + 1, buffDef.name, ButtonAction);
                buttons.Add(button);
                i++;
            }
            AddButtons(buttons);
            ActivatingButton = UmbraModGUI.Instance.playerMenu.toggleBuff;
        }

        public override void Draw()
        {
            if (IsEnabled())
            {
                SetWindow();
                base.Draw();
            }
        }
    }
}
