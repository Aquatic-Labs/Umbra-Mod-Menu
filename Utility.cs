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
        public static T FindButtonById<T>(int menuId, int buttonId) where T : Button
        {
            List<Button> menuButtons = UmbraMenu.menus[menuId].GetButtons();
            foreach (Button button in menuButtons)
            {
                if (button is T)
                {
                    if (button.GetId() == buttonId)
                    {
                        return (T)button; 
                    }
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

        /*public static HashSet<Tuple<int, int, bool>> SaveMenuState()
        {
            HashSet<Tuple<int, int, bool>> enabledButtons = new HashSet<Tuple<int, int, bool>>();
            foreach (Menu menu in UmbraMenu.menus)
            {
                if (menu != null)
                {
                    Tuple<int, int, bool> menuButtonsEnabled = new Tuple<int, int, bool>(-1, -1, false);
                    try
                    {
                        foreach (Button button in menu.GetButtons())
                        {

                            if (button is TogglableButton)
                            {
                                TogglableButton currentButton = (TogglableButton)button;

                                if (currentButton.IsEnabled())
                                {
                                    menuButtonsEnabled = new Tuple<int, int, bool>(currentButton.GetParentMenu().GetId(), currentButton.GetId(), menu.IsEnabled());
                                }
                                else if (menu.IsEnabled())
                                {
                                    menuButtonsEnabled = new Tuple<int, int, bool>(currentButton.GetParentMenu().GetId(), -1, menu.IsEnabled());
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
                        System.Console.WriteLine(e);
                        continue;
                    }
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
                    TogglableButton button = (TogglableButton)UmbraMenu.menus[menuId].GetButtons()[buttonPos - 1];
                    button.SetEnabled(true);
                }
            }
        }*/

        public static void StubbedFunction()
        {
            return;
        }

        #region Get Lists
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

            foreach (EquipmentIndex equipmentIndex in EquipmentCatalog.allEquipment)
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
            UmbraMenu.unreleasedEquipment = other;
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

            foreach (ItemIndex itemIndex in ItemCatalog.allItems)
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

            UmbraMenu.bossItems = boss;
            UmbraMenu.unreleasedItems = other;
            var result = items.Concat(boss).Concat(tier3).Concat(tier2).Concat(tier1).Concat(lunar).Concat(other).ToList();
            return result;
        }
           
        public static List<BuffDef> GetBuffs()
        {
            List<BuffDef> buffs = new List<BuffDef>();

            List<BuffDef> eliteBuff = new List<BuffDef>();
            List<BuffDef> nonEliteBuff = new List<BuffDef>();
            List<BuffDef> eliteDebuff = new List<BuffDef>();
            List<BuffDef> nonEliteDebuff = new List<BuffDef>();
            List<BuffDef> other = new List<BuffDef>();

            foreach (BuffDef buffDef in typeof(BuffCatalog).GetField<BuffDef[]>("buffDefs"))
            {
                if (!buffDef.isDebuff && buffDef.isElite)
                {
                    eliteBuff.Add(buffDef);
                }
                else if (!buffDef.isDebuff && !buffDef.isElite)
                {
                    nonEliteBuff.Add(buffDef);
                }
                else if (buffDef.isDebuff && buffDef.isElite)
                {
                    eliteDebuff.Add(buffDef);
                }
                else if (buffDef.isDebuff && !buffDef.isElite)
                {
                    nonEliteDebuff.Add(buffDef);
                }
                else
                {
                    other.Add(buffDef);
                }
            }
            var result = buffs.Concat(eliteBuff).Concat(nonEliteBuff).Concat(eliteDebuff).Concat(nonEliteDebuff).Concat(other).ToList();
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
            UmbraMenu.scrolled = false;
            UmbraMenu.navigationToggle = false;
            Navigation.menuIndex = 0;
            Navigation.buttonIndex = 0;
        }

        public static void CloseOpenMenus()
        {
            for (int i = 0; i < UmbraMenu.menus.Count; i++)
            {
                if (UmbraMenu.menus[i].GetId() != 9 && UmbraMenu.menus[i].GetId() != 0 && UmbraMenu.menus[i].IsEnabled())
                {
                    UmbraMenu.menus[i].SetEnabled(false);
                }
            }
        }
        #endregion

        #region Keybind Utility
        public static Button GetEnabledKeybindButton()
        {
            ListMenu keybindMenu = UmbraMenu.keybindListMenu;
            for (int i = 0; i < keybindMenu.GetNumberOfButtons(); i++)
            {
                if (keybindMenu.GetButtons()[i] is TogglableButton button && button.IsEnabled())
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