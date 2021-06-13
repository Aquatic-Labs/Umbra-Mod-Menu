using System;
using System.Collections.Generic;
using UnityEngine;
using RoR2;

namespace UmbraMenu.Menus
{
    public sealed class LobbyMenu : NormalMenu
    {
        public TextButton text1;
        public TextButton text2;
        public TextButton text3;

        public LobbyMenu() : base(100, 100, new Rect(10, 10, 20, 20), "UMBRA MENU")
        {
            if (Loader.updateAvailable)
            {
                SetTitle($"UMBRA\n<color=yellow>OUTDATED</color>");
            }
            else if (Loader.upToDate)
            {
                SetTitle($"UMBRA\n<color=grey>v{UmbraMenu.VERSION}</color>");
            }
            else if (Loader.devBuild)
            {
                SetTitle($"UMBRA\n<color=yellow>DEV</color>");
            }

            if (Loader.updateAvailable)
            {
                text1 = new TextButton(this, 2, "<color=yellow>Buttons will be availble in game.</color>");
                text2 = new TextButton(this, 3, "<color=#11ccee>Created By Neonix#1337 and Snow#8008.\n Feel Free to Message me on discord.</color>");
                text3 = new TextButton(this, 4, "<color=#11ccee>Download the latest version on my github.\nAcher0ns/Umbra-Mod-Menu</color>");
                AddButtons(new List<Button> { text1, text2, text3 });
            }
            else if (Loader.upToDate || Loader.devBuild)
            {
                text1 = new TextButton(this, 2, "<color=yellow>Buttons will be availble in game.</color>");
                text2 = new TextButton(this, 3, "<color=#11ccee>Created By Neonix#1337 and Snow#8008.\n Feel Free to Message me on discord.</color>");
                text3 = new TextButton(this, 4, "<color=#11ccee>with bug Reports or suggestions.</color>");
                AddButtons(new List<Button> { text1, text2, text3 });
            }
        }

        public override void Draw()
        {
            SetWindow();
            if (IsEnabled())
            {
                base.Draw();
            }
        }
    }
}
