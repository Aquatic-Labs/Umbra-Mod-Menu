using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using RoR2;
using System.Text;
using Player = UmbraMenu.Model.Cheats.Player;

namespace UmbraMenu.View
{
    public sealed class PlayerMenu : NormalMenu
    {
        public MulButton giveMoney;
        public MulButton giveCoins;
        public MulButton giveExperience;
        public TogglableButton toggleStatsMod;
        public TogglableButton toggleChangeCharacter;
        public TogglableButton toggleBuff;
        public NormalButton removeBuffs;
        public TogglableButton toggleAimbot;
        public TogglableButton toggleGod;
        public TogglableButton toggleSkillCD;
        public TogglableButton unlockAll;

        public PlayerMenu() : base(1, 0, new Rect(374, 10, 20, 20), "PLAYER MENU")
        {
            void ToggleStatsMenu() => UmbraModGUI.Instance.menus[8].ToggleMenu();
            void ToggleCharacterListMenu() => UmbraModGUI.Instance.menus[10].ToggleMenu();
            void ToggleBuffListMenu() => UmbraModGUI.Instance.menus[11].ToggleMenu();
            Action DoNothing = () => { return; };

            giveMoney = new MulButton(this, 1, $"GIVE MONEY : {Player.moneyToGive}", Player.GiveMoney, IncreaseMoney, DecreaseMoney);
            giveCoins = new MulButton(this, 2, $"GIVE LUNAR COINS : {Player.coinsToGive}", Player.GiveLunarCoins, IncreaseCoins, DecreaseCoins);
            giveExperience = new MulButton(this, 3, $"GIVE EXPERIENCE : {Player.XPToGive}", Player.GiveXP, IncreaseXP, DecreaseXP);
            toggleStatsMod = new TogglableButton(this, 4, "STATS MENU : OFF", "STATS MENU : ON", ToggleStatsMenu, ToggleStatsMenu);
            toggleChangeCharacter = new TogglableButton(this, 5, "CHANGE CHARACTER : OFF", "CHANGE CHARACTER : ON", ToggleCharacterListMenu, ToggleCharacterListMenu);
            toggleBuff = new TogglableButton(this, 6, "GIVE BUFF MENU : OFF", "GIVE BUFF MENU : ON", ToggleBuffListMenu, ToggleBuffListMenu);
            removeBuffs = new NormalButton(this, 7, "REMOVE ALL BUFFS", Player.RemoveAllBuffs);
            toggleAimbot = new TogglableButton(this, 8, "AIMBOT : OFF", "AIMBOT : ON", ToggleAimbot, ToggleAimbot);
            toggleGod = new TogglableButton(this, 9, "GOD MODE : OFF", "GOD MODE : ON", ToggleGodMode, ToggleGodMode);
            toggleSkillCD = new TogglableButton(this, 10, "INFINITE SKILLS : OFF", "INFINITE SKILLS : ON", ToggleSkillCD, ToggleSkillCD);
            unlockAll = new TogglableButton(this, 11, "UNLOCK ALL", "CONFIRM?", DoNothing, Player.UnlockAll);

            giveMoney.MulChange += UpdateGiveMoney;
            giveCoins.MulChange += UpdateGiveCoins;
            giveExperience.MulChange += UpdateGiveXP;

            AddButtons(new List<Button>()
            {
                giveMoney,
                giveCoins,
                giveExperience,
                toggleStatsMod,
                toggleChangeCharacter,
                toggleBuff,
                removeBuffs,
                toggleAimbot,
                toggleGod,
                toggleSkillCD,
                unlockAll
            });
            ActivatingButton = UmbraModGUI.Instance.mainMenu.togglePlayer;
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
            Player.SkillToggle = false;
            Player.AimBotToggle = false;
            Player.GodToggle = false;
            Player.XPToGive = 50;
            Player.moneyToGive = 50;
            Player.coinsToGive = 50;
            base.Reset();
        }

        public void ToggleAimbot()
        {
            Player.AimBotToggle = !Player.AimBotToggle;
        }

        public void ToggleGodMode()
        {
            Player.GodToggle = !Player.GodToggle;
            if (!Player.GodToggle)
            {
                Player.DisabledGodMode();
            }
        }

        public static void ToggleSkillCD()
        {
            Player.SkillToggle = !Player.SkillToggle;
        }

        #region Increase/Decrease Value Actions
        public void IncreaseMoney()
        {
            if (Player.moneyToGive >= 50)
                Player.moneyToGive += 50;
        }

        public void IncreaseCoins()
        {
            if (Player.coinsToGive >= 10)
                Player.coinsToGive += 10;
        }

        public void IncreaseXP()
        {
            if (Player.XPToGive >= 50)
                Player.XPToGive += 50;
        }

        public void DecreaseMoney()
        {
            if (Player.moneyToGive > 50)
                Player.moneyToGive -= 50;
        }

        public void DecreaseCoins()
        {
            if (Player.coinsToGive > 10)
                Player.coinsToGive -= 10;
        }

        public void DecreaseXP()
        {
            if (Player.XPToGive > 50)
                Player.XPToGive -= 50;
        }
        #endregion

        #region Mul Button Event Update Methods
        public void UpdateGiveMoney(object sender, EventArgs e)
        {
            giveMoney.SetText($"GIVE MONEY : {Player.moneyToGive}");
        }

        public void UpdateGiveCoins(object sender, EventArgs e)
        {
            giveCoins.SetText($"GIVE LUNAR COINS : {Player.coinsToGive}");
        }

        public void UpdateGiveXP(object sender, EventArgs e)
        {
            giveExperience.SetText($"GIVE EXPERIENCE : {Player.XPToGive}");
        }
        #endregion
    }
}

