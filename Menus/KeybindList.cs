using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace UmbraMenu.Menus
{
    class KeybindList : Menu
    {
        private static readonly IMenu keybindList = new ListMenu(16, new Rect(1503, 10, 20, 20), "KEYBINDS MENU");

        public KeybindList() : base(keybindList)
        {
            if (UmbraMenu.characterCollected)
            {
                List<Button> buttons = new List<Button>();
                for (int i = 1; i < UmbraMenu.keybindDict.Count; i++)
                {
                    Keybind keyBind = UmbraMenu.keybindDict[UmbraMenu.keyBindNames[i]];
                    Button setKeybind = new Button(new TogglableButton(this, i, $"{keyBind.Name} : {keyBind.KeyCode}" , $"{keyBind.Name} : {keyBind.KeyCode}", ChangeKeybind, ChangeKeybind));
                    buttons.Add(setKeybind);
                }
                AddButtons(buttons);
                SetActivatingButton(Utility.FindButtonById(7, 4));
                SetPrevMenuId(7);
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

        public override void Reset()
        {
            base.Reset();
        }

        public void ChangeKeybind()
        {
            UmbraMenu.listenForKeybind = !UmbraMenu.listenForKeybind;
        }
    }
}
