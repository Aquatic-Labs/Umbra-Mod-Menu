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

        public static List<Menu> menus = new List<Menu>();
        public static bool _CharacterCollected;

        public static Scene currentScene;

        public Routines routines = new Routines();

        public Menu main = new Menu();
        public Menu player = new Menu();
        public Menu movement = new Menu();
        public Menu item = new Menu();
        public Menu spawn = new Menu();
        public Menu teleporter = new Menu();
        public Menu render = new Menu();
        public Menu lobby = new Menu();

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

            #region Main Menu
            main.SetWindow();
            BuildMenus.BuildMainMenu(main);
            #endregion

            #region Player Menu
            BuildMenus.BuildPlayerMenu(player);
            #endregion

            #region Movement Menu
            BuildMenus.BuildPlayerMenu(player);
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
        }

        public void Start()
        {
            Styles styles = new Styles();
            styles.BuildStyles();

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

            #region Item Menu
            item.rect = new Rect(738, 10, 20, 20); // Start Position
            item.menuTitle = "I T E M   M E N U";
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

            #region Lobby Menu
            lobby.rect = new Rect(10, 985, 20, 20); // Start Position
            lobby.menuTitle = "L O B B Y   M E N U";
            lobby.id = 7;
            menus.Add(lobby);
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
