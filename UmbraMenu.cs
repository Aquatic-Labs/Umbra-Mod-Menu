using System;
using System.Collections.Generic;
using UnityEngine;
using RoR2;
using UnityEngine.SceneManagement;
using System.Linq;
using System.Text.RegularExpressions;

namespace UmbraMenu
{
    public class UmbraMenu : MonoBehaviour
    {
        public const string
            NAME = "U M B R A",
            VERSION = "2.0.3";

        public static string SETTINGSPATH = System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), $"UmbraMenu/settings-{VERSION}.ini");

        #region Player Variables
        public static CharacterMaster LocalPlayer;
        public static CharacterBody   LocalPlayerBody;
        public static Inventory       LocalPlayerInv;
        public static HealthComponent LocalHealth;
        public static SkillLocator    LocalSkills;
        public static NetworkUser     LocalNetworkUser;
        public static CharacterMotor  LocalMotor;
        #endregion

        #region Init Lists
        public static Dictionary<String, UnlockableDef> unlockables = typeof(UnlockableCatalog).GetField<Dictionary<String, UnlockableDef>>("nameToDefTable");
        public static List<GameObject> bodyPrefabs = Utility.GetBodyPrefabs();
        public static List<EquipmentIndex> equipment = Utility.GetEquipment();
        public static List<ItemIndex> items = Utility.GetItems();
        public static List<BuffDef> buffs = Utility.GetBuffs();
        public static List<SpawnCard> spawnCards = Utility.GetSpawnCards();
        public static List<ItemIndex> bossItems;
        public static List<ItemIndex> unreleasedItems;
        public static List<EquipmentIndex> unreleasedEquipment;
        #endregion

        #region Misc Variabled used in some features
        public static int previousMenuOpen;
        public static bool characterCollected, navigationToggle, devDoOnce = true, devMode, forceFullModMenu, lowResolutionMonitor, chatOpen, msgSent = true, scrolled, listenForKeybind;
        public static Scene currentScene;
        #endregion

        #region Settings Variables
        public static List<string> keyBindNames = new List<string>()
        {
            "MAIN MENU",

            "PLAYER MENU",
            "GIVE MONEY",
            "GIVE COINS",
            "GIVE XP",
            "STATS MENU",
            "VIEW STATS MENU",
            "CHANGE CHARACTER MENU",
            "BUFF MENU",
            "REMOVE BUFFS",
            "AIMBOT",
            "GODMODE",
            "INFINITE SKILLS",

            "MOVEMENT MENU",
            "ALWAYS SPRINT",
            "FLIGHT",
            "JUMP PACK",

            "ITEMS MENU",
            "GIVE ALL",
            "ROLL ITEMS",
            "ITEMS LIST MENU",
            "EQUIPMENT LIST MENU",
            "DROP ITEMS",
            "DROP INVENTORY ITEMS",
            "INFINITE EQUIPMENT",
            "STACK INVENTORY",
            "CLEAR INVENTORY",
            "CHANGE CHEST ITEM MENU",

            "SPAWN MENU",
            "SPAWN LIST MENU",
            "KILL ALL",
            "DESTROY INTERACTABLES",

            "TELEPORTER MENU",
            "SKIP STAGE",
            "INSTANT TELE CHARGE",
            "ADD MOUNTAIN STACK",
            "SPAWN ALL PORTALS",
            "SPAWN BLUE PORTAL",
            "SPAWN CELE PORTAL",
            "SPAWN GOLD PORTAL",

            "RENDER MENU",
            "RENDER ACTIVE MODS",
            "RENDER INTERACTABLES",
            "RENDER MOB ESP"
        };

        public static List<string> Settings = Utility.ReadSettings();

        public static float Width = float.Parse(Settings[0]);
        public static bool AllowNavigation = bool.Parse(Settings[1]);
        public static int GodVersion = int.Parse(Settings[2]);
        public static Dictionary<string, Keybind> keybindDict = BuildKeybinds();
        #endregion

        #region Menus
        public static Menus.LobbyMenu lobbyMenu = new Menus.LobbyMenu();

        public static Menus.MainMenu mainMenu;

        public static Menus.Player playerMenu;
        public static Menus.Movement movementMenu;
        public static Menus.Items itemsMenu;
        public static Menus.Spawn spawnMenu;
        public static Menus.Teleporter teleporterMenu;
        public static Menus.Render renderMenu;
        public static Menus.Settings settingsMenu;

        public static Menus.StatsMod statsModMenu;
        public static Menus.ViewStats viewStatsMenu;
        public static Menus.CharacterList characterListMenu;
        public static Menus.BuffList buffListMenu;

        public static Menus.ItemList itemListMenu;
        public static Menus.EquipmentList equipmentListMenu;
        public static Menus.ChestItemList chestItemListMenu;

        public static Menus.SpawnList spawnListMenu;

        public static Menus.KeybindList keybindListMenu;

        public static List<Menu> menus = new List<Menu>()
        {
            mainMenu, //0
            playerMenu, //1
            movementMenu, //2
            itemsMenu, //3
            spawnMenu, //4
            teleporterMenu, //5
            renderMenu, //6
            settingsMenu, //7
            statsModMenu, //8
            viewStatsMenu, //9
            characterListMenu, //10
            buffListMenu, //11
            itemListMenu, //12
            equipmentListMenu, //13
            chestItemListMenu, //14
            spawnListMenu, //15
        };
        #endregion

        #region Main Unity Functions
        private void OnGUI()
        {
            try
            {
                #region Watermark
                if (Loader.updateAvailable)
                {
                    GUI.Label(new Rect(Screen.width - 250, 1f, 100, 50f), $"Umbra Menu (v{VERSION}) <color=grey>-</color> <color=yellow>Lastest (v{Loader.latestVersion})</color>", Styles.WatermarkStyle);
                }
                else if (Loader.upToDate)
                {
                    GUI.Label(new Rect(Screen.width - 140, 1f, 100, 50f), $"Umbra Menu (v{VERSION})", Styles.WatermarkStyle);
                }
                else if (Loader.devBuild)
                {
                    GUI.Label(new Rect(Screen.width - 210, 1f, 100, 50f), $"Umbra Menu (v{VERSION}) <color=grey>-</color> <color=yellow>Dev Build</color>", Styles.WatermarkStyle);
                }
                #endregion

                #region Draw Menus
                if (characterCollected)
                {
                    mainMenu.Draw(); //0
                    playerMenu.Draw(); //1
                    movementMenu.Draw(); //2
                    itemsMenu.Draw(); //3
                    spawnMenu.Draw(); //4
                    teleporterMenu.Draw(); //5
                    renderMenu.Draw(); //6
                    settingsMenu.Draw(); //7

                    statsModMenu.Draw(); //8
                    viewStatsMenu.Draw(); //9
                    characterListMenu.Draw(); //10
                    buffListMenu.Draw(); //11

                    itemListMenu.Draw(); //12
                    equipmentListMenu.Draw(); //13
                    chestItemListMenu.Draw(); //14

                    spawnListMenu.Draw(); //15

                    keybindListMenu.Draw(); //16
                }
                else
                {
                    lobbyMenu.Draw();
                }
                #endregion

                ESPRoutine();
            }
            catch //(Exception e)
            {
                //Utility.WriteToLog("GUI ERROR - " + e.ToString());
            }
        }

        public void Start()
        {
            try
            {
                SceneManager.activeSceneChanged += OnSceneLoaded;

                #region Resolution Check
                if (Screen.height < 1080)
                {
                    lowResolutionMonitor = true;

                    mainMenu.SetRect(new Rect(10, 10, 20, 20)); // Start Position
                    playerMenu.SetRect(new Rect(374, 10, 20, 20)); // Start Position
                    movementMenu.SetRect(new Rect(374, 10, 20, 20)); // Start Position
                    itemsMenu.SetRect(new Rect(374, 10, 20, 20)); // Start Position
                    spawnMenu.SetRect(new Rect(374, 10, 20, 20)); // Start Position
                    teleporterMenu.SetRect(new Rect(374, 10, 20, 20)); // Start Position
                    renderMenu.SetRect(new Rect(374, 10, 20, 20)); // Start Position
                    settingsMenu.SetRect(new Rect(374, 10, 20, 20)); // Start Position

                    statsModMenu.SetRect(new Rect(374, 10, 20, 20)); // Start Position
                    viewStatsMenu.SetRect(new Rect(374, 10, 20, 20)); // Start Position
                    characterListMenu.SetRect(new Rect(374, 10, 20, 20)); // Start Position
                    buffListMenu.SetRect(new Rect(374, 10, 20, 20)); // Start Position
                    itemListMenu.SetRect(new Rect(374, 10, 20, 20)); // Start Position
                    equipmentListMenu.SetRect(new Rect(374, 10, 20, 20)); // Start Position
                    chestItemListMenu.SetRect(new Rect(374, 10, 20, 20)); // Start Position
                    spawnListMenu.SetRect(new Rect(374, 10, 20, 20)); // Start Position

                    Menus.Render.renderMods = false;
                }
                #endregion
            }
            catch //(Exception e)
            {
                //Utility.WriteToLog("START ERROR - " + e.ToString());
            }
        }

        public void Update()
        {
            try
            {
                LowResolutionRoutine();
                DevBuildRoutine();

                CheckInputs();
                CharacterRoutine();

                SkillsRoutine();
                AimBotRoutine();
                GodRoutine();
                EquipCooldownRoutine();
                FlightRoutine();
                SprintRoutine();
                JumpPackRoutine();

                UpdateNavIndexRoutine();
                Menus.ViewStats.UpdateViewStats();
                SetKeybindRoutine();
                //UpdateKeybindButtonRoutine();
                ForceFullMenuRoutine();
            }
            catch //(Exception e)
            {
                //Utility.WriteToLog("UPDATE ERROR" + e.ToString());
            }
        }

        public void FixedUpdate()
        {
            try
            {
                currentScene = SceneManager.GetActiveScene();
                if (InGameCheck())
                {
                    if (Menus.Render.renderMobs)
                    {
                        Menus.Render.hurtBoxes = Utility.GetHurtBoxes();
                    }
                    if (chestItemListMenu.IsEnabled())
                    {
                        chestItemListMenu.IsClosestChestEquip = Menus.ChestItemList.CheckClosestChestEquip();
                    }
                }
            }
            catch //(Exception e)
            {
                //Utility.WriteToLog("FIXED UPDATE ERROR - " + e.ToString());
            }
        }
        #endregion

        #region Misc Functions
        public void OnSceneLoaded(Scene s1, Scene s2)
        {
            if (s2 != null)
            {
                bool inGame = s2.name != "title" && s2.name != "lobby" && s2.name != "" && s2.name != " ";
                if (!inGame)
                {
                    if (Screen.height < 1080)
                    {
                        lowResolutionMonitor = true;
                        Menus.Render.renderMods = false;
                    }
                    Utility.ResetMenu();
                }
                else
                {
                    if (Menus.Render.renderInteractables)
                    {
                        Menus.Render.DumpInteractables(null);
                    }
                }
            }
        }

        private void LowResolutionMonitor()
        {
            var menusOpen = Utility.GetMenusOpen();

            int closingIndex = 0;
            if (menusOpen.Count > 1)
            {
                if (menusOpen[1].GetId() > previousMenuOpen)
                {
                    closingIndex = 1;
                }
                menusOpen[closingIndex].SetEnabled(false);
            }
        }

        public static void GetCharacter()
        {
            try
            {
                if (InGameCheck())
                {
                    LocalNetworkUser = null;

                    foreach (NetworkUser readOnlyInstance in NetworkUser.readOnlyInstancesList)   
                    {
                        if (readOnlyInstance.isLocalPlayer)
                        {
                            LocalNetworkUser = readOnlyInstance;
                            LocalPlayer = LocalNetworkUser.master;
                            LocalPlayerInv = LocalPlayer.GetComponent<Inventory>(); //gets player inventory
                            LocalHealth = LocalPlayer.GetBody().GetComponent<HealthComponent>(); //gets players local health numbers
                            LocalSkills = LocalPlayer.GetBody().GetComponent<SkillLocator>(); //gets current for local character skills
                            LocalPlayerBody = LocalPlayer.GetBody().GetComponent<CharacterBody>(); //gets all stats for local character
                            LocalMotor = LocalPlayer.GetBody().GetComponent<CharacterMotor>();
                            bool flag = LocalHealth.alive || LocalPlayer.isActiveAndEnabled || LocalPlayerBody.isActiveAndEnabled;

						    if (flag)
						    {
                                if (mainMenu == null)
                                {
                                    mainMenu = new Menus.MainMenu();

                                    playerMenu = new Menus.Player();
                                    movementMenu = new Menus.Movement();
                                    itemsMenu = new Menus.Items();
                                    spawnMenu = new Menus.Spawn();
                                    teleporterMenu = new Menus.Teleporter();
                                    renderMenu = new Menus.Render();
                                    settingsMenu = new Menus.Settings();

                                    statsModMenu = new Menus.StatsMod();
                                    viewStatsMenu = new Menus.ViewStats();
                                    characterListMenu = new Menus.CharacterList();
                                    buffListMenu = new Menus.BuffList();

                                    itemListMenu = new Menus.ItemList();
                                    equipmentListMenu = new Menus.EquipmentList();
                                    chestItemListMenu = new Menus.ChestItemList();

                                    spawnListMenu = new Menus.SpawnList();

                                    keybindListMenu = new Menus.KeybindList();

                                    menus = new List<Menu>()
                                    {
                                        mainMenu, //0
                                        playerMenu, //1
                                        movementMenu, //2
                                        itemsMenu, //3
                                        spawnMenu, //4
                                        teleporterMenu, //5
                                        renderMenu, //6
                                        settingsMenu, //7
                                        statsModMenu, //8
                                        viewStatsMenu, //9
                                        characterListMenu, //10
                                        buffListMenu, //11
                                        itemListMenu, //12
                                        equipmentListMenu, //13
                                        chestItemListMenu, //14
                                        spawnListMenu, //15
                                    };
                                }

                                lobbyMenu = null;

                                characterCollected = true;
                            }
						    else
						    {
							    characterCollected = false;

                                if (lobbyMenu == null && !InGameCheck())
                                {
                                    lobbyMenu = new Menus.LobbyMenu();
                                }
                            }
                        }
                    }
                }
            }
            catch
            {
                characterCollected = false;
            }
        }

        public static bool InGameCheck()
        {
            if (currentScene != null)
            {
                bool inGame = currentScene.name != "title" && currentScene.name != "lobby" && currentScene.name != "" && currentScene.name != " ";
                return inGame;
            }
            return false;
        }
        #endregion

        #region Routines
        private void LowResolutionRoutine()
        {
            if (lowResolutionMonitor)
            {
                LowResolutionMonitor();
            }
        }

        private void CharacterRoutine()
        {
            GetCharacter();
        }

        private void DevBuildRoutine()
        {
            if (Loader.devBuild)
            {
                if (characterCollected)
                {
                    if (devDoOnce && devMode)
                    {
                        Menus.Player.GodToggle = true;
                        playerMenu.toggleGod.SetEnabled(true);

                        Menus.Movement.flightToggle = true;
                        movementMenu.toggleFlight.SetEnabled(true);

                        Menus.Movement.alwaysSprintToggle = true;
                        movementMenu.toggleAlwaysSprint.SetEnabled(true);

                        LocalPlayer.GiveMoney(10000);
                        devDoOnce = false;
                    }
                }
            }
        }

        private void ESPRoutine()
        {
            if (characterCollected)
            {
                if (Menus.Render.renderInteractables)
                {
                    Menus.Render.Interactables();
                    Menus.Render.renderInteractables = true;
                }
                else
                {
                    Menus.Render.renderInteractables = false;
                }

                if (Menus.Render.renderMobs)
                {
                    Menus.Render.Mobs();
                    Menus.Render.renderMobs = true;
                }
                else
                {
                    Menus.Render.renderMobs = false;
                }

                if (Menus.Render.renderMods)
                {
                    Menus.Render.ActiveMods();
                    Menus.Render.renderMods = true;
                }
                else
                {
                    Menus.Render.renderMods = false;
                }

                if (chestItemListMenu.IsEnabled())
                {
                    Menus.ChestItemList.RenderClosestChest();
                }
            }
        }

        private void EquipCooldownRoutine()
        {
            if (Menus.Items.noEquipmentCD)
            {
                Menus.Items.NoEquipmentCooldown();
            }
        }

        private void SkillsRoutine()
        {
            if (characterCollected)
            {
                if (Menus.Player.SkillToggle)
                {
                    LocalSkills.ApplyAmmoPack();
                }
            }
        }

        private void AimBotRoutine()
        {
            if (Menus.Player.AimBotToggle)
            {
                Menus.Player.AimBot();
            }

        }

        private void GodRoutine()
        {
            if (characterCollected)
            {
                if (Menus.Player.GodToggle)
                {
                    Menus.Player.EnableGodMode();
                }
            }
        }

        private void SprintRoutine()
        {
            if (Menus.Movement.alwaysSprintToggle)
            {
                Menus.Movement.AlwaysSprint();
            }
        }

        private void FlightRoutine()
        {
            if (Menus.Movement.flightToggle)
            {
                Menus.Movement.Flight();
            }
        }

        private void JumpPackRoutine()
        {
            if (Menus.Movement.jumpPackToggle)
            {
                Menus.Movement.JumpPack();
            }
        }

        private void UpdateKeybindButtonRoutine()
        {
            if (InGameCheck() && keybindListMenu.IsEnabled())
            {
                int buttonsEnabled = 0;
                for (int i = 1; i < keybindListMenu.GetButtons().Count + 1; i++)
                {
                    TogglableButton button = (TogglableButton)keybindListMenu.GetButtons()[i];
                    if (button.IsEnabled())
                    {
                        buttonsEnabled++;
                    }
                    if (buttonsEnabled > 1)
                    {
                        for (int j = 1; i < keybindListMenu.GetButtons().Count + 1; j++)
                        {
                            TogglableButton btn = (TogglableButton)keybindListMenu.GetButtons()[j];
                            btn.SetEnabled(false);
                        }
                        listenForKeybind = false;
                    }
                }
            }
        }

        private void UpdateNavIndexRoutine()
        {
            if (navigationToggle)
            {
                Navigation.UpdateIndexValues();
            }
        }

        private void SetKeybindRoutine()
        {
            if (listenForKeybind)
            {
                Dictionary<string, string> numKeys = new Dictionary<string, string>()
                {
                    { "0", "Alpha0" },
                    { "1", "Alpha1" },
                    { "2", "Alpha2" },
                    { "3", "Alpha3" },
                    { "4", "Alpha4" },
                    { "5", "Alpha5" },
                    { "6", "Alpha6" },
                    { "7", "Alpha7" },
                    { "8", "Alpha8" },
                    { "9", "Alpha9" },
                };
                Regex rgAlpha = new Regex(@"^[A-Z]$");
                Regex rgNum = new Regex(@"^[0-9]$");
                TogglableButton button = (TogglableButton)Utility.GetEnabledKeybindButton();
                string newKeybind = Input.inputString;
                if (newKeybind.Length > 1)
                {
                    newKeybind = newKeybind.First().ToString().ToUpper() + newKeybind.Substring(1);
                }
                else
                {
                    newKeybind = newKeybind.ToUpper();
                }

                bool validKeybind = newKeybind != "V" && newKeybind != "W" && newKeybind != "A" && newKeybind != "S" && newKeybind != "D" && rgAlpha.IsMatch(newKeybind) && newKeybind != "" && newKeybind != " " && newKeybind != null;
                if (validKeybind)
                {
                    KeyCode keyCode = (KeyCode)Enum.Parse(typeof(KeyCode), newKeybind);
                    if (!Utility.KeyCodeInUse(keyCode))
                    {
                        string keybindName = button.GetOffText().Split(new string[] { " :" }, StringSplitOptions.None)[0];
                        keybindDict[keybindName].KeyCode = keyCode;
                        listenForKeybind = false;
                        button.SetEnabled(false);
                        Utility.SaveSettings();
                    }
                    else
                    {
                        Keybind keybind = Utility.FindKeybindByKeyCode(keyCode);
                        keybind.KeyCode = KeyCode.None;

                        string keybindName = button.GetOffText().Split(new string[] { " :" }, StringSplitOptions.None)[0];
                        keybindDict[keybindName].KeyCode = keyCode;
                        listenForKeybind = false;
                        button.SetEnabled(false);
                        Utility.SaveSettings();
                    }
                }
                else if (!validKeybind && rgNum.IsMatch(newKeybind))
                {
                    newKeybind = numKeys[newKeybind];
                    if (newKeybind != "Alpha0")
                    {
                        string keybindName = button.GetOffText().Split(new string[] { " :" }, StringSplitOptions.None)[0];
                        keybindDict[keybindName].KeyCode = (KeyCode)Enum.Parse(typeof(KeyCode), newKeybind);
                        listenForKeybind = false;
                        button.SetEnabled(false);
                        Utility.SaveSettings();
                    }
                    else
                    {
                        string keybindName = button.GetOffText().Split(new string[] { " :" }, StringSplitOptions.None)[0];
                        keybindDict[keybindName].KeyCode = KeyCode.None;
                        listenForKeybind = false;
                        button.SetEnabled(false);
                        Utility.SaveSettings();
                    }
                }
            }
        }

        private void ForceFullMenuRoutine()
        {
            if (forceFullModMenu == true)
            {
                characterCollected = true;
            }
        }
        #endregion

        #region Inputs
        private void CheckInputs()
        {
            if (InGameCheck())
            {
                if (chatOpen && Input.GetKeyDown(KeyCode.Escape))
                {
                    chatOpen = false;
                    msgSent = true;
                }
                if (Input.GetKeyDown(KeyCode.Return))
                {
                    if (msgSent)
                    {
                        chatOpen = true;
                        msgSent = false;
                    }
                    else
                    {
                        chatOpen = false;
                        msgSent = true;
                    }
                }
            }

            if (characterCollected)
            {
                if (mainMenu.IsEnabled())
                {
                    Cursor.visible = true;
                    if (characterCollected)
                    {
                        if (AllowNavigation)
                        {
                            if (Input.GetKeyDown(KeyCode.DownArrow))
                            {
                                if (!navigationToggle)
                                {
                                    Utility.CloseOpenMenus();
                                }

                                navigationToggle = true;
                                Navigation.buttonIndex++;
                            }
                            if (Input.GetKeyDown(KeyCode.UpArrow))
                            {
                                if (!navigationToggle)
                                {
                                    Utility.CloseOpenMenus();
                                }

                                navigationToggle = true;
                                Navigation.buttonIndex--;
                            }
                        }
                    }
                    if (navigationToggle && AllowNavigation)
                    {
                        if (Input.GetKeyDown(KeyCode.V))
                        {
                            Navigation.PressBtn(Navigation.menuIndex, Navigation.buttonIndex);
                        }
                        if (Input.GetKeyDown(KeyCode.RightArrow))
                        {
                            bool playerPlusMinusBtn = Navigation.menuIndex == 1 && Enumerable.Range(1, 3).Contains(Navigation.buttonIndex);
                            bool statsPlusMinusBtn = Navigation.menuIndex == 8 && Enumerable.Range(1, 6).Contains(Navigation.buttonIndex);
                            bool itemPlusMinusBtn = Navigation.menuIndex == 3 && Enumerable.Range(1, 2).Contains(Navigation.buttonIndex);
                            bool spawnPlusMinusBtn = Navigation.menuIndex == 4 && Enumerable.Range(1, 3).Contains(Navigation.buttonIndex);
                            bool settingsPlusMinusBtn = Navigation.menuIndex == 7 && Navigation.buttonIndex == 1;
                            if (playerPlusMinusBtn || itemPlusMinusBtn || statsPlusMinusBtn || spawnPlusMinusBtn || settingsPlusMinusBtn)
                            {
                                Navigation.IncreaseValue(Navigation.menuIndex, Navigation.buttonIndex);
                            }
                            else
                            {
                                Navigation.PressBtn(Navigation.menuIndex, Navigation.buttonIndex);
                            }
                        }
                        if (Input.GetKeyDown(KeyCode.LeftArrow))
                        {
                            bool playerPlusMinusBtn = Navigation.menuIndex == 1 && Enumerable.Range(1, 3).Contains(Navigation.buttonIndex);
                            bool statsPlusMinusBtn = Navigation.menuIndex == 8 && Enumerable.Range(1, 6).Contains(Navigation.buttonIndex);
                            bool itemPlusMinusBtn = Navigation.menuIndex == 3 && Enumerable.Range(1, 2).Contains(Navigation.buttonIndex);
                            bool spawnPlusMinusBtn = Navigation.menuIndex == 4 && Enumerable.Range(1, 3).Contains(Navigation.buttonIndex);
                            bool settingsPlusMinusBtn = Navigation.menuIndex == 7 && Navigation.buttonIndex == 1;
                            if (playerPlusMinusBtn || itemPlusMinusBtn || statsPlusMinusBtn || spawnPlusMinusBtn || settingsPlusMinusBtn)
                            {
                                Navigation.DecreaseValue(Navigation.menuIndex, Navigation.buttonIndex);
                            }
                            else
                            {
                                Navigation.GoBackAMenu();
                            }
                        }
                        if (Input.GetKeyDown(KeyCode.Backspace))
                        {
                            Navigation.GoBackAMenu();
                        }

                        if (buffListMenu.IsEnabled() || characterListMenu.IsEnabled() || chestItemListMenu.IsEnabled() || equipmentListMenu.IsEnabled() || itemListMenu.IsEnabled() || spawnListMenu.IsEnabled() || keybindListMenu.IsEnabled())
                        {
                            if (!scrolled)
                            {
                                if (Input.GetAxis("Mouse ScrollWheel") != 0f) // Scrolled
                                {
                                    scrolled = true;
                                }
                            }
                            else
                            {
                                if (Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.UpArrow))
                                {
                                    scrolled = false;
                                }
                            }
                        }
                    }
                }
                else if (!mainMenu.IsEnabled())
                {
                    navigationToggle = false;
                    Navigation.buttonIndex = 0;
                    Navigation.menuIndex = 0;
                    Cursor.visible = false;
                }
            }

            Keybinds();
        }

        private void Keybinds()
        {
            #region Dev Mode Keybinds
            if (Input.GetKeyDown(KeyCode.F2))
            {
                devMode = !devMode;
            }

            if (Input.GetKeyDown(KeyCode.F7))
            {
                forceFullModMenu = !forceFullModMenu;
            }
            #endregion

            #region Main Menu Keybind
            if (Input.GetKeyDown(keybindDict["MAIN MENU"].KeyCode))
            {
                if (characterCollected)
                {
                    if (InGameCheck())
                    {
                        Utility.CloseOpenMenus();
                    }
                    mainMenu.ToggleMenu();
                }
                else
                {
                    lobbyMenu.ToggleMenu();
                }
            }
            #endregion

            if (!chatOpen && InGameCheck())
            {
                #region Player Menu Keybinds
                if (Input.GetKeyDown(keybindDict["PLAYER MENU"].KeyCode))
                {
                    //playerMenu.ToggleMenu();
                    if (navigationToggle && AllowNavigation)
                    {
                        Navigation.menuIndex = 1;
                    }
                }

                if (Input.GetKeyDown(keybindDict["GIVE MONEY"].KeyCode))
                {
                    Menus.Player.GiveMoney();
                }

                if (Input.GetKeyDown(keybindDict["GIVE COINS"].KeyCode))
                {
                    Menus.Player.GiveLunarCoins();
                }

                if (Input.GetKeyDown(keybindDict["GIVE XP"].KeyCode))
                {
                    Menus.Player.GiveXP();
                }

                if (Input.GetKeyDown(keybindDict["STATS MENU"].KeyCode))
                {
                    //statsModMenu.ToggleMenu();
                    if (navigationToggle && AllowNavigation)
                    {
                        Navigation.menuIndex = 8;
                    }
                }

                if (Input.GetKeyDown(keybindDict["VIEW STATS MENU"].KeyCode))
                {
                    //viewStatsMenu.ToggleMenu();
                }

                if (Input.GetKeyDown(keybindDict["CHANGE CHARACTER MENU"].KeyCode))
                {
                    //characterListMenu.ToggleMenu();
                    if (navigationToggle && AllowNavigation)
                    {
                        Navigation.menuIndex = 10;
                    }
                }

                if (Input.GetKeyDown(keybindDict["BUFF MENU"].KeyCode))
                {
                    //buffListMenu.ToggleMenu();
                    if (navigationToggle && AllowNavigation)
                    {
                        Navigation.menuIndex = 11;
                    }
                }

                if (Input.GetKeyDown(keybindDict["REMOVE BUFFS"].KeyCode))
                {
                    Utility.FindButtonById<NormalButton>(1, 7).GetAction().Invoke();
                }

                if (Input.GetKeyDown(keybindDict["AIMBOT"].KeyCode))
                {
                    Menus.Player.AimBotToggle = !Menus.Player.AimBotToggle;
                    Utility.FindButtonById<TogglableButton>(1, 8).SetEnabled(Menus.Player.AimBotToggle);
                }

                if (Input.GetKeyDown(keybindDict["GODMODE"].KeyCode))
                {
                    Menus.Player.GodToggle = !Menus.Player.GodToggle;
                    Utility.FindButtonById<TogglableButton>(1, 9).SetEnabled(Menus.Player.GodToggle);
                }

                if (Input.GetKeyDown(keybindDict["INFINITE SKILLS"].KeyCode))
                {
                    Menus.Player.SkillToggle = !Menus.Player.SkillToggle;
                    Utility.FindButtonById<TogglableButton>(1, 10).SetEnabled(Menus.Player.SkillToggle);
                }
                #endregion

                #region Movement Menu Keybinds
                if (Input.GetKeyDown(keybindDict["MOVEMENT MENU"].KeyCode))
                {
                    //movementMenu.ToggleMenu();
                    if (navigationToggle && AllowNavigation)
                    {
                        Navigation.menuIndex = 2;
                    }
                }

                if (Input.GetKeyDown(keybindDict["ALWAYS SPRINT"].KeyCode))
                {
                    Menus.Movement.alwaysSprintToggle = !Menus.Movement.alwaysSprintToggle;
                    Utility.FindButtonById<TogglableButton>(2, 1).SetEnabled(Menus.Movement.alwaysSprintToggle);
                }

                if (Input.GetKeyDown(keybindDict["FLIGHT"].KeyCode))
                {
                    Menus.Movement.flightToggle = !Menus.Movement.flightToggle;
                    Utility.FindButtonById<TogglableButton>(2, 2).SetEnabled(Menus.Movement.flightToggle);
                }

                if (Input.GetKeyDown(keybindDict["JUMP PACK"].KeyCode))
                {
                    Menus.Movement.jumpPackToggle = !Menus.Movement.jumpPackToggle;
                    Utility.FindButtonById<TogglableButton>(2, 3).SetEnabled(Menus.Movement.jumpPackToggle);
                }
                #endregion

                #region Item Menu Keybinds
                if (Input.GetKeyDown(keybindDict["ITEMS MENU"].KeyCode))
                {
                    //itemsMenu.ToggleMenu();
                    if (navigationToggle && AllowNavigation)
                    {
                        Navigation.menuIndex = 3;
                    }
                }

                if (Input.GetKeyDown(keybindDict["GIVE ALL"].KeyCode))
                {
                    Utility.FindButtonById<MulButton>(3, 1).GetAction().Invoke();
                }

                if (Input.GetKeyDown(keybindDict["ROLL ITEMS"].KeyCode))
                {
                    Utility.FindButtonById<MulButton>(3, 2).GetAction().Invoke();
                }

                if (Input.GetKeyDown(keybindDict["ITEMS LIST MENU"].KeyCode))
                {
                    //itemListMenu.ToggleMenu();
                    if (navigationToggle && AllowNavigation)
                    {
                        Navigation.menuIndex = 12;
                    }
                }

                if (Input.GetKeyDown(keybindDict["EQUIPMENT LIST MENU"].KeyCode))
                {
                    //equipmentListMenu.ToggleMenu();
                    if (navigationToggle && AllowNavigation)
                    {
                        Navigation.menuIndex = 13;
                    }
                }

                if (Input.GetKeyDown(keybindDict["DROP ITEMS"].KeyCode))
                {
                    Menus.Items.isDropItemForAll = !Menus.Items.isDropItemForAll;
                    Utility.FindButtonById<TogglableButton>(3, 5).SetEnabled(Menus.Items.isDropItemForAll);
                }

                if (Input.GetKeyDown(keybindDict["DROP INVENTORY ITEMS"].KeyCode))
                {
                    Menus.Items.isDropItemFromInventory = !Menus.Items.isDropItemFromInventory;
                    Utility.FindButtonById<TogglableButton>(3, 6).SetEnabled(Menus.Items.isDropItemFromInventory);
                }

                if (Input.GetKeyDown(keybindDict["INFINITE EQUIPMENT"].KeyCode))
                {
                    Menus.Items.noEquipmentCD = !Menus.Items.noEquipmentCD;
                    Utility.FindButtonById<TogglableButton>(3, 7).SetEnabled(Menus.Items.noEquipmentCD);
                }

                if (Input.GetKeyDown(keybindDict["STACK INVENTORY"].KeyCode))
                {
                    Utility.FindButtonById<NormalButton>(3, 8).GetAction().Invoke();
                }

                if (Input.GetKeyDown(keybindDict["CLEAR INVENTORY"].KeyCode))
                {
                    Utility.FindButtonById<NormalButton>(3, 9).GetAction().Invoke();
                }

                if (Input.GetKeyDown(keybindDict["CHANGE CHEST ITEM MENU"].KeyCode))
                {
                    //chestItemListMenu.ToggleMenu();
                    if (navigationToggle && AllowNavigation)
                    {
                        Navigation.menuIndex = 14;
                    }
                }
                #endregion

                #region Spawn Menu Keybinds
                if (Input.GetKeyDown(keybindDict["SPAWN MENU"].KeyCode))
                {
                    //spawnMenu.ToggleMenu();
                    if (navigationToggle && AllowNavigation)
                    {
                        Navigation.menuIndex = 4;
                    }
                }

                if (Input.GetKeyDown(keybindDict["SPAWN LIST MENU"].KeyCode))
                {
                    //spawnListMenu.ToggleMenu();
                    if (navigationToggle && AllowNavigation)
                    {
                        Navigation.menuIndex = 15;
                    }
                }

                if (Input.GetKeyDown(keybindDict["KILL ALL"].KeyCode))
                {
                    Utility.FindButtonById<NormalButton>(4, 5).GetAction().Invoke();
                }

                if (Input.GetKeyDown(keybindDict["DESTROY INTERACTABLES"].KeyCode))
                {
                    Utility.FindButtonById<NormalButton>(4, 6).GetAction().Invoke();
                }
                #endregion

                #region Teleport Menu Keybinds 
                if (Input.GetKeyDown(keybindDict["TELEPORTER MENU"].KeyCode))
                {
                    //teleporterMenu.ToggleMenu();
                    if (navigationToggle && AllowNavigation)
                    {
                        Navigation.menuIndex = 5;
                    }
                }

                if (Input.GetKeyDown(keybindDict["SKIP STAGE"].KeyCode))
                {
                    Utility.FindButtonById<NormalButton>(5, 1).GetAction().Invoke();
                }

                if (Input.GetKeyDown(keybindDict["INSTANT TELE CHARGE"].KeyCode))
                {
                    Utility.FindButtonById<NormalButton>(5, 2).GetAction().Invoke();
                }

                if (Input.GetKeyDown(keybindDict["ADD MOUNTAIN STACK"].KeyCode))
                {
                    Utility.FindButtonById<NormalButton>(5, 3).GetAction().Invoke();
                }

                if (Input.GetKeyDown(keybindDict["SPAWN ALL PORTALS"].KeyCode))
                {
                    Utility.FindButtonById<NormalButton>(5, 4).GetAction().Invoke();
                }

                if (Input.GetKeyDown(keybindDict["SPAWN BLUE PORTAL"].KeyCode))
                {
                    Utility.FindButtonById<NormalButton>(5, 5).GetAction().Invoke();
                }

                if (Input.GetKeyDown(keybindDict["SPAWN CELE PORTAL"].KeyCode))
                {
                    Utility.FindButtonById<NormalButton>(5, 6).GetAction().Invoke();
                }

                if (Input.GetKeyDown(keybindDict["SPAWN GOLD PORTAL"].KeyCode))
                {
                    Utility.FindButtonById<NormalButton>(5, 7).GetAction().Invoke();
                }
                #endregion

                #region Render Menu Keybinds
                if (Input.GetKeyDown(keybindDict["RENDER MENU"].KeyCode))
                {
                    //renderMenu.ToggleMenu();
                    if (navigationToggle && AllowNavigation)
                    {
                        Navigation.menuIndex = 6;
                    }
                }

                if (Input.GetKeyDown(keybindDict["RENDER ACTIVE MODS"].KeyCode))
                {
                    Menus.Render.renderMods = !Menus.Render.renderMods;
                    Utility.FindButtonById<TogglableButton>(6, 1).SetEnabled(Menus.Render.renderMods);
                }

                if (Input.GetKeyDown(keybindDict["RENDER INTERACTABLES"].KeyCode))
                {
                    Menus.Render.renderInteractables = !Menus.Render.renderInteractables;
                    Utility.FindButtonById<TogglableButton>(6, 2).SetEnabled(Menus.Render.renderInteractables);
                }

                if (Input.GetKeyDown(keybindDict["RENDER MOB ESP"].KeyCode))
                {
                    Menus.Render.renderMobs = !Menus.Render.renderMobs;
                    Utility.FindButtonById<TogglableButton>(6, 3).SetEnabled(Menus.Render.renderMobs);
                }
                #endregion
            }
        }

        public static Dictionary<string, Keybind> BuildKeybinds()
        {
            Dictionary<string, Keybind> keybinds = new Dictionary<string, Keybind>();
            for (int i = 0; i < keyBindNames.Count; i++)
            {
                Keybind keybind = new Keybind(keyBindNames[i], (KeyCode)Enum.Parse(typeof(KeyCode), Settings[i + 3]));
                keybinds.Add(keyBindNames[i], keybind);
            }
            return keybinds;
        }
        #endregion Inputs
    }
}