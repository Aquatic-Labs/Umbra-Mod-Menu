using System;
using System.Collections.Generic;
using UnityEngine;

namespace UmbraMenu.Menus
{
    public class StatsMod : ListMenu
    {
        public static int damagePerLvl = 10, critPerLvl = 1, multiplier = 10;
        public int DamagePerLevel
        {
            get
            {
                return damagePerLvl;
            }
            set
            {
                damagePerLvl = value;
                changeDmgPerLevel.SetText($"DAMAGE/LVL : {damagePerLvl}");
            }
        }
        public int CritPerLevel
        {
            get
            {
                return critPerLvl;
            }
            set
            {
                critPerLvl = value;
                changeCritPerLevel.SetText($"CRIT/LVL : {critPerLvl}");
            }
        }
        public int Multiplier
        {
            get
            {
                return multiplier;
            }
            set
            {
                multiplier = value;
                changeMultiplier.SetText($"MULTIPLIER : {multiplier}");
            }
        }

        public static float attackSpeed = 1, armor = 0, moveSpeed = 7;
        public float AttackSpeed
        {
            get
            {
                return attackSpeed;
            }
            set
            {
                attackSpeed = value;
                changeAttackSpeed.SetText($"ATTACK SPEED : {attackSpeed}");
            }
        }
        public float Armor
        {
            get
            {
                return armor;
            }
            set
            {
                armor = value;
                changeArmor.SetText($"ARMOR : {armor}");
            }
        }
        public float MoveSpeed
        {
            get
            {
                return moveSpeed;
            }
            set
            {
                moveSpeed = value;
                changeMoveSpeed.SetText($"MOVE SPEED : {moveSpeed}");
            }
        }
        public static bool armorToggle, attackSpeedToggle, critToggle, damageToggle, moveSpeedToggle, regenToggle;

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
            if (UmbraMenu.characterCollected)
            {
                changeDmgPerLevel = new MulButton(this, 1, $"DAMAGE/LVL : {DamagePerLevel}", ToggleDmgPerLevel, IncreaseDmgPerLevel, DecreaseDmgPerLevel);
                changeCritPerLevel = new MulButton(this, 2, $"CRIT/LVL : {CritPerLevel}", ToggleCritPerLevel, IncreaseCritPerLevel, DecreaseCritPerLevel);
                changeAttackSpeed = new MulButton(this, 3, $"ATTACK SPEED : {AttackSpeed}", ToggleAttackSpeed, IncreaseAttackSpeed, DecreaseAttackSpeed);
                changeArmor = new MulButton(this, 4, $"ARMOR : {Armor}", ToggleArmor, IncreaseArmor, DecreaseArmor);
                changeMoveSpeed = new MulButton(this, 5, $"MOVE SPEED : {MoveSpeed}", ToggleMoveSpeed, IncreaseMoveSpeed, DecreaseMoveSpeed);
                changeMultiplier = new MulButton(this, 6, $"MULTIPLIER : {Multiplier}", DoNothing, IncreaseMultiplier, DecreaseMultiplier);
                toggleViewStatsMenu = new TogglableButton(this, 7, "SHOW STATS : OFF", "SHOW STATS : ON", ToggleViewStatsMenu, ToggleViewStatsMenu);

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
                //SetActivatingButton(Utility.FindButtonById(1, 4));
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
            DamagePerLevel = 10;
            CritPerLevel = 1;
            AttackSpeed = 1;
            Armor = 0;
            MoveSpeed = 7;
            Multiplier = 10;
            armorToggle = false;
            attackSpeedToggle = false;
            critToggle = false;
            damageToggle = false;
            moveSpeedToggle = false;
            regenToggle = false;
            base.Reset();
        }

        public static void LevelPlayersCrit()
        {
            try
            {
                UmbraMenu.LocalPlayerBody.levelCrit = (float)critPerLvl;
            }
            catch (NullReferenceException)
            {
                Debug.Log("Stats1");
            }
        }

        public static void LevelPlayersDamage()
        {
            try
            {
                UmbraMenu.LocalPlayerBody.levelDamage = (float)damagePerLvl;
            }
            catch (NullReferenceException)
            {
                Debug.Log("Stats2");

            }
        }

        public static void SetplayersAttackSpeed()
        {
            try
            {
                UmbraMenu.LocalPlayerBody.baseAttackSpeed = attackSpeed;
            }
            catch (NullReferenceException)
            {
                Debug.Log("Stats3");

            }
        }

        public static void SetplayersArmor()
        {
            try
            {
                UmbraMenu.LocalPlayerBody.baseArmor = armor;
            }
            catch (NullReferenceException)
            {
                Debug.Log("Stats4");

            }
        }

        public static void SetplayersMoveSpeed()
        {
            try
            {
                UmbraMenu.LocalPlayerBody.baseMoveSpeed = moveSpeed;
            }
            catch (NullReferenceException)
            {
                Debug.Log("Stats5");

            }
        }

        #region Toggle Cheat Functions
        public void ToggleDmgPerLevel()
        {
            damageToggle = !damageToggle;
        }

        public void ToggleCritPerLevel()
        {
            critToggle = !critToggle;
        }

        public void ToggleAttackSpeed()
        {
            attackSpeedToggle = !attackSpeedToggle;
        }
        public void ToggleArmor()
        {
            armorToggle = !armorToggle;
        }

        public void ToggleMoveSpeed()
        {
            moveSpeedToggle = !moveSpeedToggle;
        }

        public void ToggleRegen()
        {
            regenToggle = !regenToggle;
        }
        #endregion

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
