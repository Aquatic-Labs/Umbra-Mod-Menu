// TODO:
//     Add Settings Menu
//     Add Navigation
//     Possibly add OnEnable action for Menu/ListMenu type

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
        void Draw(); 
    };
    public interface IMenu
    {
        int Id { get; set; }
        int NumberOfButtons { get; set; }
        bool Enabled { get; set; }
        bool IfDragged { get; set; }

        float WidthSize { get; set; }
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

        public static List<Menu> menus = new List<Menu>()
        {
            mainMenu,
            playerMenu,
            movementMenu,
            itemsMenu,
            spawnMenu,
            teleporterMenu
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

                mainMenu.Draw();
                playerMenu.Draw();
                movementMenu.Draw();
                itemsMenu.Draw();
                spawnMenu.Draw();
                teleporterMenu.Draw();
                /*
                #region Main Menus

                #region Main Menu
                if (Loader.updateAvailable)
                {
                    main.Title = $"U M B R A \n<color=yellow>O U T D A T E D</color>";
                }
                else if (Loader.upToDate)
                {
                    main.Title = $"U M B R A \n<color=grey>v{VERSION}</color>";
                }
                else if (Loader.devBuild)
                {
                    main.Title = $"U M B R A \n<color=yellow>D E V</color>";
                }
                MenuButtons.Main.AddButtonsToMenu();
                main.SetWindow();
                BuildMenus.BuildMainMenu(main);
                #endregion

                #region Player Menu
                BuildMenus.BuildMenu(player, MenuButtons.Main.togglePlayer, MenuButtons.Player.AddButtonsToMenu);
                #endregion

                #region Movement Menu
                BuildMenus.BuildMenu(movement, MenuButtons.Main.toggleMovement, MenuButtons.Movement.AddButtonsToMenu);
                #endregion

                #region Item Menu
                BuildMenus.BuildMenu(item, MenuButtons.Main.toggleItems, MenuButtons.Items.AddButtonsToMenu);
                #endregion

                #region Spawn Menu
                BuildMenus.BuildMenu(spawn, MenuButtons.Main.toggleSpawn, MenuButtons.Spawn.AddButtonsToMenu);
                #endregion

                #region Teleporter Menu
                BuildMenus.BuildMenu(teleporter, MenuButtons.Main.toggleTeleporter, MenuButtons.Teleporter.AddButtonsToMenu);
                #endregion

                #region Render Menu
                BuildMenus.BuildMenu(render, MenuButtons.Main.toggleRender, MenuButtons.Render.AddButtonsToMenu);
                #endregion

                #region settings Menu
                BuildMenus.BuildMenu(settings, MenuButtons.Main.toggleSettings, MenuButtons.Settings.AddButtonsToMenu);
                #endregion

                #endregion

                #region Sub Menus

                #region Stats Modification Menu
                BuildMenus.BuildMenu(statsMod, MenuButtons.Player.toggleStatsMod, MenuButtons.StatsMod.AddButtonsToMenu);
                #endregion

                #region View Stats Menu
                BuildMenus.BuildMenu(viewStats, MenuButtons.StatsMod.toggleViewStatsMenu, MenuButtons.ViewStats.AddTextToMenu);
                #endregion

                #region Character List Menu
                BuildMenus.BuildMenu(characterList, MenuButtons.Player.toggleChangeCharacter, MenuButtons.CharacterList.AddButtonsToMenu);
                #endregion

                #region Buff List Menu
                BuildMenus.BuildMenu(buffList, MenuButtons.Player.toggleBuff, MenuButtons.BuffList.AddButtonsToMenu);
                #endregion

                #region Item List Menu
                BuildMenus.BuildMenu(itemList, MenuButtons.Items.toggleItemListMenu, MenuButtons.ItemList.AddButtonsToMenu);
                #endregion

                #region Equipment List Menu
                BuildMenus.BuildMenu(equipmentList, MenuButtons.Items.toggleEquipmentListMenu, MenuButtons.EquipmentList.AddButtonsToMenu);
                #endregion

                #region Chest Items List Menu
                BuildMenus.BuildMenu(chestItemList, MenuButtons.Items.toggleChestItemMenu, MenuButtons.ChestItemList.AddButtonsToMenu);
                #endregion

                #region Spawn List Menu
                BuildMenus.BuildMenu(spawnList, MenuButtons.Spawn.toggleSpawnListMenu, MenuButtons.SpawnList.AddButtonsToMenu);
                #endregion

                #endregion
                */

                // ESPRoutine();
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

                /*#region Main Menu
                main.Rect = new Rect(10, 10, 20, 20); // Start Position
                main.Title = $"U M B R A \n<color=grey>v{VERSION}</color>";
                main.Id = 0;
                menus.Add(main);
                #endregion

                #region Player Menu
                player.Rect = new Rect(374, 10, 20, 20); // Start Position
                player.Title = "P L A Y E R   M E N U";
                player.Id = 1;
                menus.Add(player);
                #endregion

                #region Movement Menu
                movement.Rect = new Rect(374, 560, 20, 20); // Start Position
                movement.Title = "M O V E M E N T   M E N U";
                movement.Id = 2;
                menus.Add(movement);
                #endregion

                #region Items Menu
                item.Rect = new Rect(738, 10, 20, 20); // Start Position
                item.Title = "I T E M S   M E N U";
                item.Id = 3;
                menus.Add(item);
                #endregion

                #region Spawn Menu
                spawn.Rect = new Rect(738, 515, 20, 20); // Start Position
                spawn.Title = "S P A W N   M E N U";
                spawn.Id = 4;
                menus.Add(spawn);
                #endregion

                #region Teleporter Menu
                teleporter.Rect = new Rect(10, 425, 20, 20); // Start Position
                teleporter.Title = "T E L E P O R T E R   M E N U";
                teleporter.Id = 5;
                menus.Add(teleporter);
                #endregion

                #region Render Menu
                render.Rect = new Rect(10, 795, 20, 20); // Start Position
                render.Title = "R E N D E R   M E N U";
                render.Id = 6;
                menus.Add(render);
                #endregion

                #region Settings Menu
                settings.Rect = new Rect(374, 750, 20, 20); // Start Position
                settings.Title = "S E T T I N G S   M E N U";
                settings.Id = 7;
                menus.Add(settings);
                #endregion

                #endregion

                #region Sub Menus

                #region Stats Modification Menu
                statsMod.Rect = new Rect(1503, 10, 20, 20); // Start Position
                statsMod.Title = "S T A T S   M O D   M E N U";
                statsMod.Id = 8;
                menus.Add(statsMod);
                #endregion

                #region View Stats Menu
                viewStats.Rect = new Rect(1626, 457, 20, 20); // Start Position
                viewStats.Title = "V I E W   S T A T S   M E N U";
                viewStats.Id = 9;
                menus.Add(viewStats);
                #endregion

                #region Character List Menu
                characterList.Rect = new Rect(1503, 10, 20, 20); // Start Position
                characterList.Title = "C H A R A C T E R S   M E N U";
                characterList.Id = 10;
                menus.Add(characterList);
                #endregion

                #region Buff List Menu
                buffList.Rect = new Rect(1503, 10, 20, 20); // Start Position
                buffList.Title = "B U F F S   M E N U";
                buffList.Id = 11;
                menus.Add(buffList);
                #endregion

                #region Item List Menu
                itemList.Rect = new Rect(1503, 10, 20, 20); // Start Position
                itemList.Title = "I T E M S   M E N U";
                itemList.Id = 12;
                menus.Add(itemList);
                #endregion

                #region Equipment List Menu
                equipmentList.Rect = new Rect(1503, 10, 20, 20); // Start Position
                equipmentList.Title = "E Q U I P M E N T   M E N U";
                equipmentList.Id = 13;
                menus.Add(equipmentList);
                #endregion

                #region Chest Items List Menu
                chestItemList.Rect = new Rect(1503, 10, 20, 20); // Start Position
                chestItemList.Title = "C H E S T   I T E M S   M E N U";
                chestItemList.Id = 14;
                menus.Add(chestItemList);
                #endregion

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
                // MenuButtons.ViewStats.UpdateViewStats();
            }
            catch (Exception e)
            {
                Debug.Log($"Update threw exception: {e}");
            }
        }

        public void FixedUpdate()
        {
            currentScene = SceneManager.GetActiveScene();
            if (Menus.Render.toggleMobESP.Enabled)
            {
                Menus.Render.hurtBoxes = Utility.GetHurtBoxes();
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

                menus = new List<Menu>()
                {
                    mainMenu,
                    playerMenu,
                    movementMenu,
                    itemsMenu,
                    spawnMenu,
                    teleporterMenu
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
                if (Menus.Render.toggleInteractESP.Enabled)
                {
                    Menus.Render.Interactables();
                    Menus.Render.renderInteractables = true;
                }
                else
                {
                    Menus.Render.renderInteractables = false;
                }

                if (Menus.Render.toggleMobESP.Enabled)
                {
                    Menus.Render.Mobs();
                    Menus.Render.renderMobs = true;
                }
                else
                {
                    Menus.Render.renderMobs = false;
                }

                if (Menus.Render.toggleActiveMods.Enabled)
                {
                    Menus.Render.ActiveMods();
                    Menus.Render.renderMods = true;
                }
                else
                {
                    Menus.Render.renderMods = false;
                }

                /*if (chestItemList.Enabled)
                {
                    MenuButtons.ChestItemList.RenderClosestChest();
                }*/
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
                if (Menus.StatsMod.changeDmgPerLevel.Enabled)
                {
                    Menus.StatsMod.LevelPlayersDamage();
                }
                if (Menus.StatsMod.changeCritPerLevel.Enabled)
                {
                    Menus.StatsMod.LevelPlayersCrit();
                }
                if (Menus.StatsMod.changeAttackSpeed.Enabled)
                {
                    Menus.StatsMod.SetplayersAttackSpeed();
                }
                if (Menus.StatsMod.changeArmor.Enabled)
                {
                    Menus.StatsMod.SetplayersArmor();
                }
                if (Menus.StatsMod.changeMoveSpeed.Enabled)
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
