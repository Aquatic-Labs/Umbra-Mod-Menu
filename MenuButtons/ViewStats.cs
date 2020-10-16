using EntityStates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UmbraMenu.MenuButtons
{
    class ViewStats
    {
        private static readonly Menu currentMenu = (Menu)Utility.FindMenuById(15);

        public static Text damageStat = new Text(currentMenu, 1, $"D A M A G E : {UmbraMenu.LocalPlayerBody.damage}");
        public static Text critStat = new Text(currentMenu, 2, $"C R I T : {UmbraMenu.LocalPlayerBody.crit}");
        public static Text attackSpeedStat = new Text(currentMenu, 3, $"A T T A C K   S P E E D : {UmbraMenu.LocalPlayerBody.attackSpeed}");
        public static Text armorStat = new Text(currentMenu, 4, $"A R M O R : {UmbraMenu.LocalPlayerBody.armor}");
        public static Text regenStat = new Text(currentMenu, 5, $"R E G E N : {UmbraMenu.LocalPlayerBody.regen}");
        public static Text moveSpeedStat = new Text(currentMenu, 6, $"M O V E   S P E E D : {UmbraMenu.LocalPlayerBody.moveSpeed}");
        public static Text jumpCountStat = new Text(currentMenu, 7, $"J U M P   C O U N T : {UmbraMenu.LocalPlayerBody.maxJumpCount}");
        public static Text experienceStat = new Text(currentMenu, 8, $"E X P E R I E N C E : {UmbraMenu.LocalPlayerBody.experience}");
        public static Text killsStat = new Text(currentMenu, 9, $"K I L L S: {UmbraMenu.LocalPlayerBody.killCountServer}");

        public static List<Buttons> buttons = new List<Buttons>()
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
                damageStat.text = $"D A M A G E : {UmbraMenu.LocalPlayerBody.damage}";
                critStat.text = $"C R I T : {UmbraMenu.LocalPlayerBody.crit}";
                attackSpeedStat.text = $"A T T A C K   S P E E D : {UmbraMenu.LocalPlayerBody.attackSpeed}";
                armorStat.text = $"A R M O R : {UmbraMenu.LocalPlayerBody.armor}";
                regenStat.text = $"R E G E N : {UmbraMenu.LocalPlayerBody.regen}";
                moveSpeedStat.text = $"M O V E   S P E E D : {UmbraMenu.LocalPlayerBody.moveSpeed}";
                jumpCountStat.text = $"J U M P   C O U N T : {UmbraMenu.LocalPlayerBody.maxJumpCount}";
                experienceStat.text = $"E X P E R I E N C E : {UmbraMenu.LocalPlayerBody.experience}";
                killsStat.text = $"K I L L S: {UmbraMenu.LocalPlayerBody.killCountServer}";
            }
        }
    }
}
