using System;
using System.Collections.Generic;
using UnityEngine;
using RoR2;
using UnityEngine.SceneManagement;
using System.Linq;
using System.Text.RegularExpressions;
using Player = UmbraMenu.Model.Cheats.Player;
using Movement = UmbraMenu.Model.Cheats.Movement;
using Items = UmbraMenu.Model.Cheats.Items;
using Spawn = UmbraMenu.Model.Cheats.Spawn;
using Teleporter = UmbraMenu.Model.Cheats.Teleporter;
using Render = UmbraMenu.Model.Cheats.Render;
using Chests = UmbraMenu.Model.Cheats.Chests;

namespace UmbraMenu.Model
{
    public class UmbraMod : MonoBehaviour
    {
        public const string
            NAME = "U M B R A",
            VERSION = "2.0.3";

        public static string SETTINGSPATH = System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), $"UmbraMenu/settings-{VERSION}.ini");

        #region Player Variables
        public CharacterMaster LocalPlayer;
        public CharacterBody LocalPlayerBody;
        public Inventory LocalPlayerInv;
        public HealthComponent LocalHealth;
        public SkillLocator LocalSkills;
        public NetworkUser LocalNetworkUser;
        public CharacterMotor LocalMotor;
        #endregion

        #region Game Element Lists
        public Dictionary<String, UnlockableDef> unlockables;
        public List<GameObject> bodyPrefabs;
        public List<EquipmentIndex> equipment;
        public List<ItemIndex> items;
        public List<BuffDef> buffs;
        public List<SpawnCard> spawnCards;
        public List<ItemIndex> bossItems;
        public List<ItemIndex> unreleasedItems;
        public List<EquipmentIndex> unreleasedEquipment;
        #endregion

        #region Misc Variabled used in some features
        public bool characterCollected, devDoOnce = true, devMode, chatOpen, msgSent = true, listenForKeybind, devRoutineFired;
        public Scene currentScene;
        #endregion

        #region Settings Variables
        public static List<string> keyBindNames = new List<string>()
        {
            "MAIN MENU",

            "PLAYER MENU",
            "GIVE MONEY",
            "GIVE COINS",
            "GIVE XP",
            "STATS MENU",
            "VIEW STATS MENU",
            "CHANGE CHARACTER MENU",
            "BUFF MENU",
            "REMOVE BUFFS",
            "AIMBOT",
            "GODMODE",
            "INFINITE SKILLS",

            "MOVEMENT MENU",
            "ALWAYS SPRINT",
            "FLIGHT",
            "JUMP PACK",

            "ITEMS MENU",
            "GIVE ALL",
            "ROLL ITEMS",
            "ITEMS LIST MENU",
            "EQUIPMENT LIST MENU",
            "DROP ITEMS",
            "DROP INVENTORY ITEMS",
            "INFINITE EQUIPMENT",
            "STACK INVENTORY",
            "CLEAR INVENTORY",
            "CHANGE CHEST ITEM MENU",

            "SPAWN MENU",
            "SPAWN LIST MENU",
            "KILL ALL",
            "DESTROY INTERACTABLES",

            "TELEPORTER MENU",
            "SKIP STAGE",
            "INSTANT TELE CHARGE",
            "ADD MOUNTAIN STACK",
            "SPAWN ALL PORTALS",
            "SPAWN BLUE PORTAL",
            "SPAWN CELE PORTAL",
            "SPAWN GOLD PORTAL",

            "RENDER MENU",
            "RENDER ACTIVE MODS",
            "RENDER INTERACTABLES",
            "RENDER MOB ESP"
        };
        public Dictionary<string, Keybind> keybindDict;

        public List<string> Settings;
        public int GodVersion;
        #endregion

        #region Events and their Handlers
        public delegate void StartEventHandler(object sender, EventArgs e);
        public event StartEventHandler OnStart;

        public delegate void UpdateEventHandler(object sender, EventArgs e);
        public event UpdateEventHandler OnUpdate;

        public delegate void FixedUpdateEventHandler(object sender, EventArgs e);
        public event FixedUpdateEventHandler OnFixedUpdate;

        public delegate void GUIUpdateEventHandler(object sender, EventArgs e);
        public event GUIUpdateEventHandler OnGUIUpdate;

        public delegate void CharacterUpdateEventHandler(object sender, EventArgs e);
        public event CharacterUpdateEventHandler OnCharacterUpdate;

        public class KeybindUpdatedEventArgs : EventArgs
        {
            public Keybind newKeybind;
            public bool wasInUse;
        }

        public delegate void KeybindUpdatedEventHandler(object sender, KeybindUpdatedEventArgs e);
        public event KeybindUpdatedEventHandler OnKeybindUpdated;

        public class StartKeybindUpdateEventArgs : EventArgs
        {
            public string keybindName, rawKeybindStr;
        }

        public delegate void StartKeybindUpdateEventHandler(object sender, StartKeybindUpdateEventArgs e);
        public event StartKeybindUpdateEventHandler OnStartKeybindUpdate;
        #endregion

        static UmbraMod() { }

        private UmbraMod()
        {
            try
            {
                unlockables = typeof(UnlockableCatalog).GetField<Dictionary<String, UnlockableDef>>("nameToDefTable");
                bodyPrefabs = Utility.GetBodyPrefabs();
                equipment = Utility.GetEquipment();
                items = Utility.GetItems();
                buffs = Utility.GetBuffs();
                spawnCards = Utility.GetSpawnCards();

                Settings = Utility.ReadSettings();
                GodVersion = int.Parse(Settings[2]);
                keybindDict = BuildKeybinds();

                OnGUIUpdate += ESPRoutine;

                OnStart += ResolutionCheckRoutine;

                OnUpdate += DevBuildRoutine;
                OnUpdate += CheckInputsRoutine;
                OnUpdate += CharacterRoutine;
                OnUpdate += SkillsRoutine;
                OnUpdate += AimBotRoutine;
                OnUpdate += GodRoutine;
                OnUpdate += EquipCooldownRoutine;
                OnUpdate += FlightRoutine;
                OnUpdate += SprintRoutine;
                OnUpdate += JumpPackRoutine;

                OnFixedUpdate += UpdateCurrentSceneRoutine;
                OnFixedUpdate += UpdateHurtboxesRoutine;
                OnFixedUpdate += UpdateNearestChestRoutine;

                OnStartKeybindUpdate += SetKeybindRoutine; // Separate into GUI and Non GUI elements

                SceneManager.activeSceneChanged += OnSceneLoadedRoutine;
            }
            catch
            {
                Debug.Log("Error while loading UmbraMod");
            }
        }

        public static UmbraMod Instance { get; } = new UmbraMod();

        #region Main Unity Functions
        public void OnGUI()
        {
            try { OnGUIUpdate?.Invoke(this, EventArgs.Empty); } catch { }
        }

        public void Start()
        {
            try { OnStart?.Invoke(this, EventArgs.Empty); } catch { }
        }

        public void Update()
        {
            try { OnUpdate?.Invoke(this, EventArgs.Empty); } catch { }
        }

        public void FixedUpdate()
        {
            try { OnFixedUpdate?.Invoke(this, EventArgs.Empty); } catch { }
        }
        #endregion

        #region Misc Functions
        public void CallToStartKeybindUpdate(object sender, StartKeybindUpdateEventArgs e)
        {
            OnStartKeybindUpdate?.Invoke(sender, e);
        }

        public void GetCharacter()
        {
            bool temp = characterCollected;
            try
            {
                if (InGameCheck())
                {
                    LocalNetworkUser = null;

                    foreach (NetworkUser readOnlyInstance in NetworkUser.readOnlyInstancesList)   
                    {
                        if (readOnlyInstance.isLocalPlayer)
                        {
                            LocalNetworkUser = readOnlyInstance;
                            LocalPlayer = LocalNetworkUser.master;
                            LocalPlayerInv = LocalPlayer.GetComponent<Inventory>(); //gets player inventory
                            LocalHealth = LocalPlayer.GetBody().GetComponent<HealthComponent>(); //gets players local health numbers
                            LocalSkills = LocalPlayer.GetBody().GetComponent<SkillLocator>(); //gets current for local character skills
                            LocalPlayerBody = LocalPlayer.GetBody().GetComponent<CharacterBody>(); //gets all stats for local character
                            LocalMotor = LocalPlayer.GetBody().GetComponent<CharacterMotor>();
                            bool flag = LocalHealth.alive || LocalPlayer.isActiveAndEnabled || LocalPlayerBody.isActiveAndEnabled;

						    if (flag)
						    {
                                characterCollected = true;
                            }
						    else
						    {
							    characterCollected = false;
                            }
                        }
                    }
                }
            }
            catch
            {
                characterCollected = false;
            }

            try { if (temp != characterCollected) OnCharacterUpdate?.Invoke(this, EventArgs.Empty); } catch { }
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
        #endregion

        #region Routines
        #region OnGUIUpdate Routines
        private void ESPRoutine(object sender, EventArgs e)
        {
            if (characterCollected)
            {
                if (Render.renderInteractables)
                {
                    Render.RenderInteractables();
                    Render.renderInteractables = true;
                }
                else
                {
                    Render.renderInteractables = false;
                }

                if (Render.renderMobs)
                {
                    Render.RenderMobs();
                    Render.renderMobs = true;
                }
                else
                {
                    Render.renderMobs = false;
                }

                if (Render.renderMods)
                {
                    Render.RenderActiveMods();
                    Render.renderMods = true;
                }
                else
                {
                    Render.renderMods = false;
                }

                if (!Chests.onChestsEnable)
                {
                    Render.RenderClosestChest();
                }
            }
        }
        #endregion

        #region OnStart Routines
        private void ResolutionCheckRoutine(object sender, EventArgs e)
        {
            if (Screen.height < 1080)
            {
                Render.renderMods = false;
            }
        }
        #endregion

        #region OnUpdate Routines
        private void CheckInputsRoutine(object sender, EventArgs e)
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

            Keybinds();
        }

        private void CharacterRoutine(object sender, EventArgs e)
        {
            GetCharacter();
        }

        private void DevBuildRoutine(object sender, EventArgs e)
        {
            if (Loader.devBuild)
            {
                if (characterCollected)
                {
                    if (devDoOnce && devMode)
                    {
                        Player.GodToggle = true;

                        Movement.flightToggle = true;

                        Movement.alwaysSprintToggle = true;

                        LocalPlayer.GiveMoney(10000);
                        devDoOnce = false;
                        devRoutineFired = true;
                    }
                }
            }
        }

        private void EquipCooldownRoutine(object sender, EventArgs e)
        {
            if (Items.noEquipmentCD)
            {
                Items.NoEquipmentCooldown();
            }
        }

        private void SkillsRoutine(object sender, EventArgs e)
        {
            if (characterCollected)
            {
                if (Player.SkillToggle)
                {
                    LocalSkills.ApplyAmmoPack();
                }
            }
        }

        private void AimBotRoutine(object sender, EventArgs e)
        {
            if (Player.AimBotToggle)
            {
                Player.AimBot();
            }

        }

        private void GodRoutine(object sender, EventArgs e)
        {
            if (characterCollected)
            {
                if (Player.GodToggle)
                {
                    Player.EnableGodMode();
                }
            }
        }

        private void SprintRoutine(object sender, EventArgs e)
        {
            if (Movement.alwaysSprintToggle)
            {
                Movement.AlwaysSprint();
            }
        }

        private void FlightRoutine(object sender, EventArgs e)
        {
            if (Movement.flightToggle)
            {
                Movement.Flight();
            }
        }

        private void JumpPackRoutine(object sender, EventArgs e)
        {
            if (Movement.jumpPackToggle)
            {
                Movement.JumpPack();
            }
        }

        private void SetKeybindRoutine(object sender, StartKeybindUpdateEventArgs e)
        {
            Dictionary<string, string> numKeys = new Dictionary<string, string>()
            {
                { "0", "Alpha0" },
                { "1", "Alpha1" },
                { "2", "Alpha2" },
                { "3", "Alpha3" },
                { "4", "Alpha4" },
                { "5", "Alpha5" },
                { "6", "Alpha6" },
                { "7", "Alpha7" },
                { "8", "Alpha8" },
                { "9", "Alpha9" },
            };
            Regex rgAlpha = new Regex(@"^[A-Z]$");
            Regex rgNum = new Regex(@"^[0-9]$");
            string newKeybind = e.rawKeybindStr;
            string keybindName = e.keybindName;
            if (newKeybind.Length > 1)
            {
                newKeybind = newKeybind.First().ToString().ToUpper() + newKeybind.Substring(1);
            }
            else
            {
                newKeybind = newKeybind.ToUpper();
            }

            bool wasKeybindInUse = false;
            bool validKeybind = newKeybind != "V" && newKeybind != "W" && newKeybind != "A" && newKeybind != "S" && newKeybind != "D" && rgAlpha.IsMatch(newKeybind) && newKeybind != "" && newKeybind != " " && newKeybind != null;
            if (validKeybind)
            {
                KeyCode keyCode = (KeyCode)Enum.Parse(typeof(KeyCode), newKeybind);
                if (!Utility.KeyCodeInUse(keyCode))
                {
                    keybindDict[keybindName].KeyCode = keyCode;
                }
                else
                {
                    wasKeybindInUse = true;
                    Keybind keybind = Utility.FindKeybindByKeyCode(keyCode);
                    keybind.KeyCode = KeyCode.None;

                    keybindDict[keybindName].KeyCode = keyCode;
                }
                listenForKeybind = false;
                Utility.SaveSettings();
                OnKeybindUpdated?.Invoke(this, new KeybindUpdatedEventArgs() { newKeybind = keybindDict[keybindName], wasInUse = wasKeybindInUse });
            }
            else if (rgNum.IsMatch(newKeybind))
            {
                newKeybind = numKeys[newKeybind];
                KeyCode keyCode = (KeyCode)Enum.Parse(typeof(KeyCode), newKeybind);
                if (newKeybind != "Alpha0")
                {
                    if (!Utility.KeyCodeInUse(keyCode))
                    {
                        keybindDict[keybindName].KeyCode = keyCode;
                    }
                    else
                    {
                        wasKeybindInUse = true;
                        Keybind keybind = Utility.FindKeybindByKeyCode(keyCode);
                        keybind.KeyCode = KeyCode.None;

                        keybindDict[keybindName].KeyCode = keyCode;
                    }
                }
                else
                {
                    keybindDict[keybindName].KeyCode = KeyCode.None;
                }
                listenForKeybind = false;
                Utility.SaveSettings();
                OnKeybindUpdated?.Invoke(this, new KeybindUpdatedEventArgs() { newKeybind = keybindDict[keybindName], wasInUse = wasKeybindInUse });
            }
        }
        #endregion

        #region OnFixedUpdate Routines
        private void UpdateCurrentSceneRoutine(object sender, EventArgs e)
        {
            currentScene = SceneManager.GetActiveScene();
        }

        private void UpdateHurtboxesRoutine(object sender, EventArgs e)
        {
            if (InGameCheck())
            {
                if (Render.renderMobs)
                {
                    Render.hurtBoxes = Utility.GetHurtBoxes();
                }
            }
        }

        private void UpdateNearestChestRoutine(object sender, EventArgs e)
        {
            if (InGameCheck())
            {
                Chests.isClosestChestEquip = Chests.CheckClosestChestEquip();
            }
        }
        #endregion

        #region Misc Routines
        public void OnSceneLoadedRoutine(Scene s1, Scene s2)
        {
            if (s2 != null)
            {
                bool inGame = s2.name != "title" && s2.name != "lobby" && s2.name != "" && s2.name != " ";
                if (inGame)
                {
                    if (Render.renderInteractables)
                    {
                        Render.DumpInteractables(null);
                    }
                }
                else
                {
                    if (Screen.height < 1080)
                    {
                        Render.renderMods = false;
                    }
                }
            }
        }
        #endregion
        #endregion

        #region Inputs
        private void Keybinds()
        {
            #region Dev Mode Keybinds
            if (Input.GetKeyDown(KeyCode.F2))
            {
                devMode = !devMode;
            }
            #endregion

            if (!chatOpen && InGameCheck() && !listenForKeybind)
            {
                #region Player Menu Keybinds
                if (Input.GetKeyDown(keybindDict["GIVE MONEY"].KeyCode))
                {
                    Player.GiveMoney();
                }

                if (Input.GetKeyDown(keybindDict["GIVE COINS"].KeyCode))
                {
                    Player.GiveLunarCoins();
                }

                if (Input.GetKeyDown(keybindDict["GIVE XP"].KeyCode))
                {
                    Player.GiveXP();
                }

                if (Input.GetKeyDown(keybindDict["REMOVE BUFFS"].KeyCode))
                {
                    Player.RemoveAllBuffs();
                }

                if (Input.GetKeyDown(keybindDict["AIMBOT"].KeyCode))
                {
                    Player.AimBotToggle = !Player.AimBotToggle;
                }

                if (Input.GetKeyDown(keybindDict["GODMODE"].KeyCode))
                {
                    Player.GodToggle = !Player.GodToggle;
                }

                if (Input.GetKeyDown(keybindDict["INFINITE SKILLS"].KeyCode))
                {
                    Player.SkillToggle = !Player.SkillToggle;
                }
                #endregion

                #region Movement Menu Keybinds
                if (Input.GetKeyDown(keybindDict["ALWAYS SPRINT"].KeyCode))
                {
                    Movement.alwaysSprintToggle = !Movement.alwaysSprintToggle;
                }

                if (Input.GetKeyDown(keybindDict["FLIGHT"].KeyCode))
                {
                    Movement.flightToggle = !Movement.flightToggle;
                }

                if (Input.GetKeyDown(keybindDict["JUMP PACK"].KeyCode))
                {
                    Movement.jumpPackToggle = !Movement.jumpPackToggle;
                }
                #endregion

                #region Item Menu Keybinds
                if (Input.GetKeyDown(keybindDict["GIVE ALL"].KeyCode))
                {
                    Items.GiveAllItems();
                }

                if (Input.GetKeyDown(keybindDict["ROLL ITEMS"].KeyCode))
                {
                    Items.RollItems();
                }

                if (Input.GetKeyDown(keybindDict["DROP ITEMS"].KeyCode))
                {
                    Items.isDropItemForAll = !Items.isDropItemForAll;
                }

                if (Input.GetKeyDown(keybindDict["DROP INVENTORY ITEMS"].KeyCode))
                {
                    Items.isDropItemFromInventory = !Items.isDropItemFromInventory;
                }

                if (Input.GetKeyDown(keybindDict["INFINITE EQUIPMENT"].KeyCode))
                {
                    Items.noEquipmentCD = !Items.noEquipmentCD;
                }

                if (Input.GetKeyDown(keybindDict["STACK INVENTORY"].KeyCode))
                {
                    Items.StackInventory();
                }

                if (Input.GetKeyDown(keybindDict["CLEAR INVENTORY"].KeyCode))
                {
                    Items.ClearInventory();
                }
                #endregion

                #region Spawn Menu Keybinds
                if (Input.GetKeyDown(keybindDict["KILL ALL"].KeyCode))
                {
                    Spawn.KillAllMobs();
                }

                if (Input.GetKeyDown(keybindDict["DESTROY INTERACTABLES"].KeyCode))
                {
                    Spawn.DestroySpawnedInteractables();
                }
                #endregion

                #region Teleport Menu Keybinds 
                if (Input.GetKeyDown(keybindDict["SKIP STAGE"].KeyCode))
                {
                    Teleporter.SkipStage();
                }

                if (Input.GetKeyDown(keybindDict["INSTANT TELE CHARGE"].KeyCode))
                {
                    Teleporter.InstaTeleporter();
                }

                if (Input.GetKeyDown(keybindDict["ADD MOUNTAIN STACK"].KeyCode))
                {
                    Teleporter.AddMountain();
                }

                if (Input.GetKeyDown(keybindDict["SPAWN ALL PORTALS"].KeyCode))
                {
                    Teleporter.SpawnPortals("all");
                }

                if (Input.GetKeyDown(keybindDict["SPAWN BLUE PORTAL"].KeyCode))
                {
                    Teleporter.SpawnPortals("blue");
                }

                if (Input.GetKeyDown(keybindDict["SPAWN CELE PORTAL"].KeyCode))
                {
                    Teleporter.SpawnPortals("cele");
                }

                if (Input.GetKeyDown(keybindDict["SPAWN GOLD PORTAL"].KeyCode))
                {
                    Teleporter.SpawnPortals("gold");
                }
                #endregion

                #region Render Menu Keybinds
                if (Input.GetKeyDown(keybindDict["RENDER ACTIVE MODS"].KeyCode))
                {
                    Render.renderMods = !Render.renderMods;
                }

                if (Input.GetKeyDown(keybindDict["RENDER INTERACTABLES"].KeyCode))
                {
                    Render.renderInteractables = !Render.renderInteractables;
                }

                if (Input.GetKeyDown(keybindDict["RENDER MOB ESP"].KeyCode))
                {
                    Render.renderMobs = !Render.renderMobs;
                }
                #endregion
            }
        }

        public Dictionary<string, Keybind> BuildKeybinds()
        {
            Dictionary<string, Keybind> keybinds = new Dictionary<string, Keybind>();
            for (int i = 0; i < keyBindNames.Count; i++)
            {
                Keybind keybind = new Keybind(keyBindNames[i], (KeyCode)Enum.Parse(typeof(KeyCode), Settings[i + 3]));
                keybinds.Add(keyBindNames[i], keybind);
            }
            return keybinds;
        }
        #endregion Inputs
    }
}