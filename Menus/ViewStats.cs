using System.Collections.Generic;
using UnityEngine;

namespace UmbraMenu.Menus
{
    public class ViewStats : Menu
    {
        private static readonly IMenu viewStats = new NormalMenu(9, new Rect(1626, 457, 20, 20), "VIEW STATS MENU");

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
                damageStat = new Button(new TextButton(this, 1, $"DAMAGE : {playerDamage}"));
                critStat = new Button(new TextButton(this, 2, $"CRIT : {playerCrit}"));
                attackSpeedStat = new Button(new TextButton(this, 3, $"ATTACK SPEED : {playerAttackSpeed}"));
                armorStat = new Button(new TextButton(this, 4, $"ARMOR : {playerArmor}"));
                regenStat = new Button(new TextButton(this, 5, $"REGEN : {playerRegen}"));
                moveSpeedStat = new Button(new TextButton(this, 6, $"MOVE SPEED : {playerMoveSpeed}"));
                jumpCountStat = new Button(new TextButton(this, 7, $"JUMP COUNT : {playerMaxJumpCount}"));
                experienceStat = new Button(new TextButton(this, 8, $"EXPERIENCE : {playerExperience}"));
                killsStat = new Button(new TextButton(this, 9, $"KILLS: {playerKillCount}"));

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
                SetActivatingButton(Utility.FindButtonById(8, 7));
                SetPrevMenuId(8);
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
