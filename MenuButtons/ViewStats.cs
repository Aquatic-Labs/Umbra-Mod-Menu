using System.Collections.Generic;
using RoR2;
using UnityEngine;

namespace UmbraMenu.MenuButtons
{
    public class ViewStats
    {
        private static readonly Menu currentMenu = (Menu)Utility.FindMenuById(9);

        private static float playerDamage, playerCrit, playerAttackSpeed, playerArmor, playerRegen, playerMoveSpeed, playerExperience;
        private static int playerMaxJumpCount, playerKillCount;

        public static Text damageStat = new Text(currentMenu, 1, $"D A M A G E : {playerDamage}");
        public static Text critStat = new Text(currentMenu, 2, $"C R I T : {playerCrit}");
        public static Text attackSpeedStat = new Text(currentMenu, 3, $"A T T A C K   S P E E D : {playerAttackSpeed}");
        public static Text armorStat = new Text(currentMenu, 4, $"A R M O R : {playerArmor}");
        public static Text regenStat = new Text(currentMenu, 5, $"R E G E N : {playerRegen}");
        public static Text moveSpeedStat = new Text(currentMenu, 6, $"M O V E   S P E E D : {playerMoveSpeed}");
        public static Text jumpCountStat = new Text(currentMenu, 7, $"J U M P   C O U N T : {playerMaxJumpCount}");
        public static Text experienceStat = new Text(currentMenu, 8, $"E X P E R I E N C E : {playerExperience}");
        public static Text killsStat = new Text(currentMenu, 9, $"K I L L S: {playerKillCount}");

        private static List<Buttons> buttons = new List<Buttons>()
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
            currentMenu.buttons = buttons;
        }

        public static void UpdateViewStats()
        {
            if (currentMenu.enabled)
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

                damageStat.text = $"D A M A G E : {playerDamage}";
                critStat.text = $"C R I T : {playerCrit}";
                attackSpeedStat.text = $"A T T A C K   S P E E D : {playerAttackSpeed}";
                armorStat.text = $"A R M O R : {playerArmor}";
                regenStat.text = $"R E G E N : {playerRegen}";
                moveSpeedStat.text = $"M O V E   S P E E D : {playerMoveSpeed}";
                jumpCountStat.text = $"J U M P   C O U N T : {playerMaxJumpCount}";
                experienceStat.text = $"E X P E R I E N C E : {playerExperience}";
                killsStat.text = $"K I L L S: {playerKillCount}";
            }
        }
    }
}
