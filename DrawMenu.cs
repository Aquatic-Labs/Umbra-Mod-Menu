using RoR2;
using System;
using UnityEngine;

namespace UmbraRoR
{
    internal class DrawMenu
    {
        public static Vector2 itemSpawnerScrollPosition = Vector2.zero;
        public static Vector2 equipmentSpawnerScrollPosition = Vector2.zero;
        public static Vector2 buffMenuScrollPosition = Vector2.zero;
        public static Vector2 characterScrollPosition = Vector2.zero;
        public static Vector2 spawnScrollPosition = Vector2.zero;

        public static void DrawNotCollectedMenu(GUIStyle buttonStyle, GUIStyle OnStyle, GUIStyle OffStyle)
        {
            if (Updates.updateAvailable)
            {
                DrawButton(2, "main", "<color=yellow>Buttons will be availble in game.</color>", buttonStyle, justText: true);
                DrawButton(3, "main", "<color=#11ccee>Created By Neonix#1337.\n Feel Free to Message me on discord.</color>", buttonStyle, justText: true);
                DrawButton(4, "main", "<color=#11ccee>Download the latest version on my github.\nAcher0ns/Umbra-Mod-Menu</color>", buttonStyle, justText: true);
            }
            else if (Updates.upToDate || Updates.devBuild)
            {
                DrawButton(2, "main", "<color=yellow>Buttons will be availble in game.</color>", buttonStyle, justText: true);
                DrawButton(3, "main", "<color=#11ccee>Created By Neonix#1337.\n Feel Free to Message me on discord.</color>", buttonStyle, justText: true);
                DrawButton(4, "main", "<color=#11ccee>with bug Reports or suggestions.</color>", buttonStyle, justText: true);
            }
        }

        public static void DrawMainMenu(float x, float y, float widthSize, float mulY, GUIStyle BGstyle, GUIStyle OnStyle, GUIStyle OffStyle, GUIStyle ButtonStyle)
        {
            if (Main._isPlayerMod)
            {
                DrawButton(1, "main", "P L A Y E R : O N", OnStyle);
            }
            else
            {
                DrawButton(1, "main", "P L A Y E R : O F F", OffStyle);
            }

            if (Main._isMovementOpen)
            {
                DrawButton(2, "main", "M O V E M E N T : O N", OnStyle);
            }
            else
            {
                DrawButton(2, "main", "M O V E M E N T : O F F", OffStyle);
            }

            if (Main._isItemManagerOpen)
            {
                DrawButton(3, "main", "I T E M S : ON", OnStyle);
            }
            else
            {
                DrawButton(3, "main", "I T E M S : O F F", OffStyle);
            }

            if (Main._isSpawnMenuOpen)
            {
                DrawButton(4, "main", "S P A W N : O N", OnStyle);
            }
            else
            {
                DrawButton(4, "main", "S P A W N : O F F", OffStyle);
            }

            if (Main._isTeleMenuOpen)
            {
                DrawButton(5, "main", "T E L E P O R T E R : O N", OnStyle);
            }
            else
            {
                DrawButton(5, "main", "T E L E P O R T E R : O F F", OffStyle);
            }

            if (Main._isESPMenuOpen)
            {
                DrawButton(6, "main", "R E N D E R : O N", OnStyle);
            }
            else
            {
                DrawButton(6, "main", "R E N D E R : O F F", OffStyle);
            }

            if (Main._isLobbyMenuOpen)
            {
                DrawButton(7, "main", "L O B B Y : O N", OnStyle);
            }
            else
            {
                DrawButton(7, "main", "L O B B Y : O F F", OffStyle);
            }

            if (Main.unloadConfirm)
            {
                DrawButton(8, "main", "C O N F I R M ?", ButtonStyle);
            }
            else
            {
                DrawButton(8, "main", "U N L O A D   M E N U", ButtonStyle);
            }
        }

        public static void DrawPlayerModMenu(float x, float y, float widthSize, int mulY, GUIStyle BGstyle, GUIStyle buttonStyle, GUIStyle OnStyle, GUIStyle OffStyle, GUIStyle LabelStyle)
        {
            GUI.Box(new Rect(x + 0f, y + 0f, widthSize + 10, 50f + 45 * mulY), "", BGstyle);
            GUI.Label(new Rect(x + 5f, y + 5f, widthSize + 5, 85f), "P L A Y E R   M E N U", LabelStyle);

            DrawButton(1, "playermod", $"G I V E   M O N E Y : {PlayerMod.moneyToGive}", buttonStyle, true);
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

            DrawButton(2, "playermod", $"G I V E   L U N A R   C O I N S : {PlayerMod.coinsToGive}", buttonStyle, true);
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

            DrawButton(3, "playermod", $"G I V E   E X P E R I E N C E : {PlayerMod.xpToGive}", buttonStyle, true);
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

            if (Main._isEditStatsOpen)
            {
                DrawButton(4, "playermod", "S T A T S   M E N U : ON", OnStyle);
            }
            else
            {
                DrawButton(4, "playermod", "S T A T S   M E N U : OFF", OffStyle);
            }

            if (Main._isChangeCharacterMenuOpen)
            {
                DrawButton(5, "playermod", "C H A N G E   C H A R A C T E R : ON", OnStyle);
            }
            else
            {
                DrawButton(5, "playermod", "C H A N G E   C H A R A C T E R : OFF", OffStyle);
            }

            if (Main._isBuffMenuOpen)
            {
                DrawButton(6, "playermod", "G I V E   B U F F   M E N U : O N", OnStyle);
            }
            else
            {
                DrawButton(6, "playermod", "G I V E   B U F F   M E N U : O F F", OffStyle);
            }

            DrawButton(7, "playermod", "R E M O V E   A L L   B U F F S", buttonStyle);

            if (Main.aimBot)
            {
                DrawButton(8, "playermod", "A I M B O T : O N", OnStyle);
            }
            else
            {
                DrawButton(8, "playermod", "A I M B O T : O F F", OffStyle);
            }

            if (Main.godToggle)
            {
                DrawButton(9, "playermod", "G O D   M O D E : O N", OnStyle);
            }
            else
            {
                DrawButton(9, "playermod", "G O D   M O D E : O F F", OffStyle);
            }

            if (Main.skillToggle)
            {
                DrawButton(10, "playermod", "I N F I N I T E   S K I L L S : O N", OnStyle);
            }
            else
            {
                DrawButton(10, "playermod", "I N F I N I T E   S K I L L S : O F F", OffStyle);
            }

            DrawButton(11, "playermod", "U N L O C K   A L L", buttonStyle);
        }

        public static void DrawMovementMenu(float x, float y, float widthSize, int mulY, GUIStyle BGstyle, GUIStyle buttonStyle, GUIStyle OnStyle, GUIStyle OffStyle, GUIStyle LabelStyle)
        {
            GUI.Box(new Rect(x + 0f, y + 0f, widthSize + 10, 50f + 45 * mulY), "", BGstyle);
            GUI.Label(new Rect(x + 5f, y + 5f, widthSize + 10, 85f), "M O V E M E N T   M E N U", LabelStyle);

            if (Main.alwaysSprint)
            {
                DrawButton(1, "movement", "A L W A Y S   S P R I N T : O N", OnStyle);
            }
            else
            {
                DrawButton(1, "movement", "A L W A Y S   S P R I N T : O F F", OffStyle);
            }

            if (Main.FlightToggle)
            {
                DrawButton(2, "movement", "F L I G H T : O N", OnStyle);
            }
            else
            {
                DrawButton(2, "movement", "F L I G H T : O F F", OffStyle);
            }

            if (Main.jumpPackToggle)
            {
                DrawButton(3, "movement", "J U M P - P A C K : O N", OnStyle);
            }
            else
            {
                DrawButton(3, "movement", "J U M P - P A C K : O F F", OffStyle);
            }
        }

        public static void DrawItemManagementMenu(float x, float y, float widthSize, int mulY, GUIStyle BGstyle, GUIStyle buttonStyle, GUIStyle OnStyle, GUIStyle OffStyle, GUIStyle LabelStyle)
        {
            GUI.Box(new Rect(x + 0f, y + 0f, widthSize + 10, 50f + 45 * mulY), "", BGstyle);
            GUI.Label(new Rect(x + 5f, y + 5f, widthSize + 5, 85f), "I T E M S   M E N U", LabelStyle);

            DrawButton(1, "itemmanager", $"G I V E   A L L   I T E M S : {ItemManager.allItemsQuantity}", buttonStyle, true);
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

            DrawButton(2, "itemmanager", $"R O L L   I T E M S : {ItemManager.itemsToRoll}", buttonStyle, true);
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
                DrawButton(3, "itemmanager", "I T E M   S P A W N   M E N U : O N", OnStyle);
            }
            else
            {
                DrawButton(3, "itemmanager", "I T E M   S P A W N   M E N U : O F F", OffStyle);
            }

            if (Main._isEquipmentSpawnMenuOpen)
            {
                DrawButton(4, "itemmanager", "E Q U I P M E N T   S P A W N   M E N U : O N", OnStyle);
            }
            else
            {
                DrawButton(4, "itemmanager", "E Q U I P M E N T   S P A W N   M E N U : O F F", OffStyle);
            }

            if (ItemManager.isDropItemForAll)
            {
                DrawButton(5, "itemmanager", "D R O P   I T E M S / E Q U I P M E N T : O N", OnStyle);
            }
            else
            {
                DrawButton(5, "itemmanager", "D R O P   I T E M S / E Q U I P M E N T : O F F", OffStyle);
            }

            if (ItemManager.isDropItemFromInventory)
            {
                DrawButton(6, "itemmanager", "D R O P   F R O M   I N V E N T O R Y : O N", OnStyle);
            }
            else
            {
                DrawButton(6, "itemmanager", "D R O P   F R O M   I N V E N T O R Y : O F F", OffStyle);
            }

            if (Main.noEquipmentCooldown)
            {
                DrawButton(7, "itemmanager", "I N F I N I T E   E Q U I P M E N T : O N", OnStyle);
            }
            else
            {
                DrawButton(7, "itemmanager", "I N F I N I T E   E Q U I P M E N T : O F F", OffStyle);
            }
            DrawButton(8, "itemmanager", "S T A C K   I N V E N T O R Y", buttonStyle);
            DrawButton(9, "itemmanager", "C L E A R   I N V E N T O R Y", buttonStyle);
        }

        public static void DrawSpawnMenu(float x, float y, float widthSize, int mulY, GUIStyle BGstyle, GUIStyle buttonStyle, GUIStyle OnStyle, GUIStyle OffStyle, GUIStyle LabelStyle)
        {
            GUI.Box(new Rect(x + 0f, y + 0f, widthSize + 10, 50f + 45 * mulY), "", BGstyle);
            GUI.Label(new Rect(x + 5f, y + 5f, widthSize + 10, 85f), "S P A W N   M E N U", LabelStyle);

            DrawButton(1, "spawn", $"M I N   D I S T A N C E : {Spawn.minDistance}", buttonStyle, true);
            if (GUI.Button(new Rect(x + widthSize - 80, y + Main.spawnBtnY, 40, 40), "-", OffStyle))
            {
                if (Spawn.minDistance > 0)
                {
                    Spawn.minDistance -= 1;
                }
            }
            if (GUI.Button(new Rect(x + widthSize - 35, y + Main.spawnBtnY, 40, 40), "+", OffStyle))
            {
                if (Spawn.minDistance < Spawn.maxDistance)
                {
                    Spawn.minDistance += 1;
                }
            }

            DrawButton(2, "spawn", $"M A X   D I S T A N C E : {Spawn.maxDistance}", buttonStyle, true);
            if (GUI.Button(new Rect(x + widthSize - 80, y + Main.spawnBtnY, 40, 40), "-", OffStyle))
            {
                if (Spawn.maxDistance > Spawn.minDistance)
                {
                    Spawn.maxDistance -= 1;
                }
            }
            if (GUI.Button(new Rect(x + widthSize - 35, y + Main.spawnBtnY, 40, 40), "+", OffStyle))
            {
                if (Spawn.maxDistance >= Spawn.minDistance)
                {
                    Spawn.maxDistance += 1;
                }
            }

            DrawButton(3, "spawn", $"T E A M : {Spawn.team[Spawn.teamIndex]}", buttonStyle, true);
            if (GUI.Button(new Rect(x + widthSize - 80, y + Main.spawnBtnY, 40, 40), "-", OffStyle))
            {
                if (Spawn.teamIndex > 0)
                {
                    Spawn.teamIndex -= 1;
                }
                else if (Spawn.teamIndex == 0)
                {
                    Spawn.teamIndex = 3;
                }
            }
            if (GUI.Button(new Rect(x + widthSize - 35, y + Main.spawnBtnY, 40, 40), "+", buttonStyle))
            {
                if (Spawn.teamIndex < 3)
                {
                    Spawn.teamIndex += 1;
                }
                else if (Spawn.teamIndex == 3)
                {
                    Spawn.teamIndex = 0;
                }
            }

            DrawButton(4, "spawn", "K I L L   A L L", buttonStyle);

            if (Main._isSpawnListMenuOpen)
            {
                DrawButton(5, "spawn", "S P A W N   L I S T: O N", OnStyle);
            }
            else
            {
                DrawButton(5, "spawn", "S P A W N   L I S T: O N", OffStyle);
            }
        }

        public static void DrawTeleMenu(float x, float y, float widthSize, int mulY, GUIStyle BGstyle, GUIStyle buttonStyle, GUIStyle LabelStyle)
        {
            GUI.Box(new Rect(x + 0f, y + 0f, widthSize + 10, 50f + 45 * mulY), "", BGstyle);
            GUI.Label(new Rect(x + 5f, y + 5f, widthSize + 5, 85f), "T E L E P O R T E R   M E N U", LabelStyle);

            DrawButton(1, "tele", "S K I P   S T A G E", buttonStyle);
            DrawButton(2, "tele", "I N S T A N T   T E L E P O R T E R", buttonStyle);
            DrawButton(3, "tele", $"A D D   M O U N T A I N - C O U N T : {TeleporterInteraction.instance.shrineBonusStacks}", buttonStyle);
            DrawButton(4, "tele", "S P A W N   A L L   P O R T A L S", buttonStyle);
            DrawButton(5, "tele", "S P A W N   B L U E   P O R T A L", buttonStyle);
            DrawButton(6, "tele", "S P A W N   C E L E S T A L   P O R T A L", buttonStyle);
            DrawButton(7, "tele", "S P A W N   G O L D   P O R T A L", buttonStyle);
        }

        public static void DrawESPMenu(float x, float y, float widthSize, int mulY, GUIStyle BGstyle, GUIStyle buttonStyle, GUIStyle OnStyle, GUIStyle OffStyle, GUIStyle LabelStyle)
        {
            GUI.Box(new Rect(x + 0f, y + 0f, widthSize + 10, 50f + 45 * mulY), "", BGstyle);
            GUI.Label(new Rect(x + 5f, y + 5f, widthSize + 5, 85f), "R E N D E R   M E N U", LabelStyle);

            if (Main.renderActiveMods)
            {
                DrawButton(1, "ESP", "A C T I V E   M O D S : O N", OnStyle);
            }
            else
            {
                DrawButton(1, "ESP", "A C T I V E   M O D S : O F F", OffStyle);
            }

            if (Main.renderInteractables)
            {
                DrawButton(2, "ESP", "I N T E R A C T A B L E S   E S P : O N", OnStyle);
            }
            else
            {
                DrawButton(2, "ESP", "I N T E R A C T A B L E S   E S P : O F F", OffStyle);
            }

            if (Main.renderMobs)
            {
                DrawButton(3, "ESP", "M O B   E S P : O N\n<color=red>Warning: May lag/crash game </color>", OnStyle);
            }
            else
            {
                DrawButton(3, "ESP", "M O B   E S P : O F F\n<color=red>Warning: May lag/crash game </color>", OffStyle);
            }
        }

        public static void DrawLobbyMenu(float x, float y, float widthSize, int mulY, GUIStyle BGstyle, GUIStyle buttonStyle, GUIStyle LabelStyle)
        {
            GUI.Box(new Rect(x + 0f, y + 0f, widthSize + 10, 50f + 45 * mulY), "", BGstyle);
            GUI.Label(new Rect(x + 5f, y + 5f, widthSize + 5, 85f), "L O B B Y   M E N U", LabelStyle);

            if (Main._CharacterCollected)
            {
                Utility.GetPlayers(Main.Players); //update this asap
                int buttonPlacement = 1;
                for (int i = 0; i < Main.Players.Length; i++)
                {
                    try
                    {
                        if (Main.Players[i] != null)
                        {
                            DrawButton(buttonPlacement, "lobby", $"K I C K  <color=yellow>{Main.Players[i]}</color>", buttonStyle);
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

        public static void CharacterWindowMethod(float x, float y, float widthSize, int mulY, GUIStyle BGstyle, GUIStyle buttonStyle, GUIStyle LabelStyle)
        {
            GUI.Box(new Rect(x + 0f, y + 0f, widthSize + 10, 50f + 45 * 15), "", BGstyle);
            GUI.Label(new Rect(x + 5f, y + 5f, widthSize + 5, 85f), "C H A R A C T E R   M E N U", LabelStyle);

            characterScrollPosition = GUI.BeginScrollView(new Rect(x + 0f, y + 0f, widthSize + 10, 50f + 45 * 15), characterScrollPosition, new Rect(x + 0f, y + 0f, widthSize + 10, 50f + 45 * mulY), false, true);
            PlayerMod.ChangeCharacter(buttonStyle, "character");
            GUI.EndScrollView();
        }

        public static void DrawStatsModMenu(float x, float y, float widthSize, int mulY, GUIStyle BGstyle, GUIStyle buttonStyle, GUIStyle OnStyle, GUIStyle OffStyle, GUIStyle LabelStyle)
        {
            GUI.Box(new Rect(x + 0f, y + 0f, widthSize + 10, 50f + 45 * mulY), "", BGstyle);
            GUI.Label(new Rect(x + 5f, y + 5f, widthSize + 10, 85f), "S T A T S   M E N U", LabelStyle);

            if (Main.damageToggle)
            {
                DrawButton(1, "statsmod", $"D A M A G E / L V L ( O N ) : {PlayerMod.damagePerLvl}", OnStyle, true);
            }
            else
            {
                DrawButton(1, "statsmod", $"D A M A G E / L V L ( O F F ) : {PlayerMod.damagePerLvl}", OffStyle, true);
            }
            if (GUI.Button(new Rect(x + widthSize - 80, y + Main.editStatsBtnY, 40, 40), "-", OffStyle))
            {
                if (PlayerMod.damagePerLvl > 0)
                    PlayerMod.damagePerLvl -= 10;
            }
            if (GUI.Button(new Rect(x + widthSize - 35, y + Main.editStatsBtnY, 40, 40), "+", OffStyle))
            {
                if (PlayerMod.damagePerLvl >= 0)
                    PlayerMod.damagePerLvl += 10;
            }

            if (Main.critToggle)
            {
                DrawButton(2, "statsmod", $"C R I T / L V L ( O N ) : {PlayerMod.CritPerLvl}", OnStyle, true);
            }
            else
            {
                DrawButton(2, "statsmod", $"C R I T / L V L ( O F F ) : {PlayerMod.CritPerLvl}", OffStyle, true);
            }
            if (GUI.Button(new Rect(x + widthSize - 80, y + Main.editStatsBtnY, 40, 40), "-", OffStyle))
            {
                if (PlayerMod.CritPerLvl > 0)
                    PlayerMod.CritPerLvl -= 1;
            }
            if (GUI.Button(new Rect(x + widthSize - 35, y + Main.editStatsBtnY, 40, 40), "+", OffStyle))
            {
                if (PlayerMod.CritPerLvl >= 0)
                    PlayerMod.CritPerLvl += 1;
            }

            if (Main.attackSpeedToggle)
            {
                DrawButton(3, "statsmod", $"A T T A C K   S P E E D ( O N ) : {PlayerMod.attackSpeed}", OnStyle, true);
            }
            else
            {
                DrawButton(3, "statsmod", $"A T T A C K   S P E E D ( O F F ) : {PlayerMod.attackSpeed}", OffStyle, true);
            }
            if (GUI.Button(new Rect(x + widthSize - 80, y + Main.editStatsBtnY, 40, 40), "-", OffStyle))
            {
                if (PlayerMod.attackSpeed > 0)
                    PlayerMod.attackSpeed -= 1;
            }
            if (GUI.Button(new Rect(x + widthSize - 35, y + Main.editStatsBtnY, 40, 40), "+", OffStyle))
            {
                if (PlayerMod.attackSpeed >= 0)
                    PlayerMod.attackSpeed += 1;
            }

            if (Main.armorToggle)
            {
                DrawButton(4, "statsmod", $"A R M O R ( O N ) : {PlayerMod.armor}", OnStyle, true);
            }
            else
            {
                DrawButton(4, "statsmod", $"A R M O R ( O F F ) : {PlayerMod.armor}", OffStyle, true);
            }
            if (GUI.Button(new Rect(x + widthSize - 80, y + Main.editStatsBtnY, 40, 40), "-", OffStyle))
            {
                if (PlayerMod.armor > 0)
                    PlayerMod.armor -= 10;
            }
            if (GUI.Button(new Rect(x + widthSize - 35, y + Main.editStatsBtnY, 40, 40), "+", OffStyle))
            {
                if (PlayerMod.armor >= 0)
                    PlayerMod.armor += 10;
            }

            if (Main.moveSpeedToggle)
            {
                DrawButton(5, "statsmod", $"M O V E   S P E E D ( O N ) : {PlayerMod.movespeed}", OnStyle, true);
            }
            else
            {
                DrawButton(5, "statsmod", $"M O V E   S P E E D ( O F F ) : {PlayerMod.movespeed}", OffStyle, true);
            }
            if (GUI.Button(new Rect(x + widthSize - 80, y + Main.editStatsBtnY, 40, 40), "-", OffStyle))
            {
                if (PlayerMod.movespeed > 7)
                    PlayerMod.movespeed -= 10;
            }
            if (GUI.Button(new Rect(x + widthSize - 35, y + Main.editStatsBtnY, 40, 40), "+", OffStyle))
            {
                if (PlayerMod.movespeed >= 7)
                    PlayerMod.movespeed += 10;
            }

            if (Main._isStatMenuOpen)
            {
                DrawButton(6, "statsmod", "S H O W   S T A T S : O N", OnStyle);
            }
            else
            {
                DrawButton(6, "statsmod", "S H O W   S T A T S : O F F", OnStyle);
            }
        }

        public static void DrawItemMenu(float x, float y, float widthSize, int mulY, GUIStyle BGstyle, GUIStyle buttonStyle, GUIStyle LabelStyle)
        {
            GUI.Box(new Rect(x + 0f, y + 0f, widthSize + 20, 50f + 45 * 15), "", BGstyle);
            GUI.Label(new Rect(x + 5f, y + 5f, widthSize + 10, 85f), "I T E M S   L I S T", LabelStyle);

            itemSpawnerScrollPosition = GUI.BeginScrollView(new Rect(x + 0f, y + 0f, widthSize + 10, 50f + 45 * 15), itemSpawnerScrollPosition, new Rect(x + 0f, y + 0f, widthSize + 10, 50f + 45 * mulY), false, true);
            ItemManager.GiveItem(buttonStyle, "itemSpawner");
            GUI.EndScrollView();
        }

        public static void DrawSpawnMobMenu(float x, float y, float widthSize, int mulY, GUIStyle BGstyle, GUIStyle buttonStyle, GUIStyle LabelStyle)
        {
            GUI.Box(new Rect(x + 0f, y + 0f, widthSize + 20, 50f + 45 * 15), "", BGstyle);
            GUI.Label(new Rect(x + 5f, y + 5f, widthSize + 10, 85f), "S P A W N   L I S T", LabelStyle);

            spawnScrollPosition = GUI.BeginScrollView(new Rect(x + 0f, y + 0f, widthSize + 10, 50f + 45 * 15), spawnScrollPosition, new Rect(x + 0f, y + 0f, widthSize + 10, 50f + 45 * mulY), false, true);
            Spawn.SpawnMob(buttonStyle, "spawnMob");
            GUI.EndScrollView();
        }

        public static void DrawEquipmentMenu(float x, float y, float widthSize, int mulY, GUIStyle BGstyle, GUIStyle buttonStyle, GUIStyle LabelStyle, GUIStyle offStyle)
        {
            GUI.Box(new Rect(x + 0f, y + 0f, widthSize + 20, 50f + 45 * 15), "", BGstyle);
            GUI.Label(new Rect(x + 5f, y + 5f, widthSize + 10, 85f), "E Q U I P M E N T   L I S T", LabelStyle);

            equipmentSpawnerScrollPosition = GUI.BeginScrollView(new Rect(x + 0f, y + 0f, widthSize + 10, 50f + 45 * 15), equipmentSpawnerScrollPosition, new Rect(x + 0f, y + 0f, widthSize + 10, 50f + 45 * mulY), false, true);
            ItemManager.GiveEquipment(buttonStyle, "equipmentSpawner");
            GUI.EndScrollView();
        }

        public static void DrawBuffMenu(float x, float y, float widthSize, int mulY, GUIStyle BGstyle, GUIStyle buttonStyle, GUIStyle LabelStyle, GUIStyle offStyle)
        {
            GUI.Box(new Rect(x + 0f, y + 0f, widthSize + 20, 50f + 45 * 15), "", BGstyle);
            GUI.Label(new Rect(x + 5f, y + 5f, widthSize + 10, 85f), "B U F F S   L I S T", LabelStyle);

            buffMenuScrollPosition = GUI.BeginScrollView(new Rect(x + 0f, y + 0f, widthSize + 10, 50f + 45 * 15), buffMenuScrollPosition, new Rect(x + 0f, y + 0f, widthSize + 10, 50f + 45 * mulY), false, true);
            PlayerMod.GiveBuff(buttonStyle, "giveBuff");
            GUI.EndScrollView();
        }

        public static void DrawStatsMenu(float x, float y, float widthSize, int mulY, GUIStyle BGstyle, GUIStyle buttonStyle, GUIStyle LabelStyle)
        {
            GUI.Box(new Rect(x + 0f, y + 0f, widthSize, 50f + 45 * mulY), "", BGstyle);
            GUI.Label(new Rect(x + 5f, y + 5f, widthSize + 5, 50f), "S T A T S   M E N U", LabelStyle);

            DrawButton(1, "stats", $"D A M A G E : {Main.LocalPlayerBody.damage}", buttonStyle, justText: true);
            DrawButton(2, "stats", $"C R I T : {Main.LocalPlayerBody.crit}", buttonStyle, justText: true);
            DrawButton(3, "stats", $"A T T A C K   S P E E D : {Main.LocalPlayerBody.attackSpeed}", buttonStyle, justText: true);
            DrawButton(4, "stats", $"A R M O R : {Main.LocalPlayerBody.armor}", buttonStyle, justText: true);
            DrawButton(5, "stats", $"R E G E N : {Main.LocalPlayerBody.regen}", buttonStyle, justText: true);
            DrawButton(6, "stats", $"M O V E   S P E E D : {Main.LocalPlayerBody.moveSpeed}", buttonStyle, justText: true);
            DrawButton(7, "stats", $"J U M P   C O U N T : {Main.LocalPlayerBody.maxJumpCount}", buttonStyle, justText: true);
            DrawButton(8, "stats", $"E X P E R I E N C E : {Main.LocalPlayerBody.experience}", buttonStyle, justText: true);
            DrawButton(9, "stats", $"K I L L S: {Main.LocalPlayerBody.killCount}", buttonStyle, justText: true);

        }

        public static void DrawButton(int position, string id, string text, GUIStyle defaultStyle, bool isMultButton = false, bool justText = false)
        {
            Rect rect;
            GUIStyle highlighted = Main.HighlightBtnStyle;
            float menuIndex;
            int intraMenuIndex = position - 1;
            switch (id)
            {
                case "main":
                    {
                        menuIndex = 0;
                        Main.MainMulY = position;
                        if (isMultButton)
                        {
                            rect = new Rect(Main.mainRect.x + 5, Main.mainRect.y + 5 + 45 * position, Main.widthSize - 90, 40);
                        }
                        else
                        {
                            rect = new Rect(Main.mainRect.x + 5, Main.mainRect.y + 5 + 45 * position, Main.widthSize, 40);
                        }
                        break;
                    }

                case "playermod":
                    {
                        menuIndex = 1;
                        Main.PlayerModMulY = position;
                        Main.PlayerModBtnY = 5 + 45 * position;
                        if (isMultButton)
                        {
                            rect = new Rect(Main.playerModRect.x + 5, Main.playerModRect.y + 5 + 45 * position, Main.widthSize - 90, 40);
                        }
                        else
                        {
                            rect = new Rect(Main.playerModRect.x + 5, Main.playerModRect.y + 5 + 45 * position, Main.widthSize, 40);
                        }
                        break;
                    }

                case "character":
                    {
                        menuIndex = 1.1f;
                        Main.CharacterMulY = position;
                        if (isMultButton)
                        {
                            rect = new Rect(Main.characterRect.x + 5, Main.characterRect.y + 5 + 45 * position, Main.widthSize - 90, 40);
                        }
                        else
                        {
                            rect = new Rect(Main.characterRect.x + 5, Main.characterRect.y + 5 + 45 * position, Main.widthSize, 40);
                        }
                        break;
                    }

                case "giveBuff":
                    {
                        menuIndex = 1.2f;
                        Main.buffMenuMulY = position;
                        if (isMultButton)
                        {
                            rect = new Rect(Main.buffMenuRect.x + 5, Main.buffMenuRect.y + 5 + 45 * position, Main.widthSize - 90, 40);
                        }
                        else
                        {
                            rect = new Rect(Main.buffMenuRect.x + 5, Main.buffMenuRect.y + 5 + 45 * position, Main.widthSize, 40);
                        }
                        break;
                    }

                case "statsmod":
                    {
                        menuIndex = 1.3f;
                        Main.editStatsMulY = position;
                        Main.editStatsBtnY = 5 + 45 * position;
                        if (isMultButton)
                        {
                            rect = new Rect(Main.editStatsRect.x + 5, Main.editStatsRect.y + 5 + 45 * position, Main.widthSize - 90, 40);
                        }
                        else
                        {
                            rect = new Rect(Main.editStatsRect.x + 5, Main.editStatsRect.y + 5 + 45 * position, Main.widthSize, 40);
                        }
                        break;
                    }

                case "stats":
                    {
                        menuIndex = 8f;
                        Main.StatMulY = position;
                        if (isMultButton)
                        {
                            rect = new Rect(Main.statRect.x + 5, Main.statRect.y + 5 + 45 * position, Main.widthSize - 90, 40);
                        }
                        else
                        {
                            rect = new Rect(Main.statRect.x + 5, Main.statRect.y + 5 + 45 * position, Main.widthSize, 40);
                        }
                        break;
                    }

                case "movement":
                    {
                        menuIndex = 2f;
                        Main.movementMulY = position;
                        if (isMultButton)
                        {
                            rect = new Rect(Main.movementRect.x + 5, Main.movementRect.y + 5 + 45 * position, Main.widthSize - 90, 40);
                        }
                        else
                        {
                            rect = new Rect(Main.movementRect.x + 5, Main.movementRect.y + 5 + 45 * position, Main.widthSize, 40);
                        }
                        break;
                    }

                case "itemmanager":
                    {
                        menuIndex = 3f;
                        Main.ItemManagerMulY = position;
                        Main.ItemManagerBtnY = 5 + 45 * position;
                        if (isMultButton)
                        {
                            rect = new Rect(Main.itemManagerRect.x + 5, Main.itemManagerRect.y + 5 + 45 * position, Main.widthSize - 90, 40);
                        }
                        else
                        {
                            rect = new Rect(Main.itemManagerRect.x + 5, Main.itemManagerRect.y + 5 + 45 * position, Main.widthSize, 40);
                        }
                        break;
                    }

                case "itemSpawner":
                    {
                        menuIndex = 3.1f;
                        Main.itemSpawnerMulY = position;
                        if (isMultButton)
                        {
                            rect = new Rect(Main.itemSpawnerRect.x + 5, Main.itemSpawnerRect.y + 5 + 45 * position, Main.widthSize - 90, 40);
                        }
                        else
                        {
                            rect = new Rect(Main.itemSpawnerRect.x + 5, Main.itemSpawnerRect.y + 5 + 45 * position, Main.widthSize, 40);
                        }
                        break;
                    }

                case "equipmentSpawner":
                    {
                        menuIndex = 3.2f;
                        Main.equipmentSpawnerMulY = position;
                        if (isMultButton)
                        {
                            rect = new Rect(Main.equipmentSpawnerRect.x + 5, Main.equipmentSpawnerRect.y + 5 + 45 * position, Main.widthSize - 90, 40);
                        }
                        else
                        {
                            rect = new Rect(Main.equipmentSpawnerRect.x + 5, Main.equipmentSpawnerRect.y + 5 + 45 * position, Main.widthSize, 40);
                        }
                        break;
                    }

                case "spawn":
                    {
                        menuIndex = 4f;
                        Main.spawnMulY = position;
                        Main.spawnBtnY = 5 + 45 * position;
                        if (isMultButton)
                        {
                            rect = new Rect(Main.spawnRect.x + 5, Main.spawnRect.y + 5 + 45 * position, Main.widthSize - 90, 40);
                        }
                        else
                        {
                            rect = new Rect(Main.spawnRect.x + 5, Main.spawnRect.y + 5 + 45 * position, Main.widthSize, 40);
                        }
                        break;
                    }

                case "spawnMob":
                    {
                        menuIndex = 4.1f;
                        Main.spawnListMulY = position;
                        if (isMultButton)
                        {
                            rect = new Rect(Main.spawnListRect.x + 5, Main.spawnListRect.y + 5 + 45 * position, Main.widthSize - 90, 40);
                        }
                        else
                        {
                            rect = new Rect(Main.spawnListRect.x + 5, Main.spawnListRect.y + 5 + 45 * position, Main.widthSize, 40);
                        }
                        break;
                    }

                case "tele":
                    {
                        menuIndex = 5f;
                        Main.TeleMulY = position;
                        if (isMultButton)
                        {
                            rect = new Rect(Main.teleRect.x + 5, Main.teleRect.y + 5 + 45 * position, Main.widthSize - 90, 40);
                        }
                        else
                        {
                            rect = new Rect(Main.teleRect.x + 5, Main.teleRect.y + 5 + 45 * position, Main.widthSize, 40);
                        }
                        break;
                    }

                case "ESP":
                    {
                        menuIndex = 6f;
                        Main.ESPMulY = position;
                        if (isMultButton)
                        {
                            rect = new Rect(Main.ESPRect.x + 5, Main.ESPRect.y + 5 + 45 * position, Main.widthSize - 90, 40);
                        }
                        else
                        {
                            rect = new Rect(Main.ESPRect.x + 5, Main.ESPRect.y + 5 + 45 * position, Main.widthSize, 40);
                        }
                        break;
                    }

                case "lobby":
                    {
                        menuIndex = 7f;
                        Main.LobbyMulY = position;
                        if (isMultButton)
                        {
                            rect = new Rect(Main.lobbyRect.x + 5, Main.lobbyRect.y + 5 + 45 * position, Main.widthSize - 90, 40);
                        }
                        else
                        {
                            rect = new Rect(Main.lobbyRect.x + 5, Main.lobbyRect.y + 5 + 45 * position, Main.widthSize, 40);
                        }
                        break;
                    }

                default:
                    {
                        menuIndex = 0;
                        rect = new Rect(Main.mainRect.x + 5, Main.mainRect.y + 5 + 45 * position, Main.widthSize - 90, 40);
                        break;
                    }
            }

            if (justText)
            {
                GUI.Button(rect, text, defaultStyle);
            }
            else
            {
                if (GUI.Button(rect, text, Navigation.HighlighedCheck(defaultStyle, highlighted, menuIndex, position)))
                {
                    Navigation.PressBtn(menuIndex, intraMenuIndex);
                }
            }



        }
    }
}