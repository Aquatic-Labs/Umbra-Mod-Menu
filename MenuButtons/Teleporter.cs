using UnityEngine;
using RoR2;
using System.Collections.Generic;
using System;
using System.Linq;


namespace UmbraMenu.MenuButtons
{
    public class Teleporter
    {
        private static readonly Menu currentMenu = (Menu)Utility.FindMenuById(5);
        private static int mountainStacks = 0;

        private static void SpawnAllPortals() => SpawnPortals("all");
        private static void SpawnBluePortal() => SpawnPortals("blue");
        private static void SpawnCelestalPortal() => SpawnPortals("cele");
        private static void SpawnGoldPortal() => SpawnPortals("gold");
        public static Button skipStage = new Button(currentMenu, 1, "S K I P   S T A G E", SkipStage);
        public static Button instaTele = new Button(currentMenu, 2, "I N S T A N T   T E L E P O R T E R", InstaTeleporter);
        public static Button addMountain = new Button(currentMenu, 3, $"A D D   M O U N T A I N - C O U N T : {mountainStacks}", AddMountain);
        public static Button spawnAll = new Button(currentMenu, 4, "S P A W N   A L L   P O R T A L S", SpawnAllPortals);
        public static Button spawnBlue = new Button(currentMenu, 5, "S P A W N   B L U E   P O R T A L", SpawnBluePortal);
        public static Button spawnCele = new Button(currentMenu, 6, "S P A W N   C E L E S T A L   P O R T A L", SpawnCelestalPortal);
        public static Button spawnGold = new Button(currentMenu, 7, "S P A W N   G O L D   P O R T A L", SpawnGoldPortal);

        private static List<IButtons> buttons = new List<IButtons>()
        {
            skipStage,
            instaTele,
            addMountain,
            spawnAll,
            spawnBlue,
            spawnCele,
            spawnGold
        };

        public static void AddButtonsToMenu()
        {
            currentMenu.buttons = buttons;
        }

        public static void InstaTeleporter()
        {
            if (TeleporterInteraction.instance)
            {
                TeleporterInteraction.instance.holdoutZoneController.baseChargeDuration = 1;
            }
        }

        public static void SkipStage()
        {
            Run.instance.AdvanceStage(Run.instance.nextStageScene);
        }

        public static void AddMountain()
        {
            TeleporterInteraction.instance.AddShrineStack();
            mountainStacks = TeleporterInteraction.instance.shrineBonusStacks;
            addMountain.text = $"A D D   M O U N T A I N - C O U N T : {mountainStacks}";
        }

        public static void SpawnPortals(string portal)
        {
            if (TeleporterInteraction.instance)
            {
                if (portal.Equals("gold"))
                {
                    Debug.Log("UmbraMenu : Spawned Gold Portal");
                    TeleporterInteraction.instance.Network_shouldAttemptToSpawnGoldshoresPortal = true;
                    TeleporterInteraction.instance.shouldAttemptToSpawnGoldshoresPortal = true;
                }
                else if (portal.Equals("blue"))
                {
                    Debug.Log("UmbraMenu : Spawned Shop Portal");
                    TeleporterInteraction.instance.Network_shouldAttemptToSpawnShopPortal = true;
                    TeleporterInteraction.instance.shouldAttemptToSpawnShopPortal = true;
                }
                else if (portal.Equals("cele"))
                {
                    Debug.Log("UmbraMenu : Spawned Celestal Portal");
                    TeleporterInteraction.instance.Network_shouldAttemptToSpawnMSPortal = true;
                    TeleporterInteraction.instance.shouldAttemptToSpawnMSPortal = true;
                }
                else if (portal.Equals("all"))
                {
                    Debug.Log("UmbraMenu : Spawned All Portals");
                    TeleporterInteraction.instance.Network_shouldAttemptToSpawnGoldshoresPortal = true;
                    TeleporterInteraction.instance.Network_shouldAttemptToSpawnShopPortal = true;
                    TeleporterInteraction.instance.Network_shouldAttemptToSpawnMSPortal = true;

                    TeleporterInteraction.instance.shouldAttemptToSpawnGoldshoresPortal = true;
                    TeleporterInteraction.instance.shouldAttemptToSpawnShopPortal = true;
                    TeleporterInteraction.instance.shouldAttemptToSpawnMSPortal = true;
                }
            }
        }
    }
}
