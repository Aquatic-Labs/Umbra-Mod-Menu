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
                                    break;
                                }

                            case 1:
                                {
                                    break;
                                }

                            case 2:
                                {
                                    break;
                                }

                            case 3:
                                {
                                    break;
                                }

                            case 4:
                                {
                                    break;
                                }

                            case 5:
                                {
                                    break;
                                }

                            case 6:
                                {
                                    break;
                                }
                            case 7:
                                {
                                    break;
                                }

                            case 8:
                                {
                                    break;
                                }

                            case 9:
                                {
                                    break;
                                }

                            case 10:
                                {
                                    break;
                                }

                            case 11:
                                {
                                    break;
                                }

                            case 12:
                                {
                                    break;
                                }

                            case 13:
                                {
                                    break;
                                }

                            case 14:
                                {
                                    break;
                                }

                            case 15:
                                {
                                    break;
                                }

                            case 16:
                                {
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
                                    break;
                                }

                            case 1:
                                {
                                    break;
                                }

                            case 2:
                                {
                                    break;
                                }

                            case 3:
                                {
                                    break;
                                }

                            case 4:
                                {
                                    break;
                                }

                            case 5:
                                {
                                    break;
                                }

                            case 6:
                                {
                                    break;
                                }

                            case 7:
                                {
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
                                    break;
                                }

                            case 1:
                                {
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
                    break;
            }
        }
    }
}
