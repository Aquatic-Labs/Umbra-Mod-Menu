using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using RoR2;

namespace UmbraMenu.Menus
{
    public class SpawnList : Menu
    {
        private static readonly IMenu spawnList = new ListMenu(15, new Rect(1503, 10, 20, 20), "S P A W N   C A R D S   M E N U");

        public SpawnList() : base(spawnList)
        {
            if (UmbraMenu.characterCollected)
            {
                EnableSpawnList();

                List<Button> buttons = new List<Button>();
                for (int i = 0; i < UmbraMenu.spawnCards.Count; i++)
                {
                    var spawnCard = UmbraMenu.spawnCards[i];
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

                    void ButtonAction() => SpawnSpawnCard(spawnCard);
                    Button button = new Button(new NormalButton(this, i + 1, buttonText, ButtonAction));
                    buttons.Add(button);
                }
                AddButtons(buttons);
                SetActivatingButton(Utility.FindButtonById(4, 4));
                SetPrevMenuId(4);
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

        public override void Reset()
        {
            DisableSpawnList();
            base.Reset();
        }
        private static void SpawnSpawnCard(SpawnCard spawnCard)
        {
            var localUser = LocalUserManager.GetFirstLocalUser();
            var body = localUser.cachedMasterController.master.GetBody().transform;
            if (localUser.cachedMasterController && localUser.cachedMasterController.master)
            {
                var directorSpawnRequest = new DirectorSpawnRequest(spawnCard, new DirectorPlacementRule
                {
                    placementMode = DirectorPlacementRule.PlacementMode.Approximate,
                    minDistance = Spawn.minDistance,
                    maxDistance = Spawn.maxDistance,
                    position = UmbraMenu.LocalPlayerBody.footPosition
                }, RoR2Application.rng)
                {
                    ignoreTeamMemberLimit = true,
                    teamIndexOverride = Spawn.team[Spawn.teamIndex]
                };

                directorSpawnRequest.spawnCard.sendOverNetwork = true;

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

                if (cardName.Contains("isc"))
                {
                    var interactable = Resources.Load<SpawnCard>(path).DoSpawn(body.position + (Vector3.forward * Spawn.minDistance), body.rotation, directorSpawnRequest).spawnedInstance.gameObject;
                    Spawn.spawnedObjects.Add(interactable);
                    Chat.AddMessage($"<color=yellow>Spawned \"{buttonText}\"</color>");
                }
                else
                {
                    DirectorCore.instance.TrySpawnObject(directorSpawnRequest);
                    Chat.AddMessage($"<color=yellow>Spawned \"{buttonText}\" on team \"{Spawn.team[Spawn.teamIndex]}\" </color>");
                }
            }
        }

        public static bool onSpawnListEnable = true;
        public static void EnableSpawnList()
        {
            if (onSpawnListEnable)
            {
                DumpInteractables(null);
                SceneDirector.onPostPopulateSceneServer += DumpInteractables;
                onSpawnListEnable = false;
            }
            else
            {
                return;
            }
        }

        public static void DisableSpawnList()
        {
            if (!onSpawnListEnable)
            {
                SceneDirector.onPostPopulateSceneServer -= DumpInteractables;
                onSpawnListEnable = true;
            }
            else
            {
                return;
            }
        }

        private static void DumpInteractables(SceneDirector obj)
        {
            UmbraMenu.spawnCards = Utility.GetSpawnCards();
        }
    }
}
