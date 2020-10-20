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

namespace UmbraMenu
{
    public interface Buttons { void Add(); };
    public interface Menus 
    { 
        Rect rect { get; }
        List<Buttons> buttons { get; }
        TogglableButton activatingButton { get; }
        bool enabled { get; set; }
        bool ifDragged { get; set; }
        int id { get; }
        void SetWindow(); 
        void DrawMenu(); 
        void DrawAllButtons();
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

        public static List<Menus> menus = new List<Menus>();
        public static bool characterCollected, navigationToggle, devDoOnce = true, lowResolutionMonitor;

        public static Scene currentScene;

        #region Create Main Menus
        public Menu main = new Menu();
        public Menu player = new Menu();
        public Menu movement = new Menu();
        public Menu item = new Menu();
        public Menu spawn = new Menu();
        public Menu teleporter = new Menu();
        public Menu render = new Menu();
        public Menu settings = new Menu();
        #endregion

        #region Create Sub Menus
        public Menu statsMod = new Menu();
        public Menu viewStats = new Menu();
        public ListMenu characterList = new ListMenu();
        public ListMenu buffList = new ListMenu();
        public ListMenu itemList = new ListMenu();
        public ListMenu equipmentList = new ListMenu();
        public ListMenu chestItemList = new ListMenu();
        public ListMenu spawnList = new ListMenu();
        #endregion


        private void OnGUI()
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

            #region Main Menus

            #region Main Menu
            if (Loader.updateAvailable)
            {
                main.menuTitle = $"U M B R A \n<color=yellow>O U T D A T E D</color>";
            }
            else if (Loader.upToDate)
            {
                main.menuTitle = $"U M B R A \n<color=grey>v{VERSION}</color>";
            }
            else if (Loader.devBuild)
            {
                main.menuTitle = $"U M B R A \n<color=yellow>D E V</color>";
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

            ESPRoutine();
            UpdateMenusAndButtonsRoutine();
        }

        public void Start()
        {
            Styles styles = new Styles();
            styles.BuildStyles();

            SceneManager.sceneLoaded += OnSceneLoaded;

            #region Main Menus

            #region Main Menu
            main.rect = new Rect(10, 10, 20, 20); // Start Position
            main.menuTitle = $"U M B R A \n<color=grey>v{VERSION}</color>";
            main.id = 0;
            menus.Add(main);
            #endregion

            #region Player Menu
            player.rect = new Rect(374, 10, 20, 20); // Start Position
            player.menuTitle = "P L A Y E R   M E N U";
            player.id = 1;
            menus.Add(player);
            #endregion

            #region Movement Menu
            movement.rect = new Rect(374, 560, 20, 20); // Start Position
            movement.menuTitle = "M O V E M E N T   M E N U";
            movement.id = 2;
            menus.Add(movement);
            #endregion

            #region Items Menu
            item.rect = new Rect(738, 10, 20, 20); // Start Position
            item.menuTitle = "I T E M S   M E N U";
            item.id = 3;
            menus.Add(item);
            #endregion

            #region Spawn Menu
            spawn.rect = new Rect(738, 515, 20, 20); // Start Position
            spawn.menuTitle = "S P A W N   M E N U";
            spawn.id = 4;
            menus.Add(spawn);
            #endregion

            #region Teleporter Menu
            teleporter.rect = new Rect(10, 425, 20, 20); // Start Position
            teleporter.menuTitle = "T E L E P O R T E R   M E N U";
            teleporter.id = 5;
            menus.Add(teleporter);
            #endregion

            #region Render Menu
            render.rect = new Rect(10, 795, 20, 20); // Start Position
            render.menuTitle = "R E N D E R   M E N U";
            render.id = 6;
            menus.Add(render);
            #endregion

            #region Settings Menu
            settings.rect = new Rect(374, 750, 20, 20); // Start Position
            settings.menuTitle = "S E T T I N G S   M E N U";
            settings.id = 7;
            menus.Add(settings);
            #endregion

            #endregion

            #region Sub Menus

            #region Stats Modification Menu
            statsMod.rect = new Rect(1503, 10, 20, 20); // Start Position
            statsMod.menuTitle = "S T A T S   M O D   M E N U";
            statsMod.id = 8;
            menus.Add(statsMod);
            #endregion

            #region View Stats Menu
            viewStats.rect = new Rect(1626, 457, 20, 20); // Start Position
            viewStats.menuTitle = "V I E W   S T A T S   M E N U";
            viewStats.id = 9;
            menus.Add(viewStats);
            #endregion

            #region Character List Menu
            characterList.rect = new Rect(1503, 10, 20, 20); // Start Position
            characterList.menuTitle = "C H A R A C T E R S   M E N U";
            characterList.id = 10;
            menus.Add(characterList);
            #endregion

            #region Buff List Menu
            buffList.rect = new Rect(1503, 10, 20, 20); // Start Position
            buffList.menuTitle = "B U F F S   M E N U";
            buffList.id = 11;
            menus.Add(buffList);
            #endregion

            #region Item List Menu
            itemList.rect = new Rect(1503, 10, 20, 20); // Start Position
            itemList.menuTitle = "I T E M S   M E N U";
            itemList.id = 12;
            menus.Add(itemList);
            #endregion

            #region Equipment List Menu
            equipmentList.rect = new Rect(1503, 10, 20, 20); // Start Position
            equipmentList.menuTitle = "E Q U I P M E N T   M E N U";
            equipmentList.id = 13;
            menus.Add(equipmentList);
            #endregion

            #region Chest Items List Menu
            chestItemList.rect = new Rect(1503, 10, 20, 20); // Start Position
            chestItemList.menuTitle = "C H E S T   I T E M S   M E N U";
            chestItemList.id = 14;
            menus.Add(chestItemList);
            #endregion

            #region Spawn List Menu
            spawnList.rect = new Rect(1503, 10, 20, 20); // Start Position
            spawnList.menuTitle = "S P A W N   C A R D S   M E N U";
            spawnList.id = 15;
            menus.Add(spawnList);
            #endregion

            #endregion

            #region Resolution Check
            if (Screen.height > 1080)
            {
            }
            else if (Screen.height < 1080)
            {
                lowResolutionMonitor = true;

                main.rect = new Rect(10, 10, 20, 20); // Start Position
                player.rect = new Rect(374, 10, 20, 20); // Start Position
                movement.rect = new Rect(374, 10, 20, 20); // Start Position
                item.rect = new Rect(374, 10, 20, 20); // Start Position
                spawn.rect = new Rect(374, 10, 20, 20); // Start Position
                teleporter.rect = new Rect(374, 10, 20, 20); // Start Position
                render.rect = new Rect(374, 10, 20, 20); // Start Position
                settings.rect = new Rect(374, 10, 20, 20); // Start Position

                statsMod.rect = new Rect(374, 10, 20, 20); // Start Position
                viewStats.rect = new Rect(374, 10, 20, 20); // Start Position
                characterList.rect = new Rect(374, 10, 20, 20); // Start Position
                buffList.rect = new Rect(374, 10, 20, 20); // Start Position
                itemList.rect = new Rect(374, 10, 20, 20); // Start Position
                equipmentList.rect = new Rect(374, 10, 20, 20); // Start Position
                chestItemList.rect = new Rect(374, 10, 20, 20); // Start Position
                spawnList.rect = new Rect(374, 10, 20, 20); // Start Position
            }
            #endregion
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

                //UpdateNavIndexRoutine();
                //UpdateMenuPositions();
                MenuButtons.ViewStats.UpdateViewStats();
            }
            catch (NullReferenceException)
            {
                Debug.Log("Update is throwing an NRE");
            }
        }

        public void FixedUpdate()
        {
            currentScene = SceneManager.GetActiveScene();
            if (MenuButtons.Render.toggleMobESP.Enabled)
            {
                MenuButtons.Render.hurtBoxes = Utility.GetHurtBoxes();
            }
        }

        private void CheckInputs()
        {
            if (Input.GetKeyDown(KeyCode.Insert))
            {
                main.enabled = !main.enabled;
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
                menusOpen[0].enabled = false;
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
            GetCharacter();
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
                        MenuButtons.Player.toggleGod.Enabled = true;
                        MenuButtons.Movement.toggleFlight.Enabled = true;
                        MenuButtons.Movement.toggleAlwaysSprint.Enabled = true;
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
                if (MenuButtons.Render.toggleInteractESP.Enabled)
                {
                    MenuButtons.Render.Interactables();
                    MenuButtons.Render.renderInteractables = true;
                }
                else
                {
                    MenuButtons.Render.renderInteractables = false;
                }

                if (MenuButtons.Render.toggleMobESP.Enabled)
                {
                    MenuButtons.Render.Mobs();
                    MenuButtons.Render.renderMobs = true;
                }
                else
                {
                    MenuButtons.Render.renderMobs = false;
                }

                if (MenuButtons.Render.toggleActiveMods.Enabled)
                {
                    MenuButtons.Render.ActiveMods();
                    MenuButtons.Render.renderMods = true;
                }
                else
                {
                    MenuButtons.Render.renderMods = false;
                }

                if (chestItemList.enabled)
                {
                    MenuButtons.ChestItemList.RenderClosestChest();
                }
            }
        }

        private void EquipCooldownRoutine()
        {
            if (MenuButtons.Items.toggleEquipmentCD.Enabled)
            {
                MenuButtons.Items.NoEquipmentCooldown();
                MenuButtons.Items.noEquipmentCD = true;
            }
            else
            {
                MenuButtons.Items.noEquipmentCD = false;
            }
        }

        private void SkillsRoutine()
        {
            if (characterCollected)
            {
                if (MenuButtons.Player.toggleSkillCD.Enabled)
                {
                    LocalSkills.ApplyAmmoPack();
                    MenuButtons.Player.skillToggle = true;
                }
                else
                {
                    MenuButtons.Player.skillToggle = false;
                }
            }
        }

        private void AimBotRoutine()
        {
            if (MenuButtons.Player.toggleAimbot.Enabled)
            {
                MenuButtons.Player.AimBot();
                MenuButtons.Player.aimBotToggle = true;
            }
            else
            {
                MenuButtons.Player.aimBotToggle = false;
            }
        }

        private void GodRoutine()
        {
            if (characterCollected)
            {
                if (MenuButtons.Player.toggleGod.Enabled)
                {
                    MenuButtons.Player.GodMode();
                    MenuButtons.Player.godToggle = true;
                }
                else
                {
                    LocalHealth.godMode = false;
                    MenuButtons.Player.godToggle = false;
                }
            }
        }

        private void SprintRoutine()
        {
            if (MenuButtons.Movement.toggleAlwaysSprint.Enabled)
            {
                MenuButtons.Movement.AlwaysSprint();
                MenuButtons.Movement.alwaysSprintToggle = true;
            }
            else
            {
                MenuButtons.Movement.alwaysSprintToggle = false;
            }
        }

        private void FlightRoutine()
        {
            if (MenuButtons.Movement.toggleFlight.Enabled)
            {
                MenuButtons.Movement.Flight();
                MenuButtons.Movement.flightToggle = true;
            }
            else
            {
                MenuButtons.Movement.flightToggle = false;
            }
        }

        private void ModStatsRoutine()
        {
            if (characterCollected)
            {
                if (MenuButtons.StatsMod.changeDmgPerLevel.Enabled)
                {
                    MenuButtons.StatsMod.LevelPlayersDamage();
                }
                if (MenuButtons.StatsMod.changeCritPerLevel.Enabled)
                {
                    MenuButtons.StatsMod.LevelPlayersCrit();
                }
                if (MenuButtons.StatsMod.changeAttackSpeed.Enabled)
                {
                    MenuButtons.StatsMod.SetplayersAttackSpeed();
                }
                if (MenuButtons.StatsMod.changeArmor.Enabled)
                {
                    MenuButtons.StatsMod.SetplayersArmor();
                }
                if (MenuButtons.StatsMod.changeMoveSpeed.Enabled)
                {
                    MenuButtons.StatsMod.SetplayersMoveSpeed();
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

        private void JumpPackRoutine()
        {
            if (MenuButtons.Movement.toggleJumpPack.Enabled)
            {
                MenuButtons.Movement.JumpPack();
                MenuButtons.Movement.jumpPackToggle = true;
            }
            else
            {
                MenuButtons.Movement.jumpPackToggle = false;
            }
        }

        private void UpdateMenusAndButtonsRoutine()
        {
            for (int i = 1; i < menus.Count; i++)
            {
                if (menus[i].enabled)
                {
                    menus[i].activatingButton.Enabled = true;
                }
                else
                {
                    menus[i].activatingButton.Enabled = false;

                }
            }
        }

        #endregion
    }
}
