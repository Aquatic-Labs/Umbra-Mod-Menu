// TODO:
//     Somehow link buttons/menus to their toggles so if the menu closes, the toggle is updated or if a toggle is enabled by default, so is the button
//     Make it so only 1 drop item toggle can be enabled at a time
//     Implement Settings Menu
//     Add LowResolution support
//     Add Navigation
//     Move Interfaces to their own files
//     remove unused code
//     Implement enhancements and bug fixes from github issues.

using System;
using System.Collections.Generic;
using UnityEngine;
using RoR2;
using UnityEngine.SceneManagement;
using System.Linq;
using Octokit;

namespace UmbraMenu
{
    // MOVE THESE TO SEPARATE FILES
    public interface IButton
    {
        bool Enabled { get; set; }
        string Text { get; set; }
        string OnText { get; set; }
        string OffText { get; set; }
        int Position { get; set; }
        void Draw(); 
    };
    public interface IMenu
    {
        int Id { get; set; }
        int NumberOfButtons { get; set; }
        bool Enabled { get; set; }
        bool IfDragged { get; set; }
        float WidthSize { get; set; }
        Button ActivatingButton { get; set; }
        List<Button> Buttons { get; set; }
        Rect Rect { get; set; }
        string Title { get; set; }
        void SetWindow();
        void Draw(); 
    }

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

        public static List<string> unlockableNames = Utility.GetAllUnlockables();
        public static List<GameObject> bodyPrefabs = Utility.GetBodyPrefabs();
        public static List<EquipmentIndex> equipment = Utility.GetEquipment();
        public static List<ItemIndex> items = Utility.GetItems();
        public static List<SpawnCard> spawnCards = Utility.GetSpawnCards();

        public static bool characterCollected, navigationToggle, devDoOnce = true, lowResolutionMonitor;

        public static Scene currentScene;

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
                /*
                #region Main Menus

                #region settings Menu
                BuildMenus.BuildMenu(settings, MenuButtons.Main.toggleSettings, MenuButtons.Settings.AddButtonsToMenu);
                #endregion

                #endregion

                #region Sub Menus

                #region Spawn List Menu
                BuildMenus.BuildMenu(spawnList, MenuButtons.Spawn.toggleSpawnListMenu, MenuButtons.SpawnList.AddButtonsToMenu);
                #endregion

                #endregion
                */

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
                // SceneManager.sceneLoaded += OnSceneLoaded;

                #region Old Build Menus

                /*#region Settings Menu
                settings.Rect = new Rect(374, 750, 20, 20); // Start Position
                settings.Title = "S E T T I N G S   M E N U";
                settings.Id = 7;
                menus.Add(settings);
                #endregion

                #endregion

                #region Sub Menus

                #region Spawn List Menu
                spawnList.Rect = new Rect(1503, 10, 20, 20); // Start Position
                spawnList.Title = "S P A W N   C A R D S   M E N U";
                spawnList.Id = 15;
                menus.Add(spawnList);
                #endregion*/

                #endregion

                #region Resolution Check
                if (Screen.height > 1080)
                {
                }
                else if (Screen.height < 1080)
                {
                    lowResolutionMonitor = true;

                    mainMenu.SetRect(new Rect(10, 10, 20, 20)); // Start Position
                    /*
                    player.Rect = new Rect(374, 10, 20, 20); // Start Position
                    movement.Rect = new Rect(374, 10, 20, 20); // Start Position
                    item.Rect = new Rect(374, 10, 20, 20); // Start Position
                    spawn.Rect = new Rect(374, 10, 20, 20); // Start Position
                    teleporter.Rect = new Rect(374, 10, 20, 20); // Start Position
                    render.Rect = new Rect(374, 10, 20, 20); // Start Position
                    settings.Rect = new Rect(374, 10, 20, 20); // Start Position

                    statsMod.Rect = new Rect(374, 10, 20, 20); // Start Position
                    viewStats.Rect = new Rect(374, 10, 20, 20); // Start Position
                    characterList.Rect = new Rect(374, 10, 20, 20); // Start Position
                    buffList.Rect = new Rect(374, 10, 20, 20); // Start Position
                    itemList.Rect = new Rect(374, 10, 20, 20); // Start Position
                    equipmentList.Rect = new Rect(374, 10, 20, 20); // Start Position
                    chestItemList.Rect = new Rect(374, 10, 20, 20); // Start Position
                    spawnList.Rect = new Rect(374, 10, 20, 20); // Start Position*/
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
                // LowResolutionRoutine();
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

                // UpdateNavIndexRoutine();
                // UpdateMenuPositions();
                Menus.ViewStats.UpdateViewStats();
            }
            catch (Exception e)
            {
                Debug.Log($"Update threw exception: {e}");
            }
        }

        public void FixedUpdate()
        {
            currentScene = SceneManager.GetActiveScene();
            if (Menus.Render.renderMobs)
            {
                Menus.Render.hurtBoxes = Utility.GetHurtBoxes();
            }
            if (Menus.Items.chestItemList)
            {
                Menus.ChestItemList.IsClosestChestEquip = Menus.ChestItemList.CheckClosestChestEquip();
            }
        }

        private void CheckInputs()
        {
            if (Input.GetKeyDown(KeyCode.Insert))
            {
                mainMenu.ToggleMenu();
                GetCharacter();
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

        public void OnSceneLoaded(Scene scene, LoadSceneMode mode)
        {
            if (!InGameCheck())
            {
                Utility.ResetMenu();
            }
            else
            {
                ModStatsRoutine();
                Utility.SoftResetMenu();
            }
        }

        private void LowResolutionMonitor()
        {
            var menusOpen = Utility.GetMenusOpen();
            if (menusOpen.Count > 1)
            {
                menusOpen[0].SetEnabled(false);
            }
        }

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
            if (prevCharCollected != characterCollected)
            {
                mainMenu = new Menus.Main();
                playerMenu = new Menus.Player();
                movementMenu = new Menus.Movement();
                itemsMenu = new Menus.Items();
                spawnMenu = new Menus.Spawn();
                teleporterMenu = new Menus.Teleporter();
                renderMenu = new Menus.Render();

                statsModMenu = new Menus.StatsMod();
                viewStatsMenu = new Menus.ViewStats();
                characterListMenu = new Menus.CharacterList();
                buffListMenu = new Menus.BuffList();
                
                itemListMenu = new Menus.ItemList();
                equipmentListMenu = new Menus.EquipmentList();
                chestItemListMenu = new Menus.ChestItemList();

                spawnListMenu = new Menus.SpawnList();

                menus = new List<Menu>()
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
            }
        }

        /*private void LowResolutionRoutine()
        {
            if (lowResolutionMonitor)
            {
                Utility.MenusOpenKeys();
                LowResolutionMonitor();
            }
        }*/

        private void DevBuildRoutine()
        {
            if (Loader.devBuild)
            {
                if (characterCollected)
                {
                    if (devDoOnce)
                    {
                        Menus.Player.GodToggle = true;
                        Menus.Movement.flightToggle = true;
                        Menus.Movement.alwaysSprintToggle = true;
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

        /*
        private void UpdateNavIndexRoutine()
        {
            if (navigationToggle)
            {
                Navigation.UpdateIndexValues();
            }
        }*/

        /*private void UpdateMenusAndButtonsRoutine()
        {
            for (int i = 1; i < Menu.menus.Count; i++)
            {
                if (Menu.menus[i].enabled)
                {
                    Menu.menus[i].activatingButton.Enabled = true;
                }
                else
                {
                    Menu.menus[i].activatingButton.Enabled = false;

                }
            }
        }
        */

        #endregion
    }
}
