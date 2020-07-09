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
        public static int prevMenuIndex;
        public static int prevIntraMenuIndex;
        public static Tuple<float, float> highlightedBtn = new Tuple<float, float>(menuIndex, intraMenuIndex);

        public static Dictionary<float, string> MenuList = new Dictionary<float, string>()
        {
            { 0, "Menu" },
            { 1, "Player" },
            { 2, "Item" },
            { 3, "Teleporter" },
            { 4, "Render" },
            { 5, "Lobby" }
        };

        public static Dictionary<float, string> ExtentionMenuList = new Dictionary<float, string>()
        {
            { 1.1f, "CharacterMenu" },
            { 1.2f, "BuffMenu" },
            { 2.1f, "ItemMenu" },
            { 2.2f, "EquipMenu" },
        };

        public static string[] MainBtnNav = { "PlayerMod", "ItemMang", "Teleporter", "Render", "LobbyMang" };
        public static string[] PlayerBtnNav = { "GiveMoney", "GiveCoin", "GiveXP", "DmgPerLVL", "CritPerLVL", "AttSpeed", "Armor", "MoveSpeed", "CharacterMenu", "Stat", "BuffMenu", "RemoveBuffs", "Aimbot", "AutoSprint", "Flight", "GodMode", "NoSkillCD", "UnlockAll" };
        public static string[] ItemBtnNav = { "GiveAll", "RollItems", "ItemMenu", "EquipMenu", "DropItems", "DropFromInventory", "NoEquipCD", "StackShrine", "ClearInv" };
        public static string[] TeleBtnNav = { "Skip", "InstaTP", "Mountain", "SpawnAll", "SpawnBlue", "SpawnCele", "SpawnGold" };
        public static string[] RenderBtnNav = { "InteractESP", "MobESP" };
        public static string[] LobbyBtnNav = { "Player1", "Player2", "Player3", "Player4" };

        // Goes to previous menu when backspace or left arrow is pressed
        public static void GoBackAMenu()
        {
            switch (Navigation.menuIndex)
            {
                case 0:
                    {
                        Main.navigationToggle = false;
                        menuIndex = 0;
                        intraMenuIndex = -1;
                        break;
                    }

                case 1:
                    {
                        Main._isPlayerMod = false;
                        menuIndex = 0;
                        intraMenuIndex = 0;
                        break;
                    }

                case 1.1f:
                    {
                        Main._isChangeCharacterMenuOpen = false;
                        menuIndex = 1;
                        intraMenuIndex = prevIntraMenuIndex;
                        break;
                    }

                case 1.2f:
                    {
                        Main._isBuffMenuOpen = false;
                        menuIndex = 1;
                        intraMenuIndex = prevIntraMenuIndex;
                        break;
                    }

                case 2:
                    {
                        Main._isItemManagerOpen = false;
                        menuIndex = 0;
                        intraMenuIndex = 1;
                        break;
                    }

                case 2.1f:
                    {
                        Main._isItemSpawnMenuOpen = false;
                        menuIndex = 2;
                        intraMenuIndex = prevIntraMenuIndex;
                        break;
                    }

                case 2.2f:
                    {
                        Main._isEquipmentSpawnMenuOpen = false;
                        menuIndex = 2;
                        intraMenuIndex = prevIntraMenuIndex;
                        break;
                    }

                case 3:
                    {
                        Main._isTeleMenuOpen = false;
                        menuIndex = 0;
                        intraMenuIndex = 2;
                        break;
                    }

                case 4:
                    {
                        Main._isESPMenuOpen = false;
                        menuIndex = 0;
                        intraMenuIndex = 3;
                        break;
                    }

                case 5:
                    {
                        Main._isLobbyMenuOpen = false;
                        menuIndex = 0;
                        intraMenuIndex = 4;
                        break;
                    }

                default:
                    {
                        break;
                    }
            }
        }

        // Increase value for buttons with +/- options
        public static void IncreaseValue(int MenuIndex, int BtnIndex)
        {
            switch (MenuIndex)
            {
                case 1:
                    {
                        switch (BtnIndex)
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

                            case 3:
                                {
                                    if (PlayerMod.damagePerLvl >= 0)
                                        PlayerMod.damagePerLvl += 10;
                                    break;
                                }

                            case 4:
                                {
                                    if (PlayerMod.CritPerLvl >= 0)
                                        PlayerMod.CritPerLvl += 1;
                                    break;
                                }

                            case 5:
                                {
                                    if (PlayerMod.attackSpeed >= 0)
                                        PlayerMod.attackSpeed += 1;
                                    break;
                                }

                            case 6:
                                {
                                    if (PlayerMod.armor >= 0)
                                        PlayerMod.armor += 10;
                                    break;
                                }

                            case 7:
                                {
                                    if (PlayerMod.movespeed >= 7)
                                        PlayerMod.movespeed += 10;
                                    break;
                                }

                            default:
                                {
                                    break;
                                }
                        }
                        break;
                    }

                case 2:
                    {
                        switch (BtnIndex)
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

                default:
                    {
                        break;
                    }
            }
        }

        // Decrease value for buttons with +/- options
        public static void DecreaseValue(int MenuIndex, int BtnIndex)
        {
            switch (MenuIndex)
            {
                case 1:
                    {
                        switch (BtnIndex)
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

                            case 3:
                                {
                                    if (PlayerMod.damagePerLvl > 0)
                                        PlayerMod.damagePerLvl -= 10;
                                    break;
                                }

                            case 4:
                                {
                                    if (PlayerMod.CritPerLvl > 0)
                                        PlayerMod.CritPerLvl -= 1;
                                    break;
                                }

                            case 5:
                                {
                                    if (PlayerMod.attackSpeed > 0)
                                        PlayerMod.attackSpeed -= 1;
                                    break;
                                }

                            case 6:
                                {
                                    if (PlayerMod.armor > 0)
                                        PlayerMod.armor -= 10;
                                    break;
                                }

                            case 7:
                                {
                                    if (PlayerMod.movespeed > 7)
                                        PlayerMod.movespeed -= 10;
                                    break;
                                }

                            default:
                                {
                                    break;
                                }
                        }
                        break;
                    }

                case 2:
                    {
                        switch (BtnIndex)
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

                default:
                    {
                        break;
                    }
            }
        }

        // Basically recreates menu buttons based on what button is highlighted
        public static void PressBtn()
        {
            switch (menuIndex)
            {
                case 0: // Main Menu 
                    {
                        switch (intraMenuIndex)
                        {
                            case 0:
                                {
                                    Main._isPlayerMod = !Main._isPlayerMod;
                                    Navigation.menuIndex = 1;
                                    break;
                                }

                            case 1:
                                {
                                    Main._isItemManagerOpen = !Main._isItemManagerOpen;
                                    Navigation.menuIndex = 2;
                                    break;
                                }

                            case 2:
                                {
                                    Main._isTeleMenuOpen = !Main._isTeleMenuOpen;
                                    Navigation.menuIndex = 3;
                                    break;
                                }

                            case 3:
                                {
                                    Main._isESPMenuOpen = !Main._isESPMenuOpen;
                                    Navigation.menuIndex = 4;
                                    break;
                                }

                            case 4:
                                {
                                    Main._isLobbyMenuOpen = !Main._isLobbyMenuOpen;
                                    Navigation.menuIndex = 5;
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
                        switch (intraMenuIndex)
                        {
                            case 0:
                                {
                                    PlayerMod.GiveMoney();
                                    break;
                                }

                            case 1:
                                {
                                    PlayerMod.GiveLunarCoins();
                                    break;
                                }

                            case 2:
                                {
                                    PlayerMod.GiveXP();
                                    break;
                                }

                            case 3:
                                {
                                    Main.damageToggle = !Main.damageToggle;
                                    break;
                                }

                            case 4:
                                {
                                    Main.critToggle = !Main.critToggle;
                                    break;
                                }

                            case 5:
                                {
                                    Main.attackSpeedToggle = !Main.attackSpeedToggle;
                                    break;
                                }

                            case 6:
                                {
                                    Main.armorToggle = !Main.armorToggle;
                                    break;
                                }

                            case 7:
                                {
                                    Main.moveSpeedToggle = !Main.moveSpeedToggle;
                                    break;
                                }

                            case 8:
                                {
                                    prevIntraMenuIndex = intraMenuIndex;
                                    intraMenuIndex = 0;
                                    menuIndex = 1.1f;
                                    Main._isChangeCharacterMenuOpen = !Main._isChangeCharacterMenuOpen;
                                    break;
                                }

                            case 9:
                                {
                                    Main._isStatMenuOpen = !Main._isStatMenuOpen;
                                    break;
                                }

                            case 10:
                                {
                                    prevIntraMenuIndex = intraMenuIndex;
                                    intraMenuIndex = 0;
                                    menuIndex = 1.2f;
                                    Main._isBuffMenuOpen = !Main._isBuffMenuOpen;
                                    break;
                                }

                            case 11:
                                {
                                    PlayerMod.RemoveAllBuffs();
                                    break;
                                }

                            case 12:
                                {
                                    if (Main.aimBot)
                                    {
                                        EntityStates.FireNailgun.spreadPitchScale = 0.5f;
                                        EntityStates.FireNailgun.spreadYawScale = 1f;
                                        EntityStates.FireNailgun.spreadBloomValue = 0.2f;
                                        Main.aimBot = false;
                                        break;
                                    }
                                    else if (!Main.aimBot)
                                    {
                                        EntityStates.FireNailgun.spreadPitchScale = 0;
                                        EntityStates.FireNailgun.spreadYawScale = 0;
                                        EntityStates.FireNailgun.spreadBloomValue = 0;
                                        Main.aimBot = true;
                                        break;
                                    }
                                    break;
                                }

                            case 13:
                                {
                                    Main.alwaysSprint = !Main.alwaysSprint;
                                    break;
                                }

                            case 14:
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

                            case 15:
                                {
                                    Main.godToggle = !Main.godToggle;
                                    break;
                                }

                            case 16:
                                {
                                    Main.skillToggle = !Main.skillToggle;
                                    break;
                                }

                            case 17:
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
                        GameObject newBody = BodyCatalog.FindBodyPrefab(Main.bodyPrefabs[intraMenuIndex].name);
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
                        BuffIndex buffIndex = (BuffIndex)Enum.Parse(typeof(BuffIndex), Enum.GetNames(typeof(BuffIndex))[intraMenuIndex]);
                        var localUser = LocalUserManager.GetFirstLocalUser();
                        if (localUser.cachedMasterController && localUser.cachedMasterController.master)
                        {
                            Main.LocalPlayerBody.AddBuff(buffIndex);
                        }
                        break;
                    }

                case 2: // Item Management Menu
                    {
                        switch (intraMenuIndex)
                        {
                            case 0:
                                {
                                    ItemManager.GiveAllItems();
                                    break;
                                }

                            case 1:
                                {
                                    ItemManager.RollItems(ItemManager.itemsToRoll.ToString());
                                    break;
                                }

                            case 2:
                                {
                                    prevIntraMenuIndex = intraMenuIndex;
                                    intraMenuIndex = 0;
                                    menuIndex = 2.1f;
                                    Main._isItemSpawnMenuOpen = !Main._isItemSpawnMenuOpen;
                                    break;
                                }

                            case 3:
                                {
                                    prevIntraMenuIndex = intraMenuIndex;
                                    intraMenuIndex = 0;
                                    menuIndex = 2.2f;
                                    Main._isEquipmentSpawnMenuOpen = !Main._isEquipmentSpawnMenuOpen;
                                    break;
                                }

                            case 4:
                                {
                                    ItemManager.isDropItemForAll = !ItemManager.isDropItemForAll;
                                    ItemManager.isDropItemFromInventory = false;
                                    break;
                                }

                            case 5:
                                {
                                    ItemManager.isDropItemFromInventory = !ItemManager.isDropItemFromInventory;
                                    ItemManager.isDropItemForAll = false;
                                    break;
                                }

                            case 6:
                                {
                                    Main.noEquipmentCooldown = !Main.noEquipmentCooldown;
                                    break;
                                }

                            case 7:
                                {
                                    ItemManager.StackInventory();
                                    break;
                                }

                            case 8:
                                {
                                    ItemManager.ClearInventory();
                                    break;
                                }

                            default:
                                {
                                    break;
                                }
                        }
                        break;
                    }

                case 2.1f: // Give Item Menu
                    {
                        var localUser = LocalUserManager.GetFirstLocalUser();
                        if (localUser.cachedMasterController && localUser.cachedMasterController.master)
                        {
                            if (ItemManager.isDropItemForAll)
                            {
                                ItemManager.DropItemMethod(Main.items[intraMenuIndex]);
                            }
                            else if (ItemManager.isDropItemFromInventory)
                            {
                                if (ItemManager.CurrentInventory().Contains(Main.items[intraMenuIndex].ToString()))
                                {
                                    Main.LocalPlayerInv.RemoveItem(Main.items[intraMenuIndex], 1);
                                    ItemManager.DropItemMethod(Main.items[intraMenuIndex]);
                                }
                                else
                                {
                                    Chat.AddMessage($"<color=yellow> You do not have that item and therefore cannot drop it from your inventory.</color>");
                                    Chat.AddMessage($" ");
                                }
                            }
                            else
                            {
                                Main.LocalPlayerInv.GiveItem(Main.items[intraMenuIndex], 1);
                            }
                        }
                        break;
                    }

                case 2.2f: // Give Equipment Menu
                    {
                        var localUser = LocalUserManager.GetFirstLocalUser();
                        if (localUser.cachedMasterController && localUser.cachedMasterController.master)
                        {
                            if (ItemManager.isDropItemForAll)
                            {
                                ItemManager.DropEquipmentMethod(Main.equipment[intraMenuIndex]);
                            }
                            else if (ItemManager.isDropItemFromInventory)
                            {
                                if (Main.LocalPlayerInv.currentEquipmentIndex == Main.equipment[intraMenuIndex])
                                {
                                    Main.LocalPlayerInv.SetEquipmentIndex(EquipmentIndex.None);
                                    ItemManager.DropEquipmentMethod(Main.equipment[intraMenuIndex]);
                                }
                                else
                                {
                                    Chat.AddMessage($"<color=yellow> You do not have that equipment and therefore cannot drop it from your inventory.</color>");
                                    Chat.AddMessage($" ");
                                }
                            }
                            else
                            {
                                Main.LocalPlayerInv.SetEquipmentIndex(Main.equipment[intraMenuIndex]);
                            }
                        }
                        break;
                    }

                case 3: // Teleporter Menu
                    {
                        switch (intraMenuIndex)
                        {
                            case 0:
                                {
                                    Teleporter.skipStage();
                                    break;
                                }

                            case 1:
                                {
                                    Teleporter.InstaTeleporter();
                                    break;
                                }

                            case 2:
                                {
                                    Teleporter.addMountain();
                                    break;
                                }

                            case 3:
                                {
                                    Teleporter.SpawnPortals("all");
                                    break;
                                }

                            case 4:
                                {
                                    Teleporter.SpawnPortals("newt");
                                    break;
                                }

                            case 5:
                                {
                                    Teleporter.SpawnPortals("blue");
                                    break;
                                }

                            case 6:
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

                case 4: // Render Menu
                    {
                        switch (intraMenuIndex)
                        {
                            case 0:
                                {
                                    Main.renderInteractables = !Main.renderInteractables;
                                    break;
                                }

                            case 1:
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

                case 5: // Lobby Management Menu
                    {
                        switch (intraMenuIndex)
                        {
                            case 0:
                                {
                                    Chat.AddMessage("<color=#42f5d4>Kicked Player </color>" + $"<color=yellow>{Main.Players[0]}</color>");
                                    Utility.KickPlayer(Utility.GetNetUserFromString(Main.Players[0].ToString()), Main.LocalNetworkUser);
                                    break;
                                }

                            case 1:
                                {
                                    Chat.AddMessage("<color=#42f5d4>Kicked Player </color>" + $"<color=yellow>{Main.Players[1]}</color>");
                                    Utility.KickPlayer(Utility.GetNetUserFromString(Main.Players[1].ToString()), Main.LocalNetworkUser);
                                    break;
                                }

                            case 2:
                                {
                                    Chat.AddMessage("<color=#42f5d4>Kicked Player </color>" + $"<color=yellow>{Main.Players[2]}</color>");
                                    Utility.KickPlayer(Utility.GetNetUserFromString(Main.Players[2].ToString()), Main.LocalNetworkUser);
                                    break;
                                }

                            case 3:
                                {
                                    Chat.AddMessage("<color=#42f5d4>Kicked Player </color>" + $"<color=yellow>{Main.Players[3]}</color>");
                                    Utility.KickPlayer(Utility.GetNetUserFromString(Main.Players[3].ToString()), Main.LocalNetworkUser);
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

        public static void UpdateIndexValues()
        {
            switch (menuIndex)
            {
                case 0: // Main Menu 0 - 4
                    {
                        if (intraMenuIndex > 4)
                        {
                            intraMenuIndex = 0;
                        }
                        if (intraMenuIndex < 0)
                        {
                            intraMenuIndex = 4;
                        }
                        break;
                    }

                case 1: // Player Management Menu 0 - 17
                    {
                        if (intraMenuIndex > 17)
                        {
                            intraMenuIndex = 0;
                        }
                        if (intraMenuIndex < 0)
                        {
                            intraMenuIndex = 17;
                        }
                        break;
                    }

                case 1.1f: // Change Character Menu
                    {
                        DrawMenu.characterScrollPosition.y = 40 * intraMenuIndex;

                        if (intraMenuIndex > Main.bodyPrefabs.Count - 1)
                        {
                            intraMenuIndex = 0;
                        }
                        if (intraMenuIndex < 0)
                        {
                            intraMenuIndex = Main.bodyPrefabs.Count - 1;
                        }

                        if (DrawMenu.characterScrollPosition.y > (Main.bodyPrefabs.Count - 1) * 40)
                        {
                            DrawMenu.characterScrollPosition = Vector2.zero;
                        }
                        if (DrawMenu.characterScrollPosition.y < 0)
                        {
                            DrawMenu.characterScrollPosition.y = (Main.bodyPrefabs.Count - 1) * 40;
                        }
                        break;
                    }

                case 1.2f: // Give Buff Menu
                    {
                        DrawMenu.buffMenuScrollPosition.y = 40 * intraMenuIndex;

                        if (intraMenuIndex > Enum.GetNames(typeof(BuffIndex)).Length - 1)
                        {
                            intraMenuIndex = 0;
                        }
                        if (intraMenuIndex < 0)
                        {
                            intraMenuIndex = Enum.GetNames(typeof(BuffIndex)).Length - 1;
                        }

                        if (DrawMenu.buffMenuScrollPosition.y > (Enum.GetNames(typeof(BuffIndex)).Length - 1) * 40)
                        {
                            DrawMenu.buffMenuScrollPosition = Vector2.zero;
                        }
                        if (DrawMenu.buffMenuScrollPosition.y < 0)
                        {
                            DrawMenu.buffMenuScrollPosition.y = (Enum.GetNames(typeof(BuffIndex)).Length - 1) * 40;
                        }
                        break;
                    }

                case 2: // Item Management Menu 0 - 8
                    {
                        if (intraMenuIndex > 8)
                        {
                            intraMenuIndex = 0;
                        }
                        if (intraMenuIndex < 0)
                        {
                            intraMenuIndex = 8;
                        }
                        break;
                    }

                case 2.1f: // Give Item Menu
                    {
                        DrawMenu.itemSpawnerScrollPosition.y = 40 * intraMenuIndex;

                        if (intraMenuIndex > Main.items.Count - 1)
                        {
                            intraMenuIndex = 0;
                        }
                        if (intraMenuIndex < 0)
                        {
                            intraMenuIndex = Main.items.Count - 1;
                        }

                        if (DrawMenu.itemSpawnerScrollPosition.y > (Main.items.Count - 1) * 40)
                        {
                            DrawMenu.itemSpawnerScrollPosition = Vector2.zero;
                        }
                        if (DrawMenu.itemSpawnerScrollPosition.y < 0)
                        {
                            DrawMenu.itemSpawnerScrollPosition.y = (Main.items.Count - 1) * 40;
                        }
                        break;
                    }

                case 2.2f: // Give Equip Menu
                    {
                        DrawMenu.equipmentSpawnerScrollPosition.y = 40 * intraMenuIndex;

                        if (intraMenuIndex > Main.equipment.Count - 1)
                        {
                            intraMenuIndex = 0;
                        }
                        if (intraMenuIndex < 0)
                        {
                            intraMenuIndex = Main.equipment.Count - 1;
                        }

                        if (DrawMenu.equipmentSpawnerScrollPosition.y > (Main.equipment.Count - 1) * 40)
                        {
                            DrawMenu.equipmentSpawnerScrollPosition = Vector2.zero;
                        }
                        if (DrawMenu.equipmentSpawnerScrollPosition.y < 0)
                        {
                            DrawMenu.equipmentSpawnerScrollPosition.y = (Main.equipment.Count - 1) * 40;
                        }
                        break;
                    }

                case 3: // Teleporter Menu 0 - 6
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

                case 4: // Render Menu 0 - 1
                    {
                        if (intraMenuIndex > 1)
                        {
                            intraMenuIndex = 0;
                        }
                        if (intraMenuIndex < 0)
                        {
                            intraMenuIndex = 1;
                        }
                        break;
                    }

                case 5: // Lobby Management Menu 0 - 3
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
