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

            main.SetWindow();
            BuildMenus.BuildMainMenu(main);

            BuildMenus.BuildPlayerMenu(player);
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
            player.rect = new Rect(360, 10, 20, 20); // Start Position
            player.menuTitle = "P L A Y E R   M E N U";
            player.id = 1;
            menus.Add(player);
            #endregion 
        }

        public void Update()
        {
            try
            {
                routines.CharacterRoutine();
                CheckInputs();
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
