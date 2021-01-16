using System;
using System.Collections.Generic;
using System.Linq;
using RoR2;
using UnityEngine;
using System.Text;
using System.Threading.Tasks;

namespace UmbraMenu.Menus
{
    public class Settings : Menu
    {
        private static readonly IMenu settings = new NormalMenu(7, new Rect(374, 750, 20, 20), "SETTINGS MENU");

        public static string[] GodVerion = { "NORMAL", "INTANGIBLE", "REGEN", "NEGATIVE", "REVIVE" };
        public static string enableNavigationBtnText = UmbraMenu.AllowNavigation ? "TRUE" : "FALSE";
        public string EnableNavigationBtnText
        {
            get
            {
                return UmbraMenu.AllowNavigation ? "TRUE" : "FALSE";
            }
        }

        public Button changeWidth;
        public Button allowNavigation;
        public Button changeGodModeVersion;
        public Button toggleKeybindMenu;

        public Settings() : base(settings)
        {
            if (UmbraMenu.characterCollected)
            {
                void DoNothing() => Utility.StubbedFunction();
                void ToggleKeybindMenu() => Utility.FindMenuById(17).ToggleMenu();
                changeWidth = new Button(new MulButton(this, 1, $"WIDTH : {UmbraMenu.Width}", DoNothing, IncreaseWidth, DecreaseWidth));
                allowNavigation = new Button(new NormalButton(this, 2, $"ENABLE NAVIGATION : {EnableNavigationBtnText}", ToggleAllowNavigation));
                changeGodModeVersion = new Button(new NormalButton(this, 3, $"GOD TYPE : {GodVerion[UmbraMenu.GodVersion]}", ChangeGodVersion));
                toggleKeybindMenu = new Button(new TogglableButton(this, 4, "KEYBIND MENU : OFF", "KEYBIND MENU : ON", ToggleKeybindMenu, ToggleKeybindMenu));

                AddButtons(new List<Button>() 
                {
                    changeWidth,
                    allowNavigation,
                    changeGodModeVersion,
                    toggleKeybindMenu
                });
                SetActivatingButton(Utility.FindButtonById(0, 7));
                SetPrevMenuId(0);
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

        public void IncreaseWidth()
        {
            UmbraMenu.Width++;
            Utility.SaveSettings();
            Utility.SoftResetMenu(true);
        }

        public void DecreaseWidth()
        {
            UmbraMenu.Width--;
            Utility.SaveSettings();
            Utility.SoftResetMenu(true);
        }

        public void ToggleAllowNavigation()
        {
            UmbraMenu.AllowNavigation = !UmbraMenu.AllowNavigation;
            if (!UmbraMenu.AllowNavigation)
            {
                UmbraMenu.navigationToggle = false;
                Navigation.buttonIndex = 0;
                Navigation.menuIndex = 0;
            }

            Utility.SaveSettings();
            allowNavigation.SetText($"ENABLE NAVIGATION : {EnableNavigationBtnText}");
            Utility.SoftResetMenu(true);
        }

        public void ChangeGodVersion()
        {
            if (Player.GodToggle)
            {
                Player.GodToggle = false;
                Utility.FindButtonById(1, 9).SetEnabled(false);
                Player.DisabledGodMode();
                UmbraMenu.GodVersion++;
                Player.GodToggle = true;
                Utility.FindButtonById(1, 9).SetEnabled(true);
            }
            else
            {
                UmbraMenu.GodVersion++;
            }

            if (UmbraMenu.GodVersion > 4)
            {
                UmbraMenu.GodVersion = 0;
            }

            Utility.SaveSettings();
            Utility.SoftResetMenu(true);
        }
    }
}
