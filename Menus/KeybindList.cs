using System.Collections.Generic;
using UnityEngine;
using System;

namespace UmbraMenu.Menus
{
    public sealed class KeybindList : ListMenu
    {
        public KeybindList() : base(16, 7, new Rect(1503, 10, 20, 20), "KEYBINDS MENU")
        {
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

        protected override void OnEnable()
        {
            List<Button> buttons = new List<Button>();
            for (int i = 1; i < UmbraMenu.keybindDict.Count; i++)
            {
                Keybind keyBind = UmbraMenu.keybindDict[UmbraMenu.keyBindNames[i]];
                TogglableButton setKeybind = new TogglableButton(this, i, $"{keyBind.Name} : {keyBind.KeyCode}", $"{keyBind.Name} : {keyBind.KeyCode}", ChangeKeybind, ChangeKeybind);
                buttons.Add(setKeybind);
            }
            AddButtons(buttons);
            base.OnEnable();
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
