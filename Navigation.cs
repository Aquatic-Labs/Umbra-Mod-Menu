using RoR2;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace UmbraRoR
{
    class Navigation
    {
        public static float menuIndex = 0;
        public static int intraMenuIndex = -1;
        public static int prevIntraMenuIndex;
        public static float lowResMenuIndex = 0;
        public static float prevLowResMenuIndex = 0;
        public static Tuple<float, int> highlightedBtn = new Tuple<float, int>(menuIndex, intraMenuIndex);

        #region Menu Layout Variables
        public static Dictionary<float, string> MenuList = new Dictionary<float, string>()
        {
            { 0, "Menu" },
            { 1, "Player" },
            { 2, "Movement" },
            { 3, "Item" },
            { 4, "Spawn" },
            { 5, "Teleporter" },
            { 6, "Render" },
            { 7, "Lobby" }
        };

        public static Dictionary<float, string> ExtentionMenuList = new Dictionary<float, string>()
        {
            { 1.1f, "CharacterMenu" },
            { 1.2f, "BuffMenu" },
            { 1.3f, "StatsModMenu"},
            { 3.1f, "ItemMenu" },
            { 3.2f, "EquipMenu" },
            { 4.1f, "SpawnListMenu" }
        };

        public static string[] MainBtnNav = { "PlayerMod", "ItemMang", "Teleporter", "Render", "LobbyMang" };
        public static string[] PlayerBtnNav = { "GiveMoney", "GiveCoin", "GiveXP", "DmgPerLVL", "CritPerLVL", "AttSpeed", "Armor", "MoveSpeed", "CharacterMenu", "Stat", "BuffMenu", "RemoveBuffs", "Aimbot", "GodMode", "NoSkillCD", "UnlockAll" };
        public static string[] StatsBtnNav = { "DmgPerLVL", "CritPerLVL", "AttSpeed", "Armor", "MoveSpeed", "Stat" };
        public static string[] MovementBtnNav = { "AutoSprint", "Flight", "JumpPack" };
        public static string[] ItemBtnNav = { "GiveAll", "RollItems", "ItemMenu", "EquipMenu", "DropItems", "DropFromInventory", "NoEquipCD", "StackShrine", "ClearInv" };
        public static string[] SpawnBtnNav = { "MinDistance", "MaxDistance", "TeamIndex", "KillAll", "SpawnList" };
        public static string[] TeleBtnNav = { "Skip", "InstaTP", "Mountain", "SpawnAll", "SpawnBlue", "SpawnCele", "SpawnGold" };
        public static string[] RenderBtnNav = { "ActiveMods", "InteractESP", "MobESP" };
        public static string[] LobbyBtnNav = { "Player1", "Player2", "Player3", "Player4" };
        #endregion

        // Goes to previous menu when backspace or left arrow is pressed
        public static void GoBackAMenu()
        {
            if (Main.lowResolutionMonitor)
            {
                switch (Navigation.menuIndex)
                {
                    case 0: // Main Menu 
                        {
                            if (intraMenuIndex == 5)
                            {
                                Main.unloadConfirm = false;
                            }
                            else
                            {
                                Main.navigationToggle = false;
                                menuIndex = 0;
                                intraMenuIndex = -1;
                            }
                            break;
                        }

                    case 1: // Player Management Menu
                        {
                            Main._isPlayerMod = false;
                            menuIndex = 0;
                            intraMenuIndex = 0;
                            break;
                        }

                    case 1.1f: // Character Menu
                        {
                            Main._isChangeCharacterMenuOpen = false;
                            Main._isPlayerMod = true;
                            menuIndex = 1;
                            intraMenuIndex = prevIntraMenuIndex;
                            break;
                        }

                    case 1.2f: // Buff Menu
                        {
                            Main._isBuffMenuOpen = false;
                            Main._isPlayerMod = true;
                            menuIndex = 1;
                            intraMenuIndex = prevIntraMenuIndex;
                            break;
                        }

                    case 1.3f: // Stats Modification Menu
                        {
                            Main._isEditStatsOpen = false;
                            Main._isPlayerMod = true;
                            menuIndex = 1;
                            intraMenuIndex = prevIntraMenuIndex;
                            break;
                        }

                    case 2: // Movement Menu
                        {
                            Main._isMovementOpen = false;
                            menuIndex = 0;
                            intraMenuIndex = 1;
                            break;
                        }

                    case 3: // Item Management Menu
                        {
                            Main._isItemManagerOpen = false;
                            menuIndex = 0;
                            intraMenuIndex = 2;
                            break;
                        }

                    case 3.1f: // Give Item Menu
                        {
                            Main._isItemSpawnMenuOpen = false;
                            Main._isItemManagerOpen = true;
                            menuIndex = 3;
                            intraMenuIndex = prevIntraMenuIndex;
                            break;
                        }

                    case 3.2f: // Give Equipment Menu
                        {
                            Main._isEquipmentSpawnMenuOpen = false;
                            Main._isItemManagerOpen = true;
                            menuIndex = 3;
                            intraMenuIndex = prevIntraMenuIndex;
                            break;
                        }

                    case 3.3f: // Change Chest Item List Menu
                        {
                            Main._isChestItemListOpen = false;
                            Main._isItemManagerOpen = true;
                            menuIndex = 3;
                            intraMenuIndex = prevIntraMenuIndex;
                            break;
                        }

                    case 4: // Spawn Menu
                        {
                            Main._isSpawnMenuOpen = false;
                            menuIndex = 0;
                            intraMenuIndex = 3;
                            break;
                        }

                    case 4.1f: // Spawn List Menu
                        {
                            Main._isSpawnListMenuOpen = false;
                            Main._isSpawnMenuOpen = true;
                            menuIndex = 4;
                            intraMenuIndex = prevIntraMenuIndex;
                            break;
                        }

                    case 5: // Teleporter Menu
                        {
                            Main._isTeleMenuOpen = false;
                            menuIndex = 0;
                            intraMenuIndex = 4;
                            break;
                        }

                    case 6: // Render Menu
                        {
                            Main._isESPMenuOpen = false;
                            menuIndex = 0;
                            intraMenuIndex = 5;
                            break;
                        }

                    case 7: // Lobby Management Menu
                        {
                            Main._isLobbyMenuOpen = false;
                            menuIndex = 0;
                            intraMenuIndex = 6;
                            break;
                        }

                    default:
                        {
                            break;
                        }
                }
            }
            else
            {
                switch (Navigation.menuIndex)
                {
                    case 0: // Main Menu 
                        {
                            if (intraMenuIndex == 5)
                            {
                                Main.unloadConfirm = false;
                            }
                            else
                            {
                                Main.navigationToggle = false;
                                menuIndex = 0;
                                intraMenuIndex = -1;
                            }
                            break;
                        }

                    case 1: // Player Management Menu
                        {
                            Main._isPlayerMod = false;
                            menuIndex = 0;
                            intraMenuIndex = 0;
                            break;
                        }

                    case 1.1f: // Character Menu
                        {
                            Main._isChangeCharacterMenuOpen = false;
                            menuIndex = 1;
                            intraMenuIndex = prevIntraMenuIndex;
                            break;
                        }

                    case 1.2f: // Buff Menu
                        {
                            Main._isBuffMenuOpen = false;
                            menuIndex = 1;
                            intraMenuIndex = prevIntraMenuIndex;
                            break;
                        }

                    case 1.3f: // Stats Modification Menu
                        {
                            Main._isEditStatsOpen = false;
                            menuIndex = 1;
                            intraMenuIndex = prevIntraMenuIndex;
                            break;
                        }

                    case 2: // Movement Menu
                        {
                            Main._isMovementOpen = false;
                            menuIndex = 0;
                            intraMenuIndex = 1;
                            break;
                        }

                    case 3: // Item Management Menu
                        {
                            Main._isItemManagerOpen = false;
                            menuIndex = 0;
                            intraMenuIndex = 2;
                            break;
                        }

                    case 3.1f: // Give Item Menu
                        {
                            Main._isItemSpawnMenuOpen = false;
                            menuIndex = 3;
                            intraMenuIndex = prevIntraMenuIndex;
                            break;
                        }

                    case 3.2f: // Give Equipment Menu
                        {
                            Main._isEquipmentSpawnMenuOpen = false;
                            menuIndex = 3;
                            intraMenuIndex = prevIntraMenuIndex;
                            break;
                        }

                    case 3.3f: // Change Chest Item List Menu
                        {
                            Main._isChestItemListOpen = false;
                            menuIndex = 3;
                            intraMenuIndex = prevIntraMenuIndex;
                            break;
                        }

                    case 4: // Spawn Menu
                        {
                            Main._isSpawnMenuOpen = false;
                            menuIndex = 0;
                            intraMenuIndex = 3;
                            break;
                        }

                    case 4.1f: // Spawn List Menu
                        {
                            Main._isSpawnListMenuOpen = false;
                            menuIndex = 4;
                            intraMenuIndex = prevIntraMenuIndex;
                            break;
                        }

                    case 5: // Teleporter Menu
                        {
                            Main._isTeleMenuOpen = false;
                            menuIndex = 0;
                            intraMenuIndex = 4;
                            break;
                        }

                    case 6: // Render Menu
                        {
                            Main._isESPMenuOpen = false;
                            menuIndex = 0;
                            intraMenuIndex = 5;
                            break;
                        }

                    case 7: // Lobby Management Menu
                        {
                            Main._isLobbyMenuOpen = false;
                            menuIndex = 0;
                            intraMenuIndex = 6;
                            break;
                        }

                    default:
                        {
                            break;
                        }
                }
            }
        }

        // Increase value for buttons with +/- options
        public static void IncreaseValue(float pressMenuIndex, int pressIntraMenuIndex)
        {
            switch (pressMenuIndex)
            {
                case 1:
                    {
                        switch (pressIntraMenuIndex)
                        {
                            case 0:
                                {
                                    if (PlayerMod.moneyToGive >= 50)
                                        PlayerMod.moneyToGive += 50;
                                    break;
                                }

                            case 1:
                                {
                                    if (PlayerMod.coinsToGive >= 10)
                                        PlayerMod.coinsToGive += 10;
                                    break;
                                }

                            case 2:
                                {
                                    if (PlayerMod.xpToGive >= 50)
                                        PlayerMod.xpToGive += 50;
                                    break;
                                }

                            default:
                                {
                                    break;
                                }
                        }
                        break;
                    }

                case 1.3f:
                    {
                        switch (pressIntraMenuIndex)
                        {
                            case 0:
                                {
                                    if (PlayerMod.damagePerLvl >= 0)
                                        PlayerMod.damagePerLvl += PlayerMod.multiplyer;
                                    break;
                                }

                            case 1:
                                {
                                    if (PlayerMod.CritPerLvl >= 0)
                                        PlayerMod.CritPerLvl += PlayerMod.multiplyer;
                                    break;
                                }

                            case 2:
                                {
                                    if (PlayerMod.attackSpeed >= 0)
                                        PlayerMod.attackSpeed += PlayerMod.multiplyer;
                                    break;
                                }

                            case 3:
                                {
                                    if (PlayerMod.armor >= 0)
                                        PlayerMod.armor += PlayerMod.multiplyer;
                                    break;
                                }

                            case 4:
                                {
                                    if (PlayerMod.movespeed >= 7)
                                        PlayerMod.movespeed += PlayerMod.multiplyer;
                                    break;
                                }

                            case 5:
                                {
                                    if (PlayerMod.multiplyer == 1)
                                        PlayerMod.multiplyer = 10;
                                    else if (PlayerMod.multiplyer >= 10)
                                        PlayerMod.multiplyer += 10;
                                    break;
                                }

                            default:
                                {
                                    break;
                                }
                        }
                        break;
                    }

                case 3:
                    {
                        switch (pressIntraMenuIndex)
                        {
                            case 0:
                                {
                                    if (ItemManager.allItemsQuantity >= 1)
                                        ItemManager.allItemsQuantity += 1;
                                    break;
                                }

                            case 1:
                                {
                                    if (ItemManager.itemsToRoll >= 5)
                                        ItemManager.itemsToRoll += 5;
                                    break;
                                }

                            default:
                                {
                                    break;
                                }
                        }
                        break;
                    }

                case 4:
                    {
                        switch (pressIntraMenuIndex)
                        {
                            case 0:
                                {
                                    if (Spawn.minDistance < Spawn.maxDistance)
                                    {
                                        Spawn.minDistance += 1;
                                    }
                                    break;
                                }

                            case 1:
                                {
                                    if (Spawn.maxDistance >= Spawn.minDistance)
                                    {
                                        Spawn.maxDistance += 1;
                                    }
                                    break;
                                }

                            case 2:
                                {
                                    if (Spawn.teamIndex < 3)
                                    {
                                        Spawn.teamIndex += 1;
                                    }
                                    else if (Spawn.teamIndex == 3)
                                    {
                                        Spawn.teamIndex = 0;
                                    }
                                    break;
                                }

                            default:
                                {
                                    break;
                                }
                        }
                        break;
                    }

                default:
                    {
                        break;
                    }
            }
        }

        // Decrease value for buttons with +/- options
        public static void DecreaseValue(float pressMenuIndex, int pressIntraMenuIndex)
        {
            switch (pressMenuIndex)
            {
                case 1:
                    {
                        switch (pressIntraMenuIndex)
                        {
                            case 0:
                                {
                                    if (PlayerMod.moneyToGive > 50)
                                        PlayerMod.moneyToGive -= 50;
                                    break;
                                }

                            case 1:
                                {
                                    if (PlayerMod.coinsToGive > 10)
                                        PlayerMod.coinsToGive -= 10;
                                    break;
                                }

                            case 2:
                                {
                                    if (PlayerMod.xpToGive > 50)
                                        PlayerMod.xpToGive -= 50;
                                    break;
                                }

                            default:
                                {
                                    break;
                                }
                        }
                        break;
                    }

                case 1.3f:
                    {
                        switch (pressIntraMenuIndex)
                        {
                            case 0:
                                {
                                    if (PlayerMod.damagePerLvl > PlayerMod.multiplyer)
                                        PlayerMod.damagePerLvl -= PlayerMod.multiplyer;
                                    break;
                                }

                            case 1:
                                {
                                    if (PlayerMod.CritPerLvl > PlayerMod.multiplyer)
                                        PlayerMod.CritPerLvl -= PlayerMod.multiplyer;
                                    break;
                                }

                            case 2:
                                {
                                    if (PlayerMod.attackSpeed > PlayerMod.multiplyer)
                                        PlayerMod.attackSpeed -= PlayerMod.multiplyer;
                                    break;
                                }

                            case 3:
                                {
                                    if (PlayerMod.armor > PlayerMod.multiplyer)
                                        PlayerMod.armor -= 10;
                                    break;
                                }

                            case 4:
                                {
                                    if (PlayerMod.movespeed > 7)
                                        PlayerMod.movespeed -= PlayerMod.multiplyer;
                                    break;
                                }

                            case 5:
                                {
                                    if (PlayerMod.multiplyer == 10)
                                        PlayerMod.multiplyer = 1;
                                    else if (PlayerMod.multiplyer > 10)
                                        PlayerMod.multiplyer -= 10;
                                    break;
                                }

                            default:
                                {
                                    break;
                                }
                        }
                        break;
                    }

                case 3:
                    {
                        switch (pressIntraMenuIndex)
                        {
                            case 0:
                                {
                                    if (ItemManager.allItemsQuantity > 1)
                                        ItemManager.allItemsQuantity -= 1;
                                    break;
                                }

                            case 1:
                                {
                                    if (ItemManager.itemsToRoll > 5)
                                        ItemManager.itemsToRoll -= 5;
                                    break;
                                }

                            default:
                                {
                                    break;
                                }
                        }
                        break;
                    }

                case 4:
                    {
                        switch (pressIntraMenuIndex)
                        {
                            case 0:
                                {
                                    if (Spawn.minDistance > 0)
                                    {
                                        Spawn.minDistance -= 1;
                                    }
                                    break;
                                }

                            case 1:
                                {
                                    if (Spawn.maxDistance > Spawn.minDistance)
                                    {
                                        Spawn.maxDistance -= 1;
                                    }
                                    break;
                                }

                            case 2:
                                {
                                    if (Spawn.teamIndex > 0)
                                    {
                                        Spawn.teamIndex -= 1;
                                    }
                                    else if (Spawn.teamIndex == 0)
                                    {
                                        Spawn.teamIndex = 3;
                                    }
                                    break;
                                }

                            default:
                                {
                                    break;
                                }
                        }
                        break;
                    }

                default:
                    {
                        break;
                    }
            }
        }

        // Method that handles what all the buttons do
        public static void PressBtn(float pressMenuIndex, int pressIntraMenuIndex)
        {
            switch (pressMenuIndex)
            {
                case 0: // Main Menu 
                    {
                        switch (pressIntraMenuIndex)
                        {
                            case 0: // Toggle PlayerMod Menu
                                {
                                    Main._isPlayerMod = !Main._isPlayerMod;
                                    Navigation.prevLowResMenuIndex = Navigation.lowResMenuIndex;
                                    Navigation.lowResMenuIndex = 1;

                                    if (Main.navigationToggle)
                                    {
                                        Navigation.menuIndex = 1;
                                    }
                                    break;
                                }

                            case 1: // Toggle Movement Menu
                                {
                                    Main._isMovementOpen = !Main._isMovementOpen;
                                    Navigation.prevLowResMenuIndex = Navigation.lowResMenuIndex;
                                    Navigation.lowResMenuIndex = 2;

                                    if (Main.navigationToggle)
                                    {
                                        Navigation.menuIndex = 2;
                                    }
                                    break;
                                }

                            case 2: // Toggle Item Menu
                                {
                                    Main._isItemManagerOpen = !Main._isItemManagerOpen;
                                    Navigation.prevLowResMenuIndex = Navigation.lowResMenuIndex;
                                    Navigation.lowResMenuIndex = 3;

                                    if (Main.navigationToggle)
                                    {
                                        Navigation.menuIndex = 3;
                                    }
                                    break;
                                }

                            case 3: // Toggle Spawn Menu
                                {
                                    Main._isSpawnMenuOpen = !Main._isSpawnMenuOpen;
                                    Navigation.prevLowResMenuIndex = Navigation.lowResMenuIndex;
                                    Navigation.lowResMenuIndex = 4;

                                    if (Main.navigationToggle)
                                    {
                                        Navigation.menuIndex = 4;
                                    }
                                    break;
                                }

                            case 4: // Toggle Teleporter Menu
                                {
                                    Main._isTeleMenuOpen = !Main._isTeleMenuOpen;
                                    Navigation.prevLowResMenuIndex = Navigation.lowResMenuIndex;
                                    Navigation.lowResMenuIndex = 5;

                                    if (Main.navigationToggle)
                                    {
                                        Navigation.menuIndex = 5;
                                    }
                                    break;
                                }

                            case 5: // Toggle Render Menu
                                {
                                    Main._isESPMenuOpen = !Main._isESPMenuOpen;
                                    Navigation.prevLowResMenuIndex = Navigation.lowResMenuIndex;
                                    Navigation.lowResMenuIndex = 6;

                                    if (Main.navigationToggle)
                                    {
                                        Navigation.menuIndex = 6;
                                    }
                                    break;
                                }

                            case 6: // Toggle Lobby Menu
                                {
                                    Main._isLobbyMenuOpen = !Main._isLobbyMenuOpen;
                                    Navigation.prevLowResMenuIndex = Navigation.lowResMenuIndex;
                                    Navigation.lowResMenuIndex = 7;

                                    if (Main.navigationToggle)
                                    {
                                        Navigation.menuIndex = 7;
                                    }
                                    break;
                                }

                            case 7: // Unload Button
                                {
                                    if (Main.unloadConfirm)
                                    {
                                        Utility.ResetMenu();
                                        Loader.Unload();
                                    }
                                    else
                                    {
                                        Main.unloadConfirm = true;
                                    }
                                    break;
                                }

                            default:
                                {
                                    Navigation.menuIndex = 0;
                                    break;
                                }
                        }
                        break;
                    }

                case 1: // Player Management Menu
                    {
                        switch (pressIntraMenuIndex)
                        {
                            case 0: // Give Money
                                {
                                    PlayerMod.GiveMoney();
                                    break;
                                }

                            case 1: // Give Lunar Coins
                                {
                                    PlayerMod.GiveLunarCoins();
                                    break;
                                }

                            case 2: // Give XP
                                {
                                    PlayerMod.GiveXP();
                                    break;
                                }

                            case 3: // Toggle StatMod Menu
                                {
                                    prevIntraMenuIndex = intraMenuIndex;
                                    intraMenuIndex = 0;
                                    Main._isEditStatsOpen = !Main._isEditStatsOpen;
                                    Navigation.prevLowResMenuIndex = Navigation.lowResMenuIndex;
                                    Navigation.lowResMenuIndex = 1.3f;

                                    if (Main.navigationToggle)
                                    {
                                        Navigation.menuIndex = 1.3f;
                                    }
                                    break;
                                }

                            case 4: // Toggle Change Character Menu
                                {
                                    prevIntraMenuIndex = intraMenuIndex;
                                    intraMenuIndex = 0;
                                    Main._isChangeCharacterMenuOpen = !Main._isChangeCharacterMenuOpen;
                                    Navigation.prevLowResMenuIndex = Navigation.lowResMenuIndex;
                                    Navigation.lowResMenuIndex = 1.1f;

                                    if (Main.navigationToggle)
                                    {
                                        Navigation.menuIndex = 1.1f;
                                    }
                                    break;
                                }

                            case 5: // Toggle Give Buff Menu
                                {
                                    prevIntraMenuIndex = intraMenuIndex;
                                    intraMenuIndex = 0;
                                    Main._isBuffMenuOpen = !Main._isBuffMenuOpen;
                                    Navigation.prevLowResMenuIndex = Navigation.lowResMenuIndex;
                                    Navigation.lowResMenuIndex = 1.2f;

                                    if (Main.navigationToggle)
                                    {
                                        Navigation.menuIndex = 1.2f;
                                    }
                                    break;
                                }

                            case 6: // Remove Buffs
                                {
                                    PlayerMod.RemoveAllBuffs();
                                    break;
                                }

                            case 7: // Toggle Aimbot
                                {
                                    if (Main.aimBot)
                                    {
                                        EntityStates.FireNailgun.spreadPitchScale = 0.5f;
                                        EntityStates.FireNailgun.spreadYawScale = 1f;
                                        EntityStates.FireNailgun.spreadBloomValue = 0.2f;
                                        if (PlayerMod.GetCurrentCharacter().ToString() == "Huntress")
                                        {
                                            var huntTracker = Main.LocalPlayerBody.GetComponent<HuntressTracker>();
                                            huntTracker.SetField<float>("maxTrackingDistance", 20f);
                                        }
                                        Main.aimBot = false;
                                        break;
                                    }
                                    else if (!Main.aimBot)
                                    {
                                        EntityStates.FireNailgun.spreadPitchScale = 0;
                                        EntityStates.FireNailgun.spreadYawScale = 0;
                                        EntityStates.FireNailgun.spreadBloomValue = 0;
                                        if (PlayerMod.GetCurrentCharacter().ToString() == "Huntress")
                                        {
                                            var huntTracker = Main.LocalPlayerBody.GetComponent<HuntressTracker>();
                                            huntTracker.SetField<float>("maxTrackingDistance", 1000f);
                                        }
                                        Main.aimBot = true;
                                        break;
                                    }
                                    break;
                                }

                            case 8: // Toggle God Mode
                                {
                                    Main.godToggle = !Main.godToggle;
                                    break;
                                }

                            case 9: // Toggle No Skill Cooldowns
                                {
                                    Main.skillToggle = !Main.skillToggle;
                                    break;
                                }

                            case 10: // Unlock All Characters, Logs, etc
                                {
                                    PlayerMod.UnlockAll();
                                    break;
                                }

                            default:
                                {
                                    break;
                                }
                        }
                        break;
                    }

                case 1.1f: // Character Menu
                    {
                        GameObject newBody = BodyCatalog.FindBodyPrefab(Main.bodyPrefabs[pressIntraMenuIndex].name);
                        if (newBody == null) return;
                        var localUser = LocalUserManager.GetFirstLocalUser();
                        if (localUser == null || localUser.cachedMasterController == null || localUser.cachedMasterController.master == null) return;
                        var master = localUser.cachedMasterController.master;

                        master.bodyPrefab = newBody;
                        master.Respawn(master.GetBody().transform.position, master.GetBody().transform.rotation);
                        Utility.SoftResetMenu();
                        break;
                    }

                case 1.2f: // Buff Menu
                    {
                        BuffIndex buffIndex = (BuffIndex)Enum.Parse(typeof(BuffIndex), Enum.GetNames(typeof(BuffIndex))[pressIntraMenuIndex]);
                        var localUser = LocalUserManager.GetFirstLocalUser();
                        if (localUser.cachedMasterController && localUser.cachedMasterController.master)
                        {
                            Main.LocalPlayerBody.AddBuff(buffIndex);
                        }
                        break;
                    }

                case 1.3f: // Stats Modification Menu
                    {
                        switch (pressIntraMenuIndex)
                        {
                            case 0: // Toggle Dmg Increase
                                {
                                    Main.damageToggle = !Main.damageToggle;
                                    break;
                                }

                            case 1: // Toggle Crit Increase
                                {
                                    Main.critToggle = !Main.critToggle;
                                    break;
                                }

                            case 2: // Toggle Attack Speed Increase
                                {
                                    Main.attackSpeedToggle = !Main.attackSpeedToggle;
                                    break;
                                }

                            case 3: // Toggle Armor Increase
                                {
                                    Main.armorToggle = !Main.armorToggle;
                                    break;
                                }

                            case 4: // Toggle Move Speed Increase
                                {
                                    Main.moveSpeedToggle = !Main.moveSpeedToggle;
                                    break;
                                }

                            case 5: // Multiplier change
                                {
                                    
                                    break;
                                }

                            case 6: // Toggle View Stats Menu
                                {
                                    Main._isStatMenuOpen = !Main._isStatMenuOpen;
                                    break;
                                }

                            default:
                                {
                                    break;
                                }

                        }
                        break;
                    }

                case 2: // Movement Menu
                    {
                        switch (pressIntraMenuIndex)
                        {
                            case 0:  // Toggle Always Sprint
                                {
                                    Main.alwaysSprint = !Main.alwaysSprint;
                                    break;
                                }

                            case 1: // Toggle Flight
                                {
                                    if (Main.FlightToggle)
                                    {
                                        if (PlayerMod.GetCurrentCharacter().ToString() != "Loader")
                                        {
                                            Main.LocalPlayerBody.bodyFlags &= CharacterBody.BodyFlags.None;
                                        }
                                        Main.FlightToggle = false;
                                    }
                                    else
                                    {
                                        Main.FlightToggle = true;
                                    }
                                    break;
                                }

                            case 2: // Toggle Jump Pack
                                {
                                    Main.jumpPackToggle = !Main.jumpPackToggle;
                                    break;
                                }

                            default:
                                {
                                    break;
                                }
                        }
                        break;
                    }

                case 3: // Item Management Menu
                    {
                        switch (pressIntraMenuIndex)
                        {
                            case 0: // Give All Items
                                {
                                    ItemManager.GiveAllItems();
                                    break;
                                }

                            case 1: // Give Random Items
                                {
                                    ItemManager.RollItems(ItemManager.itemsToRoll.ToString());
                                    break;
                                }

                            case 2: // Toggle Item Spawn Menu
                                {
                                    prevIntraMenuIndex = intraMenuIndex;
                                    intraMenuIndex = 0;
                                    menuIndex = 3.1f;
                                    Main._isItemSpawnMenuOpen = !Main._isItemSpawnMenuOpen;
                                    Navigation.prevLowResMenuIndex = Navigation.lowResMenuIndex;
                                    Navigation.lowResMenuIndex = 3.1f;
                                    break;
                                }

                            case 3: // Toggle Equipment Spawn Menu
                                {
                                    prevIntraMenuIndex = intraMenuIndex;
                                    intraMenuIndex = 0;
                                    menuIndex = 3.2f;
                                    Main._isEquipmentSpawnMenuOpen = !Main._isEquipmentSpawnMenuOpen;
                                    Navigation.prevLowResMenuIndex = Navigation.lowResMenuIndex;
                                    Navigation.lowResMenuIndex = 3.2f;
                                    break;
                                }

                            case 4: // Toggle Drop Items
                                {
                                    ItemManager.isDropItemForAll = !ItemManager.isDropItemForAll;
                                    ItemManager.isDropItemFromInventory = false;
                                    break;
                                }

                            case 5: // Toggle Drop Items From Inventory
                                {
                                    ItemManager.isDropItemFromInventory = !ItemManager.isDropItemFromInventory;
                                    ItemManager.isDropItemForAll = false;
                                    break;
                                }

                            case 6: // Toggle No Equipment Cooldown
                                {
                                    Main.noEquipmentCooldown = !Main.noEquipmentCooldown;
                                    break;
                                }

                            case 7: // Stack Inventory (Shrine of Chance)
                                {
                                    ItemManager.StackInventory();
                                    break;
                                }

                            case 8: // Remove All Items from Inventory
                                {
                                    ItemManager.ClearInventory();
                                    break;
                                }

                            case 9: // Toggle Chest List Menu
                                {
                                    if (Main._isChangeCharacterMenuOpen)
                                    {
                                        Chests.DisableChests();
                                    }
                                    else
                                    {
                                        Chests.EnableChests();
                                    }
                                    prevIntraMenuIndex = intraMenuIndex;
                                    intraMenuIndex = 0;
                                    menuIndex = 3.3f;
                                    Main._isChestItemListOpen = !Main._isChestItemListOpen;
                                    Navigation.prevLowResMenuIndex = Navigation.lowResMenuIndex;
                                    Navigation.lowResMenuIndex = 3.3f;
                                    break;
                                }

                            default:
                                {
                                    break;
                                }
                        }
                        break;
                    }

                case 3.1f: // Give Item Menu
                    {
                        var localUser = LocalUserManager.GetFirstLocalUser();
                        if (localUser.cachedMasterController && localUser.cachedMasterController.master)
                        {
                            if (ItemManager.isDropItemForAll)
                            {
                                ItemManager.DropItemMethod(Main.items[pressIntraMenuIndex]);
                            }
                            else if (ItemManager.isDropItemFromInventory)
                            {
                                if (ItemManager.CurrentInventory().Contains(Main.items[pressIntraMenuIndex].ToString()))
                                {
                                    Main.LocalPlayerInv.RemoveItem(Main.items[pressIntraMenuIndex], 1);
                                    ItemManager.DropItemMethod(Main.items[pressIntraMenuIndex]);
                                }
                                else
                                {
                                    Chat.AddMessage($"<color=yellow> You do not have that item and therefore cannot drop it from your inventory.</color>");
                                    Chat.AddMessage($" ");
                                }
                            }
                            else
                            {
                                Main.LocalPlayerInv.GiveItem(Main.items[pressIntraMenuIndex], 1);
                            }
                        }
                        break;
                    }

                case 3.2f: // Give Equipment Menu
                    {
                        var localUser = LocalUserManager.GetFirstLocalUser();
                        if (localUser.cachedMasterController && localUser.cachedMasterController.master)
                        {
                            if (ItemManager.isDropItemForAll)
                            {
                                ItemManager.DropEquipmentMethod(Main.equipment[pressIntraMenuIndex]);
                            }
                            else if (ItemManager.isDropItemFromInventory)
                            {
                                if (Main.LocalPlayerInv.currentEquipmentIndex == Main.equipment[pressIntraMenuIndex])
                                {
                                    Main.LocalPlayerInv.SetEquipmentIndex(EquipmentIndex.None);
                                    ItemManager.DropEquipmentMethod(Main.equipment[pressIntraMenuIndex]);
                                }
                                else
                                {
                                    Chat.AddMessage($"<color=yellow> You do not have that equipment and therefore cannot drop it from your inventory.</color>");
                                    Chat.AddMessage($" ");
                                }
                            }
                            else
                            {
                                Main.LocalPlayerInv.SetEquipmentIndex(Main.equipment[pressIntraMenuIndex]);
                            }
                        }
                        break;
                    }

                case 3.3f: // Chest Item List Menu
                    {
                        if (Chests.IsClosestChestEquip())
                        {
                            Chests.SetChestEquipment(Main.equipment[pressIntraMenuIndex]);
                        }
                        else
                        {
                            Chests.SetChestItem(Main.items[pressIntraMenuIndex]);
                        }
                        break;
                    }

                case 4: // Spawn Menu
                    {
                        switch (pressIntraMenuIndex)
                        {
                            case 0: // Min Distance Button
                                {
                                    break;
                                }

                            case 1: // Max Distance Button
                                {
                                    break;
                                }

                            case 2: // Team Index Button
                                {
                                    break;
                                }

                            case 3: // Toggle Spawn Menu
                                {
                                    prevIntraMenuIndex = intraMenuIndex;
                                    intraMenuIndex = 0;
                                    menuIndex = 4.1f;
                                    Main._isSpawnListMenuOpen = !Main._isSpawnListMenuOpen;
                                    Navigation.prevLowResMenuIndex = Navigation.lowResMenuIndex;
                                    Navigation.lowResMenuIndex = 4.1f;
                                    break;
                                }

                            case 4: // Kill All Mobs
                                {
                                    Spawn.KillAllMobs();
                                    break;
                                }

                            case 5: // Destroy Spawned Interactables
                                {
                                    Spawn.DestroySpawnedInteractables();
                                    break;
                                }

                            default:
                                {
                                    break;
                                }
                        }
                        break;
                    }

                case 4.1f: // Spawn List Menu
                    {
                        var localUser = LocalUserManager.GetFirstLocalUser();
                        var body = localUser.cachedMasterController.master.GetBody().transform;
                        if (localUser.cachedMasterController && localUser.cachedMasterController.master)
                        {
                            var directorSpawnRequest = new DirectorSpawnRequest(Main.spawnCards[pressIntraMenuIndex], new DirectorPlacementRule
                            {
                                placementMode = DirectorPlacementRule.PlacementMode.Approximate,
                                minDistance = Spawn.minDistance,
                                maxDistance = Spawn.maxDistance,
                                position = Main.LocalPlayerBody.footPosition
                            }, RoR2Application.rng)
                            {
                                ignoreTeamMemberLimit = true,
                                teamIndexOverride = Spawn.team[Spawn.teamIndex]
                            };

                            directorSpawnRequest.spawnCard.sendOverNetwork = true;

                            string cardName = Main.spawnCards[pressIntraMenuIndex].ToString();
                            string category = "";
                            string buttonText = "";
                            if (cardName.Contains("MultiCharacterSpawnCard"))
                            {
                                cardName = cardName.Replace(" (RoR2.MultiCharacterSpawnCard)", "");
                                category = "CharacterSpawnCard";
                                buttonText = cardName.Replace("csc", "");
                            }
                            else if (cardName.Contains("CharacterSpawnCard"))
                            {
                                cardName = cardName.Replace(" (RoR2.CharacterSpawnCard)", "");
                                category = "CharacterSpawnCard";
                                buttonText = cardName.Replace("csc", "");
                            }
                            else if (cardName.Contains("InteractableSpawnCard"))
                            {
                                cardName = cardName.Replace(" (RoR2.InteractableSpawnCard)", "");
                                category = "InteractableSpawnCard";
                                buttonText = cardName.Replace("isc", "");
                            }
                            else if (cardName.Contains("BodySpawnCard"))
                            {
                                cardName = cardName.Replace(" (RoR2.BodySpawnCard)", "");
                                category = "BodySpawnCard";
                                buttonText = cardName.Replace("bsc", "");
                            }
                            string path = $"SpawnCards/{category}/{cardName}";

                            // Add chat message
                            if (cardName.Contains("isc"))
                            {
                                var interactable = Resources.Load<SpawnCard>(path).DoSpawn(body.position + (Vector3.forward * Spawn.minDistance), body.rotation, directorSpawnRequest).spawnedInstance.gameObject;
                                Spawn.spawnedObjects.Add(interactable);
                                Chat.AddMessage($"<color=yellow>Spawned \"{buttonText}\"</color>");
                            }
                            else
                            {
                                DirectorCore.instance.TrySpawnObject(directorSpawnRequest);
                                Chat.AddMessage($"<color=yellow>Spawned \"{buttonText}\" on team \"{Spawn.team[Spawn.teamIndex]}\" </color>");
                            }
                        }
                        break;
                    }

                case 5: // Teleporter Menu
                    {
                        switch (pressIntraMenuIndex)
                        {
                            case 0: // Skip Stage
                                {
                                    Teleporter.SkipStage();
                                    break;
                                }

                            case 1: // Charge Teleporter
                                {
                                    Teleporter.InstaTeleporter();
                                    break;
                                }

                            case 2: // Add Mountain Shrine Stack
                                {
                                    Teleporter.AddMountain();
                                    break;
                                }

                            case 3: // Spawn All Portals
                                {
                                    Teleporter.SpawnPortals("all");
                                    break;
                                }

                            case 4: // Spawn Blue(Newt/Shop) Portal
                                {
                                    Teleporter.SpawnPortals("newt");
                                    break;
                                }

                            case 5: // Spawn Celestial Portal
                                {
                                    Teleporter.SpawnPortals("blue");
                                    break;
                                }

                            case 6: // Spawn Gold Portal
                                {
                                    Teleporter.SpawnPortals("gold");
                                    break;
                                }

                            default:
                                {
                                    break;
                                }
                        }
                        break;
                    }

                case 6: // Render Menu
                    {
                        switch (pressIntraMenuIndex)
                        {
                            case 0: // Toggle Active Mods
                                {
                                    Main.renderActiveMods = !Main.renderActiveMods;
                                    break;
                                }

                            case 1: // Toggle Render Interactables
                                {
                                    if (Main.renderInteractables)
                                    {
                                        Render.DisableInteractables();
                                    }
                                    else
                                    {
                                        Render.EnableInteractables();
                                    }
                                    Main.renderInteractables = !Main.renderInteractables;
                                    break;
                                }

                            case 2: // Toggle Render Mobs
                                {
                                    Main.renderMobs = !Main.renderMobs;
                                    break;
                                }

                            default:
                                {
                                    break;
                                }
                        }
                        break;
                    }

                case 7: // Lobby Management Menu
                    {
                        switch (pressIntraMenuIndex)
                        {
                            case 0: // Kick Player 1
                                {
                                    Chat.AddMessage("<color=#42f5d4>Kicked Player </color>" + $"<color=yellow>{Main.Players[0]}</color>");
                                    Lobby.KickPlayer(Lobby.GetNetUserFromString(Main.Players[0].ToString()), Main.LocalNetworkUser);
                                    break;
                                }

                            case 1: // Kick Player 2
                                {
                                    Chat.AddMessage("<color=#42f5d4>Kicked Player </color>" + $"<color=yellow>{Main.Players[1]}</color>");
                                    Lobby.KickPlayer(Lobby.GetNetUserFromString(Main.Players[1].ToString()), Main.LocalNetworkUser);
                                    break;
                                }

                            case 2: // Kick Player 3
                                {
                                    Chat.AddMessage("<color=#42f5d4>Kicked Player </color>" + $"<color=yellow>{Main.Players[2]}</color>");
                                    Lobby.KickPlayer(Lobby.GetNetUserFromString(Main.Players[2].ToString()), Main.LocalNetworkUser);
                                    break;
                                }

                            case 3: // Kick Player 4
                                {
                                    Chat.AddMessage("<color=#42f5d4>Kicked Player </color>" + $"<color=yellow>{Main.Players[3]}</color>");
                                    Lobby.KickPlayer(Lobby.GetNetUserFromString(Main.Players[3].ToString()), Main.LocalNetworkUser);
                                    break;
                                }

                            default:
                                {
                                    break;
                                }
                        }
                        break;
                    }

                default:
                    {
                        break;
                    }
            }
        }

        // Main method for Navigation, Highlights button if its supposed to be highlighted
        public static GUIStyle HighlighedCheck(GUIStyle defaultStyle, GUIStyle highlighted, float currentMenu, int currentBtn)
        {
            if (Main.navigationToggle)
            {
                if (currentBtn - 1 == intraMenuIndex && currentMenu == menuIndex)
                {
                    return highlighted;
                }
                else
                {
                    return defaultStyle;
                }
            }
            return defaultStyle;
        }

        // Prevents menuIndex and intraMenuIndex from going out of range
        public static void UpdateIndexValues()
        {
            switch (menuIndex)
            {
                case 0: // Main Menu 0 - 7
                    {
                        if (intraMenuIndex > 7)
                        {
                            intraMenuIndex = 0;
                        }
                        if (intraMenuIndex < 0)
                        {
                            intraMenuIndex = 7;
                        }
                        break;
                    }

                case 1: // Player Management Menu 0 - 10
                    {
                        if (intraMenuIndex > 10)
                        {
                            intraMenuIndex = 0;
                        }
                        if (intraMenuIndex < 0)
                        {
                            intraMenuIndex = 10;
                        }
                        break;
                    }

                case 1.1f: // Change Character Menu
                    {
                        int scrollMul = 40;

                        if (!Main.scrolled)
                        {
                            DrawMenu.characterScrollPosition.y = scrollMul * intraMenuIndex;
                        }

                        if (intraMenuIndex > Main.bodyPrefabs.Count - 1)
                        {
                            intraMenuIndex = 0;
                        }
                        if (intraMenuIndex < 0)
                        {
                            intraMenuIndex = Main.bodyPrefabs.Count - 1;
                        }

                        if (!Main.scrolled)
                        {
                            if (DrawMenu.characterScrollPosition.y > (Main.bodyPrefabs.Count - 1) * scrollMul)
                            {
                                DrawMenu.characterScrollPosition = Vector2.zero;
                            }
                            if (DrawMenu.characterScrollPosition.y < 0)
                            {
                                DrawMenu.characterScrollPosition.y = (Main.bodyPrefabs.Count - 1) * scrollMul;
                            }
                        }
                        break;
                    }

                case 1.2f: // Give Buff Menu
                    {
                        int scrollMul = 40;

                        if (!Main.scrolled)
                        {
                            DrawMenu.buffMenuScrollPosition.y = scrollMul * intraMenuIndex;
                        }

                        if (intraMenuIndex > Enum.GetNames(typeof(BuffIndex)).Length - 1)
                        {
                            intraMenuIndex = 0;
                        }
                        if (intraMenuIndex < 0)
                        {
                            intraMenuIndex = Enum.GetNames(typeof(BuffIndex)).Length - 1;
                        }

                        if (!Main.scrolled)
                        {
                            if (DrawMenu.buffMenuScrollPosition.y > (Enum.GetNames(typeof(BuffIndex)).Length - 1) * scrollMul)
                            {
                                DrawMenu.buffMenuScrollPosition = Vector2.zero;
                            }
                            if (DrawMenu.buffMenuScrollPosition.y < 0)
                            {
                                DrawMenu.buffMenuScrollPosition.y = (Enum.GetNames(typeof(BuffIndex)).Length - 1) * scrollMul;
                            }
                        }
                        break;
                    }

                case 1.3f: // Stats Modification Menu 0 - 6
                    {
                        if (intraMenuIndex > 6)
                        {
                            intraMenuIndex = 0;
                        }
                        if (intraMenuIndex < 0)
                        {
                            intraMenuIndex = 6;
                        }
                        break;
                    }

                case 2: // Movement Menu 0 - 2
                    {
                        if (intraMenuIndex > 2)
                        {
                            intraMenuIndex = 0;
                        }
                        if (intraMenuIndex < 0)
                        {
                            intraMenuIndex = 2;
                        }
                        break;
                    }

                case 3: // Item Management Menu 0 - 9
                    {
                        if (intraMenuIndex > 9)
                        {
                            intraMenuIndex = 0;
                        }
                        if (intraMenuIndex < 0)
                        {
                            intraMenuIndex = 9;
                        }
                        break;
                    }

                case 3.1f: // Give Item Menu
                    {
                        int scrollMul = 40;

                        if (!Main.scrolled)
                        {
                            DrawMenu.itemSpawnerScrollPosition.y = scrollMul * intraMenuIndex;
                        }

                        if (intraMenuIndex > Main.items.Count - 1)
                        {
                            intraMenuIndex = 0;
                        }
                        if (intraMenuIndex < 0)
                        {
                            intraMenuIndex = Main.items.Count - 1;
                        }

                        if (!Main.scrolled)
                        {
                            if (DrawMenu.itemSpawnerScrollPosition.y > (Main.items.Count - 1) * scrollMul)
                            {
                                DrawMenu.itemSpawnerScrollPosition = Vector2.zero;
                            }
                            if (DrawMenu.itemSpawnerScrollPosition.y < 0)
                            {
                                DrawMenu.itemSpawnerScrollPosition.y = (Main.items.Count - 1) * scrollMul;
                            }
                        }
                        break;
                    }

                case 3.2f: // Give Equip Menu
                    {
                        int scrollMul = 40;

                        if (!Main.scrolled)
                        {
                            DrawMenu.equipmentSpawnerScrollPosition.y = scrollMul * intraMenuIndex;
                        }

                        if (intraMenuIndex > Main.equipment.Count - 1)
                        {
                            intraMenuIndex = 0;
                        }
                        if (intraMenuIndex < 0)
                        {
                            intraMenuIndex = Main.equipment.Count - 1;
                        }

                        if (!Main.scrolled)
                        {
                            if (DrawMenu.equipmentSpawnerScrollPosition.y > (Main.equipment.Count - 1) * scrollMul)
                            {
                                DrawMenu.equipmentSpawnerScrollPosition = Vector2.zero;
                            }
                            if (DrawMenu.equipmentSpawnerScrollPosition.y < 0)
                            {
                                DrawMenu.equipmentSpawnerScrollPosition.y = (Main.equipment.Count - 1) * scrollMul;
                            }
                        }
                        break;
                    }

                case 3.3f: // Change Chest Item/Equipment List
                    {
                        int scrollMul = 40;

                        if (Main._isChestItemListOpen)
                        {
                            if (Chests.IsClosestChestEquip())
                            {
                                if (!Main.scrolled)
                                {
                                    DrawMenu.chestItemChangerScrollPosition.y = scrollMul * intraMenuIndex;
                                }

                                if (intraMenuIndex > Main.equipment.Count - 2)
                                {
                                    intraMenuIndex = 0;
                                }
                                if (intraMenuIndex < 0)
                                {
                                    intraMenuIndex = Main.equipment.Count - 2;
                                }

                                if (!Main.scrolled)
                                {
                                    if (DrawMenu.chestItemChangerScrollPosition.y > (Main.equipment.Count - 2) * scrollMul)
                                    {
                                        DrawMenu.chestItemChangerScrollPosition = Vector2.zero;
                                    }
                                    if (DrawMenu.chestItemChangerScrollPosition.y < 0)
                                    {
                                        DrawMenu.chestItemChangerScrollPosition.y = (Main.equipment.Count - 2) * scrollMul;
                                    }
                                }
                            }
                            else
                            {
                                if (!Main.scrolled)
                                {
                                    DrawMenu.chestItemChangerScrollPosition.y = 40 * intraMenuIndex;
                                }

                                if (intraMenuIndex > Main.items.Count - 1)
                                {
                                    intraMenuIndex = 0;
                                }
                                if (intraMenuIndex < 0)
                                {
                                    intraMenuIndex = Main.items.Count - 1;
                                }

                                if (!Main.scrolled)
                                {
                                    if (DrawMenu.chestItemChangerScrollPosition.y > (Main.items.Count - 1) * scrollMul)
                                    {
                                        DrawMenu.chestItemChangerScrollPosition = Vector2.zero;
                                    }
                                    if (DrawMenu.chestItemChangerScrollPosition.y < 0)
                                    {
                                        DrawMenu.chestItemChangerScrollPosition.y = (Main.items.Count - 1) * scrollMul;
                                    }
                                }
                            }
                        }
                        break;
                    }

                case 4: // Spawn Menu 0 - 5
                    {
                        if (intraMenuIndex > 5)
                        {
                            intraMenuIndex = 0;
                        }
                        if (intraMenuIndex < 0)
                        {
                            intraMenuIndex = 5;
                        }
                        break;
                    }

                case 4.1f: // Spawn List Menu
                    {
                        int scrollMul = 40;

                        if (!Main.scrolled)
                        {
                            DrawMenu.spawnScrollPosition.y = scrollMul * intraMenuIndex;
                        }

                        if (intraMenuIndex > Main.spawnCards.Count - 1)
                        {
                            intraMenuIndex = 0;
                        }
                        if (intraMenuIndex < 0)
                        {
                            intraMenuIndex = Main.spawnCards.Count - 1;
                        }

                        if (!Main.scrolled)
                        {
                            if (DrawMenu.spawnScrollPosition.y > (Main.spawnCards.Count - 1) * scrollMul)
                            {
                                DrawMenu.spawnScrollPosition = Vector2.zero;
                            }
                            if (DrawMenu.spawnScrollPosition.y < 0)
                            {
                                DrawMenu.spawnScrollPosition.y = (Main.spawnCards.Count - 1) * scrollMul;
                            }
                        }
                        break;
                    }

                case 5: // Teleporter Menu 0 - 6
                    {
                        if (intraMenuIndex > 6)
                        {
                            intraMenuIndex = 0;
                        }
                        if (intraMenuIndex < 0)
                        {
                            intraMenuIndex = 6;
                        }
                        break;
                    }

                case 6: // Render Menu 0 - 2
                    {
                        if (intraMenuIndex > 2)
                        {
                            intraMenuIndex = 0;
                        }
                        if (intraMenuIndex < 0)
                        {
                            intraMenuIndex = 2;
                        }
                        break;
                    }

                case 7: // Lobby Management Menu 0 - 3
                    {
                        if (Main.numberOfPlayers > 0)
                        {
                            if (intraMenuIndex > Main.numberOfPlayers - 1)
                            {
                                intraMenuIndex = 0;
                            }
                            if (intraMenuIndex < 0)
                            {
                                intraMenuIndex = Main.numberOfPlayers - 1;
                            }
                        }
                        break;
                    }

                default:
                    {
                        break;
                    }
            }
        }
    }
}
