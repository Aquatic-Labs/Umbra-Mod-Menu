using System;
using System.Collections.Generic;
using UnityEngine;
using RoR2;
using UnityEngine.SceneManagement;
using Player = UmbraMenu.Model.Cheats.Player;
using Movement = UmbraMenu.Model.Cheats.Movement;
using Items = UmbraMenu.Model.Cheats.Items;
using Spawn = UmbraMenu.Model.Cheats.Spawn;
using Teleporter = UmbraMenu.Model.Cheats.Teleporter;
using Render = UmbraMenu.Model.Cheats.Render;
using Chests = UmbraMenu.Model.Cheats.Chests;

namespace UmbraMenu.View
{
    public class UmbraModGUI : MonoBehaviour
    {
        public Model.UmbraMod umbraMod = Model.UmbraMod.Instance;

        #region Menus
        public LobbyMenu lobbyMenu;

        public MainMenu mainMenu;

        public PlayerMenu playerMenu;
        public MovementMenu movementMenu;
        public ItemsMenu itemsMenu;
        public SpawnMenu spawnMenu;
        public TeleporterMenu teleporterMenu;
        public RenderMenu renderMenu;
        public SettingsMenu settingsMenu;

        public StatsModMenu statsModMenu;
        public ViewStatsMenu viewStatsMenu;
        public CharacterListMenu characterListMenu;
        public BuffListMenu buffListMenu;

        public ItemListMenu itemListMenu;
        public EquipmentListMenu equipmentListMenu;
        public ChestItemListMenu chestItemListMenu;

        public SpawnListMenu spawnListMenu;

        public KeybindListMenu keybindListMenu;

        public List<Menu> menus;
        #endregion

        public int previousMenuOpen;
        public bool navigationToggle, forceFullModMenu, lowResolutionMonitor, scrolled;

        public float width;
        public bool allowNavigation;

        static UmbraModGUI() { }

        private UmbraModGUI()
        {
            try
            {
                lobbyMenu = new LobbyMenu();
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
                keybindListMenu //16
            };

                width = float.Parse(umbraMod.Settings[0]);
                allowNavigation = bool.Parse(umbraMod.Settings[1]);

                umbraMod.OnGUIUpdate += DrawWaterMarkRoutine;
                umbraMod.OnGUIUpdate += DrawMenusRoutine;

                umbraMod.OnStart += ResolutionCheckRoutine;

                umbraMod.OnUpdate += LowResolutionRoutine;
                umbraMod.OnUpdate += UpdateNavIndexRoutine;
                umbraMod.OnUpdate += DevBuildGUIRoutine;
                umbraMod.OnUpdate += ViewStatsMenu.UpdateViewStats;
                umbraMod.OnUpdate += UpdateKeybindButtonRoutine;
                umbraMod.OnUpdate += ForceFullMenuRoutine;
                umbraMod.OnUpdate += CheckInputsGUIRoutine;

                umbraMod.OnCharacterUpdate += BuildMenusRoutine;

                umbraMod.OnKeybindUpdated += SetKeybindRoutineGUI;

                SceneManager.activeSceneChanged += OnSceneLoadedGUIRoutine;
            }
            catch
            {
                Debug.Log("Error while loading UmbraModGUI");
            }
        }

        public static UmbraModGUI Instance { get; } = new UmbraModGUI();

        #region Routines
        #region OnGUIUpdate Routines
        private void DrawWaterMarkRoutine(object sender, EventArgs e)
        {
            if (Loader.updateAvailable)
            {
                GUI.Label(new Rect(Screen.width - 250, 1f, 100, 50f), $"Umbra Menu (v{Model.UmbraMod.VERSION}) <color=grey>-</color> <color=yellow>Lastest (v{Loader.latestVersion})</color>", Styles.WatermarkStyle);
            }
            else if (Loader.upToDate)
            {
                GUI.Label(new Rect(Screen.width - 140, 1f, 100, 50f), $"Umbra Menu (v{Model.UmbraMod.VERSION})", Styles.WatermarkStyle);
            }
            else if (Loader.devBuild)
            {
                GUI.Label(new Rect(Screen.width - 210, 1f, 100, 50f), $"Umbra Menu (v{Model.UmbraMod.VERSION}) <color=grey>-</color> <color=yellow>Dev Build</color>", Styles.WatermarkStyle);
            }
        }

        private void DrawMenusRoutine(object sender, EventArgs e)
        {
            if (umbraMod.characterCollected)
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
        }
        #endregion

        #region OnStart Routines
        private void ResolutionCheckRoutine(object sender, EventArgs e)
        {
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
            }
        }
        #endregion

        #region OnUpdate Routines
        private void CheckInputsGUIRoutine(object sender, EventArgs e)
        {
            if (umbraMod.characterCollected)
            {
                if (mainMenu.IsEnabled())
                {
                    Cursor.visible = true;
                    if (umbraMod.characterCollected)
                    {
                        if (allowNavigation)
                        {
                            if (Input.GetKeyDown(KeyCode.DownArrow))
                            {
                                if (!navigationToggle)
                                {
                                    GUIUtility.CloseOpenMenus();
                                }

                                navigationToggle = true;
                                Navigation.buttonIndex++;
                            }
                            if (Input.GetKeyDown(KeyCode.UpArrow))
                            {
                                if (!navigationToggle)
                                {
                                    GUIUtility.CloseOpenMenus();
                                }

                                navigationToggle = true;
                                Navigation.buttonIndex--;
                            }
                        }
                    }
                    if (navigationToggle && allowNavigation)
                    {
                        if (Input.GetKeyDown(KeyCode.V))
                        {
                            Navigation.PressBtn(Navigation.menuIndex, Navigation.buttonIndex);
                        }
                        if (Input.GetKeyDown(KeyCode.RightArrow))
                        {

                            if (menus[Navigation.menuIndex].GetButtons()[Navigation.buttonIndex - 1] is MulButton)
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
                            if (menus[Navigation.menuIndex].GetButtons()[Navigation.buttonIndex - 1] is MulButton)
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

            GUIKeybinds();
        }

        private void LowResolutionRoutine(object sender, EventArgs e)
        {
            if (lowResolutionMonitor)
            {
                var menusOpen = GUIUtility.GetMenusOpen();

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
        }

        private void DevBuildGUIRoutine(object sender, EventArgs e)
        {
            if (Loader.devBuild)
            {
                if (umbraMod.characterCollected)
                {
                    if (umbraMod.devDoOnce && umbraMod.devMode && umbraMod.devRoutineFired)
                    {
                        playerMenu.toggleGod.SetEnabled(true);
                        movementMenu.toggleFlight.SetEnabled(true);
                        movementMenu.toggleAlwaysSprint.SetEnabled(true);

                        umbraMod.devRoutineFired = false;
                    }
                }
            }
        }

        private void UpdateKeybindButtonRoutine(object sender, EventArgs e)
        {
            if (umbraMod.InGameCheck() && keybindListMenu.IsEnabled())
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
                    }
                }
            }
        }

        private void UpdateNavIndexRoutine(object sender, EventArgs e)
        {
            if (navigationToggle)
            {
                Navigation.UpdateIndexValues();
            }
        }

        private void ForceFullMenuRoutine(object sender, EventArgs e)
        {
            if (forceFullModMenu == true)
            {
                umbraMod.characterCollected = true;
            }
        }
        #endregion

        #region OnFixedUpdate Routines
        #endregion

        #region OnCharacterUpdate Routines
        private void BuildMenusRoutine(object sender, EventArgs e)
        {
            if (umbraMod.characterCollected && mainMenu == null)
            {
                mainMenu = new MainMenu();

                playerMenu = new PlayerMenu();
                movementMenu = new MovementMenu();
                itemsMenu = new ItemsMenu();
                spawnMenu = new SpawnMenu();
                teleporterMenu = new TeleporterMenu();
                renderMenu = new RenderMenu();
                settingsMenu = new SettingsMenu();

                statsModMenu = new StatsModMenu();
                viewStatsMenu = new ViewStatsMenu();
                characterListMenu = new CharacterListMenu();
                buffListMenu = new BuffListMenu();

                itemListMenu = new ItemListMenu();
                equipmentListMenu = new EquipmentListMenu();
                chestItemListMenu = new ChestItemListMenu();

                spawnListMenu = new SpawnListMenu();

                keybindListMenu = new KeybindListMenu();

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
                    keybindListMenu //16
                };
            }
        }
        #endregion

        #region OnKeybindUpdated Routine
        private void SetKeybindRoutineGUI(object sender, Model.UmbraMod.KeybindUpdatedEventArgs e)
        {
            TogglableButton button = (TogglableButton)GUIUtility.GetEnabledKeybindButton();
            Model.Keybind newKeybind = e.newKeybind;
            KeyCode keyCode = newKeybind.KeyCode;

            if (e.wasInUse)
            {
                // Find and update previous button and keybind that used the same keycode
                Model.Keybind keybind = Model.Utility.FindKeybindByKeyCode(keyCode);
                foreach (TogglableButton keybindButton in keybindListMenu.GetButtons())
                {
                    string[] buttonTextArray = keybindButton.GetOffText().Split(new string[] { " : " }, StringSplitOptions.None);
                    if (buttonTextArray[1] == keyCode.ToString())
                    {
                        keybindButton.SetText($"{buttonTextArray[0]} : {KeyCode.None}");
                        keybindButton.OffText = $"{buttonTextArray[0]} : {KeyCode.None}";
                        keybindButton.OnText = $"{buttonTextArray[0]} : {KeyCode.None}";
                        keybindButton.SetEnabled(false);
                        break;
                    }
                }
                keybind.KeyCode = KeyCode.None;


                string keybindName = button.GetOffText().Split(new string[] { " :" }, StringSplitOptions.None)[0];
                button.SetText($"{keybindName} : {umbraMod.keybindDict[keybindName].KeyCode}");
                button.OffText = $"{keybindName} : {umbraMod.keybindDict[keybindName].KeyCode}";
                button.OnText = $"{keybindName} : {umbraMod.keybindDict[keybindName].KeyCode}";
                button.SetEnabled(false);
            }
            else
            {
                string keybindName = button.GetOffText().Split(new string[] { " :" }, StringSplitOptions.None)[0];
                button.SetText($"{keybindName} : {umbraMod.keybindDict[keybindName].KeyCode}");
                button.OffText = $"{keybindName} : {umbraMod.keybindDict[keybindName].KeyCode}";
                button.OnText = $"{keybindName} : {umbraMod.keybindDict[keybindName].KeyCode}";
                button.SetEnabled(false);
            }
        }
        #endregion

        #region Misc Routines
        private void OnSceneLoadedGUIRoutine(Scene s1, Scene s2)
        {
            if (s2 != null)
            {
                bool inGame = s2.name != "title" && s2.name != "lobby" && s2.name != "" && s2.name != " ";
                if (!inGame)
                {
                    if (Screen.height < 1080)
                    {
                        lowResolutionMonitor = true;
                    }
                    GUIUtility.ResetMenu();
                }
            }
        }
        #endregion
        #endregion

        #region Inputs
        private void GUIKeybinds()
        {
            #region Dev Mode Keybinds
            if (Input.GetKeyDown(KeyCode.F7))
            {
                forceFullModMenu = !forceFullModMenu;
            }
            #endregion

            #region Main Menu Keybind
            if (Input.GetKeyDown(umbraMod.keybindDict["MAIN MENU"].KeyCode))
            {
                if (umbraMod.characterCollected)
                {
                    if (umbraMod.InGameCheck())
                    {
                        GUIUtility.CloseOpenMenus();
                    }
                    mainMenu.ToggleMenu();
                }
                else
                {
                    lobbyMenu.ToggleMenu();
                }
            }
            #endregion

            if (!umbraMod.chatOpen && umbraMod.InGameCheck())
            {
                #region Player Menu Keybinds
                if (Input.GetKeyDown(umbraMod.keybindDict["PLAYER MENU"].KeyCode))
                {
                    playerMenu.ToggleMenu();
                    if (navigationToggle && allowNavigation)
                    {
                        Navigation.menuIndex = 1;
                    }
                }

                if (Input.GetKeyDown(umbraMod.keybindDict["STATS MENU"].KeyCode))
                {
                    statsModMenu.ToggleMenu();
                    if (navigationToggle && allowNavigation)
                    {
                        Navigation.menuIndex = 8;
                    }
                }

                if (Input.GetKeyDown(umbraMod.keybindDict["VIEW STATS MENU"].KeyCode))
                {
                    viewStatsMenu.ToggleMenu();
                }

                if (Input.GetKeyDown(umbraMod.keybindDict["CHANGE CHARACTER MENU"].KeyCode))
                {
                    characterListMenu.ToggleMenu();
                    if (navigationToggle && allowNavigation)
                    {
                        Navigation.menuIndex = 10;
                    }
                }

                if (Input.GetKeyDown(umbraMod.keybindDict["BUFF MENU"].KeyCode))
                {
                    buffListMenu.ToggleMenu();
                    if (navigationToggle && allowNavigation)
                    {
                        Navigation.menuIndex = 11;
                    }
                }

                if (Input.GetKeyDown(umbraMod.keybindDict["AIMBOT"].KeyCode))
                {
                    playerMenu.toggleAimbot.SetEnabled(Player.AimBotToggle);
                }

                if (Input.GetKeyDown(umbraMod.keybindDict["GODMODE"].KeyCode))
                {
                    playerMenu.toggleGod.SetEnabled(Player.GodToggle);
                }

                if (Input.GetKeyDown(umbraMod.keybindDict["INFINITE SKILLS"].KeyCode))
                {
                    playerMenu.toggleSkillCD.SetEnabled(Player.SkillToggle);
                }
                #endregion

                #region Movement Menu Keybinds
                if (Input.GetKeyDown(umbraMod.keybindDict["MOVEMENT MENU"].KeyCode))
                {
                    movementMenu.ToggleMenu();
                    if (navigationToggle && allowNavigation)
                    {
                        Navigation.menuIndex = 2;
                    }
                }

                if (Input.GetKeyDown(umbraMod.keybindDict["ALWAYS SPRINT"].KeyCode))
                {
                    movementMenu.toggleAlwaysSprint.SetEnabled(Movement.alwaysSprintToggle);
                }

                if (Input.GetKeyDown(umbraMod.keybindDict["FLIGHT"].KeyCode))
                {
                    movementMenu.toggleFlight.SetEnabled(Movement.flightToggle);
                }

                if (Input.GetKeyDown(umbraMod.keybindDict["JUMP PACK"].KeyCode))
                {

                    movementMenu.toggleJumpPack.SetEnabled(Movement.jumpPackToggle);
                }
                #endregion

                #region Item Menu Keybinds
                if (Input.GetKeyDown(umbraMod.keybindDict["ITEMS MENU"].KeyCode))
                {
                    itemsMenu.ToggleMenu();
                    if (navigationToggle && allowNavigation)
                    {
                        Navigation.menuIndex = 3;
                    }
                }

                if (Input.GetKeyDown(umbraMod.keybindDict["ITEMS LIST MENU"].KeyCode))
                {
                    itemListMenu.ToggleMenu();
                    if (navigationToggle && allowNavigation)
                    {
                        Navigation.menuIndex = 12;
                    }
                }

                if (Input.GetKeyDown(umbraMod.keybindDict["EQUIPMENT LIST MENU"].KeyCode))
                {
                    equipmentListMenu.ToggleMenu();
                    if (navigationToggle && allowNavigation)
                    {
                        Navigation.menuIndex = 13;
                    }
                }

                if (Input.GetKeyDown(umbraMod.keybindDict["CHANGE CHEST ITEM MENU"].KeyCode))
                {
                    chestItemListMenu.ToggleMenu();
                    if (navigationToggle && allowNavigation)
                    {
                        Navigation.menuIndex = 14;
                    }
                }

                if (Input.GetKeyDown(umbraMod.keybindDict["DROP ITEMS"].KeyCode))
                {
                    itemsMenu.toggleDropItems.SetEnabled(Items.isDropItemForAll);
                }

                if (Input.GetKeyDown(umbraMod.keybindDict["DROP INVENTORY ITEMS"].KeyCode))
                {
                    itemsMenu.toggleDropInvItems.SetEnabled(Items.isDropItemFromInventory);
                }

                if (Input.GetKeyDown(umbraMod.keybindDict["INFINITE EQUIPMENT"].KeyCode))
                {
                    itemsMenu.toggleEquipmentCD.SetEnabled(Items.noEquipmentCD);
                }
                #endregion

                #region Spawn Menu Keybinds
                if (Input.GetKeyDown(umbraMod.keybindDict["SPAWN MENU"].KeyCode))
                {
                    spawnMenu.ToggleMenu();
                    if (navigationToggle && allowNavigation)
                    {
                        Navigation.menuIndex = 4;
                    }
                }

                if (Input.GetKeyDown(umbraMod.keybindDict["SPAWN LIST MENU"].KeyCode))
                {
                    spawnListMenu.ToggleMenu();
                    if (navigationToggle && allowNavigation)
                    {
                        Navigation.menuIndex = 15;
                    }
                }
                #endregion

                #region Teleport Menu Keybinds 
                if (Input.GetKeyDown(umbraMod.keybindDict["TELEPORTER MENU"].KeyCode))
                {
                    teleporterMenu.ToggleMenu();
                    if (navigationToggle && allowNavigation)
                    {
                        Navigation.menuIndex = 5;
                    }
                }
                #endregion

                #region Render Menu Keybinds
                if (Input.GetKeyDown(umbraMod.keybindDict["RENDER MENU"].KeyCode))
                {
                    renderMenu.ToggleMenu();
                    if (navigationToggle && allowNavigation)
                    {
                        Navigation.menuIndex = 6;
                    }
                }

                if (Input.GetKeyDown(umbraMod.keybindDict["RENDER ACTIVE MODS"].KeyCode))
                {
                    renderMenu.toggleActiveMods.SetEnabled(Render.renderMods);
                }

                if (Input.GetKeyDown(umbraMod.keybindDict["RENDER INTERACTABLES"].KeyCode))
                {
                    renderMenu.toggleInteractESP.SetEnabled(Render.renderInteractables);
                }

                if (Input.GetKeyDown(umbraMod.keybindDict["RENDER MOB ESP"].KeyCode))
                {
                    renderMenu.toggleMobESP.SetEnabled(Render.renderMobs);
                }
                #endregion
            }
        }
        #endregion Inputs
    }
}
