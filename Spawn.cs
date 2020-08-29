using UnityEngine;
using RoR2;
using System.Collections.Generic;
using System;
using System.Linq;

namespace UmbraRoR
{
    class Spawn : MonoBehaviour
    {
        public static TeamIndex[] team = { TeamIndex.Monster, TeamIndex.Neutral, TeamIndex.Player, TeamIndex.None };
        public static int teamIndex = 0;
        public static float minDistance = 3f;
        public static float maxDistance = 40f;
        public static List<GameObject> spawnedObjects = new List<GameObject>();

        public static void SpawnMob(GUIStyle buttonStyle, string buttonId)
        {
            int buttonPlacement = 1;
            foreach (var spawnCard in Main.spawnCards)
            {
                string cardName = spawnCard.ToString();
                string category = "";
                string buttonText = "";
                if (cardName.Contains("MultiCharacterSpawnCard"))
                {
                    cardName = cardName.Replace(" (RoR2.MultiCharacterSpawnCard)", "");
                    category = "CharacterSpawnCard";
                    buttonText = cardName.Replace("csc", "");
                }
                else if (cardName.Contains("CharacterSpawnCard"))
                {
                    cardName = cardName.Replace(" (RoR2.CharacterSpawnCard)", "");
                    category = "CharacterSpawnCard";
                    buttonText = cardName.Replace("csc", "");
                }
                else if (cardName.Contains("InteractableSpawnCard"))
                {
                    cardName = cardName.Replace(" (RoR2.InteractableSpawnCard)", "");
                    category = "InteractableSpawnCard";
                    buttonText = cardName.Replace("isc", "");
                }
                else if (cardName.Contains("BodySpawnCard"))
                {
                    cardName = cardName.Replace(" (RoR2.BodySpawnCard)", "");
                    category = "BodySpawnCard";
                    buttonText = cardName.Replace("bsc", "");
                }
                string path = $"SpawnCards/{category}/{cardName}";

                DrawMenu.DrawButton(buttonPlacement, buttonId, buttonText, buttonStyle);
                buttonPlacement++;
            }
        }

        public static void KillAllMobs()
        {
            var localUser = LocalUserManager.GetFirstLocalUser();
            var controller = localUser.cachedMasterController;
            if (!controller)
            {
                return;
            }
            var body = controller.master.GetBody();
            if (!body)
            {
                return;
            }

            var bullseyeSearch = new BullseyeSearch
            {
                filterByLoS = false,
                maxDistanceFilter = float.MaxValue,
                maxAngleFilter = float.MaxValue
            };

            bullseyeSearch.RefreshCandidates();
            var hurtBoxList = bullseyeSearch.GetResults();
            foreach (var hurtbox in hurtBoxList)
            {
                var mob = HurtBox.FindEntityObject(hurtbox);
                string mobName = mob.name.Replace("Body(Clone)", "");
                if (Enum.GetNames(typeof(SurvivorIndex)).Contains(mobName))
                {
                    continue;
                }
                else
                {
                    var health = mob.GetComponent<HealthComponent>();
                    health.Suicide();
                    Chat.AddMessage($"<color=yellow>Killed {mobName} </color>");
                }

            }
        }

        public static void DestroySpawnedInteractables()
        {
            var localUser = LocalUserManager.GetFirstLocalUser();
            var controller = localUser.cachedMasterController;
            if (!controller)
            {
                return;
            }
            var body = controller.master.GetBody();
            if (!body)
            {
                return;
            }

            if (spawnedObjects != null)
            {
                foreach (var gameObject in spawnedObjects)
                {
                    UnityEngine.Object.Destroy(gameObject);
                    Chat.AddMessage($"<color=yellow>Destroyed {gameObject.name.Replace("(Clone)", "")} </color>");
                }
                spawnedObjects = new List<GameObject>();
            }
        }
    }
}
