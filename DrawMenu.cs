using RoR2;
using System;
using UnityEngine;

namespace UmbraRoR
{
    internal class DrawMenu
    {
        public static Vector2 itemSpawnerScrollPosition = Vector2.zero;
        public static Vector2 equipmentSpawnerScrollPosition = Vector2.zero;
        public static Vector2 characterScrollPosition = Vector2.zero;

        public static void DrawMainMenu(float x, float y, float widthSize, float mulY, GUIStyle BGstyle, GUIStyle OnStyle, GUIStyle OffStyle, GUIStyle BtnStyle, GUIStyle Highlighted)
        {
            if (Main.navigationToggle && Navigation.MenuIndex == 0)
            {
                switch (Navigation.IntraMenuIndex)
                {
                    case 0:
                        {
                            if (Main._isPlayerMod)
                            {
                                if (GUI.Button(btn.BtnRect(1, false, "main"), "P L A Y E R   M O D I F I C A T I O N S : O N", Highlighted))
                                {
                                    Main._isPlayerMod = false;
                                }
                            }
                            else if (GUI.Button(btn.BtnRect(1, false, "main"), "P L A Y E R   M O D I F I C A T I O N S : O F F", Highlighted))
                            {
                                Main._isPlayerMod = true;
                            }

                            if (Main._isItemManagerOpen)
                            {
                                if (GUI.Button(btn.BtnRect(2, false, "main"), "I T E M   M A N A G E M E N T : ON", OnStyle))
                                {
                                    Main._isItemManagerOpen = false;
                                }
                            }
                            else if (GUI.Button(btn.BtnRect(2, false, "main"), "I T E M   M A N A G E M E N T : O F F", OffStyle))
                            {
                                Main._isItemManagerOpen = true;
                            }
                            if (Main._isTeleMenuOpen)
                            {
                                if (GUI.Button(btn.BtnRect(3, false, "main"), "T E L E P O R T E R : O N", OnStyle))
                                {
                                    Main._isTeleMenuOpen = false;
                                }
                            }
                            else if (GUI.Button(btn.BtnRect(3, false, "main"), "T E L E P O R T E R : O F F", OffStyle))
                            {
                                Main._isTeleMenuOpen = true;
                            }
                            if (Main._isESPMenuOpen)
                            {
                                if (GUI.Button(btn.BtnRect(4, false, "main"), "R E N D E R : O N", OnStyle))
                                {
                                    Main._isESPMenuOpen = false;
                                }
                            }
                            else if (GUI.Button(btn.BtnRect(4, false, "main"), "R E N D E R : O F F", OffStyle))
                            {
                                Main._isESPMenuOpen = true;
                            }
                            if (Main._isLobbyMenuOpen)
                            {
                                if (GUI.Button(btn.BtnRect(5, false, "main"), "L O B B Y   M A N A G E M E N T : O N", OnStyle))
                                {
                                    Main._isLobbyMenuOpen = false;
                                }
                            }
                            else if (GUI.Button(btn.BtnRect(5, false, "main"), "L O B B Y   M A N A G E M E N T : O F F", OffStyle))
                            {
                                Main._isLobbyMenuOpen = true;
                            }
                            break;
                        }

                    case 1:
                        {
                            if (Main._isPlayerMod)
                            {
                                if (GUI.Button(btn.BtnRect(1, false, "main"), "P L A Y E R   M O D I F I C A T I O N S : O N", OnStyle))
                                {
                                    Main._isPlayerMod = false;
                                }
                            }
                            else if (GUI.Button(btn.BtnRect(1, false, "main"), "P L A Y E R   M O D I F I C A T I O N S : O F F", OffStyle))
                            {
                                Main._isPlayerMod = true;
                            }

                            if (Main._isItemManagerOpen)
                            {
                                if (GUI.Button(btn.BtnRect(2, false, "main"), "I T E M   M A N A G E M E N T : ON", Highlighted))
                                {
                                    Main._isItemManagerOpen = false;
                                }
                            }
                            else if (GUI.Button(btn.BtnRect(2, false, "main"), "I T E M   M A N A G E M E N T : O F F", Highlighted))
                            {
                                Main._isItemManagerOpen = true;
                            }
                            if (Main._isTeleMenuOpen)
                            {
                                if (GUI.Button(btn.BtnRect(3, false, "main"), "T E L E P O R T E R : O N", OnStyle))
                                {
                                    Main._isTeleMenuOpen = false;
                                }
                            }
                            else if (GUI.Button(btn.BtnRect(3, false, "main"), "T E L E P O R T E R : O F F", OffStyle))
                            {
                                Main._isTeleMenuOpen = true;
                            }
                            if (Main._isESPMenuOpen)
                            {
                                if (GUI.Button(btn.BtnRect(4, false, "main"), "R E N D E R : O N", OnStyle))
                                {
                                    Main._isESPMenuOpen = false;
                                }
                            }
                            else if (GUI.Button(btn.BtnRect(4, false, "main"), "R E N D E R : O F F", OffStyle))
                            {
                                Main._isESPMenuOpen = true;
                            }
                            if (Main._isLobbyMenuOpen)
                            {
                                if (GUI.Button(btn.BtnRect(5, false, "main"), "L O B B Y   M A N A G E M E N T : O N", OnStyle))
                                {
                                    Main._isLobbyMenuOpen = false;
                                }
                            }
                            else if (GUI.Button(btn.BtnRect(5, false, "main"), "L O B B Y   M A N A G E M E N T : O F F", OffStyle))
                            {
                                Main._isLobbyMenuOpen = true;
                            }
                            break;
                        }

                    case 2:
                        {
                            if (Main._isPlayerMod)
                            {
                                if (GUI.Button(btn.BtnRect(1, false, "main"), "P L A Y E R   M O D I F I C A T I O N S : O N", OnStyle))
                                {
                                    Main._isPlayerMod = false;
                                }
                            }
                            else if (GUI.Button(btn.BtnRect(1, false, "main"), "P L A Y E R   M O D I F I C A T I O N S : O F F", OffStyle))
                            {
                                Main._isPlayerMod = true;
                            }

                            if (Main._isItemManagerOpen)
                            {
                                if (GUI.Button(btn.BtnRect(2, false, "main"), "I T E M   M A N A G E M E N T : ON", OnStyle))
                                {
                                    Main._isItemManagerOpen = false;
                                }
                            }
                            else if (GUI.Button(btn.BtnRect(2, false, "main"), "I T E M   M A N A G E M E N T : O F F", OffStyle))
                            {
                                Main._isItemManagerOpen = true;
                            }
                            if (Main._isTeleMenuOpen)
                            {
                                if (GUI.Button(btn.BtnRect(3, false, "main"), "T E L E P O R T E R : O N", Highlighted))
                                {
                                    Main._isTeleMenuOpen = false;
                                }
                            }
                            else if (GUI.Button(btn.BtnRect(3, false, "main"), "T E L E P O R T E R : O F F", Highlighted))
                            {
                                Main._isTeleMenuOpen = true;
                            }
                            if (Main._isESPMenuOpen)
                            {
                                if (GUI.Button(btn.BtnRect(4, false, "main"), "R E N D E R : O N", OnStyle))
                                {
                                    Main._isESPMenuOpen = false;
                                }
                            }
                            else if (GUI.Button(btn.BtnRect(4, false, "main"), "R E N D E R : O F F", OffStyle))
                            {
                                Main._isESPMenuOpen = true;
                            }
                            if (Main._isLobbyMenuOpen)
                            {
                                if (GUI.Button(btn.BtnRect(5, false, "main"), "L O B B Y   M A N A G E M E N T : O N", OnStyle))
                                {
                                    Main._isLobbyMenuOpen = false;
                                }
                            }
                            else if (GUI.Button(btn.BtnRect(5, false, "main"), "L O B B Y   M A N A G E M E N T : O F F", OffStyle))
                            {
                                Main._isLobbyMenuOpen = true;
                            }
                            break;
                        }

                    case 3:
                        {
                            if (Main._isPlayerMod)
                            {
                                if (GUI.Button(btn.BtnRect(1, false, "main"), "P L A Y E R   M O D I F I C A T I O N S : O N", OnStyle))
                                {
                                    Main._isPlayerMod = false;
                                }
                            }
                            else if (GUI.Button(btn.BtnRect(1, false, "main"), "P L A Y E R   M O D I F I C A T I O N S : O F F", OffStyle))
                            {
                                Main._isPlayerMod = true;
                            }

                            if (Main._isItemManagerOpen)
                            {
                                if (GUI.Button(btn.BtnRect(2, false, "main"), "I T E M   M A N A G E M E N T : ON", OnStyle))
                                {
                                    Main._isItemManagerOpen = false;
                                }
                            }
                            else if (GUI.Button(btn.BtnRect(2, false, "main"), "I T E M   M A N A G E M E N T : O F F", OffStyle))
                            {
                                Main._isItemManagerOpen = true;
                            }
                            if (Main._isTeleMenuOpen)
                            {
                                if (GUI.Button(btn.BtnRect(3, false, "main"), "T E L E P O R T E R : O N", OnStyle))
                                {
                                    Main._isTeleMenuOpen = false;
                                }
                            }
                            else if (GUI.Button(btn.BtnRect(3, false, "main"), "T E L E P O R T E R : O F F", OffStyle))
                            {
                                Main._isTeleMenuOpen = true;
                            }
                            if (Main._isESPMenuOpen)
                            {
                                if (GUI.Button(btn.BtnRect(4, false, "main"), "R E N D E R : O N", Highlighted))
                                {
                                    Main._isESPMenuOpen = false;
                                }
                            }
                            else if (GUI.Button(btn.BtnRect(4, false, "main"), "R E N D E R : O F F", Highlighted))
                            {
                                Main._isESPMenuOpen = true;
                            }
                            if (Main._isLobbyMenuOpen)
                            {
                                if (GUI.Button(btn.BtnRect(5, false, "main"), "L O B B Y   M A N A G E M E N T : O N", OnStyle))
                                {
                                    Main._isLobbyMenuOpen = false;
                                }
                            }
                            else if (GUI.Button(btn.BtnRect(5, false, "main"), "L O B B Y   M A N A G E M E N T : O F F", OffStyle))
                            {
                                Main._isLobbyMenuOpen = true;
                            }
                            break;
                        }

                    case 4:
                        {
                            if (Main._isPlayerMod)
                            {
                                if (GUI.Button(btn.BtnRect(1, false, "main"), "P L A Y E R   M O D I F I C A T I O N S : O N", OnStyle))
                                {
                                    Main._isPlayerMod = false;
                                }
                            }
                            else if (GUI.Button(btn.BtnRect(1, false, "main"), "P L A Y E R   M O D I F I C A T I O N S : O F F", OffStyle))
                            {
                                Main._isPlayerMod = true;
                            }

                            if (Main._isItemManagerOpen)
                            {
                                if (GUI.Button(btn.BtnRect(2, false, "main"), "I T E M   M A N A G E M E N T : ON", OnStyle))
                                {
                                    Main._isItemManagerOpen = false;
                                }
                            }
                            else if (GUI.Button(btn.BtnRect(2, false, "main"), "I T E M   M A N A G E M E N T : O F F", OffStyle))
                            {
                                Main._isItemManagerOpen = true;
                            }
                            if (Main._isTeleMenuOpen)
                            {
                                if (GUI.Button(btn.BtnRect(3, false, "main"), "T E L E P O R T E R : O N", OnStyle))
                                {
                                    Main._isTeleMenuOpen = false;
                                }
                            }
                            else if (GUI.Button(btn.BtnRect(3, false, "main"), "T E L E P O R T E R : O F F", OffStyle))
                            {
                                Main._isTeleMenuOpen = true;
                            }
                            if (Main._isESPMenuOpen)
                            {
                                if (GUI.Button(btn.BtnRect(4, false, "main"), "R E N D E R : O N", OnStyle))
                                {
                                    Main._isESPMenuOpen = false;
                                }
                            }
                            else if (GUI.Button(btn.BtnRect(4, false, "main"), "R E N D E R : O F F", OffStyle))
                            {
                                Main._isESPMenuOpen = true;
                            }
                            if (Main._isLobbyMenuOpen)
                            {
                                if (GUI.Button(btn.BtnRect(5, false, "main"), "L O B B Y   M A N A G E M E N T : O N", Highlighted))
                                {
                                    Main._isLobbyMenuOpen = false;
                                }
                            }
                            else if (GUI.Button(btn.BtnRect(5, false, "main"), "L O B B Y   M A N A G E M E N T : O F F", Highlighted))
                            {
                                Main._isLobbyMenuOpen = true;
                            }
                            break;
                        }

                    default:
                        if (Navigation.IntraMenuIndex > 4)
                        {
                            Navigation.IntraMenuIndex = 0;
                        }
                        if (Navigation.IntraMenuIndex < 0)
                        {
                            Navigation.IntraMenuIndex = 4;
                        }
                        break;
                }
            }
            else
            {
                if (Main._isPlayerMod)
                {
                    if (GUI.Button(btn.BtnRect(1, false, "main"), "P L A Y E R   M O D I F I C A T I O N S : O N", OnStyle))
                    {
                        Main._isPlayerMod = false;
                    }
                }
                else if (GUI.Button(btn.BtnRect(1, false, "main"), "P L A Y E R   M O D I F I C A T I O N S : O F F", OffStyle))
                {
                    Main._isPlayerMod = true;
                }

                if (Main._isItemManagerOpen)
                {
                    if (GUI.Button(btn.BtnRect(2, false, "main"), "I T E M   M A N A G E M E N T : ON", OnStyle))
                    {
                        Main._isItemManagerOpen = false;
                    }
                }
                else if (GUI.Button(btn.BtnRect(2, false, "main"), "I T E M   M A N A G E M E N T : O F F", OffStyle))
                {
                    Main._isItemManagerOpen = true;
                }
                if (Main._isTeleMenuOpen)
                {
                    if (GUI.Button(btn.BtnRect(3, false, "main"), "T E L E P O R T E R : O N", OnStyle))
                    {
                        Main._isTeleMenuOpen = false;
                    }
                }
                else if (GUI.Button(btn.BtnRect(3, false, "main"), "T E L E P O R T E R : O F F", OffStyle))
                {
                    Main._isTeleMenuOpen = true;
                }
                if (Main._isESPMenuOpen)
                {
                    if (GUI.Button(btn.BtnRect(4, false, "main"), "R E N D E R : O N", OnStyle))
                    {
                        Main._isESPMenuOpen = false;
                    }
                }
                else if (GUI.Button(btn.BtnRect(4, false, "main"), "R E N D E R : O F F", OffStyle))
                {
                    Main._isESPMenuOpen = true;
                }
                if (Main._isLobbyMenuOpen)
                {
                    if (GUI.Button(btn.BtnRect(5, false, "main"), "L O B B Y   M A N A G E M E N T : O N", OnStyle))
                    {
                        Main._isLobbyMenuOpen = false;
                    }
                }
                else if (GUI.Button(btn.BtnRect(5, false, "main"), "L O B B Y   M A N A G E M E N T : O F F", OffStyle))
                {
                    Main._isLobbyMenuOpen = true;
                }
            }
        }

        public static void DrawManagmentMenu(float x, float y, float widthSize, int mulY, GUIStyle BGstyle, GUIStyle buttonStyle, GUIStyle LabelStyle, GUIStyle Highlighted)
        {
            GUI.Box(new Rect(x + 0f, y + 0f, widthSize + 10, 50f + 45 * mulY), "", BGstyle);
            GUI.Label(new Rect(x + 5f, y + 5f, widthSize + 5, 95f), "L O B B Y   M A N A G E M E N T   M E N U", LabelStyle);

            if (Main._CharacterCollected)
            {
                if (Main.navigationToggle && Navigation.MenuIndex == 5)
                {
                    int maxBtn = -1;
                    Utility.GetPlayers(Main.Players); //update this asap
                    try
                    {
                        switch (Navigation.IntraMenuIndex)
                        {
                            case 0:
                                {
                                    int playerIndex = 0;
                                    int buttonPlacement = 1;
                                    if (Main.Players[playerIndex] != null)
                                    {
                                        if (GUI.Button(btn.BtnRect(buttonPlacement, false, "lobby"), $"K I C K  <color=yellow>{Main.Players[playerIndex]}</color>", Highlighted))
                                        {
                                            Chat.AddMessage("<color=#42f5d4>Kicked Player </color>" + $"<color=yellow>{Main.Players[playerIndex]}</color>");
                                            Utility.KickPlayer(Utility.GetNetUserFromString(Main.Players[playerIndex].ToString()), Main.LocalNetworkUser);
                                        }
                                        maxBtn = 0;
                                        playerIndex++;
                                        buttonPlacement++;
                                    }
                                    if (Main.Players[playerIndex] != null)
                                    {
                                        if (GUI.Button(btn.BtnRect(buttonPlacement, false, "lobby"), $"K I C K  <color=yellow>{Main.Players[playerIndex]}</color>", buttonStyle))
                                        {
                                            Chat.AddMessage("<color=#42f5d4>Kicked Player </color>" + $"<color=yellow>{Main.Players[playerIndex]}</color>");
                                            Utility.KickPlayer(Utility.GetNetUserFromString(Main.Players[playerIndex].ToString()), Main.LocalNetworkUser);
                                        }
                                        maxBtn = 1;
                                        playerIndex++;
                                        buttonPlacement++;
                                    }
                                    if (Main.Players[playerIndex] != null)
                                    {
                                        if (GUI.Button(btn.BtnRect(buttonPlacement, false, "lobby"), $"K I C K  <color=yellow>{Main.Players[playerIndex]}</color>", buttonStyle))
                                        {
                                            Chat.AddMessage("<color=#42f5d4>Kicked Player </color>" + $"<color=yellow>{Main.Players[playerIndex]}</color>");
                                            Utility.KickPlayer(Utility.GetNetUserFromString(Main.Players[playerIndex].ToString()), Main.LocalNetworkUser);
                                        }
                                        maxBtn = 2;
                                        playerIndex++;
                                        buttonPlacement++;
                                    }
                                    if (Main.Players[playerIndex] != null)
                                    {
                                        if (GUI.Button(btn.BtnRect(buttonPlacement, false, "lobby"), $"K I C K  <color=yellow>{Main.Players[playerIndex]}</color>", buttonStyle))
                                        {
                                            Chat.AddMessage("<color=#42f5d4>Kicked Player </color>" + $"<color=yellow>{Main.Players[playerIndex]}</color>");
                                            Utility.KickPlayer(Utility.GetNetUserFromString(Main.Players[playerIndex].ToString()), Main.LocalNetworkUser);
                                        }
                                        maxBtn = 3;
                                        buttonPlacement++;
                                    }
                                    break;
                                }

                            case 1:
                                {
                                    int playerIndex = 0;
                                    int buttonPlacement = 1;
                                    if (Main.Players[playerIndex] != null)
                                    {
                                        if (GUI.Button(btn.BtnRect(buttonPlacement, false, "lobby"), $"K I C K  <color=yellow>{Main.Players[playerIndex]}</color>", buttonStyle))
                                        {
                                            Chat.AddMessage("<color=#42f5d4>Kicked Player </color>" + $"<color=yellow>{Main.Players[playerIndex]}</color>");
                                            Utility.KickPlayer(Utility.GetNetUserFromString(Main.Players[playerIndex].ToString()), Main.LocalNetworkUser);
                                        }
                                        maxBtn = 0;
                                        playerIndex++;
                                        buttonPlacement++;
                                    }
                                    if (Main.Players[playerIndex] != null)
                                    {
                                        if (GUI.Button(btn.BtnRect(buttonPlacement, false, "lobby"), $"K I C K  <color=yellow>{Main.Players[playerIndex]}</color>", Highlighted))
                                        {
                                            Chat.AddMessage("<color=#42f5d4>Kicked Player </color>" + $"<color=yellow>{Main.Players[playerIndex]}</color>");
                                            Utility.KickPlayer(Utility.GetNetUserFromString(Main.Players[playerIndex].ToString()), Main.LocalNetworkUser);
                                        }
                                        maxBtn = 1;
                                        playerIndex++;
                                        buttonPlacement++;
                                    }
                                    if (Main.Players[playerIndex] != null)
                                    {
                                        if (GUI.Button(btn.BtnRect(buttonPlacement, false, "lobby"), $"K I C K  <color=yellow>{Main.Players[playerIndex]}</color>", buttonStyle))
                                        {
                                            Chat.AddMessage("<color=#42f5d4>Kicked Player </color>" + $"<color=yellow>{Main.Players[playerIndex]}</color>");
                                            Utility.KickPlayer(Utility.GetNetUserFromString(Main.Players[playerIndex].ToString()), Main.LocalNetworkUser);
                                        }
                                        maxBtn = 3;
                                        playerIndex++;
                                        buttonPlacement++;
                                    }
                                    if (Main.Players[playerIndex] != null)
                                    {
                                        if (GUI.Button(btn.BtnRect(buttonPlacement, false, "lobby"), $"K I C K  <color=yellow>{Main.Players[playerIndex]}</color>", buttonStyle))
                                        {
                                            Chat.AddMessage("<color=#42f5d4>Kicked Player </color>" + $"<color=yellow>{Main.Players[playerIndex]}</color>");
                                            Utility.KickPlayer(Utility.GetNetUserFromString(Main.Players[playerIndex].ToString()), Main.LocalNetworkUser);
                                        }
                                        maxBtn = 3;
                                        buttonPlacement++;
                                    }

                                    if (Navigation.IntraMenuIndex > maxBtn)
                                    {
                                        Navigation.IntraMenuIndex = 0;
                                    }
                                    if (Navigation.IntraMenuIndex < 0)
                                    {
                                        Navigation.IntraMenuIndex = maxBtn;
                                    }
                                    break;
                                }

                            case 2:
                                {
                                    int playerIndex = 0;
                                    int buttonPlacement = 1;
                                    if (Main.Players[playerIndex] != null)
                                    {
                                        if (GUI.Button(btn.BtnRect(buttonPlacement, false, "lobby"), $"K I C K  <color=yellow>{Main.Players[playerIndex]}</color>", buttonStyle))
                                        {
                                            Chat.AddMessage("<color=#42f5d4>Kicked Player </color>" + $"<color=yellow>{Main.Players[playerIndex]}</color>");
                                            Utility.KickPlayer(Utility.GetNetUserFromString(Main.Players[playerIndex].ToString()), Main.LocalNetworkUser);
                                        }
                                        maxBtn = 0;
                                        playerIndex++;
                                        buttonPlacement++;
                                    }
                                    if (Main.Players[playerIndex] != null)
                                    {
                                        if (GUI.Button(btn.BtnRect(buttonPlacement, false, "lobby"), $"K I C K  <color=yellow>{Main.Players[playerIndex]}</color>", buttonStyle))
                                        {
                                            Chat.AddMessage("<color=#42f5d4>Kicked Player </color>" + $"<color=yellow>{Main.Players[playerIndex]}</color>");
                                            Utility.KickPlayer(Utility.GetNetUserFromString(Main.Players[playerIndex].ToString()), Main.LocalNetworkUser);
                                        }
                                        maxBtn = 1;
                                        playerIndex++;
                                        buttonPlacement++;
                                    }
                                    if (Main.Players[playerIndex] != null)
                                    {
                                        if (GUI.Button(btn.BtnRect(buttonPlacement, false, "lobby"), $"K I C K  <color=yellow>{Main.Players[playerIndex]}</color>", Highlighted))
                                        {
                                            Chat.AddMessage("<color=#42f5d4>Kicked Player </color>" + $"<color=yellow>{Main.Players[playerIndex]}</color>");
                                            Utility.KickPlayer(Utility.GetNetUserFromString(Main.Players[playerIndex].ToString()), Main.LocalNetworkUser);
                                        }
                                        maxBtn = 2;
                                        playerIndex++;
                                        buttonPlacement++;
                                    }
                                    if (Main.Players[playerIndex] != null)
                                    {
                                        if (GUI.Button(btn.BtnRect(buttonPlacement, false, "lobby"), $"K I C K  <color=yellow>{Main.Players[playerIndex]}</color>", buttonStyle))
                                        {
                                            Chat.AddMessage("<color=#42f5d4>Kicked Player </color>" + $"<color=yellow>{Main.Players[playerIndex]}</color>");
                                            Utility.KickPlayer(Utility.GetNetUserFromString(Main.Players[playerIndex].ToString()), Main.LocalNetworkUser);
                                        }
                                        maxBtn = 3;
                                        buttonPlacement++;
                                    }

                                    if (Navigation.IntraMenuIndex > maxBtn)
                                    {
                                        Navigation.IntraMenuIndex = 0;
                                    }
                                    if (Navigation.IntraMenuIndex < 0)
                                    {
                                        Navigation.IntraMenuIndex = maxBtn;
                                    }
                                    break;
                                }

                            case 3:
                                {
                                    int playerIndex = 0;
                                    int buttonPlacement = 1;
                                    if (Main.Players[playerIndex] != null)
                                    {
                                        if (GUI.Button(btn.BtnRect(buttonPlacement, false, "lobby"), $"K I C K  <color=yellow>{Main.Players[playerIndex]}</color>", buttonStyle))
                                        {
                                            Chat.AddMessage("<color=#42f5d4>Kicked Player </color>" + $"<color=yellow>{Main.Players[playerIndex]}</color>");
                                            Utility.KickPlayer(Utility.GetNetUserFromString(Main.Players[playerIndex].ToString()), Main.LocalNetworkUser);
                                        }
                                        maxBtn = 0;
                                        playerIndex++;
                                        buttonPlacement++;
                                    }
                                    if (Main.Players[playerIndex] != null)
                                    {
                                        if (GUI.Button(btn.BtnRect(buttonPlacement, false, "lobby"), $"K I C K  <color=yellow>{Main.Players[playerIndex]}</color>", buttonStyle))
                                        {
                                            Chat.AddMessage("<color=#42f5d4>Kicked Player </color>" + $"<color=yellow>{Main.Players[playerIndex]}</color>");
                                            Utility.KickPlayer(Utility.GetNetUserFromString(Main.Players[playerIndex].ToString()), Main.LocalNetworkUser);
                                        }
                                        maxBtn = 1;
                                        playerIndex++;
                                        buttonPlacement++;
                                    }
                                    if (Main.Players[playerIndex] != null)
                                    {
                                        if (GUI.Button(btn.BtnRect(buttonPlacement, false, "lobby"), $"K I C K  <color=yellow>{Main.Players[playerIndex]}</color>", buttonStyle))
                                        {
                                            Chat.AddMessage("<color=#42f5d4>Kicked Player </color>" + $"<color=yellow>{Main.Players[playerIndex]}</color>");
                                            Utility.KickPlayer(Utility.GetNetUserFromString(Main.Players[playerIndex].ToString()), Main.LocalNetworkUser);
                                        }
                                        maxBtn = 2;
                                        playerIndex++;
                                        buttonPlacement++;
                                    }
                                    if (Main.Players[playerIndex] != null)
                                    {
                                        if (GUI.Button(btn.BtnRect(buttonPlacement, false, "lobby"), $"K I C K  <color=yellow>{Main.Players[playerIndex]}</color>", Highlighted))
                                        {
                                            Chat.AddMessage("<color=#42f5d4>Kicked Player </color>" + $"<color=yellow>{Main.Players[playerIndex]}</color>");
                                            Utility.KickPlayer(Utility.GetNetUserFromString(Main.Players[playerIndex].ToString()), Main.LocalNetworkUser);
                                        }
                                        maxBtn = 3;
                                        buttonPlacement++;
                                    }

                                    if (Navigation.IntraMenuIndex > maxBtn)
                                    {
                                        Navigation.IntraMenuIndex = 0;
                                    }
                                    if (Navigation.IntraMenuIndex < 0)
                                    {
                                        Navigation.IntraMenuIndex = maxBtn;
                                    }
                                    break;
                                }

                            default:
                                {
                                    if (Navigation.IntraMenuIndex > 3)
                                    {
                                        Navigation.IntraMenuIndex = 0;
                                    }
                                    if (Navigation.IntraMenuIndex < 0)
                                    {
                                        Navigation.IntraMenuIndex = 3;
                                    }
                                    break;
                                }

                        }
                    }
                    catch (NullReferenceException)
                    {
                        Debug.LogWarning("UmbraRoR: There is No Player Selected");
                    }
                }
                else
                {
                    Utility.GetPlayers(Main.Players); //update this asap
                    int buttonPlacement = 1;
                    for (int i = 0; i < Main.Players.Length; i++)
                    {
                        try
                        {
                            if (Main.Players[i] != null)
                            {
                                if (GUI.Button(btn.BtnRect(buttonPlacement, false, "lobby"), $"K I C K  <color=yellow>{Main.Players[i]}</color>", buttonStyle))
                                {
                                    Chat.AddMessage("<color=#42f5d4>Kicked Player </color>" + $"<color=yellow>{Main.Players[i]}</color>");
                                    Utility.KickPlayer(Utility.GetNetUserFromString(Main.Players[i].ToString()), Main.LocalNetworkUser);
                                }
                                buttonPlacement++;
                            }
                        }
                        catch (NullReferenceException)
                        {
                            Debug.LogWarning("UmbraRoR: There is No Player Selected");
                        }
                    }
                }
            }
        }

        public static void DrawNotCollectedMenu(GUIStyle buttonStyle, GUIStyle OnStyle, GUIStyle OffStyle)
        {
            GUI.Button(btn.BtnRect(2, false, "main"), "<color=yellow>Buttons will be availble in game.</color>", buttonStyle);
            GUI.Button(btn.BtnRect(3, false, "main"), "<color=#11ccee>Created By Neonix#1337.\n Feel Free to Message me on discord</color>", buttonStyle);
            GUI.Button(btn.BtnRect(4, false, "main"), "<color=#11ccee>with Bug Reports or suggestions.</color>", buttonStyle);
        }

        public static void CharacterWindowMethod(float x, float y, float widthSize, int mulY, GUIStyle BGstyle, GUIStyle buttonStyle, GUIStyle LabelStyle)
        {
            GUI.Box(new Rect(x + 0f, y + 0f, widthSize + 10, 50f + 45 * 15), "", BGstyle);
            GUI.Label(new Rect(x + 5f, y + 5f, widthSize + 5, 95f), "C H A R A C T E R   M E N U", LabelStyle);

            characterScrollPosition = GUI.BeginScrollView(new Rect(x + 0f, y + 0f, widthSize + 10, 50f + 45 * 15), characterScrollPosition, new Rect(x + 0f, y + 0f, widthSize + 10, 50f + 45 * mulY), false, true);
            PlayerMod.ChangeCharacter(buttonStyle, "character");
            GUI.EndScrollView();
        }

        public static void DrawItemMenu(float x, float y, float widthSize, int mulY, GUIStyle BGstyle, GUIStyle buttonStyle, GUIStyle LabelStyle)
        {
            GUI.Box(new Rect(x + 0f, y + 0f, widthSize + 20, 50f + 45 * 15), "", BGstyle);
            GUI.Label(new Rect(x + 5f, y + 5f, widthSize + 10, 95f), "I T E M   M E N U", LabelStyle);

            itemSpawnerScrollPosition = GUI.BeginScrollView(new Rect(x + 0f, y + 0f, widthSize + 10, 50f + 45 * 15), itemSpawnerScrollPosition, new Rect(x + 0f, y + 0f, widthSize + 10, 50f + 45 * mulY), false, true);
            ItemManager.GiveItem(buttonStyle, "itemSpawner");
            GUI.EndScrollView();
        }
        public static void DrawEquipmentMenu(float x, float y, float widthSize, int mulY, GUIStyle BGstyle, GUIStyle buttonStyle, GUIStyle LabelStyle, GUIStyle offStyle)
        {
            GUI.Box(new Rect(x + 0f, y + 0f, widthSize + 20, 50f + 45 * 15), "", BGstyle);
            GUI.Label(new Rect(x + 5f, y + 5f, widthSize + 10, 95f), "E Q U I P M E N T   L I S T", LabelStyle);

            equipmentSpawnerScrollPosition = GUI.BeginScrollView(new Rect(x + 0f, y + 0f, widthSize + 10, 50f + 45 * 15), equipmentSpawnerScrollPosition, new Rect(x + 0f, y + 0f, widthSize + 10, 50f + 45 * mulY), false, true);
            ItemManager.GiveEquipment(buttonStyle, "equipmentSpawner");
            GUI.EndScrollView();
        }
        public static void DrawBuffMenu(float x, float y, float widthSize, int mulY, GUIStyle BGstyle, GUIStyle buttonStyle, GUIStyle LabelStyle, GUIStyle offStyle)
        {
            GUI.Box(new Rect(x + 0f, y + 0f, widthSize + 20, 50f + 45 * 15), "", BGstyle);
            GUI.Label(new Rect(x + 5f, y + 5f, widthSize + 10, 95f), "B U F F   L I S T", LabelStyle);

            equipmentSpawnerScrollPosition = GUI.BeginScrollView(new Rect(x + 0f, y + 0f, widthSize + 10, 50f + 45 * 15), equipmentSpawnerScrollPosition, new Rect(x + 0f, y + 0f, widthSize + 10, 50f + 45 * mulY), false, true);
            PlayerMod.GiveBuff(buttonStyle, "giveBuff");
            GUI.EndScrollView();
        }

        public static void DrawStatsMenu(float x, float y, float widthSize, int mulY, GUIStyle BGstyle, GUIStyle buttonStyle)
        {
            GUI.Box(new Rect(x + 0f, y + 0f, 350, 50f + 45 * mulY), "", BGstyle);
            GUI.Label(new Rect(x + 5f, y + 5f, widthSize + 5, 50f), "S T A T S   M E N U", buttonStyle);

            GUI.Button(btn.BtnRect(1, false, "stats"), "D A M A G E : " + Main.LocalPlayerBody.damage, buttonStyle);
            GUI.Button(btn.BtnRect(2, false, "stats"), "C R I T : " + Main.LocalPlayerBody.crit, buttonStyle);
            GUI.Button(btn.BtnRect(3, false, "stats"), "A T T A C K   S P E E D : " + Main.LocalPlayerBody.attackSpeed, buttonStyle);
            GUI.Button(btn.BtnRect(4, false, "stats"), "A R M O R : " + Main.LocalPlayerBody.armor, buttonStyle);
            GUI.Button(btn.BtnRect(5, false, "stats"), "R E G E N : " + Main.LocalPlayerBody.regen, buttonStyle);
            GUI.Button(btn.BtnRect(6, false, "stats"), "M O V E   S P E E D : " + Main.LocalPlayerBody.moveSpeed, buttonStyle);
            GUI.Button(btn.BtnRect(7, false, "stats"), "J U M P   C O U N T : " + Main.LocalPlayerBody.maxJumpCount, buttonStyle);
            GUI.Button(btn.BtnRect(8, false, "stats"), "E X P E R I E N C E : " + Main.LocalPlayerBody.experience, buttonStyle);
            GUI.Button(btn.BtnRect(9, false, "stats"), "K I L L S: " + Main.LocalPlayerBody.killCount, buttonStyle);
        }

        public static void DrawTeleMenu(float x, float y, float widthSize, int mulY, GUIStyle BGstyle, GUIStyle buttonStyle, GUIStyle LabelStyle, GUIStyle Highlighted)
        {
            GUI.Box(new Rect(x + 0f, y + 0f, widthSize + 10, 50f + 45 * mulY), "", BGstyle);
            GUI.Label(new Rect(x + 5f, y + 5f, widthSize + 5, 95f), "T E L E P O R T E R   M E N U", LabelStyle);

            if (Main.navigationToggle && Navigation.MenuIndex == 3)
            {
                switch (Navigation.IntraMenuIndex)
                {
                    case 0:
                        {
                            if (GUI.Button(btn.BtnRect(1, false, "tele"), "S K I P   S T A G E", Highlighted))
                                Teleporter.skipStage();
                            if (GUI.Button(btn.BtnRect(2, false, "tele"), "I N S T A N T   T E L E P O R T E R   C H A R G E", buttonStyle))
                                Teleporter.InstaTeleporter();
                            if (GUI.Button(btn.BtnRect(3, false, "tele"), "M O U N T A I N   C H A L L E N G E - C O U N T : " + TeleporterInteraction.instance.shrineBonusStacks.ToString(), buttonStyle))
                                Teleporter.addMountain();
                            if (GUI.Button(btn.BtnRect(4, false, "tele"), "S P A W N   A L L   P O R T A L S", buttonStyle))
                                Teleporter.SpawnPortals("all");
                            if (GUI.Button(btn.BtnRect(5, false, "tele"), "S P A W N   B L U E   P O R T A L", buttonStyle))
                                Teleporter.SpawnPortals("newt");
                            if (GUI.Button(btn.BtnRect(6, false, "tele"), "S P A W N   C E L E S T A L   P O R T A L", buttonStyle))
                                Teleporter.SpawnPortals("blue");
                            if (GUI.Button(btn.BtnRect(7, false, "tele"), "S P A W N   G O L D   P O R T A L", buttonStyle))
                                Teleporter.SpawnPortals("gold");
                            break;
                        }

                    case 1:
                        {
                            if (GUI.Button(btn.BtnRect(1, false, "tele"), "S K I P   S T A G E", buttonStyle))
                                Teleporter.skipStage();
                            if (GUI.Button(btn.BtnRect(2, false, "tele"), "I N S T A N T   T E L E P O R T E R   C H A R G E", Highlighted))
                                Teleporter.InstaTeleporter();
                            if (GUI.Button(btn.BtnRect(3, false, "tele"), "M O U N T A I N   C H A L L E N G E - C O U N T : " + TeleporterInteraction.instance.shrineBonusStacks.ToString(), buttonStyle))
                                Teleporter.addMountain();
                            if (GUI.Button(btn.BtnRect(4, false, "tele"), "S P A W N   A L L   P O R T A L S", buttonStyle))
                                Teleporter.SpawnPortals("all");
                            if (GUI.Button(btn.BtnRect(5, false, "tele"), "S P A W N   B L U E   P O R T A L", buttonStyle))
                                Teleporter.SpawnPortals("newt");
                            if (GUI.Button(btn.BtnRect(6, false, "tele"), "S P A W N   C E L E S T A L   P O R T A L", buttonStyle))
                                Teleporter.SpawnPortals("blue");
                            if (GUI.Button(btn.BtnRect(7, false, "tele"), "S P A W N   G O L D   P O R T A L", buttonStyle))
                                Teleporter.SpawnPortals("gold");
                            break;
                        }

                    case 2:
                        {
                            if (GUI.Button(btn.BtnRect(1, false, "tele"), "S K I P   S T A G E", buttonStyle))
                                Teleporter.skipStage();
                            if (GUI.Button(btn.BtnRect(2, false, "tele"), "I N S T A N T   T E L E P O R T E R   C H A R G E", buttonStyle))
                                Teleporter.InstaTeleporter();
                            if (GUI.Button(btn.BtnRect(3, false, "tele"), "M O U N T A I N   C H A L L E N G E - C O U N T : " + TeleporterInteraction.instance.shrineBonusStacks.ToString(), Highlighted))
                                Teleporter.addMountain();
                            if (GUI.Button(btn.BtnRect(4, false, "tele"), "S P A W N   A L L   P O R T A L S", buttonStyle))
                                Teleporter.SpawnPortals("all");
                            if (GUI.Button(btn.BtnRect(5, false, "tele"), "S P A W N   B L U E   P O R T A L", buttonStyle))
                                Teleporter.SpawnPortals("newt");
                            if (GUI.Button(btn.BtnRect(6, false, "tele"), "S P A W N   C E L E S T A L   P O R T A L", buttonStyle))
                                Teleporter.SpawnPortals("blue");
                            if (GUI.Button(btn.BtnRect(7, false, "tele"), "S P A W N   G O L D   P O R T A L", buttonStyle))
                                Teleporter.SpawnPortals("gold");
                            break;
                        }

                    case 3:
                        {
                            if (GUI.Button(btn.BtnRect(1, false, "tele"), "S K I P   S T A G E", buttonStyle))
                                Teleporter.skipStage();
                            if (GUI.Button(btn.BtnRect(2, false, "tele"), "I N S T A N T   T E L E P O R T E R   C H A R G E", buttonStyle))
                                Teleporter.InstaTeleporter();
                            if (GUI.Button(btn.BtnRect(3, false, "tele"), "M O U N T A I N   C H A L L E N G E - C O U N T : " + TeleporterInteraction.instance.shrineBonusStacks.ToString(), buttonStyle))
                                Teleporter.addMountain();
                            if (GUI.Button(btn.BtnRect(4, false, "tele"), "S P A W N   A L L   P O R T A L S", Highlighted))
                                Teleporter.SpawnPortals("all");
                            if (GUI.Button(btn.BtnRect(5, false, "tele"), "S P A W N   B L U E   P O R T A L", buttonStyle))
                                Teleporter.SpawnPortals("newt");
                            if (GUI.Button(btn.BtnRect(6, false, "tele"), "S P A W N   C E L E S T A L   P O R T A L", buttonStyle))
                                Teleporter.SpawnPortals("blue");
                            if (GUI.Button(btn.BtnRect(7, false, "tele"), "S P A W N   G O L D   P O R T A L", buttonStyle))
                                Teleporter.SpawnPortals("gold");
                            break;
                        }

                    case 4:
                        {
                            if (GUI.Button(btn.BtnRect(1, false, "tele"), "S K I P   S T A G E", buttonStyle))
                                Teleporter.skipStage();
                            if (GUI.Button(btn.BtnRect(2, false, "tele"), "I N S T A N T   T E L E P O R T E R   C H A R G E", buttonStyle))
                                Teleporter.InstaTeleporter();
                            if (GUI.Button(btn.BtnRect(3, false, "tele"), "M O U N T A I N   C H A L L E N G E - C O U N T : " + TeleporterInteraction.instance.shrineBonusStacks.ToString(), buttonStyle))
                                Teleporter.addMountain();
                            if (GUI.Button(btn.BtnRect(4, false, "tele"), "S P A W N   A L L   P O R T A L S", buttonStyle))
                                Teleporter.SpawnPortals("all");
                            if (GUI.Button(btn.BtnRect(5, false, "tele"), "S P A W N   B L U E   P O R T A L", Highlighted))
                                Teleporter.SpawnPortals("newt");
                            if (GUI.Button(btn.BtnRect(6, false, "tele"), "S P A W N   C E L E S T A L   P O R T A L", buttonStyle))
                                Teleporter.SpawnPortals("blue");
                            if (GUI.Button(btn.BtnRect(7, false, "tele"), "S P A W N   G O L D   P O R T A L", buttonStyle))
                                Teleporter.SpawnPortals("gold");
                            break;
                        }

                    case 5:
                        {
                            if (GUI.Button(btn.BtnRect(1, false, "tele"), "S K I P   S T A G E", buttonStyle))
                                Teleporter.skipStage();
                            if (GUI.Button(btn.BtnRect(2, false, "tele"), "I N S T A N T   T E L E P O R T E R   C H A R G E", buttonStyle))
                                Teleporter.InstaTeleporter();
                            if (GUI.Button(btn.BtnRect(3, false, "tele"), "M O U N T A I N   C H A L L E N G E - C O U N T : " + TeleporterInteraction.instance.shrineBonusStacks.ToString(), buttonStyle))
                                Teleporter.addMountain();
                            if (GUI.Button(btn.BtnRect(4, false, "tele"), "S P A W N   A L L   P O R T A L S", buttonStyle))
                                Teleporter.SpawnPortals("all");
                            if (GUI.Button(btn.BtnRect(5, false, "tele"), "S P A W N   B L U E   P O R T A L", buttonStyle))
                                Teleporter.SpawnPortals("newt");
                            if (GUI.Button(btn.BtnRect(6, false, "tele"), "S P A W N   C E L E S T A L   P O R T A L", Highlighted))
                                Teleporter.SpawnPortals("blue");
                            if (GUI.Button(btn.BtnRect(7, false, "tele"), "S P A W N   G O L D   P O R T A L", buttonStyle))
                                Teleporter.SpawnPortals("gold");
                            break;
                        }

                    case 6:
                        {
                            if (GUI.Button(btn.BtnRect(1, false, "tele"), "S K I P   S T A G E", buttonStyle))
                                Teleporter.skipStage();
                            if (GUI.Button(btn.BtnRect(2, false, "tele"), "I N S T A N T   T E L E P O R T E R   C H A R G E", buttonStyle))
                                Teleporter.InstaTeleporter();
                            if (GUI.Button(btn.BtnRect(3, false, "tele"), "M O U N T A I N   C H A L L E N G E - C O U N T : " + TeleporterInteraction.instance.shrineBonusStacks.ToString(), buttonStyle))
                                Teleporter.addMountain();
                            if (GUI.Button(btn.BtnRect(4, false, "tele"), "S P A W N   A L L   P O R T A L S", buttonStyle))
                                Teleporter.SpawnPortals("all");
                            if (GUI.Button(btn.BtnRect(5, false, "tele"), "S P A W N   B L U E   P O R T A L", buttonStyle))
                                Teleporter.SpawnPortals("newt");
                            if (GUI.Button(btn.BtnRect(6, false, "tele"), "S P A W N   C E L E S T A L   P O R T A L", buttonStyle))
                                Teleporter.SpawnPortals("blue");
                            if (GUI.Button(btn.BtnRect(7, false, "tele"), "S P A W N   G O L D   P O R T A L", Highlighted))
                                Teleporter.SpawnPortals("gold");
                            break;
                        }

                    default:
                        {
                            if (Navigation.IntraMenuIndex > 6)
                            {
                                Navigation.IntraMenuIndex = 0;
                            }
                            if (Navigation.IntraMenuIndex < 0)
                            {
                                Navigation.IntraMenuIndex = 6;
                            }
                            break;
                        }
                }
            }
            else
            {
                if (GUI.Button(btn.BtnRect(1, false, "tele"), "S K I P   S T A G E", buttonStyle))
                    Teleporter.skipStage();
                if (GUI.Button(btn.BtnRect(2, false, "tele"), "I N S T A N T   T E L E P O R T E R   C H A R G E", buttonStyle))
                    Teleporter.InstaTeleporter();
                if (GUI.Button(btn.BtnRect(3, false, "tele"), "M O U N T A I N   C H A L L E N G E - C O U N T : " + TeleporterInteraction.instance.shrineBonusStacks.ToString(), buttonStyle))
                    Teleporter.addMountain();
                if (GUI.Button(btn.BtnRect(4, false, "tele"), "S P A W N   A L L   P O R T A L S", buttonStyle))
                    Teleporter.SpawnPortals("all");
                if (GUI.Button(btn.BtnRect(5, false, "tele"), "S P A W N   B L U E   P O R T A L", buttonStyle))
                    Teleporter.SpawnPortals("newt");
                if (GUI.Button(btn.BtnRect(6, false, "tele"), "S P A W N   C E L E S T A L   P O R T A L", buttonStyle))
                    Teleporter.SpawnPortals("blue");
                if (GUI.Button(btn.BtnRect(7, false, "tele"), "S P A W N   G O L D   P O R T A L", buttonStyle))
                    Teleporter.SpawnPortals("gold");
            }
        }

        public static void DrawESPMenu(float x, float y, float widthSize, int mulY, GUIStyle BGstyle, GUIStyle buttonStyle, GUIStyle OnStyle, GUIStyle OffStyle, GUIStyle LabelStyle, GUIStyle Highlighted)
        {
            GUI.Box(new Rect(x + 0f, y + 0f, widthSize + 10, 50f + 45 * mulY), "", BGstyle);
            GUI.Label(new Rect(x + 5f, y + 5f, widthSize + 5, 95f), "R E N D E R   M E N U", LabelStyle);

            if (Main.navigationToggle && Navigation.MenuIndex == 4)
            {
                switch (Navigation.IntraMenuIndex)
                {

                    case 0:
                        {
                            if (Main.renderInteractables)
                            {
                                if (GUI.Button(btn.BtnRect(1, false, "ESP"), "I N T E R A C T A B L E S   E S P : O N", Highlighted))
                                {
                                    Main.renderInteractables = false;
                                }
                            }
                            else if (GUI.Button(btn.BtnRect(1, false, "ESP"), "I N T E R A C T A B L E S   E S P : O F F", Highlighted))
                            {
                                Main.renderInteractables = true;
                            }
                            if (Main.renderMobs)
                            {
                                if (GUI.Button(btn.BtnRect(2, false, "ESP"), "M O B   E S P : O N\n<color=red>Warning: May lag/crash game </color>", OnStyle))
                                {
                                    Main.renderMobs = false;
                                }
                            }
                            else if (GUI.Button(btn.BtnRect(2, false, "ESP"), "M O B   E S P : O F F\n<color=red>Warning: May lag/crash game </color>", OffStyle))
                            {
                                Main.renderMobs = true;
                            }
                            break;
                        }

                    case 1:
                        {
                            if (Main.renderInteractables)
                            {
                                if (GUI.Button(btn.BtnRect(1, false, "ESP"), "I N T E R A C T A B L E S   E S P : O N", OnStyle))
                                {
                                    Main.renderInteractables = false;
                                }
                            }
                            else if (GUI.Button(btn.BtnRect(1, false, "ESP"), "I N T E R A C T A B L E S   E S P : O F F", OffStyle))
                            {
                                Main.renderInteractables = true;
                            }
                            if (Main.renderMobs)
                            {
                                if (GUI.Button(btn.BtnRect(2, false, "ESP"), "M O B   E S P : O N\n<color=red>Warning: May lag/crash game </color>", Highlighted))
                                {
                                    Main.renderMobs = false;
                                }
                            }
                            else if (GUI.Button(btn.BtnRect(2, false, "ESP"), "M O B   E S P : O F F\n<color=red>Warning: May lag/crash game </color>", Highlighted))
                            {
                                Main.renderMobs = true;
                            }
                            break;
                        }

                    default:
                        {
                            if (Navigation.IntraMenuIndex > 1)
                            {
                                Navigation.IntraMenuIndex = 0;
                            }
                            if (Navigation.IntraMenuIndex < 0)
                            {
                                Navigation.IntraMenuIndex = 1;
                            }
                            break;
                        }
                }
            }
            else
            {
                if (Main.renderInteractables)
                {
                    if (GUI.Button(btn.BtnRect(1, false, "ESP"), "I N T E R A C T A B L E S   E S P : O N", OnStyle))
                    {
                        Main.renderInteractables = false;
                    }
                }
                else if (GUI.Button(btn.BtnRect(1, false, "ESP"), "I N T E R A C T A B L E S   E S P : O F F", OffStyle))
                {
                    Main.renderInteractables = true;
                }
                if (Main.renderMobs)
                {
                    if (GUI.Button(btn.BtnRect(2, false, "ESP"), "M O B   E S P : O N\n<color=red>Warning: May lag/crash game </color>", OnStyle))
                    {
                        Main.renderMobs = false;
                    }
                }
                else if (GUI.Button(btn.BtnRect(2, false, "ESP"), "M O B   E S P : O F F\n<color=red>Warning: May lag/crash game </color>", OffStyle))
                {
                    Main.renderMobs = true;
                }
            }

        }

        public static void DrawPlayerModMenu(float x, float y, float widthSize, int mulY, GUIStyle BGstyle, GUIStyle buttonStyle, GUIStyle OnStyle, GUIStyle OffStyle, GUIStyle LabelStyle, GUIStyle Highlighted)
        {
            GUI.Box(new Rect(x + 0f, y + 0f, widthSize + 10, 50f + 45 * mulY), "", BGstyle);
            GUI.Label(new Rect(x + 5f, y + 5f, widthSize + 5, 95f), "P L A Y E R   M O D I F I C A T I O N   M E N U", LabelStyle);

            if (Main.navigationToggle && Navigation.MenuIndex == 1)
            {
                switch (Navigation.IntraMenuIndex)
                {
                    case 0:
                        {
                            if (GUI.Button(btn.BtnRect(1, true, "playermod"), "G I V E   M O N E Y : " + PlayerMod.moneyToGive.ToString(), Highlighted))
                            {
                                PlayerMod.GiveMoney();
                            }
                            if (GUI.Button(new Rect(x + widthSize - 80, y + Main.PlayerModBtnY, 40, 40), "-", OffStyle))
                            {
                                if (PlayerMod.moneyToGive > 50)
                                    PlayerMod.moneyToGive -= 50;
                            }
                            if (GUI.Button(new Rect(x + widthSize - 35, y + Main.PlayerModBtnY, 40, 40), "+", OffStyle))
                            {
                                if (PlayerMod.moneyToGive >= 50)
                                    PlayerMod.moneyToGive += 50;
                            }
                            if (GUI.Button(btn.BtnRect(2, true, "playermod"), "G I V E   L U N A R   C O I N S : " + PlayerMod.coinsToGive.ToString(), buttonStyle))
                            {
                                PlayerMod.GiveLunarCoins();
                            }
                            if (GUI.Button(new Rect(x + widthSize - 80, y + Main.PlayerModBtnY, 40, 40), "-", OffStyle))
                            {
                                if (PlayerMod.coinsToGive > 10)
                                    PlayerMod.coinsToGive -= 10;
                            }
                            if (GUI.Button(new Rect(x + widthSize - 35, y + Main.PlayerModBtnY, 40, 40), "+", OffStyle))
                            {
                                if (PlayerMod.coinsToGive >= 10)
                                    PlayerMod.coinsToGive += 10;
                            }
                            if (GUI.Button(btn.BtnRect(3, true, "playermod"), "G I V E   E X P E R I E N C E : " + PlayerMod.xpToGive.ToString(), buttonStyle))
                            {
                                PlayerMod.GiveXP();
                            }
                            if (GUI.Button(new Rect(x + widthSize - 80, y + Main.PlayerModBtnY, 40, 40), "-", OffStyle))
                            {
                                if (PlayerMod.xpToGive > 50)
                                    PlayerMod.xpToGive -= 50;
                            }
                            if (GUI.Button(new Rect(x + widthSize - 35, y + Main.PlayerModBtnY, 40, 40), "+", OffStyle))
                            {
                                if (PlayerMod.xpToGive >= 50)
                                    PlayerMod.xpToGive += 50;
                            }
                            if (Main.damageToggle)
                            {
                                if (GUI.Button(btn.BtnRect(4, true, "playermod"), "D A M A G E   P E R   L V L ( O N ) : " + PlayerMod.damagePerLvl.ToString(), OnStyle))
                                {
                                    Main.damageToggle = false;
                                }
                            }
                            else if (GUI.Button(btn.BtnRect(4, true, "playermod"), "D A M A G E   P E R   L V L ( O F F ) : " + PlayerMod.damagePerLvl.ToString(), OffStyle))
                            {
                                Main.damageToggle = true;
                            }
                            if (GUI.Button(new Rect(x + widthSize - 80, y + Main.PlayerModBtnY, 40, 40), "-", OffStyle))
                            {
                                if (PlayerMod.damagePerLvl > 0)
                                    PlayerMod.damagePerLvl -= 10;
                            }
                            if (GUI.Button(new Rect(x + widthSize - 35, y + Main.PlayerModBtnY, 40, 40), "+", OffStyle))
                            {
                                if (PlayerMod.damagePerLvl >= 0)
                                    PlayerMod.damagePerLvl += 10;
                            }
                            if (Main.critToggle)
                            {
                                if (GUI.Button(btn.BtnRect(5, true, "playermod"), "C R I T   P E R   L V L ( O N ) : " + PlayerMod.CritPerLvl.ToString(), OnStyle))
                                {
                                    Main.critToggle = false;
                                }
                            }
                            else if (GUI.Button(btn.BtnRect(5, true, "playermod"), "C R I T   P E R   L V L ( O F F ) : " + PlayerMod.CritPerLvl.ToString(), OffStyle))
                            {
                                Main.critToggle = true;
                            }
                            if (GUI.Button(new Rect(x + widthSize - 80, y + Main.PlayerModBtnY, 40, 40), "-", OffStyle))
                            {
                                if (PlayerMod.CritPerLvl > 0)
                                    PlayerMod.CritPerLvl -= 1;
                            }
                            if (GUI.Button(new Rect(x + widthSize - 35, y + Main.PlayerModBtnY, 40, 40), "+", OffStyle))
                            {
                                if (PlayerMod.CritPerLvl >= 0)
                                    PlayerMod.CritPerLvl += 1;
                            }
                            if (Main.attackSpeedToggle)
                            {
                                if (GUI.Button(btn.BtnRect(6, true, "playermod"), "A T T A C K   S P E E D ( O N ) : " + PlayerMod.attackSpeed.ToString(), OnStyle))
                                {
                                    Main.attackSpeedToggle = false;
                                }
                            }
                            else if (GUI.Button(btn.BtnRect(6, true, "playermod"), "A T T A C K   S P E E D ( O F F ) : " + PlayerMod.attackSpeed.ToString(), OffStyle))
                            {
                                Main.attackSpeedToggle = true;
                            }
                            if (GUI.Button(new Rect(x + widthSize - 80, y + Main.PlayerModBtnY, 40, 40), "-", OffStyle))
                            {
                                if (PlayerMod.attackSpeed > 0)
                                    PlayerMod.attackSpeed -= 1;
                            }
                            if (GUI.Button(new Rect(x + widthSize - 35, y + Main.PlayerModBtnY, 40, 40), "+", OffStyle))
                            {
                                if (PlayerMod.attackSpeed >= 0)
                                    PlayerMod.attackSpeed += 1;
                            }
                            if (Main.armorToggle)
                            {
                                if (GUI.Button(btn.BtnRect(7, true, "playermod"), "A R M O R ( O N ) : " + PlayerMod.armor.ToString(), OnStyle))
                                {
                                    Main.armorToggle = false;
                                }
                            }
                            else if (GUI.Button(btn.BtnRect(7, true, "playermod"), "A R M O R ( O F F ) : " + PlayerMod.armor.ToString(), OffStyle))
                            {
                                Main.armorToggle = true;
                            }
                            if (GUI.Button(new Rect(x + widthSize - 80, y + Main.PlayerModBtnY, 40, 40), "-", OffStyle))
                            {
                                if (PlayerMod.armor > 0)
                                    PlayerMod.armor -= 10;
                            }
                            if (GUI.Button(new Rect(x + widthSize - 35, y + Main.PlayerModBtnY, 40, 40), "+", OffStyle))
                            {
                                if (PlayerMod.armor >= 0)
                                    PlayerMod.armor += 10;
                            }
                            if (Main.moveSpeedToggle)
                            {
                                if (GUI.Button(btn.BtnRect(8, true, "playermod"), "M O V E   S P E E D ( O N ) : " + PlayerMod.movespeed.ToString(), OnStyle))
                                {
                                    Main.moveSpeedToggle = false;
                                }
                            }
                            else if (GUI.Button(btn.BtnRect(8, true, "playermod"), "M O V E   S P E E D ( O F F ) : " + PlayerMod.movespeed.ToString(), OffStyle))
                            {
                                Main.moveSpeedToggle = true;
                            }
                            if (GUI.Button(new Rect(x + widthSize - 80, y + Main.PlayerModBtnY, 40, 40), "-", OffStyle))
                            {
                                if (PlayerMod.movespeed > 7)
                                    PlayerMod.movespeed -= 10;
                            }
                            if (GUI.Button(new Rect(x + widthSize - 35, y + Main.PlayerModBtnY, 40, 40), "+", OffStyle))
                            {
                                if (PlayerMod.movespeed >= 7)
                                    PlayerMod.movespeed += 10;
                            }
                            if (Main._CharacterToggle)
                            {
                                if (GUI.Button(btn.BtnRect(9, false, "playermod"), "C H A N G E   C H A R A C T E R : ON", OnStyle))
                                {
                                    Main._CharacterToggle = false;
                                }
                            }
                            else if (GUI.Button(btn.BtnRect(9, false, "playermod"), "C H A N G E   C H A R A C T E R : OFF", OffStyle))
                            {
                                Main._CharacterToggle = true;
                            }
                            if (Main._isStatMenuOpen)
                            {
                                if (GUI.Button(btn.BtnRect(10, false, "playermod"), "S H O W   S T A T S : O N", OnStyle))
                                {
                                    Main._isStatMenuOpen = false;
                                }
                            }
                            else if (GUI.Button(btn.BtnRect(10, false, "playermod"), "S H O W   S T A T S : O F F", OffStyle))
                            {
                                Main._isStatMenuOpen = true;
                            }
                            if (Main._isBuffMenuOpen)
                            {
                                if (GUI.Button(btn.BtnRect(11, false, "playermod"), "G I V E   B U F F   M E N U : O N", OnStyle))
                                {
                                    Main._isBuffMenuOpen = false;
                                }
                            }
                            else if (GUI.Button(btn.BtnRect(11, false, "playermod"), "G I V E   B U F F   M E N U : O F F", OffStyle))
                            {
                                Main._isBuffMenuOpen = true;
                            }
                            if (GUI.Button(btn.BtnRect(12, false, "playermod"), "R E M O V E   A L L   B U F F S", buttonStyle))
                            {
                                PlayerMod.RemoveAllBuffs();
                            }
                            if (Main.aimBot)
                            {
                                if (GUI.Button(btn.BtnRect(13, false, "playermod"), "A I M B O T : O N", OnStyle))
                                {
                                    EntityStates.FireNailgun.spreadPitchScale = 0.5f;
                                    EntityStates.FireNailgun.spreadYawScale = 1f;
                                    EntityStates.FireNailgun.spreadBloomValue = 0.2f;
                                    Main.aimBot = false;
                                }
                            }
                            else if (!Main.aimBot)
                            {
                                if (GUI.Button(btn.BtnRect(13, false, "playermod"), "A I M B O T : O F F", OffStyle))
                                {
                                    EntityStates.FireNailgun.spreadPitchScale = 0;
                                    EntityStates.FireNailgun.spreadYawScale = 0;
                                    EntityStates.FireNailgun.spreadBloomValue = 0;
                                    Main.aimBot = true;
                                }
                            }
                            if (Main.alwaysSprint)
                            {
                                if (GUI.Button(btn.BtnRect(14, false, "playermod"), "A L W A Y S   S P R I N T : O N", OnStyle))
                                {
                                    Main.alwaysSprint = false;
                                }
                            }
                            else if (!Main.alwaysSprint)
                            {
                                if (GUI.Button(btn.BtnRect(14, false, "playermod"), "A L W A Y S   S P R I N T : O F F", OffStyle))
                                {
                                    Main.alwaysSprint = true;
                                }
                            }
                            if (Main.FlightToggle)
                            {
                                if (GUI.Button(btn.BtnRect(15, false, "playermod"), "F L I G H T : O N", OnStyle))
                                {
                                    if (PlayerMod.GetCurrentCharacter().ToString() != "Loader")
                                    {
                                        Main.LocalPlayerBody.bodyFlags &= CharacterBody.BodyFlags.None;
                                    }
                                    Main.FlightToggle = false;
                                }
                            }
                            else if (GUI.Button(btn.BtnRect(15, false, "playermod"), "F L I G H T : O F F", OffStyle))
                            {
                                Main.FlightToggle = true;
                            }
                            if (Main.godToggle)
                            {
                                if (GUI.Button(btn.BtnRect(16, false, "playermod"), "G O D   M O D E : O N", OnStyle))
                                {
                                    Main.godToggle = false;
                                }
                            }
                            else if (GUI.Button(btn.BtnRect(16, false, "playermod"), "G O D   M O D E : O F F", OffStyle))
                            {
                                Main.godToggle = true;
                            }
                            if (Main.skillToggle)
                            {
                                if (GUI.Button(btn.BtnRect(17, false, "playermod"), "I N F I N I T E   S K I L L S : O N", OnStyle))
                                {
                                    Main.skillToggle = false;
                                }
                            }
                            else if (GUI.Button(btn.BtnRect(17, false, "playermod"), "I N F I N I T E   S K I L L S : O F F", OffStyle))
                            {
                                Main.skillToggle = true;
                            }
                            if (GUI.Button(btn.BtnRect(18, false, "playermod"), "U N L O C K   A L L", buttonStyle))
                            {
                                PlayerMod.UnlockAll();
                            }
                            break;
                        }

                    case 1:
                        {
                            if (GUI.Button(btn.BtnRect(1, true, "playermod"), "G I V E   M O N E Y : " + PlayerMod.moneyToGive.ToString(), buttonStyle))
                            {
                                PlayerMod.GiveMoney();
                            }
                            if (GUI.Button(new Rect(x + widthSize - 80, y + Main.PlayerModBtnY, 40, 40), "-", OffStyle))
                            {
                                if (PlayerMod.moneyToGive > 50)
                                    PlayerMod.moneyToGive -= 50;
                            }
                            if (GUI.Button(new Rect(x + widthSize - 35, y + Main.PlayerModBtnY, 40, 40), "+", OffStyle))
                            {
                                if (PlayerMod.moneyToGive >= 50)
                                    PlayerMod.moneyToGive += 50;
                            }
                            if (GUI.Button(btn.BtnRect(2, true, "playermod"), "G I V E   L U N A R   C O I N S : " + PlayerMod.coinsToGive.ToString(), Highlighted))
                            {
                                PlayerMod.GiveLunarCoins();
                            }
                            if (GUI.Button(new Rect(x + widthSize - 80, y + Main.PlayerModBtnY, 40, 40), "-", OffStyle))
                            {
                                if (PlayerMod.coinsToGive > 10)
                                    PlayerMod.coinsToGive -= 10;
                            }
                            if (GUI.Button(new Rect(x + widthSize - 35, y + Main.PlayerModBtnY, 40, 40), "+", OffStyle))
                            {
                                if (PlayerMod.coinsToGive >= 10)
                                    PlayerMod.coinsToGive += 10;
                            }
                            if (GUI.Button(btn.BtnRect(3, true, "playermod"), "G I V E   E X P E R I E N C E : " + PlayerMod.xpToGive.ToString(), buttonStyle))
                            {
                                PlayerMod.GiveXP();
                            }
                            if (GUI.Button(new Rect(x + widthSize - 80, y + Main.PlayerModBtnY, 40, 40), "-", OffStyle))
                            {
                                if (PlayerMod.xpToGive > 50)
                                    PlayerMod.xpToGive -= 50;
                            }
                            if (GUI.Button(new Rect(x + widthSize - 35, y + Main.PlayerModBtnY, 40, 40), "+", OffStyle))
                            {
                                if (PlayerMod.xpToGive >= 50)
                                    PlayerMod.xpToGive += 50;
                            }
                            if (Main.damageToggle)
                            {
                                if (GUI.Button(btn.BtnRect(4, true, "playermod"), "D A M A G E   P E R   L V L ( O N ) : " + PlayerMod.damagePerLvl.ToString(), OnStyle))
                                {
                                    Main.damageToggle = false;
                                }
                            }
                            else if (GUI.Button(btn.BtnRect(4, true, "playermod"), "D A M A G E   P E R   L V L ( O F F ) : " + PlayerMod.damagePerLvl.ToString(), OffStyle))
                            {
                                Main.damageToggle = true;
                            }
                            if (GUI.Button(new Rect(x + widthSize - 80, y + Main.PlayerModBtnY, 40, 40), "-", OffStyle))
                            {
                                if (PlayerMod.damagePerLvl > 0)
                                    PlayerMod.damagePerLvl -= 10;
                            }
                            if (GUI.Button(new Rect(x + widthSize - 35, y + Main.PlayerModBtnY, 40, 40), "+", OffStyle))
                            {
                                if (PlayerMod.damagePerLvl >= 0)
                                    PlayerMod.damagePerLvl += 10;
                            }
                            if (Main.critToggle)
                            {
                                if (GUI.Button(btn.BtnRect(5, true, "playermod"), "C R I T   P E R   L V L ( O N ) : " + PlayerMod.CritPerLvl.ToString(), OnStyle))
                                {
                                    Main.critToggle = false;
                                }
                            }
                            else if (GUI.Button(btn.BtnRect(5, true, "playermod"), "C R I T   P E R   L V L ( O F F ) : " + PlayerMod.CritPerLvl.ToString(), OffStyle))
                            {
                                Main.critToggle = true;
                            }
                            if (GUI.Button(new Rect(x + widthSize - 80, y + Main.PlayerModBtnY, 40, 40), "-", OffStyle))
                            {
                                if (PlayerMod.CritPerLvl > 0)
                                    PlayerMod.CritPerLvl -= 1;
                            }
                            if (GUI.Button(new Rect(x + widthSize - 35, y + Main.PlayerModBtnY, 40, 40), "+", OffStyle))
                            {
                                if (PlayerMod.CritPerLvl >= 0)
                                    PlayerMod.CritPerLvl += 1;
                            }
                            if (Main.attackSpeedToggle)
                            {
                                if (GUI.Button(btn.BtnRect(6, true, "playermod"), "A T T A C K   S P E E D ( O N ) : " + PlayerMod.attackSpeed.ToString(), OnStyle))
                                {
                                    Main.attackSpeedToggle = false;
                                }
                            }
                            else if (GUI.Button(btn.BtnRect(6, true, "playermod"), "A T T A C K   S P E E D ( O F F ) : " + PlayerMod.attackSpeed.ToString(), OffStyle))
                            {
                                Main.attackSpeedToggle = true;
                            }
                            if (GUI.Button(new Rect(x + widthSize - 80, y + Main.PlayerModBtnY, 40, 40), "-", OffStyle))
                            {
                                if (PlayerMod.attackSpeed > 0)
                                    PlayerMod.attackSpeed -= 1;
                            }
                            if (GUI.Button(new Rect(x + widthSize - 35, y + Main.PlayerModBtnY, 40, 40), "+", OffStyle))
                            {
                                if (PlayerMod.attackSpeed >= 0)
                                    PlayerMod.attackSpeed += 1;
                            }
                            if (Main.armorToggle)
                            {
                                if (GUI.Button(btn.BtnRect(7, true, "playermod"), "A R M O R ( O N ) : " + PlayerMod.armor.ToString(), OnStyle))
                                {
                                    Main.armorToggle = false;
                                }
                            }
                            else if (GUI.Button(btn.BtnRect(7, true, "playermod"), "A R M O R ( O F F ) : " + PlayerMod.armor.ToString(), OffStyle))
                            {
                                Main.armorToggle = true;
                            }
                            if (GUI.Button(new Rect(x + widthSize - 80, y + Main.PlayerModBtnY, 40, 40), "-", OffStyle))
                            {
                                if (PlayerMod.armor > 0)
                                    PlayerMod.armor -= 10;
                            }
                            if (GUI.Button(new Rect(x + widthSize - 35, y + Main.PlayerModBtnY, 40, 40), "+", OffStyle))
                            {
                                if (PlayerMod.armor >= 0)
                                    PlayerMod.armor += 10;
                            }
                            if (Main.moveSpeedToggle)
                            {
                                if (GUI.Button(btn.BtnRect(8, true, "playermod"), "M O V E   S P E E D ( O N ) : " + PlayerMod.movespeed.ToString(), OnStyle))
                                {
                                    Main.moveSpeedToggle = false;
                                }
                            }
                            else if (GUI.Button(btn.BtnRect(8, true, "playermod"), "M O V E   S P E E D ( O F F ) : " + PlayerMod.movespeed.ToString(), OffStyle))
                            {
                                Main.moveSpeedToggle = true;
                            }
                            if (GUI.Button(new Rect(x + widthSize - 80, y + Main.PlayerModBtnY, 40, 40), "-", OffStyle))
                            {
                                if (PlayerMod.movespeed > 7)
                                    PlayerMod.movespeed -= 10;
                            }
                            if (GUI.Button(new Rect(x + widthSize - 35, y + Main.PlayerModBtnY, 40, 40), "+", OffStyle))
                            {
                                if (PlayerMod.movespeed >= 7)
                                    PlayerMod.movespeed += 10;
                            }
                            if (Main._CharacterToggle)
                            {
                                if (GUI.Button(btn.BtnRect(9, false, "playermod"), "C H A N G E   C H A R A C T E R : ON", OnStyle))
                                {
                                    Main._CharacterToggle = false;
                                }
                            }
                            else if (GUI.Button(btn.BtnRect(9, false, "playermod"), "C H A N G E   C H A R A C T E R : OFF", OffStyle))
                            {
                                Main._CharacterToggle = true;
                            }
                            if (Main._isStatMenuOpen)
                            {
                                if (GUI.Button(btn.BtnRect(10, false, "playermod"), "S H O W   S T A T S : O N", OnStyle))
                                {
                                    Main._isStatMenuOpen = false;
                                }
                            }
                            else if (GUI.Button(btn.BtnRect(10, false, "playermod"), "S H O W   S T A T S : O F F", OffStyle))
                            {
                                Main._isStatMenuOpen = true;
                            }
                            if (Main._isBuffMenuOpen)
                            {
                                if (GUI.Button(btn.BtnRect(11, false, "playermod"), "G I V E   B U F F   M E N U : O N", OnStyle))
                                {
                                    Main._isBuffMenuOpen = false;
                                }
                            }
                            else if (GUI.Button(btn.BtnRect(11, false, "playermod"), "G I V E   B U F F   M E N U : O F F", OffStyle))
                            {
                                Main._isBuffMenuOpen = true;
                            }
                            if (GUI.Button(btn.BtnRect(12, false, "playermod"), "R E M O V E   A L L   B U F F S", buttonStyle))
                            {
                                PlayerMod.RemoveAllBuffs();
                            }
                            if (Main.aimBot)
                            {
                                if (GUI.Button(btn.BtnRect(13, false, "playermod"), "A I M B O T : O N", OnStyle))
                                {
                                    EntityStates.FireNailgun.spreadPitchScale = 0.5f;
                                    EntityStates.FireNailgun.spreadYawScale = 1f;
                                    EntityStates.FireNailgun.spreadBloomValue = 0.2f;
                                    Main.aimBot = false;
                                }
                            }
                            else if (!Main.aimBot)
                            {
                                if (GUI.Button(btn.BtnRect(13, false, "playermod"), "A I M B O T : O F F", OffStyle))
                                {
                                    EntityStates.FireNailgun.spreadPitchScale = 0;
                                    EntityStates.FireNailgun.spreadYawScale = 0;
                                    EntityStates.FireNailgun.spreadBloomValue = 0;
                                    Main.aimBot = true;
                                }
                            }
                            if (Main.alwaysSprint)
                            {
                                if (GUI.Button(btn.BtnRect(14, false, "playermod"), "A L W A Y S   S P R I N T : O N", OnStyle))
                                {
                                    Main.alwaysSprint = false;
                                }
                            }
                            else if (!Main.alwaysSprint)
                            {
                                if (GUI.Button(btn.BtnRect(14, false, "playermod"), "A L W A Y S   S P R I N T : O F F", OffStyle))
                                {
                                    Main.alwaysSprint = true;
                                }
                            }
                            if (Main.FlightToggle)
                            {
                                if (GUI.Button(btn.BtnRect(15, false, "playermod"), "F L I G H T : O N", OnStyle))
                                {
                                    if (PlayerMod.GetCurrentCharacter().ToString() != "Loader")
                                    {
                                        Main.LocalPlayerBody.bodyFlags &= CharacterBody.BodyFlags.None;
                                    }
                                    Main.FlightToggle = false;
                                }
                            }
                            else if (GUI.Button(btn.BtnRect(15, false, "playermod"), "F L I G H T : O F F", OffStyle))
                            {
                                Main.FlightToggle = true;
                            }
                            if (Main.godToggle)
                            {
                                if (GUI.Button(btn.BtnRect(16, false, "playermod"), "G O D   M O D E : O N", OnStyle))
                                {
                                    Main.godToggle = false;
                                }
                            }
                            else if (GUI.Button(btn.BtnRect(16, false, "playermod"), "G O D   M O D E : O F F", OffStyle))
                            {
                                Main.godToggle = true;
                            }
                            if (Main.skillToggle)
                            {
                                if (GUI.Button(btn.BtnRect(17, false, "playermod"), "I N F I N I T E   S K I L L S : O N", OnStyle))
                                {
                                    Main.skillToggle = false;
                                }
                            }
                            else if (GUI.Button(btn.BtnRect(17, false, "playermod"), "I N F I N I T E   S K I L L S : O F F", OffStyle))
                            {
                                Main.skillToggle = true;
                            }
                            if (GUI.Button(btn.BtnRect(18, false, "playermod"), "U N L O C K   A L L", buttonStyle))
                            {
                                PlayerMod.UnlockAll();
                            }
                            break;
                        }

                    case 2:
                        {
                            if (GUI.Button(btn.BtnRect(1, true, "playermod"), "G I V E   M O N E Y : " + PlayerMod.moneyToGive.ToString(), buttonStyle))
                            {
                                PlayerMod.GiveMoney();
                            }
                            if (GUI.Button(new Rect(x + widthSize - 80, y + Main.PlayerModBtnY, 40, 40), "-", OffStyle))
                            {
                                if (PlayerMod.moneyToGive > 50)
                                    PlayerMod.moneyToGive -= 50;
                            }
                            if (GUI.Button(new Rect(x + widthSize - 35, y + Main.PlayerModBtnY, 40, 40), "+", OffStyle))
                            {
                                if (PlayerMod.moneyToGive >= 50)
                                    PlayerMod.moneyToGive += 50;
                            }
                            if (GUI.Button(btn.BtnRect(2, true, "playermod"), "G I V E   L U N A R   C O I N S : " + PlayerMod.coinsToGive.ToString(), buttonStyle))
                            {
                                PlayerMod.GiveLunarCoins();
                            }
                            if (GUI.Button(new Rect(x + widthSize - 80, y + Main.PlayerModBtnY, 40, 40), "-", OffStyle))
                            {
                                if (PlayerMod.coinsToGive > 10)
                                    PlayerMod.coinsToGive -= 10;
                            }
                            if (GUI.Button(new Rect(x + widthSize - 35, y + Main.PlayerModBtnY, 40, 40), "+", OffStyle))
                            {
                                if (PlayerMod.coinsToGive >= 10)
                                    PlayerMod.coinsToGive += 10;
                            }
                            if (GUI.Button(btn.BtnRect(3, true, "playermod"), "G I V E   E X P E R I E N C E : " + PlayerMod.xpToGive.ToString(), Highlighted))
                            {
                                PlayerMod.GiveXP();
                            }
                            if (GUI.Button(new Rect(x + widthSize - 80, y + Main.PlayerModBtnY, 40, 40), "-", OffStyle))
                            {
                                if (PlayerMod.xpToGive > 50)
                                    PlayerMod.xpToGive -= 50;
                            }
                            if (GUI.Button(new Rect(x + widthSize - 35, y + Main.PlayerModBtnY, 40, 40), "+", OffStyle))
                            {
                                if (PlayerMod.xpToGive >= 50)
                                    PlayerMod.xpToGive += 50;
                            }
                            if (Main.damageToggle)
                            {
                                if (GUI.Button(btn.BtnRect(4, true, "playermod"), "D A M A G E   P E R   L V L ( O N ) : " + PlayerMod.damagePerLvl.ToString(), OnStyle))
                                {
                                    Main.damageToggle = false;
                                }
                            }
                            else if (GUI.Button(btn.BtnRect(4, true, "playermod"), "D A M A G E   P E R   L V L ( O F F ) : " + PlayerMod.damagePerLvl.ToString(), OffStyle))
                            {
                                Main.damageToggle = true;
                            }
                            if (GUI.Button(new Rect(x + widthSize - 80, y + Main.PlayerModBtnY, 40, 40), "-", OffStyle))
                            {
                                if (PlayerMod.damagePerLvl > 0)
                                    PlayerMod.damagePerLvl -= 10;
                            }
                            if (GUI.Button(new Rect(x + widthSize - 35, y + Main.PlayerModBtnY, 40, 40), "+", OffStyle))
                            {
                                if (PlayerMod.damagePerLvl >= 0)
                                    PlayerMod.damagePerLvl += 10;
                            }
                            if (Main.critToggle)
                            {
                                if (GUI.Button(btn.BtnRect(5, true, "playermod"), "C R I T   P E R   L V L ( O N ) : " + PlayerMod.CritPerLvl.ToString(), OnStyle))
                                {
                                    Main.critToggle = false;
                                }
                            }
                            else if (GUI.Button(btn.BtnRect(5, true, "playermod"), "C R I T   P E R   L V L ( O F F ) : " + PlayerMod.CritPerLvl.ToString(), OffStyle))
                            {
                                Main.critToggle = true;
                            }
                            if (GUI.Button(new Rect(x + widthSize - 80, y + Main.PlayerModBtnY, 40, 40), "-", OffStyle))
                            {
                                if (PlayerMod.CritPerLvl > 0)
                                    PlayerMod.CritPerLvl -= 1;
                            }
                            if (GUI.Button(new Rect(x + widthSize - 35, y + Main.PlayerModBtnY, 40, 40), "+", OffStyle))
                            {
                                if (PlayerMod.CritPerLvl >= 0)
                                    PlayerMod.CritPerLvl += 1;
                            }
                            if (Main.attackSpeedToggle)
                            {
                                if (GUI.Button(btn.BtnRect(6, true, "playermod"), "A T T A C K   S P E E D ( O N ) : " + PlayerMod.attackSpeed.ToString(), OnStyle))
                                {
                                    Main.attackSpeedToggle = false;
                                }
                            }
                            else if (GUI.Button(btn.BtnRect(6, true, "playermod"), "A T T A C K   S P E E D ( O F F ) : " + PlayerMod.attackSpeed.ToString(), OffStyle))
                            {
                                Main.attackSpeedToggle = true;
                            }
                            if (GUI.Button(new Rect(x + widthSize - 80, y + Main.PlayerModBtnY, 40, 40), "-", OffStyle))
                            {
                                if (PlayerMod.attackSpeed > 0)
                                    PlayerMod.attackSpeed -= 1;
                            }
                            if (GUI.Button(new Rect(x + widthSize - 35, y + Main.PlayerModBtnY, 40, 40), "+", OffStyle))
                            {
                                if (PlayerMod.attackSpeed >= 0)
                                    PlayerMod.attackSpeed += 1;
                            }
                            if (Main.armorToggle)
                            {
                                if (GUI.Button(btn.BtnRect(7, true, "playermod"), "A R M O R ( O N ) : " + PlayerMod.armor.ToString(), OnStyle))
                                {
                                    Main.armorToggle = false;
                                }
                            }
                            else if (GUI.Button(btn.BtnRect(7, true, "playermod"), "A R M O R ( O F F ) : " + PlayerMod.armor.ToString(), OffStyle))
                            {
                                Main.armorToggle = true;
                            }
                            if (GUI.Button(new Rect(x + widthSize - 80, y + Main.PlayerModBtnY, 40, 40), "-", OffStyle))
                            {
                                if (PlayerMod.armor > 0)
                                    PlayerMod.armor -= 10;
                            }
                            if (GUI.Button(new Rect(x + widthSize - 35, y + Main.PlayerModBtnY, 40, 40), "+", OffStyle))
                            {
                                if (PlayerMod.armor >= 0)
                                    PlayerMod.armor += 10;
                            }
                            if (Main.moveSpeedToggle)
                            {
                                if (GUI.Button(btn.BtnRect(8, true, "playermod"), "M O V E   S P E E D ( O N ) : " + PlayerMod.movespeed.ToString(), OnStyle))
                                {
                                    Main.moveSpeedToggle = false;
                                }
                            }
                            else if (GUI.Button(btn.BtnRect(8, true, "playermod"), "M O V E   S P E E D ( O F F ) : " + PlayerMod.movespeed.ToString(), OffStyle))
                            {
                                Main.moveSpeedToggle = true;
                            }
                            if (GUI.Button(new Rect(x + widthSize - 80, y + Main.PlayerModBtnY, 40, 40), "-", OffStyle))
                            {
                                if (PlayerMod.movespeed > 7)
                                    PlayerMod.movespeed -= 10;
                            }
                            if (GUI.Button(new Rect(x + widthSize - 35, y + Main.PlayerModBtnY, 40, 40), "+", OffStyle))
                            {
                                if (PlayerMod.movespeed >= 7)
                                    PlayerMod.movespeed += 10;
                            }
                            if (Main._CharacterToggle)
                            {
                                if (GUI.Button(btn.BtnRect(9, false, "playermod"), "C H A N G E   C H A R A C T E R : ON", OnStyle))
                                {
                                    Main._CharacterToggle = false;
                                }
                            }
                            else if (GUI.Button(btn.BtnRect(9, false, "playermod"), "C H A N G E   C H A R A C T E R : OFF", OffStyle))
                            {
                                Main._CharacterToggle = true;
                            }
                            if (Main._isStatMenuOpen)
                            {
                                if (GUI.Button(btn.BtnRect(10, false, "playermod"), "S H O W   S T A T S : O N", OnStyle))
                                {
                                    Main._isStatMenuOpen = false;
                                }
                            }
                            else if (GUI.Button(btn.BtnRect(10, false, "playermod"), "S H O W   S T A T S : O F F", OffStyle))
                            {
                                Main._isStatMenuOpen = true;
                            }
                            if (Main._isBuffMenuOpen)
                            {
                                if (GUI.Button(btn.BtnRect(11, false, "playermod"), "G I V E   B U F F   M E N U : O N", OnStyle))
                                {
                                    Main._isBuffMenuOpen = false;
                                }
                            }
                            else if (GUI.Button(btn.BtnRect(11, false, "playermod"), "G I V E   B U F F   M E N U : O F F", OffStyle))
                            {
                                Main._isBuffMenuOpen = true;
                            }
                            if (GUI.Button(btn.BtnRect(12, false, "playermod"), "R E M O V E   A L L   B U F F S", buttonStyle))
                            {
                                PlayerMod.RemoveAllBuffs();
                            }
                            if (Main.aimBot)
                            {
                                if (GUI.Button(btn.BtnRect(13, false, "playermod"), "A I M B O T : O N", OnStyle))
                                {
                                    EntityStates.FireNailgun.spreadPitchScale = 0.5f;
                                    EntityStates.FireNailgun.spreadYawScale = 1f;
                                    EntityStates.FireNailgun.spreadBloomValue = 0.2f;
                                    Main.aimBot = false;
                                }
                            }
                            else if (!Main.aimBot)
                            {
                                if (GUI.Button(btn.BtnRect(13, false, "playermod"), "A I M B O T : O F F", OffStyle))
                                {
                                    EntityStates.FireNailgun.spreadPitchScale = 0;
                                    EntityStates.FireNailgun.spreadYawScale = 0;
                                    EntityStates.FireNailgun.spreadBloomValue = 0;
                                    Main.aimBot = true;
                                }
                            }
                            if (Main.alwaysSprint)
                            {
                                if (GUI.Button(btn.BtnRect(14, false, "playermod"), "A L W A Y S   S P R I N T : O N", OnStyle))
                                {
                                    Main.alwaysSprint = false;
                                }
                            }
                            else if (!Main.alwaysSprint)
                            {
                                if (GUI.Button(btn.BtnRect(14, false, "playermod"), "A L W A Y S   S P R I N T : O F F", OffStyle))
                                {
                                    Main.alwaysSprint = true;
                                }
                            }
                            if (Main.FlightToggle)
                            {
                                if (GUI.Button(btn.BtnRect(15, false, "playermod"), "F L I G H T : O N", OnStyle))
                                {
                                    if (PlayerMod.GetCurrentCharacter().ToString() != "Loader")
                                    {
                                        Main.LocalPlayerBody.bodyFlags &= CharacterBody.BodyFlags.None;
                                    }
                                    Main.FlightToggle = false;
                                }
                            }
                            else if (GUI.Button(btn.BtnRect(15, false, "playermod"), "F L I G H T : O F F", OffStyle))
                            {
                                Main.FlightToggle = true;
                            }
                            if (Main.godToggle)
                            {
                                if (GUI.Button(btn.BtnRect(16, false, "playermod"), "G O D   M O D E : O N", OnStyle))
                                {
                                    Main.godToggle = false;
                                }
                            }
                            else if (GUI.Button(btn.BtnRect(16, false, "playermod"), "G O D   M O D E : O F F", OffStyle))
                            {
                                Main.godToggle = true;
                            }
                            if (Main.skillToggle)
                            {
                                if (GUI.Button(btn.BtnRect(17, false, "playermod"), "I N F I N I T E   S K I L L S : O N", OnStyle))
                                {
                                    Main.skillToggle = false;
                                }
                            }
                            else if (GUI.Button(btn.BtnRect(17, false, "playermod"), "I N F I N I T E   S K I L L S : O F F", OffStyle))
                            {
                                Main.skillToggle = true;
                            }
                            if (GUI.Button(btn.BtnRect(18, false, "playermod"), "U N L O C K   A L L", buttonStyle))
                            {
                                PlayerMod.UnlockAll();
                            }
                            break;
                        }

                    case 3:
                        {
                            if (GUI.Button(btn.BtnRect(1, true, "playermod"), "G I V E   M O N E Y : " + PlayerMod.moneyToGive.ToString(), buttonStyle))
                            {
                                PlayerMod.GiveMoney();
                            }
                            if (GUI.Button(new Rect(x + widthSize - 80, y + Main.PlayerModBtnY, 40, 40), "-", OffStyle))
                            {
                                if (PlayerMod.moneyToGive > 50)
                                    PlayerMod.moneyToGive -= 50;
                            }
                            if (GUI.Button(new Rect(x + widthSize - 35, y + Main.PlayerModBtnY, 40, 40), "+", OffStyle))
                            {
                                if (PlayerMod.moneyToGive >= 50)
                                    PlayerMod.moneyToGive += 50;
                            }
                            if (GUI.Button(btn.BtnRect(2, true, "playermod"), "G I V E   L U N A R   C O I N S : " + PlayerMod.coinsToGive.ToString(), buttonStyle))
                            {
                                PlayerMod.GiveLunarCoins();
                            }
                            if (GUI.Button(new Rect(x + widthSize - 80, y + Main.PlayerModBtnY, 40, 40), "-", OffStyle))
                            {
                                if (PlayerMod.coinsToGive > 10)
                                    PlayerMod.coinsToGive -= 10;
                            }
                            if (GUI.Button(new Rect(x + widthSize - 35, y + Main.PlayerModBtnY, 40, 40), "+", OffStyle))
                            {
                                if (PlayerMod.coinsToGive >= 10)
                                    PlayerMod.coinsToGive += 10;
                            }
                            if (GUI.Button(btn.BtnRect(3, true, "playermod"), "G I V E   E X P E R I E N C E : " + PlayerMod.xpToGive.ToString(), buttonStyle))
                            {
                                PlayerMod.GiveXP();
                            }
                            if (GUI.Button(new Rect(x + widthSize - 80, y + Main.PlayerModBtnY, 40, 40), "-", OffStyle))
                            {
                                if (PlayerMod.xpToGive > 50)
                                    PlayerMod.xpToGive -= 50;
                            }
                            if (GUI.Button(new Rect(x + widthSize - 35, y + Main.PlayerModBtnY, 40, 40), "+", OffStyle))
                            {
                                if (PlayerMod.xpToGive >= 50)
                                    PlayerMod.xpToGive += 50;
                            }
                            if (Main.damageToggle)
                            {
                                if (GUI.Button(btn.BtnRect(4, true, "playermod"), "D A M A G E   P E R   L V L ( O N ) : " + PlayerMod.damagePerLvl.ToString(), Highlighted))
                                {
                                    Main.damageToggle = false;
                                }
                            }
                            else if (GUI.Button(btn.BtnRect(4, true, "playermod"), "D A M A G E   P E R   L V L ( O F F ) : " + PlayerMod.damagePerLvl.ToString(), Highlighted))
                            {
                                Main.damageToggle = true;
                            }
                            if (GUI.Button(new Rect(x + widthSize - 80, y + Main.PlayerModBtnY, 40, 40), "-", OffStyle))
                            {
                                if (PlayerMod.damagePerLvl > 0)
                                    PlayerMod.damagePerLvl -= 10;
                            }
                            if (GUI.Button(new Rect(x + widthSize - 35, y + Main.PlayerModBtnY, 40, 40), "+", OffStyle))
                            {
                                if (PlayerMod.damagePerLvl >= 0)
                                    PlayerMod.damagePerLvl += 10;
                            }
                            if (Main.critToggle)
                            {
                                if (GUI.Button(btn.BtnRect(5, true, "playermod"), "C R I T   P E R   L V L ( O N ) : " + PlayerMod.CritPerLvl.ToString(), OnStyle))
                                {
                                    Main.critToggle = false;
                                }
                            }
                            else if (GUI.Button(btn.BtnRect(5, true, "playermod"), "C R I T   P E R   L V L ( O F F ) : " + PlayerMod.CritPerLvl.ToString(), OffStyle))
                            {
                                Main.critToggle = true;
                            }
                            if (GUI.Button(new Rect(x + widthSize - 80, y + Main.PlayerModBtnY, 40, 40), "-", OffStyle))
                            {
                                if (PlayerMod.CritPerLvl > 0)
                                    PlayerMod.CritPerLvl -= 1;
                            }
                            if (GUI.Button(new Rect(x + widthSize - 35, y + Main.PlayerModBtnY, 40, 40), "+", OffStyle))
                            {
                                if (PlayerMod.CritPerLvl >= 0)
                                    PlayerMod.CritPerLvl += 1;
                            }
                            if (Main.attackSpeedToggle)
                            {
                                if (GUI.Button(btn.BtnRect(6, true, "playermod"), "A T T A C K   S P E E D ( O N ) : " + PlayerMod.attackSpeed.ToString(), OnStyle))
                                {
                                    Main.attackSpeedToggle = false;
                                }
                            }
                            else if (GUI.Button(btn.BtnRect(6, true, "playermod"), "A T T A C K   S P E E D ( O F F ) : " + PlayerMod.attackSpeed.ToString(), OffStyle))
                            {
                                Main.attackSpeedToggle = true;
                            }
                            if (GUI.Button(new Rect(x + widthSize - 80, y + Main.PlayerModBtnY, 40, 40), "-", OffStyle))
                            {
                                if (PlayerMod.attackSpeed > 0)
                                    PlayerMod.attackSpeed -= 1;
                            }
                            if (GUI.Button(new Rect(x + widthSize - 35, y + Main.PlayerModBtnY, 40, 40), "+", OffStyle))
                            {
                                if (PlayerMod.attackSpeed >= 0)
                                    PlayerMod.attackSpeed += 1;
                            }
                            if (Main.armorToggle)
                            {
                                if (GUI.Button(btn.BtnRect(7, true, "playermod"), "A R M O R ( O N ) : " + PlayerMod.armor.ToString(), OnStyle))
                                {
                                    Main.armorToggle = false;
                                }
                            }
                            else if (GUI.Button(btn.BtnRect(7, true, "playermod"), "A R M O R ( O F F ) : " + PlayerMod.armor.ToString(), OffStyle))
                            {
                                Main.armorToggle = true;
                            }
                            if (GUI.Button(new Rect(x + widthSize - 80, y + Main.PlayerModBtnY, 40, 40), "-", OffStyle))
                            {
                                if (PlayerMod.armor > 0)
                                    PlayerMod.armor -= 10;
                            }
                            if (GUI.Button(new Rect(x + widthSize - 35, y + Main.PlayerModBtnY, 40, 40), "+", OffStyle))
                            {
                                if (PlayerMod.armor >= 0)
                                    PlayerMod.armor += 10;
                            }
                            if (Main.moveSpeedToggle)
                            {
                                if (GUI.Button(btn.BtnRect(8, true, "playermod"), "M O V E   S P E E D ( O N ) : " + PlayerMod.movespeed.ToString(), OnStyle))
                                {
                                    Main.moveSpeedToggle = false;
                                }
                            }
                            else if (GUI.Button(btn.BtnRect(8, true, "playermod"), "M O V E   S P E E D ( O F F ) : " + PlayerMod.movespeed.ToString(), OffStyle))
                            {
                                Main.moveSpeedToggle = true;
                            }
                            if (GUI.Button(new Rect(x + widthSize - 80, y + Main.PlayerModBtnY, 40, 40), "-", OffStyle))
                            {
                                if (PlayerMod.movespeed > 7)
                                    PlayerMod.movespeed -= 10;
                            }
                            if (GUI.Button(new Rect(x + widthSize - 35, y + Main.PlayerModBtnY, 40, 40), "+", OffStyle))
                            {
                                if (PlayerMod.movespeed >= 7)
                                    PlayerMod.movespeed += 10;
                            }
                            if (Main._CharacterToggle)
                            {
                                if (GUI.Button(btn.BtnRect(9, false, "playermod"), "C H A N G E   C H A R A C T E R : ON", OnStyle))
                                {
                                    Main._CharacterToggle = false;
                                }
                            }
                            else if (GUI.Button(btn.BtnRect(9, false, "playermod"), "C H A N G E   C H A R A C T E R : OFF", OffStyle))
                            {
                                Main._CharacterToggle = true;
                            }
                            if (Main._isStatMenuOpen)
                            {
                                if (GUI.Button(btn.BtnRect(10, false, "playermod"), "S H O W   S T A T S : O N", OnStyle))
                                {
                                    Main._isStatMenuOpen = false;
                                }
                            }
                            else if (GUI.Button(btn.BtnRect(10, false, "playermod"), "S H O W   S T A T S : O F F", OffStyle))
                            {
                                Main._isStatMenuOpen = true;
                            }
                            if (Main._isBuffMenuOpen)
                            {
                                if (GUI.Button(btn.BtnRect(11, false, "playermod"), "G I V E   B U F F   M E N U : O N", OnStyle))
                                {
                                    Main._isBuffMenuOpen = false;
                                }
                            }
                            else if (GUI.Button(btn.BtnRect(11, false, "playermod"), "G I V E   B U F F   M E N U : O F F", OffStyle))
                            {
                                Main._isBuffMenuOpen = true;
                            }
                            if (GUI.Button(btn.BtnRect(12, false, "playermod"), "R E M O V E   A L L   B U F F S", buttonStyle))
                            {
                                PlayerMod.RemoveAllBuffs();
                            }
                            if (Main.aimBot)
                            {
                                if (GUI.Button(btn.BtnRect(13, false, "playermod"), "A I M B O T : O N", OnStyle))
                                {
                                    EntityStates.FireNailgun.spreadPitchScale = 0.5f;
                                    EntityStates.FireNailgun.spreadYawScale = 1f;
                                    EntityStates.FireNailgun.spreadBloomValue = 0.2f;
                                    Main.aimBot = false;
                                }
                            }
                            else if (!Main.aimBot)
                            {
                                if (GUI.Button(btn.BtnRect(13, false, "playermod"), "A I M B O T : O F F", OffStyle))
                                {
                                    EntityStates.FireNailgun.spreadPitchScale = 0;
                                    EntityStates.FireNailgun.spreadYawScale = 0;
                                    EntityStates.FireNailgun.spreadBloomValue = 0;
                                    Main.aimBot = true;
                                }
                            }
                            if (Main.alwaysSprint)
                            {
                                if (GUI.Button(btn.BtnRect(14, false, "playermod"), "A L W A Y S   S P R I N T : O N", OnStyle))
                                {
                                    Main.alwaysSprint = false;
                                }
                            }
                            else if (!Main.alwaysSprint)
                            {
                                if (GUI.Button(btn.BtnRect(14, false, "playermod"), "A L W A Y S   S P R I N T : O F F", OffStyle))
                                {
                                    Main.alwaysSprint = true;
                                }
                            }
                            if (Main.FlightToggle)
                            {
                                if (GUI.Button(btn.BtnRect(15, false, "playermod"), "F L I G H T : O N", OnStyle))
                                {
                                    if (PlayerMod.GetCurrentCharacter().ToString() != "Loader")
                                    {
                                        Main.LocalPlayerBody.bodyFlags &= CharacterBody.BodyFlags.None;
                                    }
                                    Main.FlightToggle = false;
                                }
                            }
                            else if (GUI.Button(btn.BtnRect(15, false, "playermod"), "F L I G H T : O F F", OffStyle))
                            {
                                Main.FlightToggle = true;
                            }
                            if (Main.godToggle)
                            {
                                if (GUI.Button(btn.BtnRect(16, false, "playermod"), "G O D   M O D E : O N", OnStyle))
                                {
                                    Main.godToggle = false;
                                }
                            }
                            else if (GUI.Button(btn.BtnRect(16, false, "playermod"), "G O D   M O D E : O F F", OffStyle))
                            {
                                Main.godToggle = true;
                            }
                            if (Main.skillToggle)
                            {
                                if (GUI.Button(btn.BtnRect(17, false, "playermod"), "I N F I N I T E   S K I L L S : O N", OnStyle))
                                {
                                    Main.skillToggle = false;
                                }
                            }
                            else if (GUI.Button(btn.BtnRect(17, false, "playermod"), "I N F I N I T E   S K I L L S : O F F", OffStyle))
                            {
                                Main.skillToggle = true;
                            }
                            if (GUI.Button(btn.BtnRect(18, false, "playermod"), "U N L O C K   A L L", buttonStyle))
                            {
                                PlayerMod.UnlockAll();
                            }
                            break;
                        }

                    case 4:
                        {
                            if (GUI.Button(btn.BtnRect(1, true, "playermod"), "G I V E   M O N E Y : " + PlayerMod.moneyToGive.ToString(), buttonStyle))
                            {
                                PlayerMod.GiveMoney();
                            }
                            if (GUI.Button(new Rect(x + widthSize - 80, y + Main.PlayerModBtnY, 40, 40), "-", OffStyle))
                            {
                                if (PlayerMod.moneyToGive > 50)
                                    PlayerMod.moneyToGive -= 50;
                            }
                            if (GUI.Button(new Rect(x + widthSize - 35, y + Main.PlayerModBtnY, 40, 40), "+", OffStyle))
                            {
                                if (PlayerMod.moneyToGive >= 50)
                                    PlayerMod.moneyToGive += 50;
                            }
                            if (GUI.Button(btn.BtnRect(2, true, "playermod"), "G I V E   L U N A R   C O I N S : " + PlayerMod.coinsToGive.ToString(), buttonStyle))
                            {
                                PlayerMod.GiveLunarCoins();
                            }
                            if (GUI.Button(new Rect(x + widthSize - 80, y + Main.PlayerModBtnY, 40, 40), "-", OffStyle))
                            {
                                if (PlayerMod.coinsToGive > 10)
                                    PlayerMod.coinsToGive -= 10;
                            }
                            if (GUI.Button(new Rect(x + widthSize - 35, y + Main.PlayerModBtnY, 40, 40), "+", OffStyle))
                            {
                                if (PlayerMod.coinsToGive >= 10)
                                    PlayerMod.coinsToGive += 10;
                            }
                            if (GUI.Button(btn.BtnRect(3, true, "playermod"), "G I V E   E X P E R I E N C E : " + PlayerMod.xpToGive.ToString(), buttonStyle))
                            {
                                PlayerMod.GiveXP();
                            }
                            if (GUI.Button(new Rect(x + widthSize - 80, y + Main.PlayerModBtnY, 40, 40), "-", OffStyle))
                            {
                                if (PlayerMod.xpToGive > 50)
                                    PlayerMod.xpToGive -= 50;
                            }
                            if (GUI.Button(new Rect(x + widthSize - 35, y + Main.PlayerModBtnY, 40, 40), "+", OffStyle))
                            {
                                if (PlayerMod.xpToGive >= 50)
                                    PlayerMod.xpToGive += 50;
                            }
                            if (Main.damageToggle)
                            {
                                if (GUI.Button(btn.BtnRect(4, true, "playermod"), "D A M A G E   P E R   L V L ( O N ) : " + PlayerMod.damagePerLvl.ToString(), OnStyle))
                                {
                                    Main.damageToggle = false;
                                }
                            }
                            else if (GUI.Button(btn.BtnRect(4, true, "playermod"), "D A M A G E   P E R   L V L ( O F F ) : " + PlayerMod.damagePerLvl.ToString(), OffStyle))
                            {
                                Main.damageToggle = true;
                            }
                            if (GUI.Button(new Rect(x + widthSize - 80, y + Main.PlayerModBtnY, 40, 40), "-", OffStyle))
                            {
                                if (PlayerMod.damagePerLvl > 0)
                                    PlayerMod.damagePerLvl -= 10;
                            }
                            if (GUI.Button(new Rect(x + widthSize - 35, y + Main.PlayerModBtnY, 40, 40), "+", OffStyle))
                            {
                                if (PlayerMod.damagePerLvl >= 0)
                                    PlayerMod.damagePerLvl += 10;
                            }
                            if (Main.critToggle)
                            {
                                if (GUI.Button(btn.BtnRect(5, true, "playermod"), "C R I T   P E R   L V L ( O N ) : " + PlayerMod.CritPerLvl.ToString(), Highlighted))
                                {
                                    Main.critToggle = false;
                                }
                            }
                            else if (GUI.Button(btn.BtnRect(5, true, "playermod"), "C R I T   P E R   L V L ( O F F ) : " + PlayerMod.CritPerLvl.ToString(), Highlighted))
                            {
                                Main.critToggle = true;
                            }
                            if (GUI.Button(new Rect(x + widthSize - 80, y + Main.PlayerModBtnY, 40, 40), "-", OffStyle))
                            {
                                if (PlayerMod.CritPerLvl > 0)
                                    PlayerMod.CritPerLvl -= 1;
                            }
                            if (GUI.Button(new Rect(x + widthSize - 35, y + Main.PlayerModBtnY, 40, 40), "+", OffStyle))
                            {
                                if (PlayerMod.CritPerLvl >= 0)
                                    PlayerMod.CritPerLvl += 1;
                            }
                            if (Main.attackSpeedToggle)
                            {
                                if (GUI.Button(btn.BtnRect(6, true, "playermod"), "A T T A C K   S P E E D ( O N ) : " + PlayerMod.attackSpeed.ToString(), OnStyle))
                                {
                                    Main.attackSpeedToggle = false;
                                }
                            }
                            else if (GUI.Button(btn.BtnRect(6, true, "playermod"), "A T T A C K   S P E E D ( O F F ) : " + PlayerMod.attackSpeed.ToString(), OffStyle))
                            {
                                Main.attackSpeedToggle = true;
                            }
                            if (GUI.Button(new Rect(x + widthSize - 80, y + Main.PlayerModBtnY, 40, 40), "-", OffStyle))
                            {
                                if (PlayerMod.attackSpeed > 0)
                                    PlayerMod.attackSpeed -= 1;
                            }
                            if (GUI.Button(new Rect(x + widthSize - 35, y + Main.PlayerModBtnY, 40, 40), "+", OffStyle))
                            {
                                if (PlayerMod.attackSpeed >= 0)
                                    PlayerMod.attackSpeed += 1;
                            }
                            if (Main.armorToggle)
                            {
                                if (GUI.Button(btn.BtnRect(7, true, "playermod"), "A R M O R ( O N ) : " + PlayerMod.armor.ToString(), OnStyle))
                                {
                                    Main.armorToggle = false;
                                }
                            }
                            else if (GUI.Button(btn.BtnRect(7, true, "playermod"), "A R M O R ( O F F ) : " + PlayerMod.armor.ToString(), OffStyle))
                            {
                                Main.armorToggle = true;
                            }
                            if (GUI.Button(new Rect(x + widthSize - 80, y + Main.PlayerModBtnY, 40, 40), "-", OffStyle))
                            {
                                if (PlayerMod.armor > 0)
                                    PlayerMod.armor -= 10;
                            }
                            if (GUI.Button(new Rect(x + widthSize - 35, y + Main.PlayerModBtnY, 40, 40), "+", OffStyle))
                            {
                                if (PlayerMod.armor >= 0)
                                    PlayerMod.armor += 10;
                            }
                            if (Main.moveSpeedToggle)
                            {
                                if (GUI.Button(btn.BtnRect(8, true, "playermod"), "M O V E   S P E E D ( O N ) : " + PlayerMod.movespeed.ToString(), OnStyle))
                                {
                                    Main.moveSpeedToggle = false;
                                }
                            }
                            else if (GUI.Button(btn.BtnRect(8, true, "playermod"), "M O V E   S P E E D ( O F F ) : " + PlayerMod.movespeed.ToString(), OffStyle))
                            {
                                Main.moveSpeedToggle = true;
                            }
                            if (GUI.Button(new Rect(x + widthSize - 80, y + Main.PlayerModBtnY, 40, 40), "-", OffStyle))
                            {
                                if (PlayerMod.movespeed > 7)
                                    PlayerMod.movespeed -= 10;
                            }
                            if (GUI.Button(new Rect(x + widthSize - 35, y + Main.PlayerModBtnY, 40, 40), "+", OffStyle))
                            {
                                if (PlayerMod.movespeed >= 7)
                                    PlayerMod.movespeed += 10;
                            }
                            if (Main._CharacterToggle)
                            {
                                if (GUI.Button(btn.BtnRect(9, false, "playermod"), "C H A N G E   C H A R A C T E R : ON", OnStyle))
                                {
                                    Main._CharacterToggle = false;
                                }
                            }
                            else if (GUI.Button(btn.BtnRect(9, false, "playermod"), "C H A N G E   C H A R A C T E R : OFF", OffStyle))
                            {
                                Main._CharacterToggle = true;
                            }
                            if (Main._isStatMenuOpen)
                            {
                                if (GUI.Button(btn.BtnRect(10, false, "playermod"), "S H O W   S T A T S : O N", OnStyle))
                                {
                                    Main._isStatMenuOpen = false;
                                }
                            }
                            else if (GUI.Button(btn.BtnRect(10, false, "playermod"), "S H O W   S T A T S : O F F", OffStyle))
                            {
                                Main._isStatMenuOpen = true;
                            }
                            if (Main._isBuffMenuOpen)
                            {
                                if (GUI.Button(btn.BtnRect(11, false, "playermod"), "G I V E   B U F F   M E N U : O N", OnStyle))
                                {
                                    Main._isBuffMenuOpen = false;
                                }
                            }
                            else if (GUI.Button(btn.BtnRect(11, false, "playermod"), "G I V E   B U F F   M E N U : O F F", OffStyle))
                            {
                                Main._isBuffMenuOpen = true;
                            }
                            if (GUI.Button(btn.BtnRect(12, false, "playermod"), "R E M O V E   A L L   B U F F S", buttonStyle))
                            {
                                PlayerMod.RemoveAllBuffs();
                            }
                            if (Main.aimBot)
                            {
                                if (GUI.Button(btn.BtnRect(13, false, "playermod"), "A I M B O T : O N", OnStyle))
                                {
                                    EntityStates.FireNailgun.spreadPitchScale = 0.5f;
                                    EntityStates.FireNailgun.spreadYawScale = 1f;
                                    EntityStates.FireNailgun.spreadBloomValue = 0.2f;
                                    Main.aimBot = false;
                                }
                            }
                            else if (!Main.aimBot)
                            {
                                if (GUI.Button(btn.BtnRect(13, false, "playermod"), "A I M B O T : O F F", OffStyle))
                                {
                                    EntityStates.FireNailgun.spreadPitchScale = 0;
                                    EntityStates.FireNailgun.spreadYawScale = 0;
                                    EntityStates.FireNailgun.spreadBloomValue = 0;
                                    Main.aimBot = true;
                                }
                            }
                            if (Main.alwaysSprint)
                            {
                                if (GUI.Button(btn.BtnRect(14, false, "playermod"), "A L W A Y S   S P R I N T : O N", OnStyle))
                                {
                                    Main.alwaysSprint = false;
                                }
                            }
                            else if (!Main.alwaysSprint)
                            {
                                if (GUI.Button(btn.BtnRect(14, false, "playermod"), "A L W A Y S   S P R I N T : O F F", OffStyle))
                                {
                                    Main.alwaysSprint = true;
                                }
                            }
                            if (Main.FlightToggle)
                            {
                                if (GUI.Button(btn.BtnRect(15, false, "playermod"), "F L I G H T : O N", OnStyle))
                                {
                                    if (PlayerMod.GetCurrentCharacter().ToString() != "Loader")
                                    {
                                        Main.LocalPlayerBody.bodyFlags &= CharacterBody.BodyFlags.None;
                                    }
                                    Main.FlightToggle = false;
                                }
                            }
                            else if (GUI.Button(btn.BtnRect(15, false, "playermod"), "F L I G H T : O F F", OffStyle))
                            {
                                Main.FlightToggle = true;
                            }
                            if (Main.godToggle)
                            {
                                if (GUI.Button(btn.BtnRect(16, false, "playermod"), "G O D   M O D E : O N", OnStyle))
                                {
                                    Main.godToggle = false;
                                }
                            }
                            else if (GUI.Button(btn.BtnRect(16, false, "playermod"), "G O D   M O D E : O F F", OffStyle))
                            {
                                Main.godToggle = true;
                            }
                            if (Main.skillToggle)
                            {
                                if (GUI.Button(btn.BtnRect(17, false, "playermod"), "I N F I N I T E   S K I L L S : O N", OnStyle))
                                {
                                    Main.skillToggle = false;
                                }
                            }
                            else if (GUI.Button(btn.BtnRect(17, false, "playermod"), "I N F I N I T E   S K I L L S : O F F", OffStyle))
                            {
                                Main.skillToggle = true;
                            }
                            if (GUI.Button(btn.BtnRect(18, false, "playermod"), "U N L O C K   A L L", buttonStyle))
                            {
                                PlayerMod.UnlockAll();
                            }
                            break;
                        }

                    case 5:
                        {
                            if (GUI.Button(btn.BtnRect(1, true, "playermod"), "G I V E   M O N E Y : " + PlayerMod.moneyToGive.ToString(), buttonStyle))
                            {
                                PlayerMod.GiveMoney();
                            }
                            if (GUI.Button(new Rect(x + widthSize - 80, y + Main.PlayerModBtnY, 40, 40), "-", OffStyle))
                            {
                                if (PlayerMod.moneyToGive > 50)
                                    PlayerMod.moneyToGive -= 50;
                            }
                            if (GUI.Button(new Rect(x + widthSize - 35, y + Main.PlayerModBtnY, 40, 40), "+", OffStyle))
                            {
                                if (PlayerMod.moneyToGive >= 50)
                                    PlayerMod.moneyToGive += 50;
                            }
                            if (GUI.Button(btn.BtnRect(2, true, "playermod"), "G I V E   L U N A R   C O I N S : " + PlayerMod.coinsToGive.ToString(), buttonStyle))
                            {
                                PlayerMod.GiveLunarCoins();
                            }
                            if (GUI.Button(new Rect(x + widthSize - 80, y + Main.PlayerModBtnY, 40, 40), "-", OffStyle))
                            {
                                if (PlayerMod.coinsToGive > 10)
                                    PlayerMod.coinsToGive -= 10;
                            }
                            if (GUI.Button(new Rect(x + widthSize - 35, y + Main.PlayerModBtnY, 40, 40), "+", OffStyle))
                            {
                                if (PlayerMod.coinsToGive >= 10)
                                    PlayerMod.coinsToGive += 10;
                            }
                            if (GUI.Button(btn.BtnRect(3, true, "playermod"), "G I V E   E X P E R I E N C E : " + PlayerMod.xpToGive.ToString(), buttonStyle))
                            {
                                PlayerMod.GiveXP();
                            }
                            if (GUI.Button(new Rect(x + widthSize - 80, y + Main.PlayerModBtnY, 40, 40), "-", OffStyle))
                            {
                                if (PlayerMod.xpToGive > 50)
                                    PlayerMod.xpToGive -= 50;
                            }
                            if (GUI.Button(new Rect(x + widthSize - 35, y + Main.PlayerModBtnY, 40, 40), "+", OffStyle))
                            {
                                if (PlayerMod.xpToGive >= 50)
                                    PlayerMod.xpToGive += 50;
                            }
                            if (Main.damageToggle)
                            {
                                if (GUI.Button(btn.BtnRect(4, true, "playermod"), "D A M A G E   P E R   L V L ( O N ) : " + PlayerMod.damagePerLvl.ToString(), OnStyle))
                                {
                                    Main.damageToggle = false;
                                }
                            }
                            else if (GUI.Button(btn.BtnRect(4, true, "playermod"), "D A M A G E   P E R   L V L ( O F F ) : " + PlayerMod.damagePerLvl.ToString(), OffStyle))
                            {
                                Main.damageToggle = true;
                            }
                            if (GUI.Button(new Rect(x + widthSize - 80, y + Main.PlayerModBtnY, 40, 40), "-", OffStyle))
                            {
                                if (PlayerMod.damagePerLvl > 0)
                                    PlayerMod.damagePerLvl -= 10;
                            }
                            if (GUI.Button(new Rect(x + widthSize - 35, y + Main.PlayerModBtnY, 40, 40), "+", OffStyle))
                            {
                                if (PlayerMod.damagePerLvl >= 0)
                                    PlayerMod.damagePerLvl += 10;
                            }
                            if (Main.critToggle)
                            {
                                if (GUI.Button(btn.BtnRect(5, true, "playermod"), "C R I T   P E R   L V L ( O N ) : " + PlayerMod.CritPerLvl.ToString(), OnStyle))
                                {
                                    Main.critToggle = false;
                                }
                            }
                            else if (GUI.Button(btn.BtnRect(5, true, "playermod"), "C R I T   P E R   L V L ( O F F ) : " + PlayerMod.CritPerLvl.ToString(), OffStyle))
                            {
                                Main.critToggle = true;
                            }
                            if (GUI.Button(new Rect(x + widthSize - 80, y + Main.PlayerModBtnY, 40, 40), "-", OffStyle))
                            {
                                if (PlayerMod.CritPerLvl > 0)
                                    PlayerMod.CritPerLvl -= 1;
                            }
                            if (GUI.Button(new Rect(x + widthSize - 35, y + Main.PlayerModBtnY, 40, 40), "+", OffStyle))
                            {
                                if (PlayerMod.CritPerLvl >= 0)
                                    PlayerMod.CritPerLvl += 1;
                            }
                            if (Main.attackSpeedToggle)
                            {
                                if (GUI.Button(btn.BtnRect(6, true, "playermod"), "A T T A C K   S P E E D ( O N ) : " + PlayerMod.attackSpeed.ToString(), Highlighted))
                                {
                                    Main.attackSpeedToggle = false;
                                }
                            }
                            else if (GUI.Button(btn.BtnRect(6, true, "playermod"), "A T T A C K   S P E E D ( O F F ) : " + PlayerMod.attackSpeed.ToString(), Highlighted))
                            {
                                Main.attackSpeedToggle = true;
                            }
                            if (GUI.Button(new Rect(x + widthSize - 80, y + Main.PlayerModBtnY, 40, 40), "-", OffStyle))
                            {
                                if (PlayerMod.attackSpeed > 0)
                                    PlayerMod.attackSpeed -= 1;
                            }
                            if (GUI.Button(new Rect(x + widthSize - 35, y + Main.PlayerModBtnY, 40, 40), "+", OffStyle))
                            {
                                if (PlayerMod.attackSpeed >= 0)
                                    PlayerMod.attackSpeed += 1;
                            }
                            if (Main.armorToggle)
                            {
                                if (GUI.Button(btn.BtnRect(7, true, "playermod"), "A R M O R ( O N ) : " + PlayerMod.armor.ToString(), OnStyle))
                                {
                                    Main.armorToggle = false;
                                }
                            }
                            else if (GUI.Button(btn.BtnRect(7, true, "playermod"), "A R M O R ( O F F ) : " + PlayerMod.armor.ToString(), OffStyle))
                            {
                                Main.armorToggle = true;
                            }
                            if (GUI.Button(new Rect(x + widthSize - 80, y + Main.PlayerModBtnY, 40, 40), "-", OffStyle))
                            {
                                if (PlayerMod.armor > 0)
                                    PlayerMod.armor -= 10;
                            }
                            if (GUI.Button(new Rect(x + widthSize - 35, y + Main.PlayerModBtnY, 40, 40), "+", OffStyle))
                            {
                                if (PlayerMod.armor >= 0)
                                    PlayerMod.armor += 10;
                            }
                            if (Main.moveSpeedToggle)
                            {
                                if (GUI.Button(btn.BtnRect(8, true, "playermod"), "M O V E   S P E E D ( O N ) : " + PlayerMod.movespeed.ToString(), OnStyle))
                                {
                                    Main.moveSpeedToggle = false;
                                }
                            }
                            else if (GUI.Button(btn.BtnRect(8, true, "playermod"), "M O V E   S P E E D ( O F F ) : " + PlayerMod.movespeed.ToString(), OffStyle))
                            {
                                Main.moveSpeedToggle = true;
                            }
                            if (GUI.Button(new Rect(x + widthSize - 80, y + Main.PlayerModBtnY, 40, 40), "-", OffStyle))
                            {
                                if (PlayerMod.movespeed > 7)
                                    PlayerMod.movespeed -= 10;
                            }
                            if (GUI.Button(new Rect(x + widthSize - 35, y + Main.PlayerModBtnY, 40, 40), "+", OffStyle))
                            {
                                if (PlayerMod.movespeed >= 7)
                                    PlayerMod.movespeed += 10;
                            }
                            if (Main._CharacterToggle)
                            {
                                if (GUI.Button(btn.BtnRect(9, false, "playermod"), "C H A N G E   C H A R A C T E R : ON", OnStyle))
                                {
                                    Main._CharacterToggle = false;
                                }
                            }
                            else if (GUI.Button(btn.BtnRect(9, false, "playermod"), "C H A N G E   C H A R A C T E R : OFF", OffStyle))
                            {
                                Main._CharacterToggle = true;
                            }
                            if (Main._isStatMenuOpen)
                            {
                                if (GUI.Button(btn.BtnRect(10, false, "playermod"), "S H O W   S T A T S : O N", OnStyle))
                                {
                                    Main._isStatMenuOpen = false;
                                }
                            }
                            else if (GUI.Button(btn.BtnRect(10, false, "playermod"), "S H O W   S T A T S : O F F", OffStyle))
                            {
                                Main._isStatMenuOpen = true;
                            }
                            if (Main._isBuffMenuOpen)
                            {
                                if (GUI.Button(btn.BtnRect(11, false, "playermod"), "G I V E   B U F F   M E N U : O N", OnStyle))
                                {
                                    Main._isBuffMenuOpen = false;
                                }
                            }
                            else if (GUI.Button(btn.BtnRect(11, false, "playermod"), "G I V E   B U F F   M E N U : O F F", OffStyle))
                            {
                                Main._isBuffMenuOpen = true;
                            }
                            if (GUI.Button(btn.BtnRect(12, false, "playermod"), "R E M O V E   A L L   B U F F S", buttonStyle))
                            {
                                PlayerMod.RemoveAllBuffs();
                            }
                            if (Main.aimBot)
                            {
                                if (GUI.Button(btn.BtnRect(13, false, "playermod"), "A I M B O T : O N", OnStyle))
                                {
                                    EntityStates.FireNailgun.spreadPitchScale = 0.5f;
                                    EntityStates.FireNailgun.spreadYawScale = 1f;
                                    EntityStates.FireNailgun.spreadBloomValue = 0.2f;
                                    Main.aimBot = false;
                                }
                            }
                            else if (!Main.aimBot)
                            {
                                if (GUI.Button(btn.BtnRect(13, false, "playermod"), "A I M B O T : O F F", OffStyle))
                                {
                                    EntityStates.FireNailgun.spreadPitchScale = 0;
                                    EntityStates.FireNailgun.spreadYawScale = 0;
                                    EntityStates.FireNailgun.spreadBloomValue = 0;
                                    Main.aimBot = true;
                                }
                            }
                            if (Main.alwaysSprint)
                            {
                                if (GUI.Button(btn.BtnRect(14, false, "playermod"), "A L W A Y S   S P R I N T : O N", OnStyle))
                                {
                                    Main.alwaysSprint = false;
                                }
                            }
                            else if (!Main.alwaysSprint)
                            {
                                if (GUI.Button(btn.BtnRect(14, false, "playermod"), "A L W A Y S   S P R I N T : O F F", OffStyle))
                                {
                                    Main.alwaysSprint = true;
                                }
                            }
                            if (Main.FlightToggle)
                            {
                                if (GUI.Button(btn.BtnRect(15, false, "playermod"), "F L I G H T : O N", OnStyle))
                                {
                                    if (PlayerMod.GetCurrentCharacter().ToString() != "Loader")
                                    {
                                        Main.LocalPlayerBody.bodyFlags &= CharacterBody.BodyFlags.None;
                                    }
                                    Main.FlightToggle = false;
                                }
                            }
                            else if (GUI.Button(btn.BtnRect(15, false, "playermod"), "F L I G H T : O F F", OffStyle))
                            {
                                Main.FlightToggle = true;
                            }
                            if (Main.godToggle)
                            {
                                if (GUI.Button(btn.BtnRect(16, false, "playermod"), "G O D   M O D E : O N", OnStyle))
                                {
                                    Main.godToggle = false;
                                }
                            }
                            else if (GUI.Button(btn.BtnRect(16, false, "playermod"), "G O D   M O D E : O F F", OffStyle))
                            {
                                Main.godToggle = true;
                            }
                            if (Main.skillToggle)
                            {
                                if (GUI.Button(btn.BtnRect(17, false, "playermod"), "I N F I N I T E   S K I L L S : O N", OnStyle))
                                {
                                    Main.skillToggle = false;
                                }
                            }
                            else if (GUI.Button(btn.BtnRect(17, false, "playermod"), "I N F I N I T E   S K I L L S : O F F", OffStyle))
                            {
                                Main.skillToggle = true;
                            }
                            if (GUI.Button(btn.BtnRect(18, false, "playermod"), "U N L O C K   A L L", buttonStyle))
                            {
                                PlayerMod.UnlockAll();
                            }
                            break;
                        }

                    case 6:
                        {
                            if (GUI.Button(btn.BtnRect(1, true, "playermod"), "G I V E   M O N E Y : " + PlayerMod.moneyToGive.ToString(), buttonStyle))
                            {
                                PlayerMod.GiveMoney();
                            }
                            if (GUI.Button(new Rect(x + widthSize - 80, y + Main.PlayerModBtnY, 40, 40), "-", OffStyle))
                            {
                                if (PlayerMod.moneyToGive > 50)
                                    PlayerMod.moneyToGive -= 50;
                            }
                            if (GUI.Button(new Rect(x + widthSize - 35, y + Main.PlayerModBtnY, 40, 40), "+", OffStyle))
                            {
                                if (PlayerMod.moneyToGive >= 50)
                                    PlayerMod.moneyToGive += 50;
                            }
                            if (GUI.Button(btn.BtnRect(2, true, "playermod"), "G I V E   L U N A R   C O I N S : " + PlayerMod.coinsToGive.ToString(), buttonStyle))
                            {
                                PlayerMod.GiveLunarCoins();
                            }
                            if (GUI.Button(new Rect(x + widthSize - 80, y + Main.PlayerModBtnY, 40, 40), "-", OffStyle))
                            {
                                if (PlayerMod.coinsToGive > 10)
                                    PlayerMod.coinsToGive -= 10;
                            }
                            if (GUI.Button(new Rect(x + widthSize - 35, y + Main.PlayerModBtnY, 40, 40), "+", OffStyle))
                            {
                                if (PlayerMod.coinsToGive >= 10)
                                    PlayerMod.coinsToGive += 10;
                            }
                            if (GUI.Button(btn.BtnRect(3, true, "playermod"), "G I V E   E X P E R I E N C E : " + PlayerMod.xpToGive.ToString(), buttonStyle))
                            {
                                PlayerMod.GiveXP();
                            }
                            if (GUI.Button(new Rect(x + widthSize - 80, y + Main.PlayerModBtnY, 40, 40), "-", OffStyle))
                            {
                                if (PlayerMod.xpToGive > 50)
                                    PlayerMod.xpToGive -= 50;
                            }
                            if (GUI.Button(new Rect(x + widthSize - 35, y + Main.PlayerModBtnY, 40, 40), "+", OffStyle))
                            {
                                if (PlayerMod.xpToGive >= 50)
                                    PlayerMod.xpToGive += 50;
                            }
                            if (Main.damageToggle)
                            {
                                if (GUI.Button(btn.BtnRect(4, true, "playermod"), "D A M A G E   P E R   L V L ( O N ) : " + PlayerMod.damagePerLvl.ToString(), OnStyle))
                                {
                                    Main.damageToggle = false;
                                }
                            }
                            else if (GUI.Button(btn.BtnRect(4, true, "playermod"), "D A M A G E   P E R   L V L ( O F F ) : " + PlayerMod.damagePerLvl.ToString(), OffStyle))
                            {
                                Main.damageToggle = true;
                            }
                            if (GUI.Button(new Rect(x + widthSize - 80, y + Main.PlayerModBtnY, 40, 40), "-", OffStyle))
                            {
                                if (PlayerMod.damagePerLvl > 0)
                                    PlayerMod.damagePerLvl -= 10;
                            }
                            if (GUI.Button(new Rect(x + widthSize - 35, y + Main.PlayerModBtnY, 40, 40), "+", OffStyle))
                            {
                                if (PlayerMod.damagePerLvl >= 0)
                                    PlayerMod.damagePerLvl += 10;
                            }
                            if (Main.critToggle)
                            {
                                if (GUI.Button(btn.BtnRect(5, true, "playermod"), "C R I T   P E R   L V L ( O N ) : " + PlayerMod.CritPerLvl.ToString(), OnStyle))
                                {
                                    Main.critToggle = false;
                                }
                            }
                            else if (GUI.Button(btn.BtnRect(5, true, "playermod"), "C R I T   P E R   L V L ( O F F ) : " + PlayerMod.CritPerLvl.ToString(), OffStyle))
                            {
                                Main.critToggle = true;
                            }
                            if (GUI.Button(new Rect(x + widthSize - 80, y + Main.PlayerModBtnY, 40, 40), "-", OffStyle))
                            {
                                if (PlayerMod.CritPerLvl > 0)
                                    PlayerMod.CritPerLvl -= 1;
                            }
                            if (GUI.Button(new Rect(x + widthSize - 35, y + Main.PlayerModBtnY, 40, 40), "+", OffStyle))
                            {
                                if (PlayerMod.CritPerLvl >= 0)
                                    PlayerMod.CritPerLvl += 1;
                            }
                            if (Main.attackSpeedToggle)
                            {
                                if (GUI.Button(btn.BtnRect(6, true, "playermod"), "A T T A C K   S P E E D ( O N ) : " + PlayerMod.attackSpeed.ToString(), OnStyle))
                                {
                                    Main.attackSpeedToggle = false;
                                }
                            }
                            else if (GUI.Button(btn.BtnRect(6, true, "playermod"), "A T T A C K   S P E E D ( O F F ) : " + PlayerMod.attackSpeed.ToString(), OffStyle))
                            {
                                Main.attackSpeedToggle = true;
                            }
                            if (GUI.Button(new Rect(x + widthSize - 80, y + Main.PlayerModBtnY, 40, 40), "-", OffStyle))
                            {
                                if (PlayerMod.attackSpeed > 0)
                                    PlayerMod.attackSpeed -= 1;
                            }
                            if (GUI.Button(new Rect(x + widthSize - 35, y + Main.PlayerModBtnY, 40, 40), "+", OffStyle))
                            {
                                if (PlayerMod.attackSpeed >= 0)
                                    PlayerMod.attackSpeed += 1;
                            }
                            if (Main.armorToggle)
                            {
                                if (GUI.Button(btn.BtnRect(7, true, "playermod"), "A R M O R ( O N ) : " + PlayerMod.armor.ToString(), Highlighted))
                                {
                                    Main.armorToggle = false;
                                }
                            }
                            else if (GUI.Button(btn.BtnRect(7, true, "playermod"), "A R M O R ( O F F ) : " + PlayerMod.armor.ToString(), Highlighted))
                            {
                                Main.armorToggle = true;
                            }
                            if (GUI.Button(new Rect(x + widthSize - 80, y + Main.PlayerModBtnY, 40, 40), "-", OffStyle))
                            {
                                if (PlayerMod.armor > 0)
                                    PlayerMod.armor -= 10;
                            }
                            if (GUI.Button(new Rect(x + widthSize - 35, y + Main.PlayerModBtnY, 40, 40), "+", OffStyle))
                            {
                                if (PlayerMod.armor >= 0)
                                    PlayerMod.armor += 10;
                            }
                            if (Main.moveSpeedToggle)
                            {
                                if (GUI.Button(btn.BtnRect(8, true, "playermod"), "M O V E   S P E E D ( O N ) : " + PlayerMod.movespeed.ToString(), OnStyle))
                                {
                                    Main.moveSpeedToggle = false;
                                }
                            }
                            else if (GUI.Button(btn.BtnRect(8, true, "playermod"), "M O V E   S P E E D ( O F F ) : " + PlayerMod.movespeed.ToString(), OffStyle))
                            {
                                Main.moveSpeedToggle = true;
                            }
                            if (GUI.Button(new Rect(x + widthSize - 80, y + Main.PlayerModBtnY, 40, 40), "-", OffStyle))
                            {
                                if (PlayerMod.movespeed > 7)
                                    PlayerMod.movespeed -= 10;
                            }
                            if (GUI.Button(new Rect(x + widthSize - 35, y + Main.PlayerModBtnY, 40, 40), "+", OffStyle))
                            {
                                if (PlayerMod.movespeed >= 7)
                                    PlayerMod.movespeed += 10;
                            }
                            if (Main._CharacterToggle)
                            {
                                if (GUI.Button(btn.BtnRect(9, false, "playermod"), "C H A N G E   C H A R A C T E R : ON", OnStyle))
                                {
                                    Main._CharacterToggle = false;
                                }
                            }
                            else if (GUI.Button(btn.BtnRect(9, false, "playermod"), "C H A N G E   C H A R A C T E R : OFF", OffStyle))
                            {
                                Main._CharacterToggle = true;
                            }
                            if (Main._isStatMenuOpen)
                            {
                                if (GUI.Button(btn.BtnRect(10, false, "playermod"), "S H O W   S T A T S : O N", OnStyle))
                                {
                                    Main._isStatMenuOpen = false;
                                }
                            }
                            else if (GUI.Button(btn.BtnRect(10, false, "playermod"), "S H O W   S T A T S : O F F", OffStyle))
                            {
                                Main._isStatMenuOpen = true;
                            }
                            if (Main._isBuffMenuOpen)
                            {
                                if (GUI.Button(btn.BtnRect(11, false, "playermod"), "G I V E   B U F F   M E N U : O N", OnStyle))
                                {
                                    Main._isBuffMenuOpen = false;
                                }
                            }
                            else if (GUI.Button(btn.BtnRect(11, false, "playermod"), "G I V E   B U F F   M E N U : O F F", OffStyle))
                            {
                                Main._isBuffMenuOpen = true;
                            }
                            if (GUI.Button(btn.BtnRect(12, false, "playermod"), "R E M O V E   A L L   B U F F S", buttonStyle))
                            {
                                PlayerMod.RemoveAllBuffs();
                            }
                            if (Main.aimBot)
                            {
                                if (GUI.Button(btn.BtnRect(13, false, "playermod"), "A I M B O T : O N", OnStyle))
                                {
                                    EntityStates.FireNailgun.spreadPitchScale = 0.5f;
                                    EntityStates.FireNailgun.spreadYawScale = 1f;
                                    EntityStates.FireNailgun.spreadBloomValue = 0.2f;
                                    Main.aimBot = false;
                                }
                            }
                            else if (!Main.aimBot)
                            {
                                if (GUI.Button(btn.BtnRect(13, false, "playermod"), "A I M B O T : O F F", OffStyle))
                                {
                                    EntityStates.FireNailgun.spreadPitchScale = 0;
                                    EntityStates.FireNailgun.spreadYawScale = 0;
                                    EntityStates.FireNailgun.spreadBloomValue = 0;
                                    Main.aimBot = true;
                                }
                            }
                            if (Main.alwaysSprint)
                            {
                                if (GUI.Button(btn.BtnRect(14, false, "playermod"), "A L W A Y S   S P R I N T : O N", OnStyle))
                                {
                                    Main.alwaysSprint = false;
                                }
                            }
                            else if (!Main.alwaysSprint)
                            {
                                if (GUI.Button(btn.BtnRect(14, false, "playermod"), "A L W A Y S   S P R I N T : O F F", OffStyle))
                                {
                                    Main.alwaysSprint = true;
                                }
                            }
                            if (Main.FlightToggle)
                            {
                                if (GUI.Button(btn.BtnRect(15, false, "playermod"), "F L I G H T : O N", OnStyle))
                                {
                                    if (PlayerMod.GetCurrentCharacter().ToString() != "Loader")
                                    {
                                        Main.LocalPlayerBody.bodyFlags &= CharacterBody.BodyFlags.None;
                                    }
                                    Main.FlightToggle = false;
                                }
                            }
                            else if (GUI.Button(btn.BtnRect(15, false, "playermod"), "F L I G H T : O F F", OffStyle))
                            {
                                Main.FlightToggle = true;
                            }
                            if (Main.godToggle)
                            {
                                if (GUI.Button(btn.BtnRect(16, false, "playermod"), "G O D   M O D E : O N", OnStyle))
                                {
                                    Main.godToggle = false;
                                }
                            }
                            else if (GUI.Button(btn.BtnRect(16, false, "playermod"), "G O D   M O D E : O F F", OffStyle))
                            {
                                Main.godToggle = true;
                            }
                            if (Main.skillToggle)
                            {
                                if (GUI.Button(btn.BtnRect(17, false, "playermod"), "I N F I N I T E   S K I L L S : O N", OnStyle))
                                {
                                    Main.skillToggle = false;
                                }
                            }
                            else if (GUI.Button(btn.BtnRect(17, false, "playermod"), "I N F I N I T E   S K I L L S : O F F", OffStyle))
                            {
                                Main.skillToggle = true;
                            }
                            if (GUI.Button(btn.BtnRect(18, false, "playermod"), "U N L O C K   A L L", buttonStyle))
                            {
                                PlayerMod.UnlockAll();
                            }
                            break;
                        }

                    case 7:
                        {
                            if (GUI.Button(btn.BtnRect(1, true, "playermod"), "G I V E   M O N E Y : " + PlayerMod.moneyToGive.ToString(), buttonStyle))
                            {
                                PlayerMod.GiveMoney();
                            }
                            if (GUI.Button(new Rect(x + widthSize - 80, y + Main.PlayerModBtnY, 40, 40), "-", OffStyle))
                            {
                                if (PlayerMod.moneyToGive > 50)
                                    PlayerMod.moneyToGive -= 50;
                            }
                            if (GUI.Button(new Rect(x + widthSize - 35, y + Main.PlayerModBtnY, 40, 40), "+", OffStyle))
                            {
                                if (PlayerMod.moneyToGive >= 50)
                                    PlayerMod.moneyToGive += 50;
                            }
                            if (GUI.Button(btn.BtnRect(2, true, "playermod"), "G I V E   L U N A R   C O I N S : " + PlayerMod.coinsToGive.ToString(), buttonStyle))
                            {
                                PlayerMod.GiveLunarCoins();
                            }
                            if (GUI.Button(new Rect(x + widthSize - 80, y + Main.PlayerModBtnY, 40, 40), "-", OffStyle))
                            {
                                if (PlayerMod.coinsToGive > 10)
                                    PlayerMod.coinsToGive -= 10;
                            }
                            if (GUI.Button(new Rect(x + widthSize - 35, y + Main.PlayerModBtnY, 40, 40), "+", OffStyle))
                            {
                                if (PlayerMod.coinsToGive >= 10)
                                    PlayerMod.coinsToGive += 10;
                            }
                            if (GUI.Button(btn.BtnRect(3, true, "playermod"), "G I V E   E X P E R I E N C E : " + PlayerMod.xpToGive.ToString(), buttonStyle))
                            {
                                PlayerMod.GiveXP();
                            }
                            if (GUI.Button(new Rect(x + widthSize - 80, y + Main.PlayerModBtnY, 40, 40), "-", OffStyle))
                            {
                                if (PlayerMod.xpToGive > 50)
                                    PlayerMod.xpToGive -= 50;
                            }
                            if (GUI.Button(new Rect(x + widthSize - 35, y + Main.PlayerModBtnY, 40, 40), "+", OffStyle))
                            {
                                if (PlayerMod.xpToGive >= 50)
                                    PlayerMod.xpToGive += 50;
                            }
                            if (Main.damageToggle)
                            {
                                if (GUI.Button(btn.BtnRect(4, true, "playermod"), "D A M A G E   P E R   L V L ( O N ) : " + PlayerMod.damagePerLvl.ToString(), OnStyle))
                                {
                                    Main.damageToggle = false;
                                }
                            }
                            else if (GUI.Button(btn.BtnRect(4, true, "playermod"), "D A M A G E   P E R   L V L ( O F F ) : " + PlayerMod.damagePerLvl.ToString(), OffStyle))
                            {
                                Main.damageToggle = true;
                            }
                            if (GUI.Button(new Rect(x + widthSize - 80, y + Main.PlayerModBtnY, 40, 40), "-", OffStyle))
                            {
                                if (PlayerMod.damagePerLvl > 0)
                                    PlayerMod.damagePerLvl -= 10;
                            }
                            if (GUI.Button(new Rect(x + widthSize - 35, y + Main.PlayerModBtnY, 40, 40), "+", OffStyle))
                            {
                                if (PlayerMod.damagePerLvl >= 0)
                                    PlayerMod.damagePerLvl += 10;
                            }
                            if (Main.critToggle)
                            {
                                if (GUI.Button(btn.BtnRect(5, true, "playermod"), "C R I T   P E R   L V L ( O N ) : " + PlayerMod.CritPerLvl.ToString(), OnStyle))
                                {
                                    Main.critToggle = false;
                                }
                            }
                            else if (GUI.Button(btn.BtnRect(5, true, "playermod"), "C R I T   P E R   L V L ( O F F ) : " + PlayerMod.CritPerLvl.ToString(), OffStyle))
                            {
                                Main.critToggle = true;
                            }
                            if (GUI.Button(new Rect(x + widthSize - 80, y + Main.PlayerModBtnY, 40, 40), "-", OffStyle))
                            {
                                if (PlayerMod.CritPerLvl > 0)
                                    PlayerMod.CritPerLvl -= 1;
                            }
                            if (GUI.Button(new Rect(x + widthSize - 35, y + Main.PlayerModBtnY, 40, 40), "+", OffStyle))
                            {
                                if (PlayerMod.CritPerLvl >= 0)
                                    PlayerMod.CritPerLvl += 1;
                            }
                            if (Main.attackSpeedToggle)
                            {
                                if (GUI.Button(btn.BtnRect(6, true, "playermod"), "A T T A C K   S P E E D ( O N ) : " + PlayerMod.attackSpeed.ToString(), OnStyle))
                                {
                                    Main.attackSpeedToggle = false;
                                }
                            }
                            else if (GUI.Button(btn.BtnRect(6, true, "playermod"), "A T T A C K   S P E E D ( O F F ) : " + PlayerMod.attackSpeed.ToString(), OffStyle))
                            {
                                Main.attackSpeedToggle = true;
                            }
                            if (GUI.Button(new Rect(x + widthSize - 80, y + Main.PlayerModBtnY, 40, 40), "-", OffStyle))
                            {
                                if (PlayerMod.attackSpeed > 0)
                                    PlayerMod.attackSpeed -= 1;
                            }
                            if (GUI.Button(new Rect(x + widthSize - 35, y + Main.PlayerModBtnY, 40, 40), "+", OffStyle))
                            {
                                if (PlayerMod.attackSpeed >= 0)
                                    PlayerMod.attackSpeed += 1;
                            }
                            if (Main.armorToggle)
                            {
                                if (GUI.Button(btn.BtnRect(7, true, "playermod"), "A R M O R ( O N ) : " + PlayerMod.armor.ToString(), OnStyle))
                                {
                                    Main.armorToggle = false;
                                }
                            }
                            else if (GUI.Button(btn.BtnRect(7, true, "playermod"), "A R M O R ( O F F ) : " + PlayerMod.armor.ToString(), OffStyle))
                            {
                                Main.armorToggle = true;
                            }
                            if (GUI.Button(new Rect(x + widthSize - 80, y + Main.PlayerModBtnY, 40, 40), "-", OffStyle))
                            {
                                if (PlayerMod.armor > 0)
                                    PlayerMod.armor -= 10;
                            }
                            if (GUI.Button(new Rect(x + widthSize - 35, y + Main.PlayerModBtnY, 40, 40), "+", OffStyle))
                            {
                                if (PlayerMod.armor >= 0)
                                    PlayerMod.armor += 10;
                            }
                            if (Main.moveSpeedToggle)
                            {
                                if (GUI.Button(btn.BtnRect(8, true, "playermod"), "M O V E   S P E E D ( O N ) : " + PlayerMod.movespeed.ToString(), Highlighted))
                                {
                                    Main.moveSpeedToggle = false;
                                }
                            }
                            else if (GUI.Button(btn.BtnRect(8, true, "playermod"), "M O V E   S P E E D ( O F F ) : " + PlayerMod.movespeed.ToString(), Highlighted))
                            {
                                Main.moveSpeedToggle = true;
                            }
                            if (GUI.Button(new Rect(x + widthSize - 80, y + Main.PlayerModBtnY, 40, 40), "-", OffStyle))
                            {
                                if (PlayerMod.movespeed > 7)
                                    PlayerMod.movespeed -= 10;
                            }
                            if (GUI.Button(new Rect(x + widthSize - 35, y + Main.PlayerModBtnY, 40, 40), "+", OffStyle))
                            {
                                if (PlayerMod.movespeed >= 7)
                                    PlayerMod.movespeed += 10;
                            }
                            if (Main._CharacterToggle)
                            {
                                if (GUI.Button(btn.BtnRect(9, false, "playermod"), "C H A N G E   C H A R A C T E R : ON", OnStyle))
                                {
                                    Main._CharacterToggle = false;
                                }
                            }
                            else if (GUI.Button(btn.BtnRect(9, false, "playermod"), "C H A N G E   C H A R A C T E R : OFF", OffStyle))
                            {
                                Main._CharacterToggle = true;
                            }
                            if (Main._isStatMenuOpen)
                            {
                                if (GUI.Button(btn.BtnRect(10, false, "playermod"), "S H O W   S T A T S : O N", OnStyle))
                                {
                                    Main._isStatMenuOpen = false;
                                }
                            }
                            else if (GUI.Button(btn.BtnRect(10, false, "playermod"), "S H O W   S T A T S : O F F", OffStyle))
                            {
                                Main._isStatMenuOpen = true;
                            }
                            if (Main._isBuffMenuOpen)
                            {
                                if (GUI.Button(btn.BtnRect(11, false, "playermod"), "G I V E   B U F F   M E N U : O N", OnStyle))
                                {
                                    Main._isBuffMenuOpen = false;
                                }
                            }
                            else if (GUI.Button(btn.BtnRect(11, false, "playermod"), "G I V E   B U F F   M E N U : O F F", OffStyle))
                            {
                                Main._isBuffMenuOpen = true;
                            }
                            if (GUI.Button(btn.BtnRect(12, false, "playermod"), "R E M O V E   A L L   B U F F S", buttonStyle))
                            {
                                PlayerMod.RemoveAllBuffs();
                            }
                            if (Main.aimBot)
                            {
                                if (GUI.Button(btn.BtnRect(13, false, "playermod"), "A I M B O T : O N", OnStyle))
                                {
                                    EntityStates.FireNailgun.spreadPitchScale = 0.5f;
                                    EntityStates.FireNailgun.spreadYawScale = 1f;
                                    EntityStates.FireNailgun.spreadBloomValue = 0.2f;
                                    Main.aimBot = false;
                                }
                            }
                            else if (!Main.aimBot)
                            {
                                if (GUI.Button(btn.BtnRect(13, false, "playermod"), "A I M B O T : O F F", OffStyle))
                                {
                                    EntityStates.FireNailgun.spreadPitchScale = 0;
                                    EntityStates.FireNailgun.spreadYawScale = 0;
                                    EntityStates.FireNailgun.spreadBloomValue = 0;
                                    Main.aimBot = true;
                                }
                            }
                            if (Main.alwaysSprint)
                            {
                                if (GUI.Button(btn.BtnRect(14, false, "playermod"), "A L W A Y S   S P R I N T : O N", OnStyle))
                                {
                                    Main.alwaysSprint = false;
                                }
                            }
                            else if (!Main.alwaysSprint)
                            {
                                if (GUI.Button(btn.BtnRect(14, false, "playermod"), "A L W A Y S   S P R I N T : O F F", OffStyle))
                                {
                                    Main.alwaysSprint = true;
                                }
                            }
                            if (Main.FlightToggle)
                            {
                                if (GUI.Button(btn.BtnRect(15, false, "playermod"), "F L I G H T : O N", OnStyle))
                                {
                                    if (PlayerMod.GetCurrentCharacter().ToString() != "Loader")
                                    {
                                        Main.LocalPlayerBody.bodyFlags &= CharacterBody.BodyFlags.None;
                                    }
                                    Main.FlightToggle = false;
                                }
                            }
                            else if (GUI.Button(btn.BtnRect(15, false, "playermod"), "F L I G H T : O F F", OffStyle))
                            {
                                Main.FlightToggle = true;
                            }
                            if (Main.godToggle)
                            {
                                if (GUI.Button(btn.BtnRect(16, false, "playermod"), "G O D   M O D E : O N", OnStyle))
                                {
                                    Main.godToggle = false;
                                }
                            }
                            else if (GUI.Button(btn.BtnRect(16, false, "playermod"), "G O D   M O D E : O F F", OffStyle))
                            {
                                Main.godToggle = true;
                            }
                            if (Main.skillToggle)
                            {
                                if (GUI.Button(btn.BtnRect(17, false, "playermod"), "I N F I N I T E   S K I L L S : O N", OnStyle))
                                {
                                    Main.skillToggle = false;
                                }
                            }
                            else if (GUI.Button(btn.BtnRect(17, false, "playermod"), "I N F I N I T E   S K I L L S : O F F", OffStyle))
                            {
                                Main.skillToggle = true;
                            }
                            if (GUI.Button(btn.BtnRect(18, false, "playermod"), "U N L O C K   A L L", buttonStyle))
                            {
                                PlayerMod.UnlockAll();
                            }
                            break;
                        }

                    case 8:
                        {
                            if (GUI.Button(btn.BtnRect(1, true, "playermod"), "G I V E   M O N E Y : " + PlayerMod.moneyToGive.ToString(), buttonStyle))
                            {
                                PlayerMod.GiveMoney();
                            }
                            if (GUI.Button(new Rect(x + widthSize - 80, y + Main.PlayerModBtnY, 40, 40), "-", OffStyle))
                            {
                                if (PlayerMod.moneyToGive > 50)
                                    PlayerMod.moneyToGive -= 50;
                            }
                            if (GUI.Button(new Rect(x + widthSize - 35, y + Main.PlayerModBtnY, 40, 40), "+", OffStyle))
                            {
                                if (PlayerMod.moneyToGive >= 50)
                                    PlayerMod.moneyToGive += 50;
                            }
                            if (GUI.Button(btn.BtnRect(2, true, "playermod"), "G I V E   L U N A R   C O I N S : " + PlayerMod.coinsToGive.ToString(), buttonStyle))
                            {
                                PlayerMod.GiveLunarCoins();
                            }
                            if (GUI.Button(new Rect(x + widthSize - 80, y + Main.PlayerModBtnY, 40, 40), "-", OffStyle))
                            {
                                if (PlayerMod.coinsToGive > 10)
                                    PlayerMod.coinsToGive -= 10;
                            }
                            if (GUI.Button(new Rect(x + widthSize - 35, y + Main.PlayerModBtnY, 40, 40), "+", OffStyle))
                            {
                                if (PlayerMod.coinsToGive >= 10)
                                    PlayerMod.coinsToGive += 10;
                            }
                            if (GUI.Button(btn.BtnRect(3, true, "playermod"), "G I V E   E X P E R I E N C E : " + PlayerMod.xpToGive.ToString(), buttonStyle))
                            {
                                PlayerMod.GiveXP();
                            }
                            if (GUI.Button(new Rect(x + widthSize - 80, y + Main.PlayerModBtnY, 40, 40), "-", OffStyle))
                            {
                                if (PlayerMod.xpToGive > 50)
                                    PlayerMod.xpToGive -= 50;
                            }
                            if (GUI.Button(new Rect(x + widthSize - 35, y + Main.PlayerModBtnY, 40, 40), "+", OffStyle))
                            {
                                if (PlayerMod.xpToGive >= 50)
                                    PlayerMod.xpToGive += 50;
                            }
                            if (Main.damageToggle)
                            {
                                if (GUI.Button(btn.BtnRect(4, true, "playermod"), "D A M A G E   P E R   L V L ( O N ) : " + PlayerMod.damagePerLvl.ToString(), OnStyle))
                                {
                                    Main.damageToggle = false;
                                }
                            }
                            else if (GUI.Button(btn.BtnRect(4, true, "playermod"), "D A M A G E   P E R   L V L ( O F F ) : " + PlayerMod.damagePerLvl.ToString(), OffStyle))
                            {
                                Main.damageToggle = true;
                            }
                            if (GUI.Button(new Rect(x + widthSize - 80, y + Main.PlayerModBtnY, 40, 40), "-", OffStyle))
                            {
                                if (PlayerMod.damagePerLvl > 0)
                                    PlayerMod.damagePerLvl -= 10;
                            }
                            if (GUI.Button(new Rect(x + widthSize - 35, y + Main.PlayerModBtnY, 40, 40), "+", OffStyle))
                            {
                                if (PlayerMod.damagePerLvl >= 0)
                                    PlayerMod.damagePerLvl += 10;
                            }
                            if (Main.critToggle)
                            {
                                if (GUI.Button(btn.BtnRect(5, true, "playermod"), "C R I T   P E R   L V L ( O N ) : " + PlayerMod.CritPerLvl.ToString(), OnStyle))
                                {
                                    Main.critToggle = false;
                                }
                            }
                            else if (GUI.Button(btn.BtnRect(5, true, "playermod"), "C R I T   P E R   L V L ( O F F ) : " + PlayerMod.CritPerLvl.ToString(), OffStyle))
                            {
                                Main.critToggle = true;
                            }
                            if (GUI.Button(new Rect(x + widthSize - 80, y + Main.PlayerModBtnY, 40, 40), "-", OffStyle))
                            {
                                if (PlayerMod.CritPerLvl > 0)
                                    PlayerMod.CritPerLvl -= 1;
                            }
                            if (GUI.Button(new Rect(x + widthSize - 35, y + Main.PlayerModBtnY, 40, 40), "+", OffStyle))
                            {
                                if (PlayerMod.CritPerLvl >= 0)
                                    PlayerMod.CritPerLvl += 1;
                            }
                            if (Main.attackSpeedToggle)
                            {
                                if (GUI.Button(btn.BtnRect(6, true, "playermod"), "A T T A C K   S P E E D ( O N ) : " + PlayerMod.attackSpeed.ToString(), OnStyle))
                                {
                                    Main.attackSpeedToggle = false;
                                }
                            }
                            else if (GUI.Button(btn.BtnRect(6, true, "playermod"), "A T T A C K   S P E E D ( O F F ) : " + PlayerMod.attackSpeed.ToString(), OffStyle))
                            {
                                Main.attackSpeedToggle = true;
                            }
                            if (GUI.Button(new Rect(x + widthSize - 80, y + Main.PlayerModBtnY, 40, 40), "-", OffStyle))
                            {
                                if (PlayerMod.attackSpeed > 0)
                                    PlayerMod.attackSpeed -= 1;
                            }
                            if (GUI.Button(new Rect(x + widthSize - 35, y + Main.PlayerModBtnY, 40, 40), "+", OffStyle))
                            {
                                if (PlayerMod.attackSpeed >= 0)
                                    PlayerMod.attackSpeed += 1;
                            }
                            if (Main.armorToggle)
                            {
                                if (GUI.Button(btn.BtnRect(7, true, "playermod"), "A R M O R ( O N ) : " + PlayerMod.armor.ToString(), OnStyle))
                                {
                                    Main.armorToggle = false;
                                }
                            }
                            else if (GUI.Button(btn.BtnRect(7, true, "playermod"), "A R M O R ( O F F ) : " + PlayerMod.armor.ToString(), OffStyle))
                            {
                                Main.armorToggle = true;
                            }
                            if (GUI.Button(new Rect(x + widthSize - 80, y + Main.PlayerModBtnY, 40, 40), "-", OffStyle))
                            {
                                if (PlayerMod.armor > 0)
                                    PlayerMod.armor -= 10;
                            }
                            if (GUI.Button(new Rect(x + widthSize - 35, y + Main.PlayerModBtnY, 40, 40), "+", OffStyle))
                            {
                                if (PlayerMod.armor >= 0)
                                    PlayerMod.armor += 10;
                            }
                            if (Main.moveSpeedToggle)
                            {
                                if (GUI.Button(btn.BtnRect(8, true, "playermod"), "M O V E   S P E E D ( O N ) : " + PlayerMod.movespeed.ToString(), OnStyle))
                                {
                                    Main.moveSpeedToggle = false;
                                }
                            }
                            else if (GUI.Button(btn.BtnRect(8, true, "playermod"), "M O V E   S P E E D ( O F F ) : " + PlayerMod.movespeed.ToString(), OffStyle))
                            {
                                Main.moveSpeedToggle = true;
                            }
                            if (GUI.Button(new Rect(x + widthSize - 80, y + Main.PlayerModBtnY, 40, 40), "-", OffStyle))
                            {
                                if (PlayerMod.movespeed > 7)
                                    PlayerMod.movespeed -= 10;
                            }
                            if (GUI.Button(new Rect(x + widthSize - 35, y + Main.PlayerModBtnY, 40, 40), "+", OffStyle))
                            {
                                if (PlayerMod.movespeed >= 7)
                                    PlayerMod.movespeed += 10;
                            }
                            if (Main._CharacterToggle)
                            {
                                if (GUI.Button(btn.BtnRect(9, false, "playermod"), "C H A N G E   C H A R A C T E R : ON", Highlighted))
                                {
                                    Main._CharacterToggle = false;
                                }
                            }
                            else if (GUI.Button(btn.BtnRect(9, false, "playermod"), "C H A N G E   C H A R A C T E R : OFF", Highlighted))
                            {
                                Main._CharacterToggle = true;
                            }
                            if (Main._isStatMenuOpen)
                            {
                                if (GUI.Button(btn.BtnRect(10, false, "playermod"), "S H O W   S T A T S : O N", OnStyle))
                                {
                                    Main._isStatMenuOpen = false;
                                }
                            }
                            else if (GUI.Button(btn.BtnRect(10, false, "playermod"), "S H O W   S T A T S : O F F", OffStyle))
                            {
                                Main._isStatMenuOpen = true;
                            }
                            if (Main._isBuffMenuOpen)
                            {
                                if (GUI.Button(btn.BtnRect(11, false, "playermod"), "G I V E   B U F F   M E N U : O N", OnStyle))
                                {
                                    Main._isBuffMenuOpen = false;
                                }
                            }
                            else if (GUI.Button(btn.BtnRect(11, false, "playermod"), "G I V E   B U F F   M E N U : O F F", OffStyle))
                            {
                                Main._isBuffMenuOpen = true;
                            }
                            if (GUI.Button(btn.BtnRect(12, false, "playermod"), "R E M O V E   A L L   B U F F S", buttonStyle))
                            {
                                PlayerMod.RemoveAllBuffs();
                            }
                            if (Main.aimBot)
                            {
                                if (GUI.Button(btn.BtnRect(13, false, "playermod"), "A I M B O T : O N", OnStyle))
                                {
                                    EntityStates.FireNailgun.spreadPitchScale = 0.5f;
                                    EntityStates.FireNailgun.spreadYawScale = 1f;
                                    EntityStates.FireNailgun.spreadBloomValue = 0.2f;
                                    Main.aimBot = false;
                                }
                            }
                            else if (!Main.aimBot)
                            {
                                if (GUI.Button(btn.BtnRect(13, false, "playermod"), "A I M B O T : O F F", OffStyle))
                                {
                                    EntityStates.FireNailgun.spreadPitchScale = 0;
                                    EntityStates.FireNailgun.spreadYawScale = 0;
                                    EntityStates.FireNailgun.spreadBloomValue = 0;
                                    Main.aimBot = true;
                                }
                            }
                            if (Main.alwaysSprint)
                            {
                                if (GUI.Button(btn.BtnRect(14, false, "playermod"), "A L W A Y S   S P R I N T : O N", OnStyle))
                                {
                                    Main.alwaysSprint = false;
                                }
                            }
                            else if (!Main.alwaysSprint)
                            {
                                if (GUI.Button(btn.BtnRect(14, false, "playermod"), "A L W A Y S   S P R I N T : O F F", OffStyle))
                                {
                                    Main.alwaysSprint = true;
                                }
                            }
                            if (Main.FlightToggle)
                            {
                                if (GUI.Button(btn.BtnRect(15, false, "playermod"), "F L I G H T : O N", OnStyle))
                                {
                                    if (PlayerMod.GetCurrentCharacter().ToString() != "Loader")
                                    {
                                        Main.LocalPlayerBody.bodyFlags &= CharacterBody.BodyFlags.None;
                                    }
                                    Main.FlightToggle = false;
                                }
                            }
                            else if (GUI.Button(btn.BtnRect(15, false, "playermod"), "F L I G H T : O F F", OffStyle))
                            {
                                Main.FlightToggle = true;
                            }
                            if (Main.godToggle)
                            {
                                if (GUI.Button(btn.BtnRect(16, false, "playermod"), "G O D   M O D E : O N", OnStyle))
                                {
                                    Main.godToggle = false;
                                }
                            }
                            else if (GUI.Button(btn.BtnRect(16, false, "playermod"), "G O D   M O D E : O F F", OffStyle))
                            {
                                Main.godToggle = true;
                            }
                            if (Main.skillToggle)
                            {
                                if (GUI.Button(btn.BtnRect(17, false, "playermod"), "I N F I N I T E   S K I L L S : O N", OnStyle))
                                {
                                    Main.skillToggle = false;
                                }
                            }
                            else if (GUI.Button(btn.BtnRect(17, false, "playermod"), "I N F I N I T E   S K I L L S : O F F", OffStyle))
                            {
                                Main.skillToggle = true;
                            }
                            if (GUI.Button(btn.BtnRect(18, false, "playermod"), "U N L O C K   A L L", buttonStyle))
                            {
                                PlayerMod.UnlockAll();
                            }
                            break;
                        }

                    case 9:
                        {
                            if (GUI.Button(btn.BtnRect(1, true, "playermod"), "G I V E   M O N E Y : " + PlayerMod.moneyToGive.ToString(), buttonStyle))
                            {
                                PlayerMod.GiveMoney();
                            }
                            if (GUI.Button(new Rect(x + widthSize - 80, y + Main.PlayerModBtnY, 40, 40), "-", OffStyle))
                            {
                                if (PlayerMod.moneyToGive > 50)
                                    PlayerMod.moneyToGive -= 50;
                            }
                            if (GUI.Button(new Rect(x + widthSize - 35, y + Main.PlayerModBtnY, 40, 40), "+", OffStyle))
                            {
                                if (PlayerMod.moneyToGive >= 50)
                                    PlayerMod.moneyToGive += 50;
                            }
                            if (GUI.Button(btn.BtnRect(2, true, "playermod"), "G I V E   L U N A R   C O I N S : " + PlayerMod.coinsToGive.ToString(), buttonStyle))
                            {
                                PlayerMod.GiveLunarCoins();
                            }
                            if (GUI.Button(new Rect(x + widthSize - 80, y + Main.PlayerModBtnY, 40, 40), "-", OffStyle))
                            {
                                if (PlayerMod.coinsToGive > 10)
                                    PlayerMod.coinsToGive -= 10;
                            }
                            if (GUI.Button(new Rect(x + widthSize - 35, y + Main.PlayerModBtnY, 40, 40), "+", OffStyle))
                            {
                                if (PlayerMod.coinsToGive >= 10)
                                    PlayerMod.coinsToGive += 10;
                            }
                            if (GUI.Button(btn.BtnRect(3, true, "playermod"), "G I V E   E X P E R I E N C E : " + PlayerMod.xpToGive.ToString(), buttonStyle))
                            {
                                PlayerMod.GiveXP();
                            }
                            if (GUI.Button(new Rect(x + widthSize - 80, y + Main.PlayerModBtnY, 40, 40), "-", OffStyle))
                            {
                                if (PlayerMod.xpToGive > 50)
                                    PlayerMod.xpToGive -= 50;
                            }
                            if (GUI.Button(new Rect(x + widthSize - 35, y + Main.PlayerModBtnY, 40, 40), "+", OffStyle))
                            {
                                if (PlayerMod.xpToGive >= 50)
                                    PlayerMod.xpToGive += 50;
                            }
                            if (Main.damageToggle)
                            {
                                if (GUI.Button(btn.BtnRect(4, true, "playermod"), "D A M A G E   P E R   L V L ( O N ) : " + PlayerMod.damagePerLvl.ToString(), OnStyle))
                                {
                                    Main.damageToggle = false;
                                }
                            }
                            else if (GUI.Button(btn.BtnRect(4, true, "playermod"), "D A M A G E   P E R   L V L ( O F F ) : " + PlayerMod.damagePerLvl.ToString(), OffStyle))
                            {
                                Main.damageToggle = true;
                            }
                            if (GUI.Button(new Rect(x + widthSize - 80, y + Main.PlayerModBtnY, 40, 40), "-", OffStyle))
                            {
                                if (PlayerMod.damagePerLvl > 0)
                                    PlayerMod.damagePerLvl -= 10;
                            }
                            if (GUI.Button(new Rect(x + widthSize - 35, y + Main.PlayerModBtnY, 40, 40), "+", OffStyle))
                            {
                                if (PlayerMod.damagePerLvl >= 0)
                                    PlayerMod.damagePerLvl += 10;
                            }
                            if (Main.critToggle)
                            {
                                if (GUI.Button(btn.BtnRect(5, true, "playermod"), "C R I T   P E R   L V L ( O N ) : " + PlayerMod.CritPerLvl.ToString(), OnStyle))
                                {
                                    Main.critToggle = false;
                                }
                            }
                            else if (GUI.Button(btn.BtnRect(5, true, "playermod"), "C R I T   P E R   L V L ( O F F ) : " + PlayerMod.CritPerLvl.ToString(), OffStyle))
                            {
                                Main.critToggle = true;
                            }
                            if (GUI.Button(new Rect(x + widthSize - 80, y + Main.PlayerModBtnY, 40, 40), "-", OffStyle))
                            {
                                if (PlayerMod.CritPerLvl > 0)
                                    PlayerMod.CritPerLvl -= 1;
                            }
                            if (GUI.Button(new Rect(x + widthSize - 35, y + Main.PlayerModBtnY, 40, 40), "+", OffStyle))
                            {
                                if (PlayerMod.CritPerLvl >= 0)
                                    PlayerMod.CritPerLvl += 1;
                            }
                            if (Main.attackSpeedToggle)
                            {
                                if (GUI.Button(btn.BtnRect(6, true, "playermod"), "A T T A C K   S P E E D ( O N ) : " + PlayerMod.attackSpeed.ToString(), OnStyle))
                                {
                                    Main.attackSpeedToggle = false;
                                }
                            }
                            else if (GUI.Button(btn.BtnRect(6, true, "playermod"), "A T T A C K   S P E E D ( O F F ) : " + PlayerMod.attackSpeed.ToString(), OffStyle))
                            {
                                Main.attackSpeedToggle = true;
                            }
                            if (GUI.Button(new Rect(x + widthSize - 80, y + Main.PlayerModBtnY, 40, 40), "-", OffStyle))
                            {
                                if (PlayerMod.attackSpeed > 0)
                                    PlayerMod.attackSpeed -= 1;
                            }
                            if (GUI.Button(new Rect(x + widthSize - 35, y + Main.PlayerModBtnY, 40, 40), "+", OffStyle))
                            {
                                if (PlayerMod.attackSpeed >= 0)
                                    PlayerMod.attackSpeed += 1;
                            }
                            if (Main.armorToggle)
                            {
                                if (GUI.Button(btn.BtnRect(7, true, "playermod"), "A R M O R ( O N ) : " + PlayerMod.armor.ToString(), OnStyle))
                                {
                                    Main.armorToggle = false;
                                }
                            }
                            else if (GUI.Button(btn.BtnRect(7, true, "playermod"), "A R M O R ( O F F ) : " + PlayerMod.armor.ToString(), OffStyle))
                            {
                                Main.armorToggle = true;
                            }
                            if (GUI.Button(new Rect(x + widthSize - 80, y + Main.PlayerModBtnY, 40, 40), "-", OffStyle))
                            {
                                if (PlayerMod.armor > 0)
                                    PlayerMod.armor -= 10;
                            }
                            if (GUI.Button(new Rect(x + widthSize - 35, y + Main.PlayerModBtnY, 40, 40), "+", OffStyle))
                            {
                                if (PlayerMod.armor >= 0)
                                    PlayerMod.armor += 10;
                            }
                            if (Main.moveSpeedToggle)
                            {
                                if (GUI.Button(btn.BtnRect(8, true, "playermod"), "M O V E   S P E E D ( O N ) : " + PlayerMod.movespeed.ToString(), OnStyle))
                                {
                                    Main.moveSpeedToggle = false;
                                }
                            }
                            else if (GUI.Button(btn.BtnRect(8, true, "playermod"), "M O V E   S P E E D ( O F F ) : " + PlayerMod.movespeed.ToString(), OffStyle))
                            {
                                Main.moveSpeedToggle = true;
                            }
                            if (GUI.Button(new Rect(x + widthSize - 80, y + Main.PlayerModBtnY, 40, 40), "-", OffStyle))
                            {
                                if (PlayerMod.movespeed > 7)
                                    PlayerMod.movespeed -= 10;
                            }
                            if (GUI.Button(new Rect(x + widthSize - 35, y + Main.PlayerModBtnY, 40, 40), "+", OffStyle))
                            {
                                if (PlayerMod.movespeed >= 7)
                                    PlayerMod.movespeed += 10;
                            }
                            if (Main._CharacterToggle)
                            {
                                if (GUI.Button(btn.BtnRect(9, false, "playermod"), "C H A N G E   C H A R A C T E R : ON", OnStyle))
                                {
                                    Main._CharacterToggle = false;
                                }
                            }
                            else if (GUI.Button(btn.BtnRect(9, false, "playermod"), "C H A N G E   C H A R A C T E R : OFF", OffStyle))
                            {
                                Main._CharacterToggle = true;
                            }
                            if (Main._isStatMenuOpen)
                            {
                                if (GUI.Button(btn.BtnRect(10, false, "playermod"), "S H O W   S T A T S : O N", Highlighted))
                                {
                                    Main._isStatMenuOpen = false;
                                }
                            }
                            else if (GUI.Button(btn.BtnRect(10, false, "playermod"), "S H O W   S T A T S : O F F", Highlighted))
                            {
                                Main._isStatMenuOpen = true;
                            }
                            if (Main._isBuffMenuOpen)
                            {
                                if (GUI.Button(btn.BtnRect(11, false, "playermod"), "G I V E   B U F F   M E N U : O N", OnStyle))
                                {
                                    Main._isBuffMenuOpen = false;
                                }
                            }
                            else if (GUI.Button(btn.BtnRect(11, false, "playermod"), "G I V E   B U F F   M E N U : O F F", OffStyle))
                            {
                                Main._isBuffMenuOpen = true;
                            }
                            if (GUI.Button(btn.BtnRect(12, false, "playermod"), "R E M O V E   A L L   B U F F S", buttonStyle))
                            {
                                PlayerMod.RemoveAllBuffs();
                            }
                            if (Main.aimBot)
                            {
                                if (GUI.Button(btn.BtnRect(13, false, "playermod"), "A I M B O T : O N", OnStyle))
                                {
                                    EntityStates.FireNailgun.spreadPitchScale = 0.5f;
                                    EntityStates.FireNailgun.spreadYawScale = 1f;
                                    EntityStates.FireNailgun.spreadBloomValue = 0.2f;
                                    Main.aimBot = false;
                                }
                            }
                            else if (!Main.aimBot)
                            {
                                if (GUI.Button(btn.BtnRect(13, false, "playermod"), "A I M B O T : O F F", OffStyle))
                                {
                                    EntityStates.FireNailgun.spreadPitchScale = 0;
                                    EntityStates.FireNailgun.spreadYawScale = 0;
                                    EntityStates.FireNailgun.spreadBloomValue = 0;
                                    Main.aimBot = true;
                                }
                            }
                            if (Main.alwaysSprint)
                            {
                                if (GUI.Button(btn.BtnRect(14, false, "playermod"), "A L W A Y S   S P R I N T : O N", OnStyle))
                                {
                                    Main.alwaysSprint = false;
                                }
                            }
                            else if (!Main.alwaysSprint)
                            {
                                if (GUI.Button(btn.BtnRect(14, false, "playermod"), "A L W A Y S   S P R I N T : O F F", OffStyle))
                                {
                                    Main.alwaysSprint = true;
                                }
                            }
                            if (Main.FlightToggle)
                            {
                                if (GUI.Button(btn.BtnRect(15, false, "playermod"), "F L I G H T : O N", OnStyle))
                                {
                                    if (PlayerMod.GetCurrentCharacter().ToString() != "Loader")
                                    {
                                        Main.LocalPlayerBody.bodyFlags &= CharacterBody.BodyFlags.None;
                                    }
                                    Main.FlightToggle = false;
                                }
                            }
                            else if (GUI.Button(btn.BtnRect(15, false, "playermod"), "F L I G H T : O F F", OffStyle))
                            {
                                Main.FlightToggle = true;
                            }
                            if (Main.godToggle)
                            {
                                if (GUI.Button(btn.BtnRect(16, false, "playermod"), "G O D   M O D E : O N", OnStyle))
                                {
                                    Main.godToggle = false;
                                }
                            }
                            else if (GUI.Button(btn.BtnRect(16, false, "playermod"), "G O D   M O D E : O F F", OffStyle))
                            {
                                Main.godToggle = true;
                            }
                            if (Main.skillToggle)
                            {
                                if (GUI.Button(btn.BtnRect(17, false, "playermod"), "I N F I N I T E   S K I L L S : O N", OnStyle))
                                {
                                    Main.skillToggle = false;
                                }
                            }
                            else if (GUI.Button(btn.BtnRect(17, false, "playermod"), "I N F I N I T E   S K I L L S : O F F", OffStyle))
                            {
                                Main.skillToggle = true;
                            }
                            if (GUI.Button(btn.BtnRect(18, false, "playermod"), "U N L O C K   A L L", buttonStyle))
                            {
                                PlayerMod.UnlockAll();
                            }
                            break;
                        }

                    case 10:
                        {
                            if (GUI.Button(btn.BtnRect(1, true, "playermod"), "G I V E   M O N E Y : " + PlayerMod.moneyToGive.ToString(), buttonStyle))
                            {
                                PlayerMod.GiveMoney();
                            }
                            if (GUI.Button(new Rect(x + widthSize - 80, y + Main.PlayerModBtnY, 40, 40), "-", OffStyle))
                            {
                                if (PlayerMod.moneyToGive > 50)
                                    PlayerMod.moneyToGive -= 50;
                            }
                            if (GUI.Button(new Rect(x + widthSize - 35, y + Main.PlayerModBtnY, 40, 40), "+", OffStyle))
                            {
                                if (PlayerMod.moneyToGive >= 50)
                                    PlayerMod.moneyToGive += 50;
                            }
                            if (GUI.Button(btn.BtnRect(2, true, "playermod"), "G I V E   L U N A R   C O I N S : " + PlayerMod.coinsToGive.ToString(), buttonStyle))
                            {
                                PlayerMod.GiveLunarCoins();
                            }
                            if (GUI.Button(new Rect(x + widthSize - 80, y + Main.PlayerModBtnY, 40, 40), "-", OffStyle))
                            {
                                if (PlayerMod.coinsToGive > 10)
                                    PlayerMod.coinsToGive -= 10;
                            }
                            if (GUI.Button(new Rect(x + widthSize - 35, y + Main.PlayerModBtnY, 40, 40), "+", OffStyle))
                            {
                                if (PlayerMod.coinsToGive >= 10)
                                    PlayerMod.coinsToGive += 10;
                            }
                            if (GUI.Button(btn.BtnRect(3, true, "playermod"), "G I V E   E X P E R I E N C E : " + PlayerMod.xpToGive.ToString(), buttonStyle))
                            {
                                PlayerMod.GiveXP();
                            }
                            if (GUI.Button(new Rect(x + widthSize - 80, y + Main.PlayerModBtnY, 40, 40), "-", OffStyle))
                            {
                                if (PlayerMod.xpToGive > 50)
                                    PlayerMod.xpToGive -= 50;
                            }
                            if (GUI.Button(new Rect(x + widthSize - 35, y + Main.PlayerModBtnY, 40, 40), "+", OffStyle))
                            {
                                if (PlayerMod.xpToGive >= 50)
                                    PlayerMod.xpToGive += 50;
                            }
                            if (Main.damageToggle)
                            {
                                if (GUI.Button(btn.BtnRect(4, true, "playermod"), "D A M A G E   P E R   L V L ( O N ) : " + PlayerMod.damagePerLvl.ToString(), OnStyle))
                                {
                                    Main.damageToggle = false;
                                }
                            }
                            else if (GUI.Button(btn.BtnRect(4, true, "playermod"), "D A M A G E   P E R   L V L ( O F F ) : " + PlayerMod.damagePerLvl.ToString(), OffStyle))
                            {
                                Main.damageToggle = true;
                            }
                            if (GUI.Button(new Rect(x + widthSize - 80, y + Main.PlayerModBtnY, 40, 40), "-", OffStyle))
                            {
                                if (PlayerMod.damagePerLvl > 0)
                                    PlayerMod.damagePerLvl -= 10;
                            }
                            if (GUI.Button(new Rect(x + widthSize - 35, y + Main.PlayerModBtnY, 40, 40), "+", OffStyle))
                            {
                                if (PlayerMod.damagePerLvl >= 0)
                                    PlayerMod.damagePerLvl += 10;
                            }
                            if (Main.critToggle)
                            {
                                if (GUI.Button(btn.BtnRect(5, true, "playermod"), "C R I T   P E R   L V L ( O N ) : " + PlayerMod.CritPerLvl.ToString(), OnStyle))
                                {
                                    Main.critToggle = false;
                                }
                            }
                            else if (GUI.Button(btn.BtnRect(5, true, "playermod"), "C R I T   P E R   L V L ( O F F ) : " + PlayerMod.CritPerLvl.ToString(), OffStyle))
                            {
                                Main.critToggle = true;
                            }
                            if (GUI.Button(new Rect(x + widthSize - 80, y + Main.PlayerModBtnY, 40, 40), "-", OffStyle))
                            {
                                if (PlayerMod.CritPerLvl > 0)
                                    PlayerMod.CritPerLvl -= 1;
                            }
                            if (GUI.Button(new Rect(x + widthSize - 35, y + Main.PlayerModBtnY, 40, 40), "+", OffStyle))
                            {
                                if (PlayerMod.CritPerLvl >= 0)
                                    PlayerMod.CritPerLvl += 1;
                            }
                            if (Main.attackSpeedToggle)
                            {
                                if (GUI.Button(btn.BtnRect(6, true, "playermod"), "A T T A C K   S P E E D ( O N ) : " + PlayerMod.attackSpeed.ToString(), OnStyle))
                                {
                                    Main.attackSpeedToggle = false;
                                }
                            }
                            else if (GUI.Button(btn.BtnRect(6, true, "playermod"), "A T T A C K   S P E E D ( O F F ) : " + PlayerMod.attackSpeed.ToString(), OffStyle))
                            {
                                Main.attackSpeedToggle = true;
                            }
                            if (GUI.Button(new Rect(x + widthSize - 80, y + Main.PlayerModBtnY, 40, 40), "-", OffStyle))
                            {
                                if (PlayerMod.attackSpeed > 0)
                                    PlayerMod.attackSpeed -= 1;
                            }
                            if (GUI.Button(new Rect(x + widthSize - 35, y + Main.PlayerModBtnY, 40, 40), "+", OffStyle))
                            {
                                if (PlayerMod.attackSpeed >= 0)
                                    PlayerMod.attackSpeed += 1;
                            }
                            if (Main.armorToggle)
                            {
                                if (GUI.Button(btn.BtnRect(7, true, "playermod"), "A R M O R ( O N ) : " + PlayerMod.armor.ToString(), OnStyle))
                                {
                                    Main.armorToggle = false;
                                }
                            }
                            else if (GUI.Button(btn.BtnRect(7, true, "playermod"), "A R M O R ( O F F ) : " + PlayerMod.armor.ToString(), OffStyle))
                            {
                                Main.armorToggle = true;
                            }
                            if (GUI.Button(new Rect(x + widthSize - 80, y + Main.PlayerModBtnY, 40, 40), "-", OffStyle))
                            {
                                if (PlayerMod.armor > 0)
                                    PlayerMod.armor -= 10;
                            }
                            if (GUI.Button(new Rect(x + widthSize - 35, y + Main.PlayerModBtnY, 40, 40), "+", OffStyle))
                            {
                                if (PlayerMod.armor >= 0)
                                    PlayerMod.armor += 10;
                            }
                            if (Main.moveSpeedToggle)
                            {
                                if (GUI.Button(btn.BtnRect(8, true, "playermod"), "M O V E   S P E E D ( O N ) : " + PlayerMod.movespeed.ToString(), OnStyle))
                                {
                                    Main.moveSpeedToggle = false;
                                }
                            }
                            else if (GUI.Button(btn.BtnRect(8, true, "playermod"), "M O V E   S P E E D ( O F F ) : " + PlayerMod.movespeed.ToString(), OffStyle))
                            {
                                Main.moveSpeedToggle = true;
                            }
                            if (GUI.Button(new Rect(x + widthSize - 80, y + Main.PlayerModBtnY, 40, 40), "-", OffStyle))
                            {
                                if (PlayerMod.movespeed > 7)
                                    PlayerMod.movespeed -= 10;
                            }
                            if (GUI.Button(new Rect(x + widthSize - 35, y + Main.PlayerModBtnY, 40, 40), "+", OffStyle))
                            {
                                if (PlayerMod.movespeed >= 7)
                                    PlayerMod.movespeed += 10;
                            }
                            if (Main._CharacterToggle)
                            {
                                if (GUI.Button(btn.BtnRect(9, false, "playermod"), "C H A N G E   C H A R A C T E R : ON", OnStyle))
                                {
                                    Main._CharacterToggle = false;
                                }
                            }
                            else if (GUI.Button(btn.BtnRect(9, false, "playermod"), "C H A N G E   C H A R A C T E R : OFF", OffStyle))
                            {
                                Main._CharacterToggle = true;
                            }
                            if (Main._isStatMenuOpen)
                            {
                                if (GUI.Button(btn.BtnRect(10, false, "playermod"), "S H O W   S T A T S : O N", OnStyle))
                                {
                                    Main._isStatMenuOpen = false;
                                }
                            }
                            else if (GUI.Button(btn.BtnRect(10, false, "playermod"), "S H O W   S T A T S : O F F", OffStyle))
                            {
                                Main._isStatMenuOpen = true;
                            }
                            if (Main._isBuffMenuOpen)
                            {
                                if (GUI.Button(btn.BtnRect(11, false, "playermod"), "G I V E   B U F F   M E N U : O N", Highlighted))
                                {
                                    Main._isBuffMenuOpen = false;
                                }
                            }
                            else if (GUI.Button(btn.BtnRect(11, false, "playermod"), "G I V E   B U F F   M E N U : O F F", Highlighted))
                            {
                                Main._isBuffMenuOpen = true;
                            }
                            if (GUI.Button(btn.BtnRect(12, false, "playermod"), "R E M O V E   A L L   B U F F S", buttonStyle))
                            {
                                PlayerMod.RemoveAllBuffs();
                            }
                            if (Main.aimBot)
                            {
                                if (GUI.Button(btn.BtnRect(13, false, "playermod"), "A I M B O T : O N", OnStyle))
                                {
                                    EntityStates.FireNailgun.spreadPitchScale = 0.5f;
                                    EntityStates.FireNailgun.spreadYawScale = 1f;
                                    EntityStates.FireNailgun.spreadBloomValue = 0.2f;
                                    Main.aimBot = false;
                                }
                            }
                            else if (!Main.aimBot)
                            {
                                if (GUI.Button(btn.BtnRect(13, false, "playermod"), "A I M B O T : O F F", OffStyle))
                                {
                                    EntityStates.FireNailgun.spreadPitchScale = 0;
                                    EntityStates.FireNailgun.spreadYawScale = 0;
                                    EntityStates.FireNailgun.spreadBloomValue = 0;
                                    Main.aimBot = true;
                                }
                            }
                            if (Main.alwaysSprint)
                            {
                                if (GUI.Button(btn.BtnRect(14, false, "playermod"), "A L W A Y S   S P R I N T : O N", OnStyle))
                                {
                                    Main.alwaysSprint = false;
                                }
                            }
                            else if (!Main.alwaysSprint)
                            {
                                if (GUI.Button(btn.BtnRect(14, false, "playermod"), "A L W A Y S   S P R I N T : O F F", OffStyle))
                                {
                                    Main.alwaysSprint = true;
                                }
                            }
                            if (Main.FlightToggle)
                            {
                                if (GUI.Button(btn.BtnRect(15, false, "playermod"), "F L I G H T : O N", OnStyle))
                                {
                                    if (PlayerMod.GetCurrentCharacter().ToString() != "Loader")
                                    {
                                        Main.LocalPlayerBody.bodyFlags &= CharacterBody.BodyFlags.None;
                                    }
                                    Main.FlightToggle = false;
                                }
                            }
                            else if (GUI.Button(btn.BtnRect(15, false, "playermod"), "F L I G H T : O F F", OffStyle))
                            {
                                Main.FlightToggle = true;
                            }
                            if (Main.godToggle)
                            {
                                if (GUI.Button(btn.BtnRect(16, false, "playermod"), "G O D   M O D E : O N", OnStyle))
                                {
                                    Main.godToggle = false;
                                }
                            }
                            else if (GUI.Button(btn.BtnRect(16, false, "playermod"), "G O D   M O D E : O F F", OffStyle))
                            {
                                Main.godToggle = true;
                            }
                            if (Main.skillToggle)
                            {
                                if (GUI.Button(btn.BtnRect(17, false, "playermod"), "I N F I N I T E   S K I L L S : O N", OnStyle))
                                {
                                    Main.skillToggle = false;
                                }
                            }
                            else if (GUI.Button(btn.BtnRect(17, false, "playermod"), "I N F I N I T E   S K I L L S : O F F", OffStyle))
                            {
                                Main.skillToggle = true;
                            }
                            if (GUI.Button(btn.BtnRect(18, false, "playermod"), "U N L O C K   A L L", buttonStyle))
                            {
                                PlayerMod.UnlockAll();
                            }
                            break;
                        }

                    case 11:
                        {
                            if (GUI.Button(btn.BtnRect(1, true, "playermod"), "G I V E   M O N E Y : " + PlayerMod.moneyToGive.ToString(), buttonStyle))
                            {
                                PlayerMod.GiveMoney();
                            }
                            if (GUI.Button(new Rect(x + widthSize - 80, y + Main.PlayerModBtnY, 40, 40), "-", OffStyle))
                            {
                                if (PlayerMod.moneyToGive > 50)
                                    PlayerMod.moneyToGive -= 50;
                            }
                            if (GUI.Button(new Rect(x + widthSize - 35, y + Main.PlayerModBtnY, 40, 40), "+", OffStyle))
                            {
                                if (PlayerMod.moneyToGive >= 50)
                                    PlayerMod.moneyToGive += 50;
                            }
                            if (GUI.Button(btn.BtnRect(2, true, "playermod"), "G I V E   L U N A R   C O I N S : " + PlayerMod.coinsToGive.ToString(), buttonStyle))
                            {
                                PlayerMod.GiveLunarCoins();
                            }
                            if (GUI.Button(new Rect(x + widthSize - 80, y + Main.PlayerModBtnY, 40, 40), "-", OffStyle))
                            {
                                if (PlayerMod.coinsToGive > 10)
                                    PlayerMod.coinsToGive -= 10;
                            }
                            if (GUI.Button(new Rect(x + widthSize - 35, y + Main.PlayerModBtnY, 40, 40), "+", OffStyle))
                            {
                                if (PlayerMod.coinsToGive >= 10)
                                    PlayerMod.coinsToGive += 10;
                            }
                            if (GUI.Button(btn.BtnRect(3, true, "playermod"), "G I V E   E X P E R I E N C E : " + PlayerMod.xpToGive.ToString(), buttonStyle))
                            {
                                PlayerMod.GiveXP();
                            }
                            if (GUI.Button(new Rect(x + widthSize - 80, y + Main.PlayerModBtnY, 40, 40), "-", OffStyle))
                            {
                                if (PlayerMod.xpToGive > 50)
                                    PlayerMod.xpToGive -= 50;
                            }
                            if (GUI.Button(new Rect(x + widthSize - 35, y + Main.PlayerModBtnY, 40, 40), "+", OffStyle))
                            {
                                if (PlayerMod.xpToGive >= 50)
                                    PlayerMod.xpToGive += 50;
                            }
                            if (Main.damageToggle)
                            {
                                if (GUI.Button(btn.BtnRect(4, true, "playermod"), "D A M A G E   P E R   L V L ( O N ) : " + PlayerMod.damagePerLvl.ToString(), OnStyle))
                                {
                                    Main.damageToggle = false;
                                }
                            }
                            else if (GUI.Button(btn.BtnRect(4, true, "playermod"), "D A M A G E   P E R   L V L ( O F F ) : " + PlayerMod.damagePerLvl.ToString(), OffStyle))
                            {
                                Main.damageToggle = true;
                            }
                            if (GUI.Button(new Rect(x + widthSize - 80, y + Main.PlayerModBtnY, 40, 40), "-", OffStyle))
                            {
                                if (PlayerMod.damagePerLvl > 0)
                                    PlayerMod.damagePerLvl -= 10;
                            }
                            if (GUI.Button(new Rect(x + widthSize - 35, y + Main.PlayerModBtnY, 40, 40), "+", OffStyle))
                            {
                                if (PlayerMod.damagePerLvl >= 0)
                                    PlayerMod.damagePerLvl += 10;
                            }
                            if (Main.critToggle)
                            {
                                if (GUI.Button(btn.BtnRect(5, true, "playermod"), "C R I T   P E R   L V L ( O N ) : " + PlayerMod.CritPerLvl.ToString(), OnStyle))
                                {
                                    Main.critToggle = false;
                                }
                            }
                            else if (GUI.Button(btn.BtnRect(5, true, "playermod"), "C R I T   P E R   L V L ( O F F ) : " + PlayerMod.CritPerLvl.ToString(), OffStyle))
                            {
                                Main.critToggle = true;
                            }
                            if (GUI.Button(new Rect(x + widthSize - 80, y + Main.PlayerModBtnY, 40, 40), "-", OffStyle))
                            {
                                if (PlayerMod.CritPerLvl > 0)
                                    PlayerMod.CritPerLvl -= 1;
                            }
                            if (GUI.Button(new Rect(x + widthSize - 35, y + Main.PlayerModBtnY, 40, 40), "+", OffStyle))
                            {
                                if (PlayerMod.CritPerLvl >= 0)
                                    PlayerMod.CritPerLvl += 1;
                            }
                            if (Main.attackSpeedToggle)
                            {
                                if (GUI.Button(btn.BtnRect(6, true, "playermod"), "A T T A C K   S P E E D ( O N ) : " + PlayerMod.attackSpeed.ToString(), OnStyle))
                                {
                                    Main.attackSpeedToggle = false;
                                }
                            }
                            else if (GUI.Button(btn.BtnRect(6, true, "playermod"), "A T T A C K   S P E E D ( O F F ) : " + PlayerMod.attackSpeed.ToString(), OffStyle))
                            {
                                Main.attackSpeedToggle = true;
                            }
                            if (GUI.Button(new Rect(x + widthSize - 80, y + Main.PlayerModBtnY, 40, 40), "-", OffStyle))
                            {
                                if (PlayerMod.attackSpeed > 0)
                                    PlayerMod.attackSpeed -= 1;
                            }
                            if (GUI.Button(new Rect(x + widthSize - 35, y + Main.PlayerModBtnY, 40, 40), "+", OffStyle))
                            {
                                if (PlayerMod.attackSpeed >= 0)
                                    PlayerMod.attackSpeed += 1;
                            }
                            if (Main.armorToggle)
                            {
                                if (GUI.Button(btn.BtnRect(7, true, "playermod"), "A R M O R ( O N ) : " + PlayerMod.armor.ToString(), OnStyle))
                                {
                                    Main.armorToggle = false;
                                }
                            }
                            else if (GUI.Button(btn.BtnRect(7, true, "playermod"), "A R M O R ( O F F ) : " + PlayerMod.armor.ToString(), OffStyle))
                            {
                                Main.armorToggle = true;
                            }
                            if (GUI.Button(new Rect(x + widthSize - 80, y + Main.PlayerModBtnY, 40, 40), "-", OffStyle))
                            {
                                if (PlayerMod.armor > 0)
                                    PlayerMod.armor -= 10;
                            }
                            if (GUI.Button(new Rect(x + widthSize - 35, y + Main.PlayerModBtnY, 40, 40), "+", OffStyle))
                            {
                                if (PlayerMod.armor >= 0)
                                    PlayerMod.armor += 10;
                            }
                            if (Main.moveSpeedToggle)
                            {
                                if (GUI.Button(btn.BtnRect(8, true, "playermod"), "M O V E   S P E E D ( O N ) : " + PlayerMod.movespeed.ToString(), OnStyle))
                                {
                                    Main.moveSpeedToggle = false;
                                }
                            }
                            else if (GUI.Button(btn.BtnRect(8, true, "playermod"), "M O V E   S P E E D ( O F F ) : " + PlayerMod.movespeed.ToString(), OffStyle))
                            {
                                Main.moveSpeedToggle = true;
                            }
                            if (GUI.Button(new Rect(x + widthSize - 80, y + Main.PlayerModBtnY, 40, 40), "-", OffStyle))
                            {
                                if (PlayerMod.movespeed > 7)
                                    PlayerMod.movespeed -= 10;
                            }
                            if (GUI.Button(new Rect(x + widthSize - 35, y + Main.PlayerModBtnY, 40, 40), "+", OffStyle))
                            {
                                if (PlayerMod.movespeed >= 7)
                                    PlayerMod.movespeed += 10;
                            }
                            if (Main._CharacterToggle)
                            {
                                if (GUI.Button(btn.BtnRect(9, false, "playermod"), "C H A N G E   C H A R A C T E R : ON", OnStyle))
                                {
                                    Main._CharacterToggle = false;
                                }
                            }
                            else if (GUI.Button(btn.BtnRect(9, false, "playermod"), "C H A N G E   C H A R A C T E R : OFF", OffStyle))
                            {
                                Main._CharacterToggle = true;
                            }
                            if (Main._isStatMenuOpen)
                            {
                                if (GUI.Button(btn.BtnRect(10, false, "playermod"), "S H O W   S T A T S : O N", OnStyle))
                                {
                                    Main._isStatMenuOpen = false;
                                }
                            }
                            else if (GUI.Button(btn.BtnRect(10, false, "playermod"), "S H O W   S T A T S : O F F", OffStyle))
                            {
                                Main._isStatMenuOpen = true;
                            }
                            if (Main._isBuffMenuOpen)
                            {
                                if (GUI.Button(btn.BtnRect(11, false, "playermod"), "G I V E   B U F F   M E N U : O N", OnStyle))
                                {
                                    Main._isBuffMenuOpen = false;
                                }
                            }
                            else if (GUI.Button(btn.BtnRect(11, false, "playermod"), "G I V E   B U F F   M E N U : O F F", OffStyle))
                            {
                                Main._isBuffMenuOpen = true;
                            }
                            if (GUI.Button(btn.BtnRect(12, false, "playermod"), "R E M O V E   A L L   B U F F S", Highlighted))
                            {
                                PlayerMod.RemoveAllBuffs();
                            }
                            if (Main.aimBot)
                            {
                                if (GUI.Button(btn.BtnRect(13, false, "playermod"), "A I M B O T : O N", OnStyle))
                                {
                                    EntityStates.FireNailgun.spreadPitchScale = 0.5f;
                                    EntityStates.FireNailgun.spreadYawScale = 1f;
                                    EntityStates.FireNailgun.spreadBloomValue = 0.2f;
                                    Main.aimBot = false;
                                }
                            }
                            else if (!Main.aimBot)
                            {
                                if (GUI.Button(btn.BtnRect(13, false, "playermod"), "A I M B O T : O F F", OffStyle))
                                {
                                    EntityStates.FireNailgun.spreadPitchScale = 0;
                                    EntityStates.FireNailgun.spreadYawScale = 0;
                                    EntityStates.FireNailgun.spreadBloomValue = 0;
                                    Main.aimBot = true;
                                }
                            }
                            if (Main.alwaysSprint)
                            {
                                if (GUI.Button(btn.BtnRect(14, false, "playermod"), "A L W A Y S   S P R I N T : O N", OnStyle))
                                {
                                    Main.alwaysSprint = false;
                                }
                            }
                            else if (!Main.alwaysSprint)
                            {
                                if (GUI.Button(btn.BtnRect(14, false, "playermod"), "A L W A Y S   S P R I N T : O F F", OffStyle))
                                {
                                    Main.alwaysSprint = true;
                                }
                            }
                            if (Main.FlightToggle)
                            {
                                if (GUI.Button(btn.BtnRect(15, false, "playermod"), "F L I G H T : O N", OnStyle))
                                {
                                    if (PlayerMod.GetCurrentCharacter().ToString() != "Loader")
                                    {
                                        Main.LocalPlayerBody.bodyFlags &= CharacterBody.BodyFlags.None;
                                    }
                                    Main.FlightToggle = false;
                                }
                            }
                            else if (GUI.Button(btn.BtnRect(15, false, "playermod"), "F L I G H T : O F F", OffStyle))
                            {
                                Main.FlightToggle = true;
                            }
                            if (Main.godToggle)
                            {
                                if (GUI.Button(btn.BtnRect(16, false, "playermod"), "G O D   M O D E : O N", OnStyle))
                                {
                                    Main.godToggle = false;
                                }
                            }
                            else if (GUI.Button(btn.BtnRect(16, false, "playermod"), "G O D   M O D E : O F F", OffStyle))
                            {
                                Main.godToggle = true;
                            }
                            if (Main.skillToggle)
                            {
                                if (GUI.Button(btn.BtnRect(17, false, "playermod"), "I N F I N I T E   S K I L L S : O N", OnStyle))
                                {
                                    Main.skillToggle = false;
                                }
                            }
                            else if (GUI.Button(btn.BtnRect(17, false, "playermod"), "I N F I N I T E   S K I L L S : O F F", OffStyle))
                            {
                                Main.skillToggle = true;
                            }
                            if (GUI.Button(btn.BtnRect(18, false, "playermod"), "U N L O C K   A L L", buttonStyle))
                            {
                                PlayerMod.UnlockAll();
                            }
                            break;
                        }

                    case 12:
                        {
                            if (GUI.Button(btn.BtnRect(1, true, "playermod"), "G I V E   M O N E Y : " + PlayerMod.moneyToGive.ToString(), buttonStyle))
                            {
                                PlayerMod.GiveMoney();
                            }
                            if (GUI.Button(new Rect(x + widthSize - 80, y + Main.PlayerModBtnY, 40, 40), "-", OffStyle))
                            {
                                if (PlayerMod.moneyToGive > 50)
                                    PlayerMod.moneyToGive -= 50;
                            }
                            if (GUI.Button(new Rect(x + widthSize - 35, y + Main.PlayerModBtnY, 40, 40), "+", OffStyle))
                            {
                                if (PlayerMod.moneyToGive >= 50)
                                    PlayerMod.moneyToGive += 50;
                            }
                            if (GUI.Button(btn.BtnRect(2, true, "playermod"), "G I V E   L U N A R   C O I N S : " + PlayerMod.coinsToGive.ToString(), buttonStyle))
                            {
                                PlayerMod.GiveLunarCoins();
                            }
                            if (GUI.Button(new Rect(x + widthSize - 80, y + Main.PlayerModBtnY, 40, 40), "-", OffStyle))
                            {
                                if (PlayerMod.coinsToGive > 10)
                                    PlayerMod.coinsToGive -= 10;
                            }
                            if (GUI.Button(new Rect(x + widthSize - 35, y + Main.PlayerModBtnY, 40, 40), "+", OffStyle))
                            {
                                if (PlayerMod.coinsToGive >= 10)
                                    PlayerMod.coinsToGive += 10;
                            }
                            if (GUI.Button(btn.BtnRect(3, true, "playermod"), "G I V E   E X P E R I E N C E : " + PlayerMod.xpToGive.ToString(), buttonStyle))
                            {
                                PlayerMod.GiveXP();
                            }
                            if (GUI.Button(new Rect(x + widthSize - 80, y + Main.PlayerModBtnY, 40, 40), "-", OffStyle))
                            {
                                if (PlayerMod.xpToGive > 50)
                                    PlayerMod.xpToGive -= 50;
                            }
                            if (GUI.Button(new Rect(x + widthSize - 35, y + Main.PlayerModBtnY, 40, 40), "+", OffStyle))
                            {
                                if (PlayerMod.xpToGive >= 50)
                                    PlayerMod.xpToGive += 50;
                            }
                            if (Main.damageToggle)
                            {
                                if (GUI.Button(btn.BtnRect(4, true, "playermod"), "D A M A G E   P E R   L V L ( O N ) : " + PlayerMod.damagePerLvl.ToString(), OnStyle))
                                {
                                    Main.damageToggle = false;
                                }
                            }
                            else if (GUI.Button(btn.BtnRect(4, true, "playermod"), "D A M A G E   P E R   L V L ( O F F ) : " + PlayerMod.damagePerLvl.ToString(), OffStyle))
                            {
                                Main.damageToggle = true;
                            }
                            if (GUI.Button(new Rect(x + widthSize - 80, y + Main.PlayerModBtnY, 40, 40), "-", OffStyle))
                            {
                                if (PlayerMod.damagePerLvl > 0)
                                    PlayerMod.damagePerLvl -= 10;
                            }
                            if (GUI.Button(new Rect(x + widthSize - 35, y + Main.PlayerModBtnY, 40, 40), "+", OffStyle))
                            {
                                if (PlayerMod.damagePerLvl >= 0)
                                    PlayerMod.damagePerLvl += 10;
                            }
                            if (Main.critToggle)
                            {
                                if (GUI.Button(btn.BtnRect(5, true, "playermod"), "C R I T   P E R   L V L ( O N ) : " + PlayerMod.CritPerLvl.ToString(), OnStyle))
                                {
                                    Main.critToggle = false;
                                }
                            }
                            else if (GUI.Button(btn.BtnRect(5, true, "playermod"), "C R I T   P E R   L V L ( O F F ) : " + PlayerMod.CritPerLvl.ToString(), OffStyle))
                            {
                                Main.critToggle = true;
                            }
                            if (GUI.Button(new Rect(x + widthSize - 80, y + Main.PlayerModBtnY, 40, 40), "-", OffStyle))
                            {
                                if (PlayerMod.CritPerLvl > 0)
                                    PlayerMod.CritPerLvl -= 1;
                            }
                            if (GUI.Button(new Rect(x + widthSize - 35, y + Main.PlayerModBtnY, 40, 40), "+", OffStyle))
                            {
                                if (PlayerMod.CritPerLvl >= 0)
                                    PlayerMod.CritPerLvl += 1;
                            }
                            if (Main.attackSpeedToggle)
                            {
                                if (GUI.Button(btn.BtnRect(6, true, "playermod"), "A T T A C K   S P E E D ( O N ) : " + PlayerMod.attackSpeed.ToString(), OnStyle))
                                {
                                    Main.attackSpeedToggle = false;
                                }
                            }
                            else if (GUI.Button(btn.BtnRect(6, true, "playermod"), "A T T A C K   S P E E D ( O F F ) : " + PlayerMod.attackSpeed.ToString(), OffStyle))
                            {
                                Main.attackSpeedToggle = true;
                            }
                            if (GUI.Button(new Rect(x + widthSize - 80, y + Main.PlayerModBtnY, 40, 40), "-", OffStyle))
                            {
                                if (PlayerMod.attackSpeed > 0)
                                    PlayerMod.attackSpeed -= 1;
                            }
                            if (GUI.Button(new Rect(x + widthSize - 35, y + Main.PlayerModBtnY, 40, 40), "+", OffStyle))
                            {
                                if (PlayerMod.attackSpeed >= 0)
                                    PlayerMod.attackSpeed += 1;
                            }
                            if (Main.armorToggle)
                            {
                                if (GUI.Button(btn.BtnRect(7, true, "playermod"), "A R M O R ( O N ) : " + PlayerMod.armor.ToString(), OnStyle))
                                {
                                    Main.armorToggle = false;
                                }
                            }
                            else if (GUI.Button(btn.BtnRect(7, true, "playermod"), "A R M O R ( O F F ) : " + PlayerMod.armor.ToString(), OffStyle))
                            {
                                Main.armorToggle = true;
                            }
                            if (GUI.Button(new Rect(x + widthSize - 80, y + Main.PlayerModBtnY, 40, 40), "-", OffStyle))
                            {
                                if (PlayerMod.armor > 0)
                                    PlayerMod.armor -= 10;
                            }
                            if (GUI.Button(new Rect(x + widthSize - 35, y + Main.PlayerModBtnY, 40, 40), "+", OffStyle))
                            {
                                if (PlayerMod.armor >= 0)
                                    PlayerMod.armor += 10;
                            }
                            if (Main.moveSpeedToggle)
                            {
                                if (GUI.Button(btn.BtnRect(8, true, "playermod"), "M O V E   S P E E D ( O N ) : " + PlayerMod.movespeed.ToString(), OnStyle))
                                {
                                    Main.moveSpeedToggle = false;
                                }
                            }
                            else if (GUI.Button(btn.BtnRect(8, true, "playermod"), "M O V E   S P E E D ( O F F ) : " + PlayerMod.movespeed.ToString(), OffStyle))
                            {
                                Main.moveSpeedToggle = true;
                            }
                            if (GUI.Button(new Rect(x + widthSize - 80, y + Main.PlayerModBtnY, 40, 40), "-", OffStyle))
                            {
                                if (PlayerMod.movespeed > 7)
                                    PlayerMod.movespeed -= 10;
                            }
                            if (GUI.Button(new Rect(x + widthSize - 35, y + Main.PlayerModBtnY, 40, 40), "+", OffStyle))
                            {
                                if (PlayerMod.movespeed >= 7)
                                    PlayerMod.movespeed += 10;
                            }
                            if (Main._CharacterToggle)
                            {
                                if (GUI.Button(btn.BtnRect(9, false, "playermod"), "C H A N G E   C H A R A C T E R : ON", OnStyle))
                                {
                                    Main._CharacterToggle = false;
                                }
                            }
                            else if (GUI.Button(btn.BtnRect(9, false, "playermod"), "C H A N G E   C H A R A C T E R : OFF", OffStyle))
                            {
                                Main._CharacterToggle = true;
                            }
                            if (Main._isStatMenuOpen)
                            {
                                if (GUI.Button(btn.BtnRect(10, false, "playermod"), "S H O W   S T A T S : O N", OnStyle))
                                {
                                    Main._isStatMenuOpen = false;
                                }
                            }
                            else if (GUI.Button(btn.BtnRect(10, false, "playermod"), "S H O W   S T A T S : O F F", OffStyle))
                            {
                                Main._isStatMenuOpen = true;
                            }
                            if (Main._isBuffMenuOpen)
                            {
                                if (GUI.Button(btn.BtnRect(11, false, "playermod"), "G I V E   B U F F   M E N U : O N", OnStyle))
                                {
                                    Main._isBuffMenuOpen = false;
                                }
                            }
                            else if (GUI.Button(btn.BtnRect(11, false, "playermod"), "G I V E   B U F F   M E N U : O F F", OffStyle))
                            {
                                Main._isBuffMenuOpen = true;
                            }
                            if (GUI.Button(btn.BtnRect(12, false, "playermod"), "R E M O V E   A L L   B U F F S", buttonStyle))
                            {
                                PlayerMod.RemoveAllBuffs();
                            }
                            if (Main.aimBot)
                            {
                                if (GUI.Button(btn.BtnRect(13, false, "playermod"), "A I M B O T : O N", Highlighted))
                                {
                                    EntityStates.FireNailgun.spreadPitchScale = 0.5f;
                                    EntityStates.FireNailgun.spreadYawScale = 1f;
                                    EntityStates.FireNailgun.spreadBloomValue = 0.2f;
                                    Main.aimBot = false;
                                }
                            }
                            else if (!Main.aimBot)
                            {
                                if (GUI.Button(btn.BtnRect(13, false, "playermod"), "A I M B O T : O F F", Highlighted))
                                {
                                    EntityStates.FireNailgun.spreadPitchScale = 0;
                                    EntityStates.FireNailgun.spreadYawScale = 0;
                                    EntityStates.FireNailgun.spreadBloomValue = 0;
                                    Main.aimBot = true;
                                }
                            }
                            if (Main.alwaysSprint)
                            {
                                if (GUI.Button(btn.BtnRect(14, false, "playermod"), "A L W A Y S   S P R I N T : O N", OnStyle))
                                {
                                    Main.alwaysSprint = false;
                                }
                            }
                            else if (!Main.alwaysSprint)
                            {
                                if (GUI.Button(btn.BtnRect(14, false, "playermod"), "A L W A Y S   S P R I N T : O F F", OffStyle))
                                {
                                    Main.alwaysSprint = true;
                                }
                            }
                            if (Main.FlightToggle)
                            {
                                if (GUI.Button(btn.BtnRect(15, false, "playermod"), "F L I G H T : O N", OnStyle))
                                {
                                    if (PlayerMod.GetCurrentCharacter().ToString() != "Loader")
                                    {
                                        Main.LocalPlayerBody.bodyFlags &= CharacterBody.BodyFlags.None;
                                    }
                                    Main.FlightToggle = false;
                                }
                            }
                            else if (GUI.Button(btn.BtnRect(15, false, "playermod"), "F L I G H T : O F F", OffStyle))
                            {
                                Main.FlightToggle = true;
                            }
                            if (Main.godToggle)
                            {
                                if (GUI.Button(btn.BtnRect(16, false, "playermod"), "G O D   M O D E : O N", OnStyle))
                                {
                                    Main.godToggle = false;
                                }
                            }
                            else if (GUI.Button(btn.BtnRect(16, false, "playermod"), "G O D   M O D E : O F F", OffStyle))
                            {
                                Main.godToggle = true;
                            }
                            if (Main.skillToggle)
                            {
                                if (GUI.Button(btn.BtnRect(17, false, "playermod"), "I N F I N I T E   S K I L L S : O N", OnStyle))
                                {
                                    Main.skillToggle = false;
                                }
                            }
                            else if (GUI.Button(btn.BtnRect(17, false, "playermod"), "I N F I N I T E   S K I L L S : O F F", OffStyle))
                            {
                                Main.skillToggle = true;
                            }
                            if (GUI.Button(btn.BtnRect(18, false, "playermod"), "U N L O C K   A L L", buttonStyle))
                            {
                                PlayerMod.UnlockAll();
                            }
                            break;
                        }

                    case 13:
                        {
                            if (GUI.Button(btn.BtnRect(1, true, "playermod"), "G I V E   M O N E Y : " + PlayerMod.moneyToGive.ToString(), buttonStyle))
                            {
                                PlayerMod.GiveMoney();
                            }
                            if (GUI.Button(new Rect(x + widthSize - 80, y + Main.PlayerModBtnY, 40, 40), "-", OffStyle))
                            {
                                if (PlayerMod.moneyToGive > 50)
                                    PlayerMod.moneyToGive -= 50;
                            }
                            if (GUI.Button(new Rect(x + widthSize - 35, y + Main.PlayerModBtnY, 40, 40), "+", OffStyle))
                            {
                                if (PlayerMod.moneyToGive >= 50)
                                    PlayerMod.moneyToGive += 50;
                            }
                            if (GUI.Button(btn.BtnRect(2, true, "playermod"), "G I V E   L U N A R   C O I N S : " + PlayerMod.coinsToGive.ToString(), buttonStyle))
                            {
                                PlayerMod.GiveLunarCoins();
                            }
                            if (GUI.Button(new Rect(x + widthSize - 80, y + Main.PlayerModBtnY, 40, 40), "-", OffStyle))
                            {
                                if (PlayerMod.coinsToGive > 10)
                                    PlayerMod.coinsToGive -= 10;
                            }
                            if (GUI.Button(new Rect(x + widthSize - 35, y + Main.PlayerModBtnY, 40, 40), "+", OffStyle))
                            {
                                if (PlayerMod.coinsToGive >= 10)
                                    PlayerMod.coinsToGive += 10;
                            }
                            if (GUI.Button(btn.BtnRect(3, true, "playermod"), "G I V E   E X P E R I E N C E : " + PlayerMod.xpToGive.ToString(), buttonStyle))
                            {
                                PlayerMod.GiveXP();
                            }
                            if (GUI.Button(new Rect(x + widthSize - 80, y + Main.PlayerModBtnY, 40, 40), "-", OffStyle))
                            {
                                if (PlayerMod.xpToGive > 50)
                                    PlayerMod.xpToGive -= 50;
                            }
                            if (GUI.Button(new Rect(x + widthSize - 35, y + Main.PlayerModBtnY, 40, 40), "+", OffStyle))
                            {
                                if (PlayerMod.xpToGive >= 50)
                                    PlayerMod.xpToGive += 50;
                            }
                            if (Main.damageToggle)
                            {
                                if (GUI.Button(btn.BtnRect(4, true, "playermod"), "D A M A G E   P E R   L V L ( O N ) : " + PlayerMod.damagePerLvl.ToString(), OnStyle))
                                {
                                    Main.damageToggle = false;
                                }
                            }
                            else if (GUI.Button(btn.BtnRect(4, true, "playermod"), "D A M A G E   P E R   L V L ( O F F ) : " + PlayerMod.damagePerLvl.ToString(), OffStyle))
                            {
                                Main.damageToggle = true;
                            }
                            if (GUI.Button(new Rect(x + widthSize - 80, y + Main.PlayerModBtnY, 40, 40), "-", OffStyle))
                            {
                                if (PlayerMod.damagePerLvl > 0)
                                    PlayerMod.damagePerLvl -= 10;
                            }
                            if (GUI.Button(new Rect(x + widthSize - 35, y + Main.PlayerModBtnY, 40, 40), "+", OffStyle))
                            {
                                if (PlayerMod.damagePerLvl >= 0)
                                    PlayerMod.damagePerLvl += 10;
                            }
                            if (Main.critToggle)
                            {
                                if (GUI.Button(btn.BtnRect(5, true, "playermod"), "C R I T   P E R   L V L ( O N ) : " + PlayerMod.CritPerLvl.ToString(), OnStyle))
                                {
                                    Main.critToggle = false;
                                }
                            }
                            else if (GUI.Button(btn.BtnRect(5, true, "playermod"), "C R I T   P E R   L V L ( O F F ) : " + PlayerMod.CritPerLvl.ToString(), OffStyle))
                            {
                                Main.critToggle = true;
                            }
                            if (GUI.Button(new Rect(x + widthSize - 80, y + Main.PlayerModBtnY, 40, 40), "-", OffStyle))
                            {
                                if (PlayerMod.CritPerLvl > 0)
                                    PlayerMod.CritPerLvl -= 1;
                            }
                            if (GUI.Button(new Rect(x + widthSize - 35, y + Main.PlayerModBtnY, 40, 40), "+", OffStyle))
                            {
                                if (PlayerMod.CritPerLvl >= 0)
                                    PlayerMod.CritPerLvl += 1;
                            }
                            if (Main.attackSpeedToggle)
                            {
                                if (GUI.Button(btn.BtnRect(6, true, "playermod"), "A T T A C K   S P E E D ( O N ) : " + PlayerMod.attackSpeed.ToString(), OnStyle))
                                {
                                    Main.attackSpeedToggle = false;
                                }
                            }
                            else if (GUI.Button(btn.BtnRect(6, true, "playermod"), "A T T A C K   S P E E D ( O F F ) : " + PlayerMod.attackSpeed.ToString(), OffStyle))
                            {
                                Main.attackSpeedToggle = true;
                            }
                            if (GUI.Button(new Rect(x + widthSize - 80, y + Main.PlayerModBtnY, 40, 40), "-", OffStyle))
                            {
                                if (PlayerMod.attackSpeed > 0)
                                    PlayerMod.attackSpeed -= 1;
                            }
                            if (GUI.Button(new Rect(x + widthSize - 35, y + Main.PlayerModBtnY, 40, 40), "+", OffStyle))
                            {
                                if (PlayerMod.attackSpeed >= 0)
                                    PlayerMod.attackSpeed += 1;
                            }
                            if (Main.armorToggle)
                            {
                                if (GUI.Button(btn.BtnRect(7, true, "playermod"), "A R M O R ( O N ) : " + PlayerMod.armor.ToString(), OnStyle))
                                {
                                    Main.armorToggle = false;
                                }
                            }
                            else if (GUI.Button(btn.BtnRect(7, true, "playermod"), "A R M O R ( O F F ) : " + PlayerMod.armor.ToString(), OffStyle))
                            {
                                Main.armorToggle = true;
                            }
                            if (GUI.Button(new Rect(x + widthSize - 80, y + Main.PlayerModBtnY, 40, 40), "-", OffStyle))
                            {
                                if (PlayerMod.armor > 0)
                                    PlayerMod.armor -= 10;
                            }
                            if (GUI.Button(new Rect(x + widthSize - 35, y + Main.PlayerModBtnY, 40, 40), "+", OffStyle))
                            {
                                if (PlayerMod.armor >= 0)
                                    PlayerMod.armor += 10;
                            }
                            if (Main.moveSpeedToggle)
                            {
                                if (GUI.Button(btn.BtnRect(8, true, "playermod"), "M O V E   S P E E D ( O N ) : " + PlayerMod.movespeed.ToString(), OnStyle))
                                {
                                    Main.moveSpeedToggle = false;
                                }
                            }
                            else if (GUI.Button(btn.BtnRect(8, true, "playermod"), "M O V E   S P E E D ( O F F ) : " + PlayerMod.movespeed.ToString(), OffStyle))
                            {
                                Main.moveSpeedToggle = true;
                            }
                            if (GUI.Button(new Rect(x + widthSize - 80, y + Main.PlayerModBtnY, 40, 40), "-", OffStyle))
                            {
                                if (PlayerMod.movespeed > 7)
                                    PlayerMod.movespeed -= 10;
                            }
                            if (GUI.Button(new Rect(x + widthSize - 35, y + Main.PlayerModBtnY, 40, 40), "+", OffStyle))
                            {
                                if (PlayerMod.movespeed >= 7)
                                    PlayerMod.movespeed += 10;
                            }
                            if (Main._CharacterToggle)
                            {
                                if (GUI.Button(btn.BtnRect(9, false, "playermod"), "C H A N G E   C H A R A C T E R : ON", OnStyle))
                                {
                                    Main._CharacterToggle = false;
                                }
                            }
                            else if (GUI.Button(btn.BtnRect(9, false, "playermod"), "C H A N G E   C H A R A C T E R : OFF", OffStyle))
                            {
                                Main._CharacterToggle = true;
                            }
                            if (Main._isStatMenuOpen)
                            {
                                if (GUI.Button(btn.BtnRect(10, false, "playermod"), "S H O W   S T A T S : O N", OnStyle))
                                {
                                    Main._isStatMenuOpen = false;
                                }
                            }
                            else if (GUI.Button(btn.BtnRect(10, false, "playermod"), "S H O W   S T A T S : O F F", OffStyle))
                            {
                                Main._isStatMenuOpen = true;
                            }
                            if (Main._isBuffMenuOpen)
                            {
                                if (GUI.Button(btn.BtnRect(11, false, "playermod"), "G I V E   B U F F   M E N U : O N", OnStyle))
                                {
                                    Main._isBuffMenuOpen = false;
                                }
                            }
                            else if (GUI.Button(btn.BtnRect(11, false, "playermod"), "G I V E   B U F F   M E N U : O F F", OffStyle))
                            {
                                Main._isBuffMenuOpen = true;
                            }
                            if (GUI.Button(btn.BtnRect(12, false, "playermod"), "R E M O V E   A L L   B U F F S", buttonStyle))
                            {
                                PlayerMod.RemoveAllBuffs();
                            }
                            if (Main.aimBot)
                            {
                                if (GUI.Button(btn.BtnRect(13, false, "playermod"), "A I M B O T : O N", OnStyle))
                                {
                                    EntityStates.FireNailgun.spreadPitchScale = 0.5f;
                                    EntityStates.FireNailgun.spreadYawScale = 1f;
                                    EntityStates.FireNailgun.spreadBloomValue = 0.2f;
                                    Main.aimBot = false;
                                }
                            }
                            else if (!Main.aimBot)
                            {
                                if (GUI.Button(btn.BtnRect(13, false, "playermod"), "A I M B O T : O F F", OffStyle))
                                {
                                    EntityStates.FireNailgun.spreadPitchScale = 0;
                                    EntityStates.FireNailgun.spreadYawScale = 0;
                                    EntityStates.FireNailgun.spreadBloomValue = 0;
                                    Main.aimBot = true;
                                }
                            }
                            if (Main.alwaysSprint)
                            {
                                if (GUI.Button(btn.BtnRect(14, false, "playermod"), "A L W A Y S   S P R I N T : O N", Highlighted))
                                {
                                    Main.alwaysSprint = false;
                                }
                            }
                            else if (!Main.alwaysSprint)
                            {
                                if (GUI.Button(btn.BtnRect(14, false, "playermod"), "A L W A Y S   S P R I N T : O F F", Highlighted))
                                {
                                    Main.alwaysSprint = true;
                                }
                            }
                            if (Main.FlightToggle)
                            {
                                if (GUI.Button(btn.BtnRect(15, false, "playermod"), "F L I G H T : O N", OnStyle))
                                {
                                    if (PlayerMod.GetCurrentCharacter().ToString() != "Loader")
                                    {
                                        Main.LocalPlayerBody.bodyFlags &= CharacterBody.BodyFlags.None;
                                    }
                                    Main.FlightToggle = false;
                                }
                            }
                            else if (GUI.Button(btn.BtnRect(15, false, "playermod"), "F L I G H T : O F F", OffStyle))
                            {
                                Main.FlightToggle = true;
                            }
                            if (Main.godToggle)
                            {
                                if (GUI.Button(btn.BtnRect(16, false, "playermod"), "G O D   M O D E : O N", OnStyle))
                                {
                                    Main.godToggle = false;
                                }
                            }
                            else if (GUI.Button(btn.BtnRect(16, false, "playermod"), "G O D   M O D E : O F F", OffStyle))
                            {
                                Main.godToggle = true;
                            }
                            if (Main.skillToggle)
                            {
                                if (GUI.Button(btn.BtnRect(17, false, "playermod"), "I N F I N I T E   S K I L L S : O N", OnStyle))
                                {
                                    Main.skillToggle = false;
                                }
                            }
                            else if (GUI.Button(btn.BtnRect(17, false, "playermod"), "I N F I N I T E   S K I L L S : O F F", OffStyle))
                            {
                                Main.skillToggle = true;
                            }
                            if (GUI.Button(btn.BtnRect(18, false, "playermod"), "U N L O C K   A L L", buttonStyle))
                            {
                                PlayerMod.UnlockAll();
                            }
                            break;
                        }

                    case 14:
                        {
                            if (GUI.Button(btn.BtnRect(1, true, "playermod"), "G I V E   M O N E Y : " + PlayerMod.moneyToGive.ToString(), buttonStyle))
                            {
                                PlayerMod.GiveMoney();
                            }
                            if (GUI.Button(new Rect(x + widthSize - 80, y + Main.PlayerModBtnY, 40, 40), "-", OffStyle))
                            {
                                if (PlayerMod.moneyToGive > 50)
                                    PlayerMod.moneyToGive -= 50;
                            }
                            if (GUI.Button(new Rect(x + widthSize - 35, y + Main.PlayerModBtnY, 40, 40), "+", OffStyle))
                            {
                                if (PlayerMod.moneyToGive >= 50)
                                    PlayerMod.moneyToGive += 50;
                            }
                            if (GUI.Button(btn.BtnRect(2, true, "playermod"), "G I V E   L U N A R   C O I N S : " + PlayerMod.coinsToGive.ToString(), buttonStyle))
                            {
                                PlayerMod.GiveLunarCoins();
                            }
                            if (GUI.Button(new Rect(x + widthSize - 80, y + Main.PlayerModBtnY, 40, 40), "-", OffStyle))
                            {
                                if (PlayerMod.coinsToGive > 10)
                                    PlayerMod.coinsToGive -= 10;
                            }
                            if (GUI.Button(new Rect(x + widthSize - 35, y + Main.PlayerModBtnY, 40, 40), "+", OffStyle))
                            {
                                if (PlayerMod.coinsToGive >= 10)
                                    PlayerMod.coinsToGive += 10;
                            }
                            if (GUI.Button(btn.BtnRect(3, true, "playermod"), "G I V E   E X P E R I E N C E : " + PlayerMod.xpToGive.ToString(), buttonStyle))
                            {
                                PlayerMod.GiveXP();
                            }
                            if (GUI.Button(new Rect(x + widthSize - 80, y + Main.PlayerModBtnY, 40, 40), "-", OffStyle))
                            {
                                if (PlayerMod.xpToGive > 50)
                                    PlayerMod.xpToGive -= 50;
                            }
                            if (GUI.Button(new Rect(x + widthSize - 35, y + Main.PlayerModBtnY, 40, 40), "+", OffStyle))
                            {
                                if (PlayerMod.xpToGive >= 50)
                                    PlayerMod.xpToGive += 50;
                            }
                            if (Main.damageToggle)
                            {
                                if (GUI.Button(btn.BtnRect(4, true, "playermod"), "D A M A G E   P E R   L V L ( O N ) : " + PlayerMod.damagePerLvl.ToString(), OnStyle))
                                {
                                    Main.damageToggle = false;
                                }
                            }
                            else if (GUI.Button(btn.BtnRect(4, true, "playermod"), "D A M A G E   P E R   L V L ( O F F ) : " + PlayerMod.damagePerLvl.ToString(), OffStyle))
                            {
                                Main.damageToggle = true;
                            }
                            if (GUI.Button(new Rect(x + widthSize - 80, y + Main.PlayerModBtnY, 40, 40), "-", OffStyle))
                            {
                                if (PlayerMod.damagePerLvl > 0)
                                    PlayerMod.damagePerLvl -= 10;
                            }
                            if (GUI.Button(new Rect(x + widthSize - 35, y + Main.PlayerModBtnY, 40, 40), "+", OffStyle))
                            {
                                if (PlayerMod.damagePerLvl >= 0)
                                    PlayerMod.damagePerLvl += 10;
                            }
                            if (Main.critToggle)
                            {
                                if (GUI.Button(btn.BtnRect(5, true, "playermod"), "C R I T   P E R   L V L ( O N ) : " + PlayerMod.CritPerLvl.ToString(), OnStyle))
                                {
                                    Main.critToggle = false;
                                }
                            }
                            else if (GUI.Button(btn.BtnRect(5, true, "playermod"), "C R I T   P E R   L V L ( O F F ) : " + PlayerMod.CritPerLvl.ToString(), OffStyle))
                            {
                                Main.critToggle = true;
                            }
                            if (GUI.Button(new Rect(x + widthSize - 80, y + Main.PlayerModBtnY, 40, 40), "-", OffStyle))
                            {
                                if (PlayerMod.CritPerLvl > 0)
                                    PlayerMod.CritPerLvl -= 1;
                            }
                            if (GUI.Button(new Rect(x + widthSize - 35, y + Main.PlayerModBtnY, 40, 40), "+", OffStyle))
                            {
                                if (PlayerMod.CritPerLvl >= 0)
                                    PlayerMod.CritPerLvl += 1;
                            }
                            if (Main.attackSpeedToggle)
                            {
                                if (GUI.Button(btn.BtnRect(6, true, "playermod"), "A T T A C K   S P E E D ( O N ) : " + PlayerMod.attackSpeed.ToString(), OnStyle))
                                {
                                    Main.attackSpeedToggle = false;
                                }
                            }
                            else if (GUI.Button(btn.BtnRect(6, true, "playermod"), "A T T A C K   S P E E D ( O F F ) : " + PlayerMod.attackSpeed.ToString(), OffStyle))
                            {
                                Main.attackSpeedToggle = true;
                            }
                            if (GUI.Button(new Rect(x + widthSize - 80, y + Main.PlayerModBtnY, 40, 40), "-", OffStyle))
                            {
                                if (PlayerMod.attackSpeed > 0)
                                    PlayerMod.attackSpeed -= 1;
                            }
                            if (GUI.Button(new Rect(x + widthSize - 35, y + Main.PlayerModBtnY, 40, 40), "+", OffStyle))
                            {
                                if (PlayerMod.attackSpeed >= 0)
                                    PlayerMod.attackSpeed += 1;
                            }
                            if (Main.armorToggle)
                            {
                                if (GUI.Button(btn.BtnRect(7, true, "playermod"), "A R M O R ( O N ) : " + PlayerMod.armor.ToString(), OnStyle))
                                {
                                    Main.armorToggle = false;
                                }
                            }
                            else if (GUI.Button(btn.BtnRect(7, true, "playermod"), "A R M O R ( O F F ) : " + PlayerMod.armor.ToString(), OffStyle))
                            {
                                Main.armorToggle = true;
                            }
                            if (GUI.Button(new Rect(x + widthSize - 80, y + Main.PlayerModBtnY, 40, 40), "-", OffStyle))
                            {
                                if (PlayerMod.armor > 0)
                                    PlayerMod.armor -= 10;
                            }
                            if (GUI.Button(new Rect(x + widthSize - 35, y + Main.PlayerModBtnY, 40, 40), "+", OffStyle))
                            {
                                if (PlayerMod.armor >= 0)
                                    PlayerMod.armor += 10;
                            }
                            if (Main.moveSpeedToggle)
                            {
                                if (GUI.Button(btn.BtnRect(8, true, "playermod"), "M O V E   S P E E D ( O N ) : " + PlayerMod.movespeed.ToString(), OnStyle))
                                {
                                    Main.moveSpeedToggle = false;
                                }
                            }
                            else if (GUI.Button(btn.BtnRect(8, true, "playermod"), "M O V E   S P E E D ( O F F ) : " + PlayerMod.movespeed.ToString(), OffStyle))
                            {
                                Main.moveSpeedToggle = true;
                            }
                            if (GUI.Button(new Rect(x + widthSize - 80, y + Main.PlayerModBtnY, 40, 40), "-", OffStyle))
                            {
                                if (PlayerMod.movespeed > 7)
                                    PlayerMod.movespeed -= 10;
                            }
                            if (GUI.Button(new Rect(x + widthSize - 35, y + Main.PlayerModBtnY, 40, 40), "+", OffStyle))
                            {
                                if (PlayerMod.movespeed >= 7)
                                    PlayerMod.movespeed += 10;
                            }
                            if (Main._CharacterToggle)
                            {
                                if (GUI.Button(btn.BtnRect(9, false, "playermod"), "C H A N G E   C H A R A C T E R : ON", OnStyle))
                                {
                                    Main._CharacterToggle = false;
                                }
                            }
                            else if (GUI.Button(btn.BtnRect(9, false, "playermod"), "C H A N G E   C H A R A C T E R : OFF", OffStyle))
                            {
                                Main._CharacterToggle = true;
                            }
                            if (Main._isStatMenuOpen)
                            {
                                if (GUI.Button(btn.BtnRect(10, false, "playermod"), "S H O W   S T A T S : O N", OnStyle))
                                {
                                    Main._isStatMenuOpen = false;
                                }
                            }
                            else if (GUI.Button(btn.BtnRect(10, false, "playermod"), "S H O W   S T A T S : O F F", OffStyle))
                            {
                                Main._isStatMenuOpen = true;
                            }
                            if (Main._isBuffMenuOpen)
                            {
                                if (GUI.Button(btn.BtnRect(11, false, "playermod"), "G I V E   B U F F   M E N U : O N", OnStyle))
                                {
                                    Main._isBuffMenuOpen = false;
                                }
                            }
                            else if (GUI.Button(btn.BtnRect(11, false, "playermod"), "G I V E   B U F F   M E N U : O F F", OffStyle))
                            {
                                Main._isBuffMenuOpen = true;
                            }
                            if (GUI.Button(btn.BtnRect(12, false, "playermod"), "R E M O V E   A L L   B U F F S", buttonStyle))
                            {
                                PlayerMod.RemoveAllBuffs();
                            }
                            if (Main.aimBot)
                            {
                                if (GUI.Button(btn.BtnRect(13, false, "playermod"), "A I M B O T : O N", OnStyle))
                                {
                                    EntityStates.FireNailgun.spreadPitchScale = 0.5f;
                                    EntityStates.FireNailgun.spreadYawScale = 1f;
                                    EntityStates.FireNailgun.spreadBloomValue = 0.2f;
                                    Main.aimBot = false;
                                }
                            }
                            else if (!Main.aimBot)
                            {
                                if (GUI.Button(btn.BtnRect(13, false, "playermod"), "A I M B O T : O F F", OffStyle))
                                {
                                    EntityStates.FireNailgun.spreadPitchScale = 0;
                                    EntityStates.FireNailgun.spreadYawScale = 0;
                                    EntityStates.FireNailgun.spreadBloomValue = 0;
                                    Main.aimBot = true;
                                }
                            }
                            if (Main.alwaysSprint)
                            {
                                if (GUI.Button(btn.BtnRect(14, false, "playermod"), "A L W A Y S   S P R I N T : O N", OnStyle))
                                {
                                    Main.alwaysSprint = false;
                                }
                            }
                            else if (!Main.alwaysSprint)
                            {
                                if (GUI.Button(btn.BtnRect(14, false, "playermod"), "A L W A Y S   S P R I N T : O F F", OffStyle))
                                {
                                    Main.alwaysSprint = true;
                                }
                            }
                            if (Main.FlightToggle)
                            {
                                if (GUI.Button(btn.BtnRect(15, false, "playermod"), "F L I G H T : O N", Highlighted))
                                {
                                    if (PlayerMod.GetCurrentCharacter().ToString() != "Loader")
                                    {
                                        Main.LocalPlayerBody.bodyFlags &= CharacterBody.BodyFlags.None;
                                    }
                                    Main.FlightToggle = false;
                                }
                            }
                            else if (GUI.Button(btn.BtnRect(15, false, "playermod"), "F L I G H T : O F F", Highlighted))
                            {
                                Main.FlightToggle = true;
                            }
                            if (Main.godToggle)
                            {
                                if (GUI.Button(btn.BtnRect(16, false, "playermod"), "G O D   M O D E : O N", OnStyle))
                                {
                                    Main.godToggle = false;
                                }
                            }
                            else if (GUI.Button(btn.BtnRect(16, false, "playermod"), "G O D   M O D E : O F F", OffStyle))
                            {
                                Main.godToggle = true;
                            }
                            if (Main.skillToggle)
                            {
                                if (GUI.Button(btn.BtnRect(17, false, "playermod"), "I N F I N I T E   S K I L L S : O N", OnStyle))
                                {
                                    Main.skillToggle = false;
                                }
                            }
                            else if (GUI.Button(btn.BtnRect(17, false, "playermod"), "I N F I N I T E   S K I L L S : O F F", OffStyle))
                            {
                                Main.skillToggle = true;
                            }
                            if (GUI.Button(btn.BtnRect(18, false, "playermod"), "U N L O C K   A L L", buttonStyle))
                            {
                                PlayerMod.UnlockAll();
                            }
                            break;
                        }

                    case 15:
                        {
                            if (GUI.Button(btn.BtnRect(1, true, "playermod"), "G I V E   M O N E Y : " + PlayerMod.moneyToGive.ToString(), buttonStyle))
                            {
                                PlayerMod.GiveMoney();
                            }
                            if (GUI.Button(new Rect(x + widthSize - 80, y + Main.PlayerModBtnY, 40, 40), "-", OffStyle))
                            {
                                if (PlayerMod.moneyToGive > 50)
                                    PlayerMod.moneyToGive -= 50;
                            }
                            if (GUI.Button(new Rect(x + widthSize - 35, y + Main.PlayerModBtnY, 40, 40), "+", OffStyle))
                            {
                                if (PlayerMod.moneyToGive >= 50)
                                    PlayerMod.moneyToGive += 50;
                            }
                            if (GUI.Button(btn.BtnRect(2, true, "playermod"), "G I V E   L U N A R   C O I N S : " + PlayerMod.coinsToGive.ToString(), buttonStyle))
                            {
                                PlayerMod.GiveLunarCoins();
                            }
                            if (GUI.Button(new Rect(x + widthSize - 80, y + Main.PlayerModBtnY, 40, 40), "-", OffStyle))
                            {
                                if (PlayerMod.coinsToGive > 10)
                                    PlayerMod.coinsToGive -= 10;
                            }
                            if (GUI.Button(new Rect(x + widthSize - 35, y + Main.PlayerModBtnY, 40, 40), "+", OffStyle))
                            {
                                if (PlayerMod.coinsToGive >= 10)
                                    PlayerMod.coinsToGive += 10;
                            }
                            if (GUI.Button(btn.BtnRect(3, true, "playermod"), "G I V E   E X P E R I E N C E : " + PlayerMod.xpToGive.ToString(), buttonStyle))
                            {
                                PlayerMod.GiveXP();
                            }
                            if (GUI.Button(new Rect(x + widthSize - 80, y + Main.PlayerModBtnY, 40, 40), "-", OffStyle))
                            {
                                if (PlayerMod.xpToGive > 50)
                                    PlayerMod.xpToGive -= 50;
                            }
                            if (GUI.Button(new Rect(x + widthSize - 35, y + Main.PlayerModBtnY, 40, 40), "+", OffStyle))
                            {
                                if (PlayerMod.xpToGive >= 50)
                                    PlayerMod.xpToGive += 50;
                            }
                            if (Main.damageToggle)
                            {
                                if (GUI.Button(btn.BtnRect(4, true, "playermod"), "D A M A G E   P E R   L V L ( O N ) : " + PlayerMod.damagePerLvl.ToString(), OnStyle))
                                {
                                    Main.damageToggle = false;
                                }
                            }
                            else if (GUI.Button(btn.BtnRect(4, true, "playermod"), "D A M A G E   P E R   L V L ( O F F ) : " + PlayerMod.damagePerLvl.ToString(), OffStyle))
                            {
                                Main.damageToggle = true;
                            }
                            if (GUI.Button(new Rect(x + widthSize - 80, y + Main.PlayerModBtnY, 40, 40), "-", OffStyle))
                            {
                                if (PlayerMod.damagePerLvl > 0)
                                    PlayerMod.damagePerLvl -= 10;
                            }
                            if (GUI.Button(new Rect(x + widthSize - 35, y + Main.PlayerModBtnY, 40, 40), "+", OffStyle))
                            {
                                if (PlayerMod.damagePerLvl >= 0)
                                    PlayerMod.damagePerLvl += 10;
                            }
                            if (Main.critToggle)
                            {
                                if (GUI.Button(btn.BtnRect(5, true, "playermod"), "C R I T   P E R   L V L ( O N ) : " + PlayerMod.CritPerLvl.ToString(), OnStyle))
                                {
                                    Main.critToggle = false;
                                }
                            }
                            else if (GUI.Button(btn.BtnRect(5, true, "playermod"), "C R I T   P E R   L V L ( O F F ) : " + PlayerMod.CritPerLvl.ToString(), OffStyle))
                            {
                                Main.critToggle = true;
                            }
                            if (GUI.Button(new Rect(x + widthSize - 80, y + Main.PlayerModBtnY, 40, 40), "-", OffStyle))
                            {
                                if (PlayerMod.CritPerLvl > 0)
                                    PlayerMod.CritPerLvl -= 1;
                            }
                            if (GUI.Button(new Rect(x + widthSize - 35, y + Main.PlayerModBtnY, 40, 40), "+", OffStyle))
                            {
                                if (PlayerMod.CritPerLvl >= 0)
                                    PlayerMod.CritPerLvl += 1;
                            }
                            if (Main.attackSpeedToggle)
                            {
                                if (GUI.Button(btn.BtnRect(6, true, "playermod"), "A T T A C K   S P E E D ( O N ) : " + PlayerMod.attackSpeed.ToString(), OnStyle))
                                {
                                    Main.attackSpeedToggle = false;
                                }
                            }
                            else if (GUI.Button(btn.BtnRect(6, true, "playermod"), "A T T A C K   S P E E D ( O F F ) : " + PlayerMod.attackSpeed.ToString(), OffStyle))
                            {
                                Main.attackSpeedToggle = true;
                            }
                            if (GUI.Button(new Rect(x + widthSize - 80, y + Main.PlayerModBtnY, 40, 40), "-", OffStyle))
                            {
                                if (PlayerMod.attackSpeed > 0)
                                    PlayerMod.attackSpeed -= 1;
                            }
                            if (GUI.Button(new Rect(x + widthSize - 35, y + Main.PlayerModBtnY, 40, 40), "+", OffStyle))
                            {
                                if (PlayerMod.attackSpeed >= 0)
                                    PlayerMod.attackSpeed += 1;
                            }
                            if (Main.armorToggle)
                            {
                                if (GUI.Button(btn.BtnRect(7, true, "playermod"), "A R M O R ( O N ) : " + PlayerMod.armor.ToString(), OnStyle))
                                {
                                    Main.armorToggle = false;
                                }
                            }
                            else if (GUI.Button(btn.BtnRect(7, true, "playermod"), "A R M O R ( O F F ) : " + PlayerMod.armor.ToString(), OffStyle))
                            {
                                Main.armorToggle = true;
                            }
                            if (GUI.Button(new Rect(x + widthSize - 80, y + Main.PlayerModBtnY, 40, 40), "-", OffStyle))
                            {
                                if (PlayerMod.armor > 0)
                                    PlayerMod.armor -= 10;
                            }
                            if (GUI.Button(new Rect(x + widthSize - 35, y + Main.PlayerModBtnY, 40, 40), "+", OffStyle))
                            {
                                if (PlayerMod.armor >= 0)
                                    PlayerMod.armor += 10;
                            }
                            if (Main.moveSpeedToggle)
                            {
                                if (GUI.Button(btn.BtnRect(8, true, "playermod"), "M O V E   S P E E D ( O N ) : " + PlayerMod.movespeed.ToString(), OnStyle))
                                {
                                    Main.moveSpeedToggle = false;
                                }
                            }
                            else if (GUI.Button(btn.BtnRect(8, true, "playermod"), "M O V E   S P E E D ( O F F ) : " + PlayerMod.movespeed.ToString(), OffStyle))
                            {
                                Main.moveSpeedToggle = true;
                            }
                            if (GUI.Button(new Rect(x + widthSize - 80, y + Main.PlayerModBtnY, 40, 40), "-", OffStyle))
                            {
                                if (PlayerMod.movespeed > 7)
                                    PlayerMod.movespeed -= 10;
                            }
                            if (GUI.Button(new Rect(x + widthSize - 35, y + Main.PlayerModBtnY, 40, 40), "+", OffStyle))
                            {
                                if (PlayerMod.movespeed >= 7)
                                    PlayerMod.movespeed += 10;
                            }
                            if (Main._CharacterToggle)
                            {
                                if (GUI.Button(btn.BtnRect(9, false, "playermod"), "C H A N G E   C H A R A C T E R : ON", OnStyle))
                                {
                                    Main._CharacterToggle = false;
                                }
                            }
                            else if (GUI.Button(btn.BtnRect(9, false, "playermod"), "C H A N G E   C H A R A C T E R : OFF", OffStyle))
                            {
                                Main._CharacterToggle = true;
                            }
                            if (Main._isStatMenuOpen)
                            {
                                if (GUI.Button(btn.BtnRect(10, false, "playermod"), "S H O W   S T A T S : O N", OnStyle))
                                {
                                    Main._isStatMenuOpen = false;
                                }
                            }
                            else if (GUI.Button(btn.BtnRect(10, false, "playermod"), "S H O W   S T A T S : O F F", OffStyle))
                            {
                                Main._isStatMenuOpen = true;
                            }
                            if (Main._isBuffMenuOpen)
                            {
                                if (GUI.Button(btn.BtnRect(11, false, "playermod"), "G I V E   B U F F   M E N U : O N", OnStyle))
                                {
                                    Main._isBuffMenuOpen = false;
                                }
                            }
                            else if (GUI.Button(btn.BtnRect(11, false, "playermod"), "G I V E   B U F F   M E N U : O F F", OffStyle))
                            {
                                Main._isBuffMenuOpen = true;
                            }
                            if (GUI.Button(btn.BtnRect(12, false, "playermod"), "R E M O V E   A L L   B U F F S", buttonStyle))
                            {
                                PlayerMod.RemoveAllBuffs();
                            }
                            if (Main.aimBot)
                            {
                                if (GUI.Button(btn.BtnRect(13, false, "playermod"), "A I M B O T : O N", OnStyle))
                                {
                                    EntityStates.FireNailgun.spreadPitchScale = 0.5f;
                                    EntityStates.FireNailgun.spreadYawScale = 1f;
                                    EntityStates.FireNailgun.spreadBloomValue = 0.2f;
                                    Main.aimBot = false;
                                }
                            }
                            else if (!Main.aimBot)
                            {
                                if (GUI.Button(btn.BtnRect(13, false, "playermod"), "A I M B O T : O F F", OffStyle))
                                {
                                    EntityStates.FireNailgun.spreadPitchScale = 0;
                                    EntityStates.FireNailgun.spreadYawScale = 0;
                                    EntityStates.FireNailgun.spreadBloomValue = 0;
                                    Main.aimBot = true;
                                }
                            }
                            if (Main.alwaysSprint)
                            {
                                if (GUI.Button(btn.BtnRect(14, false, "playermod"), "A L W A Y S   S P R I N T : O N", OnStyle))
                                {
                                    Main.alwaysSprint = false;
                                }
                            }
                            else if (!Main.alwaysSprint)
                            {
                                if (GUI.Button(btn.BtnRect(14, false, "playermod"), "A L W A Y S   S P R I N T : O F F", OffStyle))
                                {
                                    Main.alwaysSprint = true;
                                }
                            }
                            if (Main.FlightToggle)
                            {
                                if (GUI.Button(btn.BtnRect(15, false, "playermod"), "F L I G H T : O N", OnStyle))
                                {
                                    if (PlayerMod.GetCurrentCharacter().ToString() != "Loader")
                                    {
                                        Main.LocalPlayerBody.bodyFlags &= CharacterBody.BodyFlags.None;
                                    }
                                    Main.FlightToggle = false;
                                }
                            }
                            else if (GUI.Button(btn.BtnRect(15, false, "playermod"), "F L I G H T : O F F", OffStyle))
                            {
                                Main.FlightToggle = true;
                            }
                            if (Main.godToggle)
                            {
                                if (GUI.Button(btn.BtnRect(16, false, "playermod"), "G O D   M O D E : O N", Highlighted))
                                {
                                    Main.godToggle = false;
                                }
                            }
                            else if (GUI.Button(btn.BtnRect(16, false, "playermod"), "G O D   M O D E : O F F", Highlighted))
                            {
                                Main.godToggle = true;
                            }
                            if (Main.skillToggle)
                            {
                                if (GUI.Button(btn.BtnRect(17, false, "playermod"), "I N F I N I T E   S K I L L S : O N", OnStyle))
                                {
                                    Main.skillToggle = false;
                                }
                            }
                            else if (GUI.Button(btn.BtnRect(17, false, "playermod"), "I N F I N I T E   S K I L L S : O F F", OffStyle))
                            {
                                Main.skillToggle = true;
                            }
                            if (GUI.Button(btn.BtnRect(18, false, "playermod"), "U N L O C K   A L L", buttonStyle))
                            {
                                PlayerMod.UnlockAll();
                            }
                            break;
                        }

                    case 16:
                        {
                            if (GUI.Button(btn.BtnRect(1, true, "playermod"), "G I V E   M O N E Y : " + PlayerMod.moneyToGive.ToString(), buttonStyle))
                            {
                                PlayerMod.GiveMoney();
                            }
                            if (GUI.Button(new Rect(x + widthSize - 80, y + Main.PlayerModBtnY, 40, 40), "-", OffStyle))
                            {
                                if (PlayerMod.moneyToGive > 50)
                                    PlayerMod.moneyToGive -= 50;
                            }
                            if (GUI.Button(new Rect(x + widthSize - 35, y + Main.PlayerModBtnY, 40, 40), "+", OffStyle))
                            {
                                if (PlayerMod.moneyToGive >= 50)
                                    PlayerMod.moneyToGive += 50;
                            }
                            if (GUI.Button(btn.BtnRect(2, true, "playermod"), "G I V E   L U N A R   C O I N S : " + PlayerMod.coinsToGive.ToString(), buttonStyle))
                            {
                                PlayerMod.GiveLunarCoins();
                            }
                            if (GUI.Button(new Rect(x + widthSize - 80, y + Main.PlayerModBtnY, 40, 40), "-", OffStyle))
                            {
                                if (PlayerMod.coinsToGive > 10)
                                    PlayerMod.coinsToGive -= 10;
                            }
                            if (GUI.Button(new Rect(x + widthSize - 35, y + Main.PlayerModBtnY, 40, 40), "+", OffStyle))
                            {
                                if (PlayerMod.coinsToGive >= 10)
                                    PlayerMod.coinsToGive += 10;
                            }
                            if (GUI.Button(btn.BtnRect(3, true, "playermod"), "G I V E   E X P E R I E N C E : " + PlayerMod.xpToGive.ToString(), buttonStyle))
                            {
                                PlayerMod.GiveXP();
                            }
                            if (GUI.Button(new Rect(x + widthSize - 80, y + Main.PlayerModBtnY, 40, 40), "-", OffStyle))
                            {
                                if (PlayerMod.xpToGive > 50)
                                    PlayerMod.xpToGive -= 50;
                            }
                            if (GUI.Button(new Rect(x + widthSize - 35, y + Main.PlayerModBtnY, 40, 40), "+", OffStyle))
                            {
                                if (PlayerMod.xpToGive >= 50)
                                    PlayerMod.xpToGive += 50;
                            }
                            if (Main.damageToggle)
                            {
                                if (GUI.Button(btn.BtnRect(4, true, "playermod"), "D A M A G E   P E R   L V L ( O N ) : " + PlayerMod.damagePerLvl.ToString(), OnStyle))
                                {
                                    Main.damageToggle = false;
                                }
                            }
                            else if (GUI.Button(btn.BtnRect(4, true, "playermod"), "D A M A G E   P E R   L V L ( O F F ) : " + PlayerMod.damagePerLvl.ToString(), OffStyle))
                            {
                                Main.damageToggle = true;
                            }
                            if (GUI.Button(new Rect(x + widthSize - 80, y + Main.PlayerModBtnY, 40, 40), "-", OffStyle))
                            {
                                if (PlayerMod.damagePerLvl > 0)
                                    PlayerMod.damagePerLvl -= 10;
                            }
                            if (GUI.Button(new Rect(x + widthSize - 35, y + Main.PlayerModBtnY, 40, 40), "+", OffStyle))
                            {
                                if (PlayerMod.damagePerLvl >= 0)
                                    PlayerMod.damagePerLvl += 10;
                            }
                            if (Main.critToggle)
                            {
                                if (GUI.Button(btn.BtnRect(5, true, "playermod"), "C R I T   P E R   L V L ( O N ) : " + PlayerMod.CritPerLvl.ToString(), OnStyle))
                                {
                                    Main.critToggle = false;
                                }
                            }
                            else if (GUI.Button(btn.BtnRect(5, true, "playermod"), "C R I T   P E R   L V L ( O F F ) : " + PlayerMod.CritPerLvl.ToString(), OffStyle))
                            {
                                Main.critToggle = true;
                            }
                            if (GUI.Button(new Rect(x + widthSize - 80, y + Main.PlayerModBtnY, 40, 40), "-", OffStyle))
                            {
                                if (PlayerMod.CritPerLvl > 0)
                                    PlayerMod.CritPerLvl -= 1;
                            }
                            if (GUI.Button(new Rect(x + widthSize - 35, y + Main.PlayerModBtnY, 40, 40), "+", OffStyle))
                            {
                                if (PlayerMod.CritPerLvl >= 0)
                                    PlayerMod.CritPerLvl += 1;
                            }
                            if (Main.attackSpeedToggle)
                            {
                                if (GUI.Button(btn.BtnRect(6, true, "playermod"), "A T T A C K   S P E E D ( O N ) : " + PlayerMod.attackSpeed.ToString(), OnStyle))
                                {
                                    Main.attackSpeedToggle = false;
                                }
                            }
                            else if (GUI.Button(btn.BtnRect(6, true, "playermod"), "A T T A C K   S P E E D ( O F F ) : " + PlayerMod.attackSpeed.ToString(), OffStyle))
                            {
                                Main.attackSpeedToggle = true;
                            }
                            if (GUI.Button(new Rect(x + widthSize - 80, y + Main.PlayerModBtnY, 40, 40), "-", OffStyle))
                            {
                                if (PlayerMod.attackSpeed > 0)
                                    PlayerMod.attackSpeed -= 1;
                            }
                            if (GUI.Button(new Rect(x + widthSize - 35, y + Main.PlayerModBtnY, 40, 40), "+", OffStyle))
                            {
                                if (PlayerMod.attackSpeed >= 0)
                                    PlayerMod.attackSpeed += 1;
                            }
                            if (Main.armorToggle)
                            {
                                if (GUI.Button(btn.BtnRect(7, true, "playermod"), "A R M O R ( O N ) : " + PlayerMod.armor.ToString(), OnStyle))
                                {
                                    Main.armorToggle = false;
                                }
                            }
                            else if (GUI.Button(btn.BtnRect(7, true, "playermod"), "A R M O R ( O F F ) : " + PlayerMod.armor.ToString(), OffStyle))
                            {
                                Main.armorToggle = true;
                            }
                            if (GUI.Button(new Rect(x + widthSize - 80, y + Main.PlayerModBtnY, 40, 40), "-", OffStyle))
                            {
                                if (PlayerMod.armor > 0)
                                    PlayerMod.armor -= 10;
                            }
                            if (GUI.Button(new Rect(x + widthSize - 35, y + Main.PlayerModBtnY, 40, 40), "+", OffStyle))
                            {
                                if (PlayerMod.armor >= 0)
                                    PlayerMod.armor += 10;
                            }
                            if (Main.moveSpeedToggle)
                            {
                                if (GUI.Button(btn.BtnRect(8, true, "playermod"), "M O V E   S P E E D ( O N ) : " + PlayerMod.movespeed.ToString(), OnStyle))
                                {
                                    Main.moveSpeedToggle = false;
                                }
                            }
                            else if (GUI.Button(btn.BtnRect(8, true, "playermod"), "M O V E   S P E E D ( O F F ) : " + PlayerMod.movespeed.ToString(), OffStyle))
                            {
                                Main.moveSpeedToggle = true;
                            }
                            if (GUI.Button(new Rect(x + widthSize - 80, y + Main.PlayerModBtnY, 40, 40), "-", OffStyle))
                            {
                                if (PlayerMod.movespeed > 7)
                                    PlayerMod.movespeed -= 10;
                            }
                            if (GUI.Button(new Rect(x + widthSize - 35, y + Main.PlayerModBtnY, 40, 40), "+", OffStyle))
                            {
                                if (PlayerMod.movespeed >= 7)
                                    PlayerMod.movespeed += 10;
                            }
                            if (Main._CharacterToggle)
                            {
                                if (GUI.Button(btn.BtnRect(9, false, "playermod"), "C H A N G E   C H A R A C T E R : ON", OnStyle))
                                {
                                    Main._CharacterToggle = false;
                                }
                            }
                            else if (GUI.Button(btn.BtnRect(9, false, "playermod"), "C H A N G E   C H A R A C T E R : OFF", OffStyle))
                            {
                                Main._CharacterToggle = true;
                            }
                            if (Main._isStatMenuOpen)
                            {
                                if (GUI.Button(btn.BtnRect(10, false, "playermod"), "S H O W   S T A T S : O N", OnStyle))
                                {
                                    Main._isStatMenuOpen = false;
                                }
                            }
                            else if (GUI.Button(btn.BtnRect(10, false, "playermod"), "S H O W   S T A T S : O F F", OffStyle))
                            {
                                Main._isStatMenuOpen = true;
                            }
                            if (Main._isBuffMenuOpen)
                            {
                                if (GUI.Button(btn.BtnRect(11, false, "playermod"), "G I V E   B U F F   M E N U : O N", OnStyle))
                                {
                                    Main._isBuffMenuOpen = false;
                                }
                            }
                            else if (GUI.Button(btn.BtnRect(11, false, "playermod"), "G I V E   B U F F   M E N U : O F F", OffStyle))
                            {
                                Main._isBuffMenuOpen = true;
                            }
                            if (GUI.Button(btn.BtnRect(12, false, "playermod"), "R E M O V E   A L L   B U F F S", buttonStyle))
                            {
                                PlayerMod.RemoveAllBuffs();
                            }
                            if (Main.aimBot)
                            {
                                if (GUI.Button(btn.BtnRect(13, false, "playermod"), "A I M B O T : O N", OnStyle))
                                {
                                    EntityStates.FireNailgun.spreadPitchScale = 0.5f;
                                    EntityStates.FireNailgun.spreadYawScale = 1f;
                                    EntityStates.FireNailgun.spreadBloomValue = 0.2f;
                                    Main.aimBot = false;
                                }
                            }
                            else if (!Main.aimBot)
                            {
                                if (GUI.Button(btn.BtnRect(13, false, "playermod"), "A I M B O T : O F F", OffStyle))
                                {
                                    EntityStates.FireNailgun.spreadPitchScale = 0;
                                    EntityStates.FireNailgun.spreadYawScale = 0;
                                    EntityStates.FireNailgun.spreadBloomValue = 0;
                                    Main.aimBot = true;
                                }
                            }
                            if (Main.alwaysSprint)
                            {
                                if (GUI.Button(btn.BtnRect(14, false, "playermod"), "A L W A Y S   S P R I N T : O N", OnStyle))
                                {
                                    Main.alwaysSprint = false;
                                }
                            }
                            else if (!Main.alwaysSprint)
                            {
                                if (GUI.Button(btn.BtnRect(14, false, "playermod"), "A L W A Y S   S P R I N T : O F F", OffStyle))
                                {
                                    Main.alwaysSprint = true;
                                }
                            }
                            if (Main.FlightToggle)
                            {
                                if (GUI.Button(btn.BtnRect(15, false, "playermod"), "F L I G H T : O N", OnStyle))
                                {
                                    if (PlayerMod.GetCurrentCharacter().ToString() != "Loader")
                                    {
                                        Main.LocalPlayerBody.bodyFlags &= CharacterBody.BodyFlags.None;
                                    }
                                    Main.FlightToggle = false;
                                }
                            }
                            else if (GUI.Button(btn.BtnRect(15, false, "playermod"), "F L I G H T : O F F", OffStyle))
                            {
                                Main.FlightToggle = true;
                            }
                            if (Main.godToggle)
                            {
                                if (GUI.Button(btn.BtnRect(16, false, "playermod"), "G O D   M O D E : O N", OnStyle))
                                {
                                    Main.godToggle = false;
                                }
                            }
                            else if (GUI.Button(btn.BtnRect(16, false, "playermod"), "G O D   M O D E : O F F", OffStyle))
                            {
                                Main.godToggle = true;
                            }
                            if (Main.skillToggle)
                            {
                                if (GUI.Button(btn.BtnRect(17, false, "playermod"), "I N F I N I T E   S K I L L S : O N", Highlighted))
                                {
                                    Main.skillToggle = false;
                                }
                            }
                            else if (GUI.Button(btn.BtnRect(17, false, "playermod"), "I N F I N I T E   S K I L L S : O F F", Highlighted))
                            {
                                Main.skillToggle = true;
                            }
                            if (GUI.Button(btn.BtnRect(18, false, "playermod"), "U N L O C K   A L L", buttonStyle))
                            {
                                PlayerMod.UnlockAll();
                            }
                            break;
                        }

                    case 17:
                        {
                            if (GUI.Button(btn.BtnRect(1, true, "playermod"), "G I V E   M O N E Y : " + PlayerMod.moneyToGive.ToString(), buttonStyle))
                            {
                                PlayerMod.GiveMoney();
                            }
                            if (GUI.Button(new Rect(x + widthSize - 80, y + Main.PlayerModBtnY, 40, 40), "-", OffStyle))
                            {
                                if (PlayerMod.moneyToGive > 50)
                                    PlayerMod.moneyToGive -= 50;
                            }
                            if (GUI.Button(new Rect(x + widthSize - 35, y + Main.PlayerModBtnY, 40, 40), "+", OffStyle))
                            {
                                if (PlayerMod.moneyToGive >= 50)
                                    PlayerMod.moneyToGive += 50;
                            }
                            if (GUI.Button(btn.BtnRect(2, true, "playermod"), "G I V E   L U N A R   C O I N S : " + PlayerMod.coinsToGive.ToString(), buttonStyle))
                            {
                                PlayerMod.GiveLunarCoins();
                            }
                            if (GUI.Button(new Rect(x + widthSize - 80, y + Main.PlayerModBtnY, 40, 40), "-", OffStyle))
                            {
                                if (PlayerMod.coinsToGive > 10)
                                    PlayerMod.coinsToGive -= 10;
                            }
                            if (GUI.Button(new Rect(x + widthSize - 35, y + Main.PlayerModBtnY, 40, 40), "+", OffStyle))
                            {
                                if (PlayerMod.coinsToGive >= 10)
                                    PlayerMod.coinsToGive += 10;
                            }
                            if (GUI.Button(btn.BtnRect(3, true, "playermod"), "G I V E   E X P E R I E N C E : " + PlayerMod.xpToGive.ToString(), buttonStyle))
                            {
                                PlayerMod.GiveXP();
                            }
                            if (GUI.Button(new Rect(x + widthSize - 80, y + Main.PlayerModBtnY, 40, 40), "-", OffStyle))
                            {
                                if (PlayerMod.xpToGive > 50)
                                    PlayerMod.xpToGive -= 50;
                            }
                            if (GUI.Button(new Rect(x + widthSize - 35, y + Main.PlayerModBtnY, 40, 40), "+", OffStyle))
                            {
                                if (PlayerMod.xpToGive >= 50)
                                    PlayerMod.xpToGive += 50;
                            }
                            if (Main.damageToggle)
                            {
                                if (GUI.Button(btn.BtnRect(4, true, "playermod"), "D A M A G E   P E R   L V L ( O N ) : " + PlayerMod.damagePerLvl.ToString(), OnStyle))
                                {
                                    Main.damageToggle = false;
                                }
                            }
                            else if (GUI.Button(btn.BtnRect(4, true, "playermod"), "D A M A G E   P E R   L V L ( O F F ) : " + PlayerMod.damagePerLvl.ToString(), OffStyle))
                            {
                                Main.damageToggle = true;
                            }
                            if (GUI.Button(new Rect(x + widthSize - 80, y + Main.PlayerModBtnY, 40, 40), "-", OffStyle))
                            {
                                if (PlayerMod.damagePerLvl > 0)
                                    PlayerMod.damagePerLvl -= 10;
                            }
                            if (GUI.Button(new Rect(x + widthSize - 35, y + Main.PlayerModBtnY, 40, 40), "+", OffStyle))
                            {
                                if (PlayerMod.damagePerLvl >= 0)
                                    PlayerMod.damagePerLvl += 10;
                            }
                            if (Main.critToggle)
                            {
                                if (GUI.Button(btn.BtnRect(5, true, "playermod"), "C R I T   P E R   L V L ( O N ) : " + PlayerMod.CritPerLvl.ToString(), OnStyle))
                                {
                                    Main.critToggle = false;
                                }
                            }
                            else if (GUI.Button(btn.BtnRect(5, true, "playermod"), "C R I T   P E R   L V L ( O F F ) : " + PlayerMod.CritPerLvl.ToString(), OffStyle))
                            {
                                Main.critToggle = true;
                            }
                            if (GUI.Button(new Rect(x + widthSize - 80, y + Main.PlayerModBtnY, 40, 40), "-", OffStyle))
                            {
                                if (PlayerMod.CritPerLvl > 0)
                                    PlayerMod.CritPerLvl -= 1;
                            }
                            if (GUI.Button(new Rect(x + widthSize - 35, y + Main.PlayerModBtnY, 40, 40), "+", OffStyle))
                            {
                                if (PlayerMod.CritPerLvl >= 0)
                                    PlayerMod.CritPerLvl += 1;
                            }
                            if (Main.attackSpeedToggle)
                            {
                                if (GUI.Button(btn.BtnRect(6, true, "playermod"), "A T T A C K   S P E E D ( O N ) : " + PlayerMod.attackSpeed.ToString(), OnStyle))
                                {
                                    Main.attackSpeedToggle = false;
                                }
                            }
                            else if (GUI.Button(btn.BtnRect(6, true, "playermod"), "A T T A C K   S P E E D ( O F F ) : " + PlayerMod.attackSpeed.ToString(), OffStyle))
                            {
                                Main.attackSpeedToggle = true;
                            }
                            if (GUI.Button(new Rect(x + widthSize - 80, y + Main.PlayerModBtnY, 40, 40), "-", OffStyle))
                            {
                                if (PlayerMod.attackSpeed > 0)
                                    PlayerMod.attackSpeed -= 1;
                            }
                            if (GUI.Button(new Rect(x + widthSize - 35, y + Main.PlayerModBtnY, 40, 40), "+", OffStyle))
                            {
                                if (PlayerMod.attackSpeed >= 0)
                                    PlayerMod.attackSpeed += 1;
                            }
                            if (Main.armorToggle)
                            {
                                if (GUI.Button(btn.BtnRect(7, true, "playermod"), "A R M O R ( O N ) : " + PlayerMod.armor.ToString(), OnStyle))
                                {
                                    Main.armorToggle = false;
                                }
                            }
                            else if (GUI.Button(btn.BtnRect(7, true, "playermod"), "A R M O R ( O F F ) : " + PlayerMod.armor.ToString(), OffStyle))
                            {
                                Main.armorToggle = true;
                            }
                            if (GUI.Button(new Rect(x + widthSize - 80, y + Main.PlayerModBtnY, 40, 40), "-", OffStyle))
                            {
                                if (PlayerMod.armor > 0)
                                    PlayerMod.armor -= 10;
                            }
                            if (GUI.Button(new Rect(x + widthSize - 35, y + Main.PlayerModBtnY, 40, 40), "+", OffStyle))
                            {
                                if (PlayerMod.armor >= 0)
                                    PlayerMod.armor += 10;
                            }
                            if (Main.moveSpeedToggle)
                            {
                                if (GUI.Button(btn.BtnRect(8, true, "playermod"), "M O V E   S P E E D ( O N ) : " + PlayerMod.movespeed.ToString(), OnStyle))
                                {
                                    Main.moveSpeedToggle = false;
                                }
                            }
                            else if (GUI.Button(btn.BtnRect(8, true, "playermod"), "M O V E   S P E E D ( O F F ) : " + PlayerMod.movespeed.ToString(), OffStyle))
                            {
                                Main.moveSpeedToggle = true;
                            }
                            if (GUI.Button(new Rect(x + widthSize - 80, y + Main.PlayerModBtnY, 40, 40), "-", OffStyle))
                            {
                                if (PlayerMod.movespeed > 7)
                                    PlayerMod.movespeed -= 10;
                            }
                            if (GUI.Button(new Rect(x + widthSize - 35, y + Main.PlayerModBtnY, 40, 40), "+", OffStyle))
                            {
                                if (PlayerMod.movespeed >= 7)
                                    PlayerMod.movespeed += 10;
                            }
                            if (Main._CharacterToggle)
                            {
                                if (GUI.Button(btn.BtnRect(9, false, "playermod"), "C H A N G E   C H A R A C T E R : ON", OnStyle))
                                {
                                    Main._CharacterToggle = false;
                                }
                            }
                            else if (GUI.Button(btn.BtnRect(9, false, "playermod"), "C H A N G E   C H A R A C T E R : OFF", OffStyle))
                            {
                                Main._CharacterToggle = true;
                            }
                            if (Main._isStatMenuOpen)
                            {
                                if (GUI.Button(btn.BtnRect(10, false, "playermod"), "S H O W   S T A T S : O N", OnStyle))
                                {
                                    Main._isStatMenuOpen = false;
                                }
                            }
                            else if (GUI.Button(btn.BtnRect(10, false, "playermod"), "S H O W   S T A T S : O F F", OffStyle))
                            {
                                Main._isStatMenuOpen = true;
                            }
                            if (Main._isBuffMenuOpen)
                            {
                                if (GUI.Button(btn.BtnRect(11, false, "playermod"), "G I V E   B U F F   M E N U : O N", OnStyle))
                                {
                                    Main._isBuffMenuOpen = false;
                                }
                            }
                            else if (GUI.Button(btn.BtnRect(11, false, "playermod"), "G I V E   B U F F   M E N U : O F F", OffStyle))
                            {
                                Main._isBuffMenuOpen = true;
                            }
                            if (GUI.Button(btn.BtnRect(12, false, "playermod"), "R E M O V E   A L L   B U F F S", buttonStyle))
                            {
                                PlayerMod.RemoveAllBuffs();
                            }
                            if (Main.aimBot)
                            {
                                if (GUI.Button(btn.BtnRect(13, false, "playermod"), "A I M B O T : O N", OnStyle))
                                {
                                    EntityStates.FireNailgun.spreadPitchScale = 0.5f;
                                    EntityStates.FireNailgun.spreadYawScale = 1f;
                                    EntityStates.FireNailgun.spreadBloomValue = 0.2f;
                                    Main.aimBot = false;
                                }
                            }
                            else if (!Main.aimBot)
                            {
                                if (GUI.Button(btn.BtnRect(13, false, "playermod"), "A I M B O T : O F F", OffStyle))
                                {
                                    EntityStates.FireNailgun.spreadPitchScale = 0;
                                    EntityStates.FireNailgun.spreadYawScale = 0;
                                    EntityStates.FireNailgun.spreadBloomValue = 0;
                                    Main.aimBot = true;
                                }
                            }
                            if (Main.alwaysSprint)
                            {
                                if (GUI.Button(btn.BtnRect(14, false, "playermod"), "A L W A Y S   S P R I N T : O N", OnStyle))
                                {
                                    Main.alwaysSprint = false;
                                }
                            }
                            else if (!Main.alwaysSprint)
                            {
                                if (GUI.Button(btn.BtnRect(14, false, "playermod"), "A L W A Y S   S P R I N T : O F F", OffStyle))
                                {
                                    Main.alwaysSprint = true;
                                }
                            }
                            if (Main.FlightToggle)
                            {
                                if (GUI.Button(btn.BtnRect(15, false, "playermod"), "F L I G H T : O N", OnStyle))
                                {
                                    if (PlayerMod.GetCurrentCharacter().ToString() != "Loader")
                                    {
                                        Main.LocalPlayerBody.bodyFlags &= CharacterBody.BodyFlags.None;
                                    }
                                    Main.FlightToggle = false;
                                }
                            }
                            else if (GUI.Button(btn.BtnRect(15, false, "playermod"), "F L I G H T : O F F", OffStyle))
                            {
                                Main.FlightToggle = true;
                            }
                            if (Main.godToggle)
                            {
                                if (GUI.Button(btn.BtnRect(16, false, "playermod"), "G O D   M O D E : O N", OnStyle))
                                {
                                    Main.godToggle = false;
                                }
                            }
                            else if (GUI.Button(btn.BtnRect(16, false, "playermod"), "G O D   M O D E : O F F", OffStyle))
                            {
                                Main.godToggle = true;
                            }
                            if (Main.skillToggle)
                            {
                                if (GUI.Button(btn.BtnRect(17, false, "playermod"), "I N F I N I T E   S K I L L S : O N", OnStyle))
                                {
                                    Main.skillToggle = false;
                                }
                            }
                            else if (GUI.Button(btn.BtnRect(17, false, "playermod"), "I N F I N I T E   S K I L L S : O F F", OffStyle))
                            {
                                Main.skillToggle = true;
                            }
                            if (GUI.Button(btn.BtnRect(18, false, "playermod"), "U N L O C K   A L L", Highlighted))
                            {
                                PlayerMod.UnlockAll();
                            }
                            break;
                        }

                    default:
                        {
                            if (Navigation.IntraMenuIndex > 17)
                            {
                                Navigation.IntraMenuIndex = 0;
                            }
                            if (Navigation.IntraMenuIndex < 0)
                            {
                                Navigation.IntraMenuIndex = 17;
                            }
                            break;
                        }
                }
            }
            else
            {
                if (GUI.Button(btn.BtnRect(1, true, "playermod"), "G I V E   M O N E Y : " + PlayerMod.moneyToGive.ToString(), buttonStyle))
                {
                    PlayerMod.GiveMoney();
                }
                if (GUI.Button(new Rect(x + widthSize - 80, y + Main.PlayerModBtnY, 40, 40), "-", OffStyle))
                {
                    if (PlayerMod.moneyToGive > 50)
                        PlayerMod.moneyToGive -= 50;
                }
                if (GUI.Button(new Rect(x + widthSize - 35, y + Main.PlayerModBtnY, 40, 40), "+", OffStyle))
                {
                    if (PlayerMod.moneyToGive >= 50)
                        PlayerMod.moneyToGive += 50;
                }
                if (GUI.Button(btn.BtnRect(2, true, "playermod"), "G I V E   L U N A R   C O I N S : " + PlayerMod.coinsToGive.ToString(), buttonStyle))
                {
                    PlayerMod.GiveLunarCoins();
                }
                if (GUI.Button(new Rect(x + widthSize - 80, y + Main.PlayerModBtnY, 40, 40), "-", OffStyle))
                {
                    if (PlayerMod.coinsToGive > 10)
                        PlayerMod.coinsToGive -= 10;
                }
                if (GUI.Button(new Rect(x + widthSize - 35, y + Main.PlayerModBtnY, 40, 40), "+", OffStyle))
                {
                    if (PlayerMod.coinsToGive >= 10)
                        PlayerMod.coinsToGive += 10;
                }
                if (GUI.Button(btn.BtnRect(3, true, "playermod"), "G I V E   E X P E R I E N C E : " + PlayerMod.xpToGive.ToString(), buttonStyle))
                {
                    PlayerMod.GiveXP();
                }
                if (GUI.Button(new Rect(x + widthSize - 80, y + Main.PlayerModBtnY, 40, 40), "-", OffStyle))
                {
                    if (PlayerMod.xpToGive > 50)
                        PlayerMod.xpToGive -= 50;
                }
                if (GUI.Button(new Rect(x + widthSize - 35, y + Main.PlayerModBtnY, 40, 40), "+", OffStyle))
                {
                    if (PlayerMod.xpToGive >= 50)
                        PlayerMod.xpToGive += 50;
                }
                if (Main.damageToggle)
                {
                    if (GUI.Button(btn.BtnRect(4, true, "playermod"), "D A M A G E   P E R   L V L ( O N ) : " + PlayerMod.damagePerLvl.ToString(), OnStyle))
                    {
                        Main.damageToggle = false;
                    }
                }
                else if (GUI.Button(btn.BtnRect(4, true, "playermod"), "D A M A G E   P E R   L V L ( O F F ) : " + PlayerMod.damagePerLvl.ToString(), OffStyle))
                {
                    Main.damageToggle = true;
                }
                if (GUI.Button(new Rect(x + widthSize - 80, y + Main.PlayerModBtnY, 40, 40), "-", OffStyle))
                {
                    if (PlayerMod.damagePerLvl > 0)
                        PlayerMod.damagePerLvl -= 10;
                }
                if (GUI.Button(new Rect(x + widthSize - 35, y + Main.PlayerModBtnY, 40, 40), "+", OffStyle))
                {
                    if (PlayerMod.damagePerLvl >= 0)
                        PlayerMod.damagePerLvl += 10;
                }
                if (Main.critToggle)
                {
                    if (GUI.Button(btn.BtnRect(5, true, "playermod"), "C R I T   P E R   L V L ( O N ) : " + PlayerMod.CritPerLvl.ToString(), OnStyle))
                    {
                        Main.critToggle = false;
                    }
                }
                else if (GUI.Button(btn.BtnRect(5, true, "playermod"), "C R I T   P E R   L V L ( O F F ) : " + PlayerMod.CritPerLvl.ToString(), OffStyle))
                {
                    Main.critToggle = true;
                }
                if (GUI.Button(new Rect(x + widthSize - 80, y + Main.PlayerModBtnY, 40, 40), "-", OffStyle))
                {
                    if (PlayerMod.CritPerLvl > 0)
                        PlayerMod.CritPerLvl -= 1;
                }
                if (GUI.Button(new Rect(x + widthSize - 35, y + Main.PlayerModBtnY, 40, 40), "+", OffStyle))
                {
                    if (PlayerMod.CritPerLvl >= 0)
                        PlayerMod.CritPerLvl += 1;
                }
                if (Main.attackSpeedToggle)
                {
                    if (GUI.Button(btn.BtnRect(6, true, "playermod"), "A T T A C K   S P E E D ( O N ) : " + PlayerMod.attackSpeed.ToString(), OnStyle))
                    {
                        Main.attackSpeedToggle = false;
                    }
                }
                else if (GUI.Button(btn.BtnRect(6, true, "playermod"), "A T T A C K   S P E E D ( O F F ) : " + PlayerMod.attackSpeed.ToString(), OffStyle))
                {
                    Main.attackSpeedToggle = true;
                }
                if (GUI.Button(new Rect(x + widthSize - 80, y + Main.PlayerModBtnY, 40, 40), "-", OffStyle))
                {
                    if (PlayerMod.attackSpeed > 0)
                        PlayerMod.attackSpeed -= 1;
                }
                if (GUI.Button(new Rect(x + widthSize - 35, y + Main.PlayerModBtnY, 40, 40), "+", OffStyle))
                {
                    if (PlayerMod.attackSpeed >= 0)
                        PlayerMod.attackSpeed += 1;
                }
                if (Main.armorToggle)
                {
                    if (GUI.Button(btn.BtnRect(7, true, "playermod"), "A R M O R ( O N ) : " + PlayerMod.armor.ToString(), OnStyle))
                    {
                        Main.armorToggle = false;
                    }
                }
                else if (GUI.Button(btn.BtnRect(7, true, "playermod"), "A R M O R ( O F F ) : " + PlayerMod.armor.ToString(), OffStyle))
                {
                    Main.armorToggle = true;
                }
                if (GUI.Button(new Rect(x + widthSize - 80, y + Main.PlayerModBtnY, 40, 40), "-", OffStyle))
                {
                    if (PlayerMod.armor > 0)
                        PlayerMod.armor -= 10;
                }
                if (GUI.Button(new Rect(x + widthSize - 35, y + Main.PlayerModBtnY, 40, 40), "+", OffStyle))
                {
                    if (PlayerMod.armor >= 0)
                        PlayerMod.armor += 10;
                }
                if (Main.moveSpeedToggle)
                {
                    if (GUI.Button(btn.BtnRect(8, true, "playermod"), "M O V E   S P E E D ( O N ) : " + PlayerMod.movespeed.ToString(), OnStyle))
                    {
                        Main.moveSpeedToggle = false;
                    }
                }
                else if (GUI.Button(btn.BtnRect(8, true, "playermod"), "M O V E   S P E E D ( O F F ) : " + PlayerMod.movespeed.ToString(), OffStyle))
                {
                    Main.moveSpeedToggle = true;
                }
                if (GUI.Button(new Rect(x + widthSize - 80, y + Main.PlayerModBtnY, 40, 40), "-", OffStyle))
                {
                    if (PlayerMod.movespeed > 7)
                        PlayerMod.movespeed -= 10;
                }
                if (GUI.Button(new Rect(x + widthSize - 35, y + Main.PlayerModBtnY, 40, 40), "+", OffStyle))
                {
                    if (PlayerMod.movespeed >= 7)
                        PlayerMod.movespeed += 10;
                }
                if (Main._CharacterToggle)
                {
                    if (GUI.Button(btn.BtnRect(9, false, "playermod"), "C H A N G E   C H A R A C T E R : ON", OnStyle))
                    {
                        Main._CharacterToggle = false;
                    }
                }
                else if (GUI.Button(btn.BtnRect(9, false, "playermod"), "C H A N G E   C H A R A C T E R : OFF", OffStyle))
                {
                    Main._CharacterToggle = true;
                }
                if (Main._isStatMenuOpen)
                {
                    if (GUI.Button(btn.BtnRect(10, false, "playermod"), "S H O W   S T A T S : O N", OnStyle))
                    {
                        Main._isStatMenuOpen = false;
                    }
                }
                else if (GUI.Button(btn.BtnRect(10, false, "playermod"), "S H O W   S T A T S : O F F", OffStyle))
                {
                    Main._isStatMenuOpen = true;
                }
                if (Main._isBuffMenuOpen)
                {
                    if (GUI.Button(btn.BtnRect(11, false, "playermod"), "G I V E   B U F F   M E N U : O N", OnStyle))
                    {
                        Main._isBuffMenuOpen = false;
                    }
                }
                else if (GUI.Button(btn.BtnRect(11, false, "playermod"), "G I V E   B U F F   M E N U : O F F", OffStyle))
                {
                    Main._isBuffMenuOpen = true;
                }
                if (GUI.Button(btn.BtnRect(12, false, "playermod"), "R E M O V E   A L L   B U F F S", buttonStyle))
                {
                    PlayerMod.RemoveAllBuffs();
                }
                if (Main.aimBot)
                {
                    if (GUI.Button(btn.BtnRect(13, false, "playermod"), "A I M B O T : O N", OnStyle))
                    {
                        EntityStates.FireNailgun.spreadPitchScale = 0.5f;
                        EntityStates.FireNailgun.spreadYawScale = 1f;
                        EntityStates.FireNailgun.spreadBloomValue = 0.2f;
                        Main.aimBot = false;
                    }
                }
                else if (!Main.aimBot)
                {
                    if (GUI.Button(btn.BtnRect(13, false, "playermod"), "A I M B O T : O F F", OffStyle))
                    {
                        EntityStates.FireNailgun.spreadPitchScale = 0;
                        EntityStates.FireNailgun.spreadYawScale = 0;
                        EntityStates.FireNailgun.spreadBloomValue = 0;
                        Main.aimBot = true;
                    }
                }
                if (Main.alwaysSprint)
                {
                    if (GUI.Button(btn.BtnRect(14, false, "playermod"), "A L W A Y S   S P R I N T : O N", OnStyle))
                    {
                        Main.alwaysSprint = false;
                    }
                }
                else if (!Main.alwaysSprint)
                {
                    if (GUI.Button(btn.BtnRect(14, false, "playermod"), "A L W A Y S   S P R I N T : O F F", OffStyle))
                    {
                        Main.alwaysSprint = true;
                    }
                }
                if (Main.FlightToggle)
                {
                    if (GUI.Button(btn.BtnRect(15, false, "playermod"), "F L I G H T : O N", OnStyle))
                    {
                        if (PlayerMod.GetCurrentCharacter().ToString() != "Loader")
                        {
                            Main.LocalPlayerBody.bodyFlags &= CharacterBody.BodyFlags.None;
                        }
                        Main.FlightToggle = false;
                    }
                }
                else if (GUI.Button(btn.BtnRect(15, false, "playermod"), "F L I G H T : O F F", OffStyle))
                {
                    Main.FlightToggle = true;
                }
                if (Main.godToggle)
                {
                    if (GUI.Button(btn.BtnRect(16, false, "playermod"), "G O D   M O D E : O N", OnStyle))
                    {
                        Main.godToggle = false;
                    }
                }
                else if (GUI.Button(btn.BtnRect(16, false, "playermod"), "G O D   M O D E : O F F", OffStyle))
                {
                    Main.godToggle = true;
                }
                if (Main.skillToggle)
                {
                    if (GUI.Button(btn.BtnRect(17, false, "playermod"), "I N F I N I T E   S K I L L S : O N", OnStyle))
                    {
                        Main.skillToggle = false;
                    }
                }
                else if (GUI.Button(btn.BtnRect(17, false, "playermod"), "I N F I N I T E   S K I L L S : O F F", OffStyle))
                {
                    Main.skillToggle = true;
                }
                if (GUI.Button(btn.BtnRect(18, false, "playermod"), "U N L O C K   A L L", buttonStyle))
                {
                    PlayerMod.UnlockAll();
                }
            }
        }

        public static void DrawItemManagementMenu(float x, float y, float widthSize, int mulY, GUIStyle BGstyle, GUIStyle buttonStyle, GUIStyle OnStyle, GUIStyle OffStyle, GUIStyle LabelStyle, GUIStyle Highlighted)
        {
            GUI.Box(new Rect(x + 0f, y + 0f, widthSize + 10, 50f + 45 * mulY), "", BGstyle);
            GUI.Label(new Rect(x + 5f, y + 5f, widthSize + 5, 95f), "I T E M   M A N A G E M E N T   M E N U", LabelStyle);

            if (Main.navigationToggle && Navigation.MenuIndex == 2)
            {
                switch (Navigation.IntraMenuIndex)
                {
                    case 0:
                        {
                            if (GUI.Button(btn.BtnRect(1, true, "itemmanager"), "G I V E   A L L   I T E M S : " + ItemManager.allItemsQuantity.ToString(), Highlighted))
                            {
                                ItemManager.GiveAllItems();
                            }
                            if (GUI.Button(new Rect(x + widthSize - 80, y + Main.ItemManagerBtnY, 40, 40), "-", OffStyle))
                            {
                                if (ItemManager.allItemsQuantity > 1)
                                    ItemManager.allItemsQuantity -= 1;
                            }
                            if (GUI.Button(new Rect(x + widthSize - 35, y + Main.ItemManagerBtnY, 40, 40), "+", OffStyle))
                            {
                                if (ItemManager.allItemsQuantity >= 1)
                                    ItemManager.allItemsQuantity += 1;
                            }
                            if (GUI.Button(btn.BtnRect(2, true, "itemmanager"), "R O L L   I T E M S : " + ItemManager.itemsToRoll.ToString(), buttonStyle))
                            {
                                ItemManager.RollItems(ItemManager.itemsToRoll.ToString());
                            }
                            if (GUI.Button(new Rect(x + widthSize - 80, y + Main.ItemManagerBtnY, 40, 40), "-", OffStyle))
                            {
                                if (ItemManager.itemsToRoll > 5)
                                    ItemManager.itemsToRoll -= 5;
                            }
                            if (GUI.Button(new Rect(x + widthSize - 35, y + Main.ItemManagerBtnY, 40, 40), "+", OffStyle))
                            {
                                if (ItemManager.itemsToRoll >= 5)
                                    ItemManager.itemsToRoll += 5;
                            }
                            if (Main._isItemSpawnMenuOpen)
                            {
                                Main._isEquipmentSpawnMenuOpen = false;
                                if (GUI.Button(btn.BtnRect(3, false, "itemmanager"), "I T E M   S P A W N   M E N U : O N", OnStyle))
                                {
                                    Main._isItemSpawnMenuOpen = false;
                                }
                            }
                            else if (GUI.Button(btn.BtnRect(3, false, "itemmanager"), "I T E M   S P A W N   M E N U : O F F", OffStyle))
                            {
                                Main._isItemSpawnMenuOpen = true;
                            }
                            if (Main._isEquipmentSpawnMenuOpen)
                            {
                                Main._isItemSpawnMenuOpen = false;
                                if (GUI.Button(btn.BtnRect(4, false, "itemmanager"), "E Q U I P M E N T   S P A W N   M E N U : O N", OnStyle))
                                {
                                    Main._isEquipmentSpawnMenuOpen = false;
                                }
                            }
                            else if (GUI.Button(btn.BtnRect(4, false, "itemmanager"), "E Q U I P M E N T   S P A W N   M E N U : O F F", OffStyle))
                            {
                                Main._isEquipmentSpawnMenuOpen = true;
                            }
                            if (ItemManager.isDropItemForAll)
                            {
                                if (GUI.Button(btn.BtnRect(5, false, "itemmanager"), "D R O P   I T E M S / E Q U I P M E N T : O N", OnStyle))
                                {
                                    ItemManager.isDropItemForAll = false;
                                }
                            }
                            else if (GUI.Button(btn.BtnRect(5, false, "itemmanager"), "D R O P   I T E M S / E Q U I P M E N T : O F F", OffStyle))
                            {
                                ItemManager.isDropItemForAll = true;
                                ItemManager.isDropItemFromInventory = false;
                            }
                            if (ItemManager.isDropItemFromInventory)
                            {
                                if (GUI.Button(btn.BtnRect(6, false, "itemmanager"), "D R O P   F R O M   I N V E N T O R Y : O N", OnStyle))
                                {
                                    ItemManager.isDropItemFromInventory = false;
                                }
                            }
                            else if (GUI.Button(btn.BtnRect(6, false, "itemmanager"), "D R O P   F R O M   I N V E N T O R Y : O F F", OffStyle))
                            {
                                ItemManager.isDropItemFromInventory = true;
                                ItemManager.isDropItemForAll = false;
                            }
                            if (Main.noEquipmentCooldown)
                            {
                                if (GUI.Button(btn.BtnRect(7, false, "itemmanager"), "I N F I N I T E   E Q U I P M E N T : O N", OnStyle))
                                {
                                    Main.noEquipmentCooldown = false;
                                }
                            }
                            else if (GUI.Button(btn.BtnRect(7, false, "itemmanager"), "I N F I N I T E   E Q U I P M E N T : O F F", OffStyle))
                            {
                                Main.noEquipmentCooldown = true;
                            }
                            if (GUI.Button(btn.BtnRect(8, false, "itemmanager"), "S T A C K   I N V E N T O R Y", buttonStyle))
                            {
                                ItemManager.StackInventory();
                            }
                            if (GUI.Button(btn.BtnRect(9, false, "itemmanager"), "C L E A R   I N V E N T O R Y", buttonStyle))
                            {
                                ItemManager.ClearInventory();
                            }
                            break;
                        }

                    case 1:
                        {
                            if (GUI.Button(btn.BtnRect(1, true, "itemmanager"), "G I V E   A L L   I T E M S : " + ItemManager.allItemsQuantity.ToString(), buttonStyle))
                            {
                                ItemManager.GiveAllItems();
                            }
                            if (GUI.Button(new Rect(x + widthSize - 80, y + Main.ItemManagerBtnY, 40, 40), "-", OffStyle))
                            {
                                if (ItemManager.allItemsQuantity > 1)
                                    ItemManager.allItemsQuantity -= 1;
                            }
                            if (GUI.Button(new Rect(x + widthSize - 35, y + Main.ItemManagerBtnY, 40, 40), "+", OffStyle))
                            {
                                if (ItemManager.allItemsQuantity >= 1)
                                    ItemManager.allItemsQuantity += 1;
                            }
                            if (GUI.Button(btn.BtnRect(2, true, "itemmanager"), "R O L L   I T E M S : " + ItemManager.itemsToRoll.ToString(), Highlighted))
                            {
                                ItemManager.RollItems(ItemManager.itemsToRoll.ToString());
                            }
                            if (GUI.Button(new Rect(x + widthSize - 80, y + Main.ItemManagerBtnY, 40, 40), "-", OffStyle))
                            {
                                if (ItemManager.itemsToRoll > 5)
                                    ItemManager.itemsToRoll -= 5;
                            }
                            if (GUI.Button(new Rect(x + widthSize - 35, y + Main.ItemManagerBtnY, 40, 40), "+", OffStyle))
                            {
                                if (ItemManager.itemsToRoll >= 5)
                                    ItemManager.itemsToRoll += 5;
                            }
                            if (Main._isItemSpawnMenuOpen)
                            {
                                Main._isEquipmentSpawnMenuOpen = false;
                                if (GUI.Button(btn.BtnRect(3, false, "itemmanager"), "I T E M   S P A W N   M E N U : O N", OnStyle))
                                {
                                    Main._isItemSpawnMenuOpen = false;
                                }
                            }
                            else if (GUI.Button(btn.BtnRect(3, false, "itemmanager"), "I T E M   S P A W N   M E N U : O F F", OffStyle))
                            {
                                Main._isItemSpawnMenuOpen = true;
                            }
                            if (Main._isEquipmentSpawnMenuOpen)
                            {
                                Main._isItemSpawnMenuOpen = false;
                                if (GUI.Button(btn.BtnRect(4, false, "itemmanager"), "E Q U I P M E N T   S P A W N   M E N U : O N", OnStyle))
                                {
                                    Main._isEquipmentSpawnMenuOpen = false;
                                }
                            }
                            else if (GUI.Button(btn.BtnRect(4, false, "itemmanager"), "E Q U I P M E N T   S P A W N   M E N U : O F F", OffStyle))
                            {
                                Main._isEquipmentSpawnMenuOpen = true;
                            }
                            if (ItemManager.isDropItemForAll)
                            {
                                if (GUI.Button(btn.BtnRect(5, false, "itemmanager"), "D R O P   I T E M S / E Q U I P M E N T : O N", OnStyle))
                                {
                                    ItemManager.isDropItemForAll = false;
                                }
                            }
                            else if (GUI.Button(btn.BtnRect(5, false, "itemmanager"), "D R O P   I T E M S / E Q U I P M E N T : O F F", OffStyle))
                            {
                                ItemManager.isDropItemForAll = true;
                                ItemManager.isDropItemFromInventory = false;
                            }
                            if (ItemManager.isDropItemFromInventory)
                            {
                                if (GUI.Button(btn.BtnRect(6, false, "itemmanager"), "D R O P   F R O M   I N V E N T O R Y : O N", OnStyle))
                                {
                                    ItemManager.isDropItemFromInventory = false;
                                }
                            }
                            else if (GUI.Button(btn.BtnRect(6, false, "itemmanager"), "D R O P   F R O M   I N V E N T O R Y : O F F", OffStyle))
                            {
                                ItemManager.isDropItemFromInventory = true;
                                ItemManager.isDropItemForAll = false;
                            }
                            if (Main.noEquipmentCooldown)
                            {
                                if (GUI.Button(btn.BtnRect(7, false, "itemmanager"), "I N F I N I T E   E Q U I P M E N T : O N", OnStyle))
                                {
                                    Main.noEquipmentCooldown = false;
                                }
                            }
                            else if (GUI.Button(btn.BtnRect(7, false, "itemmanager"), "I N F I N I T E   E Q U I P M E N T : O F F", OffStyle))
                            {
                                Main.noEquipmentCooldown = true;
                            }
                            if (GUI.Button(btn.BtnRect(8, false, "itemmanager"), "S T A C K   I N V E N T O R Y", buttonStyle))
                            {
                                ItemManager.StackInventory();
                            }
                            if (GUI.Button(btn.BtnRect(9, false, "itemmanager"), "C L E A R   I N V E N T O R Y", buttonStyle))
                            {
                                ItemManager.ClearInventory();
                            }
                            break;
                        }

                    case 2:
                        {
                            if (GUI.Button(btn.BtnRect(1, true, "itemmanager"), "G I V E   A L L   I T E M S : " + ItemManager.allItemsQuantity.ToString(), buttonStyle))
                            {
                                ItemManager.GiveAllItems();
                            }
                            if (GUI.Button(new Rect(x + widthSize - 80, y + Main.ItemManagerBtnY, 40, 40), "-", OffStyle))
                            {
                                if (ItemManager.allItemsQuantity > 1)
                                    ItemManager.allItemsQuantity -= 1;
                            }
                            if (GUI.Button(new Rect(x + widthSize - 35, y + Main.ItemManagerBtnY, 40, 40), "+", OffStyle))
                            {
                                if (ItemManager.allItemsQuantity >= 1)
                                    ItemManager.allItemsQuantity += 1;
                            }
                            if (GUI.Button(btn.BtnRect(2, true, "itemmanager"), "R O L L   I T E M S : " + ItemManager.itemsToRoll.ToString(), buttonStyle))
                            {
                                ItemManager.RollItems(ItemManager.itemsToRoll.ToString());
                            }
                            if (GUI.Button(new Rect(x + widthSize - 80, y + Main.ItemManagerBtnY, 40, 40), "-", OffStyle))
                            {
                                if (ItemManager.itemsToRoll > 5)
                                    ItemManager.itemsToRoll -= 5;
                            }
                            if (GUI.Button(new Rect(x + widthSize - 35, y + Main.ItemManagerBtnY, 40, 40), "+", OffStyle))
                            {
                                if (ItemManager.itemsToRoll >= 5)
                                    ItemManager.itemsToRoll += 5;
                            }
                            if (Main._isItemSpawnMenuOpen)
                            {
                                Main._isEquipmentSpawnMenuOpen = false;
                                if (GUI.Button(btn.BtnRect(3, false, "itemmanager"), "I T E M   S P A W N   M E N U : O N", Highlighted))
                                {
                                    Main._isItemSpawnMenuOpen = false;
                                }
                            }
                            else if (GUI.Button(btn.BtnRect(3, false, "itemmanager"), "I T E M   S P A W N   M E N U : O F F", Highlighted))
                            {
                                Main._isItemSpawnMenuOpen = true;
                            }
                            if (Main._isEquipmentSpawnMenuOpen)
                            {
                                Main._isItemSpawnMenuOpen = false;
                                if (GUI.Button(btn.BtnRect(4, false, "itemmanager"), "E Q U I P M E N T   S P A W N   M E N U : O N", OnStyle))
                                {
                                    Main._isEquipmentSpawnMenuOpen = false;
                                }
                            }
                            else if (GUI.Button(btn.BtnRect(4, false, "itemmanager"), "E Q U I P M E N T   S P A W N   M E N U : O F F", OffStyle))
                            {
                                Main._isEquipmentSpawnMenuOpen = true;
                            }
                            if (ItemManager.isDropItemForAll)
                            {
                                if (GUI.Button(btn.BtnRect(5, false, "itemmanager"), "D R O P   I T E M S / E Q U I P M E N T : O N", OnStyle))
                                {
                                    ItemManager.isDropItemForAll = false;
                                }
                            }
                            else if (GUI.Button(btn.BtnRect(5, false, "itemmanager"), "D R O P   I T E M S / E Q U I P M E N T : O F F", OffStyle))
                            {
                                ItemManager.isDropItemForAll = true;
                                ItemManager.isDropItemFromInventory = false;
                            }
                            if (ItemManager.isDropItemFromInventory)
                            {
                                if (GUI.Button(btn.BtnRect(6, false, "itemmanager"), "D R O P   F R O M   I N V E N T O R Y : O N", OnStyle))
                                {
                                    ItemManager.isDropItemFromInventory = false;
                                }
                            }
                            else if (GUI.Button(btn.BtnRect(6, false, "itemmanager"), "D R O P   F R O M   I N V E N T O R Y : O F F", OffStyle))
                            {
                                ItemManager.isDropItemFromInventory = true;
                                ItemManager.isDropItemForAll = false;
                            }
                            if (Main.noEquipmentCooldown)
                            {
                                if (GUI.Button(btn.BtnRect(7, false, "itemmanager"), "I N F I N I T E   E Q U I P M E N T : O N", OnStyle))
                                {
                                    Main.noEquipmentCooldown = false;
                                }
                            }
                            else if (GUI.Button(btn.BtnRect(7, false, "itemmanager"), "I N F I N I T E   E Q U I P M E N T : O F F", OffStyle))
                            {
                                Main.noEquipmentCooldown = true;
                            }
                            if (GUI.Button(btn.BtnRect(8, false, "itemmanager"), "S T A C K   I N V E N T O R Y", buttonStyle))
                            {
                                ItemManager.StackInventory();
                            }
                            if (GUI.Button(btn.BtnRect(9, false, "itemmanager"), "C L E A R   I N V E N T O R Y", buttonStyle))
                            {
                                ItemManager.ClearInventory();
                            }
                            break;
                        }

                    case 3:
                        {
                            if (GUI.Button(btn.BtnRect(1, true, "itemmanager"), "G I V E   A L L   I T E M S : " + ItemManager.allItemsQuantity.ToString(), buttonStyle))
                            {
                                ItemManager.GiveAllItems();
                            }
                            if (GUI.Button(new Rect(x + widthSize - 80, y + Main.ItemManagerBtnY, 40, 40), "-", OffStyle))
                            {
                                if (ItemManager.allItemsQuantity > 1)
                                    ItemManager.allItemsQuantity -= 1;
                            }
                            if (GUI.Button(new Rect(x + widthSize - 35, y + Main.ItemManagerBtnY, 40, 40), "+", OffStyle))
                            {
                                if (ItemManager.allItemsQuantity >= 1)
                                    ItemManager.allItemsQuantity += 1;
                            }
                            if (GUI.Button(btn.BtnRect(2, true, "itemmanager"), "R O L L   I T E M S : " + ItemManager.itemsToRoll.ToString(), buttonStyle))
                            {
                                ItemManager.RollItems(ItemManager.itemsToRoll.ToString());
                            }
                            if (GUI.Button(new Rect(x + widthSize - 80, y + Main.ItemManagerBtnY, 40, 40), "-", OffStyle))
                            {
                                if (ItemManager.itemsToRoll > 5)
                                    ItemManager.itemsToRoll -= 5;
                            }
                            if (GUI.Button(new Rect(x + widthSize - 35, y + Main.ItemManagerBtnY, 40, 40), "+", OffStyle))
                            {
                                if (ItemManager.itemsToRoll >= 5)
                                    ItemManager.itemsToRoll += 5;
                            }
                            if (Main._isItemSpawnMenuOpen)
                            {
                                Main._isEquipmentSpawnMenuOpen = false;
                                if (GUI.Button(btn.BtnRect(3, false, "itemmanager"), "I T E M   S P A W N   M E N U : O N", OnStyle))
                                {
                                    Main._isItemSpawnMenuOpen = false;
                                }
                            }
                            else if (GUI.Button(btn.BtnRect(3, false, "itemmanager"), "I T E M   S P A W N   M E N U : O F F", OffStyle))
                            {
                                Main._isItemSpawnMenuOpen = true;
                            }
                            if (Main._isEquipmentSpawnMenuOpen)
                            {
                                Main._isItemSpawnMenuOpen = false;
                                if (GUI.Button(btn.BtnRect(4, false, "itemmanager"), "E Q U I P M E N T   S P A W N   M E N U : O N", Highlighted))
                                {
                                    Main._isEquipmentSpawnMenuOpen = false;
                                }
                            }
                            else if (GUI.Button(btn.BtnRect(4, false, "itemmanager"), "E Q U I P M E N T   S P A W N   M E N U : O F F", Highlighted))
                            {
                                Main._isEquipmentSpawnMenuOpen = true;
                            }
                            if (ItemManager.isDropItemForAll)
                            {
                                if (GUI.Button(btn.BtnRect(5, false, "itemmanager"), "D R O P   I T E M S / E Q U I P M E N T : O N", OnStyle))
                                {
                                    ItemManager.isDropItemForAll = false;
                                }
                            }
                            else if (GUI.Button(btn.BtnRect(5, false, "itemmanager"), "D R O P   I T E M S / E Q U I P M E N T : O F F", OffStyle))
                            {
                                ItemManager.isDropItemForAll = true;
                                ItemManager.isDropItemFromInventory = false;
                            }
                            if (ItemManager.isDropItemFromInventory)
                            {
                                if (GUI.Button(btn.BtnRect(6, false, "itemmanager"), "D R O P   F R O M   I N V E N T O R Y : O N", OnStyle))
                                {
                                    ItemManager.isDropItemFromInventory = false;
                                }
                            }
                            else if (GUI.Button(btn.BtnRect(6, false, "itemmanager"), "D R O P   F R O M   I N V E N T O R Y : O F F", OffStyle))
                            {
                                ItemManager.isDropItemFromInventory = true;
                                ItemManager.isDropItemForAll = false;
                            }
                            if (Main.noEquipmentCooldown)
                            {
                                if (GUI.Button(btn.BtnRect(7, false, "itemmanager"), "I N F I N I T E   E Q U I P M E N T : O N", OnStyle))
                                {
                                    Main.noEquipmentCooldown = false;
                                }
                            }
                            else if (GUI.Button(btn.BtnRect(7, false, "itemmanager"), "I N F I N I T E   E Q U I P M E N T : O F F", OffStyle))
                            {
                                Main.noEquipmentCooldown = true;
                            }
                            if (GUI.Button(btn.BtnRect(8, false, "itemmanager"), "S T A C K   I N V E N T O R Y", buttonStyle))
                            {
                                ItemManager.StackInventory();
                            }
                            if (GUI.Button(btn.BtnRect(9, false, "itemmanager"), "C L E A R   I N V E N T O R Y", buttonStyle))
                            {
                                ItemManager.ClearInventory();
                            }
                            break;
                        }

                    case 4:
                        {
                            if (GUI.Button(btn.BtnRect(1, true, "itemmanager"), "G I V E   A L L   I T E M S : " + ItemManager.allItemsQuantity.ToString(), buttonStyle))
                            {
                                ItemManager.GiveAllItems();
                            }
                            if (GUI.Button(new Rect(x + widthSize - 80, y + Main.ItemManagerBtnY, 40, 40), "-", OffStyle))
                            {
                                if (ItemManager.allItemsQuantity > 1)
                                    ItemManager.allItemsQuantity -= 1;
                            }
                            if (GUI.Button(new Rect(x + widthSize - 35, y + Main.ItemManagerBtnY, 40, 40), "+", OffStyle))
                            {
                                if (ItemManager.allItemsQuantity >= 1)
                                    ItemManager.allItemsQuantity += 1;
                            }
                            if (GUI.Button(btn.BtnRect(2, true, "itemmanager"), "R O L L   I T E M S : " + ItemManager.itemsToRoll.ToString(), buttonStyle))
                            {
                                ItemManager.RollItems(ItemManager.itemsToRoll.ToString());
                            }
                            if (GUI.Button(new Rect(x + widthSize - 80, y + Main.ItemManagerBtnY, 40, 40), "-", OffStyle))
                            {
                                if (ItemManager.itemsToRoll > 5)
                                    ItemManager.itemsToRoll -= 5;
                            }
                            if (GUI.Button(new Rect(x + widthSize - 35, y + Main.ItemManagerBtnY, 40, 40), "+", OffStyle))
                            {
                                if (ItemManager.itemsToRoll >= 5)
                                    ItemManager.itemsToRoll += 5;
                            }
                            if (Main._isItemSpawnMenuOpen)
                            {
                                Main._isEquipmentSpawnMenuOpen = false;
                                if (GUI.Button(btn.BtnRect(3, false, "itemmanager"), "I T E M   S P A W N   M E N U : O N", OnStyle))
                                {
                                    Main._isItemSpawnMenuOpen = false;
                                }
                            }
                            else if (GUI.Button(btn.BtnRect(3, false, "itemmanager"), "I T E M   S P A W N   M E N U : O F F", OffStyle))
                            {
                                Main._isItemSpawnMenuOpen = true;
                            }
                            if (Main._isEquipmentSpawnMenuOpen)
                            {
                                Main._isItemSpawnMenuOpen = false;
                                if (GUI.Button(btn.BtnRect(4, false, "itemmanager"), "E Q U I P M E N T   S P A W N   M E N U : O N", OnStyle))
                                {
                                    Main._isEquipmentSpawnMenuOpen = false;
                                }
                            }
                            else if (GUI.Button(btn.BtnRect(4, false, "itemmanager"), "E Q U I P M E N T   S P A W N   M E N U : O F F", OffStyle))
                            {
                                Main._isEquipmentSpawnMenuOpen = true;
                            }
                            if (ItemManager.isDropItemForAll)
                            {
                                if (GUI.Button(btn.BtnRect(5, false, "itemmanager"), "D R O P   I T E M S / E Q U I P M E N T : O N", Highlighted))
                                {
                                    ItemManager.isDropItemForAll = false;
                                }
                            }
                            else if (GUI.Button(btn.BtnRect(5, false, "itemmanager"), "D R O P   I T E M S / E Q U I P M E N T : O F F", Highlighted))
                            {
                                ItemManager.isDropItemForAll = true;
                                ItemManager.isDropItemFromInventory = false;
                            }
                            if (ItemManager.isDropItemFromInventory)
                            {
                                if (GUI.Button(btn.BtnRect(6, false, "itemmanager"), "D R O P   F R O M   I N V E N T O R Y : O N", OnStyle))
                                {
                                    ItemManager.isDropItemFromInventory = false;
                                }
                            }
                            else if (GUI.Button(btn.BtnRect(6, false, "itemmanager"), "D R O P   F R O M   I N V E N T O R Y : O F F", OffStyle))
                            {
                                ItemManager.isDropItemFromInventory = true;
                                ItemManager.isDropItemForAll = false;
                            }
                            if (Main.noEquipmentCooldown)
                            {
                                if (GUI.Button(btn.BtnRect(7, false, "itemmanager"), "I N F I N I T E   E Q U I P M E N T : O N", OnStyle))
                                {
                                    Main.noEquipmentCooldown = false;
                                }
                            }
                            else if (GUI.Button(btn.BtnRect(7, false, "itemmanager"), "I N F I N I T E   E Q U I P M E N T : O F F", OffStyle))
                            {
                                Main.noEquipmentCooldown = true;
                            }
                            if (GUI.Button(btn.BtnRect(8, false, "itemmanager"), "S T A C K   I N V E N T O R Y", buttonStyle))
                            {
                                ItemManager.StackInventory();
                            }
                            if (GUI.Button(btn.BtnRect(9, false, "itemmanager"), "C L E A R   I N V E N T O R Y", buttonStyle))
                            {
                                ItemManager.ClearInventory();
                            }
                            break;
                        }

                    case 5:
                        {
                            if (GUI.Button(btn.BtnRect(1, true, "itemmanager"), "G I V E   A L L   I T E M S : " + ItemManager.allItemsQuantity.ToString(), buttonStyle))
                            {
                                ItemManager.GiveAllItems();
                            }
                            if (GUI.Button(new Rect(x + widthSize - 80, y + Main.ItemManagerBtnY, 40, 40), "-", OffStyle))
                            {
                                if (ItemManager.allItemsQuantity > 1)
                                    ItemManager.allItemsQuantity -= 1;
                            }
                            if (GUI.Button(new Rect(x + widthSize - 35, y + Main.ItemManagerBtnY, 40, 40), "+", OffStyle))
                            {
                                if (ItemManager.allItemsQuantity >= 1)
                                    ItemManager.allItemsQuantity += 1;
                            }
                            if (GUI.Button(btn.BtnRect(2, true, "itemmanager"), "R O L L   I T E M S : " + ItemManager.itemsToRoll.ToString(), buttonStyle))
                            {
                                ItemManager.RollItems(ItemManager.itemsToRoll.ToString());
                            }
                            if (GUI.Button(new Rect(x + widthSize - 80, y + Main.ItemManagerBtnY, 40, 40), "-", OffStyle))
                            {
                                if (ItemManager.itemsToRoll > 5)
                                    ItemManager.itemsToRoll -= 5;
                            }
                            if (GUI.Button(new Rect(x + widthSize - 35, y + Main.ItemManagerBtnY, 40, 40), "+", OffStyle))
                            {
                                if (ItemManager.itemsToRoll >= 5)
                                    ItemManager.itemsToRoll += 5;
                            }
                            if (Main._isItemSpawnMenuOpen)
                            {
                                Main._isEquipmentSpawnMenuOpen = false;
                                if (GUI.Button(btn.BtnRect(3, false, "itemmanager"), "I T E M   S P A W N   M E N U : O N", OnStyle))
                                {
                                    Main._isItemSpawnMenuOpen = false;
                                }
                            }
                            else if (GUI.Button(btn.BtnRect(3, false, "itemmanager"), "I T E M   S P A W N   M E N U : O F F", OffStyle))
                            {
                                Main._isItemSpawnMenuOpen = true;
                            }
                            if (Main._isEquipmentSpawnMenuOpen)
                            {
                                Main._isItemSpawnMenuOpen = false;
                                if (GUI.Button(btn.BtnRect(4, false, "itemmanager"), "E Q U I P M E N T   S P A W N   M E N U : O N", OnStyle))
                                {
                                    Main._isEquipmentSpawnMenuOpen = false;
                                }
                            }
                            else if (GUI.Button(btn.BtnRect(4, false, "itemmanager"), "E Q U I P M E N T   S P A W N   M E N U : O F F", OffStyle))
                            {
                                Main._isEquipmentSpawnMenuOpen = true;
                            }
                            if (ItemManager.isDropItemForAll)
                            {
                                if (GUI.Button(btn.BtnRect(5, false, "itemmanager"), "D R O P   I T E M S / E Q U I P M E N T : O N", OnStyle))
                                {
                                    ItemManager.isDropItemForAll = false;
                                }
                            }
                            else if (GUI.Button(btn.BtnRect(5, false, "itemmanager"), "D R O P   I T E M S / E Q U I P M E N T : O F F", OffStyle))
                            {
                                ItemManager.isDropItemForAll = true;
                                ItemManager.isDropItemFromInventory = false;
                            }
                            if (ItemManager.isDropItemFromInventory)
                            {
                                if (GUI.Button(btn.BtnRect(6, false, "itemmanager"), "D R O P   F R O M   I N V E N T O R Y : O N", Highlighted))
                                {
                                    ItemManager.isDropItemFromInventory = false;
                                }
                            }
                            else if (GUI.Button(btn.BtnRect(6, false, "itemmanager"), "D R O P   F R O M   I N V E N T O R Y : O F F", Highlighted))
                            {
                                ItemManager.isDropItemFromInventory = true;
                                ItemManager.isDropItemForAll = false;
                            }
                            if (Main.noEquipmentCooldown)
                            {
                                if (GUI.Button(btn.BtnRect(7, false, "itemmanager"), "I N F I N I T E   E Q U I P M E N T : O N", OnStyle))
                                {
                                    Main.noEquipmentCooldown = false;
                                }
                            }
                            else if (GUI.Button(btn.BtnRect(7, false, "itemmanager"), "I N F I N I T E   E Q U I P M E N T : O F F", OffStyle))
                            {
                                Main.noEquipmentCooldown = true;
                            }
                            if (GUI.Button(btn.BtnRect(8, false, "itemmanager"), "S T A C K   I N V E N T O R Y", buttonStyle))
                            {
                                ItemManager.StackInventory();
                            }
                            if (GUI.Button(btn.BtnRect(9, false, "itemmanager"), "C L E A R   I N V E N T O R Y", buttonStyle))
                            {
                                ItemManager.ClearInventory();
                            }
                            break;
                        }

                    case 6:
                        {
                            if (GUI.Button(btn.BtnRect(1, true, "itemmanager"), "G I V E   A L L   I T E M S : " + ItemManager.allItemsQuantity.ToString(), buttonStyle))
                            {
                                ItemManager.GiveAllItems();
                            }
                            if (GUI.Button(new Rect(x + widthSize - 80, y + Main.ItemManagerBtnY, 40, 40), "-", OffStyle))
                            {
                                if (ItemManager.allItemsQuantity > 1)
                                    ItemManager.allItemsQuantity -= 1;
                            }
                            if (GUI.Button(new Rect(x + widthSize - 35, y + Main.ItemManagerBtnY, 40, 40), "+", OffStyle))
                            {
                                if (ItemManager.allItemsQuantity >= 1)
                                    ItemManager.allItemsQuantity += 1;
                            }
                            if (GUI.Button(btn.BtnRect(2, true, "itemmanager"), "R O L L   I T E M S : " + ItemManager.itemsToRoll.ToString(), buttonStyle))
                            {
                                ItemManager.RollItems(ItemManager.itemsToRoll.ToString());
                            }
                            if (GUI.Button(new Rect(x + widthSize - 80, y + Main.ItemManagerBtnY, 40, 40), "-", OffStyle))
                            {
                                if (ItemManager.itemsToRoll > 5)
                                    ItemManager.itemsToRoll -= 5;
                            }
                            if (GUI.Button(new Rect(x + widthSize - 35, y + Main.ItemManagerBtnY, 40, 40), "+", OffStyle))
                            {
                                if (ItemManager.itemsToRoll >= 5)
                                    ItemManager.itemsToRoll += 5;
                            }
                            if (Main._isItemSpawnMenuOpen)
                            {
                                Main._isEquipmentSpawnMenuOpen = false;
                                if (GUI.Button(btn.BtnRect(3, false, "itemmanager"), "I T E M   S P A W N   M E N U : O N", OnStyle))
                                {
                                    Main._isItemSpawnMenuOpen = false;
                                }
                            }
                            else if (GUI.Button(btn.BtnRect(3, false, "itemmanager"), "I T E M   S P A W N   M E N U : O F F", OffStyle))
                            {
                                Main._isItemSpawnMenuOpen = true;
                            }
                            if (Main._isEquipmentSpawnMenuOpen)
                            {
                                Main._isItemSpawnMenuOpen = false;
                                if (GUI.Button(btn.BtnRect(4, false, "itemmanager"), "E Q U I P M E N T   S P A W N   M E N U : O N", OnStyle))
                                {
                                    Main._isEquipmentSpawnMenuOpen = false;
                                }
                            }
                            else if (GUI.Button(btn.BtnRect(4, false, "itemmanager"), "E Q U I P M E N T   S P A W N   M E N U : O F F", OffStyle))
                            {
                                Main._isEquipmentSpawnMenuOpen = true;
                            }
                            if (ItemManager.isDropItemForAll)
                            {
                                if (GUI.Button(btn.BtnRect(5, false, "itemmanager"), "D R O P   I T E M S / E Q U I P M E N T : O N", OnStyle))
                                {
                                    ItemManager.isDropItemForAll = false;
                                }
                            }
                            else if (GUI.Button(btn.BtnRect(5, false, "itemmanager"), "D R O P   I T E M S / E Q U I P M E N T : O F F", OffStyle))
                            {
                                ItemManager.isDropItemForAll = true;
                                ItemManager.isDropItemFromInventory = false;
                            }
                            if (ItemManager.isDropItemFromInventory)
                            {
                                if (GUI.Button(btn.BtnRect(6, false, "itemmanager"), "D R O P   F R O M   I N V E N T O R Y : O N", OnStyle))
                                {
                                    ItemManager.isDropItemFromInventory = false;
                                }
                            }
                            else if (GUI.Button(btn.BtnRect(6, false, "itemmanager"), "D R O P   F R O M   I N V E N T O R Y : O F F", OffStyle))
                            {
                                ItemManager.isDropItemFromInventory = true;
                                ItemManager.isDropItemForAll = false;
                            }
                            if (Main.noEquipmentCooldown)
                            {
                                if (GUI.Button(btn.BtnRect(7, false, "itemmanager"), "I N F I N I T E   E Q U I P M E N T : O N", Highlighted))
                                {
                                    Main.noEquipmentCooldown = false;
                                }
                            }
                            else if (GUI.Button(btn.BtnRect(7, false, "itemmanager"), "I N F I N I T E   E Q U I P M E N T : O F F", Highlighted))
                            {
                                Main.noEquipmentCooldown = true;
                            }
                            if (GUI.Button(btn.BtnRect(8, false, "itemmanager"), "S T A C K   I N V E N T O R Y", buttonStyle))
                            {
                                ItemManager.StackInventory();
                            }
                            if (GUI.Button(btn.BtnRect(9, false, "itemmanager"), "C L E A R   I N V E N T O R Y", buttonStyle))
                            {
                                ItemManager.ClearInventory();
                            }
                            break;
                        }

                    case 7:
                        {
                            if (GUI.Button(btn.BtnRect(1, true, "itemmanager"), "G I V E   A L L   I T E M S : " + ItemManager.allItemsQuantity.ToString(), buttonStyle))
                            {
                                ItemManager.GiveAllItems();
                            }
                            if (GUI.Button(new Rect(x + widthSize - 80, y + Main.ItemManagerBtnY, 40, 40), "-", OffStyle))
                            {
                                if (ItemManager.allItemsQuantity > 1)
                                    ItemManager.allItemsQuantity -= 1;
                            }
                            if (GUI.Button(new Rect(x + widthSize - 35, y + Main.ItemManagerBtnY, 40, 40), "+", OffStyle))
                            {
                                if (ItemManager.allItemsQuantity >= 1)
                                    ItemManager.allItemsQuantity += 1;
                            }
                            if (GUI.Button(btn.BtnRect(2, true, "itemmanager"), "R O L L   I T E M S : " + ItemManager.itemsToRoll.ToString(), buttonStyle))
                            {
                                ItemManager.RollItems(ItemManager.itemsToRoll.ToString());
                            }
                            if (GUI.Button(new Rect(x + widthSize - 80, y + Main.ItemManagerBtnY, 40, 40), "-", OffStyle))
                            {
                                if (ItemManager.itemsToRoll > 5)
                                    ItemManager.itemsToRoll -= 5;
                            }
                            if (GUI.Button(new Rect(x + widthSize - 35, y + Main.ItemManagerBtnY, 40, 40), "+", OffStyle))
                            {
                                if (ItemManager.itemsToRoll >= 5)
                                    ItemManager.itemsToRoll += 5;
                            }
                            if (Main._isItemSpawnMenuOpen)
                            {
                                Main._isEquipmentSpawnMenuOpen = false;
                                if (GUI.Button(btn.BtnRect(3, false, "itemmanager"), "I T E M   S P A W N   M E N U : O N", OnStyle))
                                {
                                    Main._isItemSpawnMenuOpen = false;
                                }
                            }
                            else if (GUI.Button(btn.BtnRect(3, false, "itemmanager"), "I T E M   S P A W N   M E N U : O F F", OffStyle))
                            {
                                Main._isItemSpawnMenuOpen = true;
                            }
                            if (Main._isEquipmentSpawnMenuOpen)
                            {
                                Main._isItemSpawnMenuOpen = false;
                                if (GUI.Button(btn.BtnRect(4, false, "itemmanager"), "E Q U I P M E N T   S P A W N   M E N U : O N", OnStyle))
                                {
                                    Main._isEquipmentSpawnMenuOpen = false;
                                }
                            }
                            else if (GUI.Button(btn.BtnRect(4, false, "itemmanager"), "E Q U I P M E N T   S P A W N   M E N U : O F F", OffStyle))
                            {
                                Main._isEquipmentSpawnMenuOpen = true;
                            }
                            if (ItemManager.isDropItemForAll)
                            {
                                if (GUI.Button(btn.BtnRect(5, false, "itemmanager"), "D R O P   I T E M S / E Q U I P M E N T : O N", OnStyle))
                                {
                                    ItemManager.isDropItemForAll = false;
                                }
                            }
                            else if (GUI.Button(btn.BtnRect(5, false, "itemmanager"), "D R O P   I T E M S / E Q U I P M E N T : O F F", OffStyle))
                            {
                                ItemManager.isDropItemForAll = true;
                                ItemManager.isDropItemFromInventory = false;
                            }
                            if (ItemManager.isDropItemFromInventory)
                            {
                                if (GUI.Button(btn.BtnRect(6, false, "itemmanager"), "D R O P   F R O M   I N V E N T O R Y : O N", OnStyle))
                                {
                                    ItemManager.isDropItemFromInventory = false;
                                }
                            }
                            else if (GUI.Button(btn.BtnRect(6, false, "itemmanager"), "D R O P   F R O M   I N V E N T O R Y : O F F", OffStyle))
                            {
                                ItemManager.isDropItemFromInventory = true;
                                ItemManager.isDropItemForAll = false;
                            }
                            if (Main.noEquipmentCooldown)
                            {
                                if (GUI.Button(btn.BtnRect(7, false, "itemmanager"), "I N F I N I T E   E Q U I P M E N T : O N", OnStyle))
                                {
                                    Main.noEquipmentCooldown = false;
                                }
                            }
                            else if (GUI.Button(btn.BtnRect(7, false, "itemmanager"), "I N F I N I T E   E Q U I P M E N T : O F F", OffStyle))
                            {
                                Main.noEquipmentCooldown = true;
                            }
                            if (GUI.Button(btn.BtnRect(8, false, "itemmanager"), "S T A C K   I N V E N T O R Y", Highlighted))
                            {
                                ItemManager.StackInventory();
                            }
                            if (GUI.Button(btn.BtnRect(9, false, "itemmanager"), "C L E A R   I N V E N T O R Y", buttonStyle))
                            {
                                ItemManager.ClearInventory();
                            }
                            break;
                        }

                    case 8:
                        {
                            if (GUI.Button(btn.BtnRect(1, true, "itemmanager"), "G I V E   A L L   I T E M S : " + ItemManager.allItemsQuantity.ToString(), buttonStyle))
                            {
                                ItemManager.GiveAllItems();
                            }
                            if (GUI.Button(new Rect(x + widthSize - 80, y + Main.ItemManagerBtnY, 40, 40), "-", OffStyle))
                            {
                                if (ItemManager.allItemsQuantity > 1)
                                    ItemManager.allItemsQuantity -= 1;
                            }
                            if (GUI.Button(new Rect(x + widthSize - 35, y + Main.ItemManagerBtnY, 40, 40), "+", OffStyle))
                            {
                                if (ItemManager.allItemsQuantity >= 1)
                                    ItemManager.allItemsQuantity += 1;
                            }
                            if (GUI.Button(btn.BtnRect(2, true, "itemmanager"), "R O L L   I T E M S : " + ItemManager.itemsToRoll.ToString(), buttonStyle))
                            {
                                ItemManager.RollItems(ItemManager.itemsToRoll.ToString());
                            }
                            if (GUI.Button(new Rect(x + widthSize - 80, y + Main.ItemManagerBtnY, 40, 40), "-", OffStyle))
                            {
                                if (ItemManager.itemsToRoll > 5)
                                    ItemManager.itemsToRoll -= 5;
                            }
                            if (GUI.Button(new Rect(x + widthSize - 35, y + Main.ItemManagerBtnY, 40, 40), "+", OffStyle))
                            {
                                if (ItemManager.itemsToRoll >= 5)
                                    ItemManager.itemsToRoll += 5;
                            }
                            if (Main._isItemSpawnMenuOpen)
                            {
                                Main._isEquipmentSpawnMenuOpen = false;
                                if (GUI.Button(btn.BtnRect(3, false, "itemmanager"), "I T E M   S P A W N   M E N U : O N", OnStyle))
                                {
                                    Main._isItemSpawnMenuOpen = false;
                                }
                            }
                            else if (GUI.Button(btn.BtnRect(3, false, "itemmanager"), "I T E M   S P A W N   M E N U : O F F", OffStyle))
                            {
                                Main._isItemSpawnMenuOpen = true;
                            }
                            if (Main._isEquipmentSpawnMenuOpen)
                            {
                                Main._isItemSpawnMenuOpen = false;
                                if (GUI.Button(btn.BtnRect(4, false, "itemmanager"), "E Q U I P M E N T   S P A W N   M E N U : O N", OnStyle))
                                {
                                    Main._isEquipmentSpawnMenuOpen = false;
                                }
                            }
                            else if (GUI.Button(btn.BtnRect(4, false, "itemmanager"), "E Q U I P M E N T   S P A W N   M E N U : O F F", OffStyle))
                            {
                                Main._isEquipmentSpawnMenuOpen = true;
                            }
                            if (ItemManager.isDropItemForAll)
                            {
                                if (GUI.Button(btn.BtnRect(5, false, "itemmanager"), "D R O P   I T E M S / E Q U I P M E N T : O N", OnStyle))
                                {
                                    ItemManager.isDropItemForAll = false;
                                }
                            }
                            else if (GUI.Button(btn.BtnRect(5, false, "itemmanager"), "D R O P   I T E M S / E Q U I P M E N T : O F F", OffStyle))
                            {
                                ItemManager.isDropItemForAll = true;
                                ItemManager.isDropItemFromInventory = false;
                            }
                            if (ItemManager.isDropItemFromInventory)
                            {
                                if (GUI.Button(btn.BtnRect(6, false, "itemmanager"), "D R O P   F R O M   I N V E N T O R Y : O N", OnStyle))
                                {
                                    ItemManager.isDropItemFromInventory = false;
                                }
                            }
                            else if (GUI.Button(btn.BtnRect(6, false, "itemmanager"), "D R O P   F R O M   I N V E N T O R Y : O F F", OffStyle))
                            {
                                ItemManager.isDropItemFromInventory = true;
                                ItemManager.isDropItemForAll = false;
                            }
                            if (Main.noEquipmentCooldown)
                            {
                                if (GUI.Button(btn.BtnRect(7, false, "itemmanager"), "I N F I N I T E   E Q U I P M E N T : O N", OnStyle))
                                {
                                    Main.noEquipmentCooldown = false;
                                }
                            }
                            else if (GUI.Button(btn.BtnRect(7, false, "itemmanager"), "I N F I N I T E   E Q U I P M E N T : O F F", OffStyle))
                            {
                                Main.noEquipmentCooldown = true;
                            }
                            if (GUI.Button(btn.BtnRect(8, false, "itemmanager"), "S T A C K   I N V E N T O R Y", buttonStyle))
                            {
                                ItemManager.StackInventory();
                            }
                            if (GUI.Button(btn.BtnRect(9, false, "itemmanager"), "C L E A R   I N V E N T O R Y", Highlighted))
                            {
                                ItemManager.ClearInventory();
                            }
                            break;
                        }

                    default:
                        {
                            if (Navigation.IntraMenuIndex > 8)
                            {
                                Navigation.IntraMenuIndex = 0;
                            }
                            if (Navigation.IntraMenuIndex < 0)
                            {
                                Navigation.IntraMenuIndex = 8;
                            }
                            break;
                        }
                }
            }
            else
            {
                if (GUI.Button(btn.BtnRect(1, true, "itemmanager"), "G I V E   A L L   I T E M S : " + ItemManager.allItemsQuantity.ToString(), buttonStyle))
                {
                    ItemManager.GiveAllItems();
                }
                if (GUI.Button(new Rect(x + widthSize - 80, y + Main.ItemManagerBtnY, 40, 40), "-", OffStyle))
                {
                    if (ItemManager.allItemsQuantity > 1)
                        ItemManager.allItemsQuantity -= 1;
                }
                if (GUI.Button(new Rect(x + widthSize - 35, y + Main.ItemManagerBtnY, 40, 40), "+", OffStyle))
                {
                    if (ItemManager.allItemsQuantity >= 1)
                        ItemManager.allItemsQuantity += 1;
                }
                if (GUI.Button(btn.BtnRect(2, true, "itemmanager"), "R O L L   I T E M S : " + ItemManager.itemsToRoll.ToString(), buttonStyle))
                {
                    ItemManager.RollItems(ItemManager.itemsToRoll.ToString());
                }
                if (GUI.Button(new Rect(x + widthSize - 80, y + Main.ItemManagerBtnY, 40, 40), "-", OffStyle))
                {
                    if (ItemManager.itemsToRoll > 5)
                        ItemManager.itemsToRoll -= 5;
                }
                if (GUI.Button(new Rect(x + widthSize - 35, y + Main.ItemManagerBtnY, 40, 40), "+", OffStyle))
                {
                    if (ItemManager.itemsToRoll >= 5)
                        ItemManager.itemsToRoll += 5;
                }
                if (Main._isItemSpawnMenuOpen)
                {
                    Main._isEquipmentSpawnMenuOpen = false;
                    if (GUI.Button(btn.BtnRect(3, false, "itemmanager"), "I T E M   S P A W N   M E N U : O N", OnStyle))
                    {
                        Main._isItemSpawnMenuOpen = false;
                    }
                }
                else if (GUI.Button(btn.BtnRect(3, false, "itemmanager"), "I T E M   S P A W N   M E N U : O F F", OffStyle))
                {
                    Main._isItemSpawnMenuOpen = true;
                }
                if (Main._isEquipmentSpawnMenuOpen)
                {
                    Main._isItemSpawnMenuOpen = false;
                    if (GUI.Button(btn.BtnRect(4, false, "itemmanager"), "E Q U I P M E N T   S P A W N   M E N U : O N", OnStyle))
                    {
                        Main._isEquipmentSpawnMenuOpen = false;
                    }
                }
                else if (GUI.Button(btn.BtnRect(4, false, "itemmanager"), "E Q U I P M E N T   S P A W N   M E N U : O F F", OffStyle))
                {
                    Main._isEquipmentSpawnMenuOpen = true;
                }
                if (ItemManager.isDropItemForAll)
                {
                    if (GUI.Button(btn.BtnRect(5, false, "itemmanager"), "D R O P   I T E M S / E Q U I P M E N T : O N", OnStyle))
                    {
                        ItemManager.isDropItemForAll = false;
                    }
                }
                else if (GUI.Button(btn.BtnRect(5, false, "itemmanager"), "D R O P   I T E M S / E Q U I P M E N T : O F F", OffStyle))
                {
                    ItemManager.isDropItemForAll = true;
                    ItemManager.isDropItemFromInventory = false;
                }
                if (ItemManager.isDropItemFromInventory)
                {
                    if (GUI.Button(btn.BtnRect(6, false, "itemmanager"), "D R O P   F R O M   I N V E N T O R Y : O N", OnStyle))
                    {
                        ItemManager.isDropItemFromInventory = false;
                    }
                }
                else if (GUI.Button(btn.BtnRect(6, false, "itemmanager"), "D R O P   F R O M   I N V E N T O R Y : O F F", OffStyle))
                {
                    ItemManager.isDropItemFromInventory = true;
                    ItemManager.isDropItemForAll = false;
                }
                if (Main.noEquipmentCooldown)
                {
                    if (GUI.Button(btn.BtnRect(7, false, "itemmanager"), "I N F I N I T E   E Q U I P M E N T : O N", OnStyle))
                    {
                        Main.noEquipmentCooldown = false;
                    }
                }
                else if (GUI.Button(btn.BtnRect(7, false, "itemmanager"), "I N F I N I T E   E Q U I P M E N T : O F F", OffStyle))
                {
                    Main.noEquipmentCooldown = true;
                }
                if (GUI.Button(btn.BtnRect(8, false, "itemmanager"), "S T A C K   I N V E N T O R Y", buttonStyle))
                {
                    ItemManager.StackInventory();
                }
                if (GUI.Button(btn.BtnRect(9, false, "itemmanager"), "C L E A R   I N V E N T O R Y", buttonStyle))
                {
                    ItemManager.ClearInventory();
                }
            }
        }
    }
}