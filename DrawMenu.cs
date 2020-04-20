using RoR2;
using System;
using UnityEngine;

namespace RoRCheats
{
    internal class DrawMenu
    {
        public static Vector2 itemSpawnerScrollPosition = Vector2.zero;
        public static Vector2 equipmentSpawnerScrollPosition = Vector2.zero;
        public static Vector2 CharacterScrollPosition = Vector2.zero;

        public static void DrawMainMenu(float x, float y, float widthSize, float mulY, GUIStyle BGstyle, GUIStyle OnStyle, GUIStyle OffStyle, GUIStyle BtnStyle)
        {
            // we dont have a god toggle bool, because we can just ref localhealth
            if (Main.LocalHealth.godMode)
            {
                if (GUI.Button(btn.BtnRect(1, false, "main"), "God mode: ON", OnStyle))
                {
                    Main.LocalHealth.godMode = false;
                }
            }
            else if (GUI.Button(btn.BtnRect(1, false, "main"), "God mode: OFF", OffStyle))
            {
                Main.LocalHealth.godMode = true;
            }

            if (Main.skillToggle)
            {
                if (GUI.Button(btn.BtnRect(2, false, "main"), "Infinite Skills: ON", OnStyle))
                {
                    Main.skillToggle = false;
                }
            }
            else if (GUI.Button(btn.BtnRect(2, false, "main"), "Infinite Skills: OFF", OffStyle))
            {
                Main.skillToggle = true;
            }

            if (Main.renderInteractables)
            {
                if (GUI.Button(btn.BtnRect(3, false, "main"), "Interactables ESP: ON", OnStyle))
                {
                    Main.renderInteractables = false;
                }
            }
            else if (GUI.Button(btn.BtnRect(3, false, "main"), "Interactables ESP: OFF", OffStyle))
            {
                Main.renderInteractables = true;
            }
            if (Main._isTeleMenuOpen)
            {
                if (GUI.Button(btn.BtnRect(4, false, "main"), "Teleporter Menu: ON", OnStyle))
                {
                    Main._isTeleMenuOpen = false;
                }
            }
            else if (GUI.Button(btn.BtnRect(4, false, "main"), "Teleporter Menu: OFF", OffStyle))
            {
                Main._isTeleMenuOpen = true;
            }
            if (Main._isLobbyMenuOpen)
            {
                if (GUI.Button(btn.BtnRect(5, false, "main"), "Lobby Managment: ON", OnStyle))
                {
                    Main._isLobbyMenuOpen = false;
                }
            }
            else if (GUI.Button(btn.BtnRect(5, false, "main"), "Lobby Managment: OFF", OffStyle))
            {
                Main._isLobbyMenuOpen = true;
            }
            if (Main._isPlayerMod)
            {
                if (GUI.Button(btn.BtnRect(6, false, "main"), "Player Modifcations: ON", OnStyle))
                {
                    Main._isPlayerMod = false;
                }
            }
            else if (GUI.Button(btn.BtnRect(6, false, "main"), "Player Modifcations: OFF", OffStyle))
            {
                Main._isPlayerMod = true;
            }

            if (Main._isItemManagerOpen)
            {
                if (GUI.Button(btn.BtnRect(7, false, "main"), "Item Management Menu: ON", OnStyle))
                {
                    Main._isItemManagerOpen = false;
                }
            }
            else if (GUI.Button(btn.BtnRect(7, false, "main"), "Item Management Menu: OFF", OffStyle))
            {
                Main._isItemManagerOpen = true;
            }
            if (Main.NoclipToggle)
            {
                if (GUI.Button(btn.BtnRect(8, false, "main"), "Noclip: ON", OnStyle))
                {
                    Main.NoclipToggle = false;
                }
            }
            else if (GUI.Button(btn.BtnRect(8, false, "main"), "Noclip: Off", OffStyle))
            {
                Main.NoclipToggle = true;
            }
        }

        public static void DrawManagmentMenu(float x, float y, float widthSize, int mulY, GUIStyle BGstyle, GUIStyle buttonStyle, GUIStyle LabelStyle)
        {
            GUI.Box(new Rect(x + 0f, y + 0f, widthSize + 10, 50f + 45 * mulY), "", BGstyle);
            GUI.Label(new Rect(x + 5f, y + 5f, widthSize + 5, 95f), "Lobby Management Menu", LabelStyle);

            if (Main._CharacterCollected)
            {
                Main.GetPlayers(Main.Players); //update this asap
                int buttonPlacement = 1;
                for (int i = 0; i < Main.Players.Length; i++)
                {
                    try
                    {
                        if (Main.Players[i] != null)
                        {
                            if (GUI.Button(btn.BtnRect(buttonPlacement, false, "lobby"), "Kick " + Main.Players[i], buttonStyle))
                            {
                                Chat.AddMessage("<color=#42f5d4>Kicked Player </color>" + "<color=yellow>" + Main.Players[i] + "</color>");
                                Main.kickPlayer(Main.GetNetUserFromString(Main.Players[i].ToString()), Main.LocalNetworkUser);
                            }
                            buttonPlacement++;
                        }
                    }
                    catch (NullReferenceException)
                    {
                        Debug.LogWarning("RoRCheats: There is No Player Selected");
                    }
                }
            }
        }

        public static void DrawNotCollectedMenu(GUIStyle buttonStyle, GUIStyle OnStyle, GUIStyle OffStyle)
        {
            GUI.Button(btn.BtnRect(1, false, "main"), "<color=yellow>Please Note buttons will be availble in game.</color>", buttonStyle);
            if (Main.enableRespawnButton)
            {
                if (GUI.Button(btn.BtnRect(2, false, "main"), "Respawn", OnStyle))
                {
                    Main.Respawn();
                }
            }
            else if (!Main.enableRespawnButton)
            {
                GUI.Button(btn.BtnRect(2, false, "main"), "<color=yellow>Please Note The Respawn button will appear here.</color>", buttonStyle);
            }
            GUI.Button(btn.BtnRect(7, false, "main"), "<color=yellow>Created By Lodington#9215.\n Feel Free to Message me on discord</color>", buttonStyle);
            GUI.Button(btn.BtnRect(8, false, "main"), "<color=yellow>with Bug Reports or suggestions.</color>", buttonStyle);
        }

        public static void CharacterWindowMethod(float x, float y, float widthSize, int mulY, GUIStyle BGstyle, GUIStyle buttonStyle, GUIStyle LabelStyle)
        {
            GUI.Box(new Rect(x + 0f, y + 0f, widthSize + 10, 50f + 45 * 15), "", BGstyle);
            GUI.Label(new Rect(x + 5f, y + 5f, widthSize + 5, 95f), "Character Menu", LabelStyle);

            CharacterScrollPosition = GUI.BeginScrollView(new Rect(x + 0f, y + 0f, widthSize + 10, 50f + 45 * 15), CharacterScrollPosition, new Rect(x + 0f, y + 0f, widthSize + 10, 50f + 45 * mulY), false, true);
            int buttonPlacement = 1;
            foreach (var body in Main.nameToIndexMap)
            {
                if (body.Key.Contains("(Clone)"))
                    continue;
                if (GUI.Button(btn.BtnRect(buttonPlacement, false, "character"), body.Key.Replace("Body", ""), buttonStyle))
                {
                    GameObject newBody = BodyCatalog.FindBodyPrefab(body.Key);
                    if (newBody == null)
                        return;
                    var localUser = RoR2.LocalUserManager.GetFirstLocalUser();
                    if (localUser == null || localUser.cachedMasterController == null || localUser.cachedMasterController.master == null) return;
                    var master = localUser.cachedMasterController.master;

                    master.bodyPrefab = newBody;
                    master.Respawn(master.GetBody().transform.position, master.GetBody().transform.rotation);
                    //DrawMenu();
                    return;
                }
                buttonPlacement++;
            }
            GUI.EndScrollView();
        }

        /*
        public static void DrawSpawnMenu(float x, float y, float widthSize, int mulY, GUIStyle BGstyle, GUIStyle buttonStyle, GUIStyle LabelStyle)
        {
            GUI.Box(new Rect(x + 0f, y + 0f, widthSize + 20, 50f + 45 * 15), "", BGstyle);
            GUI.Label(new Rect(x + 5f, y + 5f, widthSize + 10, 95f), "Item Spawn Menu", LabelStyle);

            itemSpawnerScrollPosition = GUI.BeginScrollView(new Rect(x + 0f, y + 0f, widthSize + 10, 50f + 45 * 15), itemSpawnerScrollPosition, new Rect(x + 0f, y + 0f, widthSize + 10, 50f + 45 * mulY), false, true);
            itemManager.GiveItems(buttonStyle, "itemSpawner");
            GUI.EndScrollView();
        }
        public static void DrawEquipmentMenu(float x, float y, float widthSize, int mulY, GUIStyle BGstyle, GUIStyle buttonStyle, GUIStyle LabelStyle, GUIStyle offStyle)
        {
            GUI.Box(new Rect(x + 0f, y + 0f, widthSize + 20, 50f + 45 * 15), "", BGstyle);
            GUI.Label(new Rect(x + 5f, y + 5f, widthSize + 10, 95f), "Equipment Spawn Menu", LabelStyle);

            equipmentSpawnerScrollPosition = GUI.BeginScrollView(new Rect(x + 0f, y + 0f, widthSize + 10, 50f + 45 * 15), equipmentSpawnerScrollPosition, new Rect(x + 0f, y + 0f, widthSize + 10, 50f + 45 * mulY), false, true);
            Main.GiveCustomEquipment(buttonStyle, "equipmentSpawner");
            GUI.EndScrollView();
        }*/

        public static void DrawStatsMenu(float x, float y, float widthSize, int mulY, GUIStyle BGstyle, GUIStyle buttonStyle)
        {
            GUI.Box(new Rect(x + 0f, y + 0f, 275, 50f + 45 * mulY), "", BGstyle);
            GUI.Label(new Rect(x + 5f, y + 5f, widthSize + 5, 50f), "Stats Menu", buttonStyle);

            GUI.Button(btn.BtnRect(1, false, "stats"), "Damage: " + Main.LocalPlayerBody.damage, buttonStyle);
            GUI.Button(btn.BtnRect(2, false, "stats"), "Crit: " + Main.LocalPlayerBody.crit, buttonStyle);
            GUI.Button(btn.BtnRect(3, false, "stats"), "Attack Speed: " + Main.LocalPlayerBody.attackSpeed, buttonStyle);
            GUI.Button(btn.BtnRect(4, false, "stats"), "Armor: " + Main.LocalPlayerBody.armor, buttonStyle);
            GUI.Button(btn.BtnRect(5, false, "stats"), "Regen: " + Main.LocalPlayerBody.regen, buttonStyle);
            GUI.Button(btn.BtnRect(6, false, "stats"), "Move Speed: " + Main.LocalPlayerBody.moveSpeed, buttonStyle);
            GUI.Button(btn.BtnRect(7, false, "stats"), "Jump Count: " + Main.LocalPlayerBody.maxJumpCount, buttonStyle);
            GUI.Button(btn.BtnRect(8, false, "stats"), "Experience: " + Main.LocalPlayerBody.experience, buttonStyle);
            GUI.Button(btn.BtnRect(9, false, "stats"), "Kills: " + Main.LocalPlayerBody.killCount, buttonStyle);
        }

        public static void DrawTeleMenu(float x, float y, float widthSize, int mulY, GUIStyle BGstyle, GUIStyle buttonStyle, GUIStyle LabelStyle)
        {
            GUI.Box(new Rect(x + 0f, y + 0f, widthSize + 10, 50f + 45 * mulY), "", BGstyle);
            GUI.Label(new Rect(x + 5f, y + 5f, widthSize + 5, 95f), "Teleporter Menu", LabelStyle);

            if (GUI.Button(btn.BtnRect(1, false, "tele"), "Skip Stage", buttonStyle))
                Main.skipStage();
            if (GUI.Button(btn.BtnRect(2, false, "tele"), "Spawn Gold Portal", buttonStyle))
                Main.SpawnPortals("gold");
            if (GUI.Button(btn.BtnRect(3, false, "tele"), "Spawn Blue Portal", buttonStyle))
                Main.SpawnPortals("newt");
            if (GUI.Button(btn.BtnRect(4, false, "tele"), "Spawn Celestal Portal", buttonStyle))
                Main.SpawnPortals("blue");
            if (GUI.Button(btn.BtnRect(5, false, "tele"), "Spawn All Portals", buttonStyle))
                Main.SpawnPortals("all");
            if (GUI.Button(btn.BtnRect(6, false, "tele"), "Insta Charge Teleporter", buttonStyle))
                Main.InstaTeleporter();
            if (GUI.Button(btn.BtnRect(7, false, "tele"), "+1 Mountain Challenge : Current Ammount " + TeleporterInteraction.instance.shrineBonusStacks.ToString(), buttonStyle))
                Main.addMountain();
        }

        public static void DrawPlayerModMenu(float x, float y, float widthSize, int mulY, GUIStyle BGstyle, GUIStyle buttonStyle, GUIStyle OnStyle, GUIStyle OffStyle, GUIStyle LabelStyle)
        {
            GUI.Box(new Rect(x + 0f, y + 0f, widthSize + 10, 50f + 45 * mulY), "", BGstyle);
            GUI.Label(new Rect(x + 5f, y + 5f, widthSize + 5, 95f), "Player Modifiers Menu", LabelStyle);

            if (GUI.Button(btn.BtnRect(1, true, "playermod"), "Give Money: " + Main.moneyToGive.ToString(), buttonStyle))
            {
                Main.GiveMoney();
            }
            if (GUI.Button(new Rect(x + widthSize - 80, y + Main.PlayerModBtnY, 40, 40), "-", OffStyle))
            {
                if (Main.moneyToGive > 100)
                    Main.moneyToGive -= 100;
            }
            if (GUI.Button(new Rect(x + widthSize - 35, y + Main.PlayerModBtnY, 40, 40), "+", OffStyle))
            {
                if (Main.moneyToGive >= 100)
                    Main.moneyToGive += 100;
            }
            if (GUI.Button(btn.BtnRect(2, true, "playermod"), "Give Lunar Coins: " + Main.coinsToGive.ToString(), buttonStyle))
            {
                Main.GiveLunarCoins();
            }
            if (GUI.Button(new Rect(x + widthSize - 80, y + Main.PlayerModBtnY, 40, 40), "-", OffStyle))
            {
                if (Main.coinsToGive > 10)
                    Main.coinsToGive -= 10;
            }
            if (GUI.Button(new Rect(x + widthSize - 35, y + Main.PlayerModBtnY, 40, 40), "+", OffStyle))
            {
                if (Main.coinsToGive >= 10)
                    Main.coinsToGive += 10;
            }
            if (GUI.Button(btn.BtnRect(3, true, "playermod"), "Give Experience: " + Main.xpToGive.ToString(), buttonStyle))
            {
                Main.giveXP();
            }
            if (GUI.Button(new Rect(x + widthSize - 80, y + Main.PlayerModBtnY, 40, 40), "-", OffStyle))
            {
                if (Main.xpToGive > 100)
                    Main.xpToGive -= 100;
            }
            if (GUI.Button(new Rect(x + widthSize - 35, y + Main.PlayerModBtnY, 40, 40), "+", OffStyle))
            {
                if (Main.xpToGive >= 100)
                    Main.xpToGive += 100;
            }

            if (Main.damageToggle)
            {
                if (GUI.Button(btn.BtnRect(4, true, "playermod"), "Damage Per LvL : " + Main.damagePerLvl.ToString(), OnStyle))
                {
                    Main.damageToggle = false;
                }
            }
            else if (GUI.Button(btn.BtnRect(4, true, "playermod"), "Damage Per LvL : " + Main.damagePerLvl.ToString(), OffStyle))
            {
                Main.damageToggle = true;
            }
            if (GUI.Button(new Rect(x + widthSize - 80, y + Main.PlayerModBtnY, 40, 40), "-", OffStyle))
            {
                if (Main.damagePerLvl > 0)
                    Main.damagePerLvl -= 10;
            }
            if (GUI.Button(new Rect(x + widthSize - 35, y + Main.PlayerModBtnY, 40, 40), "+", OffStyle))
            {
                if (Main.damagePerLvl >= 0)
                    Main.damagePerLvl += 10;
            }
            if (Main.critToggle)
            {
                if (GUI.Button(btn.BtnRect(5, true, "playermod"), "Crit Per LvL : " + Main.CritPerLvl.ToString(), OnStyle))
                {
                    Main.critToggle = false;
                }
            }
            else if (GUI.Button(btn.BtnRect(5, true, "playermod"), "Crit Per LvL : " + Main.CritPerLvl.ToString(), OffStyle))
            {
                Main.critToggle = true;
            }
            if (GUI.Button(new Rect(x + widthSize - 80, y + Main.PlayerModBtnY, 40, 40), "-", OffStyle))
            {
                if (Main.CritPerLvl > 0)
                    Main.CritPerLvl -= 1;
            }
            if (GUI.Button(new Rect(x + widthSize - 35, y + Main.PlayerModBtnY, 40, 40), "+", OffStyle))
            {
                if (Main.CritPerLvl >= 0)
                    Main.CritPerLvl += 1;
            }
            if (Main.attackSpeedToggle)
            {
                if (GUI.Button(btn.BtnRect(6, true, "playermod"), "Attack Speed : " + Main.attackSpeed.ToString(), OnStyle))
                {
                    Main.attackSpeedToggle = false;
                }
            }
            else if (GUI.Button(btn.BtnRect(6, true, "playermod"), "Attack Speed : " + Main.attackSpeed.ToString(), OffStyle))
            {
                Main.attackSpeedToggle = true;
            }
            if (GUI.Button(new Rect(x + widthSize - 80, y + Main.PlayerModBtnY, 40, 40), "-", OffStyle))
            {
                if (Main.attackSpeed > 0)
                    Main.attackSpeed -= 1;
            }
            if (GUI.Button(new Rect(x + widthSize - 35, y + Main.PlayerModBtnY, 40, 40), "+", OffStyle))
            {
                if (Main.attackSpeed >= 0)
                    Main.attackSpeed += 1;
            }
            if (Main.armorToggle)
            {
                if (GUI.Button(btn.BtnRect(7, true, "playermod"), "Armor : " + Main.armor.ToString(), OnStyle))
                {
                    Main.armorToggle = false;
                }
            }
            else if (GUI.Button(btn.BtnRect(7, true, "playermod"), "Armor : " + Main.armor.ToString(), OffStyle))
            {
                Main.armorToggle = true;
            }
            if (GUI.Button(new Rect(x + widthSize - 80, y + Main.PlayerModBtnY, 40, 40), "-", OffStyle))
            {
                if (Main.armor > 0)
                    Main.armor -= 10;
            }
            if (GUI.Button(new Rect(x + widthSize - 35, y + Main.PlayerModBtnY, 40, 40), "+", OffStyle))
            {
                if (Main.armor >= 0)
                    Main.armor += 10;
            }
            if (Main.moveSpeedToggle)
            {
                if (GUI.Button(btn.BtnRect(8, true, "playermod"), "Move Speed : " + Main.movespeed.ToString(), OnStyle))
                {
                    Main.moveSpeedToggle = false;
                }
            }
            else if (GUI.Button(btn.BtnRect(8, true, "playermod"), "Move Speed : " + Main.movespeed.ToString(), OffStyle))
            {
                Main.moveSpeedToggle = true;
            }
            if (GUI.Button(new Rect(x + widthSize - 80, y + Main.PlayerModBtnY, 40, 40), "-", OffStyle))
            {
                if (Main.movespeed > 7)
                    Main.movespeed -= 10;
            }
            if (GUI.Button(new Rect(x + widthSize - 35, y + Main.PlayerModBtnY, 40, 40), "+", OffStyle))
            {
                if (Main.movespeed >= 7)
                    Main.movespeed += 10;
            }
            if (Main._CharacterToggle)
            {
                if (GUI.Button(btn.BtnRect(9, false, "playermod"), "Character Selection: ON", OnStyle))
                {
                    Main._CharacterToggle = false;
                }
            }
            else if (GUI.Button(btn.BtnRect(9, false, "playermod"), "Character Selection: OFF", OffStyle))
            {
                Main._CharacterToggle = true;
            }
            if (Main._isStatMenuOpen)
            {
                if (GUI.Button(btn.BtnRect(10, false, "playermod"), "Stats Menu: ON", OnStyle))
                {
                    Main._isStatMenuOpen = false;
                }
            }
            else if (GUI.Button(btn.BtnRect(10, false, "playermod"), "Stats Menu: OFF", OffStyle))
            {
                Main._isStatMenuOpen = true;
            }
            if (Main.alwaysSprint)
            {
                if (GUI.Button(btn.BtnRect(11, false, "playermod"), "Always Sprint : ON", OnStyle))
                {
                    Main.alwaysSprint = false;
                }
            }
            else if (!Main.alwaysSprint)
            {
                if (GUI.Button(btn.BtnRect(11, false, "playermod"), "Always Sprint : OFF", OffStyle))
                {
                    Main.alwaysSprint = true;
                }
            }
            if (Main.aimBot)
            {
                if (GUI.Button(btn.BtnRect(12, false, "playermod"), "AimBot : ON", OnStyle))
                {
                    EntityStates.FireNailgun.spreadPitchScale = 0.5f;
                    EntityStates.FireNailgun.spreadYawScale = 1f;
                    EntityStates.FireNailgun.spreadBloomValue = 0.2f;
                    Main.aimBot = false;
                }
            }
            else if (!Main.aimBot)
            {
                if (GUI.Button(btn.BtnRect(12, false, "playermod"), "AimBot : OFF", OffStyle))
                {
                    EntityStates.FireNailgun.spreadPitchScale = 0;
                    EntityStates.FireNailgun.spreadYawScale = 0;
                    EntityStates.FireNailgun.spreadBloomValue = 0;
                    Main.aimBot = true;
                }
            }
            if (Main.ShowUnlockAll)
            {
                if (GUI.Button(btn.BtnRect(13, false, "playermod"), "Unlock All", OnStyle))
                {
                    Main.UnlockAll();
                }
            }
            else if (!Main.ShowUnlockAll)
            {
                if (GUI.Button(btn.BtnRect(13, false, "playermod"), "Unlock All", OffStyle))
                {
                    Debug.LogWarning("RoRCheats : Please Set unlock all in config to true");
                }
            }


        }
        public static void DrawItemManagementMenu(float x, float y, float widthSize, int mulY, GUIStyle BGstyle, GUIStyle buttonStyle, GUIStyle OnStyle, GUIStyle OffStyle, GUIStyle LabelStyle)
        {
            GUI.Box(new Rect(x + 0f, y + 0f, widthSize + 10, 50f + 45 * mulY), "", BGstyle);
            GUI.Label(new Rect(x + 5f, y + 5f, widthSize + 5, 95f), "Item management Menu", LabelStyle);

            if (GUI.Button(btn.BtnRect(1, true, "itemmanager"), "Roll Items: " + Main.itemsToRoll.ToString(), buttonStyle))
            {
                Main.RollItems(Main.itemsToRoll.ToString());
            }
            if (GUI.Button(new Rect(x + widthSize - 80, y + Main.ItemManagerBtnY, 40, 40), "-", OffStyle))
            {
                if (Main.itemsToRoll > 5)
                    Main.itemsToRoll -= 5;
            }
            if (GUI.Button(new Rect(x + widthSize - 35, y + Main.ItemManagerBtnY, 40, 40), "+", OffStyle))
            {
                if (Main.itemsToRoll >= 5)
                    Main.itemsToRoll += 5;
            }
            if (GUI.Button(btn.BtnRect(2, true, "itemmanager"), "Give All Items: " + Main.allItemsQuantity.ToString(), buttonStyle))
            {
                Main.GiveAllItems();
            }
            if (GUI.Button(new Rect(x + widthSize - 80, y + Main.ItemManagerBtnY, 40, 40), "-", OffStyle))
            {
                if (Main.allItemsQuantity > 1)
                    Main.allItemsQuantity -= 1;
            }
            if (GUI.Button(new Rect(x + widthSize - 35, y + Main.ItemManagerBtnY, 40, 40), "+", OffStyle))
            {
                if (Main.allItemsQuantity >= 1)
                    Main.allItemsQuantity += 1;
            }
            if (Main.isDropItems)
            {
                if (GUI.Button(btn.BtnRect(3, false, "itemmanager"), "Remove Items: ON", OnStyle))
                {
                    Main.isDropItems = false;
                }
            }
            else if (GUI.Button(btn.BtnRect(3, false, "itemmanager"), "Remove Items: OFF", OffStyle))
            {
                Main.isDropItems = true;
            }
            if (Main.isDropItemForAll)
            {
                if (GUI.Button(btn.BtnRect(4, false, "itemmanager"), "Drop Items For Others: ON", OnStyle))
                {
                    Main.isDropItemForAll = false;
                }
            }
            else if (GUI.Button(btn.BtnRect(4, false, "itemmanager"), "Drop Items For Others: OFF", OffStyle))
            {
                Main.isDropItemForAll = true;
            }
            if (Main._isItemSpawnMenuOpen)
            {
                if (GUI.Button(btn.BtnRect(5, false, "itemmanager"), "Item Spawn Menu: ON", OnStyle))
                {
                    Main._isItemSpawnMenuOpen = false;
                }
            }
            else if (GUI.Button(btn.BtnRect(5, false, "itemmanager"), "Item Spawn Menu: OFF", OffStyle))
            {
                Main._isItemSpawnMenuOpen = true;
            }
            if (Main._isEquipmentSpawnMenuOpen)
            {
                if (GUI.Button(btn.BtnRect(6, false, "itemmanager"), "Equipment Menu: ON", OnStyle))
                {
                    Main._isEquipmentSpawnMenuOpen = false;
                }
            }
            else if (GUI.Button(btn.BtnRect(6, false, "itemmanager"), "Equipment Menu: OFF", OffStyle))
            {
                Main._isEquipmentSpawnMenuOpen = true;
            }
            if (GUI.Button(btn.BtnRect(7, false, "itemmanager"), "Stack Inventory", buttonStyle))
            {
                Main.StackInventory();
            }
            if (GUI.Button(btn.BtnRect(8, false, "itemmanager"), "Clear Inventory", buttonStyle))
            {
                Main.ClearInventory();
            }
        }


    }
}