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

        public static string log = "[" + NAME + "] ";

        public static CharacterMaster LocalPlayer;
        public static CharacterBody LocalPlayerBody;
        public static Inventory LocalPlayerInv;
        public static HealthComponent LocalHealth;
        public static SkillLocator LocalSkills;
        public static NetworkUser LocalNetworkUser;
        public static CharacterMotor LocalMotor;

        public static bool _CharacterCollected;

        public Scene currentScene;

        public Routines routines = new Routines();

        public Menu mainMenu = new Menu();

        private void OnGUI()
        {
            GUI.Label(new Rect(Screen.width - 210, 1f, 100, 50f), $"Umbra Menu (v{VERSION}) <color=grey>-</color> <color=yellow>Dev Build</color>", Styles.WatermarkStyle);

            BuildMenus.BuildMainMenu(mainMenu);
        }

        public void Start()
        {
            Textures textures = new Textures();
            textures.BuildTextures();
            Styles styles = new Styles();
            styles.BuildStyles();

            #region Main Menu
            mainMenu.rect = new Rect(10, 10, 20, 20); // Start Position
            if (Loader.updateAvailable)
            {
                mainMenu.menuTitle = $"U M B R A \n<color=yellow>O U T D A T E D</color>";
            }
            else if (Loader.upToDate)
            {
                mainMenu.menuTitle = $"U M B R A \n<color=grey>v{VERSION}</color>";
            }
            else if (Loader.devBuild)
            {
                mainMenu.menuTitle = $"U M B R A \n<color=yellow>D E V</color>";
            }
            mainMenu.id = 0;
            #endregion 
        }

        public void Update()
        {
            try
            {
                routines.GetCharacter();
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

        public void GetCharacter(int id = 0)
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

        public bool InGameCheck()
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
                mainMenu.enabled = !mainMenu.enabled;
                GetCharacter();
            }
        }
    }
}
