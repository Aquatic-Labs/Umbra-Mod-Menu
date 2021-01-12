using System.Collections.Generic;
using RoR2;
using UnityEngine;

namespace UmbraMenu.Menus
{
    public class ViewStats
    {
        private static readonly Menu currentMenu = null; // (Menu)Utility.FindMenuById(9);

        private static float playerDamage, playerCrit, playerAttackSpeed, playerArmor, playerRegen, playerMoveSpeed, playerExperience;
        private static int playerMaxJumpCount, playerKillCount;

        public static TextButton damageStat = new TextButton(currentMenu, 1, $"D A M A G E : {playerDamage}");
        public static TextButton critStat = new TextButton(currentMenu, 2, $"C R I T : {playerCrit}");
        public static TextButton attackSpeedStat = new TextButton(currentMenu, 3, $"A T T A C K   S P E E D : {playerAttackSpeed}");
        public static TextButton armorStat = new TextButton(currentMenu, 4, $"A R M O R : {playerArmor}");
        public static TextButton regenStat = new TextButton(currentMenu, 5, $"R E G E N : {playerRegen}");
        public static TextButton moveSpeedStat = new TextButton(currentMenu, 6, $"M O V E   S P E E D : {playerMoveSpeed}");
        public static TextButton jumpCountStat = new TextButton(currentMenu, 7, $"J U M P   C O U N T : {playerMaxJumpCount}");
        public static TextButton experienceStat = new TextButton(currentMenu, 8, $"E X P E R I E N C E : {playerExperience}");
        public static TextButton killsStat = new TextButton(currentMenu, 9, $"K I L L S: {playerKillCount}");

        private static List<IButton> buttons = new List<IButton>()
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
        };

        public static void AddTextToMenu()
        {
            damageStat.style = Styles.StatsStyle;
            critStat.style = Styles.StatsStyle;
            attackSpeedStat.style = Styles.StatsStyle;
            armorStat.style = Styles.StatsStyle;
            regenStat.style = Styles.StatsStyle;
            moveSpeedStat.style = Styles.StatsStyle;
            jumpCountStat.style = Styles.StatsStyle;
            experienceStat.style = Styles.StatsStyle;
            killsStat.style = Styles.StatsStyle;
            //currentMenu.Buttons = buttons;
        }

        public static void UpdateViewStats()
        {
            if (currentMenu.IsEnabled())
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

                damageStat.Text = $"D A M A G E : {playerDamage}";
                critStat.Text = $"C R I T : {playerCrit}";
                attackSpeedStat.Text = $"A T T A C K   S P E E D : {playerAttackSpeed}";
                armorStat.Text = $"A R M O R : {playerArmor}";
                regenStat.Text = $"R E G E N : {playerRegen}";
                moveSpeedStat.Text = $"M O V E   S P E E D : {playerMoveSpeed}";
                jumpCountStat.Text = $"J U M P   C O U N T : {playerMaxJumpCount}";
                experienceStat.Text = $"E X P E R I E N C E : {playerExperience}";
                killsStat.Text = $"K I L L S: {playerKillCount}";
            }
        }
    }
}
