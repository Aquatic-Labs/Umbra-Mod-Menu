using System;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Collections.Generic;
using RoR2;
using Console = RoR2.Console;
using UnityEngine;

namespace UmbraRoR
{
    public class Utility
    {
        public static bool CursorIsVisible()
        {
            foreach (var mpeventSystem in RoR2.UI.MPEventSystem.readOnlyInstancesList)
                if (mpeventSystem.isCursorVisible)
                    return true;
            return false;
        }

        // More posibilities here using console.
        // Not added to ui yet.
        public static void BanPlayer(NetworkUser PlayerName, NetworkUser LocalNetworkUser)
        {
            Console.instance.RunClientCmd(LocalNetworkUser, "ban_steam", new string[] { PlayerName.Network_id.steamId.ToString() });
        }

        public static void KickPlayer(NetworkUser PlayerName, NetworkUser LocalNetworkUser)
        {
            Console.instance.RunClientCmd(LocalNetworkUser, "kick_steam", new string[] { PlayerName.Network_id.steamId.ToString() });
        }

        public static NetworkUser GetNetUserFromString(string playerString)
        {
            if (playerString != "")
            {
                if (int.TryParse(playerString, out int result))
                {
                    if (result < NetworkUser.readOnlyInstancesList.Count && result >= 0)
                    {
                        return NetworkUser.readOnlyInstancesList[result];
                    }
                    return null;
                }
                else
                {
                    foreach (NetworkUser n in NetworkUser.readOnlyInstancesList)
                    {
                        if (n.userName.Equals(playerString, StringComparison.CurrentCultureIgnoreCase))
                        {
                            return n;
                        }
                    }
                    return null;
                }
            }
            return null;
        }

        public static void GetPlayers(string[] Players)
        {
            NetworkUser n;
            for (int i = 0; i < NetworkUser.readOnlyInstancesList.Count; i++)
            {
                n = NetworkUser.readOnlyInstancesList[i];

                Players[i] = n.userName;
            }
        }

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
            Main._isEquipmentSpawnMenuOpen = false;
            Main._isBuffMenuOpen = false;
            Main._isItemManagerOpen = false;
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
            ItemManager.isDropItemForAll = false;
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

        }

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

        public static int NumberOfPlayers()
        {
            GetPlayers(Main.Players);
            int numberOfPlayers = 0;
            for (int i = 0; i < Main.Players.Length; i++)
            {
                if (Main.Players[i] != null)
                {
                    numberOfPlayers++;
                }
            }
            return numberOfPlayers;
        }

        public static List<GameObject> GetBodyPrefabs()
        {
            List<GameObject> bodyPrefabs = new List<GameObject>();

            foreach (var prefab in BodyCatalog.allBodyPrefabs)
            {
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
            foreach (string equipmentName in Enum.GetNames(typeof(EquipmentIndex)))
            {
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
            foreach (string itemName in Enum.GetNames(typeof(ItemIndex)))
            {
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

        public static void WriteToLog(string logContent)
        {
            string docPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            using (StreamWriter outputFile = new StreamWriter(System.IO.Path.Combine(docPath, "UmbraLog.txt"), true))
            {
                outputFile.WriteLine(Main.log + logContent);
            }
        }

        public static int NumberOfBoolsTrue(/*int threshold,*/IEnumerable<bool> bools)
        {
            int trueCnt = 0;
            foreach (bool b in bools)
            {
                if (b)
                {
                    trueCnt++;
                    Main.menusOpen.Add(b);
                }
                else
                {
                    Main.menusOpen.Remove(b);
                }
                /*if (b && (++trueCnt > threshold))
                {
                    return true;
                }*/
            }
            return trueCnt;
        }
    }
}
