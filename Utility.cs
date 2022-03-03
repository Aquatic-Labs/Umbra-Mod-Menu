using System;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using RoR2;
using System.Reflection;
using System.IO;

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
            List<Button> menuButtons = UmbraMenu.menus[menuId].GetButtons();
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
                if (menuId != -1 && buttonPos != -1)
                {
                    FindButtonById(menuId, buttonPos).SetEnabled(true);
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

            foreach (EquipmentIndex equipmentIndex in EquipmentCatalog.equipmentList)
            {
                equip.Add(equipmentIndex);
            }

            foreach (EquipmentIndex equipmentIndex in EquipmentCatalog.enigmaEquipmentList)
            {
                lunar.Add(equipmentIndex);
            }

            var result = equipment.Concat(lunar).Concat(equip).ToList();
            return result;
        }

        public static List<ItemIndex> GetItems()
        {
            List<ItemIndex> items = new List<ItemIndex>();

            List<ItemIndex> tier3 = new List<ItemIndex>();
            List<ItemIndex> tier2 = new List<ItemIndex>();
            List<ItemIndex> tier1 = new List<ItemIndex>();
            List<ItemIndex> lunar = new List<ItemIndex>();
            List<ItemIndex> voidt = new List<ItemIndex>();

            foreach (ItemIndex itemIndex in ItemCatalog.tier1ItemList)
            {
                tier1.Add(itemIndex);
            }
            foreach (ItemIndex itemIndex in ItemCatalog.tier2ItemList)
            {
                tier2.Add(itemIndex);
            }
            foreach (ItemIndex itemIndex in ItemCatalog.tier3ItemList)
            {
                tier3.Add(itemIndex);
            }
            foreach (ItemIndex itemIndex in ItemCatalog.lunarItemList)
            {
                lunar.Add(itemIndex);
            }
            foreach (ItemDef def in ItemCatalog.allItemDefs)
            {
                if (def.tier == ItemTier.VoidTier1 || def.tier == ItemTier.VoidTier2 || def.tier == ItemTier.VoidTier3)
                {
                    voidt.Add(def.itemIndex);
                }
            }

            var result = items.Concat(tier3).Concat(tier2).Concat(tier1).Concat(lunar).Concat(voidt).ToList();


            return result;                      
        }
           
        public static List<BuffIndex> GetBossItems()
        {
            List<BuffIndex> items = new List<BuffIndex>();

            List<BuffIndex> elite = new List<BuffIndex>();
            List<BuffIndex> debuff = new List<BuffIndex>();

            foreach (BuffIndex buffIndex in BuffCatalog.debuffBuffIndices)
            {
                debuff.Add(buffIndex);

            }
            foreach (BuffIndex buffIndex in BuffCatalog.eliteBuffIndices)
            {
                elite.Add(buffIndex);
            }
            var result = items.Concat(elite).Concat(debuff).ToList();
            return result;                      
        }



        public static List<SpawnCard> GetSpawnCards()
        {
            List<SpawnCard> spawnCards = Resources.FindObjectsOfTypeAll<SpawnCard>().ToList();
            return spawnCards;
        }

        public static List<HurtBox> GetHurtBoxes()                              
        {
            string[] allowedBoxes = { "Golem", "Jellyfish", "Wisp", "Beetle", "Lemurian", "Imp", "HermitCrab", "ClayBruiser", "Bell", "BeetleGuard", "MiniMushroom", "Bison", "GreaterWisp", "LemurianBruiser", "RoboBallMini", "Vulture",  /* BOSSES */ "BeetleQueen2", "ClayDunestrider", "Titan", "TitanGold", "TitanBlackBeach", "Grovetender", "Gravekeeper", "Mithrix", "Aurelionite", "Vagrant", "MagmaWorm", "ImpBoss", "ElectricWorm", "RoboBallBoss", "Nullifier", "Parent", "Scav", "ScavLunar1", "ClayBoss", "LunarGolem", "LunarWisp", "Brother", "BrotherHurt" };
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
            UmbraMenu.scrolled = false;
            UmbraMenu.navigationToggle = false;
            Navigation.menuIndex = 0;
            Navigation.buttonIndex = 0;
        }

        public static void CloseOpenMenus()
        {
            List<Menu> openMenus = GetMenusOpen();
            for (int i = 0; i < openMenus.Count; i++)
            {
                openMenus[i].SetEnabled(false);
            }
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
            UmbraMenu.settingsMenu = new Menus.Settings();

            UmbraMenu.statsModMenu = new Menus.StatsMod();
            UmbraMenu.viewStatsMenu = new Menus.ViewStats();
            UmbraMenu.characterListMenu = new Menus.CharacterList();
            UmbraMenu.buffListMenu = new Menus.BuffList();

            UmbraMenu.itemListMenu = new Menus.ItemList();
            UmbraMenu.equipmentListMenu = new Menus.EquipmentList();
            UmbraMenu.chestItemListMenu = new Menus.ChestItemList();

            UmbraMenu.spawnListMenu = new Menus.SpawnList();

            UmbraMenu.keybindListMenu = new Menus.KeybindList();

            UmbraMenu.menus = new List<Menu>()
            {
                UmbraMenu.mainMenu, //0
                UmbraMenu.playerMenu, //1
                UmbraMenu.movementMenu, //2
                UmbraMenu.itemsMenu, //3
                UmbraMenu.spawnMenu, //4
                UmbraMenu.teleporterMenu, //5
                UmbraMenu.renderMenu, //6
                UmbraMenu.settingsMenu, //7
                UmbraMenu.statsModMenu, //8
                UmbraMenu.viewStatsMenu, //9
                UmbraMenu.characterListMenu, //10
                UmbraMenu.buffListMenu, //11
                UmbraMenu.itemListMenu, //12
                UmbraMenu.equipmentListMenu, //13
                UmbraMenu.chestItemListMenu, //14
                UmbraMenu.spawnListMenu, //15
                UmbraMenu.keybindListMenu //16
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
                UmbraMenu.settingsMenu.SetRect(new Rect(374, 10, 20, 20)); // Start Position

                UmbraMenu.statsModMenu.SetRect(new Rect(374, 10, 20, 20)); // Start Position
                UmbraMenu.viewStatsMenu.SetRect(new Rect(374, 10, 20, 20)); // Start Position
                UmbraMenu.characterListMenu.SetRect(new Rect(374, 10, 20, 20)); // Start Position
                UmbraMenu.buffListMenu.SetRect(new Rect(374, 10, 20, 20)); // Start Position
                UmbraMenu.itemListMenu.SetRect(new Rect(374, 10, 20, 20)); // Start Position
                UmbraMenu.equipmentListMenu.SetRect(new Rect(374, 10, 20, 20)); // Start Position
                UmbraMenu.chestItemListMenu.SetRect(new Rect(374, 10, 20, 20)); // Start Position
                UmbraMenu.spawnListMenu.SetRect(new Rect(374, 10, 20, 20)); // Start Position
                UmbraMenu.keybindListMenu.SetRect(new Rect(374, 10, 20, 20));
            }
        }
        #endregion

        #region Keybind Utility
        public static Button GetEnabledKeybindButton()
        {
            Menu keybindMenu = UmbraMenu.menus[16];
            for (int i = 0; i < keybindMenu.GetNumberOfButtons(); i++)
            {
                Button button = keybindMenu.GetButtons()[i];
                if (button.IsEnabled())
                {
                    return button;
                }
            }
            throw new NullReferenceException($"No buttons are enabled in the keybind menu");
        }

        public static bool KeyCodeInUse(KeyCode keyCode)
        {
            for (int i = 0; i < UmbraMenu.keybindDict.Count; i++)
            {
                Keybind keybind = UmbraMenu.keybindDict[UmbraMenu.keyBindNames[i]];
                if (keybind.KeyCode == keyCode)
                {
                    return true;
                }
            }
            return false;
        }

        public static Keybind FindKeybindByKeyCode(KeyCode keyCode)
        {
            for (int i = 0; i < UmbraMenu.keybindDict.Count; i++)
            {
                Keybind keybind = UmbraMenu.keybindDict[UmbraMenu.keyBindNames[i]];
                if (keybind.KeyCode == keyCode)
                {
                    return keybind;
                }
            }
            throw new NullReferenceException($"Keybind using keycode '{keyCode}' was not found.");
        }
        #endregion

        public static List<Menu> GetMenusOpen()
        {
            List<Menu> openMenus = new List<Menu>();
            for (int i = 1; i < UmbraMenu.menus.Count; i++)
            {
                if (UmbraMenu.menus[i].IsEnabled() && UmbraMenu.menus[i].GetId() != 9)
                {
                    openMenus.Add(UmbraMenu.menus[i]);
                }
            }
            return openMenus;
        }

        #region Settings Functions
        public static void SaveSettings()
        {
            using (StreamWriter outputFile = new StreamWriter(UmbraMenu.SETTINGSPATH, false))
            {
                outputFile.WriteLine(@"###########################################################################################################################################################################################################################################");
                outputFile.WriteLine(@"#          _____                    _____                    _____                    _____                    _____                            _____                    _____                    _____                    _____          #");
                outputFile.WriteLine(@"#         /\    \                  /\    \                  /\    \                  /\    \                  /\    \                          /\    \                  /\    \                  /\    \                  /\    \         #");
                outputFile.WriteLine(@"#        /::\____\                /::\____\                /::\    \                /::\    \                /::\    \                        /::\____\                /::\    \                /::\____\                /::\____\        #");
                outputFile.WriteLine(@"#       /:::/    /               /::::|   |               /::::\    \              /::::\    \              /::::\    \                      /::::|   |               /::::\    \              /::::|   |               /:::/    /        #");
                outputFile.WriteLine(@"#      /:::/    /               /:::::|   |              /::::::\    \            /::::::\    \            /::::::\    \                    /:::::|   |              /::::::\    \            /:::::|   |              /:::/    /         #");
                outputFile.WriteLine(@"#     /:::/    /               /::::::|   |             /:::/\:::\    \          /:::/\:::\    \          /:::/\:::\    \                  /::::::|   |             /:::/\:::\    \          /::::::|   |             /:::/    /          #");
                outputFile.WriteLine(@"#    /:::/    /               /:::/|::|   |            /:::/__\:::\    \        /:::/__\:::\    \        /:::/__\:::\    \                /:::/|::|   |            /:::/__\:::\    \        /:::/|::|   |            /:::/    /           #");
                outputFile.WriteLine(@"#   /:::/    /               /:::/ |::|   |           /::::\   \:::\    \      /::::\   \:::\    \      /::::\   \:::\    \              /:::/ |::|   |           /::::\   \:::\    \      /:::/ |::|   |           /:::/    /            #");
                outputFile.WriteLine(@"#  /:::/    /      _____    /:::/  |::|___|______    /::::::\   \:::\    \    /::::::\   \:::\    \    /::::::\   \:::\    \            /:::/  |::|___|______    /::::::\   \:::\    \    /:::/  |::|   | _____    /:::/    /      _____  #");
                outputFile.WriteLine(@"# /:::/____/      /\    \  /:::/   |::::::::\    \  /:::/\:::\   \:::\ ___\  /:::/\:::\   \:::\____\  /:::/\:::\   \:::\    \          /:::/   |::::::::\    \  /:::/\:::\   \:::\    \  /:::/   |::|   |/\    \  /:::/____/      /\    \ #");
                outputFile.WriteLine(@"#|:::|    /      /::\____\/:::/    |:::::::::\____\/:::/__\:::\   \:::|    |/:::/  \:::\   \:::|    |/:::/  \:::\   \:::\____\        /:::/    |:::::::::\____\/:::/__\:::\   \:::\____\/:: /    |::|   /::\____\|:::|    /      /::\____\#");
                outputFile.WriteLine(@"#|:::|____\     /:::/    /\::/    / ~~~~~/:::/    /\:::\   \:::\  /:::|____|\::/   |::::\  /:::|____|\::/    \:::\  /:::/    /        \::/    / ~~~~~/:::/    /\:::\   \:::\   \::/    /\::/    /|::|  /:::/    /|:::|____\     /:::/    /#");
                outputFile.WriteLine(@"# \:::\    \   /:::/    /  \/____/      /:::/    /  \:::\   \:::\/:::/    /  \/____|:::::\/:::/    /  \/____/ \:::\/:::/    /          \/____/      /:::/    /  \:::\   \:::\   \/____/  \/____/ |::| /:::/    /  \:::\    \   /:::/    / #");
                outputFile.WriteLine(@"#  \:::\    \ /:::/    /               /:::/    /    \:::\   \::::::/    /         |:::::::::/    /            \::::::/    /                       /:::/    /    \:::\   \:::\    \              |::|/:::/    /    \:::\    \ /:::/    /  #");
                outputFile.WriteLine(@"#   \:::\    /:::/    /               /:::/    /      \:::\   \::::/    /          |::|\::::/    /              \::::/    /                       /:::/    /      \:::\   \:::\____\             |::::::/    /      \:::\    /:::/    /   #");
                outputFile.WriteLine(@"#    \:::\__/:::/    /               /:::/    /        \:::\  /:::/    /           |::| \::/____/               /:::/    /                       /:::/    /        \:::\   \::/    /             |:::::/    /        \:::\__/:::/    /    #");
                outputFile.WriteLine(@"#     \::::::::/    /               /:::/    /          \:::\/:::/    /            |::|  ~|                    /:::/    /                       /:::/    /          \:::\   \/____/              |::::/    /          \::::::::/    /     #");
                outputFile.WriteLine(@"#      \::::::/    /               /:::/    /            \::::::/    /             |::|   |                   /:::/    /                       /:::/    /            \:::\    \                  /:::/    /            \::::::/    /      #");
                outputFile.WriteLine(@"#       \::::/    /               /:::/    /              \::::/    /              \::|   |                  /:::/    /                       /:::/    /              \:::\____\                /:::/    /              \::::/    /       #");
                outputFile.WriteLine(@"#        \::/____/                \::/    /                \::/____/                \:|   |                  \::/    /                        \::/    /                \::/    /                \::/    /                \::/____/        #");
                outputFile.WriteLine(@"#         ~~                       \/____/                  ~~                       \|___|                   \/____/                          \/____/                  \/____/                  \/____/                  ~~              #");
                outputFile.WriteLine(@"###########################################################################################################################################################################################################################################");
                outputFile.WriteLine(@"# This is the settings file for the Risk Of Rain 2 Umbra Mod Menu.");
                outputFile.WriteLine(@"# Created by https://www.github.com/Acher0ns");
                outputFile.WriteLine(@"# If you need any help, add me on discord! Neonix#1337");
                outputFile.WriteLine(@"###########################################################################################################################################################################################################################################");
                outputFile.WriteLine($"Width: {UmbraMenu.Width}: # Menu Width Size (Any Number)");
                outputFile.WriteLine($"Allow Navigation: {UmbraMenu.AllowNavigation}: # Enable or Disable Keyboard Navigation Feature (true/false)");
                outputFile.WriteLine($"God Version: {UmbraMenu.GodVersion}: # Godmode Version (0-4)");
                outputFile.WriteLine(@"###########################################################################################################################################################################################################################################");
                outputFile.WriteLine(@"# Below are the keybind settings. Their value must be set to a valid Unity KeyCode");
                outputFile.WriteLine($"# Unity KeyCodes can be found here under the 'Properties' section: https://docs.unity3d.com/ScriptReference/KeyCode.html");
                for (int i = 0; i < UmbraMenu.keybindDict.Count; i++)
                {
                    outputFile.WriteLine($"{UmbraMenu.keyBindNames[i]}: {UmbraMenu.keybindDict[UmbraMenu.keyBindNames[i]].KeyCode}");
                }
            }
        }

        public static List<string> ReadSettings()
        {
            if (!File.Exists(UmbraMenu.SETTINGSPATH))
            {
                CreateDefaultSettingsFile();
            }
            List<string> result = new List<string>();
            var settings = File.ReadAllLines(UmbraMenu.SETTINGSPATH);
            for (int i = 0; i < settings.Length; i++)
            {
                if (settings[i].StartsWith("#"))
                {
                    continue;
                }
                result.Add(settings[i].Split(new string[] { ": " }, StringSplitOptions.None)[1]);
            }
            return result;
        }

        public static void CreateDefaultSettingsFile()
        {
            Directory.CreateDirectory(System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "UmbraMenu"));
            using (StreamWriter outputFile = new StreamWriter(UmbraMenu.SETTINGSPATH, false))
            {
                outputFile.WriteLine(@"###########################################################################################################################################################################################################################################");
                outputFile.WriteLine(@"#          _____                    _____                    _____                    _____                    _____                            _____                    _____                    _____                    _____          #");
                outputFile.WriteLine(@"#         /\    \                  /\    \                  /\    \                  /\    \                  /\    \                          /\    \                  /\    \                  /\    \                  /\    \         #");
                outputFile.WriteLine(@"#        /::\____\                /::\____\                /::\    \                /::\    \                /::\    \                        /::\____\                /::\    \                /::\____\                /::\____\        #");
                outputFile.WriteLine(@"#       /:::/    /               /::::|   |               /::::\    \              /::::\    \              /::::\    \                      /::::|   |               /::::\    \              /::::|   |               /:::/    /        #");
                outputFile.WriteLine(@"#      /:::/    /               /:::::|   |              /::::::\    \            /::::::\    \            /::::::\    \                    /:::::|   |              /::::::\    \            /:::::|   |              /:::/    /         #");
                outputFile.WriteLine(@"#     /:::/    /               /::::::|   |             /:::/\:::\    \          /:::/\:::\    \          /:::/\:::\    \                  /::::::|   |             /:::/\:::\    \          /::::::|   |             /:::/    /          #");
                outputFile.WriteLine(@"#    /:::/    /               /:::/|::|   |            /:::/__\:::\    \        /:::/__\:::\    \        /:::/__\:::\    \                /:::/|::|   |            /:::/__\:::\    \        /:::/|::|   |            /:::/    /           #");
                outputFile.WriteLine(@"#   /:::/    /               /:::/ |::|   |           /::::\   \:::\    \      /::::\   \:::\    \      /::::\   \:::\    \              /:::/ |::|   |           /::::\   \:::\    \      /:::/ |::|   |           /:::/    /            #");
                outputFile.WriteLine(@"#  /:::/    /      _____    /:::/  |::|___|______    /::::::\   \:::\    \    /::::::\   \:::\    \    /::::::\   \:::\    \            /:::/  |::|___|______    /::::::\   \:::\    \    /:::/  |::|   | _____    /:::/    /      _____  #");
                outputFile.WriteLine(@"# /:::/____/      /\    \  /:::/   |::::::::\    \  /:::/\:::\   \:::\ ___\  /:::/\:::\   \:::\____\  /:::/\:::\   \:::\    \          /:::/   |::::::::\    \  /:::/\:::\   \:::\    \  /:::/   |::|   |/\    \  /:::/____/      /\    \ #");
                outputFile.WriteLine(@"#|:::|    /      /::\____\/:::/    |:::::::::\____\/:::/__\:::\   \:::|    |/:::/  \:::\   \:::|    |/:::/  \:::\   \:::\____\        /:::/    |:::::::::\____\/:::/__\:::\   \:::\____\/:: /    |::|   /::\____\|:::|    /      /::\____\#");
                outputFile.WriteLine(@"#|:::|____\     /:::/    /\::/    / ~~~~~/:::/    /\:::\   \:::\  /:::|____|\::/   |::::\  /:::|____|\::/    \:::\  /:::/    /        \::/    / ~~~~~/:::/    /\:::\   \:::\   \::/    /\::/    /|::|  /:::/    /|:::|____\     /:::/    /#");
                outputFile.WriteLine(@"# \:::\    \   /:::/    /  \/____/      /:::/    /  \:::\   \:::\/:::/    /  \/____|:::::\/:::/    /  \/____/ \:::\/:::/    /          \/____/      /:::/    /  \:::\   \:::\   \/____/  \/____/ |::| /:::/    /  \:::\    \   /:::/    / #");
                outputFile.WriteLine(@"#  \:::\    \ /:::/    /               /:::/    /    \:::\   \::::::/    /         |:::::::::/    /            \::::::/    /                       /:::/    /    \:::\   \:::\    \              |::|/:::/    /    \:::\    \ /:::/    /  #");
                outputFile.WriteLine(@"#   \:::\    /:::/    /               /:::/    /      \:::\   \::::/    /          |::|\::::/    /              \::::/    /                       /:::/    /      \:::\   \:::\____\             |::::::/    /      \:::\    /:::/    /   #");
                outputFile.WriteLine(@"#    \:::\__/:::/    /               /:::/    /        \:::\  /:::/    /           |::| \::/____/               /:::/    /                       /:::/    /        \:::\   \::/    /             |:::::/    /        \:::\__/:::/    /    #");
                outputFile.WriteLine(@"#     \::::::::/    /               /:::/    /          \:::\/:::/    /            |::|  ~|                    /:::/    /                       /:::/    /          \:::\   \/____/              |::::/    /          \::::::::/    /     #");
                outputFile.WriteLine(@"#      \::::::/    /               /:::/    /            \::::::/    /             |::|   |                   /:::/    /                       /:::/    /            \:::\    \                  /:::/    /            \::::::/    /      #");
                outputFile.WriteLine(@"#       \::::/    /               /:::/    /              \::::/    /              \::|   |                  /:::/    /                       /:::/    /              \:::\____\                /:::/    /              \::::/    /       #");
                outputFile.WriteLine(@"#        \::/____/                \::/    /                \::/____/                \:|   |                  \::/    /                        \::/    /                \::/    /                \::/    /                \::/____/        #");
                outputFile.WriteLine(@"#         ~~                       \/____/                  ~~                       \|___|                   \/____/                          \/____/                  \/____/                  \/____/                  ~~              #");
                outputFile.WriteLine(@"###########################################################################################################################################################################################################################################");
                outputFile.WriteLine(@"# This is the settings file for the Risk Of Rain 2 Umbra Mod Menu.");
                outputFile.WriteLine(@"# Created by https://www.github.com/Acher0ns");
                outputFile.WriteLine(@"# If you need any help, add me on discord! Neonix#1337");
                outputFile.WriteLine(@"###########################################################################################################################################################################################################################################");
                outputFile.WriteLine($"Width: {350}: # Menu Width Size (Any Number)");
                outputFile.WriteLine($"Allow Navigation: {true}: # Enable or Disable the Keyboard Navigation feature (True/False)");
                outputFile.WriteLine($"God Version: {0}: # Godmode Version (0-4)");
                outputFile.WriteLine(@"###########################################################################################################################################################################################################################################");
                outputFile.WriteLine(@"# Below are the keybind settings. Their value must be set to a valid Unity KeyCode");
                outputFile.WriteLine($"# Unity KeyCodes can be found here under the 'Properties' section: https://docs.unity3d.com/ScriptReference/KeyCode.html");

                outputFile.WriteLine($"{UmbraMenu.keyBindNames[0]}: {KeyCode.Insert}"); // Open Menu

                outputFile.WriteLine($"{UmbraMenu.keyBindNames[1]}: {KeyCode.Z}"); // Open Player Menu
                outputFile.WriteLine($"{UmbraMenu.keyBindNames[2]}: {KeyCode.None}"); // Give Money
                outputFile.WriteLine($"{UmbraMenu.keyBindNames[3]}: {KeyCode.None}"); // Give Coin
                outputFile.WriteLine($"{UmbraMenu.keyBindNames[4]}: {KeyCode.None}"); // Give Exp
                outputFile.WriteLine($"{UmbraMenu.keyBindNames[5]}: {KeyCode.None}"); // Open Stats Mod Menu
                outputFile.WriteLine($"{UmbraMenu.keyBindNames[6]}: {KeyCode.None}"); // Open View Stats Menu
                outputFile.WriteLine($"{UmbraMenu.keyBindNames[7]}: {KeyCode.None}"); // Open Change Character List Menu
                outputFile.WriteLine($"{UmbraMenu.keyBindNames[8]}: {KeyCode.None}"); // Open BuffList
                outputFile.WriteLine($"{UmbraMenu.keyBindNames[9]}: {KeyCode.None}"); // Remove all buffs
                outputFile.WriteLine($"{UmbraMenu.keyBindNames[10]}: {KeyCode.None}"); // Aimbot
                outputFile.WriteLine($"{UmbraMenu.keyBindNames[11]}: {KeyCode.None}"); // God
                outputFile.WriteLine($"{UmbraMenu.keyBindNames[12]}: {KeyCode.None}"); // Infinite Skills

                outputFile.WriteLine($"{UmbraMenu.keyBindNames[13]}: {KeyCode.None}"); // Open Movement Menu
                outputFile.WriteLine($"{UmbraMenu.keyBindNames[14]}: {KeyCode.None}"); // Always Sprint
                outputFile.WriteLine($"{UmbraMenu.keyBindNames[15]}: {KeyCode.C}"); // Flight
                outputFile.WriteLine($"{UmbraMenu.keyBindNames[16]}: {KeyCode.None}"); // Jump Pack

                outputFile.WriteLine($"{UmbraMenu.keyBindNames[17]}: {KeyCode.I}"); // Open Items Menu
                outputFile.WriteLine($"{UmbraMenu.keyBindNames[18]}: {KeyCode.None}"); // Give All Items
                outputFile.WriteLine($"{UmbraMenu.keyBindNames[19]}: {KeyCode.None}"); // Roll Items
                outputFile.WriteLine($"{UmbraMenu.keyBindNames[20]}: {KeyCode.None}"); // Open Item List Menu
                outputFile.WriteLine($"{UmbraMenu.keyBindNames[21]}: {KeyCode.None}"); // Open Equipment List Menu
                outputFile.WriteLine($"{UmbraMenu.keyBindNames[22]}: {KeyCode.None}"); // Drop Items
                outputFile.WriteLine($"{UmbraMenu.keyBindNames[23]}: {KeyCode.None}"); // Drop Invetory Items
                outputFile.WriteLine($"{UmbraMenu.keyBindNames[24]}: {KeyCode.None}"); // Infinite Equipment
                outputFile.WriteLine($"{UmbraMenu.keyBindNames[25]}: {KeyCode.None}"); // Stack Inventory
                outputFile.WriteLine($"{UmbraMenu.keyBindNames[26]}: {KeyCode.None}"); // Clear Inventory
                outputFile.WriteLine($"{UmbraMenu.keyBindNames[27]}: {KeyCode.None}"); // Open Chest Item List Menu

                outputFile.WriteLine($"{UmbraMenu.keyBindNames[28]}: {KeyCode.None}"); // Open Spawn Menu
                outputFile.WriteLine($"{UmbraMenu.keyBindNames[29]}: {KeyCode.None}"); // Open Spawn List Menu
                outputFile.WriteLine($"{UmbraMenu.keyBindNames[30]}: {KeyCode.None}"); // Kill All Mobs
                outputFile.WriteLine($"{UmbraMenu.keyBindNames[31]}: {KeyCode.None}"); // Destroy Spawned Interactables

                outputFile.WriteLine($"{UmbraMenu.keyBindNames[32]}: {KeyCode.B}"); // Open Teleporter Menu
                outputFile.WriteLine($"{UmbraMenu.keyBindNames[33]}: {KeyCode.None}"); // Skip Stage
                outputFile.WriteLine($"{UmbraMenu.keyBindNames[34]}: {KeyCode.None}"); // Instant Teleporter
                outputFile.WriteLine($"{UmbraMenu.keyBindNames[35]}: {KeyCode.None}"); // Add Mountain Stack
                outputFile.WriteLine($"{UmbraMenu.keyBindNames[36]}: {KeyCode.None}"); // Spawn All Portals
                outputFile.WriteLine($"{UmbraMenu.keyBindNames[37]}: {KeyCode.None}"); // Spawn Blue Portal
                outputFile.WriteLine($"{UmbraMenu.keyBindNames[38]}: {KeyCode.None}"); // Spawn Celestial Portal
                outputFile.WriteLine($"{UmbraMenu.keyBindNames[39]}: {KeyCode.None}"); // Spawn Gold Portal

                outputFile.WriteLine($"{UmbraMenu.keyBindNames[40]}: {KeyCode.None}"); // Open Render Menu
                outputFile.WriteLine($"{UmbraMenu.keyBindNames[41]}: {KeyCode.None}"); // Active Mods
                outputFile.WriteLine($"{UmbraMenu.keyBindNames[42]}: {KeyCode.None}"); // Interactables
                outputFile.WriteLine($"{UmbraMenu.keyBindNames[43]}: {KeyCode.None}"); // Mob ESP
            }
        }
        #endregion

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