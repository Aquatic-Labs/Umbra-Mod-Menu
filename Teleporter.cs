using UnityEngine;
using RoR2;

namespace UmbraRoR
{
    public class Teleporter 
    {
        public static void InstaTeleporter()
        {
            if (TeleporterInteraction.instance)
            {
                TeleporterInteraction.instance.holdoutZoneController.baseChargeDuration = 1;
            }
        }

        public static void skipStage()
        {
            Run.instance.AdvanceStage(Run.instance.nextStageScene);
        }

        public static void addMountain()
        {
            TeleporterInteraction.instance.AddShrineStack();
        }

        public static void SpawnPortals(string portal)
        {
            if (TeleporterInteraction.instance)
            {
                if (portal.Equals("gold"))
                {
                    Debug.Log("UmbraRoR : Spawned Gold Portal");
                    TeleporterInteraction.instance.shouldAttemptToSpawnGoldshoresPortal = true;
                }
                else if (portal.Equals("newt"))
                {
                    Debug.Log("UmbraRoR : Spawned Shop Portal");
                    TeleporterInteraction.instance.shouldAttemptToSpawnShopPortal = true;
                }
                else if (portal.Equals("blue"))
                {
                    Debug.Log("UmbraRoR : Spawned Celestal Portal");
                    TeleporterInteraction.instance.shouldAttemptToSpawnMSPortal = true;
                }
                else if (portal.Equals("all"))
                {
                    Debug.Log("UmbraRoR : Spawned All Portals");
                    TeleporterInteraction.instance.shouldAttemptToSpawnGoldshoresPortal = true;
                    TeleporterInteraction.instance.shouldAttemptToSpawnShopPortal = true;
                    TeleporterInteraction.instance.shouldAttemptToSpawnMSPortal = true;
                }
            }
        }
    }
}
