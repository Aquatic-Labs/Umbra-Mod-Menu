using System;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using RoR2;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using System.IO;
using Octokit;

namespace UmbraMenu
{
    public static class Utility
    {
        public static Menu FindMenuById(int id)
        {
            for (int i = 0; i < UmbraMenu.menus.Count; i++)
            {
                Menu currentMenu = UmbraMenu.menus[i];
                if (currentMenu.GetId() == id)
                {
                    return currentMenu;
                }
            }
            throw new NullReferenceException($"Menu with id '{id}' was not found");
        }

        public static Button FindButtonById(int menuId, int buttonId)
        {
            List<Button> menuButtons = FindMenuById(menuId).GetButtons();
            for (int i = 0; i < menuButtons.Count; i++)
            {
                Button currentButton = menuButtons[i];
                if (currentButton.GetId() == buttonId)
                {
                    return currentButton;
                }
            }
            throw new NullReferenceException($"Button with id '{buttonId}' was not found in menu '{menuId}'");
        }

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

        public static SurvivorIndex GetCurrentCharacter()
        {
            var bodyIndex = BodyCatalog.FindBodyIndex(UmbraMenu.LocalPlayerBody);
            var survivorIndex = SurvivorCatalog.GetSurvivorIndexFromBodyIndex(bodyIndex);
            return survivorIndex;
        }

        public static HashSet<Tuple<int, int, bool>> SaveMenuState()
        {
            HashSet<Tuple<int, int, bool>> enabledButtons = new HashSet<Tuple<int, int, bool>>();
            for (int menuId = 1; menuId < UmbraMenu.menus.Count; menuId++)
            {
                Tuple<int, int, bool> menuButtonsEnabled = new Tuple<int, int, bool>(-1, -1, false);
                try
                {
                    if (menuId != 7)
                    {
                        for (int buttonPos = 1; buttonPos < UmbraMenu.menus[menuId].GetButtons().Count + 1; buttonPos++)
                        {
                            Button currentButton = FindButtonById(menuId, buttonPos);

                            if (currentButton.IsEnabled())
                            {
                                menuButtonsEnabled = new Tuple<int, int, bool>(menuId, buttonPos, UmbraMenu.menus[menuId].IsEnabled());
                            }
                            else if (UmbraMenu.menus[menuId].IsEnabled())
                            {
                                menuButtonsEnabled = new Tuple<int, int, bool>(menuId, -1, UmbraMenu.menus[menuId].IsEnabled());
                            }
                            if (menuButtonsEnabled?.Item1 != -1)
                            {
                                enabledButtons.Add(menuButtonsEnabled);
                            }
                        }
                    }
                }
                catch (NullReferenceException e)
                {
                    continue;
                }
            }
            return enabledButtons;
        }

        public static void ReadMenuState(HashSet<Tuple<int, int, bool>> menuState)
        {
            foreach (var currentTuple in menuState)
            {
                int menuId = currentTuple.Item1;
                int buttonPos = currentTuple.Item2;
                bool isMenuOpen = currentTuple.Item3;
                try
                {
                    if (menuId != -1 && buttonPos != -1)
                    {
                        FindButtonById(menuId, buttonPos).SetEnabled(true);
                    }
                }
                catch (Exception e)
                {
                    continue;
                }
            }
        }

        public static void StubbedFunction()
        {
            return;
        }

        #region Get Lists
        public static List<string> GetAllUnlockables()
        {
            var unlockableName = new List<string>();

            var assembly = Assembly.GetExecutingAssembly();
            var resourceName = "UmbraMenu.Resources.Unlockables.txt";

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

            List<EquipmentIndex> equip = new List<EquipmentIndex>();
            List<EquipmentIndex> lunar = new List<EquipmentIndex>();
            List<EquipmentIndex> other = new List<EquipmentIndex>();

            Color32 equipColor = ColorCatalog.GetColor(ColorCatalog.ColorIndex.Equipment);
            Color32 lunarColor = ColorCatalog.GetColor(ColorCatalog.ColorIndex.LunarItem);

            string[] unreleasedEquipment = { "Count", "None" };
            var equipList = Enum.GetNames(typeof(EquipmentIndex)).ToList();
            // string[] unreleasedEquipment = { "SoulJar", "AffixYellow", "AffixGold", "GhostGun", "OrbitalLaser", "Enigma", "LunarPotion", "SoulCorruptor", "Count" };
            for (int i = 0; i < equipList.Count; i++)
            {
                string equipmentName = equipList[i];
                bool unreleasednullEquipment = unreleasedEquipment.Any(equipmentName.Contains);
                EquipmentIndex equipmentIndex = (EquipmentIndex)Enum.Parse(typeof(EquipmentIndex), equipmentName);
                if (!unreleasednullEquipment)
                {
                    Color32 currentEquipColor = ColorCatalog.GetColor(EquipmentCatalog.GetEquipmentDef(equipmentIndex).colorIndex);
                    if (currentEquipColor.Equals(equipColor)) // equipment
                    {
                        equip.Add(equipmentIndex);
                    }
                    else if (currentEquipColor.Equals(lunarColor)) // lunar equipment
                    {
                        lunar.Add(equipmentIndex);
                    }
                    else // other
                    {
                        other.Add(equipmentIndex);
                    }
                }
                else if (equipmentName == "None")
                {
                    other.Add(equipmentIndex);
                }
            }
            var result = equipment.Concat(lunar).Concat(equip).Concat(other).ToList();
            return result;
        }

        public static List<ItemIndex> GetItems()
        {
            List<ItemIndex> items = new List<ItemIndex>();

            List<ItemIndex> boss = new List<ItemIndex>();
            List<ItemIndex> tier3 = new List<ItemIndex>();
            List<ItemIndex> tier2 = new List<ItemIndex>();
            List<ItemIndex> tier1 = new List<ItemIndex>();
            List<ItemIndex> lunar = new List<ItemIndex>();
            List<ItemIndex> other = new List<ItemIndex>();

            Color32 bossColor = ColorCatalog.GetColor(ColorCatalog.ColorIndex.BossItem);
            Color32 tier3Color = ColorCatalog.GetColor(ColorCatalog.ColorIndex.Tier3Item);
            Color32 tier2Color = ColorCatalog.GetColor(ColorCatalog.ColorIndex.Tier2Item);
            Color32 tier1Color = ColorCatalog.GetColor(ColorCatalog.ColorIndex.Tier1Item);
            Color32 lunarColor = ColorCatalog.GetColor(ColorCatalog.ColorIndex.LunarItem);

            // List of null items that I remove from the item list. Will change if requested.
            string[] unreleasedItems = { "Count", "None" };
            var itemList = Enum.GetNames(typeof(ItemIndex)).ToList();
            // string[] unreleasedItems = { "AACannon", "PlasmaCore", "LevelBonus", "CooldownOnCrit", "PlantOnHit", "MageAttunement", "BoostHp", "BoostDamage", "CritHeal", "BurnNearby", "CrippleWardOnLevel", "ExtraLifeConsumed", "Ghost", "HealthDecay", "DrizzlePlayerHelper", "MonsoonPlayerHelper", "TempestOnKill", "BoostAttackSpeed", "Count", "None" };
            for (int i = 0; i < itemList.Count; i++)
            {
                string itemName = itemList[i];
                bool unreleasednullItem = unreleasedItems.Any(itemName.Contains);
                ItemIndex itemIndex = (ItemIndex)Enum.Parse(typeof(ItemIndex), itemName);
                if (!unreleasednullItem)
                {
                    Color32 itemColor = ColorCatalog.GetColor(ItemCatalog.GetItemDef(itemIndex).colorIndex);
                    if (itemColor.Equals(bossColor)) // boss
                    {
                        boss.Add(itemIndex);
                    }
                    else if (itemColor.Equals(tier3Color)) // tier 3
                    {
                        tier3.Add(itemIndex);
                    }
                    else if (itemColor.Equals(tier2Color)) // tier 2
                    {
                        tier2.Add(itemIndex);
                    }
                    else if (itemColor.Equals(tier1Color)) // tier 1
                    {
                        tier1.Add(itemIndex);
                    }
                    else if (itemColor.Equals(lunarColor)) // lunar
                    {
                        lunar.Add(itemIndex);
                    }
                    else // Other
                    {
                        other.Add(itemIndex);
                    }
                }
            }
            var result = items.Concat(boss).Concat(tier3).Concat(tier2).Concat(tier1).Concat(lunar).Concat(other).ToList();
            return result;
        }

        public static List<SpawnCard> GetSpawnCards()
        {
            List<SpawnCard> spawnCards = Resources.FindObjectsOfTypeAll<SpawnCard>().ToList();
            return spawnCards;
        }

        public static List<HurtBox> GetHurtBoxes()
        {
            string[] allowedBoxes = { "Golem", "Jellyfish", "Wisp", "Beetle", "Lemurian", "Imp", "HermitCrab", "ClayBruiser", "Bell", "BeetleGuard", "MiniMushroom", "Bison", "GreaterWisp", "LemurianBruiser", "RoboBallMini", "Vulture",  /* BOSSES */ "BeetleQueen2", "ClayDunestrider", "Titan", "TitanGold", "TitanBlackBeach", "Grovetender", "Gravekeeper", "Mithrix", "Aurelionite", "Vagrant", "MagmaWorm", "ImpBoss", "ElectricWorm", "RoboBallBoss", "Nullifier", "Parent" };
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
                if (allowedBoxes.Contains(mobName))
                {
                    updatedHurtboxes.Add(hurtBox);
                }
                /*else
                {
                    WriteToLog($"Blocked: {mobName}");
                }*/
            }
            return updatedHurtboxes;
        }
        #endregion

        #region Menu Resets
        public static void ResetMenu()
        {
            for (int i = 0; i < UmbraMenu.menus.Count; i++)
            {
                Menu currentMenu = UmbraMenu.menus[i];
                currentMenu.Reset();
            }
            UmbraMenu.characterCollected = false;
            SoftResetMenu(false);
            //Main.scrolled = false;
        }

        public static void CloseAllMenus()
        {
            for (int i = 0; i < UmbraMenu.menus.Count; i++)
            {
                if (UmbraMenu.menus[i].GetId() != 9)
                {
                    UmbraMenu.menus[i].SetEnabled(false);
                }
            }
            UmbraMenu.characterCollected = false;
        }

        // Soft reset when moving to next stage to keep player stat mods and god mode between stages
        public static void SoftResetMenu(bool preserveState)
        {
            HashSet<Tuple<int, int, bool>> savedMenuState = new HashSet<Tuple<int, int, bool>>();
            if (preserveState)
            {
                savedMenuState = SaveMenuState();
            }
            UmbraMenu.mainMenu = new Menus.Main();
            UmbraMenu.playerMenu = new Menus.Player();
            UmbraMenu.movementMenu = new Menus.Movement();
            UmbraMenu.itemsMenu = new Menus.Items();
            UmbraMenu.spawnMenu = new Menus.Spawn();
            UmbraMenu.teleporterMenu = new Menus.Teleporter();
            UmbraMenu.renderMenu = new Menus.Render();

            UmbraMenu.statsModMenu = new Menus.StatsMod();
            UmbraMenu.viewStatsMenu = new Menus.ViewStats();
            UmbraMenu.characterListMenu = new Menus.CharacterList();
            UmbraMenu.buffListMenu = new Menus.BuffList();

            UmbraMenu.itemListMenu = new Menus.ItemList();
            UmbraMenu.equipmentListMenu = new Menus.EquipmentList();
            UmbraMenu.chestItemListMenu = new Menus.ChestItemList();

            UmbraMenu.spawnListMenu = new Menus.SpawnList();

            UmbraMenu.menus = new List<Menu>()
            {
                UmbraMenu.mainMenu, //0
                UmbraMenu.playerMenu, //1
                UmbraMenu.movementMenu, //2
                UmbraMenu.itemsMenu, //3
                UmbraMenu.spawnMenu, //4
                UmbraMenu.teleporterMenu, //5
                UmbraMenu.renderMenu, //6
                UmbraMenu.statsModMenu, //8
                UmbraMenu.viewStatsMenu, //9
                UmbraMenu.characterListMenu, //10
                UmbraMenu.buffListMenu, //11
                UmbraMenu.itemListMenu, //12
                UmbraMenu.equipmentListMenu, //13
                UmbraMenu.chestItemListMenu, //14
                UmbraMenu.spawnListMenu //15
            };
            if (preserveState)
            {
                ReadMenuState(savedMenuState);
            }

            if (UmbraMenu.lowResolutionMonitor)
            {
                UmbraMenu.mainMenu.SetRect(new Rect(10, 10, 20, 20)); // Start Position
                UmbraMenu.playerMenu.SetRect(new Rect(374, 10, 20, 20)); // Start Position
                UmbraMenu.movementMenu.SetRect(new Rect(374, 10, 20, 20)); // Start Position
                UmbraMenu.itemsMenu.SetRect(new Rect(374, 10, 20, 20)); // Start Position
                UmbraMenu.spawnMenu.SetRect(new Rect(374, 10, 20, 20)); // Start Position
                UmbraMenu.teleporterMenu.SetRect(new Rect(374, 10, 20, 20)); // Start Position
                UmbraMenu.renderMenu.SetRect(new Rect(374, 10, 20, 20)); // Start Position
                //UmbraMenu.settingsMenu.SetRect(new Rect(374, 10, 20, 20)); // Start Position

                UmbraMenu.statsModMenu.SetRect(new Rect(374, 10, 20, 20)); // Start Position
                UmbraMenu.viewStatsMenu.SetRect(new Rect(374, 10, 20, 20)); // Start Position
                UmbraMenu.characterListMenu.SetRect(new Rect(374, 10, 20, 20)); // Start Position
                UmbraMenu.buffListMenu.SetRect(new Rect(374, 10, 20, 20)); // Start Position
                UmbraMenu.itemListMenu.SetRect(new Rect(374, 10, 20, 20)); // Start Position
                UmbraMenu.equipmentListMenu.SetRect(new Rect(374, 10, 20, 20)); // Start Position
                UmbraMenu.chestItemListMenu.SetRect(new Rect(374, 10, 20, 20)); // Start Position
                UmbraMenu.spawnListMenu.SetRect(new Rect(374, 10, 20, 20)); // Start Position*/
            }
        }
        #endregion

        public static List<Menu> GetMenusOpen()
        {
            List<Menu> openMenus = new List<Menu>();
            for (int i = 1; i < UmbraMenu.menus.Count; i++)
            {
                if (UmbraMenu.menus[i].IsEnabled())
                {
                    openMenus.Add(UmbraMenu.menus[i]);
                }
            }
            return openMenus;
        }

        #region Debugging
        public static void WriteToLog(string logContent)
        {
            string docPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            using (StreamWriter outputFile = new StreamWriter(System.IO.Path.Combine(docPath, "UmbraLog.txt"), true))
            {
                outputFile.WriteLine("[UmbraMenu]: " + logContent);
            }
        }
        #endregion
    }
}
