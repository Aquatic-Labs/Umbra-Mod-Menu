using UnityEngine;
using RoR2;
using System.Collections.Generic;
using System.Linq;
using System;

namespace UmbraMenu.Model.Cheats
{
    public static class Teleporter
    {
        public static int mountainStacks = 0;

        public static void InstaTeleporter()
        {
            if (TeleporterInteraction.instance)
            {
                TeleporterInteraction.instance.holdoutZoneController.baseChargeDuration = 1;
            }
            else
            {
                var purchaseInteractions = UnityEngine.Object.FindObjectsOfType<PurchaseInteraction>().ToList();
                foreach (PurchaseInteraction purchaseInteraction in purchaseInteractions)
                {
                    var holdoutZone = purchaseInteraction?.gameObject.GetComponent<HoldoutZoneController>();
                    holdoutZone.baseChargeDuration = 1;
                }
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
