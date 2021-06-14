using System.Collections.Generic;
using UnityEngine;

namespace UmbraMenu.Menus
{
    public class ViewStats : NormalMenu
    {
        private static float playerDamage, playerCrit, playerAttackSpeed, playerArmor, playerRegen, playerMoveSpeed, playerExperience;
        private static int playerMaxJumpCount, playerKillCount;

        public static TextButton damageStat;
        public static TextButton critStat;
        public static TextButton attackSpeedStat;
        public static TextButton armorStat;
        public static TextButton regenStat;
        public static TextButton moveSpeedStat;
        public static TextButton jumpCountStat;
        public static TextButton experienceStat;
        public static TextButton killsStat;

        public ViewStats() : base(9, 8, new Rect(1626, 457, 20, 20), "VIEW STATS MENU")
        {
            damageStat = new TextButton(this, 1, $"DAMAGE : {playerDamage}");
            critStat = new TextButton(this, 2, $"CRIT : {playerCrit}");
            attackSpeedStat = new TextButton(this, 3, $"ATTACK SPEED : {playerAttackSpeed}");
            armorStat = new TextButton(this, 4, $"ARMOR : {playerArmor}");
            regenStat = new TextButton(this, 5, $"REGEN : {playerRegen}");
            moveSpeedStat = new TextButton(this, 6, $"MOVE SPEED : {playerMoveSpeed}");
            jumpCountStat = new TextButton(this, 7, $"JUMP COUNT : {playerMaxJumpCount}");
            experienceStat = new TextButton(this, 8, $"EXPERIENCE : {playerExperience}");
            killsStat = new TextButton(this, 9, $"KILLS: {playerKillCount}");

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
            ActivatingButton = UmbraMenu.statsModMenu.toggleViewStatsMenu;
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
            if (UmbraMenu.characterCollected)
            {
                if (UmbraMenu.viewStatsMenu.IsEnabled())
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

                damageStat.SetText($"DAMAGE : {playerDamage}");
                critStat.SetText($"CRIT : {playerCrit}");
                attackSpeedStat.SetText($"ATTACK SPEED : {playerAttackSpeed}");
                armorStat.SetText($"ARMOR : {playerArmor}");
                regenStat.SetText($"REGEN : {playerRegen}");
                moveSpeedStat.SetText($"MOVE SPEED : {playerMoveSpeed}");
                jumpCountStat.SetText($"JUMP COUNT : {playerMaxJumpCount}");
                experienceStat.SetText($"EXPERIENCE : {playerExperience}");
                killsStat.SetText($"KILLS: {playerKillCount}");
            }
        }
    }
}
