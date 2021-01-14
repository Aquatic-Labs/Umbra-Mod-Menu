using System;
using System.Collections.Generic;
using UnityEngine;
using RoR2;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UmbraMenu.Menus
{
    public class StatsMod : Menu
    {
        private static readonly IMenu statsMod = new NormalMenu(8, new Rect(1503, 10, 20, 20), "S T A T S   M O D   M E N U");

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
                if (changeDmgPerLevel.IsEnabled())
                {
                    changeDmgPerLevel.SetOffText($"D A M A G E / L V L ( O F F ) : {damagePerLvl}");
                    changeDmgPerLevel.SetOnText($"D A M A G E / L V L ( O N ) : {damagePerLvl}");
                    changeDmgPerLevel.SetText(changeDmgPerLevel.GetOnText());
                }
                else
                {
                    changeDmgPerLevel.SetOnText($"D A M A G E / L V L ( O N ) : {damagePerLvl}");
                    changeDmgPerLevel.SetOffText($"D A M A G E / L V L ( O F F ) : {damagePerLvl}");
                    changeDmgPerLevel.SetText(changeDmgPerLevel.GetOffText());
                }
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
                if (changeCritPerLevel.IsEnabled())
                {
                    changeCritPerLevel.SetOffText($"C R I T / L V L ( O F F ) : {critPerLvl}");
                    changeCritPerLevel.SetOnText($"C R I T / L V L ( O N ) : {critPerLvl}");
                    changeCritPerLevel.SetText(changeCritPerLevel.GetOnText());
                }
                else
                {
                    changeCritPerLevel.SetOnText($"C R I T / L V L ( O N ) : {critPerLvl}");
                    changeCritPerLevel.SetOffText($"C R I T / L V L ( O F F ) : {critPerLvl}");
                    changeCritPerLevel.SetText(changeCritPerLevel.GetOffText());
                }
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
                changeMultiplier.SetText($"M U L T I P L I E R : {multiplier}");
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
                if (changeAttackSpeed.IsEnabled())
                {
                    changeAttackSpeed.SetOffText($"A T T A C K   S P E E D ( O F F ) : {attackSpeed}");
                    changeAttackSpeed.SetOnText($"A T T A C K   S P E E D ( O N ) : {attackSpeed}");
                    changeAttackSpeed.SetText(changeAttackSpeed.GetOnText());
                }
                else
                {
                    changeAttackSpeed.SetOnText($"A T T A C K   S P E E D ( O N ) : {attackSpeed}");
                    changeAttackSpeed.SetOffText($"A T T A C K   S P E E D ( O F F ) : {attackSpeed}");
                    changeAttackSpeed.SetText(changeAttackSpeed.GetOffText());
                }
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
                if (changeArmor.IsEnabled())
                {
                    changeArmor.SetOffText($"A R M O R ( O F F ) : {armor}");
                    changeArmor.SetOnText($"A R M O R ( O N ) : {armor}");
                    changeArmor.SetText(changeArmor.GetOnText());
                }
                else
                {
                    changeArmor.SetOnText($"A R M O R ( O N ) : {armor}");
                    changeArmor.SetOffText($"A R M O R ( O F F ) : {armor}");
                    changeArmor.SetText(changeArmor.GetOffText());
                }
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
                if (changeMoveSpeed.IsEnabled())
                {
                    changeMoveSpeed.SetOffText($"M O V E   S P E E D ( O F F ) : {moveSpeed}");
                    changeMoveSpeed.SetOnText($"M O V E   S P E E D ( O N ) : {moveSpeed}");
                    changeMoveSpeed.SetText(changeMoveSpeed.GetOnText());
                }
                else
                {
                    changeMoveSpeed.SetOnText($"M O V E   S P E E D ( O N ) : {moveSpeed}");
                    changeMoveSpeed.SetOffText($"M O V E   S P E E D ( O F F ) : {moveSpeed}");
                    changeMoveSpeed.SetText(changeMoveSpeed.GetOffText());
                }
            }
        }
        public static bool armorToggle, attackSpeedToggle, critToggle, damageToggle, moveSpeedToggle, regenToggle;

        private static void ToggleViewStatsMenu() => Utility.FindMenuById(9).ToggleMenu();
        private static void DoNothing() => Utility.StubbedFunction();

        public Button changeDmgPerLevel;
        public Button changeCritPerLevel;
        public Button changeAttackSpeed;
        public Button changeArmor;
        public Button changeMoveSpeed;
        public Button changeMultiplier;
        public Button toggleViewStatsMenu;

        public StatsMod() : base(statsMod)
        {
            if (UmbraMenu.characterCollected)
            {
                changeDmgPerLevel = new Button(new TogglableMulButton(this, 1, $"D A M A G E / L V L ( O F F ) : {DamagePerLevel}", $"D A M A G E / L V L ( O N ) : {DamagePerLevel}", ToggleDmgPerLevel, ToggleDmgPerLevel, IncreaseDmgPerLevel, DecreaseDmgPerLevel));
                changeCritPerLevel = new Button(new TogglableMulButton(this, 2, $"C R I T / L V L ( O F F ) : {CritPerLevel}", $"C R I T / L V L ( O N ) : {CritPerLevel}", ToggleCritPerLevel, ToggleCritPerLevel, IncreaseCritPerLevel, DecreaseCritPerLevel));
                changeAttackSpeed = new Button(new TogglableMulButton(this, 3, $"A T T A C K   S P E E D ( O F F ) : {AttackSpeed}", $"A T T A C K   S P E E D ( O N ) : {AttackSpeed}", ToggleAttackSpeed, ToggleAttackSpeed, IncreaseAttackSpeed, DecreaseAttackSpeed));
                changeArmor = new Button(new TogglableMulButton(this, 4, $"A R M O R ( O F F ) : {Armor}", $"A R M O R ( O N ) : {Armor}", ToggleArmor, ToggleArmor, IncreaseArmor, DecreaseArmor));
                changeMoveSpeed = new Button(new TogglableMulButton(this, 5, $"M O V E   S P E E D ( O F F ) : {MoveSpeed}", $"M O V E   S P E E D ( O N ) : {MoveSpeed}", ToggleMoveSpeed, ToggleMoveSpeed, IncreaseMoveSpeed, DecreaseMoveSpeed));
                changeMultiplier = new Button(new MulButton(this, 6, $"M U L T I P L I E R : {Multiplier}", DoNothing, IncreaseMultiplier, DecreaseMultiplier));
                toggleViewStatsMenu = new Button(new TogglableButton(this, 7, "S H O W   S T A T S : O F F", "S H O W   S T A T S : O N", ToggleViewStatsMenu, ToggleViewStatsMenu));

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
                SetActivatingButton(Utility.FindButtonById(1, 4));
                SetPrevMenuId(1);
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
            if (DamagePerLevel >= 0)
                DamagePerLevel += Multiplier;
        }

        public void IncreaseCritPerLevel()
        {
            if (CritPerLevel >= 0)
                CritPerLevel += Multiplier;
        }

        public void IncreaseAttackSpeed()
        {
            if (AttackSpeed >= 0)
                AttackSpeed += Multiplier;
        }

        public void IncreaseArmor()
        {
            if (Armor >= 0)
                Armor += Multiplier;
        }

        public void IncreaseMoveSpeed()
        {
            if (MoveSpeed >= 7)
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
                Armor -= 10;
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
