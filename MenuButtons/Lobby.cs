using System;
using System.Collections.Generic;
using System.Linq;
using RoR2;
using UnityEngine;
using System.Text;
using System.Threading.Tasks;

namespace UmbraMenu.MenuButtons
{
    public class Lobby
    {
        public static string[] players = GetPlayers();

        private static readonly Menu currentMenu = (Menu)Utility.FindMenuById(7);

        public static void AddButtonsToMenu()
        {
            List<Buttons> buttons = new List<Buttons>();

            int numberOfPlayers = NumberOfPlayers();

            int j = 0;
            foreach (var ele in players)
            {
                Debug.Log($"{ele}: {j++}");
                Utility.WriteToLog("{ele}: {j++}");
            }

            if (UmbraMenu.characterCollected)
            {
                int buttonPlacement = 1;
                for (int i = 0; i < players.Length; i++)
                {
                    try
                    {
                        if (players[i] != null)
                        {
                            void ButtonAction() => KickButtonAction(players[i].ToString());
                            Button button = new Button(currentMenu, buttonPlacement, $"K I C K  <color=yellow>{players[i]}</color>", ButtonAction);
                            buttons.Add(button);
                            buttonPlacement++;
                        }
                    }
                    catch (NullReferenceException)
                    {
                        Debug.LogWarning("UmbraRoR: There is No Player Selected");
                    }
                }
            }
            currentMenu.buttons = buttons;
        }

        private static void KickButtonAction(string playerString)
        {
            Chat.AddMessage("<color=#42f5d4>Kicked Player </color>" + $"<color=yellow>{playerString}</color>");
            KickPlayer(GetNetUserFromString(playerString), UmbraMenu.LocalNetworkUser);
        }

        // More posibilities here using console.
        // Not added to ui yet.
        public static void BanPlayer(NetworkUser PlayerName, NetworkUser LocalNetworkUser)
        {
            RoR2.Console.instance.RunClientCmd(LocalNetworkUser, "ban_steam", new string[] { PlayerName.Network_id.steamId.ToString() });
        }

        public static void KickPlayer(NetworkUser PlayerName, NetworkUser LocalNetworkUser)
        {
            RoR2.Console.instance.RunClientCmd(LocalNetworkUser, "kick_steam", new string[] { PlayerName.Network_id.steamId.ToString() });
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

        public static string[] GetPlayers()
        {
            string[] players = new string[16];
            NetworkUser n;
            for (int i = 0; i < NetworkUser.readOnlyInstancesList.Count; i++)
            {
                n = NetworkUser.readOnlyInstancesList[i];

                players[i] = n.userName;
            }
            return players;
        }

        public static int NumberOfPlayers()
        {
            int numberOfPlayers = 0;
            for (int i = 0; i < players.Length; i++)
            {
                if (players[i] != null)
                {
                    numberOfPlayers++;
                }
            }
            return numberOfPlayers;
        }
    }
}
