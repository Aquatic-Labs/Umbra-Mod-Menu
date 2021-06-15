using System.Collections.Generic;
using UnityEngine;
using System;
using Umbra = UmbraMenu.Model.UmbraMod;
using Keybind = UmbraMenu.Model.Keybind;
using StartKeybindUpdateEventArgs = UmbraMenu.Model.UmbraMod.StartKeybindUpdateEventArgs;

namespace UmbraMenu.View
{
    public sealed class KeybindListMenu : ListMenu
    {
        public KeybindListMenu() : base(16, 7, new Rect(1503, 10, 20, 20), "KEYBINDS MENU")
        {
            ActivatingButton = UmbraModGUI.Instance.settingsMenu.toggleKeybindMenu;
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
            for (int i = 1; i < Umbra.Instance.keybindDict.Count; i++)
            {
                Keybind keyBind = Umbra.Instance.keybindDict[Umbra.keyBindNames[i]];
                Action changeKeybind = () => Umbra.Instance.CallToStartKeybindUpdate(this, new StartKeybindUpdateEventArgs() { keybindName = keyBind.Name, rawKeybindStr = Input.inputString });
                TogglableButton setKeybind = new TogglableButton(this, i, $"{keyBind.Name} : {keyBind.KeyCode}", $"{keyBind.Name} : {keyBind.KeyCode}", changeKeybind, changeKeybind);
                buttons.Add(setKeybind);
            }
            AddButtons(buttons);
            base.OnEnable();
        }

        public override void Reset()
        {
            base.Reset();
        }
    }
}
