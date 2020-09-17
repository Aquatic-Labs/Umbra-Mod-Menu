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
        public static bool _CharacterCollected;
        public static bool navigationToggle;

        public static Scene currentScene;

        public Routines routines = new Routines();

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
        public ListMenu characterList = new ListMenu();
        public ListMenu buffList = new ListMenu();
        public ListMenu itemList= new ListMenu();
        public ListMenu equipmentList= new ListMenu();
        public ListMenu chestItemList= new ListMenu();
        public ListMenu spawnList= new ListMenu();
        #endregion
        

        private void OnGUI()
        {
            #region Main Menus

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

            #region Main Menu
            main.SetWindow();
            BuildMenus.BuildMainMenu(main);
            #endregion

            #region Player Menu
            BuildMenus.BuildPlayerMenu(player);
            #endregion

            #region Movement Menu
            BuildMenus.BuildMovementMenu(movement);
            #endregion

            #region Item Menu
            BuildMenus.BuildItemMenu(item);
            #endregion

            #region Spawn Menu
            BuildMenus.BuildSpawnMenu(spawn);
            #endregion

            #region Teleporter Menu
            BuildMenus.BuildTeleporterMenu(teleporter);
            #endregion

            #region Render Menu
            BuildMenus.BuildRenderMenu(render);
            #endregion

            #region Lobby Menu
            BuildMenus.BuildLobbyMenu(lobby);
            #endregion

            #endregion
            
            #region Sub Menus

            #region Stats Modification Menu
            BuildMenus.BuildStatsModMenu(statsMod);
            #endregion

            #region Character List Menu
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
        }

        public void Start()
        {
            Styles styles = new Styles();
            styles.BuildStyles();

            #region Main Menus

            #region Main Menu
            main.rect = new Rect(10, 10, 20, 20); // Start Position
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
            main.id = 0;
            //main.buttons = MenuButtons.Main.buttons;
            menus.Add(main);
            #endregion

            #region Player Menu
            player.rect = new Rect(374, 10, 20, 20); // Start Position
            player.menuTitle = "P L A Y E R   M E N U";
            player.id = 1;
            //player.buttons = MenuButtons.Player.buttons;
            menus.Add(player);
            #endregion

            #region Movement Menu
            movement.rect = new Rect(374, 560, 20, 20); // Start Position
            movement.menuTitle = "M O V E M E N T   M E N U";
            movement.id = 2;
            //movement.buttons = MenuButtons.Movement.buttons;
            menus.Add(movement);
            #endregion

            #region Item Menu
            item.rect = new Rect(738, 10, 20, 20); // Start Position
            item.menuTitle = "I T E M   M E N U";
            item.id = 3;
            //item.buttons = MenuButtons.Items.buttons;
            menus.Add(item);
            #endregion

            #region Spawn Menu
            spawn.rect = new Rect(738, 515, 20, 20); // Start Position
            spawn.menuTitle = "S P A W N   M E N U";
            spawn.id = 4;
            //spawn.buttons = MenuButtons.Spawn.buttons;
            menus.Add(spawn);
            #endregion

            #region Teleporter Menu
            teleporter.rect = new Rect(10, 425, 20, 20); // Start Position
            teleporter.menuTitle = "T E L E P O R T E R   M E N U";
            teleporter.id = 5;
            //teleporter.buttons = MenuButtons.Teleporter.buttons;
            menus.Add(teleporter);
            #endregion

            #region Render Menu
            render.rect = new Rect(10, 795, 20, 20); // Start Position
            render.menuTitle = "R E N D E R   M E N U";
            render.id = 6;
            //render.buttons = MenuButtons.Render.buttons;
            menus.Add(render);
            #endregion

            #region Lobby Menu
            lobby.rect = new Rect(10, 985, 20, 20); // Start Position
            lobby.menuTitle = "L O B B Y   M E N U";
            lobby.id = 7;
            //lobby.buttons = MenuButtons.Lobby.buttons;
            menus.Add(lobby);
            #endregion

            #endregion
            
            #region Sub Menus

            #region Stats Modification Menu
            statsMod.rect = new Rect(10, 985, 20, 20); // Start Position
            statsMod.menuTitle = "S T A T S   M O D I F I C A T I O N   M E N U";
            statsMod.id = 8;
            //statsMod.buttons = MenuButtons.StatsMod.buttons;
            menus.Add(statsMod);
            #endregion

            #region Character List Menu
            characterList.rect = new Rect(10, 985, 20, 20); // Start Position
            characterList.menuTitle = "C H A R A C T E R S   M E N U";
            characterList.id = 9;
            //characterList.buttons = MenuButtons.CharacterList.buttons;
            listMenus.Add(characterList);
            #endregion

            #region Buff List Menu
            buffList.rect = new Rect(10, 985, 20, 20); // Start Position
            buffList.menuTitle = "B U F F S   M E N U";
            buffList.id = 10;
            //buffList.buttons = MenuButtons.BuffList.buttons;
            listMenus.Add(buffList);
            #endregion

            #region Item List Menu
            itemList.rect = new Rect(10, 985, 20, 20); // Start Position
            itemList.menuTitle = "I T E M S   M E N U";
            itemList.id = 11;
            //itemList.buttons = MenuButtons.ItemList.buttons;
            listMenus.Add(itemList);
            #endregion

            #region Equipment List Menu
            equipmentList.rect = new Rect(10, 985, 20, 20); // Start Position
            equipmentList.menuTitle = "E Q U I P M E N T   M E N U";
            equipmentList.id = 12;
            //equipmentList.buttons = MenuButtons.EquipmentList.buttons;
            listMenus.Add(equipmentList);
            #endregion

            #region Chest Items List Menu
            chestItemList.rect = new Rect(10, 985, 20, 20); // Start Position
            chestItemList.menuTitle = "C H E S T   I T E M S   M E N U";
            chestItemList.id = 13;
            //chestItemList.buttons = MenuButtons.ChestItemList.buttons;
            listMenus.Add(chestItemList);
            #endregion

            #region Spawn List Menu
            spawnList.rect = new Rect(10, 985, 20, 20); // Start Position
            spawnList.menuTitle = "S P A W N C A R D S   M E N U";
            spawnList.id = 14;
            //spawnList.buttons = MenuButtons.SpawnList.buttons;
            listMenus.Add(spawnList);
            #endregion

            #endregion
        }

        public void Update()
        {
            try
            {
                routines.CharacterRoutine();
                CheckInputs();
                /*routines.StatsRoutine();
                routines.EquipCooldownRoutine();
                routines.ModStatsRoutine();
                routines.FlightRoutine();
                routines.SprintRoutine();
                routines.JumpPackRoutine();
                routines.AimBotRoutine();
                routines.GodRoutine();
                routines.UpdateNavIndexRoutine();
                routines.DevBuildRoutine();*/
                // UpdateMenuPositions();
            }
            catch (NullReferenceException)
            {

            }
        }

        public void FixedUpdate()
        {
            currentScene = SceneManager.GetActiveScene();
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
                            if (LocalHealth.alive) _CharacterCollected = true;
                            else _CharacterCollected = false;
                        }
                    }
                }
            }
            catch (Exception e)
            {
                Debug.LogError(e);
                _CharacterCollected = false;
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

        private void CheckInputs()
        {
            if (Input.GetKeyDown(KeyCode.Insert))
            {
                main.enabled = !main.enabled;
                GetCharacter();
            }
        }
    }
}
