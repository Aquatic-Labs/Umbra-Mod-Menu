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
        public static object FindMenuById(int id)
        {
            for (int i = 0; i < UmbraMenu.menus.Count; i++)
            {
                Menu currentMenu = UmbraMenu.menus[i];
                if (currentMenu.id == id)
                {
                    return currentMenu;
                }
            }

            for (int i = 0; i < UmbraMenu.listMenus.Count; i++)
            {
                ListMenu currentMenu = UmbraMenu.listMenus[i];
                if (currentMenu.id == id)
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
                UmbraMenu.menus[i].enabled = false;
                UmbraMenu.menus[i].ifDragged = false;
            }

            for (int i = 0; i < UmbraMenu.listMenus.Count; i++)
            {
                UmbraMenu.listMenus[i].enabled = false;
                UmbraMenu.listMenus[i].ifDragged = false;
            }
            UmbraMenu.characterCollected = false;

            MenuButtons.Main.unloadMenu.Enabled = false;

            MenuButtons.Player.toggleSkillCD.Enabled = false;
            MenuButtons.Player.toggleGod.Enabled = false;
            MenuButtons.Player.toggleAimbot.Enabled = false;
            MenuButtons.Player.XPToGive = 50;
            MenuButtons.Player.MoneyToGive = 50;
            MenuButtons.Player.CoinsToGive = 50;

            MenuButtons.StatsMod.DamagePerLevel = 10;
            MenuButtons.StatsMod.CritPerLevel = 1;
            MenuButtons.StatsMod.AttackSpeed = 1;
            MenuButtons.StatsMod.Armor = 0;
            MenuButtons.StatsMod.MoveSpeed = 7;
            MenuButtons.StatsMod.changeDmgPerLevel.Enabled = false;
            MenuButtons.StatsMod.changeCritPerLevel.Enabled = false;
            MenuButtons.StatsMod.changeAttackSpeed.Enabled = false;
            MenuButtons.StatsMod.changeArmor.Enabled = false;
            MenuButtons.StatsMod.changeMoveSpeed.Enabled = false;

            MenuButtons.Movement.toggleFlight.Enabled = false;
            MenuButtons.Movement.toggleAlwaysSprint.Enabled = false;

            MenuButtons.Items.toggleEquipmentCD.Enabled = false;
            MenuButtons.Items.ItemsToRoll = 5;
            MenuButtons.Items.isDropItemForAll = false;
            MenuButtons.Items.isDropItemFromInventory = false;
            MenuButtons.Items.AllItemsQuantity = 1;

            MenuButtons.Render.toggleInteractESP.Enabled = false;
            MenuButtons.Render.toggleMobESP.Enabled = false;
            MenuButtons.Render.onRenderIntEnable = true;

            //Main.scrolled = false;
            //Main.onChestsEnable = true;
            //Main.onChestsDisable = false;
        }

        public static void CloseAllMenus()
        {
            for (int i = 0; i < UmbraMenu.menus.Count; i++)
            {
                if (UmbraMenu.menus[i].id != 9)
                {
                    UmbraMenu.menus[i].enabled = false;
                }
            }

            for (int i = 0; i < UmbraMenu.listMenus.Count; i++)
            {
                UmbraMenu.listMenus[i].enabled = false;
            }
            UmbraMenu.characterCollected = false;
        }

        // Soft reset when moving to next stage to keep player stat mods and god mode between stages
        public static void SoftResetMenu()
        {
            Menu MainMenu = (Menu)FindMenuById(0);
            MainMenu.enabled = !MainMenu.enabled;
            UmbraMenu.GetCharacter();
            MainMenu.enabled = !MainMenu.enabled;

            MenuButtons.Player.toggleGod.Enabled = !MenuButtons.Player.toggleGod.Enabled;
            UmbraMenu.GetCharacter();
            MenuButtons.Player.toggleGod.Enabled = !MenuButtons.Player.toggleGod.Enabled;

            MenuButtons.Player.toggleAimbot.Enabled = !MenuButtons.Player.toggleAimbot.Enabled;
            UmbraMenu.GetCharacter();
            MenuButtons.Player.toggleAimbot.Enabled = !MenuButtons.Player.toggleAimbot.Enabled;
        }
        #endregion
    }
}
