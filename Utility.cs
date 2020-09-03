using System;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Collections.Generic;
using RoR2;
using UnityEngine;

namespace UmbraRoR
{
    public class Utility : MonoBehaviour
    {
        #region Menu Resets
        // Reset menu when you return to main menu
        public static void ResetMenu()
        {
            Main._ifDragged = false;
            Main._CharacterCollected = false;
            Main._isStatMenuOpen = false;
            Main._isTeleMenuOpen = false;
            Main._isESPMenuOpen = false;
            Main._isChangeCharacterMenuOpen = false;
            Main._isLobbyMenuOpen = false;
            Main._isEditStatsOpen = false;
            Main._isItemSpawnMenuOpen = false;
            Main._isPlayerMod = false;
            Main._isMovementOpen = false;
            Main._isEquipmentSpawnMenuOpen = false;
            Main._isBuffMenuOpen = false;
            Main._isItemManagerOpen = false;
            Main._isSpawnListMenuOpen = false;
            Main._isSpawnMenuOpen = false;
            Main._isChestItemListOpen = false;
            Main.damageToggle = false;
            Main.noEquipmentCooldown = false;
            Main.critToggle = false;
            Main.skillToggle = false;
            Main.renderInteractables = false;
            Main.renderMobs = false;
            Main.attackSpeedToggle = false;
            Main.armorToggle = false;
            Main.regenToggle = false;
            Main.moveSpeedToggle = false;
            Main.FlightToggle = false;
            Main.godToggle = false;
            Main.alwaysSprint = false;
            Main.aimBot = false;
            Main.unloadConfirm = false;
            Main.scrolled = false;
            Main.onChestsEnable = true;
            Main.onChestsDisable = false;
            Main.onRenderIntEnable = true;
            Main.onRenderIntDisable = false;
            ItemManager.itemsToRoll = 5;
            ItemManager.isDropItemForAll = false;
            ItemManager.isDropItemFromInventory = false;
            ItemManager.allItemsQuantity = 1;
            PlayerMod.damagePerLvl = 10;
            PlayerMod.CritPerLvl = 1;
            PlayerMod.attackSpeed = 1;
            PlayerMod.armor = 0;
            PlayerMod.movespeed = 7;
            PlayerMod.jumpCount = 1;
            PlayerMod.xpToGive = 50;
            PlayerMod.moneyToGive = 50;
            PlayerMod.coinsToGive = 50;
        }

        public static void CloseAllMenus()
        {
            Main._CharacterCollected = false;
            Main._isTeleMenuOpen = false;
            Main._isESPMenuOpen = false;
            Main._isChangeCharacterMenuOpen = false;
            Main._isLobbyMenuOpen = false;
            Main._isEditStatsOpen = false;
            Main._isItemSpawnMenuOpen = false;
            Main._isPlayerMod = false;
            Main._isEquipmentSpawnMenuOpen = false;
            Main._isBuffMenuOpen = false;
            Main._isItemManagerOpen = false;
            Main._isMovementOpen = false;
            Main._isSpawnListMenuOpen = false;
            Main._isSpawnMenuOpen = false;
        }

        // Soft reset when moving to next stage to keep player stat mods and god mode between stages
        public static void SoftResetMenu()
        {
            Main._isMenuOpen = !Main._isMenuOpen;
            Main.GetCharacter();
            Main._isMenuOpen = !Main._isMenuOpen;
            Main.godToggle = !Main.godToggle;
            Main.GetCharacter();
            Main.godToggle = !Main.godToggle;
            Main.aimBot = !Main.aimBot;
            Main.GetCharacter();
            Main.aimBot = !Main.aimBot;
        }
        #endregion

        #region Get Lists
        public static List<string> GetAllUnlockables()
        {
            var unlockableName = new List<string>();

            var assembly = Assembly.GetExecutingAssembly();
            var resourceName = "UmbraRoR.Resources.Unlockables.txt";

            Stream stream = assembly.GetManifestResourceStream(resourceName);
            StreamReader reader = new StreamReader(stream);
            while (!reader.EndOfStream)
            {
                string line1 = reader.ReadLine();
                line1 = line1.Replace("UnlockableCatalog.RegisterUnlockable(\"", "");
                line1 = line1.Replace("\", new UnlockableDef", "");
                line1 = line1.Replace("true", "");
                line1 = line1.Replace("});", "");
                line1 = line1.Replace("=", "");
                line1 = line1.Replace("\"", "");
                line1 = line1.Replace("false", "");
                line1 = line1.Replace(",", "");
                line1 = line1.Replace("hidden", "");
                line1 = line1.Replace("{", "");
                line1 = line1.Replace("nameToken", "");
                line1 = line1.Replace(" ", "");
                string[] lineArray = line1.Split(null);
                foreach (var line in lineArray)
                {
                    // TODO: Simplify later
                    if (line.StartsWith("Logs.") || line.StartsWith("Characters.") || line.StartsWith("Items.") || line.StartsWith("Skills.") || line.StartsWith("Skins.") || line.StartsWith("Shop.") || line.StartsWith("Artifacts.") || line.StartsWith("NewtStatue."))
                    {
                        unlockableName.Add(line);
                    }
                }
            }
            return unlockableName;
        }

        public static List<GameObject> GetBodyPrefabs()
        {
            List<GameObject> bodyPrefabs = new List<GameObject>();

            for (int i = 0; i < BodyCatalog.allBodyPrefabs.Count(); i++)
            {
                var prefab = BodyCatalog.allBodyPrefabs.ElementAt(i);
                if (prefab.name != "ScavSackProjectile")
                {
                    bodyPrefabs.Add(prefab);
                }
            }
            return bodyPrefabs;
        }

        public static List<EquipmentIndex> GetEquipment()
        {
            List<EquipmentIndex> equipment = new List<EquipmentIndex>();

            string[] unreleasedEquipment = { "Count" };
            // string[] unreleasedEquipment = { "SoulJar", "AffixYellow", "AffixGold", "GhostGun", "OrbitalLaser", "Enigma", "LunarPotion", "SoulCorruptor", "Count" };
            for (int i = 0; i < Enum.GetNames(typeof(EquipmentIndex)).Length; i++)
            {
                string equipmentName = Enum.GetNames(typeof(EquipmentIndex))[i];
                bool unreleasednullEquipment = unreleasedEquipment.Any(equipmentName.Contains);
                if (!unreleasednullEquipment)
                {
                    EquipmentIndex equipmentIndex = (EquipmentIndex)Enum.Parse(typeof(EquipmentIndex), equipmentName);
                    equipment.Add(equipmentIndex);
                }
            }
            return equipment;
        }

        public static List<ItemIndex> GetItems()
        {
            List<ItemIndex> items = new List<ItemIndex>();

            // List of null items that I remove from the item list. Will change if requested.
            string[] unreleasedItems = { "LevelBonus", "PlantOnHit", "MageAttunement", "BoostHp", "BoostDamage", "CritHeal", "BurnNearby", "CrippleWardOnLevel", "ExtraLifeConsumed", "Ghost", "HealthDecay", "DrizzlePlayerHelper", "MonsoonPlayerHelper", "BoostAttackSpeed", "Count", "None" };
            // string[] unreleasedItems = { "AACannon", "PlasmaCore", "LevelBonus", "CooldownOnCrit", "PlantOnHit", "MageAttunement", "BoostHp", "BoostDamage", "CritHeal", "BurnNearby", "CrippleWardOnLevel", "ExtraLifeConsumed", "Ghost", "HealthDecay", "DrizzlePlayerHelper", "MonsoonPlayerHelper", "TempestOnKill", "BoostAttackSpeed", "Count", "None" };
            for (int i = 0; i < Enum.GetNames(typeof(ItemIndex)).Length; i++)
            {

                string itemName = Enum.GetNames(typeof(ItemIndex))[i];
                bool unreleasednullItem = unreleasedItems.Any(itemName.Contains);
                ItemIndex itemIndex = (ItemIndex)Enum.Parse(typeof(ItemIndex), itemName);
                if (!unreleasednullItem)
                {
                    items.Add(itemIndex);
                }
                // Since "Ghost" is null item, "GhostOnKill" was getting removed from item list.
                else if (itemName == "GhostOnKill")
                {
                    items.Add(itemIndex);
                }
            }
            return items;
        }

        public static List<SpawnCard> GetSpawnCards()
        {
            List<SpawnCard> spawnCards = Resources.FindObjectsOfTypeAll<SpawnCard>().ToList();
            return spawnCards;
        }

        public static List<HurtBox> GetHurtBoxes()
        {
            var localUser = LocalUserManager.GetFirstLocalUser();
            var controller = localUser.cachedMasterController;
            if (!controller)
            {
                return null;
            }
            var body = controller.master.GetBody();
            if (!body)
            {
                return null;
            }

            var inputBank = body.GetComponent<InputBankTest>();
            var aimRay = new Ray(inputBank.aimOrigin, inputBank.aimDirection);
            var bullseyeSearch = new BullseyeSearch();
            var team = body.GetComponent<TeamComponent>();
            bullseyeSearch.searchOrigin = aimRay.origin;
            bullseyeSearch.searchDirection = aimRay.direction;
            bullseyeSearch.filterByLoS = false;
            bullseyeSearch.maxDistanceFilter = 125;
            bullseyeSearch.maxAngleFilter = 40f;
            bullseyeSearch.teamMaskFilter = TeamMask.all;
            bullseyeSearch.teamMaskFilter.RemoveTeam(team.teamIndex);
            bullseyeSearch.RefreshCandidates();
            var hurtBoxList = bullseyeSearch.GetResults().ToList();

            List<HurtBox> updatedHurtboxes = new List<HurtBox>();

            for (int i = 0; i < hurtBoxList.Count; i++)
            {
                HurtBox hurtBox = hurtBoxList[i];

                var mobName = HurtBox.FindEntityObject(hurtBox).name.Replace("Body(Clone)", "");
                if (Main.allowedBoxes.Contains(mobName))
                {
                    updatedHurtboxes.Add(hurtBox);
                }
            }
            return updatedHurtboxes;
        }
        #endregion

        public static bool CursorIsVisible()
        {
            for (int i = 0; i < RoR2.UI.MPEventSystem.readOnlyInstancesList.Count; i++)
            {
                var mpeventSystem = RoR2.UI.MPEventSystem.readOnlyInstancesList[i];
                if (mpeventSystem.isCursorVisible) 
                { 
                    return true;
                }
            }
            return false;
        }

        public static void LoadAssembly()
        {
            AppDomain.CurrentDomain.AssemblyResolve += (sender, args) =>
            {
                String resourceName = "UmbraRoR." +
                   new AssemblyName(args.Name).Name + ".dll";

                using (var stream = Assembly.GetExecutingAssembly().GetManifestResourceStream(resourceName))
                {
                    Byte[] assemblyData = new Byte[stream.Length];
                    stream.Read(assemblyData, 0, assemblyData.Length);
                    return Assembly.Load(assemblyData);
                }
            };
        }

        public static List<float> MenusOpenKeys()
        {
            List<float> menusOpenKeys = new List<float>();
            Dictionary<float, bool> menus = new Dictionary<float, bool>()
            {
                {0, Main._isMenuOpen},
                {1, Main._isPlayerMod},
                {1.1f, Main._isChangeCharacterMenuOpen },
                {1.2f, Main._isBuffMenuOpen},
                {1.3f, Main._isEditStatsOpen},
                {2, Main._isMovementOpen},
                {3, Main._isItemManagerOpen},
                {3.1f, Main._isItemSpawnMenuOpen},
                {3.2f, Main._isEquipmentSpawnMenuOpen},
                {3.3f, Main._isChestItemListOpen},
                {4, Main._isSpawnMenuOpen},
                {4.1f, Main._isSpawnListMenuOpen},
                {5, Main._isTeleMenuOpen},
                {6, Main._isESPMenuOpen },
                {7, Main._isLobbyMenuOpen},
            };

            foreach (var menu in menus)
            {
                if (menu.Value)
                {
                    menusOpenKeys.Add(menu.Key);
                }
            }
            return menusOpenKeys;
        }

        #region Debugging
        public static void WriteToLog(string logContent)
        {
            string docPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            using (StreamWriter outputFile = new StreamWriter(System.IO.Path.Combine(docPath, "UmbraLog.txt"), true))
            {
                outputFile.WriteLine(Main.log + logContent);
            }
        }
        #endregion
    }
}