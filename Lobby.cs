using System;
using RoR2;
using UnityEngine;
using Console = RoR2.Console;

namespace UmbraRoR
{
    class Lobby : MonoBehaviour
    {
        // More posibilities here using console.
        // Not added to ui yet.
        public static void BanPlayer(NetworkUser PlayerName, NetworkUser LocalNetworkUser)
        {
            Console.instance.RunClientCmd(LocalNetworkUser, "ban_steam", new string[] { PlayerName.Network_id.steamId.ToString() });
        }

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

        public static int NumberOfPlayers()
        {
            GetPlayers(Main.Players);
            int numberOfPlayers = 0;
            for (int i = 0; i < Main.Players.Length; i++)
            {
                if (Main.Players[i] != null)
                {
                    numberOfPlayers++;
                }
            }
            return numberOfPlayers;
        }
    }
}
