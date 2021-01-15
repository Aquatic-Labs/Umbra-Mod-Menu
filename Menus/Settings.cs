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

        public static string[] GodVerion = { "N O R M A L", "B A R R I E R", "R E G E N", "N E G A T I V E", "R E V I V E" };

        public Button changeWidth;
        public Button allowNavigation;
        public Button changeGodModeVersion;
        public Button toggleKeybindMenu;

        public Settings() : base(settings)
        {
            if (UmbraMenu.characterCollected)
            {
                void DoNothing() => Utility.StubbedFunction();
                changeWidth = new Button(new MulButton(this, 1, $"W I D T H : {UmbraMenu.Width}", DoNothing, null, null));
                allowNavigation = new Button(new TogglableButton(this, 2, $"A L L O W   N A V I G A T I O N : N O", $"A L L O W   N A V I G A T I O N : Y E S", null, null, true));
                changeGodModeVersion = new Button(new NormalButton(this, 3, $"G O D   T Y P E : {GodVerion[UmbraMenu.GodVersion]}", null));
                toggleKeybindMenu = new Button(new TogglableButton(this, 4, "K E Y B I N D   M E N U : O F F", "K E Y B I N D   M E N U : O N", null, null));

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
    }
}
