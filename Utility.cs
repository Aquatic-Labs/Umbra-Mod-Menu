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
            }
            return updatedHurtboxes;
        }
        #endregion

        #region Menu Resets
        public static void ResetMenu()
        {
            for (int i = 0; i < UmbraMenu.menus.Count; i++)
            {
                UmbraMenu.menus[i].SetEnabled(false);
                UmbraMenu.menus[i].SetIfDragged(false);
            }

            for (int i = 0; i < UmbraMenu.menus.Count; i++)
            {
                UmbraMenu.menus[i].SetEnabled(false);
                UmbraMenu.menus[i].SetIfDragged(false);
            }
            UmbraMenu.characterCollected = false;

            //MenuButtons.Main.unloadMenu.Enabled = false;

            //MenuButtons.Player.toggleSkillCD.Enabled = false;
            //MenuButtons.Player.toggleGod.Enabled = false;
            //MenuButtons.Player.toggleAimbot.Enabled = false;
            //MenuButtons.Player.XPToGive = 50;
            //MenuButtons.Player.MoneyToGive = 50;
            //MenuButtons.Player.CoinsToGive = 50;

            //Menus.StatsMod.DamagePerLevel = 10;
            //Menus.StatsMod.CritPerLevel = 1;
            //Menus.StatsMod.AttackSpeed = 1;
            //Menus.StatsMod.Armor = 0;
            //Menus.StatsMod.MoveSpeed = 7;
            //Menus.StatsMod.changeDmgPerLevel.Enabled = false;
            //Menus.StatsMod.changeCritPerLevel.Enabled = false;
            //Menus.StatsMod.changeAttackSpeed.Enabled = false;
            //Menus.StatsMod.changeArmor.Enabled = false;
            //Menus.StatsMod.changeMoveSpeed.Enabled = false;

            //Menus.Movement.toggleFlight.Enabled = false;
            //Movement.toggleAlwaysSprint.Enabled = false;

            //Menus.Items.toggleEquipmentCD.SetEnabled(false);
            //Menus.Items.ItemsToRoll = 5;
            Menus.Items.isDropItemForAll = false;
            Menus.Items.isDropItemFromInventory = false;
           // Menus.Items.AllItemsQuantity = 1;

            Menus.SpawnList.onSpawnListEnable = true;
            Menus.SpawnList.DisableSpawnList();

            Menus.ChestItemList.DisableChests();

            //Menus.Render.toggleInteractESP.Enabled = false;
            //Menus.Render.toggleMobESP.Enabled = false;
            Menus.Render.onRenderIntEnable = true;
            Menus.Render.DisableInteractables();


            //Main.scrolled = false;
            //Main.onChestsEnable = true;
            //Main.onChestsDisable = false;
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

            for (int i = 0; i < UmbraMenu.menus.Count; i++)
            {
                UmbraMenu.menus[i].SetEnabled(false);
            }
            UmbraMenu.characterCollected = false;
        }

        // Soft reset when moving to next stage to keep player stat mods and god mode between stages
        public static void SoftResetMenu()
        {
            Menu MainMenu = (Menu)FindMenuById(0);
            MainMenu.ToggleMenu();
            UmbraMenu.GetCharacter();
            MainMenu.ToggleMenu();

            //MenuButtons.Player.toggleGod.Enabled = !MenuButtons.Player.toggleGod.Enabled;
            //UmbraMenu.GetCharacter();
            //MenuButtons.Player.toggleGod.Enabled = !MenuButtons.Player.toggleGod.Enabled;

            //MenuButtons.Player.toggleAimbot.Enabled = !MenuButtons.Player.toggleAimbot.Enabled;
            //UmbraMenu.GetCharacter();
            //MenuButtons.Player.toggleAimbot.Enabled = !MenuButtons.Player.toggleAimbot.Enabled;
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
