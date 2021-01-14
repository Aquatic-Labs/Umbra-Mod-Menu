// TODO:
//     Update allowed hurtbox list to track new mobs
//     remove unused code (including unused 'using's)
//     Implement Settings Menu
//     Implement enhancements and bug fixes from github issues.
//     Add Comments :)

using System;
using System.Collections.Generic;
using UnityEngine;
using RoR2;
using UnityEngine.SceneManagement;
using System.Linq;

namespace UmbraMenu
{
    public class UmbraMenu : MonoBehaviour
    {
        public const string
            NAME = "U M B R A",
            VERSION = "2.0.0";

        #region Player Variables
        public static CharacterMaster LocalPlayer;
        public static CharacterBody LocalPlayerBody;
        public static Inventory LocalPlayerInv;
        public static HealthComponent LocalHealth;
        public static SkillLocator LocalSkills;
        public static NetworkUser LocalNetworkUser;
        public static CharacterMotor LocalMotor;
        #endregion

        #region Init Lists
        public static List<string> unlockableNames = Utility.GetAllUnlockables();
        public static List<GameObject> bodyPrefabs = Utility.GetBodyPrefabs();
        public static List<EquipmentIndex> equipment = Utility.GetEquipment();
        public static List<ItemIndex> items = Utility.GetItems();
        public static List<SpawnCard> spawnCards = Utility.GetSpawnCards();
        #endregion

        #region Misc Variabled used in some features
        public static int previousMenuOpen;
        public static bool characterCollected, navigationToggle, devDoOnce = true, lowResolutionMonitor, chatOpen, msgSent = true, scrolled;
        public static Scene currentScene;
        #endregion

        #region Menus
        public static Menu mainMenu = new Menus.Main();

        public static Menu playerMenu = new Menus.Player();
        public static Menu movementMenu = new Menus.Movement();
        public static Menu itemsMenu = new Menus.Items();
        public static Menu spawnMenu = new Menus.Spawn();
        public static Menu teleporterMenu = new Menus.Teleporter();
        public static Menu renderMenu = new Menus.Render();

        public static Menu statsModMenu = new Menus.StatsMod();
        public static Menu viewStatsMenu = new Menus.ViewStats();
        public static Menu characterListMenu = new Menus.CharacterList();
        public static Menu buffListMenu = new Menus.BuffList();

        public static Menu itemListMenu = new Menus.ItemList();
        public static Menu equipmentListMenu = new Menus.EquipmentList();
        public static Menu chestItemListMenu = new Menus.ChestItemList();

        public static Menu spawnListMenu = new Menus.SpawnList();

        public static List<Menu> menus = new List<Menu>()
        {
            mainMenu, //0
            playerMenu, //1
            movementMenu, //2
            itemsMenu, //3
            spawnMenu, //4
            teleporterMenu, //5
            renderMenu, //6
            statsModMenu, //8
            viewStatsMenu, //9
            characterListMenu, //10
            buffListMenu, //11
            itemListMenu, //12
            equipmentListMenu, //13
            chestItemListMenu, //14
            spawnListMenu //15
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
                    GUI.Label(new Rect(Screen.width - 210, 1f, 100, 50f), $"Umbra Menu (v{VERSION}) <color=grey>-</color> <color=yellow>Lastest (v{Loader.latestVersion})</color>", Styles.WatermarkStyle);
                }
                else if (Loader.upToDate)
                {
                    GUI.Label(new Rect(Screen.width - 210, 1f, 100, 50f), $"Umbra Menu (v{VERSION})", Styles.WatermarkStyle);
                }
                else if (Loader.devBuild)
                {
                    GUI.Label(new Rect(Screen.width - 210, 1f, 100, 50f), $"Umbra Menu (v{VERSION}) <color=grey>-</color> <color=yellow>Dev Build</color>", Styles.WatermarkStyle);
                }
                #endregion

                mainMenu.Draw(); //0
                playerMenu.Draw(); //1
                movementMenu.Draw(); //2
                itemsMenu.Draw(); //3
                spawnMenu.Draw(); //4
                teleporterMenu.Draw(); //5
                renderMenu.Draw(); //6

                statsModMenu.Draw(); //8
                viewStatsMenu.Draw(); //9
                characterListMenu.Draw(); //10
                buffListMenu.Draw(); //11

                itemListMenu.Draw(); //12
                equipmentListMenu.Draw(); //13
                chestItemListMenu.Draw(); //14

                spawnListMenu.Draw(); //15

                ESPRoutine();
                // UpdateMenusAndButtonsRoutine();
            }
            catch (Exception e)
            {
                Debug.Log($"OnGUI threw exception: {e}");
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
                    //settingsMenu.SetRect(new Rect(374, 10, 20, 20)); // Start Position

                    statsModMenu.SetRect(new Rect(374, 10, 20, 20)); // Start Position
                    viewStatsMenu.SetRect(new Rect(374, 10, 20, 20)); // Start Position
                    characterListMenu.SetRect(new Rect(374, 10, 20, 20)); // Start Position
                    buffListMenu.SetRect(new Rect(374, 10, 20, 20)); // Start Position
                    itemListMenu.SetRect(new Rect(374, 10, 20, 20)); // Start Position
                    equipmentListMenu.SetRect(new Rect(374, 10, 20, 20)); // Start Position
                    chestItemListMenu.SetRect(new Rect(374, 10, 20, 20)); // Start Position
                    spawnListMenu.SetRect(new Rect(374, 10, 20, 20)); // Start Position*/

                    Menus.Render.renderMods = false;
                }
                #endregion
            }
            catch (Exception e)
            {
                Debug.Log($"Start threw exception: {e}");
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
                ModStatsRoutine();
                FlightRoutine();
                SprintRoutine();
                JumpPackRoutine();

                UpdateNavIndexRoutine();
                // UpdateMenuPositions();
                Menus.ViewStats.UpdateViewStats();
                UpdateMainButtonsRoutine();
            }
            catch (Exception e)
            {
                Debug.Log($"Update threw exception: {e}");
            }
        }

        public void FixedUpdate()
        {
            currentScene = SceneManager.GetActiveScene();
            if (InGameCheck())
            {
                if (Menus.Render.renderMobs)
                {
                    Menus.Render.hurtBoxes = Utility.GetHurtBoxes();
                }
                if (Menus.Items.chestItemList)
                {
                    Menus.ChestItemList.IsClosestChestEquip = Menus.ChestItemList.CheckClosestChestEquip();
                }
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

            if (mainMenu.IsEnabled())
            {
                Cursor.visible = true;
                if (characterCollected)
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
                if (navigationToggle)
                {
                    if (Input.GetKeyDown(KeyCode.V))
                    {
                        int oldMenuIndex = Navigation.menuIndex;
                        Navigation.PressBtn(Navigation.menuIndex, Navigation.buttonIndex);
                        int newMenuIndex = Navigation.menuIndex;

                        if (oldMenuIndex != newMenuIndex)
                        {
                            Navigation.buttonIndex = 1;
                        }
                    }
                    if (Input.GetKeyDown(KeyCode.RightArrow))
                    {
                        bool playerPlusMinusBtn = Navigation.menuIndex == 1 && Enumerable.Range(1, 3).Contains(Navigation.buttonIndex);
                        bool statsPlusMinusBtn = Navigation.menuIndex == 8 && Enumerable.Range(1, 6).Contains(Navigation.buttonIndex);
                        bool itemPlusMinusBtn = Navigation.menuIndex == 3 && Enumerable.Range(1, 2).Contains(Navigation.buttonIndex);
                        bool spawnPlusMinusBtn = Navigation.menuIndex == 4 && Enumerable.Range(1, 3).Contains(Navigation.buttonIndex);
                        if (playerPlusMinusBtn || itemPlusMinusBtn || statsPlusMinusBtn || spawnPlusMinusBtn)
                        {
                            Navigation.IncreaseValue(Navigation.menuIndex, Navigation.buttonIndex);
                        }
                        else
                        {
                            float oldMenuIndex = Navigation.menuIndex;
                            Navigation.PressBtn(Navigation.menuIndex, Navigation.buttonIndex);
                            float newMenuIndex = Navigation.menuIndex;

                            if (oldMenuIndex != newMenuIndex)
                            {
                                Navigation.buttonIndex = 1;
                            }
                        }
                    }
                    if (Input.GetKeyDown(KeyCode.LeftArrow))
                    {
                        bool playerPlusMinusBtn = Navigation.menuIndex == 1 && Enumerable.Range(1, 3).Contains(Navigation.buttonIndex);
                        bool statsPlusMinusBtn = Navigation.menuIndex == 8 && Enumerable.Range(1, 6).Contains(Navigation.buttonIndex);
                        bool itemPlusMinusBtn = Navigation.menuIndex == 3 && Enumerable.Range(1, 2).Contains(Navigation.buttonIndex);
                        bool spawnPlusMinusBtn = Navigation.menuIndex == 4 && Enumerable.Range(1, 3).Contains(Navigation.buttonIndex);
                        if (playerPlusMinusBtn || itemPlusMinusBtn || statsPlusMinusBtn || spawnPlusMinusBtn)
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

                    if (buffListMenu.IsEnabled() || characterListMenu.IsEnabled() || chestItemListMenu.IsEnabled() || equipmentListMenu.IsEnabled() || itemListMenu.IsEnabled() || spawnListMenu.IsEnabled())
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

            if (Input.GetKeyDown(KeyCode.Insert))
            {
                if (InGameCheck())
                {
                    Utility.FindButtonById(0, 8).SetEnabled(false);
                }

                if (mainMenu.IsEnabled() && navigationToggle)
                {
                    Utility.CloseOpenMenus();
                }
                mainMenu.ToggleMenu();
                GetCharacter();
            }

            if (!chatOpen && InGameCheck())
            {
                if (Input.GetKeyDown(KeyCode.Z))
                {
                    playerMenu.ToggleMenu();
                    if (navigationToggle)
                    {
                        Navigation.menuIndex = 1;
                    }
                }

                if (Input.GetKeyDown(KeyCode.I))
                {
                    itemListMenu.ToggleMenu();
                    if (navigationToggle)
                    {
                        Navigation.menuIndex = 12;
                    }
                }

                if (Input.GetKeyDown(KeyCode.C))
                {
                    Menus.Movement.flightToggle = !Menus.Movement.flightToggle;
                    Utility.FindButtonById(2, 2).SetEnabled(Menus.Movement.flightToggle);
                }

                if (Input.GetKeyDown(KeyCode.B))
                {
                    teleporterMenu.ToggleMenu();
                    if (navigationToggle)
                    {
                        Navigation.menuIndex = 5;
                    }
                }
            }
        }
        #endregion Inputs

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

                    for (int i = 0; i < NetworkUser.readOnlyInstancesList.Count; i++)
                    {
                        NetworkUser readOnlyInstance = NetworkUser.readOnlyInstancesList[i];
                        if (readOnlyInstance.isLocalPlayer)
                        {
                            LocalNetworkUser = readOnlyInstance;
                            LocalPlayer = LocalNetworkUser.master;
                            LocalPlayerInv = LocalPlayer.GetComponent<Inventory>();
                            LocalHealth = LocalPlayer.GetBody().GetComponent<HealthComponent>();
                            LocalSkills = LocalPlayer.GetBody().GetComponent<SkillLocator>();
                            LocalPlayerBody = LocalPlayer.GetBody().GetComponent<CharacterBody>();
                            if (LocalHealth.alive) characterCollected = true;
                            else characterCollected = false;
                            if (LocalPlayer.isActiveAndEnabled) characterCollected = true;
                            else characterCollected = false;
                            if (LocalPlayerBody.isActiveAndEnabled) characterCollected = true;
                            else characterCollected = false;
                        }
                        else
                        {
                            characterCollected = false;
                        }
                    }
                }
                else
                {
                    characterCollected = false;
                }
            }
            catch (Exception e)
            {
                Debug.LogError($"GetCharacter caused an exception: {e}");
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
            bool prevCharCollected = characterCollected;
            GetCharacter();
            if (prevCharCollected != characterCollected && characterCollected && InGameCheck())
            {
                Utility.SoftResetMenu(true);
            }
        }

        private void DevBuildRoutine()
        {
            if (Loader.devBuild)
            {
                if (characterCollected)
                {
                    if (devDoOnce)
                    {
                        Menus.Player.GodToggle = true;
                        Utility.FindButtonById(1, 9).SetEnabled(true);

                        Menus.Movement.flightToggle = true;
                        Utility.FindButtonById(2, 2).SetEnabled(true);

                        Menus.Movement.alwaysSprintToggle = true;
                        Utility.FindButtonById(2, 1).SetEnabled(true);

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

                if (Menus.Items.chestItemList)
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
                    Menus.Player.GodMode();
                }
                else
                {
                    UmbraMenu.LocalHealth.godMode = false;
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

        private void ModStatsRoutine()
        {
            if (characterCollected)
            {
                if (Menus.StatsMod.damageToggle)
                {
                    Menus.StatsMod.LevelPlayersDamage();
                }
                if (Menus.StatsMod.critToggle)
                {
                    Menus.StatsMod.LevelPlayersCrit();
                }
                if (Menus.StatsMod.attackSpeedToggle)
                {
                    Menus.StatsMod.SetplayersAttackSpeed();
                }
                if (Menus.StatsMod.armorToggle)
                {
                    Menus.StatsMod.SetplayersArmor();
                }
                if (Menus.StatsMod.moveSpeedToggle)
                {
                    Menus.StatsMod.SetplayersMoveSpeed();
                }
                LocalPlayerBody.RecalculateStats();
            }
        }

        private void UpdateMainButtonsRoutine()
        {
            if (InGameCheck())
            {
                for (int i = 1; i < menus.Count; i++)
                {
                    if (menus[i].IsEnabled())
                    {
                        menus[i].GetActivatingButton().SetEnabled(true);
                    }
                    else
                    {
                        menus[i].GetActivatingButton().SetEnabled(false);

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
        #endregion
    }
}
