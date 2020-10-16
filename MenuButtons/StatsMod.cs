using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UmbraMenu.MenuButtons
{
    public class StatsMod
    {
        private static readonly Menu currentMenu = (Menu)Utility.FindMenuById(8);

        private static int damagePerLvl = 10, critPerLvl = 1, multiplier = 10;
        public static int DamagePerLevel
        {
            get
            {
                return damagePerLvl;
            }
            set
            {
                damagePerLvl = value;
                if (changeDmgPerLevel.Enabled)
                {
                    changeDmgPerLevel.text = $"D A M A G E / L V L ( O N ) : {DamagePerLevel}";
                }
                else
                {
                    changeDmgPerLevel.text = $"D A M A G E / L V L ( O F F ) : {DamagePerLevel}";
                }
            }
        }

        public static int CritPerLevel
        {
            get
            {
                return critPerLvl;
            }
            set
            {
                critPerLvl = value;
                if (changeCritPerLevel.Enabled)
                {
                    changeCritPerLevel.text = $"C R I T / L V L ( O N ) : {CritPerLevel}";
                }
                else
                {
                    changeCritPerLevel.text = $"C R I T / L V L ( O F F ) : {CritPerLevel}";
                }
            }
        }

        public static int Multiplier
        {
            get
            {
                return multiplier;
            }
            set
            {
                multiplier = value;
                changeMultiplier.text = $"M U L T I P L I E R : {Multiplier}";
            }
        }

        private static float attackSpeed = 1, armor = 0, moveSpeed = 7;
        public static float AttackSpeed
        {
            get
            {
                return attackSpeed;
            }
            set
            {
                attackSpeed = value;
                if (changeAttackSpeed.Enabled)
                {
                    changeAttackSpeed.text = $"A T T A C K   S P E E D ( O N ) : {AttackSpeed}";
                }
                else
                {
                    changeAttackSpeed.text = $"A T T A C K   S P E E D ( O F F ) : {AttackSpeed}";
                }
            }
        }

        public static float Armor
        {
            get
            {
                return armor;

            }
            set
            {
                armor = value;
                if (changeArmor.Enabled)
                {
                    changeArmor.text = $"A R M O R ( O N ) : {Armor}";
                }
                else
                {
                    changeArmor.text = $"A R M O R ( O F F ) : {Armor}";
                }
            }
        }

        public static float MoveSpeed
        {
            get
            {
                return moveSpeed;
            }
            set
            {
                moveSpeed = value;
                if (changeMoveSpeed.Enabled)
                {
                    changeMoveSpeed.text = $"M O V E   S P E E D ( O N ) : {MoveSpeed}";
                }
                else
                {
                    changeMoveSpeed.text = $"M O V E   S P E E D ( O F F ) : {MoveSpeed}";
                }
            }
        }

        public static bool armorToggle, attackSpeedToggle, critToggle, damageToggle, moveSpeedToggle, regenToggle;

        private static void ToggleViewStatsMenu() => ToggleMenu((Menu)Utility.FindMenuById(9));
        private static void DoNothing() => Utility.StubbedFunction();

        public static TogglableMulButton changeDmgPerLevel = new TogglableMulButton(currentMenu, 1, $"D A M A G E / L V L ( O F F ) : {DamagePerLevel}", $"D A M A G E / L V L ( O N ) : {DamagePerLevel}", ToggleDmgPerLevel, ToggleDmgPerLevel, IncreaseDmgPerLevel, DecreaseDmgPerLevel);
        public static TogglableMulButton changeCritPerLevel = new TogglableMulButton(currentMenu, 2, $"C R I T / L V L ( O F F ) : {CritPerLevel}", $"C R I T / L V L ( O N ) : {CritPerLevel}", ToggleCritPerLevel, ToggleCritPerLevel, IncreaseCritPerLevel, DecreaseCritPerLevel);
        public static TogglableMulButton changeAttackSpeed = new TogglableMulButton(currentMenu, 3, $"A T T A C K   S P E E D ( O F F ) : {AttackSpeed}", $"A T T A C K   S P E E D ( O N ) : {AttackSpeed}", ToggleAttackSpeed, ToggleAttackSpeed, IncreaseAttackSpeed, DecreaseAttackSpeed);
        public static TogglableMulButton changeArmor = new TogglableMulButton(currentMenu, 4, $"A R M O R ( O F F ) : {Armor}", $"A R M O R ( O N ) : {Armor}", ToggleArmor, ToggleArmor, IncreaseArmor, DecreaseArmor);
        public static TogglableMulButton changeMoveSpeed = new TogglableMulButton(currentMenu, 5, $"M O V E   S P E E D ( O F F ) : {MoveSpeed}", $"M O V E   S P E E D ( O N ) : {MoveSpeed}", ToggleMoveSpeed, ToggleMoveSpeed, IncreaseMoveSpeed, DecreaseMoveSpeed);
        public static MulButton changeMultiplier = new MulButton(currentMenu, 6, $"M U L T I P L I E R : {Multiplier}", DoNothing, IncreaseMultiplier, DecreaseMultiplier);
        public static TogglableButton toggleViewStatsMenu = new TogglableButton(currentMenu, 7, "S H O W   S T A T S : O F F", "S H O W   S T A T S : O N", ToggleViewStatsMenu, ToggleViewStatsMenu);

        private static List<Buttons> buttons = new List<Buttons>() 
        {
            changeDmgPerLevel,
            changeCritPerLevel,
            changeAttackSpeed,
            changeArmor,
            changeMoveSpeed,
            changeMultiplier,
            toggleViewStatsMenu
        };

        public static void AddButtonsToMenu()
        {
            currentMenu.buttons = buttons;
        }

        public static void ToggleMenu(Menu menu)
        {
            menu.enabled = !menu.enabled;
        }

        public static void LevelPlayersCrit()
        {
            try
            {
                UmbraMenu.LocalPlayerBody.levelCrit = (float)CritPerLevel;
            }
            catch (NullReferenceException)
            {
            }
        }

        public static void LevelPlayersDamage()
        {
            try
            {
                UmbraMenu.LocalPlayerBody.levelDamage = (float)DamagePerLevel;
            }
            catch (NullReferenceException)
            {
            }
        }

        public static void SetplayersAttackSpeed()
        {
            try
            {
                UmbraMenu.LocalPlayerBody.baseAttackSpeed = AttackSpeed;
            }
            catch (NullReferenceException)
            {
            }
        }

        public static void SetplayersArmor()
        {
            try
            {
                UmbraMenu.LocalPlayerBody.baseArmor = Armor;
            }
            catch (NullReferenceException)
            {
            }
        }

        public static void SetplayersMoveSpeed()
        {
            try
            {
                UmbraMenu.LocalPlayerBody.baseMoveSpeed = MoveSpeed;
            }
            catch (NullReferenceException)
            {
            }
        }

        #region Toggle Cheat Functions
        public static void ToggleDmgPerLevel()
        {
            damageToggle = !damageToggle;
        }

        public static void ToggleCritPerLevel()
        {
            critToggle = !critToggle;
        }

        public static void ToggleAttackSpeed()
        {
            attackSpeedToggle = !attackSpeedToggle;
        }
        public static void ToggleArmor()
        {
            armorToggle = !armorToggle;
        }

        public static void ToggleMoveSpeed()
        {
            moveSpeedToggle = !moveSpeedToggle;
        }

        public static void ToggleRegen()
        {
            regenToggle = !regenToggle;
        }
        #endregion

        #region Increase/Decrease Value Actions
        public static void IncreaseDmgPerLevel()
        {
            if (DamagePerLevel >= 0)
                DamagePerLevel += Multiplier;
        }

        public static void IncreaseCritPerLevel()
        {
            if (CritPerLevel >= 0)
                CritPerLevel += Multiplier;
        }

        public static void IncreaseAttackSpeed()
        {
            if (AttackSpeed >= 0)
                AttackSpeed += Multiplier;
        }

        public static void IncreaseArmor()
        {
            if (Armor >= 0)
                Armor += Multiplier;
        }

        public static void IncreaseMoveSpeed()
        {
            if (MoveSpeed >= 7)
                MoveSpeed += Multiplier;
        }

        public static void IncreaseMultiplier()
        {
            if (Multiplier == 1)
                Multiplier = 10;
            else if (Multiplier >= 10)
                Multiplier += 10;
        }

        public static void DecreaseDmgPerLevel()
        {
            if (DamagePerLevel > Multiplier)
                DamagePerLevel -= Multiplier;
        }

        public static void DecreaseCritPerLevel()
        {
            if (CritPerLevel > Multiplier)
                CritPerLevel -= Multiplier;
        }

        public static void DecreaseAttackSpeed()
        {
            if (AttackSpeed > Multiplier)
                AttackSpeed -= Multiplier;
        }

        public static void DecreaseArmor()
        {
            if (Armor > Multiplier)
                Armor -= 10;
        }

        public static void DecreaseMoveSpeed()
        {
            if (MoveSpeed > 7)
                MoveSpeed -= Multiplier;
        }

        public static void DecreaseMultiplier()
        {
            if (Multiplier == 10)
                Multiplier = 1;
            else if (Multiplier > 10)
                Multiplier -= 10;
        }
        #endregion
    }
}
