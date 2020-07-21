using UnityEngine;
using RoR2;

namespace UmbraRoR
{
    class Spawn
    {
        public static TeamIndex[] team = { TeamIndex.Monster, TeamIndex.Neutral, TeamIndex.Player, TeamIndex.None };
        public static int teamIndex = 0;
        public static float minDistance = 3f;
        public static float maxDistance = 40f;

        public static void SpawnMob(GUIStyle buttonStyle, GUIStyle Highlighted, string buttonName)
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

                if (GUI.Button(btn.BtnRect(buttonPlacement, false, buttonName), buttonText, Navigation.HighlighedCheck(buttonStyle, Highlighted, 4.1f, buttonPlacement)))
                {
                    var localUser = LocalUserManager.GetFirstLocalUser();
                    var body = localUser.cachedMasterController.master.GetBody().transform;
                    if (localUser.cachedMasterController && localUser.cachedMasterController.master)
                    {
                        var directorspawnrequest = new DirectorSpawnRequest(spawnCard, new DirectorPlacementRule
                        {
                            placementMode = DirectorPlacementRule.PlacementMode.Approximate,
                            minDistance = minDistance,
                            maxDistance = maxDistance,
                            position = Main.LocalPlayerBody.footPosition
                        }, RoR2Application.rng);
                        directorspawnrequest.ignoreTeamMemberLimit = true;
                        directorspawnrequest.teamIndexOverride = team[teamIndex];

                        // Add chat message
                        if (cardName.Contains("isc"))
                        {
                            Resources.Load<SpawnCard>(path).DoSpawn(body.position + (Vector3.forward * minDistance), body.rotation, directorspawnrequest);
                        }
                        else
                        {
                            DirectorCore.instance.TrySpawnObject(directorspawnrequest);
                        }
                        Chat.AddMessage($"<color=yellow>Spawned \"{buttonText}\" on team \"{team[teamIndex]}\" </color>");
                    }
                }
                buttonPlacement++;
            }
        }

        public static void KillAll()
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

            var team = body.GetComponent<TeamComponent>();
            bullseyeSearch.teamMaskFilter = TeamMask.AllExcept(team.teamIndex);
            bullseyeSearch.RefreshCandidates();
            var hurtBoxList = bullseyeSearch.GetResults();
            foreach (var hurtbox in hurtBoxList)
            {
                var mob = HurtBox.FindEntityObject(hurtbox);
                string mobName = mob.name.Replace("Body(Clone)", ""); // Create Chat message with this.
                var health = mob.GetComponent<HealthComponent>();
                health.Suicide();
                Chat.AddMessage($"<color=yellow>Killed {mobName} </color>");
            }
        }
    }
}
