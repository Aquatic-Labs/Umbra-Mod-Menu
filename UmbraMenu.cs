// TODO:
//     Find what is causing NRE in Update
//     Implement Sub-Menus
//     Maybe add AddButtonsToMenu to BuildMenu method

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

        public static List<string> unlockableNames = Utility.GetAllUnlockables();
        public static List<GameObject> bodyPrefabs = Utility.GetBodyPrefabs();
        public static List<EquipmentIndex> equipment = Utility.GetEquipment();
        public static List<ItemIndex> items = Utility.GetItems();
        public static List<SpawnCard> spawnCards = Utility.GetSpawnCards();

        public static List<Menu> menus = new List<Menu>();
        public static List<ListMenu> listMenus = new List<ListMenu>();
        public static bool characterCollected, navigationToggle, devDoOnce = true;

        public static Scene currentScene;

        #region Create Main Menus
        public Menu main = new Menu();
        public Menu player = new Menu();
        public Menu movement = new Menu();
        public Menu item = new Menu();
        public Menu spawn = new Menu();
        public Menu teleporter = new Menu();
        public Menu render = new Menu();
        public Menu lobby = new Menu();
        #endregion
      
        #region Create Sub Menus
        public Menu statsMod = new Menu();
        public Menu viewStats = new Menu();
        public ListMenu characterList = new ListMenu();
        public ListMenu buffList = new ListMenu();
        public ListMenu itemList= new ListMenu();
        public ListMenu equipmentList= new ListMenu();
        public ListMenu chestItemList= new ListMenu();
        public ListMenu spawnList= new ListMenu();
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

            try
            {
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
            }
            catch (NullReferenceException)
            {
                Debug.Log("Main Menu is throwing a NullReferenceException");
            }

            try
            {
                #region Player Menu
                MenuButtons.Player.AddButtonsToMenu();
                BuildMenus.BuildPlayerMenu(player);
                #endregion
            }
            catch (NullReferenceException)
            {
                Debug.Log("Player Menu is throwing a NullReferenceException");
            }

            try
            {
                #region Movement Menu
                MenuButtons.Movement.AddButtonsToMenu();
                BuildMenus.BuildMovementMenu(movement);
                #endregion
            }
            catch (NullReferenceException)
            {
                Debug.Log("Movement Menu is throwing a NullReferenceException");
            }

            try
            {
                #region Item Menu
                MenuButtons.Items.AddButtonsToMenu();
                BuildMenus.BuildItemMenu(item);
                #endregion
            }
            catch (NullReferenceException)
            {
                Debug.Log("Item Menu is throwing a NullReferenceException");
            }

            try
            {
                #region Spawn Menu
                MenuButtons.Spawn.AddButtonsToMenu();
                BuildMenus.BuildSpawnMenu(spawn);
                #endregion
            }
            catch (NullReferenceException)
            {
                Debug.Log("Spawn Menu is throwing a NullReferenceException");
            }

            try
            {
                #region Teleporter Menu
                MenuButtons.Teleporter.AddButtonsToMenu();
                BuildMenus.BuildTeleporterMenu(teleporter);
                #endregion
            }
            catch (NullReferenceException)
            {
                Debug.Log("Teleporter Menu is throwing a NullReferenceException");
            }

            try
            {
                #region Render Menu
                MenuButtons.Render.AddButtonsToMenu();
                BuildMenus.BuildRenderMenu(render);
                #endregion
            }
            catch (NullReferenceException)
            {
                Debug.Log("Render Menu is throwing a NullReferenceException");
            }

            try
            {
                #region Lobby Menu
                MenuButtons.Lobby.AddButtonsToMenu();
                BuildMenus.BuildLobbyMenu(lobby);
                #endregion
            }
            catch (NullReferenceException)
            {
                Debug.Log("Lobby Menu is throwing a NullReferenceException");
            }

            #endregion

            #region Sub Menus

            #region Stats Modification Menu
                MenuButtons.StatsMod.AddButtonsToMenu();
                BuildMenus.BuildStatsModMenu(statsMod);
            #endregion

            #region View Stats Menu
            MenuButtons.ViewStats.AddTextToMenu();
            BuildMenus.BuildViewStatsMenu(viewStats);
            #endregion

            #region Character List Menu
            MenuButtons.CharacterList.AddButtonsToMenu();
            BuildMenus.BuildCharacterListMenu(characterList);
            #endregion

            #region Buff List Menu
            BuildMenus.BuildBuffListMenu(buffList);
            #endregion

            #region Item List Menu
            BuildMenus.BuildItemListMenu(itemList);
            #endregion

            #region Equipment List Menu
            BuildMenus.BuildEquipmentListMenu(equipmentList);
            #endregion

            #region Chest Items List Menu
            BuildMenus.BuildChestItemsListMenu(chestItemList);
            #endregion

            #region Spawn List Menu
            BuildMenus.BuildSpawnListMenu(spawnList);
            #endregion

            #endregion

            ESPRoutine();
            // UpdateButtonsRoutine();
        }

        public void Start()
        {
            Styles styles = new Styles();
            styles.BuildStyles();

            #region Main Menus

            #region Main Menu
            main.rect = new Rect(10, 10, 20, 20); // Start Position
            main.menuTitle = $"U M B R A \n<color=grey>v{VERSION}</color>";
            main.id = 0;
            //MenuButtons.Main.AddButtonsToMenu();
            menus.Add(main);
            #endregion

            #region Player Menu
            player.rect = new Rect(374, 10, 20, 20); // Start Position
            player.menuTitle = "P L A Y E R   M E N U";
            player.id = 1;
            //MenuButtons.Player.AddButtonsToMenu();
            menus.Add(player);
            #endregion

            #region Movement Menu
            movement.rect = new Rect(374, 560, 20, 20); // Start Position
            movement.menuTitle = "M O V E M E N T   M E N U";
            movement.id = 2;
            //MenuButtons.Movement.AddButtonsToMenu();
            menus.Add(movement);
            #endregion

            #region Item Menu
            item.rect = new Rect(738, 10, 20, 20); // Start Position
            item.menuTitle = "I T E M   M E N U";
            item.id = 3;
            //MenuButtons.Items.AddButtonsToMenu();
            menus.Add(item);
            #endregion

            #region Spawn Menu
            spawn.rect = new Rect(738, 515, 20, 20); // Start Position
            spawn.menuTitle = "S P A W N   M E N U";
            spawn.id = 4;
            //MenuButtons.Spawn.AddButtonsToMenu();
            menus.Add(spawn);
            #endregion

            #region Teleporter Menu
            teleporter.rect = new Rect(10, 425, 20, 20); // Start Position
            teleporter.menuTitle = "T E L E P O R T E R   M E N U";
            teleporter.id = 5;
            //MenuButtons.Teleporter.AddButtonsToMenu();
            menus.Add(teleporter);
            #endregion

            #region Render Menu
            render.rect = new Rect(10, 795, 20, 20); // Start Position
            render.menuTitle = "R E N D E R   M E N U";
            render.id = 6;
            //MenuButtons.Render.AddButtonsToMenu();
            menus.Add(render);
            //MenuButtons.Render.toggleActiveMods.Enabled = true;
            #endregion

            #region Lobby Menu
            lobby.rect = new Rect(10, 985, 20, 20); // Start Position
            lobby.menuTitle = "L O B B Y   M E N U";
            lobby.id = 7;
            //MenuButtons.Lobby.AddButtonsToMenu();
            menus.Add(lobby);
            #endregion

            #endregion
            
            #region Sub Menus

            #region Stats Modification Menu
            statsMod.rect = new Rect(10, 985, 20, 20); // Start Position
            statsMod.menuTitle = "S T A T S   M O D   M E N U";
            statsMod.id = 8;
            //statsMod.buttons = MenuButtons.StatsMod.buttons;
            menus.Add(statsMod);
            #endregion

            #region View Stats Menu
            viewStats.rect = new Rect(10, 985, 20, 20); // Start Position
            viewStats.menuTitle = "V I E W   S T A T S   M E N U";
            viewStats.id = 9;
            //viewStats.buttons = MenuButtons.SpawnList.buttons;
            menus.Add(viewStats);
            #endregion

            #region Character List Menu
            characterList.rect = new Rect(10, 985, 20, 20); // Start Position
            characterList.menuTitle = "C H A R A C T E R S   M E N U";
            characterList.id = 10;
            //characterList.buttons = MenuButtons.CharacterList.buttons;
            listMenus.Add(characterList);
            #endregion

            #region Buff List Menu
            buffList.rect = new Rect(10, 985, 20, 20); // Start Position
            buffList.menuTitle = "B U F F S   M E N U";
            buffList.id = 11;
            //buffList.buttons = MenuButtons.BuffList.buttons;
            listMenus.Add(buffList);
            #endregion

            #region Item List Menu
            itemList.rect = new Rect(10, 985, 20, 20); // Start Position
            itemList.menuTitle = "I T E M S   M E N U";
            itemList.id = 12;
            //itemList.buttons = MenuButtons.ItemList.buttons;
            listMenus.Add(itemList);
            #endregion

            #region Equipment List Menu
            equipmentList.rect = new Rect(10, 985, 20, 20); // Start Position
            equipmentList.menuTitle = "E Q U I P M E N T   M E N U";
            equipmentList.id = 13;
            //equipmentList.buttons = MenuButtons.EquipmentList.buttons;
            listMenus.Add(equipmentList);
            #endregion

            #region Chest Items List Menu
            chestItemList.rect = new Rect(10, 985, 20, 20); // Start Position
            chestItemList.menuTitle = "C H E S T   I T E M S   M E N U";
            chestItemList.id = 14;
            //chestItemList.buttons = MenuButtons.ChestItemList.buttons;
            listMenus.Add(chestItemList);
            #endregion

            #region Spawn List Menu
            spawnList.rect = new Rect(10, 985, 20, 20); // Start Position
            spawnList.menuTitle = "S P A W N   C A R D S   M E N U";
            spawnList.id = 15;
            //spawnList.buttons = MenuButtons.SpawnList.buttons;
            listMenus.Add(spawnList);
            #endregion

            #endregion
        }

        public void Update()
        {
            try
            {
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
                    }
                }
            }
            catch (Exception e)
            {
                Debug.LogError(e);
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

        #region Routines

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
                if (MenuButtons.Render.renderInteractables)
                {
                    MenuButtons.Render.Interactables();
                }
                if (MenuButtons.Render.renderMobs)
                {
                    MenuButtons.Render.Mobs();
                }
                if (MenuButtons.Render.renderMods)
                {
                    MenuButtons.Render.ActiveMods();
                }
                if (chestItemList.enabled)
                {
                //    Chests.RenderClosestChest();
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

        #endregion
    }
}
