using RoR2;

namespace UmbraRoR
{
    class Navigation
    {
        public static int MenuIndex = 0;
        public static int IntraMenuIndex = -1;
        public static string[] MenuList = { "Main", "Player", "Item", "Teleporter", "Render", "Lobby" };
        public static string[] MainBtnNav = { "PlayerMod", "ItemMang", "Teleporter", "Render", "LobbyMang" };
        public static string[] PlayerBtnNav = { "GiveMoney", "GiveCoin", "GiveXP", "DmgPerLVL", "CritPerLVL", "AttSpeed", "Armor", "MoveSpeed", "StatMenu", "BuffMenu", "RemoveBuffs", "Aimbot", "AutoSprint", "Flight", "GodMode", "NoSkillCD", "UnlockAll" };
        public static string[] ItemBtnNav = { "GiveAll", "RollItems", "ItemMenu", "EquipMenu", "DropItems", "NoEquipCD", "StackShrine", "ClearInv" };
        public static string[] TeleBtnNav = { "Skip", "InstaTP", "Mountain", "SpawnAll", "SpawnBlue", "SpawnCele", "SpawnGold" };
        public static string[] RenderBtnNav = { "InteractESP", "MobESP" };
        public static string[] LobbyBtnNav = { "Player1", "Player2", "Player3", "Player4" };

        //Goes to previous menu when backspace or left arrow is pressed
        public static void GoBackAMenu()
        {
            switch (Navigation.MenuIndex)
            {
                case 0:
                    {
                        Main.navigationToggle = false;
                        break;
                    }

                case 1:
                    {
                        Main._isPlayerMod = false;
                        break;
                    }

                case 2:
                    {
                        Main._isItemManagerOpen = false;
                        break;
                    }

                case 3:
                    {
                        Main._isTeleMenuOpen = false;
                        break;
                    }

                case 4:
                    {
                        Main._isESPMenuOpen = false;
                        break;
                    }

                case 5:
                    {
                        Main._isLobbyMenuOpen = false;
                        break;
                    }

                default:
                    {
                        break;
                    }
            }
            IntraMenuIndex = MenuIndex - 1;
            MenuIndex = 0;
        }

        //Increase value for buttons with +/- options
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

        //Decrease value for buttons with +/- options
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

        //Basically recreates menu buttons based on what button is highlighted
        public static void PressBtn(int MenuIndex, int BtnIndex)
        {
            switch (MenuIndex)
            {
                case 0: // Main Menu 
                    {
                        switch (BtnIndex)
                        {
                            case 0:
                                {
                                    Main._isPlayerMod = !Main._isPlayerMod;
                                    Navigation.MenuIndex = 1;
                                    break;
                                }

                            case 1:
                                {
                                    Main._isItemManagerOpen = !Main._isItemManagerOpen;
                                    Navigation.MenuIndex = 2;
                                    break;
                                }

                            case 2:
                                {
                                    Main._isTeleMenuOpen = !Main._isTeleMenuOpen;
                                    Navigation.MenuIndex = 3;
                                    break;
                                }

                            case 3:
                                {
                                    Main._isESPMenuOpen = !Main._isESPMenuOpen;
                                    Navigation.MenuIndex = 4;
                                    break;
                                }

                            case 4:
                                {
                                    Main._isLobbyMenuOpen = !Main._isLobbyMenuOpen;
                                    Navigation.MenuIndex = 5;
                                    break;
                                }

                            default:
                                {
                                    Navigation.MenuIndex = 0;
                                    break;
                                }
                        }
                        break;
                    }

                case 1: // Player Management Menu
                    {
                        switch (IntraMenuIndex)
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
                                    PlayerMod.giveXP();
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
                                    Main._isStatMenuOpen = !Main._isStatMenuOpen;
                                    break;
                                }

                            case 9:
                                {
                                    Main._isBuffMenuOpen = !Main._isBuffMenuOpen;
                                    break;
                                }

                            case 10:
                                {
                                    PlayerMod.RemoveAllBuffs();
                                    break;
                                }

                            case 11:
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

                            case 12:
                                {
                                    Main.alwaysSprint = !Main.alwaysSprint;
                                    break;
                                }

                            case 13:
                                {
                                    if (Main.FlightToggle)
                                    {
                                        Main.LocalPlayerBody.bodyFlags &= CharacterBody.BodyFlags.None;
                                        Main.FlightToggle = false;
                                    }
                                    else
                                    {
                                        Main.FlightToggle = true;
                                    }
                                    break;
                                }

                            case 14:
                                {
                                    Main.godToggle = !Main.godToggle;
                                    break;
                                }

                            case 15:
                                {
                                    Main.skillToggle = !Main.skillToggle;
                                    break;
                                }

                            case 16:
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

                case 2: // Item Management Menu
                    {
                        switch (IntraMenuIndex)
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
                                    Main._isItemSpawnMenuOpen = !Main._isItemSpawnMenuOpen;
                                    break;
                                }

                            case 3:
                                {
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

                case 3: // Teleporter Menu
                    {
                        switch (IntraMenuIndex)
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
                        switch (IntraMenuIndex)
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
                        switch (IntraMenuIndex)
                        {
                            case 0:
                                {
                                    Chat.AddMessage("<color=#42f5d4>Kicked Player </color>" + $"<color=yellow>{Main.Players[0]}</color>");
                                    Utils.KickPlayer(Utils.GetNetUserFromString(Main.Players[0].ToString()), Main.LocalNetworkUser);
                                    break;
                                }

                            case 1:
                                {
                                    Chat.AddMessage("<color=#42f5d4>Kicked Player </color>" + $"<color=yellow>{Main.Players[1]}</color>");
                                    Utils.KickPlayer(Utils.GetNetUserFromString(Main.Players[1].ToString()), Main.LocalNetworkUser);
                                    break;
                                }

                            case 2:
                                {
                                    Chat.AddMessage("<color=#42f5d4>Kicked Player </color>" + $"<color=yellow>{Main.Players[2]}</color>");
                                    Utils.KickPlayer(Utils.GetNetUserFromString(Main.Players[2].ToString()), Main.LocalNetworkUser);
                                    break;
                                }

                            case 3:
                                {
                                    Chat.AddMessage("<color=#42f5d4>Kicked Player </color>" + $"<color=yellow>{Main.Players[3]}</color>");
                                    Utils.KickPlayer(Utils.GetNetUserFromString(Main.Players[3].ToString()), Main.LocalNetworkUser);
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
    }
}
