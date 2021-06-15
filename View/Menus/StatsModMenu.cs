using System;
using System.Collections.Generic;
using UnityEngine;
using Player = UmbraMenu.Model.Cheats.Player;

namespace UmbraMenu.View
{
    public class StatsModMenu : NormalMenu
    {
        public MulButton changeDmgPerLevel;
        public MulButton changeCritPerLevel;
        public MulButton changeAttackSpeed;
        public MulButton changeArmor;
        public MulButton changeMoveSpeed;
        public MulButton changeMultiplier;
        public TogglableButton toggleViewStatsMenu;

        public StatsModMenu() : base(8, 1, new Rect(1503, 10, 20, 20), "STATS MOD MENU")
        {
            Action DoNothing = () => { return; };
            void ToggleViewStatsMenu() => UmbraModGUI.Instance.menus[9].ToggleMenu();

            changeDmgPerLevel = new MulButton(this, 1, $"DAMAGE/LVL : {Player.DamagePerLevel}", Player.LevelPlayersDamage, IncreaseDmgPerLevel, DecreaseDmgPerLevel);
            changeCritPerLevel = new MulButton(this, 2, $"CRIT/LVL : {Player.CritPerLevel}", Player.LevelPlayersCrit, IncreaseCritPerLevel, DecreaseCritPerLevel);
            changeAttackSpeed = new MulButton(this, 3, $"ATTACK SPEED : {Player.AttackSpeed}", Player.SetPlayersAttackSpeed, IncreaseAttackSpeed, DecreaseAttackSpeed);
            changeArmor = new MulButton(this, 4, $"ARMOR : {Player.Armor}", Player.SetPlayersArmor, IncreaseArmor, DecreaseArmor);
            changeMoveSpeed = new MulButton(this, 5, $"MOVE SPEED : {Player.MoveSpeed}", Player.SetPlayersMoveSpeed, IncreaseMoveSpeed, DecreaseMoveSpeed);
            changeMultiplier = new MulButton(this, 6, $"MULTIPLIER : {Player.Multiplier}", DoNothing, IncreaseMultiplier, DecreaseMultiplier);
            toggleViewStatsMenu = new TogglableButton(this, 7, "SHOW STATS : OFF", "SHOW STATS : ON", ToggleViewStatsMenu, ToggleViewStatsMenu);

            changeDmgPerLevel.MulChange += UpdateDamageButton;
            changeCritPerLevel.MulChange += UpdateCritButton;
            changeAttackSpeed.MulChange += UpdateAtkSpeedButton;
            changeArmor.MulChange += UpdateArmorButton;
            changeMoveSpeed.MulChange += UpdateMoveSpeedButton;
            changeMultiplier.MulChange += UpdateMultiplierButton;

            AddButtons(new List<Button>()
            {
                changeDmgPerLevel,
                changeCritPerLevel,
                changeAttackSpeed,
                changeArmor,
                changeMoveSpeed,
                changeMultiplier,
                toggleViewStatsMenu
            });
            ActivatingButton = UmbraModGUI.Instance.playerMenu.toggleStatsMod;
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
            Player.DamagePerLevel = 10;
            Player.CritPerLevel = 1;
            Player.AttackSpeed = 1;
            Player.Armor = 0;
            Player.MoveSpeed = 7;
            Player.Multiplier = 10;
            base.Reset();
        }

        private void UpdateDamageButton(object Sender, EventArgs e)
        {
            Player.LevelPlayersDamage();
            changeDmgPerLevel.SetText($"DAMAGE/LVL : {Player.DamagePerLevel}");
        }

        private void UpdateCritButton(object Sender, EventArgs e)
        {
            Player.LevelPlayersCrit();
            changeCritPerLevel.SetText($"CRIT/LVL : {Player.CritPerLevel}");
        }

        private void UpdateAtkSpeedButton(object Sender, EventArgs e)
        {
            Player.SetPlayersAttackSpeed();
            changeAttackSpeed.SetText($"ATTACK SPEED : {Player.AttackSpeed}");
        }

        private void UpdateArmorButton(object Sender, EventArgs e)
        {
            Player.SetPlayersArmor();
            changeArmor.SetText($"ARMOR : {Player.Armor}");
        }

        private void UpdateMoveSpeedButton(object Sender, EventArgs e)
        {
            Player.SetPlayersMoveSpeed();
            changeMoveSpeed.SetText($"MOVE SPEED : {Player.MoveSpeed}");
        }

        private void UpdateMultiplierButton(object Sender, EventArgs e)
        {
            changeMultiplier.SetText($"MULTIPLIER : {Player.Multiplier}");
        }

        #region Increase/Decrease Value Actions
        public void IncreaseDmgPerLevel()
        {
            Player.DamagePerLevel += Player.Multiplier;
        }

        public void IncreaseCritPerLevel()
        {
            Player.CritPerLevel += Player.Multiplier;
        }

        public void IncreaseAttackSpeed()
        {
            Player.AttackSpeed += Player.Multiplier;
        }

        public void IncreaseArmor()
        {
            Player.Armor += Player.Multiplier;
        }

        public void IncreaseMoveSpeed()
        {
            Player.MoveSpeed += Player.Multiplier;
        }

        public void IncreaseMultiplier()
        {
            if (Player.Multiplier == 1)
                Player.Multiplier = 10;
            else if (Player.Multiplier >= 10)
                Player.Multiplier += 10;
        }

        public void DecreaseDmgPerLevel()
        {
            if (Player.DamagePerLevel > Player.Multiplier)
                Player.DamagePerLevel -= Player.Multiplier;
        }

        public void DecreaseCritPerLevel()
        {
            if (Player.CritPerLevel > Player.Multiplier)
                Player.CritPerLevel -= Player.Multiplier;
        }

        public void DecreaseAttackSpeed()
        {
            if (Player.AttackSpeed > Player.Multiplier)
                Player.AttackSpeed -= Player.Multiplier;
        }

        public void DecreaseArmor()
        {
            if (Player.Armor > Player.Multiplier)
                Player.Armor -= Player.Multiplier;
        }

        public void DecreaseMoveSpeed()
        {
            if (Player.MoveSpeed > 7)
                Player.MoveSpeed -= Player.Multiplier;
        }

        public void DecreaseMultiplier()
        {
            if (Player.Multiplier == 10)
                Player.Multiplier = 1;
            else if (Player.Multiplier > 10)
                Player.Multiplier -= 10;
        }
        #endregion
    }
}
