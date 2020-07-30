// TODO LIST
/*
Add filters to ESPs?
Make ESP less laggy??
Clear Items despawn beatle guards from UI
*/

// On Risk of Rain 2 Update: Update Unlockables.txt, Update Unreleased items list if needed
// On Menu update, Update Version Variable and ffs Update Assembly Version...
// When Adding A Button To A Menu, Update Menu Value Range in Navigation.UpdateIndexValues
using System;
using System.Collections.Generic;
using UnityEngine;
using RoR2;
using UnityEngine.SceneManagement;
using System.Linq;

namespace UmbraRoR
{
    public class Main : MonoBehaviour
    {
        public const string
            NAME = "U M B R A",
            VERSION = "1.2.6";

        public static string log = "[" + NAME + "] ";

        // Used to unlock all items
        public static List<string> unlockableNames = Utility.GetAllUnlockables();

        // These Values are needed for navigation to create Enumerable and indexable values with the items I've excluded
        public static List<GameObject> bodyPrefabs = Utility.GetBodyPrefabs();
        public static List<EquipmentIndex> equipment = Utility.GetEquipment();
        public static List<ItemIndex> items = Utility.GetItems();
        public static List<SpawnCard> spawnCards = Utility.GetSpawnCards();

        // Used for RollItems
        public static WeightedSelection<List<ItemIndex>> weightedSelection = ItemManager.BuildRollItemsDropTable();

        // Used to make sure navigation intraMenuIndex doesnt go over when in the lobby management menu
        public static int numberOfPlayers;

        public static List<bool> menuBools = new List<bool>() { _isTeleMenuOpen, _isESPMenuOpen, _isLobbyMenuOpen, _isPlayerMod, _isItemManagerOpen, _isMovementOpen, _isSpawnMenuOpen };
        public static List<bool> menusOpen = new List<bool>();

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
        public static bool _isChangeCharacterMenuOpen = false;
        public static bool _isLobbyMenuOpen = false;
        public static bool _isEditStatsOpen = false;
        public static bool _isItemSpawnMenuOpen = false;
        public static bool _isPlayerMod = false;
        public static bool _isEquipmentSpawnMenuOpen = false;
        public static bool _isBuffMenuOpen = false;
        public static bool _isItemManagerOpen = false;
        public static bool _isMovementOpen = false;
        public static bool _isSpawnListMenuOpen = false;
        public static bool _isSpawnMenuOpen = false;
        public static bool enableRespawnButton = false;
        public static bool inGame = false;
        #endregion

        #region Button Styles / Toggles
        public static GUIStyle MainBgStyle, StatBgSytle, TeleBgStyle, OnStyle, OffStyle, LabelStyle, TitleStyle, BtnStyle, ItemBtnStyle, CornerStyle, DisplayStyle, BgStyle, HighlightBtnStyle, ActiveModsStyle, renderTeleporterStyle, renderMobsStyle, renderInteractablesStyle, WatermarkStyle, StatsStyle;
        public static GUIStyle BtnStyle1, BtnStyle2, BtnStyle3;
        public static bool skillToggle, renderInteractables, renderMobs, damageToggle, critToggle, attackSpeedToggle, armorToggle, regenToggle, moveSpeedToggle, MouseToggle, FlightToggle, listItems, noEquipmentCooldown, listBuffs, aimBot, alwaysSprint, godToggle, unloadConfirm, jumpPackToggle;
        public static bool renderActiveMods = true;
        public static float delay = 0, widthSize = 350;
        public static bool navigationToggle = false;
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
        public static Rect editStatsRect;
        public static Rect movementRect;
        public static Rect spawnListRect;
        public static Rect spawnRect;
        #endregion

        #region Rect Start Position Values
        public static int topY = 10;
        public static int leftX = 10;
        public static int firstRightX = 424;
        public static int secondRightX = 838;
        public static int belowMainY = 290;
        public static int belowTeleY = 660;
        #endregion

        public static Texture2D NewTexture2D { get { return new Texture2D(1, 1); } }
        public static Texture2D Image = null, ontexture, onpresstexture, offtexture, offpresstexture, highlightTexture, highlightPressTexture, cornertexture, backtexture, btntexture, btnpresstexture, btntexturelabel;

        public static int PlayerModBtnY, MainMulY, StatMulY, TeleMulY, ESPMulY, LobbyMulY, itemSpawnerMulY, equipmentSpawnerMulY, buffMenuMulY, CharacterMulY, PlayerModMulY, ItemManagerMulY, ItemManagerBtnY, editStatsMulY, editStatsBtnY, movementMulY, spawnListMulY, spawnMulY, spawnBtnY;
        public static int btnY, mulY;

        public static Rect rect = new Rect(10, 10, 20, 20);
        public Rect dropDownRect = new Rect(10, 10, 20, 20);

        public static string[] Players = new string[16];

        #region On GUI
        private void OnGUI()
        {
            if (Updates.updateAvailable)
            {
                GUI.Label(new Rect(Screen.width - 100, 1f, 100, 50f), $"Umbra Menu (v{VERSION}) <color=grey>-</color> <color=yellow>Lastest (v{Updates.latestVersion})</color>", WatermarkStyle);
            }
            else if (Updates.upToDate)
            {
                GUI.Label(new Rect(Screen.width - 100, 1f, 100, 50f), $"Umbra Menu (v{VERSION})", WatermarkStyle);
            }
            else if (Updates.devBuild)
            {
                GUI.Label(new Rect(Screen.width - 100, 1f, 100, 50f), $"Umbra Menu (v{VERSION}) <color=grey>-</color> <color=yellow>Dev Build</color>", WatermarkStyle);
            }

            #region GenerateMenus
            mainRect = GUI.Window(0, mainRect, new GUI.WindowFunction(SetMainBG), "", new GUIStyle());
            if (_isMenuOpen)
            {
                DrawAllMenus();
            }
            if (_isStatMenuOpen)
            {
                statRect = GUI.Window(1, statRect, new GUI.WindowFunction(SetStatsBG), "", new GUIStyle());
                DrawMenu.DrawStatsMenu(statRect.x, statRect.y, widthSize, StatMulY, MainBgStyle, StatsStyle, LabelStyle);
            }
            if (_isTeleMenuOpen)
            {
                teleRect = GUI.Window(2, teleRect, new GUI.WindowFunction(SetTeleBG), "", new GUIStyle());
                DrawMenu.DrawTeleMenu(teleRect.x, teleRect.y, widthSize, TeleMulY, MainBgStyle, BtnStyle, LabelStyle);
                // Debug.Log("X : " + teleRect.x + " Y : " + teleRect.y);
            }
            if (_isESPMenuOpen)
            {
                ESPRect = GUI.Window(3, ESPRect, new GUI.WindowFunction(SetESPBG), "", new GUIStyle());
                DrawMenu.DrawESPMenu(ESPRect.x, ESPRect.y, widthSize, ESPMulY, MainBgStyle, BtnStyle, OnStyle, OffStyle, LabelStyle);
                // Debug.Log("X : " + ESPRect.x + " Y : " + ESPRect.y);
            }
            if (_isLobbyMenuOpen)
            {
                lobbyRect = GUI.Window(4, lobbyRect, new GUI.WindowFunction(SetLobbyBG), "", new GUIStyle());
                DrawMenu.DrawLobbyMenu(lobbyRect.x, lobbyRect.y, widthSize, LobbyMulY, MainBgStyle, BtnStyle, LabelStyle);
                // Debug.Log("X : " + lobbyRect.x + " Y : " + lobbyRect.y);
            }
            if (_isItemSpawnMenuOpen)
            {
                itemSpawnerRect = GUI.Window(5, itemSpawnerRect, new GUI.WindowFunction(SetItemSpawnerBG), "", new GUIStyle());
                DrawMenu.DrawItemMenu(itemSpawnerRect.x, itemSpawnerRect.y, widthSize, itemSpawnerMulY, MainBgStyle, BtnStyle, LabelStyle);
                // Debug.Log("X : " + itemSpawnerRect.x + " Y : " + itemSpawnerRect.y);
            }
            if (_isPlayerMod)
            {
                playerModRect = GUI.Window(6, playerModRect, new GUI.WindowFunction(SetPlayerModBG), "", new GUIStyle());
                DrawMenu.DrawPlayerModMenu(playerModRect.x, playerModRect.y, widthSize, PlayerModMulY, MainBgStyle, BtnStyle, OnStyle, OffStyle, LabelStyle);
                // Debug.Log("X : " + playerModRect.x + " Y : " + playerModRect.y);
            }
            if (_isEquipmentSpawnMenuOpen)
            {
                equipmentSpawnerRect = GUI.Window(7, equipmentSpawnerRect, new GUI.WindowFunction(SetEquipmentBG), "", new GUIStyle());
                DrawMenu.DrawEquipmentMenu(equipmentSpawnerRect.x, equipmentSpawnerRect.y, widthSize, equipmentSpawnerMulY, MainBgStyle, BtnStyle, LabelStyle, OffStyle);
                // Debug.Log("X : " + equipmentSpawnerRect.x + " Y : " + equipmentSpawnerRect.y);
            }
            if (_isBuffMenuOpen)
            {
                buffMenuRect = GUI.Window(8, buffMenuRect, new GUI.WindowFunction(SetBuffBG), "", new GUIStyle());
                DrawMenu.DrawBuffMenu(buffMenuRect.x, buffMenuRect.y, widthSize, buffMenuMulY, MainBgStyle, BtnStyle, LabelStyle, OffStyle);
            }
            if (_isChangeCharacterMenuOpen)
            {
                characterRect = GUI.Window(9, characterRect, new GUI.WindowFunction(SetCharacterBG), "", new GUIStyle());
                DrawMenu.CharacterWindowMethod(characterRect.x, characterRect.y, widthSize, CharacterMulY, MainBgStyle, BtnStyle, LabelStyle);
                // Debug.Log("X : " + characterRect.x + " Y : " + characterRect.y);
            }
            if (_isItemManagerOpen)
            {
                itemManagerRect = GUI.Window(10, itemManagerRect, new GUI.WindowFunction(SetItemManagerBG), "", new GUIStyle());
                DrawMenu.DrawItemManagementMenu(itemManagerRect.x, itemManagerRect.y, widthSize, ItemManagerMulY, MainBgStyle, BtnStyle, OnStyle, OffStyle, LabelStyle);
                // Debug.Log("X : " + itemManagerRect.x + " Y : " + itemManagerRect.y);
            }
            if (_isEditStatsOpen)
            {
                editStatsRect = GUI.Window(11, editStatsRect, new GUI.WindowFunction(SetEditStatBG), "", new GUIStyle());
                DrawMenu.DrawStatsModMenu(editStatsRect.x, editStatsRect.y, widthSize, editStatsMulY, MainBgStyle, BtnStyle, OnStyle, OffStyle, LabelStyle);
                // Debug.Log("X : " + editStatsRect.x + " Y : " + editStatsRect.y);
            }
            if (_isMovementOpen)
            {
                movementRect = GUI.Window(12, movementRect, new GUI.WindowFunction(SetMovementBG), "", new GUIStyle());
                DrawMenu.DrawMovementMenu(movementRect.x, movementRect.y, widthSize, movementMulY, MainBgStyle, BtnStyle, OnStyle, OffStyle, LabelStyle);
                // Debug.Log("X : " + movementRect.x + " Y : " + movementRect.y);
            }
            if (_isSpawnMenuOpen)
            {
                spawnRect = GUI.Window(13, spawnRect, new GUI.WindowFunction(SetSpawnBG), "", new GUIStyle());
                DrawMenu.DrawSpawnMenu(spawnRect.x, spawnRect.y, widthSize, spawnMulY, MainBgStyle, BtnStyle, OnStyle, OffStyle, LabelStyle);
            }
            if (_isSpawnListMenuOpen)
            {
                spawnListRect = GUI.Window(14, spawnListRect, new GUI.WindowFunction(SetSpawnListBG), "", new GUIStyle());
                DrawMenu.DrawSpawnMobMenu(spawnListRect.x, spawnListRect.y, widthSize, spawnListMulY, MainBgStyle, BtnStyle, LabelStyle);
            }
            if (_CharacterCollected)
            {
                ESPRoutine();
            }
            #endregion
        }
        #endregion On GUI

        #region Start
        public void Start()
        {
            SceneManager.sceneLoaded += OnSceneLoaded;

            #region CondenseMenuValues
            if (Screen.height > 1080)
            {
                mainRect = new Rect(10, 10, 20, 20); // start position
                playerModRect = new Rect(374, 10, 20, 20); // start position
                movementRect = new Rect(374, 560, 20, 20); // start position
                itemManagerRect = new Rect(738, 10, 20, 20); // start positions
                teleRect = new Rect(10, 425, 20, 20); // start position
                ESPRect = new Rect(10, 795, 20, 20); // start position
                lobbyRect = new Rect(10, 985, 20, 20); // start position
                spawnRect = new Rect(738, 470, 20, 20); // start position

                statRect = new Rect(1626, 457, 20, 20); // start position

                spawnListRect = new Rect(1503, 10, 20, 20); // start position
                itemSpawnerRect = new Rect(1503, 10, 20, 20); // start position
                equipmentSpawnerRect = new Rect(1503, 10, 20, 20); // start positions
                buffMenuRect = new Rect(1503, 10, 20, 20); // start position
                characterRect = new Rect(1503, 10, 20, 20); // start position
                editStatsRect = new Rect(1503, 10, 20, 20); // start position
            }
            else
            {
                mainRect = new Rect(10, 10, 20, 20); // start position
                playerModRect = new Rect(374, 10, 20, 20); // start position
                movementRect = new Rect(374, 560, 20, 20); // start position
                itemManagerRect = new Rect(738, 10, 20, 20); // start positions
                teleRect = new Rect(10, 425, 20, 20); // start position
                ESPRect = new Rect(10, 795, 20, 20); // start position
                lobbyRect = new Rect(374, 750, 20, 20); // start position
                spawnRect = new Rect(738, 470, 20, 20); // start position

                statRect = new Rect(1626, 457, 20, 20); // start position

                spawnListRect = new Rect(1503, 10, 20, 20);// start position
                itemSpawnerRect = new Rect(1503, 10, 20, 20); // start position
                equipmentSpawnerRect = new Rect(1503, 10, 20, 20); // start positions
                buffMenuRect = new Rect(1503, 10, 20, 20); // start position
                characterRect = new Rect(1503, 10, 20, 20); // start position
                editStatsRect = new Rect(1503, 10, 20, 20); // start position
            }

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
                MainBgStyle.fontSize = 15;
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

            if (StatsStyle == null)
            {
                StatsStyle = new GUIStyle();
                StatsStyle.normal.textColor = Color.grey;
                StatsStyle.onNormal.textColor = Color.grey;
                StatsStyle.active.textColor = Color.grey;
                StatsStyle.onActive.textColor = Color.grey;
                StatsStyle.fontSize = 18;
                StatsStyle.fontStyle = FontStyle.Normal;
                StatsStyle.alignment = TextAnchor.MiddleLeft;
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

            if (ActiveModsStyle == null)
            {
                ActiveModsStyle = new GUIStyle();
                ActiveModsStyle.normal.textColor = Color.HSVToRGB(0.5256f, 0.9286f, 0.9333f);
                ActiveModsStyle.onNormal.textColor = Color.HSVToRGB(0.5256f, 0.9286f, 0.9333f);
                ActiveModsStyle.active.textColor = Color.HSVToRGB(0.5256f, 0.9286f, 0.9333f);
                ActiveModsStyle.onActive.textColor = Color.HSVToRGB(0.5256f, 0.9286f, 0.9333f);
                ActiveModsStyle.fontSize = 20;
                ActiveModsStyle.wordWrap = true;
                ActiveModsStyle.fontStyle = FontStyle.Normal;
                ActiveModsStyle.alignment = TextAnchor.MiddleLeft;
            }

            if (renderInteractablesStyle == null)
            {
                renderInteractablesStyle = new GUIStyle();
                renderInteractablesStyle.normal.textColor = Color.green;
                renderInteractablesStyle.onNormal.textColor = Color.green;
                renderInteractablesStyle.active.textColor = Color.green;
                renderInteractablesStyle.onActive.textColor = Color.green;
                renderInteractablesStyle.fontStyle = FontStyle.Normal;
                renderInteractablesStyle.alignment = TextAnchor.MiddleLeft;
            }

            if (renderTeleporterStyle == null)
            {
                renderTeleporterStyle = new GUIStyle
                {
                    fontStyle = FontStyle.Normal,
                    alignment = TextAnchor.MiddleLeft
                };
            }

            if (renderMobsStyle == null)
            {
                renderMobsStyle = new GUIStyle();
                renderMobsStyle.normal.textColor = Color.red;
                renderMobsStyle.onNormal.textColor = Color.red;
                renderMobsStyle.active.textColor = Color.red;
                renderMobsStyle.onActive.textColor = Color.red;
                renderMobsStyle.fontStyle = FontStyle.Normal;
                renderMobsStyle.alignment = TextAnchor.MiddleLeft;
            }

            if (WatermarkStyle == null)
            {
                WatermarkStyle = new GUIStyle();
                WatermarkStyle.normal.textColor = Color.HSVToRGB(0.5256f, 0.9286f, 0.9333f);
                WatermarkStyle.onNormal.textColor = Color.HSVToRGB(0.5256f, 0.9286f, 0.9333f);
                WatermarkStyle.active.textColor = Color.HSVToRGB(0.5256f, 0.9286f, 0.9333f);
                WatermarkStyle.onActive.textColor = Color.HSVToRGB(0.5256f, 0.9286f, 0.9333f);
                WatermarkStyle.fontSize = 14;
                WatermarkStyle.fontStyle = FontStyle.Normal;
                WatermarkStyle.alignment = TextAnchor.MiddleRight;
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
                OffStyle.fontSize = 15;
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
                OnStyle.fontSize = 15;
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
                BtnStyle.fontSize = 15;
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
                ItemBtnStyle.fontSize = 15;
                ItemBtnStyle.fontStyle = FontStyle.Normal;
                ItemBtnStyle.alignment = TextAnchor.MiddleCenter;
            }
            if (HighlightBtnStyle == null)
            {
                HighlightBtnStyle = new GUIStyle();
                HighlightBtnStyle.normal.background = highlightTexture;
                HighlightBtnStyle.onNormal.background = highlightTexture;
                HighlightBtnStyle.active.background = highlightPressTexture;
                HighlightBtnStyle.onActive.background = highlightPressTexture;
                HighlightBtnStyle.normal.textColor = Color.HSVToRGB(0.5256f, 0.9286f, 0.9333f);
                HighlightBtnStyle.onNormal.textColor = Color.HSVToRGB(0.5256f, 0.9286f, 0.9333f);
                HighlightBtnStyle.active.textColor = Color.HSVToRGB(0.5256f, 0.9286f, 0.9333f);
                HighlightBtnStyle.onActive.textColor = Color.HSVToRGB(0.5256f, 0.9286f, 0.9333f);
                HighlightBtnStyle.fontSize = 15;
                HighlightBtnStyle.fontStyle = FontStyle.Normal;
                HighlightBtnStyle.alignment = TextAnchor.MiddleCenter;
            }
            #endregion
        }
        #endregion Start

        #region Update
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
                JumpPackRoutine();
                AimBotRoutine();
                GodRoutine();
                UpdateNavIndexRoutine();
                // UpdateMenuPositions();
            }
            catch (NullReferenceException)
            {

            }
        }
        #endregion Update

        #region Inputs
        private void CheckInputs()
        {
            if (_isMenuOpen)
            {
                Cursor.visible = true;
                if (_CharacterCollected)
                {
                    if (Input.GetKeyDown(KeyCode.DownArrow))
                    {
                        if (!navigationToggle)
                        {
                            Utility.CloseAllMenus();
                        }

                        navigationToggle = true;
                        Navigation.intraMenuIndex++;
                    }
                    if (Input.GetKeyDown(KeyCode.UpArrow))
                    {
                        if (!navigationToggle)
                        {
                            Utility.CloseAllMenus();
                        }

                        navigationToggle = true;
                        Navigation.intraMenuIndex--;
                    }
                }
                if (navigationToggle)
                {
                    if (Input.GetKeyDown(KeyCode.V))
                    {
                        int oldMenuIndex = (int)Navigation.menuIndex;
                        Navigation.PressBtn(Navigation.menuIndex, Navigation.intraMenuIndex);
                        int newMenuIndex = (int)Navigation.menuIndex;

                        if (oldMenuIndex != newMenuIndex)
                        {
                            Navigation.intraMenuIndex = 0;
                        }
                    }
                    if (Input.GetKeyDown(KeyCode.RightArrow))
                    {
                        bool playerPlusMinusBtn = Navigation.menuIndex == 1 && Enumerable.Range(0, 3).Contains(Navigation.intraMenuIndex);
                        bool statsPlusMinusBtn = Navigation.menuIndex == 1.3f && Enumerable.Range(0, 5).Contains(Navigation.intraMenuIndex);
                        bool itemPlusMinusBtn = Navigation.menuIndex == 3 && Enumerable.Range(0, 2).Contains(Navigation.intraMenuIndex);
                        bool spawnPlusMinusBtn = Navigation.menuIndex == 4 && Enumerable.Range(0, 3).Contains(Navigation.intraMenuIndex);
                        if (playerPlusMinusBtn || itemPlusMinusBtn || statsPlusMinusBtn || spawnPlusMinusBtn)
                        {
                            Navigation.IncreaseValue(Navigation.menuIndex, Navigation.intraMenuIndex);
                        }
                        else
                        {
                            float oldMenuIndex = Navigation.menuIndex;
                            Navigation.PressBtn(Navigation.menuIndex, Navigation.intraMenuIndex);
                            float newMenuIndex = Navigation.menuIndex;

                            if (oldMenuIndex != newMenuIndex)
                            {
                                Navigation.intraMenuIndex = 0;
                            }
                        }
                    }
                    if (Input.GetKeyDown(KeyCode.LeftArrow))
                    {
                        bool playerPlusMinusBtn = Navigation.menuIndex == 1 && Enumerable.Range(0, 3).Contains(Navigation.intraMenuIndex);
                        bool statsPlusMinusBtn = Navigation.menuIndex == 1.3f && Enumerable.Range(0, 5).Contains(Navigation.intraMenuIndex);
                        bool itemPlusMinusBtn = Navigation.menuIndex == 3 && Enumerable.Range(0, 2).Contains(Navigation.intraMenuIndex);
                        bool spawnPlusMinusBtn = Navigation.menuIndex == 4 && Enumerable.Range(0, 3).Contains(Navigation.intraMenuIndex);
                        if (playerPlusMinusBtn || itemPlusMinusBtn || statsPlusMinusBtn || spawnPlusMinusBtn)
                        {
                            Navigation.DecreaseValue(Navigation.menuIndex, Navigation.intraMenuIndex);
                        }
                        else
                        {
                            Navigation.GoBackAMenu();
                        }
                    }
                    if (Input.GetKeyDown(KeyCode.Backspace))
                    {
                        Navigation.GoBackAMenu();
                    }
                }
            }
            else if (!_isMenuOpen)
            {
                navigationToggle = false;
                Navigation.intraMenuIndex = -1;
                Navigation.menuIndex = 0;
                Cursor.visible = false;
            }
            if (Input.GetKeyDown(KeyCode.Insert))
            {
                unloadConfirm = false;
                numberOfPlayers = Utility.NumberOfPlayers();
                spawnCards = Utility.GetSpawnCards();
                if (_isMenuOpen && navigationToggle)
                {
                    Utility.CloseAllMenus();
                }
                _isMenuOpen = !_isMenuOpen;
                GetCharacter();
                SceneManager.sceneLoaded += OnSceneLoaded;
            }
        }
        #endregion Inputs

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
                Render.Interactables();
            }
            if (renderMobs)
            {
                Render.Mobs();
            }
            if (renderActiveMods)
            {
                Render.ActiveMods();
            }
        }

        private void EquipCooldownRoutine()
        {
            if (noEquipmentCooldown)
            {
                ItemManager.NoEquipmentCooldown();
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
                PlayerMod.AimBot();
        }
        private void GodRoutine()
        {
            if (godToggle)
            {
                PlayerMod.GodMode();
            }
            else
            {
                LocalHealth.godMode = false;
            }
        }
        private void SprintRoutine()
        {
            if (alwaysSprint)
                Movement.AlwaysSprint();
        }

        private void FlightRoutine()
        {
            if (FlightToggle)
            {
                Movement.Flight();
            }
        }

        private void ModStatsRoutine()
        {
            if (_CharacterCollected)
            {
                if (damageToggle)
                {
                    PlayerMod.LevelPlayersDamage();
                }
                if (critToggle)
                {
                    PlayerMod.LevelPlayersCrit();
                }
                if (attackSpeedToggle)
                {
                    PlayerMod.SetplayersAttackSpeed();
                }
                if (armorToggle)
                {
                    PlayerMod.SetplayersArmor();
                }
                if (moveSpeedToggle)
                {
                    PlayerMod.SetplayersMoveSpeed();
                }
                LocalPlayerBody.RecalculateStats();
            }
        }

        private void UpdateNavIndexRoutine()
        {
            if (navigationToggle)
            {
                Navigation.UpdateIndexValues();
            }
        }

        private void JumpPackRoutine()
        {
            if (jumpPackToggle)
            {
                Movement.JumpPack();
            }
        }
        #endregion Routines

        #region On Scene Loaded
        public void OnSceneLoaded(Scene scene, LoadSceneMode mode)
        {
            inGame = scene.name != "title" && scene.name != "lobby" && scene.name != "" && scene.name != " ";
            if (!inGame)
            {
                Utility.ResetMenu();
            }
            else
            {
                ModStatsRoutine();
                Utility.SoftResetMenu();
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
                    _isChangeCharacterMenuOpen = !_isChangeCharacterMenuOpen;
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
            GUI.Box(new Rect(0f, 0f, widthSize + 10, 50f + 45 * editStatsMulY), "", CornerStyle);
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

        public static void SetItemSpawnerBG(int windowID)
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

        public static void SetMovementBG(int windowID)
        {
            GUI.Box(new Rect(0f, 0f, widthSize + 10, 50f + 45 * movementMulY), "", CornerStyle);
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
                    _isMovementOpen = !_isMovementOpen;
                }
                _ifDragged = false;
            }
            GUI.DragWindow();
        }

        public static void SetSpawnListBG(int windowID)
        {
            GUI.Box(new Rect(0f, 0f, widthSize + 10, 50f + 45 * spawnListMulY), "", CornerStyle);
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
                    _isSpawnListMenuOpen = !_isSpawnListMenuOpen;
                }
                _ifDragged = false;
            }
            GUI.DragWindow();
        }

        public static void SetSpawnBG(int windowID)
        {
            GUI.Box(new Rect(0f, 0f, widthSize + 10, 50f + 45 * spawnMulY), "", CornerStyle);
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
                    _isSpawnMenuOpen = !_isSpawnMenuOpen;
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

            if (Updates.updateAvailable)
            {
                GUI.Label(new Rect(mainRect.x + 5f, mainRect.y + 5f, widthSize + 5, 85f), $"U M B R A \n<color=yellow>O U T D A T E D</color>", TitleStyle);
            }
            else if (Updates.upToDate)
            {
                GUI.Label(new Rect(mainRect.x + 5f, mainRect.y + 5f, widthSize + 5, 85f), $"U M B R A \n<color=grey>v{VERSION}</color>", TitleStyle);
            }
            else if (Updates.devBuild)
            {
                GUI.Label(new Rect(mainRect.x + 5f, mainRect.y + 5f, widthSize + 5, 85f), $"U M B R A \n<color=yellow>D E V</color>", TitleStyle);
            }

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
                    btntexture.SetPixel(0, 0, new Color32(120, 120, 120, 240));
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
                    btnpresstexture.SetPixel(0, 0, new Color32(99, 99, 99, 240));
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
                    onpresstexture.SetPixel(0, 0, new Color32(50, 50, 50, 240));
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
                    ontexture.SetPixel(0, 0, new Color32(67, 67, 67, 240));
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
                    offpresstexture.SetPixel(0, 0, new Color32(99, 99, 99, 240));
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
                    offtexture.SetPixel(0, 0, new Color32(120, 120, 120, 240));
                    // byte[] FileData = File.ReadAllBytes(Directory.GetCurrentDirectory() + "/BepInEx/plugins/UmbraRoR/Resources/Images/OffStyle.png");
                    // offtexture.LoadImage(FileData);
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
                    //backtexture.SetPixel(0, 0, new Color32(0, 0, 0, 158));
                    backtexture.SetPixel(0, 0, new Color32(0, 0, 0, 120));
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
                    // ToHtmlStringRGBA  new Color(33, 150, 243, 1)
                    cornertexture.SetPixel(0, 0, new Color32(42, 42, 42, 0));

                    cornertexture.Apply();
                }
                return cornertexture;
            }
        }

        public static Texture2D HighlightTexture
        {
            get
            {
                if (highlightTexture == null)
                {
                    highlightTexture = NewTexture2D;
                    highlightTexture.SetPixel(0, 0, new Color32(0, 0, 0, 0));
                    highlightTexture.Apply();
                }
                return highlightTexture;
            }
        }

        public static Texture2D HighlightPressTexture
        {
            get
            {
                if (highlightPressTexture == null)
                {
                    highlightPressTexture = NewTexture2D;
                    highlightPressTexture.SetPixel(0, 0, new Color32(0, 0, 0, 0));
                    highlightPressTexture.Apply();
                }
                return highlightPressTexture;
            }
        }

        #endregion Textures

        #region Get Character
        // try and setup our character, if we hit an error we set it to false
        // TODO: Still tries to collect character after death and returning to lobby/title.
        public static void GetCharacter()
        {
            try
            {
                if (inGame)
                {
                    LocalNetworkUser = null;
                    foreach (NetworkUser readOnlyInstance in NetworkUser.readOnlyInstancesList)
                    {
                        //localplayer is you!
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
        #endregion
    }
}