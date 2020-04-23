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

        public static void DrawManagmentMenu(float x, float y, float widthSize, int mulY, GUIStyle BGstyle, GUIStyle buttonStyle, GUIStyle LabelStyle)
        {
            GUI.Box(new Rect(x + 0f, y + 0f, widthSize + 10, 50f + 45 * mulY), "", BGstyle);
            GUI.Label(new Rect(x + 5f, y + 5f, widthSize + 5, 95f), "L O B B Y   M A N A G E M E N T   M E N U", LabelStyle);

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
                            if (GUI.Button(btn.BtnRect(buttonPlacement, false, "lobby"), $"K I C K  <color=yellow>{Main.Players[i]}</color>", buttonStyle))
                            {
                                Chat.AddMessage("<color=#42f5d4>Kicked Player </color>" + $"<color=yellow>{Main.Players[i]}</color>");
                                Main.KickPlayer(Main.GetNetUserFromString(Main.Players[i].ToString()), Main.LocalNetworkUser);
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
            GUI.Button(btn.BtnRect(2, false, "main"), "<color=yellow>Buttons will be availble in game.</color>", buttonStyle);
            /*if (Main.enableRespawnButton)
            {
                if (GUI.Button(btn.BtnRect(2, false, "main"), "Respawn", OnStyle))
                {
                    Main.Respawn();
                }
            }
            else if (!Main.enableRespawnButton)
            {
                //GUI.Button(btn.BtnRect(2, false, "main"), "<color=yellow>The Respawn button will appear here.</color>", buttonStyle);
            }*/
            GUI.Button(btn.BtnRect(3, false, "main"), "<color=#11ccee>Created By Acherons#1337.\n Feel Free to Message me on discord</color>", buttonStyle);
            GUI.Button(btn.BtnRect(4, false, "main"), "<color=#11ccee>with Bug Reports or suggestions.</color>", buttonStyle);
        }

        public static void CharacterWindowMethod(float x, float y, float widthSize, int mulY, GUIStyle BGstyle, GUIStyle buttonStyle, GUIStyle LabelStyle)
        {
            GUI.Box(new Rect(x + 0f, y + 0f, widthSize + 10, 50f + 45 * 15), "", BGstyle);
            GUI.Label(new Rect(x + 5f, y + 5f, widthSize + 5, 95f), "C H A R A C T E R   M E N U", LabelStyle);

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
        public static void DrawSpawnMenu(float x, float y, float widthSize, int mulY, GUIStyle BGstyle, GUIStyle buttonStyle, GUIStyle LabelStyle)
        {
            GUI.Box(new Rect(x + 0f, y + 0f, widthSize + 20, 50f + 45 * 15), "", BGstyle);
            GUI.Label(new Rect(x + 5f, y + 5f, widthSize + 10, 95f), "I T E M   M E N U", LabelStyle);

            itemSpawnerScrollPosition = GUI.BeginScrollView(new Rect(x + 0f, y + 0f, widthSize + 10, 50f + 45 * 15), itemSpawnerScrollPosition, new Rect(x + 0f, y + 0f, widthSize + 10, 50f + 45 * mulY), false, true);
            Main.GiveItem(buttonStyle, "itemSpawner");
            GUI.EndScrollView();
        }
        public static void DrawEquipmentMenu(float x, float y, float widthSize, int mulY, GUIStyle BGstyle, GUIStyle buttonStyle, GUIStyle LabelStyle, GUIStyle offStyle)
        {
            GUI.Box(new Rect(x + 0f, y + 0f, widthSize + 20, 50f + 45 * 15), "", BGstyle);
            GUI.Label(new Rect(x + 5f, y + 5f, widthSize + 10, 95f), "E Q U I P M E N T   L I S T", LabelStyle);

            equipmentSpawnerScrollPosition = GUI.BeginScrollView(new Rect(x + 0f, y + 0f, widthSize + 10, 50f + 45 * 15), equipmentSpawnerScrollPosition, new Rect(x + 0f, y + 0f, widthSize + 10, 50f + 45 * mulY), false, true);
            Main.GiveEquipment(buttonStyle, "equipmentSpawner");
            GUI.EndScrollView();
        }
        public static void DrawBuffMenu(float x, float y, float widthSize, int mulY, GUIStyle BGstyle, GUIStyle buttonStyle, GUIStyle LabelStyle, GUIStyle offStyle)
        {
            GUI.Box(new Rect(x + 0f, y + 0f, widthSize + 20, 50f + 45 * 15), "", BGstyle);
            GUI.Label(new Rect(x + 5f, y + 5f, widthSize + 10, 95f), "B U F F   L I S T", LabelStyle);

            equipmentSpawnerScrollPosition = GUI.BeginScrollView(new Rect(x + 0f, y + 0f, widthSize + 10, 50f + 45 * 15), equipmentSpawnerScrollPosition, new Rect(x + 0f, y + 0f, widthSize + 10, 50f + 45 * mulY), false, true);
            Main.GiveBuff(buttonStyle, "giveBuff");
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

        public static void DrawTeleMenu(float x, float y, float widthSize, int mulY, GUIStyle BGstyle, GUIStyle buttonStyle, GUIStyle LabelStyle)
        {
            GUI.Box(new Rect(x + 0f, y + 0f, widthSize + 10, 50f + 45 * mulY), "", BGstyle);
            GUI.Label(new Rect(x + 5f, y + 5f, widthSize + 5, 95f), "T E L E P O R T E R   M E N U", LabelStyle);

            if (GUI.Button(btn.BtnRect(1, false, "tele"), "S K I P   S T A G E", buttonStyle))
                Main.skipStage();
            if (GUI.Button(btn.BtnRect(2, false, "tele"), "I N S T A N T   T E L E P O R T E R   C H A R G E", buttonStyle))
                Main.InstaTeleporter();
            if (GUI.Button(btn.BtnRect(3, false, "tele"), "M O U N T A I N   C H A L L E N G E - C O U N T : " + TeleporterInteraction.instance.shrineBonusStacks.ToString(), buttonStyle))
                Main.addMountain();
            if (GUI.Button(btn.BtnRect(4, false, "tele"), "S P A W N   A L L   P O R T A L S", buttonStyle))
                Main.SpawnPortals("all");
            if (GUI.Button(btn.BtnRect(5, false, "tele"), "S P A W N   B L U E   P O R T A L", buttonStyle))
                Main.SpawnPortals("newt");
            if (GUI.Button(btn.BtnRect(6, false, "tele"), "S P A W N   C E L E S T A L   P O R T A L", buttonStyle))
                Main.SpawnPortals("blue");
            if (GUI.Button(btn.BtnRect(7, false, "tele"), "S P A W N   G O L D   P O R T A L", buttonStyle))
                Main.SpawnPortals("gold");
        }

            public static void DrawESPMenu(float x, float y, float widthSize, int mulY, GUIStyle BGstyle, GUIStyle buttonStyle, GUIStyle OnStyle, GUIStyle OffStyle, GUIStyle LabelStyle)
        {
            GUI.Box(new Rect(x + 0f, y + 0f, widthSize + 10, 50f + 45 * mulY), "", BGstyle);
            GUI.Label(new Rect(x + 5f, y + 5f, widthSize + 5, 95f), "R E N D E R   M E N U", LabelStyle);

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

        public static void DrawPlayerModMenu(float x, float y, float widthSize, int mulY, GUIStyle BGstyle, GUIStyle buttonStyle, GUIStyle OnStyle, GUIStyle OffStyle, GUIStyle LabelStyle)
        {
            GUI.Box(new Rect(x + 0f, y + 0f, widthSize + 10, 50f + 45 * mulY), "", BGstyle);
            GUI.Label(new Rect(x + 5f, y + 5f, widthSize + 5, 95f), "P L A Y E R   M O D I F I C A T I O N   M E N U", LabelStyle);

            if (GUI.Button(btn.BtnRect(1, true, "playermod"), "G I V E   M O N E Y : " + Main.moneyToGive.ToString(), buttonStyle))
            {
                Main.GiveMoney();
            }
            if (GUI.Button(new Rect(x + widthSize - 80, y + Main.PlayerModBtnY, 40, 40), "-", OffStyle))
            {
                if (Main.moneyToGive > 50)
                    Main.moneyToGive -= 50;
            }
            if (GUI.Button(new Rect(x + widthSize - 35, y + Main.PlayerModBtnY, 40, 40), "+", OffStyle))
            {
                if (Main.moneyToGive >= 50)
                    Main.moneyToGive += 50;
            }
            if (GUI.Button(btn.BtnRect(2, true, "playermod"), "G I V E   L U N A R   C O I N S : " + Main.coinsToGive.ToString(), buttonStyle))
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
            if (GUI.Button(btn.BtnRect(3, true, "playermod"), "G I V E   E X P E R I E N C E : " + Main.xpToGive.ToString(), buttonStyle))
            {
                Main.giveXP();
            }
            if (GUI.Button(new Rect(x + widthSize - 80, y + Main.PlayerModBtnY, 40, 40), "-", OffStyle))
            {
                if (Main.xpToGive > 50)
                    Main.xpToGive -= 50;
            }
            if (GUI.Button(new Rect(x + widthSize - 35, y + Main.PlayerModBtnY, 40, 40), "+", OffStyle))
            {
                if (Main.xpToGive >= 50)
                    Main.xpToGive += 50;
            }

            if (Main.damageToggle)
            {
                if (GUI.Button(btn.BtnRect(4, true, "playermod"), "D A M A G E   P E R   L V L : " + Main.damagePerLvl.ToString(), OnStyle))
                {
                    Main.damageToggle = false;
                }
            }
            else if (GUI.Button(btn.BtnRect(4, true, "playermod"), "D A M A G E   P E R   L V L " + Main.damagePerLvl.ToString(), OffStyle))
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
                if (GUI.Button(btn.BtnRect(5, true, "playermod"), "C R I T   P E R   L V L : " + Main.CritPerLvl.ToString(), OnStyle))
                {
                    Main.critToggle = false;
                }
            }
            else if (GUI.Button(btn.BtnRect(5, true, "playermod"), "C R I T   P E R   L V L : " + Main.CritPerLvl.ToString(), OffStyle))
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
                if (GUI.Button(btn.BtnRect(6, true, "playermod"), "A T T A C K   S P E E D : " + Main.attackSpeed.ToString(), OnStyle))
                {
                    Main.attackSpeedToggle = false;
                }
            }
            else if (GUI.Button(btn.BtnRect(6, true, "playermod"), "A T T A C K   S P E E D : " + Main.attackSpeed.ToString(), OffStyle))
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
                if (GUI.Button(btn.BtnRect(7, true, "playermod"), "A R M O R : " + Main.armor.ToString(), OnStyle))
                {
                    Main.armorToggle = false;
                }
            }
            else if (GUI.Button(btn.BtnRect(7, true, "playermod"), "A R M O R : " + Main.armor.ToString(), OffStyle))
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
                if (GUI.Button(btn.BtnRect(8, true, "playermod"), "M O V E   S P E E D : " + Main.movespeed.ToString(), OnStyle))
                {
                    Main.moveSpeedToggle = false;
                }
            }
            else if (GUI.Button(btn.BtnRect(8, true, "playermod"), "M O V E   S P E E D : " + Main.movespeed.ToString(), OffStyle))
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
            /*if (Main._CharacterToggle)
            {
                if (GUI.Button(btn.BtnRect(9, false, "playermod"), "Character Selection: ON", OnStyle))
                {
                    Main._CharacterToggle = false;
                }
            }
            else if (GUI.Button(btn.BtnRect(9, false, "playermod"), "Character Selection: OFF", OffStyle))
            {
                Main._CharacterToggle = true;
            }*/
            if (Main._isStatMenuOpen)
            {
                if (GUI.Button(btn.BtnRect(9, false, "playermod"), "S H O W   S T A T S : O N", OnStyle))
                {
                    Main._isStatMenuOpen = false;
                }
            }
            else if (GUI.Button(btn.BtnRect(9, false, "playermod"), "S H O W   S T A T S : O F F", OffStyle))
            {
                Main._isStatMenuOpen = true;
            }
            if (Main._isBuffMenuOpen)
            {
                if (GUI.Button(btn.BtnRect(10, false, "playermod"), "G I V E   B U F F   M E N U : O N", OnStyle))
                {
                    Main._isBuffMenuOpen = false;
                }
            }
            else if (GUI.Button(btn.BtnRect(10, false, "playermod"), "G I V E   B U F F   M E N U : O F F", OffStyle))
            {
                Main._isBuffMenuOpen = true;
            }
            if (GUI.Button(btn.BtnRect(11, false, "playermod"), "R E M O V E   A L L   B U F F S", buttonStyle))
            {
                Main.RemoveAllBuffs();
            }
            if (Main.aimBot)
            {
                if (GUI.Button(btn.BtnRect(12, false, "playermod"), "A I M B O T : O N", OnStyle))
                {
                    EntityStates.FireNailgun.spreadPitchScale = 0.5f;
                    EntityStates.FireNailgun.spreadYawScale = 1f;
                    EntityStates.FireNailgun.spreadBloomValue = 0.2f;
                    Main.aimBot = false;
                }
            }
            else if (!Main.aimBot)
            {
                if (GUI.Button(btn.BtnRect(12, false, "playermod"), "A I M B O T : O F F", OffStyle))
                {
                    EntityStates.FireNailgun.spreadPitchScale = 0;
                    EntityStates.FireNailgun.spreadYawScale = 0;
                    EntityStates.FireNailgun.spreadBloomValue = 0;
                    Main.aimBot = true;
                }
            }
            if (Main.alwaysSprint)
            {
                if (GUI.Button(btn.BtnRect(13, false, "playermod"), "A L W A Y S   S P R I N T : O N", OnStyle))
                {
                    Main.alwaysSprint = false;
                }
            }
            else if (!Main.alwaysSprint)
            {
                if (GUI.Button(btn.BtnRect(13, false, "playermod"), "A L W A Y S   S P R I N T : O F F", OffStyle))
                {
                    Main.alwaysSprint = true;
                }
            }
            if (Main.FlightToggle)
            {
                if (GUI.Button(btn.BtnRect(14, false, "playermod"), "F L I G H T : O N", OnStyle))
                {
                    Main.FlightToggle = false;
                }
            }
            else if (GUI.Button(btn.BtnRect(14, false, "playermod"), "F L I G H T : O F F", OffStyle))
            {
                Main.FlightToggle = true;
            }
            if (Main.godToggle)
            {
                if (GUI.Button(btn.BtnRect(15, false, "playermod"), "G O D   M O D E : O N", OnStyle))
                {
                    Main.godToggle = false;
                }
            }
            else if (GUI.Button(btn.BtnRect(15, false, "playermod"), "G O D   M O D E : O F F", OffStyle))
            {
                Main.godToggle = true;
            }
            if (Main.skillToggle)
            {
                if (GUI.Button(btn.BtnRect(16, false, "playermod"), "I N F I N I T E   S K I L L S : O N", OnStyle))
                {
                    Main.skillToggle = false;
                }
            }
            else if (GUI.Button(btn.BtnRect(16, false, "playermod"), "I N F I N I T E   S K I L L S : O F F", OffStyle))
            {
                Main.skillToggle = true;
            }
            if (GUI.Button(btn.BtnRect(17, false, "playermod"), "U N L O C K   A L L", buttonStyle))
            {
                Main.UnlockAll();
            }
        }
        public static void DrawItemManagementMenu(float x, float y, float widthSize, int mulY, GUIStyle BGstyle, GUIStyle buttonStyle, GUIStyle OnStyle, GUIStyle OffStyle, GUIStyle LabelStyle)
        {
            GUI.Box(new Rect(x + 0f, y + 0f, widthSize + 10, 50f + 45 * mulY), "", BGstyle);
            GUI.Label(new Rect(x + 5f, y + 5f, widthSize + 5, 95f), "I T E M   M A N A G E M E N T   M E N U", LabelStyle);

            if (GUI.Button(btn.BtnRect(1, true, "itemmanager"), "G I V E   A L L   I T E M S : " + Main.allItemsQuantity.ToString(), buttonStyle))
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
            if (GUI.Button(btn.BtnRect(2, true, "itemmanager"), "R O L L   I T E M S : " + Main.itemsToRoll.ToString(), buttonStyle))
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
            /*if (Main.isDropItems)
            {
                if (GUI.Button(btn.BtnRect(3, false, "itemmanager"), "Remove Items: ON", OnStyle))
                {
                    Main.isDropItems = false;
                }
            }
            else if (GUI.Button(btn.BtnRect(3, false, "itemmanager"), "Remove Items: OFF", OffStyle))
            {
                Main.isDropItems = true;
            }*/

            if (Main._isItemSpawnMenuOpen)
            {
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
                if (GUI.Button(btn.BtnRect(4, false, "itemmanager"), "E Q U I P M E N T   S P A W N   M E N U : O N", OnStyle))
                {
                    Main._isEquipmentSpawnMenuOpen = false;
                }
            }
            else if (GUI.Button(btn.BtnRect(4, false, "itemmanager"), "E Q U I P M E N T   S P A W N   M E N U : O F F", OffStyle))
            {
                Main._isEquipmentSpawnMenuOpen = true;
            }
            if (Main.isDropItemForAll)
            {
                if (GUI.Button(btn.BtnRect(5, false, "itemmanager"), "G I V E N   I T E M S   D R O P : O N", OnStyle))
                {
                    Main.isDropItemForAll = false;
                }
            }
            else if (GUI.Button(btn.BtnRect(5, false, "itemmanager"), "G I V E N   I T E M S   D R O P : O F F", OffStyle))
            {
                Main.isDropItemForAll = true;
            }
            if (Main.noEquipmentCooldown)
            {
                if (GUI.Button(btn.BtnRect(6, false, "itemmanager"), "I N F I N I T E   E Q U I P M E N T : O N", OnStyle))
                {
                    Main.noEquipmentCooldown = false;
                }
            }
            else if (GUI.Button(btn.BtnRect(6, false, "itemmanager"), "I N F I N I T E   E Q U I P M E N T : O F F", OffStyle))
            {
                Main.noEquipmentCooldown = true;
            }
            if (GUI.Button(btn.BtnRect(7, false, "itemmanager"), "S T A C K   I N V E N T O R Y", buttonStyle))
            {
                Main.StackInventory();
            }
            if (GUI.Button(btn.BtnRect(8, false, "itemmanager"), "C L E A R   I N V E N T O R Y", buttonStyle))
            {
                Main.ClearInventory();
            }
        }


    }
}