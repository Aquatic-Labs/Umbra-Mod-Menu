using System.Collections.Generic;
using RoR2;
using UnityEngine;

namespace UmbraMenu.Menus
{
    public class ViewStats : Menu
    {
        private static readonly IMenu viewStats = new NormalMenu(9, new Rect(1626, 457, 20, 20), "V I E W   S T A T S   M E N U");

        private static float playerDamage, playerCrit, playerAttackSpeed, playerArmor, playerRegen, playerMoveSpeed, playerExperience;
        private static int playerMaxJumpCount, playerKillCount;

        public static Button damageStat;
        public static Button critStat;
        public static Button attackSpeedStat;
        public static Button armorStat;
        public static Button regenStat;
        public static Button moveSpeedStat;
        public static Button jumpCountStat;
        public static Button experienceStat;
        public static Button killsStat;

        public ViewStats() : base(viewStats)
        {
            if (UmbraMenu.characterCollected)
            {
                damageStat = new Button(new TextButton(this, 1, $"D A M A G E : {playerDamage}"));
                critStat = new Button(new TextButton(this, 2, $"C R I T : {playerCrit}"));
                attackSpeedStat = new Button(new TextButton(this, 3, $"A T T A C K   S P E E D : {playerAttackSpeed}"));
                armorStat = new Button(new TextButton(this, 4, $"A R M O R : {playerArmor}"));
                regenStat = new Button(new TextButton(this, 5, $"R E G E N : {playerRegen}"));
                moveSpeedStat = new Button(new TextButton(this, 6, $"M O V E   S P E E D : {playerMoveSpeed}"));
                jumpCountStat = new Button(new TextButton(this, 7, $"J U M P   C O U N T : {playerMaxJumpCount}"));
                experienceStat = new Button(new TextButton(this, 8, $"E X P E R I E N C E : {playerExperience}"));
                killsStat = new Button(new TextButton(this, 9, $"K I L L S: {playerKillCount}"));

                AddButtons(new List<Button>()
                {
                    damageStat,
                    critStat,
                    attackSpeedStat,
                    armorStat,
                    regenStat,
                    moveSpeedStat,
                    jumpCountStat,
                    experienceStat,
                    killsStat
                });
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

        public static void UpdateViewStats()
        {
            if (UmbraMenu.viewStatsMenu.IsEnabled())
            {
                if (UmbraMenu.characterCollected)
                {
                    playerDamage = UmbraMenu.LocalPlayerBody.damage;
                    playerCrit = UmbraMenu.LocalPlayerBody.crit;
                    playerAttackSpeed = UmbraMenu.LocalPlayerBody.attackSpeed;
                    playerArmor = UmbraMenu.LocalPlayerBody.armor;
                    playerRegen = UmbraMenu.LocalPlayerBody.regen;
                    playerMoveSpeed = UmbraMenu.LocalPlayerBody.moveSpeed;
                    playerExperience = UmbraMenu.LocalPlayerBody.experience;
                    playerMaxJumpCount = UmbraMenu.LocalPlayerBody.maxJumpCount;
                    playerKillCount = UmbraMenu.LocalPlayerBody.killCountServer;
                }

                damageStat.SetText($"D A M A G E : {playerDamage}");
                critStat.SetText($"C R I T : {playerCrit}");
                attackSpeedStat.SetText($"A T T A C K   S P E E D : {playerAttackSpeed}");
                armorStat.SetText($"A R M O R : {playerArmor}");
                regenStat.SetText($"R E G E N : {playerRegen}");
                moveSpeedStat.SetText($"M O V E   S P E E D : {playerMoveSpeed}");
                jumpCountStat.SetText($"J U M P   C O U N T : {playerMaxJumpCount}");
                experienceStat.SetText($"E X P E R I E N C E : {playerExperience}");
                killsStat.SetText($"K I L L S: {playerKillCount}");
            }
        }
    }
}
