//TODO LIST
/*
GUI keyboard navigation somehow?
Add drop items from inventory?
Add filters to ESPs
Make ESP less laggy?
Clear Items despawn beatle gaurds/Allies from UI
Press X to go down while fly is enabled
add media section to github readme
Organize Files

Possible features:
Respawn
Spawn Mobs
*/
using System;
using System.Linq;
using System.IO;
using System.Reflection;
using System.Collections.Generic;
using UnityEngine;
using RoR2;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;
using Console = RoR2.Console;

namespace RoRCheats
{
    public class Main : MonoBehaviour
    {
        public const string
            NAME = "U M B R A",
            VERSION = "1.0";

        public static string log = "[" + NAME + "] ";
        public static List<string> unlockableNames = GetAllUnlockables();

        #region Player Variables
        public static CharacterMaster LocalPlayer;
        public static CharacterBody LocalPlayerBody;
        public static Inventory LocalPlayerInv;
        public static HealthComponent LocalHealth;
        public static SkillLocator LocalSkills;
        public static NetworkUser LocalNetworkUser;
        public static CharacterMotor LocalMotor;
        #endregion

        #region Menu Checks
        public static bool _isMenuOpen = false;
        public static bool _ifDragged = false;
        public static bool _CharacterCollected = false;
        public static bool _isStatMenuOpen = false;
        public static bool _isTeleMenuOpen = false;
        public static bool _isESPMenuOpen = false;
        public static bool _ItemToggle = false;
        public static bool _CharacterToggle = false;
        public static bool _isLobbyMenuOpen = false;
        public static bool _isEditStatsOpen = false;
        public static bool _isItemSpawnMenuOpen = false;
        public static bool _isPlayerMod = false;
        public static bool _isEquipmentSpawnMenuOpen = false;
        public static bool _isBuffMenuOpen = false;
        public static bool _isItemManagerOpen = false;
        public static bool enableRespawnButton = false;
        #endregion

        #region Button Styles / Toggles
        public static GUIStyle MainBgStyle, StatBgSytle, TeleBgStyle, OnStyle, OffStyle, LabelStyle, TitleStyle, BtnStyle, ItemBtnStyle, CornerStyle, DisplayStyle, BgStyle; //make new BgStyle for stats menu
        public static GUIStyle BtnStyle1, BtnStyle2, BtnStyle3;
        public static bool skillToggle, renderInteractables, renderMobs, damageToggle, critToggle, attackSpeedToggle, armorToggle, regenToggle, moveSpeedToggle, MouseToggle, FlightToggle, listItems, noEquipmentCooldown, listBuffs, dropMenu, ShowUnlockAll;
        public static float delay = 0, widthSize = 500;
        #endregion

        #region UI Rects
        public static Rect mainRect;
        public static Rect statRect;
        public static Rect teleRect;
        public static Rect ESPRect;
        public static Rect lobbyRect;
        public static Rect itemSpawnerRect;
        public static Rect equipmentSpawnerRect;
        public static Rect buffMenuRect;
        public static Rect characterRect;
        public static Rect playerModRect;
        public static Rect itemManagerRect;
        #endregion

        public static Texture2D Image = null, ontexture, onpresstexture, offtexture, offpresstexture, cornertexture, backtexture, btntexture, btnpresstexture, btntexturelabel;
        public static Texture2D NewTexture2D { get { return new Texture2D(1, 1); } }

        #region Stats intervals / toggles
        public static int itemsToRoll = 5;
        public static int damagePerLvl = 10;
        public static int CritPerLvl = 1;
        public static float attackSpeed = 1;
        public static float armor = 0;
        public static float movespeed = 7;
        public static int jumpCount = 1;
        public static bool isDropItems = false;
        public static bool isDropItemForAll = false;
        public static bool alwaysSprint = false;
        public static bool aimBot = false;
        public static bool godToggle = false;
        public static int allItemsQuantity = 1;
        public static ulong xpToGive = 50;
        public static uint moneyToGive = 50;
        public static uint coinsToGive = 50;
        public static int ESPLimit = 1;
        #endregion

        public static int PlayerModBtnY, MainMulY, StatMulY, TeleMulY, ESPMulY, LobbyMulY, itemSpawnerMulY, equipmentSpawnerMulY, buffMenuMulY, CharacterMulY, PlayerModMulY, ItemManagerMulY, ItemManagerBtnY;

        public static Dictionary<String, Int32> nameToIndexMap = new Dictionary<String, Int32>();
        public static string[] Players = new string[16];

        public static Rect rect = new Rect(10, 10, 20, 20);

        public static int btnY, mulY;
        private Vector2 scrollViewVector = Vector2.zero;
        public Rect dropDownRect = new Rect(10, 10, 20, 20);

        private void OnGUI()
        {
            #region GenerateMenus

            mainRect = GUI.Window(0, mainRect, new GUI.WindowFunction(SetMainBG), "", new GUIStyle());
            if (_isMenuOpen)
            {
                DrawAllMenus();
            }
            if (_isStatMenuOpen)
            {
                statRect = GUI.Window(1, statRect, new GUI.WindowFunction(SetStatsBG), "", new GUIStyle());
                DrawMenu.DrawStatsMenu(statRect.x, statRect.y, widthSize, StatMulY, MainBgStyle, LabelStyle);
            }
            if (_isTeleMenuOpen)
            {
                teleRect = GUI.Window(2, teleRect, new GUI.WindowFunction(SetTeleBG), "", new GUIStyle());
                DrawMenu.DrawTeleMenu(teleRect.x, teleRect.y, widthSize, TeleMulY, MainBgStyle, BtnStyle, LabelStyle);
                //Debug.Log("X : " + teleRect.x + " Y : " + teleRect.y);
            }
            if (_isESPMenuOpen)
            {
                ESPRect = GUI.Window(3, ESPRect, new GUI.WindowFunction(SetESPBG), "", new GUIStyle());
                DrawMenu.DrawESPMenu(ESPRect.x, ESPRect.y, widthSize, ESPMulY, MainBgStyle, BtnStyle, OnStyle, OffStyle, LabelStyle);
                //Debug.Log("X : " + ESPRect.x + " Y : " + ESPRect.y);
            }
            if (_isLobbyMenuOpen)
            {
                lobbyRect = GUI.Window(4, lobbyRect, new GUI.WindowFunction(SetLobbyBG), "", new GUIStyle());
                DrawMenu.DrawManagmentMenu(lobbyRect.x, lobbyRect.y, widthSize, LobbyMulY, MainBgStyle, BtnStyle, LabelStyle);
                //Debug.Log("X : " + lobbyRect.x + " Y : " + lobbyRect.y);
            }
            if (_isItemSpawnMenuOpen)
            {
                itemSpawnerRect = GUI.Window(5, itemSpawnerRect, new GUI.WindowFunction(SetSpawnerBG), "", new GUIStyle());
                DrawMenu.DrawSpawnMenu(itemSpawnerRect.x, itemSpawnerRect.y, widthSize, itemSpawnerMulY, MainBgStyle, BtnStyle, LabelStyle);
                //Debug.Log("X : " + itemSpawnerRect.x + " Y : " + itemSpawnerRect.y);
            }
            if (_isPlayerMod)
            {
                playerModRect = GUI.Window(6, playerModRect, new GUI.WindowFunction(SetPlayerModBG), "", new GUIStyle());
                DrawMenu.DrawPlayerModMenu(playerModRect.x, playerModRect.y, widthSize, PlayerModMulY, MainBgStyle, BtnStyle, OnStyle, OffStyle, LabelStyle);
                //Debug.Log("X : " + playerModRect.x + " Y : " + playerModRect.y);
            }
            if (_isEquipmentSpawnMenuOpen)
            {
                equipmentSpawnerRect = GUI.Window(7, equipmentSpawnerRect, new GUI.WindowFunction(SetEquipmentBG), "", new GUIStyle());
                DrawMenu.DrawEquipmentMenu(equipmentSpawnerRect.x, equipmentSpawnerRect.y, widthSize, equipmentSpawnerMulY, MainBgStyle, BtnStyle, LabelStyle, OffStyle);
                //Debug.Log("X : " + equipmentSpawnerRect.x + " Y : " + equipmentSpawnerRect.y);
            }
            if (_isBuffMenuOpen)
            {
                buffMenuRect = GUI.Window(8, buffMenuRect, new GUI.WindowFunction(SetBuffBG), "", new GUIStyle());
                DrawMenu.DrawBuffMenu(buffMenuRect.x, buffMenuRect.y, widthSize, buffMenuMulY, MainBgStyle, BtnStyle, LabelStyle, OffStyle);
            }
            if (_CharacterToggle)
            {
                characterRect = GUI.Window(9, characterRect, new GUI.WindowFunction(SetCharacterBG), "", new GUIStyle());
                DrawMenu.CharacterWindowMethod(characterRect.x, characterRect.y, widthSize, CharacterMulY, MainBgStyle, BtnStyle, LabelStyle);
                //Debug.Log("X : " + characterRect.x + " Y : " + characterRect.y);
            }
            if (_isItemManagerOpen)
            {
                itemManagerRect = GUI.Window(10, itemManagerRect, new GUI.WindowFunction(SetItemManagerBG), "", new GUIStyle());
                DrawMenu.DrawItemManagementMenu(itemManagerRect.x, itemManagerRect.y, widthSize, ItemManagerMulY, MainBgStyle, BtnStyle, OnStyle, OffStyle, LabelStyle);
                //Debug.Log("X : " + itemManagerRect.x + " Y : " + itemManagerRect.y);
            }
            if (_CharacterCollected)
            {
                ESPRoutine();
            }
            #endregion
        }

        public void Start()
        {
            SceneManager.sceneLoaded += OnSceneLoaded;

            //TODO: Update these values
            #region CondenseMenuValues

            mainRect = new Rect(10, 10, 20, 20); //start position
            statRect = new Rect(1626, 457, 20, 20); //start position
            teleRect = new Rect(10, 320, 20, 20); //start position *
            ESPRect = new Rect(10, 730, 20, 20); //start position *
            lobbyRect = new Rect(10, 915, 20, 20); //start position *
            itemSpawnerRect = new Rect(1603, 10, 20, 20); //start position
            equipmentSpawnerRect = new Rect(1603, 10, 20, 20); //start positions
            buffMenuRect = new Rect(1503, 10, 20, 20);//start position
            characterRect = new Rect(1503, 10, 20, 20); //start position
            playerModRect = new Rect(524, 10, 20, 20); //start position
            itemManagerRect = new Rect(524, 815, 20, 20);

            /*mainRect = new Rect(10, 10, 20, 20); //start position
            statRect = new Rect(1626, 457, 20, 20); //start position
            teleRect = new Rect(426, 558, 20, 20); //start position
            lobbyRect = new Rect(10, 558, 20, 20); //start position
            itemSpawnerRect = new Rect(1503, 10, 20, 20); //start position
            equipmentSpawnerRect = new Rect(1503, 10, 20, 20); //start position
            characterRect = new Rect(1503, 10, 20, 20); //start position
            playerModRect = new Rect(426, 10, 20, 20); //start position
            itemManagerRect = new Rect(426, 10, 20, 20);*/

            #endregion

            #region Styles

            if (MainBgStyle == null)
            {
                MainBgStyle = new GUIStyle();
                MainBgStyle.normal.background = BackTexture;
                MainBgStyle.onNormal.background = BackTexture;
                MainBgStyle.active.background = BackTexture;
                MainBgStyle.onActive.background = BackTexture;
                MainBgStyle.normal.textColor = Color.HSVToRGB(0.5256f, 0.9286f, 0.9333f);
                MainBgStyle.onNormal.textColor = Color.HSVToRGB(0.5256f, 0.9286f, 0.9333f);
                MainBgStyle.active.textColor = Color.HSVToRGB(0.5256f, 0.9286f, 0.9333f);
                MainBgStyle.onActive.textColor = Color.HSVToRGB(0.5256f, 0.9286f, 0.9333f);
                MainBgStyle.fontSize = 18;
                MainBgStyle.fontStyle = FontStyle.Normal;
                MainBgStyle.alignment = TextAnchor.UpperCenter;
            }

            if (CornerStyle == null)
            {
                CornerStyle = new GUIStyle();
                CornerStyle.normal.background = BtnTexture;
                CornerStyle.onNormal.background = BtnTexture;
                CornerStyle.active.background = BtnTexture;
                CornerStyle.onActive.background = BtnTexture;
                CornerStyle.normal.textColor = Color.HSVToRGB(0.5256f, 0.9286f, 0.9333f);
                CornerStyle.onNormal.textColor = Color.HSVToRGB(0.5256f, 0.9286f, 0.9333f);
                CornerStyle.active.textColor = Color.HSVToRGB(0.5256f, 0.9286f, 0.9333f);
                CornerStyle.onActive.textColor = Color.HSVToRGB(0.5256f, 0.9286f, 0.9333f);
                CornerStyle.fontSize = 18;
                CornerStyle.fontStyle = FontStyle.Normal;
                CornerStyle.alignment = TextAnchor.UpperCenter;
            }

            if (LabelStyle == null)
            {
                LabelStyle = new GUIStyle();
                LabelStyle.normal.textColor = Color.grey;
                LabelStyle.onNormal.textColor = Color.grey;
                LabelStyle.active.textColor = Color.grey;
                LabelStyle.onActive.textColor = Color.grey;
                LabelStyle.fontSize = 18;
                LabelStyle.fontStyle = FontStyle.Normal;
                LabelStyle.alignment = TextAnchor.UpperCenter;
            }
            if (TitleStyle == null)
            {
                TitleStyle = new GUIStyle();
                TitleStyle.normal.textColor = Color.HSVToRGB(0.5256f, 0.9286f, 0.9333f);
                TitleStyle.onNormal.textColor = Color.HSVToRGB(0.5256f, 0.9286f, 0.9333f);
                TitleStyle.active.textColor = Color.HSVToRGB(0.5256f, 0.9286f, 0.9333f);
                TitleStyle.onActive.textColor = Color.HSVToRGB(0.5256f, 0.9286f, 0.9333f);
                TitleStyle.fontSize = 18;
                TitleStyle.fontStyle = FontStyle.Normal;
                TitleStyle.alignment = TextAnchor.UpperCenter;
            }

            if (OffStyle == null)
            {
                OffStyle = new GUIStyle();
                OffStyle.normal.background = OffTexture;
                OffStyle.onNormal.background = OffTexture;
                OffStyle.active.background = OffPressTexture;
                OffStyle.onActive.background = OffPressTexture;
                OffStyle.normal.textColor = Color.HSVToRGB(0.5256f, 0.9286f, 0.9333f);
                OffStyle.onNormal.textColor = Color.HSVToRGB(0.5256f, 0.9286f, 0.9333f);
                OffStyle.active.textColor = Color.HSVToRGB(0.5256f, 0.9286f, 0.9333f);
                OffStyle.onActive.textColor = Color.HSVToRGB(0.5256f, 0.9286f, 0.9333f);
                OffStyle.fontSize = 18;
                OffStyle.fontStyle = FontStyle.Normal;
                OffStyle.alignment = TextAnchor.MiddleCenter;
            }

            if (OnStyle == null)
            {
                OnStyle = new GUIStyle();
                OnStyle.normal.background = OnTexture;
                OnStyle.onNormal.background = OnTexture;
                OnStyle.active.background = OnPressTexture;
                OnStyle.onActive.background = OnPressTexture;
                OnStyle.normal.textColor = Color.HSVToRGB(0.5256f, 0.9286f, 0.9333f);
                OnStyle.onNormal.textColor = Color.HSVToRGB(0.5256f, 0.9286f, 0.9333f);
                OnStyle.active.textColor = Color.HSVToRGB(0.5256f, 0.9286f, 0.9333f);
                OnStyle.onActive.textColor = Color.HSVToRGB(0.5256f, 0.9286f, 0.9333f);
                OnStyle.fontSize = 18;
                OnStyle.fontStyle = FontStyle.Normal;
                OnStyle.alignment = TextAnchor.MiddleCenter;
            }

            if (BtnStyle == null)
            {
                BtnStyle = new GUIStyle();
                BtnStyle.normal.background = BtnTexture;
                BtnStyle.onNormal.background = BtnTexture;
                BtnStyle.active.background = BtnPressTexture;
                BtnStyle.onActive.background = BtnPressTexture;
                BtnStyle.normal.textColor = Color.HSVToRGB(0.5256f, 0.9286f, 0.9333f);
                BtnStyle.onNormal.textColor = Color.HSVToRGB(0.5256f, 0.9286f, 0.9333f);
                BtnStyle.active.textColor = Color.HSVToRGB(0.5256f, 0.9286f, 0.9333f);
                BtnStyle.onActive.textColor = Color.HSVToRGB(0.5256f, 0.9286f, 0.9333f);
                BtnStyle.fontSize = 18;
                BtnStyle.fontStyle = FontStyle.Normal;
                BtnStyle.alignment = TextAnchor.MiddleCenter;
            }
            if (ItemBtnStyle == null)
            {
                ItemBtnStyle = new GUIStyle();
                ItemBtnStyle.normal.background = BtnTexture;
                ItemBtnStyle.onNormal.background = BtnTexture;
                ItemBtnStyle.active.background = BtnPressTexture;
                ItemBtnStyle.onActive.background = BtnPressTexture;
                ItemBtnStyle.normal.textColor = Color.HSVToRGB(0.5256f, 0.9286f, 0.9333f);
                ItemBtnStyle.onNormal.textColor = Color.HSVToRGB(0.5256f, 0.9286f, 0.9333f);
                ItemBtnStyle.active.textColor = Color.HSVToRGB(0.5256f, 0.9286f, 0.9333f);
                ItemBtnStyle.onActive.textColor = Color.HSVToRGB(0.5256f, 0.9286f, 0.9333f);
                ItemBtnStyle.fontSize = 18;
                ItemBtnStyle.fontStyle = FontStyle.Normal;
                ItemBtnStyle.alignment = TextAnchor.MiddleCenter;
            }
            #endregion
        }

        public void Update()
        {
            try
            {
                CharacterRoutine();
                CheckInputs();
                StatsRoutine();
                EquipCooldownRoutine();
                ModStatsRoutine();
                FlightRoutine();
                SprintRoutine();
                AimBotRoutine();
                GodRoutine();
            }
            catch (NullReferenceException)
            {

            }
        }

        private void CheckInputs()
        {
            if (_isMenuOpen)
            {
                Cursor.visible = true;            
            }
            else if (!_isMenuOpen)
            {
                Cursor.visible = false;
            }
            if (Input.GetKeyDown(KeyCode.Insert))
            {
                _isMenuOpen = !_isMenuOpen;
                GetCharacter();
                SceneManager.sceneLoaded += OnSceneLoaded;
            }
            if (Input.GetKeyDown(KeyCode.V))
            {
                GiveMoney();
            }
        }

        #region Routines
        private void CharacterRoutine()
        {
            if (!_CharacterCollected)
            {
                GetCharacter();
            }
        }

        private void ESPRoutine()
        {
            if (renderInteractables)
            {
                RenderInteractables();
            }
            if (renderMobs)
            {
                RenderMobs();
            }
        }

        private void EquipCooldownRoutine()
        {
            if (noEquipmentCooldown)
            {
                NoEquipmentCooldown();
            }
        }

        private void StatsRoutine()
        {
            if (_CharacterCollected)
            {
                if (skillToggle)
                {
                    LocalSkills.ApplyAmmoPack();
                }
            }
        }
        private void AimBotRoutine()
        {
            if (aimBot)
                AimBot();
        }
        private void GodRoutine()
        {
            if (godToggle)
            {
                GodMode();
            }
            else
            {
                LocalHealth.godMode = false;
            }
        }
        private void SprintRoutine()
        {
            if (alwaysSprint)
                AlwaysSprint();
        }

        private void FlightRoutine()
        {
            if (FlightToggle)
            {
                Flight();
            }
        }

        private void ModStatsRoutine()
        {
            if (_CharacterCollected)
            {
                if (damageToggle)
                {
                    LevelPlayersDamage();
                }
                if (critToggle)
                {
                    LevelPlayersCrit();
                }
                if (attackSpeedToggle)
                {
                    SetplayersAttackSpeed();
                }
                if (armorToggle)
                {
                    SetplayersArmor();
                }
                if (moveSpeedToggle)
                {
                    SetplayersMoveSpeed();
                }
                LocalPlayerBody.RecalculateStats();

            }
        }

        #region On Scene Loaded
        public void OnSceneLoaded(Scene scene, LoadSceneMode mode)
        {
            //WriteToLog($"{scene.name}\nAlive: {LocalHealth.alive}\n");

            bool inGame = scene.name != "title";
            if (scene.name == "title")
            {
                enableRespawnButton = false;
                RESETMENU();
            }
            else if (!LocalHealth.alive && inGame)
            {
                enableRespawnButton = true;
            }
            else
            {
                enableRespawnButton = false;
                ModStatsRoutine();
                SoftResetMenu();
            }
        }
        #endregion

        #region SetBG

        public static void SetBG(int windowID)
        {
            GUI.Box(new Rect(0f, 0f, widthSize + 10, 50f + 45 * mulY), "", CornerStyle);
            if (Event.current.type == EventType.MouseDrag)
            {
                delay += Time.deltaTime;
                if (delay > 0.3f)
                {
                    _ifDragged = true;
                }
            }
            else if (Event.current.type == EventType.MouseUp)
            {
                delay = 0;
                if (!_ifDragged)
                    _isMenuOpen = !_isMenuOpen;
                _ifDragged = false;
            }
            GUI.DragWindow();
        }

        public static void SetMainBG(int windowID)
        {
            GUI.Box(new Rect(0f, 0f, widthSize + 10, 50f + 45 * MainMulY), "", CornerStyle);
            if (Event.current.type == EventType.MouseDrag)
            {
                delay += Time.deltaTime;
                if (delay > 0.3f)
                {
                    _ifDragged = true;
                }
            }
            else if (Event.current.type == EventType.MouseUp)
            {
                delay = 0;
                if (!_ifDragged)
                {
                    _isMenuOpen = !_isMenuOpen;
                    GetCharacter();
                }
                _ifDragged = false;
            }
            GUI.DragWindow();
        }

        public static void SetCharacterBG(int windowID)
        {
            GUI.Box(new Rect(0f, 0f, widthSize + 10, 50f + 45 * CharacterMulY), "", CornerStyle);
            if (Event.current.type == EventType.MouseDrag)
            {
                delay += Time.deltaTime;
                if (delay > 0.3f)
                {
                    _ifDragged = true;
                }
            }
            else if (Event.current.type == EventType.MouseUp)
            {
                delay = 0;
                if (!_ifDragged)
                {
                    _CharacterToggle = !_CharacterToggle;
                }
                _ifDragged = false;
            }
            GUI.DragWindow();
        }

        public static void SetEquipmentBG(int windowID)
        {
            GUI.Box(new Rect(0f, 0f, widthSize + 10, 50f + 45 * equipmentSpawnerMulY), "", CornerStyle);
            if (Event.current.type == EventType.MouseDrag)
            {
                delay += Time.deltaTime;
                if (delay > 0.3f)
                {
                    _ifDragged = true;
                }
            }
            else if (Event.current.type == EventType.MouseUp)
            {
                delay = 0;
                if (!_ifDragged)
                {
                    _isEquipmentSpawnMenuOpen = !_isEquipmentSpawnMenuOpen;
                }
                _ifDragged = false;
            }
            GUI.DragWindow();
        }

        public static void SetBuffBG(int windowID)
        {
            GUI.Box(new Rect(0f, 0f, widthSize + 10, 50f + 45 * buffMenuMulY), "", CornerStyle);
            if (Event.current.type == EventType.MouseDrag)
            {
                delay += Time.deltaTime;
                if (delay > 0.3f)
                {
                    _ifDragged = true;
                }
            }
            else if (Event.current.type == EventType.MouseUp)
            {
                delay = 0;
                if (!_ifDragged)
                {
                    _isBuffMenuOpen = !_isBuffMenuOpen;
                }
                _ifDragged = false;
            }
            GUI.DragWindow();
        }

        public static void SetStatsBG(int windowID)
        {
            GUI.Box(new Rect(0f, 0f, widthSize + 10, 50f + 45 * StatMulY), "", CornerStyle);
            if (Event.current.type == EventType.MouseDrag)
            {
                delay += Time.deltaTime;
                if (delay > 0.3f)
                {
                    _ifDragged = true;
                }
            }
            else if (Event.current.type == EventType.MouseUp)
            {
                delay = 0;
                if (!_ifDragged)
                {
                    _isStatMenuOpen = !_isStatMenuOpen;
                }
                _ifDragged = false;
            }
            GUI.DragWindow();
        }

        public static void SetTeleBG(int windowID)
        {
            GUI.Box(new Rect(0f, 0f, widthSize + 10, 50f + 45 * TeleMulY), "", CornerStyle);
            if (Event.current.type == EventType.MouseDrag)
            {
                delay += Time.deltaTime;
                if (delay > 0.3f)
                {
                    _ifDragged = true;
                }
            }
            else if (Event.current.type == EventType.MouseUp)
            {
                delay = 0;
                if (!_ifDragged)
                {
                    _isTeleMenuOpen = !_isTeleMenuOpen;
                }
                _ifDragged = false;
            }
            GUI.DragWindow();
        }

        public static void SetESPBG(int windowID)
        {
            GUI.Box(new Rect(0f, 0f, widthSize + 10, 50f + 45 * ESPMulY), "", CornerStyle);
            if (Event.current.type == EventType.MouseDrag)
            {
                delay += Time.deltaTime;
                if (delay > 0.3f)
                {
                    _ifDragged = true;
                }
            }
            else if (Event.current.type == EventType.MouseUp)
            {
                delay = 0;
                if (!_ifDragged)
                {
                    _isESPMenuOpen = !_isESPMenuOpen;
                }
                _ifDragged = false;
            }
            GUI.DragWindow();
        }

        public static void SetLobbyBG(int windowID)
        {
            GUI.Box(new Rect(0f, 0f, widthSize + 10, 50f + 45 * LobbyMulY), "", CornerStyle);
            if (Event.current.type == EventType.MouseDrag)
            {
                delay += Time.deltaTime;
                if (delay > 0.3f)
                {
                    _ifDragged = true;
                }
            }
            else if (Event.current.type == EventType.MouseUp)
            {
                delay = 0;
                if (!_ifDragged)
                {
                    _isLobbyMenuOpen = !_isLobbyMenuOpen;
                }
                _ifDragged = false;
            }
            GUI.DragWindow();
        }

        public static void SetEditStatBG(int windowID)
        {
            GUI.Box(new Rect(0f, 0f, widthSize + 10, 50f + 45 * MainMulY), "", CornerStyle);
            if (Event.current.type == EventType.MouseDrag)
            {
                delay += Time.deltaTime;
                if (delay > 0.3f)
                {
                    _ifDragged = true;
                }
            }
            else if (Event.current.type == EventType.MouseUp)
            {
                delay = 0;
                if (!_ifDragged)
                {
                    _isEditStatsOpen = !_isEditStatsOpen;
                }
                _ifDragged = false;
            }
            GUI.DragWindow();
        }

        public static void SetSpawnerBG(int windowID)
        {
            GUI.Box(new Rect(0f, 0f, widthSize + 10, 50f + 45 * MainMulY), "", CornerStyle);
            if (Event.current.type == EventType.MouseDrag)
            {
                delay += Time.deltaTime;
                if (delay > 0.3f)
                {
                    _ifDragged = true;
                }
            }
            else if (Event.current.type == EventType.MouseUp)
            {
                delay = 0;
                if (!_ifDragged)
                {
                    _isItemSpawnMenuOpen = !_isItemSpawnMenuOpen;
                }
                _ifDragged = false;
            }
            GUI.DragWindow();
        }

        public static void SetPlayerModBG(int windowID)
        {
            GUI.Box(new Rect(0f, 0f, widthSize + 10, 50f + 45 * PlayerModMulY), "", CornerStyle);
            if (Event.current.type == EventType.MouseDrag)
            {
                delay += Time.deltaTime;
                if (delay > 0.3f)
                {
                    _ifDragged = true;
                }
            }
            else if (Event.current.type == EventType.MouseUp)
            {
                delay = 0;
                if (!_ifDragged)
                {
                    _isPlayerMod = !_isPlayerMod;
                }
                _ifDragged = false;
            }
            GUI.DragWindow();
        }

        public static void SetItemManagerBG(int windowID)
        {
            GUI.Box(new Rect(0f, 0f, widthSize + 10, 50f + 45 * ItemManagerMulY), "", CornerStyle);
            if (Event.current.type == EventType.MouseDrag)
            {
                delay += Time.deltaTime;
                if (delay > 0.3f)
                {
                    _ifDragged = true;
                }
            }
            else if (Event.current.type == EventType.MouseUp)
            {
                delay = 0;
                if (!_ifDragged)
                {
                    _isItemManagerOpen = !_isItemManagerOpen;
                }
                _ifDragged = false;
            }
            GUI.DragWindow();
        }

        #endregion SetBG

        #region Draw all Menus
        public static void DrawAllMenus()
        {
            GUI.Box(new Rect(mainRect.x + 0f, mainRect.y + 0f, widthSize + 10, 50f + 45 * MainMulY), "", MainBgStyle);
            GUI.Label(new Rect(mainRect.x + 5f, mainRect.y + 5f, widthSize + 5, 95f), $"U M B R A \n<color=grey>v{VERSION}</color>", TitleStyle);

            if (!_CharacterCollected)
            {
                DrawMenu.DrawNotCollectedMenu(LabelStyle, OnStyle, OffStyle);
            }
            if (_CharacterCollected)
            {
                DrawMenu.DrawMainMenu(mainRect.x, mainRect.y, widthSize, MainMulY, MainBgStyle, OnStyle, OffStyle, BtnStyle);
            }
        }
        #endregion

        #region Textures

        public static Texture2D BtnTexture
        {
            get
            {
                if (btntexture == null)
                {
                    btntexture = NewTexture2D;
                    btntexture.SetPixel(0, 0, new Color32(120, 120, 120, 255));
                    //byte[] FileData = File.ReadAllBytes(Directory.GetCurrentDirectory() + "/BepInEx/plugins/RoRCheats/Resources/Images/ButtonStyle.png");
                    //btntexture.LoadImage(FileData);
                    btntexture.Apply();
                }
                return btntexture;
            }
        }

        public static Texture2D BtnTextureLabel
        {
            get
            {
                if (BtnTextureLabel == null)
                {
                    btntexture = NewTexture2D;
                    btntexture.SetPixel(0, 0, new Color32(255, 0, 0, 255));
                    btntexture.Apply();
                }
                return BtnTextureLabel;
            }
        }

        public static Texture2D BtnPressTexture
        {
            get
            {
                if (btnpresstexture == null)
                {
                    btnpresstexture = NewTexture2D;
                    btnpresstexture.SetPixel(0, 0, new Color32(99, 99, 99, 255));
                    btnpresstexture.Apply();
                }
                return btnpresstexture;
            }
        }

        public static Texture2D OnPressTexture
        {
            get
            {
                if (onpresstexture == null)
                {
                    onpresstexture = NewTexture2D;
                    onpresstexture.SetPixel(0, 0, new Color32(50, 50, 50, 255));
                    onpresstexture.Apply();
                }
                return onpresstexture;
            }
        }

        public static Texture2D OnTexture
        {
            get
            {
                if (ontexture == null)
                {
                    ontexture = NewTexture2D;
                    ontexture.SetPixel(0, 0, new Color32(67, 67, 67, 255));
                    ontexture.Apply();
                }
                return ontexture;
            }
        }

        public static Texture2D OffPressTexture
        {
            get
            {
                if (offpresstexture == null)
                {
                    offpresstexture = NewTexture2D;
                    offpresstexture.SetPixel(0, 0, new Color32(99, 99, 99, 255));
                    offpresstexture.Apply();
                }
                return offpresstexture;
            }
        }

        public static Texture2D OffTexture
        {
            get
            {
                if (offtexture == null)
                {
                    offtexture = NewTexture2D;
                    offtexture.SetPixel(0, 0, new Color32(120, 120, 120, 255));
                    //byte[] FileData = File.ReadAllBytes(Directory.GetCurrentDirectory() + "/BepInEx/plugins/RoRCheats/Resources/Images/OffStyle.png");
                    //offtexture.LoadImage(FileData);
                    offtexture.Apply();
                }
                return offtexture;
            }
        }
        public static Texture2D BackTexture
        {
            get
            {
                if (backtexture == null)
                {
                    backtexture = NewTexture2D;
                    backtexture.SetPixel(0, 0, new Color32(0, 0, 0, 158));
                    backtexture.Apply();
                }
                return backtexture;
            }
        }

        public static Texture2D CornerTexture
        {
            get
            {
                if (cornertexture == null)
                {
                    cornertexture = NewTexture2D;
                    //ToHtmlStringRGBA  new Color(33, 150, 243, 1)
                    cornertexture.SetPixel(0, 0, new Color32(42, 42, 42, 0));

                    cornertexture.Apply();
                }
                return cornertexture;
            }
        }

        #endregion Textures

        #endregion

        // Rect for buttons
        // It automatically auto position buttons. There is no need to change it
        public static Rect BtnRect(int y, bool multiplyBtn)
        {
            mulY = y;
            if (multiplyBtn)
            {
                btnY = 5 + 45 * y;
                return new Rect(rect.x + 5, rect.y + 5 + 45 * y, widthSize - 90, 40);
            }
            return new Rect(rect.x + 5, rect.y + 5 + 45 * y, widthSize, 40);
        }

        // try and setup our character, if we hit an error we set it to false
        //TODO: Find a way to stop it from checking whilst in main menu/lobby menu
        private static void GetCharacter()
        {
            try
            {
                LocalNetworkUser = null;
                foreach (NetworkUser readOnlyInstance in NetworkUser.readOnlyInstancesList)
                {
                    //localplayer == you!
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
            catch (Exception e)
            {
                _CharacterCollected = false;
            }
        }

        #region ESP
        public static void RenderInteractables()
        {
            foreach (TeleporterInteraction teleporterInteraction in FindObjectsOfType<TeleporterInteraction>())
            {
                float distanceToObject = Vector3.Distance(Camera.main.transform.position, teleporterInteraction.transform.position);
                Vector3 Position = Camera.main.WorldToScreenPoint(teleporterInteraction.transform.position);
                var BoundingVector = new Vector3(Position.x, Position.y, Position.z);
                if (BoundingVector.z > 0.01)
                {
                    GUI.color =
                        teleporterInteraction.isIdle ? Color.magenta :
                        teleporterInteraction.isIdleToCharging || teleporterInteraction.isCharging ? Color.yellow :
                        teleporterInteraction.isCharged ? Color.green : Color.yellow;
                    int distance = (int)distanceToObject;
                    String friendlyName = "Teleporter";
                    string status = "" + (
                        teleporterInteraction.isIdle ? "Idle" :
                        teleporterInteraction.isCharging ? "Charging" :
                        teleporterInteraction.isCharged ? "Charged" :
                        teleporterInteraction.isActiveAndEnabled ? "Idle" :
                        teleporterInteraction.isIdleToCharging ? "Idle-Charging" :
                        teleporterInteraction.isInFinalSequence ? "Final-Sequence" :
                        "???");
                    string boxText = $"{friendlyName}\n{status}\n{distance}m";
                    GUI.Label(new Rect(BoundingVector.x - 50f, (float)Screen.height - BoundingVector.y, 100f, 50f), boxText);
                }
            }

            foreach (PurchaseInteraction purchaseInteraction in PurchaseInteraction.FindObjectsOfType(typeof(PurchaseInteraction)))
            {
                if (purchaseInteraction.available)
                {
                    float distanceToObject = Vector3.Distance(Camera.main.transform.position, purchaseInteraction.transform.position);
                    Vector3 Position = Camera.main.WorldToScreenPoint(purchaseInteraction.transform.position);
                    var BoundingVector = new Vector3(Position.x, Position.y, Position.z);
                    if (BoundingVector.z > 0.01)
                    {
                        int distance = (int)distanceToObject;
                        GUI.color = Color.green;
                        String friendlyName = purchaseInteraction.GetDisplayName();
                        int cost = purchaseInteraction.cost;
                        string boxText = $"{friendlyName}\n${cost}\n{distance}m";
                        GUI.Label(new Rect(BoundingVector.x - 50f, (float)Screen.height - BoundingVector.y, 100f, 50f), boxText);
                    }
                }
            }
        }

        //Nees improvement. Causes a lot of lag
        public static void RenderMobs()
        {
            if (ESPLimit % 1000 == 0)
            {
                var localUser = RoR2.LocalUserManager.GetFirstLocalUser();
                var controller = localUser.cachedMasterController;
                if (!controller)
                {
                    return;
                }
                var body = controller.master.GetBody();
                if (!body)
                {
                    return;
                }
                var inputBank = body.GetComponent<RoR2.InputBankTest>();
                var aimRay = new Ray(inputBank.aimOrigin, inputBank.aimDirection);
                var bullseyeSearch = new RoR2.BullseyeSearch();
                var team = body.GetComponent<RoR2.TeamComponent>();
                bullseyeSearch.searchOrigin = aimRay.origin;
                bullseyeSearch.searchDirection = aimRay.direction;
                bullseyeSearch.filterByLoS = false;
                bullseyeSearch.maxDistanceFilter = 125;
                bullseyeSearch.maxAngleFilter = 40f;
                bullseyeSearch.teamMaskFilter = RoR2.TeamMask.all;
                bullseyeSearch.teamMaskFilter.RemoveTeam(team.teamIndex);
                bullseyeSearch.RefreshCandidates();
                var hurtBoxList = bullseyeSearch.GetResults();
                foreach (var hurtbox in hurtBoxList)
                {
                    var mob = HurtBox.FindEntityObject(hurtbox);
                    if (mob)
                    {
                        Vector3 MobPosition = Camera.main.WorldToScreenPoint(mob.transform.position);
                        var MobBoundingVector = new Vector3(MobPosition.x, MobPosition.y, MobPosition.z);
                        float distanceToMob = Vector3.Distance(Camera.main.transform.position, mob.transform.position);
                        if (MobBoundingVector.z > 0.01)
                        {
                            GUI.color = Color.red;
                            string mobName = mob.name.Replace("Body(Clone)", "");
                            int mobDistance = (int)distanceToMob;
                            string mobBoxText = $"{mobName}\n{mobDistance}m";
                            GUI.Label(new Rect(MobBoundingVector.x - 50f, (float)Screen.height - MobBoundingVector.y + 30f, 100f, 50f), mobBoxText);
                            //WriteToLog($"Drew label. \n{mobBoxText}\n");
                        }
                    }
                }
            }
            else
            {
                ESPLimit++;
            }
        }
        #endregion

        #region Teleporter
        public static void InstaTeleporter()
        {
            if (TeleporterInteraction.instance)
            {
                TeleporterInteraction.instance.holdoutZoneController.baseChargeDuration = 1;
            }
        }

        public static void skipStage()
        {
            Run.instance.AdvanceStage(Run.instance.nextStageScene);
            Debug.Log("RoRCheats : Skipped Stage");
        }

        public static void addMountain()
        {
            TeleporterInteraction.instance.AddShrineStack();
        }

        public static void SpawnPortals(string portal)
        {
            if (TeleporterInteraction.instance)
            {
                if (portal.Equals("gold"))
                {
                    Debug.Log("RoRCheats : Spawned Gold Portal");
                    TeleporterInteraction.instance.shouldAttemptToSpawnGoldshoresPortal = true;
                }
                else if (portal.Equals("newt"))
                {
                    Debug.Log("RoRCheats : Spawned Shop Portal");
                    TeleporterInteraction.instance.shouldAttemptToSpawnShopPortal = true;
                }
                else if (portal.Equals("blue"))
                {
                    Debug.Log("RoRCheats : Spawned Celestal Portal");
                    TeleporterInteraction.instance.shouldAttemptToSpawnMSPortal = true;
                }
                else if (portal.Equals("all"))
                {
                    Debug.Log("RoRCheats : Spawned All Portals");
                    TeleporterInteraction.instance.shouldAttemptToSpawnGoldshoresPortal = true;
                    TeleporterInteraction.instance.shouldAttemptToSpawnShopPortal = true;
                    TeleporterInteraction.instance.shouldAttemptToSpawnMSPortal = true;
                }
                else
                {
                    Debug.LogError("Selection was " + portal + " please contact mod developer.");
                }
            }
        }
        #endregion

        #region Player Modifiers
        public static void GiveBuff(GUIStyle buttonStyle, string buttonName)
        {
            //LocalPlayerBody.AddBuff(buff);

            int buttonPlacement = 1;
            foreach (string buffName in Enum.GetNames(typeof(BuffIndex)))
            {
                //bool unreleasedullItem = unreleasedItems.Any(item.Contains);
                if (GUI.Button(btn.BtnRect(buttonPlacement, false, buttonName), buffName, buttonStyle))
                {
                    BuffIndex buffIndex = (BuffIndex)Enum.Parse(typeof(BuffIndex), buffName);
                    var localUser = LocalUserManager.GetFirstLocalUser();
                    if (localUser.cachedMasterController && localUser.cachedMasterController.master)
                    {
                        LocalPlayerBody.AddBuff(buffIndex);
                    }
                }
                buttonPlacement++;
            }
        }

        public static void RemoveAllBuffs()
        {
            foreach (string buff in Enum.GetNames(typeof(BuffIndex)))
            {
                BuffIndex buffName = (BuffIndex)Enum.Parse(typeof(BuffIndex), buff);
                LocalPlayerBody.RemoveBuff(buffName);
            }
        }

        // self explanatory
        public static void giveXP()
        {
            LocalPlayer.GiveExperience(xpToGive);
        }
        public static void GiveMoney()
        {
            LocalPlayer.GiveMoney(moneyToGive);
        }
        //uh, duh.
        public static void GiveLunarCoins()
        {
            LocalNetworkUser.AwardLunarCoins(coinsToGive);
        }
        public static void LevelPlayersCrit()
        {
            try
            {
                LocalPlayerBody.levelCrit = (float)CritPerLvl;
            }
            catch (NullReferenceException)
            {
            }
        }

        public static void LevelPlayersDamage()
        {
            try
            {
                LocalPlayerBody.levelDamage = (float)damagePerLvl;
            }
            catch (NullReferenceException)
            {
            }
        }
        public static void SetplayersAttackSpeed()
        {
            try
            {
                LocalPlayerBody.baseAttackSpeed = attackSpeed;
            }
            catch (NullReferenceException)
            {
            }
        }
        public static void SetplayersArmor()
        {
            try
            {
                LocalPlayerBody.baseArmor = armor;
            }
            catch (NullReferenceException)
            {
            }
        }
        public static void SetplayersMoveSpeed()
        {
            try
            {
                LocalPlayerBody.baseMoveSpeed = movespeed;
            }
            catch (NullReferenceException)
            {
            }
        }

        public static void AimBot()
        {
            if (CursorIsVisible())
            {
                return;
            }
            var localUser = RoR2.LocalUserManager.GetFirstLocalUser();
            var controller = localUser.cachedMasterController;
            if (!controller)
            {
                return;
            }
            var body = controller.master.GetBody();
            if (!body)
            {
                return;
            }

            var inputBank = body.GetComponent<RoR2.InputBankTest>();
            var aimRay = new Ray(inputBank.aimOrigin, inputBank.aimDirection);
            var bullseyeSearch = new RoR2.BullseyeSearch();
            var team = body.GetComponent<RoR2.TeamComponent>();
            bullseyeSearch.teamMaskFilter = RoR2.TeamMask.all;
            bullseyeSearch.teamMaskFilter.RemoveTeam(team.teamIndex);
            bullseyeSearch.filterByLoS = true;
            bullseyeSearch.searchOrigin = aimRay.origin;
            bullseyeSearch.searchDirection = aimRay.direction;
            bullseyeSearch.sortMode = RoR2.BullseyeSearch.SortMode.Distance;
            bullseyeSearch.maxDistanceFilter = float.MaxValue;
            bullseyeSearch.maxAngleFilter = 20f;// ;// float.MaxValue;
            bullseyeSearch.RefreshCandidates();
            var hurtBox = bullseyeSearch.GetResults().FirstOrDefault();
            if (hurtBox)
            {
                Vector3 direction = hurtBox.transform.position - aimRay.origin;
                inputBank.aimDirection = direction;
            }
        }

        public static void AlwaysSprint()
        {
            var isMoving = LocalNetworkUser.inputPlayer.GetAxis("MoveVertical") != 0f || LocalNetworkUser.inputPlayer.GetAxis("MoveHorizontal") != 0f;
            var localUser = RoR2.LocalUserManager.GetFirstLocalUser();
            if (localUser == null || localUser.cachedMasterController == null || localUser.cachedMasterController.master == null) return;
            var controller = localUser.cachedMasterController;
            var body = controller.master.GetBody();
            if (body && !body.isSprinting && !localUser.inputPlayer.GetButton("Sprint"))
            {
                if (isMoving)
                {
                    body.isSprinting = true;
                }
            }
        }

        public static void Respawn()
        {
            LocalPlayer.RespawnExtraLife();
        }

        public static void GodMode()
        {
            LocalHealth.godMode = true;
        }
        #endregion

        #region Flight

        public static void Flight()
        {
            try
            {
                var forwardDirection = LocalPlayerBody.GetComponent<InputBankTest>().moveVector.normalized;
                var aimDirection = LocalPlayerBody.GetComponent<InputBankTest>().aimDirection.normalized;
                var upDirection = LocalPlayerBody.GetComponent<InputBankTest>().moveVector.y + 1;
                var downDirection = LocalPlayerBody.GetComponent<InputBankTest>().moveVector.y - 1;
                var isForward = Vector3.Dot(forwardDirection, aimDirection) > 0f;

                var isSprinting = LocalNetworkUser.inputPlayer.GetButton("Sprint");
                var isJumping = LocalNetworkUser.inputPlayer.GetButton("Jump");
                // ReSharper disable once CompareOfFloatsByEqualityOperator
                var isStrafing = LocalNetworkUser.inputPlayer.GetAxis("MoveVertical") != 0f;

                if (isSprinting)
                {
                    LocalPlayerBody.characterMotor.velocity = forwardDirection * 100f;
                    LocalPlayerBody.characterMotor.velocity.y = upDirection * 0.510005f;
                    if (isStrafing)
                    {
                        if (isForward)
                        {
                            LocalPlayerBody.characterMotor.velocity.y = aimDirection.y * 100f;
                        }
                        else
                        {
                            LocalPlayerBody.characterMotor.velocity.y = aimDirection.y * -100f;
                        }
                    }
                }
                else if (isJumping)
                {
                    LocalPlayerBody.characterMotor.velocity.y = upDirection * 100;
                }
                else
                {
                    LocalPlayerBody.characterMotor.velocity = forwardDirection * 50;
                    LocalPlayerBody.characterMotor.velocity.y = upDirection * 0.510005f;
                    if (isStrafing)
                    {
                        if (isForward)
                        {
                            LocalPlayerBody.characterMotor.velocity.y = aimDirection.y * 50;
                        }
                        else
                        {
                            LocalPlayerBody.characterMotor.velocity.y = aimDirection.y * -50;
                        }
                    }
                }
            }
            catch (NullReferenceException) { }
        }
        #endregion

        #region Item Managers
        const Int16 HandleId = 99;
        class DropItemPacket : MessageBase
        {
            public GameObject Player;
            public ItemIndex ItemIndex;
            public override void Serialize(NetworkWriter writer)
            {
                writer.Write(Player);
                writer.Write((UInt16)ItemIndex);
            }

            public override void Deserialize(NetworkReader reader)
            {
                Player = reader.ReadGameObject();
                ItemIndex = (ItemIndex)reader.ReadUInt16();
            }
        }
        class DropEquipmentPacket : MessageBase
        {
            public GameObject Player;
            public EquipmentIndex EquipmentIndex;
            public override void Serialize(NetworkWriter writer)
            {
                writer.Write(Player);
                writer.Write((UInt16)EquipmentIndex);
            }

            public override void Deserialize(NetworkReader reader)
            {
                Player = reader.ReadGameObject();
                EquipmentIndex = (EquipmentIndex)reader.ReadUInt16();
            }
        }
        static void SendDropItem(GameObject player, ItemIndex itemIndex)
        {
            NetworkServer.SendToAll(HandleId, new DropItemPacket
            {
                Player = player,
                ItemIndex = itemIndex
            });
        }
        static void SendDropEquipment(GameObject player, EquipmentIndex equipmentIndex)
        {
            NetworkServer.SendToAll(HandleId, new DropEquipmentPacket
            {
                Player = player,
                EquipmentIndex = equipmentIndex
            });
        }
        [RoR2.Networking.NetworkMessageHandler(msgType = HandleId, client = true)]
        static void HandleDropItem(NetworkMessage netMsg)
        {
            var dropItem = netMsg.ReadMessage<DropItemPacket>();
            var body = dropItem.Player.GetComponent<CharacterBody>();
            /*if (isDropItems)
                body.inventory.RemoveItem(dropItem.ItemIndex, 1);
            if (isDropItemForAll && !isDropItems)*/
            PickupDropletController.CreatePickupDroplet(PickupCatalog.FindPickupIndex(dropItem.ItemIndex), body.transform.position + Vector3.up * 1.5f, Vector3.up * 20f + body.transform.forward * 2f);
        }
        static void HandleDropEquipment(NetworkMessage netMsg)
        {
            var dropEquipment = netMsg.ReadMessage<DropEquipmentPacket>();
            var body = dropEquipment.Player.GetComponent<CharacterBody>();
            /*if (isDropItems)
                body.inventory.RemoveItem(dropItem.ItemIndex, 1);
            if (isDropItemForAll && !isDropItems)*/
            PickupDropletController.CreatePickupDroplet(PickupCatalog.FindPickupIndex(dropEquipment.EquipmentIndex), body.transform.position + Vector3.up * 1.5f, Vector3.up * 20f + body.transform.forward * 2f);
        }

        public static void DropItemMethod(ItemIndex itemIndex)
        {
            var user = RoR2.LocalUserManager.GetFirstLocalUser();
            var networkClient = NetworkClient.allClients.FirstOrDefault();
            if (networkClient != null)
            {
                networkClient.RegisterHandlerSafe(HandleId, HandleDropItem);
            }
            SendDropItem(user.cachedBody.gameObject, itemIndex);
        }

        public static void DropEquipmentMethod(EquipmentIndex equipmentIndex)
        {
            var user = RoR2.LocalUserManager.GetFirstLocalUser();
            var networkClient = NetworkClient.allClients.FirstOrDefault();
            if (networkClient != null)
            {
                networkClient.RegisterHandlerSafe(HandleId, HandleDropEquipment);
            }
            SendDropEquipment(user.cachedBody.gameObject, equipmentIndex);
        }

        //clears inventory, duh.
        public static void ClearInventory()
        {
            if (LocalPlayerInv)
            {
                //Loops through every item in ItemIndex enum
                foreach (string itemName in Enum.GetNames(typeof(ItemIndex)))
                {
                    ItemIndex itemIndex = (ItemIndex)Enum.Parse(typeof(ItemIndex), itemName); //Convert itemName string to and ItemIndex
                    LocalPlayerInv.ResetItem(itemIndex); int itemCount = LocalPlayerInv.GetItemCount(itemIndex);
                    //If an item exists, delete the whole stack of it
                    if (itemCount >= 0) // Just > doesnt delete from top bar
                    {
                        LocalPlayerInv.RemoveItem(itemIndex, itemCount); LocalPlayerInv.ResetItem(itemIndex);
                        LocalPlayerInv.itemAcquisitionOrder.Remove(itemIndex);

                        //Destroys BeetleGuardAllies on inventory clear, other wise they dont get removed until next stage.
                        //TODO: Find a way to refresh UI/Remove beetle guard health from ui on the left
                        if (itemName == "BeetleGland")
                        {
                            var localUser = RoR2.LocalUserManager.GetFirstLocalUser();
                            var controller = localUser.cachedMasterController;
                            if (!controller)
                            {
                                return;
                            }
                            var body = controller.master.GetBody();
                            if (!body)
                            {
                                return;
                            }
                            var bullseyeSearch = new RoR2.BullseyeSearch();
                            bullseyeSearch.filterByLoS = false;
                            bullseyeSearch.maxDistanceFilter = float.MaxValue;
                            bullseyeSearch.maxAngleFilter = float.MaxValue;
                            bullseyeSearch.RefreshCandidates();
                            var hurtBoxList = bullseyeSearch.GetResults();
                            foreach (var hurtbox in hurtBoxList)
                            {
                                var mob = HurtBox.FindEntityObject(hurtbox);
                                string mobName = mob.name.Replace("Body(Clone)", "");
                                if (mobName == "BeetleGuardAlly")
                                {
                                    UnityEngine.GameObject.Destroy(mob);
                                }
                            }
                        }
                    }
                }
                LocalPlayerInv.SetEquipmentIndex(EquipmentIndex.None);
            }
        }

        // random items
        public static void RollItems(string ammount)
        {
            try
            {
                int num;
                TextSerialization.TryParseInvariant(ammount, out num);
                if (num > 0)
                {
                    WeightedSelection<List<PickupIndex>> weightedSelection = new WeightedSelection<List<PickupIndex>>(8);
                    weightedSelection.AddChoice(Run.instance.availableTier1DropList, 80f);
                    weightedSelection.AddChoice(Run.instance.availableTier2DropList, 19f);
                    weightedSelection.AddChoice(Run.instance.availableTier3DropList, 1f);
                    for (int i = 0; i < num; i++)
                    {
                        List<PickupIndex> list = weightedSelection.Evaluate(UnityEngine.Random.value);
                        LocalPlayerInv.GiveItem(list[UnityEngine.Random.Range(0, list.Count)].itemIndex, 1);
                    }
                }
            }
            catch (ArgumentException)
            {
            }
        }

        public static void GiveAllItems()
        {
            if (LocalPlayerInv)
            {
                foreach (string itemName in Enum.GetNames(typeof(ItemIndex)))
                {
                    //plantonhit kills you when you pick it up
                    if (itemName == "PlantOnHit" || itemName == "HealthDecay" || itemName == "TonicAffliction" || itemName == "BurnNearby" || itemName == "CrippleWardOnLevel" || itemName == "Ghost" || itemName == "ExtraLifeConsumed")
                        continue;
                    ItemIndex itemIndex = (ItemIndex)Enum.Parse(typeof(ItemIndex), itemName);
                    LocalPlayerInv.GiveItem(itemIndex, allItemsQuantity);
                }
            }
        }

        public static void StackInventory()
        {
            //Does the same thing as the shrine of order. Orders all your items into stacks of several random items.
            LocalPlayerInv.ShrineRestackInventory(Run.instance.runRNG);
        }

        public static void GiveItem(GUIStyle buttonStyle, string buttonName)
        {
            //Removes null items and no icon items from item list. Might change if requested.
            string[] unreleasedItems = { "AACannon", "PlasmaCore", "LevelBonus", "CooldownOnCrit", "PlantOnHit", "MageAttunement", "BoostHp", "BoostDamage", "CritHeal", "BurnNearby", "CrippleWardOnLevel", "ExtraLifeConsumed", "Ghost", "HealthDecay", "DrizzlePlayerHelper", "MonsoonPlayerHelper", "TempestOnKill", "Count" };
            int buttonPlacement = 1;
            foreach (string itemName in Enum.GetNames(typeof(ItemIndex)))
            {
                bool unreleasedullItem = unreleasedItems.Any(itemName.Contains);
                if (!unreleasedullItem)
                {
                    if (GUI.Button(btn.BtnRect(buttonPlacement, false, buttonName), itemName, buttonStyle))
                    {
                        ItemIndex itemIndex = (ItemIndex)Enum.Parse(typeof(ItemIndex), itemName);
                        var localUser = LocalUserManager.GetFirstLocalUser();
                        if (localUser.cachedMasterController && localUser.cachedMasterController.master)
                        {
                            if (isDropItemForAll)
                            {
                                DropItemMethod(itemIndex);
                            }
                            else
                            {
                                LocalPlayerInv.GiveItem(itemIndex, 1);
                            }
                        }
                    }
                    buttonPlacement++;
                }
                //Since "Ghost" is unreleased item, "GhostOnKill" was getting removed from item list.
                else if (itemName == "GhostOnKill")
                {
                    if (GUI.Button(btn.BtnRect(buttonPlacement, false, buttonName), itemName, buttonStyle))
                    {
                        ItemIndex itemIndex = (ItemIndex)Enum.Parse(typeof(ItemIndex), itemName);
                        var localUser = LocalUserManager.GetFirstLocalUser();
                        if (localUser.cachedMasterController && localUser.cachedMasterController.master)
                        {
                            if (isDropItemForAll)
                            {
                                DropItemMethod(itemIndex);
                            }
                            else
                            {
                                LocalPlayerInv.GiveItem(itemIndex, 1);
                            }
                        }
                    }
                    buttonPlacement++;
                }
            }
        }

        public static void GiveEquipment(GUIStyle buttonStyle, string buttonName)
        {
            //Removes null equipment and no icon equipment from item list. Might change if requested.
            string[] unreleasedEquipment = { "SoulJar", "AffixYellow", "AffixGold", "GhostGun", "OrbitalLaser", "Enigma", "LunarPotion", "SoulCorruptor", "Count" };
            int buttonPlacement = 1;
            foreach (string equipmentName in Enum.GetNames(typeof(EquipmentIndex)))
            {
                bool unreleasedullEquipment = unreleasedEquipment.Any(equipmentName.Contains);
                if (!unreleasedullEquipment)
                {
                    if (GUI.Button(btn.BtnRect(buttonPlacement, false, buttonName), equipmentName, buttonStyle))
                    {
                        EquipmentIndex equipmentIndex = (EquipmentIndex)Enum.Parse(typeof(EquipmentIndex), equipmentName);
                        var localUser = LocalUserManager.GetFirstLocalUser();
                        if (localUser.cachedMasterController && localUser.cachedMasterController.master)
                        {
                            if (isDropItemForAll)
                            {
                                DropEquipmentMethod(equipmentIndex);
                            }
                            else
                            {
                                LocalPlayerInv.SetEquipmentIndex(equipmentIndex);
                            }

                        }
                    }
                    buttonPlacement++;
                }
            }
        }

        //Sets equipment cooldown to 0 if its on cooldown
        public static void NoEquipmentCooldown()
        {
            EquipmentState equipment = LocalPlayerInv.GetEquipment((uint)LocalPlayerInv.activeEquipmentSlot);

            if (equipment.chargeFinishTime != Run.FixedTimeStamp.zero)
            {
                LocalPlayerInv.SetEquipment(new EquipmentState(equipment.equipmentIndex, Run.FixedTimeStamp.zero, equipment.charges), (uint)LocalPlayerInv.activeEquipmentSlot);
            }
        }
        #endregion

        #region Util
        public static Boolean CursorIsVisible()
        {
            foreach (var mpeventSystem in RoR2.UI.MPEventSystem.readOnlyInstancesList)
                if (mpeventSystem.isCursorVisible)
                    return true;
            return false;
        }
        //More posibilities here using console.
        //Not added to ui yet.
        public static void BanPlayer(NetworkUser PlayerName, NetworkUser LocalNetworkUser)
        {
            Console.instance.RunClientCmd(LocalNetworkUser, "ban_steam", new string[] { PlayerName.Network_id.steamId.ToString() });
        }

        //Kicks player
        public static void KickPlayer(NetworkUser PlayerName, NetworkUser LocalNetworkUser)
        {
            Console.instance.RunClientCmd(LocalNetworkUser, "kick_steam", new string[] { PlayerName.Network_id.steamId.ToString() });
        }

        public static NetworkUser GetNetUserFromString(string playerString)
        {
            if (playerString != "")
            {
                if (int.TryParse(playerString, out int result))
                {
                    if (result < NetworkUser.readOnlyInstancesList.Count && result >= 0)
                    {
                        return NetworkUser.readOnlyInstancesList[result];
                    }
                    return null;
                }
                else
                {
                    foreach (NetworkUser n in NetworkUser.readOnlyInstancesList)
                    {
                        if (n.userName.Equals(playerString, StringComparison.CurrentCultureIgnoreCase))
                        {
                            return n;
                        }
                    }
                    return null;
                }
            }
            return null;
        }

        public static void GetPlayers(string[] Players)
        {
            NetworkUser n;
            for (int i = 0; i < NetworkUser.readOnlyInstancesList.Count; i++)
            {
                n = NetworkUser.readOnlyInstancesList[i];

                Players[i] = n.userName;
            }
        }
        //Reset menu when you return to main menu
        public static void RESETMENU()
        {
            _ifDragged = false;
            _CharacterCollected = false;
            _isStatMenuOpen = false;
            _isTeleMenuOpen = false;
            _isESPMenuOpen = false;
            _ItemToggle = false;
            _CharacterToggle = false;
            _isLobbyMenuOpen = false;
            _isEditStatsOpen = false;
            _isItemSpawnMenuOpen = false;
            _isPlayerMod = false;
            _isEquipmentSpawnMenuOpen = false;
            _isBuffMenuOpen = false;
            _isItemManagerOpen = false;
            damageToggle = false;
            noEquipmentCooldown = false;
            critToggle = false;
            skillToggle = false;
            renderInteractables = false;
            renderMobs = false;
            attackSpeedToggle = false;
            armorToggle = false;
            regenToggle = false;
            moveSpeedToggle = false;
            godToggle = false;
            FlightToggle = false;
            isDropItemForAll = false;
            alwaysSprint = false;
            aimBot = false;
        }
        //Soft reset when moving to next stage to keep player stat mods and god mode between stages
        public static void SoftResetMenu()
        {
            _isMenuOpen = !_isMenuOpen;
            GetCharacter();
            _isMenuOpen = !_isMenuOpen;
            godToggle = !godToggle;
            GetCharacter();
            godToggle = !godToggle;

        }

        public static void UnlockAll()
        {
            //Goes through resource file containing all unlockables... Easily updatable, just paste "RoR2.UnlockCatalog" and GetAllUnlockable does the rest.
            //This is needed to unlock logs
            foreach (var unlockableName in unlockableNames)
            {
                var unlockableDef = UnlockableCatalog.GetUnlockableDef(unlockableName);
                NetworkUser networkUser = Util.LookUpBodyNetworkUser(LocalPlayerBody);
                if (networkUser)
                {
                    networkUser.ServerHandleUnlock(unlockableDef);
                }
            }

            //Gives all achievements.
            var achievementManager = AchievementManager.GetUserAchievementManager(LocalUserManager.GetFirstLocalUser());
            foreach (var achievement in AchievementManager.allAchievementDefs)
            {
                achievementManager.GrantAchievement(achievement);
            }

            //Give all survivors
            var profile = LocalUserManager.GetFirstLocalUser().userProfile;
            foreach (var survivor in SurvivorCatalog.allSurvivorDefs)
            {
                if (profile.statSheet.GetStatValueDouble(RoR2.Stats.PerBodyStatDef.totalTimeAlive, survivor.bodyPrefab.name) == 0.0)
                    profile.statSheet.SetStatValueFromString(RoR2.Stats.PerBodyStatDef.totalTimeAlive.FindStatDef(survivor.bodyPrefab.name), "0.1");
            }

            //All items and equipments
            foreach (string itemName in Enum.GetNames(typeof(ItemIndex)))
            {
                ItemIndex itemIndex = (ItemIndex)Enum.Parse(typeof(ItemIndex), itemName);
                profile.DiscoverPickup(PickupCatalog.FindPickupIndex(itemIndex));
            }

            foreach (string equipmentName in Enum.GetNames(typeof(EquipmentIndex)))
            {
                EquipmentIndex equipmentIndex = (EquipmentIndex)Enum.Parse(typeof(EquipmentIndex), equipmentName);
                profile.DiscoverPickup(PickupCatalog.FindPickupIndex(equipmentIndex));
            }
        }
        public static List<string> GetAllUnlockables()
        {
            var unlockableName = new List<string>();

            var assembly = Assembly.GetExecutingAssembly();
            var resourceName = "RoRCheats.Resources.Unlockables.txt";

            Stream stream = assembly.GetManifestResourceStream(resourceName);
            StreamReader reader = new StreamReader(stream);
            while (!reader.EndOfStream)
            {
                string line1 = reader.ReadLine();
                line1 = line1.Replace("UnlockableCatalog.RegisterUnlockable(\"", "");
                line1 = line1.Replace("\", new UnlockableDef", "");
                line1 = line1.Replace("true", "");
                line1 = line1.Replace("});", "");
                line1 = line1.Replace("=", "");
                line1 = line1.Replace("\"", "");
                line1 = line1.Replace("false", "");
                line1 = line1.Replace(",", "");
                line1 = line1.Replace("hidden", "");
                line1 = line1.Replace("{", "");
                line1 = line1.Replace("nameToken", "");
                line1 = line1.Replace(" ", "");
                string[] lineArray = line1.Split(null);
                foreach (var line in lineArray)
                {
                    //TODO: Simplify later
                    if (line.StartsWith("Logs.") || line.StartsWith("Characters.") || line.StartsWith("Items.") || line.StartsWith("Skills.") || line.StartsWith("Skins.") || line.StartsWith("Shop.") || line.StartsWith("Artifacts.") || line.StartsWith("NewtStatue."))
                    {
                        unlockableName.Add(line);
                    }
                }
            }
            return unlockableName;
        }

        // Used during testing and debugging
        public static void WriteToLog(string logContent)
        {
            string docPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            using (StreamWriter outputFile = new StreamWriter(System.IO.Path.Combine(docPath, "UmbraLog.txt"), true))
            {
                outputFile.WriteLine(log + logContent);
            }
        }
        #endregion
    }
}
