using System.Collections.Generic;
using UnityEngine;
using System;
using Umbra = UmbraMenu.Model.UmbraMod;

namespace UmbraMenu.View
{
    public class ViewStatsMenu : NormalMenu
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

        public ViewStatsMenu() : base(9, 8, new Rect(1626, 457, 20, 20), "VIEW STATS MENU")
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
            ActivatingButton = UmbraModGUI.Instance.statsModMenu.toggleViewStatsMenu;
        }

        public override void Draw()
        {
            if (IsEnabled())
            {
                SetWindow();
                base.Draw();
            }
        }

        public static void UpdateViewStats(object sender, EventArgs e)
        {
            if (Umbra.Instance.characterCollected)
            {
                if (UmbraModGUI.Instance.viewStatsMenu.IsEnabled())
                {
                    playerDamage = Umbra.LocalPlayerBody.damage;
                    playerCrit = Umbra.LocalPlayerBody.crit;
                    playerAttackSpeed = Umbra.LocalPlayerBody.attackSpeed;
                    playerArmor = Umbra.LocalPlayerBody.armor;
                    playerRegen = Umbra.LocalPlayerBody.regen;
                    playerMoveSpeed = Umbra.LocalPlayerBody.moveSpeed;
                    playerExperience = Umbra.LocalPlayerBody.experience;
                    playerMaxJumpCount = Umbra.LocalPlayerBody.maxJumpCount;
                    playerKillCount = Umbra.LocalPlayerBody.killCountServer;
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
