using System.Collections.Generic;
using UnityEngine;

namespace UmbraMenu.Menus
{
    public sealed class KeybindList : ListMenu
    {
        public KeybindList() : base(16, 7, new Rect(1503, 10, 20, 20), "KEYBINDS MENU")
        {
            List<Button> buttons = new List<Button>();
            for (int i = 1; i < UmbraMenu.keybindDict.Count; i++)
            {
                Keybind keyBind = UmbraMenu.keybindDict[UmbraMenu.keyBindNames[i]];
                Button setKeybind = new TogglableButton(this, i, $"{keyBind.Name} : {keyBind.KeyCode}" , $"{keyBind.Name} : {keyBind.KeyCode}", ChangeKeybind, ChangeKeybind);
                buttons.Add(setKeybind);
            }
            AddButtons(buttons);
            ActivatingButton = UmbraMenu.settingsMenu.toggleKeybindMenu;
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
