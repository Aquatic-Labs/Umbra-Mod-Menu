using UnityEngine;
using RoR2;
using System.Collections.Generic;
using System;
using System.Linq;

namespace UmbraMenu.MenuButtons
{
    public class Spawn
    {
        private static readonly Menu currentMenu = (Menu)Utility.FindMenuById(4);

        public static TeamIndex[] team = { TeamIndex.Monster, TeamIndex.Neutral, TeamIndex.Player, TeamIndex.None };
        private static int teamIndex = 0;
        private static float minDistance = 3f;
        private static float maxDistance = 40f;

        public static int TeamIndexInt
        {
            get
            {
                return teamIndex;
            }
            set
            {
                teamIndex = value;
                changeTeamIndex.text = $"T E A M : {team[teamIndex]}";
            }
        }

        public static float MinDistance
        {
            get
            {
                return minDistance;
            }
            set 
            {
                minDistance = value;
                changeMinDistance.text = $"M I N   D I S T A N C E : {minDistance}";
            } 
        }

        public static float MaxDistance
        {
            get
            {
                return maxDistance;
            }
            set 
            {
                maxDistance = value;
                changeMaxDistance.text = $"M A X   D I S T A N C E : {maxDistance}";
            }
        }

        public static List<GameObject> spawnedObjects = new List<GameObject>();
        private static void DoNothing() => Utility.StubbedFunction();

        public static MulButton changeMinDistance = new MulButton(currentMenu, 1, $"M I N   D I S T A N C E : {MinDistance}", DoNothing, IncreaseMinDistance, DecreaseMinDistance);
        public static MulButton changeMaxDistance = new MulButton(currentMenu, 2, $"M A X   D I S T A N C E : {MaxDistance}", DoNothing, IncreaseMaxDistance, DecreaseMaxDistance);
        public static MulButton changeTeamIndex = new MulButton(currentMenu, 3, $"T E A M : {team[TeamIndexInt]}", DoNothing, IncreaseTeamIndex, DecreaseTeamIndex);
        public static TogglableButton toggleSpawnListMenu = new TogglableButton(currentMenu, 4, "S P A W N   L I S T : O F F", "S P A W N   L I S T : O N", ToggleSpawnListMenu, ToggleSpawnListMenu);
        public static Button killAll = new Button(currentMenu, 5, "K I L L   A L L", KillAllMobs);
        public static Button destroyInteractables = new Button(currentMenu, 6, "D E S T R O Y   I N T E R A C T A B L E S", DestroySpawnedInteractables);

        private static List<IButton> buttons = new List<IButton>()
        {
            changeMinDistance,
            changeMaxDistance,
            changeTeamIndex,
            toggleSpawnListMenu,
            killAll,
            destroyInteractables
        };

        public static void AddButtonsToMenu()
        {
            currentMenu.Buttons = buttons;
        }

        private static void ToggleMenu(IMenu menu)
        {
            menu.enabled = !menu.enabled;
        }

        private static void ToggleSpawnListMenu()
        {
            if (toggleSpawnListMenu.Enabled)
            {
                SpawnList.DisableSpawnList();
            }
            else
            {
                SpawnList.EnableSpawnList();
            }
            ToggleMenu(Utility.FindMenuById(15));
        }

        public static void SpawnMob(GUIStyle buttonStyle, string buttonId)
        {
            int buttonPlacement = 1;
            foreach (var spawnCard in UmbraMenu.spawnCards)
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

                // DrawMenu.DrawButton(buttonPlacement, buttonId, buttonText, buttonStyle);
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

        #region Increase/Decrease Value Actions
        public static void IncreaseMinDistance()
        {
            if (MinDistance < MaxDistance)
            {
                MinDistance += 1;
            }
        }

        public static void IncreaseMaxDistance()
        {
            if (MaxDistance >= MinDistance)
            {
                MaxDistance += 1;
            }
        }
        public static void IncreaseTeamIndex()
        {
            if (TeamIndexInt < 3)
            {
                TeamIndexInt += 1;
            }
            else if (TeamIndexInt == 3)
            {
                TeamIndexInt = 0;
            }
        }

        public static void DecreaseMinDistance()
        {
            if (MinDistance > 0)
            {
                MinDistance -= 1;
            }
        }

        public static void DecreaseMaxDistance()
        {
            if (MaxDistance > MinDistance)
            {
                MaxDistance -= 1;
            }
        }

        public static void DecreaseTeamIndex()
        {
            if (TeamIndexInt > 0)
            {
                TeamIndexInt -= 1;
            }
            else if (TeamIndexInt == 0)
            {
                TeamIndexInt = 3;
            }
        }
        #endregion
    }
}
