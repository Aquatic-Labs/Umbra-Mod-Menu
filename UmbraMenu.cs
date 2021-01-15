// TODO:
//     Update allowed hurtbox list to track new mobs
//     charge purple w/ HoldOutZoneController
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
using System.IO;

namespace UmbraMenu
{
    public class UmbraMenu : MonoBehaviour
    {
        public const string
            NAME = "U M B R A",
            VERSION = "2.0.0";

        public static string SETTINGSPATH = System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "UmbraMenu/settings.ini");

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

        #region Settings Variables
        public static string[] Settings = Utility.ReadSettings();
        public static float Width = float.Parse(Settings[0]);
        public static bool AllowNavigation = bool.Parse(Settings[1]);
        public static int GodVersion = int.Parse(Settings[2]);

        public static KeyCode OpenMainMenuKeybind = (KeyCode)Enum.Parse(typeof(KeyCode), Settings[3]);

        public static KeyCode OpenPlayerMenuKeybind = (KeyCode)Enum.Parse(typeof(KeyCode), Settings[4]);
        public static KeyCode GiveMoneyKeybind = (KeyCode)Enum.Parse(typeof(KeyCode), Settings[5]);
        public static KeyCode GiveCoinKeybind = (KeyCode)Enum.Parse(typeof(KeyCode), Settings[6]);
        public static KeyCode GiveExpKeybind = (KeyCode)Enum.Parse(typeof(KeyCode), Settings[7]);
        public static KeyCode OpenStatsModKeybind = (KeyCode)Enum.Parse(typeof(KeyCode), Settings[8]);
        public static KeyCode OpenViewStatsKeybind = (KeyCode)Enum.Parse(typeof(KeyCode), Settings[9]);
        public static KeyCode OpenChangeCharacterListKeybind = (KeyCode)Enum.Parse(typeof(KeyCode), Settings[10]);
        public static KeyCode OpenBuffListKeybind = (KeyCode)Enum.Parse(typeof(KeyCode), Settings[11]);
        public static KeyCode RemoveAllBuffsKeybind = (KeyCode)Enum.Parse(typeof(KeyCode), Settings[12]);
        public static KeyCode AimbotKeybind = (KeyCode)Enum.Parse(typeof(KeyCode), Settings[13]);
        public static KeyCode GodModeKeybind = (KeyCode)Enum.Parse(typeof(KeyCode), Settings[14]);
        public static KeyCode InfiniteSkillsKeybind = (KeyCode)Enum.Parse(typeof(KeyCode), Settings[15]);

        public static KeyCode OpenMovementMenuKeybind = (KeyCode)Enum.Parse(typeof(KeyCode), Settings[16]);
        public static KeyCode AlwaysSprintKeybind = (KeyCode)Enum.Parse(typeof(KeyCode), Settings[17]);
        public static KeyCode FlightKeybind = (KeyCode)Enum.Parse(typeof(KeyCode), Settings[18]);
        public static KeyCode JumpPackKeybind = (KeyCode)Enum.Parse(typeof(KeyCode), Settings[19]);

        public static KeyCode OpenItemsMenuKeybind = (KeyCode)Enum.Parse(typeof(KeyCode), Settings[20]);
        public static KeyCode GiveAllKeybind = (KeyCode)Enum.Parse(typeof(KeyCode), Settings[21]);
        public static KeyCode RollItemsKeybind = (KeyCode)Enum.Parse(typeof(KeyCode), Settings[22]);
        public static KeyCode OpenItemsListMenuKeybind = (KeyCode)Enum.Parse(typeof(KeyCode), Settings[23]);
        public static KeyCode OpenEquipmentListMenuKeybind = (KeyCode)Enum.Parse(typeof(KeyCode), Settings[24]);
        public static KeyCode DropItemsKeybind = (KeyCode)Enum.Parse(typeof(KeyCode), Settings[25]);
        public static KeyCode DropInvItemsKeybind = (KeyCode)Enum.Parse(typeof(KeyCode), Settings[26]);
        public static KeyCode InfiniteEquipmentKeybind = (KeyCode)Enum.Parse(typeof(KeyCode), Settings[27]);
        public static KeyCode StackInvKeybind = (KeyCode)Enum.Parse(typeof(KeyCode), Settings[28]);
        public static KeyCode ClearInvKeybind = (KeyCode)Enum.Parse(typeof(KeyCode), Settings[29]);
        public static KeyCode OpenChestItemListKeybind = (KeyCode)Enum.Parse(typeof(KeyCode), Settings[30]);

        public static KeyCode OpenSpawnMenuKeybind = (KeyCode)Enum.Parse(typeof(KeyCode), Settings[31]);
        public static KeyCode OpenSpawnListMenuKeybind = (KeyCode)Enum.Parse(typeof(KeyCode), Settings[32]);
        public static KeyCode KillAllKeybind = (KeyCode)Enum.Parse(typeof(KeyCode), Settings[33]);
        public static KeyCode DestroyIntKeybind = (KeyCode)Enum.Parse(typeof(KeyCode), Settings[34]);

        public static KeyCode OpenTeleMenuKeybind = (KeyCode)Enum.Parse(typeof(KeyCode), Settings[35]);
        public static KeyCode SkipStageKeybind = (KeyCode)Enum.Parse(typeof(KeyCode), Settings[36]);
        public static KeyCode InstantTeleKeybind = (KeyCode)Enum.Parse(typeof(KeyCode), Settings[37]);
        public static KeyCode AddMtnKeybind = (KeyCode)Enum.Parse(typeof(KeyCode), Settings[38]);
        public static KeyCode SpawnAllPortalsKeybind = (KeyCode)Enum.Parse(typeof(KeyCode), Settings[39]);
        public static KeyCode SpawnBlueKeybind = (KeyCode)Enum.Parse(typeof(KeyCode), Settings[40]);
        public static KeyCode SpawnCelKeybind = (KeyCode)Enum.Parse(typeof(KeyCode), Settings[41]);
        public static KeyCode SpawnGoldKeybind = (KeyCode)Enum.Parse(typeof(KeyCode), Settings[42]);

        public static KeyCode OpenRenderMenuKeybind = (KeyCode)Enum.Parse(typeof(KeyCode), Settings[43]);
        public static KeyCode RenActiveModsKeybind = (KeyCode)Enum.Parse(typeof(KeyCode), Settings[44]);
        public static KeyCode RenIntKeybind = (KeyCode)Enum.Parse(typeof(KeyCode), Settings[45]);
        public static KeyCode RenMobKeybind = (KeyCode)Enum.Parse(typeof(KeyCode), Settings[46]);
        #endregion

        #region Menus
        public static Menu mainMenu = new Menus.Main();

        public static Menu playerMenu = new Menus.Player();
        public static Menu movementMenu = new Menus.Movement();
        public static Menu itemsMenu = new Menus.Items();
        public static Menu spawnMenu = new Menus.Spawn();
        public static Menu teleporterMenu = new Menus.Teleporter();
        public static Menu renderMenu = new Menus.Render();
        public static Menu settingsMenu = new Menus.Settings();

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
            settingsMenu, //7
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
                    settingsMenu.SetRect(new Rect(374, 10, 20, 20)); // Start Position

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
                    switch (GodVersion)
                    {
                        case 0:
                            {
                                // works
                                // Normal
                                Menus.Player.GodMode();
                                break;
                            }

                        case 1:
                            {
                                // works
                                // Barrier
                                LocalHealth.AddBarrier(float.MaxValue);
                                break;
                            }

                        case 2:
                            {
                                // works
                                // Regen
                                LocalHealth.Heal(float.MaxValue, new ProcChainMask(), false);
                                break;
                            }

                        case 3:
                            {
                                // works
                                // Negative
                                LocalHealth.SetField<bool>("wasAlive", false);
                                break;
                            }
                        case 4:
                            {
                                // works
                                // Revive
                                LocalHealth.SetField<bool>("wasAlive", false);
                                int itemELCount = LocalPlayerInv.GetItemCount(ItemIndex.ExtraLife);
                                int itemELCCount = LocalPlayerInv.GetItemCount(ItemIndex.ExtraLifeConsumed);
                                if (LocalHealth.health < 1)
                                {
                                    if (itemELCount == 0)
                                    {
                                        Menus.ItemList.GiveItem(ItemIndex.ExtraLife);
                                        LocalHealth.SetField<bool>("wasAlive", true);
                                    }
                                }
                                if (itemELCCount > 0)
                                {
                                    LocalPlayerInv.RemoveItem(ItemIndex.ExtraLifeConsumed, itemELCCount);
                                }
                                if (itemELCount > 0)
                                {
                                    LocalPlayerInv.RemoveItem(ItemIndex.ExtraLifeConsumed, itemELCount);
                                }
                                break;
                            }


                        default:
                            break;
                    }
                }
                else
                {
                    switch (GodVersion)
                    {
                        case 0:
                            {
                                LocalHealth.godMode = false;
                                break;
                            }

                        case 1:
                            {
                                LocalHealth.barrier = 0;
                                break;
                            }

                        case 3:
                            {
                                if (LocalHealth.health < 0)
                                {
                                    LocalHealth.health = 1;
                                }
                                LocalHealth.SetField<bool>("wasAlive", true);
                                break;
                            }

                        case 4:
                            {
                                if (LocalHealth.health < 0)
                                {
                                    LocalHealth.health = 1;
                                }
                                LocalHealth.SetField<bool>("wasAlive", true);
                                int itemELCount = LocalPlayerInv.GetItemCount(ItemIndex.ExtraLife);
                                int itemELCCount = LocalPlayerInv.GetItemCount(ItemIndex.ExtraLifeConsumed);
                                if (itemELCCount > 0)
                                {
                                    LocalPlayerInv.RemoveItem(ItemIndex.ExtraLifeConsumed, itemELCCount);
                                }
                                if (itemELCount > 0)
                                {
                                    LocalPlayerInv.RemoveItem(ItemIndex.ExtraLifeConsumed, itemELCount);
                                }
                                break;
                            }

                        default:
                            break;
                    }
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

            Keybinds();
        }

        private void Keybinds()
        {
            #region Main Menu Keybind
            if (Input.GetKeyDown(OpenMainMenuKeybind))
            {
                if (InGameCheck())
                {
                    Utility.FindButtonById(0, 8).SetEnabled(false);
                }

                if (mainMenu.IsEnabled() && navigationToggle && AllowNavigation)
                {
                    Utility.CloseOpenMenus();
                }
                mainMenu.ToggleMenu();
                GetCharacter();
            }
            #endregion

            if (!chatOpen && InGameCheck())
            {
                #region Player Menu Keybinds
                if (Input.GetKeyDown(OpenPlayerMenuKeybind))
                {
                    playerMenu.ToggleMenu();
                    if (navigationToggle && AllowNavigation)
                    {
                        Navigation.menuIndex = 1;
                    }
                }

                if (Input.GetKeyDown(GiveMoneyKeybind))
                {
                    Menus.Player.GiveMoney();
                }

                if (Input.GetKeyDown(GiveCoinKeybind))
                {
                    Menus.Player.GiveLunarCoins();
                }

                if (Input.GetKeyDown(GiveExpKeybind))
                {
                    Menus.Player.GiveXP();
                }

                if (Input.GetKeyDown(OpenStatsModKeybind))
                {
                    statsModMenu.ToggleMenu();
                    if (navigationToggle && AllowNavigation)
                    {
                        Navigation.menuIndex = 8;
                    }
                }

                if (Input.GetKeyDown(OpenViewStatsKeybind))
                {
                    viewStatsMenu.ToggleMenu();
                }

                if (Input.GetKeyDown(OpenChangeCharacterListKeybind))
                {
                    characterListMenu.ToggleMenu();
                    if (navigationToggle && AllowNavigation)
                    {
                        Navigation.menuIndex = 10;
                    }
                }

                if (Input.GetKeyDown(OpenBuffListKeybind))
                {
                    buffListMenu.ToggleMenu();
                    if (navigationToggle && AllowNavigation)
                    {
                        Navigation.menuIndex = 11;
                    }
                }

                if (Input.GetKeyDown(RemoveAllBuffsKeybind))
                {
                    Utility.FindButtonById(1, 7).GetAction().Invoke();
                }

                if (Input.GetKeyDown(AimbotKeybind))
                {
                    Menus.Player.AimBotToggle = !Menus.Player.AimBotToggle;
                    Utility.FindButtonById(1, 8).SetEnabled(Menus.Player.AimBotToggle);
                }

                if (Input.GetKeyDown(GodModeKeybind))
                {
                    Menus.Player.GodToggle = !Menus.Player.GodToggle;
                    Utility.FindButtonById(1, 9).SetEnabled(Menus.Player.GodToggle);
                }

                if (Input.GetKeyDown(InfiniteSkillsKeybind))
                {
                    Menus.Player.SkillToggle = !Menus.Player.SkillToggle;
                    Utility.FindButtonById(1, 10).SetEnabled(Menus.Player.SkillToggle);
                }
                #endregion

                #region Movement Menu Keybinds
                if (Input.GetKeyDown(OpenMovementMenuKeybind))
                {
                    movementMenu.ToggleMenu();
                    if (navigationToggle && AllowNavigation)
                    {
                        Navigation.menuIndex = 2;
                    }
                }

                if (Input.GetKeyDown(AlwaysSprintKeybind))
                {
                    Menus.Movement.alwaysSprintToggle = !Menus.Movement.alwaysSprintToggle;
                    Utility.FindButtonById(2, 1).SetEnabled(Menus.Movement.alwaysSprintToggle);
                }

                if (Input.GetKeyDown(FlightKeybind))
                {
                    Menus.Movement.flightToggle = !Menus.Movement.flightToggle;
                    Utility.FindButtonById(2, 2).SetEnabled(Menus.Movement.flightToggle);
                }

                if (Input.GetKeyDown(JumpPackKeybind))
                {
                    Menus.Movement.jumpPackToggle = !Menus.Movement.jumpPackToggle;
                    Utility.FindButtonById(2, 3).SetEnabled(Menus.Movement.jumpPackToggle);
                }
                #endregion

                #region Item Menu Keybinds
                if (Input.GetKeyDown(OpenItemsMenuKeybind))
                {
                    itemsMenu.ToggleMenu();
                    if (navigationToggle && AllowNavigation)
                    {
                        Navigation.menuIndex = 3;
                    }
                }

                if (Input.GetKeyDown(GiveAllKeybind))
                {
                    Utility.FindButtonById(3, 1).GetAction().Invoke();
                }

                if (Input.GetKeyDown(RollItemsKeybind))
                {
                    Utility.FindButtonById(3, 2).GetAction().Invoke();
                }

                if (Input.GetKeyDown(OpenItemsListMenuKeybind))
                {
                    itemListMenu.ToggleMenu();
                    if (navigationToggle && AllowNavigation)
                    {
                        Navigation.menuIndex = 12;
                    }
                }

                if (Input.GetKeyDown(OpenEquipmentListMenuKeybind))
                {
                    equipmentListMenu.ToggleMenu();
                    if (navigationToggle && AllowNavigation)
                    {
                        Navigation.menuIndex = 13;
                    }
                }

                if (Input.GetKeyDown(DropItemsKeybind))
                {
                    Menus.Items.isDropItemForAll = !Menus.Items.isDropItemForAll;
                    Utility.FindButtonById(3, 5).SetEnabled(Menus.Items.isDropItemForAll);
                }

                if (Input.GetKeyDown(DropInvItemsKeybind))
                {
                    Menus.Items.isDropItemFromInventory = !Menus.Items.isDropItemFromInventory;
                    Utility.FindButtonById(3, 6).SetEnabled(Menus.Items.isDropItemFromInventory);
                }

                if (Input.GetKeyDown(InfiniteEquipmentKeybind))
                {
                    Menus.Items.noEquipmentCD = !Menus.Items.noEquipmentCD;
                    Utility.FindButtonById(3, 7).SetEnabled(Menus.Items.noEquipmentCD);
                }

                if (Input.GetKeyDown(StackInvKeybind))
                {
                    Utility.FindButtonById(3, 8).GetAction().Invoke();
                }

                if (Input.GetKeyDown(ClearInvKeybind))
                {
                    Utility.FindButtonById(3, 9).GetAction().Invoke();
                }

                if (Input.GetKeyDown(OpenChestItemListKeybind))
                {
                    chestItemListMenu.ToggleMenu();
                    if (navigationToggle && AllowNavigation)
                    {
                        Navigation.menuIndex = 14;
                    }
                }
                #endregion

                #region Spawn Menu Keybinds
                if (Input.GetKeyDown(OpenSpawnMenuKeybind))
                {
                    spawnMenu.ToggleMenu();
                    if (navigationToggle && AllowNavigation)
                    {
                        Navigation.menuIndex = 4;
                    }
                }

                if (Input.GetKeyDown(OpenSpawnListMenuKeybind))
                {
                    spawnListMenu.ToggleMenu();
                    if (navigationToggle && AllowNavigation)
                    {
                        Navigation.menuIndex = 16;
                    }
                }

                if (Input.GetKeyDown(KillAllKeybind))
                {
                    Utility.FindButtonById(4, 5).GetAction().Invoke();
                }

                if (Input.GetKeyDown(DestroyIntKeybind))
                {
                    Utility.FindButtonById(4, 6).GetAction().Invoke();
                }
                #endregion

                #region Teleport Menu Keybinds 
                if (Input.GetKeyDown(OpenTeleMenuKeybind))
                {
                    teleporterMenu.ToggleMenu();
                    if (navigationToggle && AllowNavigation)
                    {
                        Navigation.menuIndex = 5;
                    }
                }

                if (Input.GetKeyDown(SkipStageKeybind))
                {
                    Utility.FindButtonById(5, 1).GetAction().Invoke();
                }

                if (Input.GetKeyDown(InstantTeleKeybind))
                {
                    Utility.FindButtonById(5, 2).GetAction().Invoke();
                }

                if (Input.GetKeyDown(AddMtnKeybind))
                {
                    Utility.FindButtonById(5, 3).GetAction().Invoke();
                }

                if (Input.GetKeyDown(SpawnAllPortalsKeybind))
                {
                    Utility.FindButtonById(5, 4).GetAction().Invoke();
                }

                if (Input.GetKeyDown(SpawnBlueKeybind))
                {
                    Utility.FindButtonById(5, 5).GetAction().Invoke();
                }

                if (Input.GetKeyDown(SpawnCelKeybind))
                {
                    Utility.FindButtonById(5, 6).GetAction().Invoke();
                }

                if (Input.GetKeyDown(SpawnGoldKeybind))
                {
                    Utility.FindButtonById(5, 7).GetAction().Invoke();
                }
                #endregion

                #region Render Menu Keybinds
                if (Input.GetKeyDown(OpenRenderMenuKeybind))
                {
                    renderMenu.ToggleMenu();
                    if (navigationToggle && AllowNavigation)
                    {
                        Navigation.menuIndex = 6;
                    }
                }

                if (Input.GetKeyDown(RenActiveModsKeybind))
                {
                    Menus.Render.renderMods = !Menus.Render.renderMods;
                    Utility.FindButtonById(6, 1).SetEnabled(Menus.Render.renderMods);
                }

                if (Input.GetKeyDown(RenIntKeybind))
                {
                    Menus.Render.renderInteractables = !Menus.Render.renderInteractables;
                    Utility.FindButtonById(6, 2).SetEnabled(Menus.Render.renderInteractables);
                }

                if (Input.GetKeyDown(RenMobKeybind))
                {
                    Menus.Render.renderMobs = !Menus.Render.renderMobs;
                    Utility.FindButtonById(6, 3).SetEnabled(Menus.Render.renderMobs);
                }
                #endregion
            }
        }
        #endregion Inputs
    }
}
