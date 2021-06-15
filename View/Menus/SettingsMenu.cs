using System.Collections.Generic;
using UnityEngine;
using System;
using Player = UmbraMenu.Model.Cheats.Player;

namespace UmbraMenu.View
{
    public class SettingsMenu : NormalMenu
    {
        public static string[] GodVerion = { "NORMAL", "INTANGIBLE", "REGEN", "NEGATIVE", "REVIVE" };
        public static string enableNavigationBtnText = UmbraModGUI.Instance.allowNavigation ? "TRUE" : "FALSE";
        public string EnableNavigationBtnText
        {
            get
            {
                return UmbraModGUI.Instance.allowNavigation ? "TRUE" : "FALSE";
            }
        }

        public MulButton changeWidth;
        public NormalButton allowNavigation;
        public NormalButton changeGodModeVersion;
        public TogglableButton toggleKeybindMenu;
        public NormalButton reloadMenu;
        public NormalButton resetSettings;

        public SettingsMenu() : base(7, 0, new Rect(374, 750, 20, 20), "SETTINGS MENU")
        {
            Action DoNothing = () => { return; };
            void ToggleKeybindMenu() => UmbraModGUI.Instance.menus[16].ToggleMenu();
            changeWidth = new MulButton(this, 1, $"WIDTH : {UmbraModGUI.Instance.width}", DoNothing, IncreaseWidth, DecreaseWidth);
            allowNavigation = new NormalButton(this, 2, $"ENABLE NAVIGATION : {EnableNavigationBtnText}", ToggleAllowNavigation);
            changeGodModeVersion = new NormalButton(this, 3, $"GOD TYPE : {GodVerion[Model.UmbraMod.Instance.GodVersion]}", ChangeGodVersion);
            toggleKeybindMenu = new TogglableButton(this, 4, "KEYBIND MENU : OFF", "KEYBIND MENU : ON", ToggleKeybindMenu, ToggleKeybindMenu);
            reloadMenu = new NormalButton(this, 5, $"RELOAD MENU", ReloadMenus);
            resetSettings = new NormalButton(this, 6, $"RESET SETTINGS", SetSettingsToDefaults);

            changeWidth.MulChange += UpdateWidthButton;
            allowNavigation.Click += UpdateNavButton;
            changeGodModeVersion.Click += UpdateGodButton;

            AddButtons(new List<Button>()
            {
                changeWidth,
                allowNavigation,
                changeGodModeVersion,
                toggleKeybindMenu,
                reloadMenu,
                resetSettings
            });
            ActivatingButton = UmbraModGUI.Instance.mainMenu.toggleSettings;
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

        private void UpdateWidthButton(object sender, EventArgs e)
        {
            changeWidth.SetText($"WIDTH : {UmbraModGUI.Instance.width}");
        }

        private void UpdateNavButton(object sender, EventArgs e)
        {
            allowNavigation.SetText($"ENABLE NAVIGATION : {EnableNavigationBtnText}");
        }

        private void UpdateGodButton(object sender, EventArgs e)
        {
            changeGodModeVersion.SetText($"GOD TYPE : {GodVerion[Model.UmbraMod.Instance.GodVersion]}");
        }

        public void IncreaseWidth()
        {
            UmbraModGUI.Instance.width++;
            UpdateMenuWidths();
            Model.Utility.SaveSettings();
        }

        public void DecreaseWidth()
        {
            UmbraModGUI.Instance.width--;
            UpdateMenuWidths();
            Model.Utility.SaveSettings();
        }

        public void ToggleAllowNavigation()
        {
            UmbraModGUI.Instance.allowNavigation = !UmbraModGUI.Instance.allowNavigation;
            if (!UmbraModGUI.Instance.allowNavigation)
            {
                UmbraModGUI.Instance.navigationToggle = false;
                Navigation.buttonIndex = 0;
                Navigation.menuIndex = 0;
            }

            Model.Utility.SaveSettings();
            allowNavigation.SetText($"ENABLE NAVIGATION : {EnableNavigationBtnText}");
        }

        public void ChangeGodVersion()
        {
            if (Player.GodToggle)
            {
                Player.GodToggle = false;
                Player.DisabledGodMode();
                Model.UmbraMod.Instance.GodVersion++;
                Player.GodToggle = true;
            }
            else
            {
                Model.UmbraMod.Instance.GodVersion++;
            }

            if (Model.UmbraMod.Instance.GodVersion > 4)
            {
                Model.UmbraMod.Instance.GodVersion = 0;
            }
            Model.Utility.SaveSettings();
        }

        public void UpdateMenuWidths()
        {
            for (int i = 0; i < UmbraModGUI.Instance.menus.Count; i++)
            {
                UmbraModGUI.Instance.menus[i].SetWidthSize(UmbraModGUI.Instance.width);
            }
        }

        public void ReloadMenus()
        {
            GUIUtility.ResetMenu();
        }

        public void SetSettingsToDefaults()
        {
            Model.Utility.CreateDefaultSettingsFile();
            Model.UmbraMod.Instance.Settings = Model.Utility.ReadSettings();
            UmbraModGUI.Instance.width = float.Parse(Model.UmbraMod.Instance.Settings[0]);
            UmbraModGUI.Instance.allowNavigation = bool.Parse(Model.UmbraMod.Instance.Settings[1]);
            Model.UmbraMod.Instance.GodVersion = int.Parse(Model.UmbraMod.Instance.Settings[2]);
            Model.UmbraMod.Instance.keybindDict = Model.UmbraMod.Instance.BuildKeybinds();
            UpdateMenuWidths();
        }
    }
}
