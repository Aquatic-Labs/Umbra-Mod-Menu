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
        private static readonly IMenu settings = new NormalMenu(7, new Rect(374, 750, 20, 20), "S E T T I N G S   M E N U");

        public static string[] GodVerion = { "N O R M A L", "I N T A N G I B L E", "R E G E N", "N E G A T I V E", "R E V I V E" };
        public static string enableNavigationBtnText = UmbraMenu.AllowNavigation ? "T R U E" : "F A L S E";
        public string EnableNavigationBtnText
        {
            get
            {
                return UmbraMenu.AllowNavigation ? "T R U E" : "F A L S E";
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
                void ToggleKeybindMenu() => Utility.FindMenuById(16).ToggleMenu();
                changeWidth = new Button(new MulButton(this, 1, $"W I D T H : {UmbraMenu.Width}", DoNothing, IncreaseWidth, DecreaseWidth));
                allowNavigation = new Button(new NormalButton(this, 2, $"E N A B L E   N A V I G A T I O N : {EnableNavigationBtnText}", ToggleAllowNavigation));
                changeGodModeVersion = new Button(new NormalButton(this, 3, $"G O D   T Y P E : {GodVerion[UmbraMenu.GodVersion]}", ChangeGodVersion));
                toggleKeybindMenu = new Button(new TogglableButton(this, 4, "K E Y B I N D   M E N U : O F F", "K E Y B I N D   M E N U : O N", ToggleKeybindMenu, ToggleKeybindMenu));

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
            allowNavigation.SetText($"E N A B L E   N A V I G A T I O N : {EnableNavigationBtnText}");
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
