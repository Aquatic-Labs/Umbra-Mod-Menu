using System.Collections.Generic;
using UnityEngine;

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
        public Button reloadMenu;
        public Button resetSettings;

        public Settings() : base(settings)
        {
            if (UmbraMenu.characterCollected)
            {
                void DoNothing() => Utility.StubbedFunction();
                void ToggleKeybindMenu() => UmbraMenu.menus[16].ToggleMenu();
                changeWidth = new Button(new MulButton(this, 1, $"WIDTH : {UmbraMenu.Width}", DoNothing, IncreaseWidth, DecreaseWidth));
                allowNavigation = new Button(new NormalButton(this, 2, $"ENABLE NAVIGATION : {EnableNavigationBtnText}", ToggleAllowNavigation));
                changeGodModeVersion = new Button(new NormalButton(this, 3, $"GOD TYPE : {GodVerion[UmbraMenu.GodVersion]}", ChangeGodVersion));
                toggleKeybindMenu = new Button(new TogglableButton(this, 4, "KEYBIND MENU : OFF", "KEYBIND MENU : ON", ToggleKeybindMenu, ToggleKeybindMenu));
                reloadMenu = new Button(new NormalButton(this, 5, $"RELOAD MENU", ReloadMenus));
                resetSettings = new Button(new NormalButton(this, 6, $"RESET SETTINGS", SetSettingsToDefaults));

                AddButtons(new List<Button>()
                {
                    changeWidth,
                    allowNavigation,
                    changeGodModeVersion,
                    toggleKeybindMenu,
                    reloadMenu,
                    resetSettings
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
            UpdateMenuWidths();
            Utility.SaveSettings();
            Utility.SoftResetMenu(true);
        }

        public void DecreaseWidth()
        {
            UmbraMenu.Width--;
            UpdateMenuWidths();
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

        public void UpdateMenuWidths()
        {
            for (int i = 0; i < UmbraMenu.menus.Count; i++)
            {
                UmbraMenu.menus[i].SetWidthSize(UmbraMenu.Width);
            }
        }

        public void ReloadMenus()
        {
            Utility.ResetMenu();
        }

        public void SetSettingsToDefaults()
        {
            Utility.CreateDefaultSettingsFile();
            UmbraMenu.Settings = Utility.ReadSettings();
            UmbraMenu.Width = float.Parse(UmbraMenu.Settings[0]);
            UmbraMenu.AllowNavigation = bool.Parse(UmbraMenu.Settings[1]);
            UmbraMenu.GodVersion = int.Parse(UmbraMenu.Settings[2]);
            UmbraMenu.keybindDict = UmbraMenu.BuildKeybinds();
            UpdateMenuWidths();
            Utility.SoftResetMenu(true);
        }
    }
}
