using System;
using System.Collections.Generic;
using UnityEngine;

namespace UmbraMenu.Menus
{
    public class StatsMod : NormalMenu
    {
        public int DamagePerLevel = 10, CritPerLevel = 1, AttackSpeed = 1, Armor = 0, MoveSpeed = 7, Multiplier = 10;
        public bool changedFromDefault;


        private static void ToggleViewStatsMenu() => UmbraMenu.menus[9].ToggleMenu();
        private static void DoNothing() => Utility.StubbedFunction();

        public MulButton changeDmgPerLevel;
        public MulButton changeCritPerLevel;
        public MulButton changeAttackSpeed;
        public MulButton changeArmor;
        public MulButton changeMoveSpeed;
        public MulButton changeMultiplier;
        public TogglableButton toggleViewStatsMenu;

        public StatsMod() : base(8, 1, new Rect(1503, 10, 20, 20), "STATS MOD MENU")
        {
            changeDmgPerLevel = new MulButton(this, 1, $"DAMAGE/LVL : {DamagePerLevel}", LevelPlayersDamage, IncreaseDmgPerLevel, DecreaseDmgPerLevel);
            changeCritPerLevel = new MulButton(this, 2, $"CRIT/LVL : {CritPerLevel}", LevelPlayersCrit, IncreaseCritPerLevel, DecreaseCritPerLevel);
            changeAttackSpeed = new MulButton(this, 3, $"ATTACK SPEED : {AttackSpeed}", SetPlayersAttackSpeed, IncreaseAttackSpeed, DecreaseAttackSpeed);
            changeArmor = new MulButton(this, 4, $"ARMOR : {Armor}", SetPlayersArmor, IncreaseArmor, DecreaseArmor);
            changeMoveSpeed = new MulButton(this, 5, $"MOVE SPEED : {MoveSpeed}", SetPlayersMoveSpeed, IncreaseMoveSpeed, DecreaseMoveSpeed);
            changeMultiplier = new MulButton(this, 6, $"MULTIPLIER : {Multiplier}", DoNothing, IncreaseMultiplier, DecreaseMultiplier);
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
            ActivatingButton = UmbraMenu.playerMenu.toggleStatsMod;
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
            DamagePerLevel = 10;
            CritPerLevel = 1;
            AttackSpeed = 1;
            Armor = 0;
            MoveSpeed = 7;
            Multiplier = 10;
            base.Reset();
        }

        private void UpdateDamageButton(object Sender, EventArgs e)
        {
            LevelPlayersDamage();
            changeDmgPerLevel.SetText($"DAMAGE/LVL : {DamagePerLevel}");
        }

        private void UpdateCritButton(object Sender, EventArgs e)
        {
            LevelPlayersCrit();
            changeCritPerLevel.SetText($"CRIT/LVL : {CritPerLevel}");
        }

        private void UpdateAtkSpeedButton(object Sender, EventArgs e)
        {
            SetPlayersAttackSpeed();
            changeAttackSpeed.SetText($"ATTACK SPEED : {AttackSpeed}");
        }

        private void UpdateArmorButton(object Sender, EventArgs e)
        {
            SetPlayersArmor();
            changeArmor.SetText($"ARMOR : {Armor}");
        }

        private void UpdateMoveSpeedButton(object Sender, EventArgs e)
        {
            SetPlayersMoveSpeed();
            changeMoveSpeed.SetText($"MOVE SPEED : {MoveSpeed}");
        }

        private void UpdateMultiplierButton(object Sender, EventArgs e)
        {
            changeMultiplier.SetText($"MULTIPLIER : {Multiplier}");
        }

        private void LevelPlayersDamage()
        {
            try
            {
                changedFromDefault = true;
                UmbraMenu.LocalPlayerBody.levelDamage = (float)DamagePerLevel;
                UmbraMenu.LocalPlayerBody.RecalculateStats();
            }
            catch (NullReferenceException)
            {
                Debug.Log("Stats2");

            }
        }

        private void LevelPlayersCrit()
        {
            try
            {
                changedFromDefault = true;
                UmbraMenu.LocalPlayerBody.levelCrit = (float)CritPerLevel;
                UmbraMenu.LocalPlayerBody.RecalculateStats();
            }
            catch (NullReferenceException)
            {
                Debug.Log("Stats1");
            }
        }

        private void SetPlayersAttackSpeed()
        {
            try
            {
                changedFromDefault = true;
                UmbraMenu.LocalPlayerBody.baseAttackSpeed = AttackSpeed;
                UmbraMenu.LocalPlayerBody.RecalculateStats();
            }
            catch (NullReferenceException)
            {
                Debug.Log("Stats3");

            }
        }

        private void SetPlayersArmor()
        {
            try
            {
                changedFromDefault = true;
                UmbraMenu.LocalPlayerBody.baseArmor = Armor;
                UmbraMenu.LocalPlayerBody.RecalculateStats();
            }
            catch (NullReferenceException)
            {
                Debug.Log("Stats4");

            }
        }

        private void SetPlayersMoveSpeed()
        {
            try
            {
                changedFromDefault = true;
                UmbraMenu.LocalPlayerBody.baseMoveSpeed = MoveSpeed;
                UmbraMenu.LocalPlayerBody.RecalculateStats();
            }
            catch (NullReferenceException)
            {
                Debug.Log("Stats5");

            }
        }

        #region Increase/Decrease Value Actions
        public void IncreaseDmgPerLevel()
        {
            DamagePerLevel += Multiplier;
        }

        public void IncreaseCritPerLevel()
        {
            CritPerLevel += Multiplier;
        }

        public void IncreaseAttackSpeed()
        {
            AttackSpeed += Multiplier;
        }

        public void IncreaseArmor()
        {
            Armor += Multiplier;
        }

        public void IncreaseMoveSpeed()
        {
            MoveSpeed += Multiplier;
        }

        public void IncreaseMultiplier()
        {
            if (Multiplier == 1)
                Multiplier = 10;
            else if (Multiplier >= 10)
                Multiplier += 10;
        }

        public void DecreaseDmgPerLevel()
        {
            if (DamagePerLevel > Multiplier)
                DamagePerLevel -= Multiplier;
        }

        public void DecreaseCritPerLevel()
        {
            if (CritPerLevel > Multiplier)
                CritPerLevel -= Multiplier;
        }

        public void DecreaseAttackSpeed()
        {
            if (AttackSpeed > Multiplier)
                AttackSpeed -= Multiplier;
        }

        public void DecreaseArmor()
        {
            if (Armor > Multiplier)
                Armor -= Multiplier;
        }

        public void DecreaseMoveSpeed()
        {
            if (MoveSpeed > 7)
                MoveSpeed -= Multiplier;
        }

        public void DecreaseMultiplier()
        {
            if (Multiplier == 10)
                Multiplier = 1;
            else if (Multiplier > 10)
                Multiplier -= 10;
        }
        #endregion
    }
}
