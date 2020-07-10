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

        public static void DrawNotCollectedMenu(GUIStyle buttonStyle, GUIStyle OnStyle, GUIStyle OffStyle)
        {
            GUI.Button(btn.BtnRect(2, false, "main"), "<color=yellow>Buttons will be availble in game.</color>", buttonStyle);
            GUI.Button(btn.BtnRect(3, false, "main"), "<color=#11ccee>Created By Neonix#1337.\n Feel Free to Message me on discord</color>", buttonStyle);
            GUI.Button(btn.BtnRect(4, false, "main"), "<color=#11ccee>with bug Reports or suggestions.</color>", buttonStyle);
        }

        public static void DrawMainMenu(float x, float y, float widthSize, float mulY, GUIStyle BGstyle, GUIStyle OnStyle, GUIStyle OffStyle, GUIStyle BtnStyle, GUIStyle Highlighted)
        {
            if (Main._isPlayerMod)
            {
                if (GUI.Button(btn.BtnRect(1, false, "main"), "P L A Y E R   M O D I F I C A T I O N S : O N", Navigation.HighlighedCheck(OnStyle, Highlighted, 0, 1)))
                {
                    Main._isPlayerMod = false;
                    Navigation.menuIndex = Navigation.prevMenuIndex;
                }
            }
            else if (GUI.Button(btn.BtnRect(1, false, "main"), "P L A Y E R   M O D I F I C A T I O N S : O F F", Navigation.HighlighedCheck(OffStyle, Highlighted, 0, 1)))
            {
                Main._isPlayerMod = true;
                Navigation.prevMenuIndex = (int)Navigation.menuIndex;
                Navigation.menuIndex = 1;
            }

            if (Main._isItemManagerOpen)
            {
                if (GUI.Button(btn.BtnRect(2, false, "main"), "I T E M   M A N A G E M E N T : ON", Navigation.HighlighedCheck(OnStyle, Highlighted, 0, 2)))
                {
                    Main._isItemManagerOpen = false;
                    Navigation.menuIndex = Navigation.prevMenuIndex;
                }
            }
            else if (GUI.Button(btn.BtnRect(2, false, "main"), "I T E M   M A N A G E M E N T : O F F", Navigation.HighlighedCheck(OffStyle, Highlighted, 0, 2)))
            {
                Main._isItemManagerOpen = true;
                Navigation.prevMenuIndex = (int)Navigation.menuIndex;
                Navigation.menuIndex = 2;
            }
            if (Main._isTeleMenuOpen)
            {
                if (GUI.Button(btn.BtnRect(3, false, "main"), "T E L E P O R T E R : O N", Navigation.HighlighedCheck(OnStyle, Highlighted, 0, 3)))
                {
                    Main._isTeleMenuOpen = false;
                    Navigation.menuIndex = Navigation.prevMenuIndex;
                }
            }
            else if (GUI.Button(btn.BtnRect(3, false, "main"), "T E L E P O R T E R : O F F", Navigation.HighlighedCheck(OffStyle, Highlighted, 0, 3)))
            {
                Main._isTeleMenuOpen = true;
                Navigation.prevMenuIndex = (int)Navigation.menuIndex;
                Navigation.menuIndex = 3;
            }
            if (Main._isESPMenuOpen)
            {
                if (GUI.Button(btn.BtnRect(4, false, "main"), "R E N D E R : O N", Navigation.HighlighedCheck(OnStyle, Highlighted, 0, 4)))
                {
                    Main._isESPMenuOpen = false;
                    Navigation.menuIndex = Navigation.prevMenuIndex;
                }
            }
            else if (GUI.Button(btn.BtnRect(4, false, "main"), "R E N D E R : O F F", Navigation.HighlighedCheck(OffStyle, Highlighted, 0, 4)))
            {
                Main._isESPMenuOpen = true;
                Navigation.prevMenuIndex = (int)Navigation.menuIndex;
                Navigation.menuIndex = 4;
            }
            if (Main._isLobbyMenuOpen)
            {
                if (GUI.Button(btn.BtnRect(5, false, "main"), "L O B B Y   M A N A G E M E N T : O N", Navigation.HighlighedCheck(OnStyle, Highlighted, 0, 5)))
                {
                    Main._isLobbyMenuOpen = false;
                    Navigation.menuIndex = Navigation.prevMenuIndex;
                }
            }
            else if (GUI.Button(btn.BtnRect(5, false, "main"), "L O B B Y   M A N A G E M E N T : O F F", Navigation.HighlighedCheck(OffStyle, Highlighted, 0, 5)))
            {
                Main._isLobbyMenuOpen = true;
                Navigation.prevMenuIndex = (int)Navigation.menuIndex;
                Navigation.menuIndex = 5;
            }
        }

        public static void DrawPlayerModMenu(float x, float y, float widthSize, int mulY, GUIStyle BGstyle, GUIStyle buttonStyle, GUIStyle OnStyle, GUIStyle OffStyle, GUIStyle LabelStyle, GUIStyle Highlighted)
        {
            GUI.Box(new Rect(x + 0f, y + 0f, widthSize + 10, 50f + 45 * mulY), "", BGstyle);
            GUI.Label(new Rect(x + 5f, y + 5f, widthSize + 5, 85f), "P L A Y E R   M O D I F I C A T I O N   M E N U", LabelStyle);

            if (GUI.Button(btn.BtnRect(1, true, "playermod"), "G I V E   M O N E Y : " + PlayerMod.moneyToGive.ToString(), Navigation.HighlighedCheck(buttonStyle, Highlighted, 1, 1)))
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
            if (GUI.Button(btn.BtnRect(2, true, "playermod"), "G I V E   L U N A R   C O I N S : " + PlayerMod.coinsToGive.ToString(), Navigation.HighlighedCheck(buttonStyle, Highlighted, 1, 2)))
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
            if (GUI.Button(btn.BtnRect(3, true, "playermod"), "G I V E   E X P E R I E N C E : " + PlayerMod.xpToGive.ToString(), Navigation.HighlighedCheck(buttonStyle, Highlighted, 1, 3)))
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
                if (GUI.Button(btn.BtnRect(4, true, "playermod"), "D A M A G E / L V L ( O N ) : " + PlayerMod.damagePerLvl.ToString(), Navigation.HighlighedCheck(OnStyle, Highlighted, 1, 4)))
                {
                    Main.damageToggle = false;
                }
            }
            else if (GUI.Button(btn.BtnRect(4, true, "playermod"), "D A M A G E / L V L ( O F F ) : " + PlayerMod.damagePerLvl.ToString(), Navigation.HighlighedCheck(OffStyle, Highlighted, 1, 4)))
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
                if (GUI.Button(btn.BtnRect(5, true, "playermod"), "C R I T / L V L ( O N ) : " + PlayerMod.CritPerLvl.ToString(), Navigation.HighlighedCheck(OnStyle, Highlighted, 1, 5)))
                {
                    Main.critToggle = false;
                }
            }
            else if (GUI.Button(btn.BtnRect(5, true, "playermod"), "C R I T / L V L ( O F F ) : " + PlayerMod.CritPerLvl.ToString(), Navigation.HighlighedCheck(OffStyle, Highlighted, 1, 5)))
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
                if (GUI.Button(btn.BtnRect(6, true, "playermod"), "A T T A C K   S P E E D ( O N ) : " + PlayerMod.attackSpeed.ToString(), Navigation.HighlighedCheck(OnStyle, Highlighted, 1, 6)))
                {
                    Main.attackSpeedToggle = false;
                }
            }
            else if (GUI.Button(btn.BtnRect(6, true, "playermod"), "A T T A C K   S P E E D ( O F F ) : " + PlayerMod.attackSpeed.ToString(), Navigation.HighlighedCheck(OffStyle, Highlighted, 1, 6)))
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
                if (GUI.Button(btn.BtnRect(7, true, "playermod"), "A R M O R ( O N ) : " + PlayerMod.armor.ToString(), Navigation.HighlighedCheck(OnStyle, Highlighted, 1, 7)))
                {
                    Main.armorToggle = false;
                }
            }
            else if (GUI.Button(btn.BtnRect(7, true, "playermod"), "A R M O R ( O F F ) : " + PlayerMod.armor.ToString(), Navigation.HighlighedCheck(OffStyle, Highlighted, 1, 7)))
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
                if (GUI.Button(btn.BtnRect(8, true, "playermod"), "M O V E   S P E E D ( O N ) : " + PlayerMod.movespeed.ToString(), Navigation.HighlighedCheck(OnStyle, Highlighted, 1, 8)))
                {
                    Main.moveSpeedToggle = false;
                }
            }
            else if (GUI.Button(btn.BtnRect(8, true, "playermod"), "M O V E   S P E E D ( O F F ) : " + PlayerMod.movespeed.ToString(), Navigation.HighlighedCheck(OffStyle, Highlighted, 1, 8)))
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
            if (Main._isChangeCharacterMenuOpen)
            {
                if (GUI.Button(btn.BtnRect(9, false, "playermod"), "C H A N G E   C H A R A C T E R : ON", Navigation.HighlighedCheck(OnStyle, Highlighted, 1, 9)))
                {
                    Main._isChangeCharacterMenuOpen = false;
                }
            }
            else if (GUI.Button(btn.BtnRect(9, false, "playermod"), "C H A N G E   C H A R A C T E R : OFF", Navigation.HighlighedCheck(OffStyle, Highlighted, 1, 9)))
            {
                Main._isChangeCharacterMenuOpen = true;
            }
            if (Main._isStatMenuOpen)
            {
                if (GUI.Button(btn.BtnRect(10, false, "playermod"), "S H O W   S T A T S : O N", Navigation.HighlighedCheck(OnStyle, Highlighted, 1, 10)))
                {
                    Main._isStatMenuOpen = false;
                }
            }
            else if (GUI.Button(btn.BtnRect(10, false, "playermod"), "S H O W   S T A T S : O F F", Navigation.HighlighedCheck(OffStyle, Highlighted, 1, 10)))
            {
                Main._isStatMenuOpen = true;
            }
            if (Main._isBuffMenuOpen)
            {
                if (GUI.Button(btn.BtnRect(11, false, "playermod"), "G I V E   B U F F   M E N U : O N", Navigation.HighlighedCheck(OnStyle, Highlighted, 1, 11)))
                {
                    Main._isBuffMenuOpen = false;
                }
            }
            else if (GUI.Button(btn.BtnRect(11, false, "playermod"), "G I V E   B U F F   M E N U : O F F", Navigation.HighlighedCheck(OffStyle, Highlighted, 1, 11)))
            {
                Main._isBuffMenuOpen = true;
            }
            if (GUI.Button(btn.BtnRect(12, false, "playermod"), "R E M O V E   A L L   B U F F S", Navigation.HighlighedCheck(buttonStyle, Highlighted, 1, 12)))
            {
                PlayerMod.RemoveAllBuffs();
            }
            if (Main.aimBot)
            {
                if (GUI.Button(btn.BtnRect(13, false, "playermod"), "A I M B O T : O N", Navigation.HighlighedCheck(OnStyle, Highlighted, 1, 13)))
                {
                    EntityStates.FireNailgun.spreadPitchScale = 0.5f;
                    EntityStates.FireNailgun.spreadYawScale = 1f;
                    EntityStates.FireNailgun.spreadBloomValue = 0.2f;
                    Main.aimBot = false;
                }
            }
            else if (!Main.aimBot)
            {
                if (GUI.Button(btn.BtnRect(13, false, "playermod"), "A I M B O T : O F F", Navigation.HighlighedCheck(OffStyle, Highlighted, 1, 13)))
                {
                    EntityStates.FireNailgun.spreadPitchScale = 0;
                    EntityStates.FireNailgun.spreadYawScale = 0;
                    EntityStates.FireNailgun.spreadBloomValue = 0;
                    Main.aimBot = true;
                }
            }
            if (Main.alwaysSprint)
            {
                if (GUI.Button(btn.BtnRect(14, false, "playermod"), "A L W A Y S   S P R I N T : O N", Navigation.HighlighedCheck(OnStyle, Highlighted, 1, 14)))
                {
                    Main.alwaysSprint = false;
                }
            }
            else if (!Main.alwaysSprint)
            {
                if (GUI.Button(btn.BtnRect(14, false, "playermod"), "A L W A Y S   S P R I N T : O F F", Navigation.HighlighedCheck(OffStyle, Highlighted, 1, 14)))
                {
                    Main.alwaysSprint = true;
                }
            }
            if (Main.FlightToggle)
            {
                if (GUI.Button(btn.BtnRect(15, false, "playermod"), "F L I G H T : O N", Navigation.HighlighedCheck(OnStyle, Highlighted, 1, 15)))
                {
                    if (PlayerMod.GetCurrentCharacter().ToString() != "Loader")
                    {
                        Main.LocalPlayerBody.bodyFlags &= CharacterBody.BodyFlags.None;
                    }
                    Main.FlightToggle = false;
                }
            }
            else if (GUI.Button(btn.BtnRect(15, false, "playermod"), "F L I G H T : O F F", Navigation.HighlighedCheck(OffStyle, Highlighted, 1, 15)))
            {
                Main.FlightToggle = true;
            }
            if (Main.godToggle)
            {
                if (GUI.Button(btn.BtnRect(16, false, "playermod"), "G O D   M O D E : O N", Navigation.HighlighedCheck(OnStyle, Highlighted, 1, 16)))
                {
                    Main.godToggle = false;
                }
            }
            else if (GUI.Button(btn.BtnRect(16, false, "playermod"), "G O D   M O D E : O F F", Navigation.HighlighedCheck(OffStyle, Highlighted, 1, 16)))
            {
                Main.godToggle = true;
            }
            if (Main.skillToggle)
            {
                if (GUI.Button(btn.BtnRect(17, false, "playermod"), "I N F I N I T E   S K I L L S : O N", Navigation.HighlighedCheck(OnStyle, Highlighted, 1, 17)))
                {
                    Main.skillToggle = false;
                }
            }
            else if (GUI.Button(btn.BtnRect(17, false, "playermod"), "I N F I N I T E   S K I L L S : O F F", Navigation.HighlighedCheck(OffStyle, Highlighted, 1, 17)))
            {
                Main.skillToggle = true;
            }
            if (GUI.Button(btn.BtnRect(18, false, "playermod"), "U N L O C K   A L L", Navigation.HighlighedCheck(buttonStyle, Highlighted, 1, 18)))
            {
                PlayerMod.UnlockAll();
            }
        }

        public static void DrawItemManagementMenu(float x, float y, float widthSize, int mulY, GUIStyle BGstyle, GUIStyle buttonStyle, GUIStyle OnStyle, GUIStyle OffStyle, GUIStyle LabelStyle, GUIStyle Highlighted)
        {
            GUI.Box(new Rect(x + 0f, y + 0f, widthSize + 10, 50f + 45 * mulY), "", BGstyle);
            GUI.Label(new Rect(x + 5f, y + 5f, widthSize + 5, 85f), "I T E M   M A N A G E M E N T   M E N U", LabelStyle);

            if (GUI.Button(btn.BtnRect(1, true, "itemmanager"), "G I V E   A L L   I T E M S : " + ItemManager.allItemsQuantity.ToString(), Navigation.HighlighedCheck(buttonStyle, Highlighted, 2, 1)))
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
            if (GUI.Button(btn.BtnRect(2, true, "itemmanager"), "R O L L   I T E M S : " + ItemManager.itemsToRoll.ToString(), Navigation.HighlighedCheck(buttonStyle, Highlighted, 2, 2)))
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
                if (GUI.Button(btn.BtnRect(3, false, "itemmanager"), "I T E M   S P A W N   M E N U : O N", Navigation.HighlighedCheck(OnStyle, Highlighted, 2, 3)))
                {
                    Main._isItemSpawnMenuOpen = false;
                }
            }
            else if (GUI.Button(btn.BtnRect(3, false, "itemmanager"), "I T E M   S P A W N   M E N U : O F F", Navigation.HighlighedCheck(OffStyle, Highlighted, 2, 3)))
            {
                Main._isItemSpawnMenuOpen = true;
            }
            if (Main._isEquipmentSpawnMenuOpen)
            {
                Main._isItemSpawnMenuOpen = false;
                if (GUI.Button(btn.BtnRect(4, false, "itemmanager"), "E Q U I P M E N T   S P A W N   M E N U : O N", Navigation.HighlighedCheck(OnStyle, Highlighted, 2, 4)))
                {
                    Main._isEquipmentSpawnMenuOpen = false;
                }
            }
            else if (GUI.Button(btn.BtnRect(4, false, "itemmanager"), "E Q U I P M E N T   S P A W N   M E N U : O F F", Navigation.HighlighedCheck(OffStyle, Highlighted, 2, 4)))
            {
                Main._isEquipmentSpawnMenuOpen = true;
            }
            if (ItemManager.isDropItemForAll)
            {
                if (GUI.Button(btn.BtnRect(5, false, "itemmanager"), "D R O P   I T E M S / E Q U I P M E N T : O N", Navigation.HighlighedCheck(OnStyle, Highlighted, 2, 5)))
                {
                    ItemManager.isDropItemForAll = false;
                }
            }
            else if (GUI.Button(btn.BtnRect(5, false, "itemmanager"), "D R O P   I T E M S / E Q U I P M E N T : O F F", Navigation.HighlighedCheck(OffStyle, Highlighted, 2, 5)))
            {
                ItemManager.isDropItemForAll = true;
                ItemManager.isDropItemFromInventory = false;
            }
            if (ItemManager.isDropItemFromInventory)
            {
                if (GUI.Button(btn.BtnRect(6, false, "itemmanager"), "D R O P   F R O M   I N V E N T O R Y : O N", Navigation.HighlighedCheck(OnStyle, Highlighted, 2, 6)))
                {
                    ItemManager.isDropItemFromInventory = false;
                }
            }
            else if (GUI.Button(btn.BtnRect(6, false, "itemmanager"), "D R O P   F R O M   I N V E N T O R Y : O F F", Navigation.HighlighedCheck(OffStyle, Highlighted, 2, 6)))
            {
                ItemManager.isDropItemFromInventory = true;
                ItemManager.isDropItemForAll = false;
            }
            if (Main.noEquipmentCooldown)
            {
                if (GUI.Button(btn.BtnRect(7, false, "itemmanager"), "I N F I N I T E   E Q U I P M E N T : O N", Navigation.HighlighedCheck(OnStyle, Highlighted, 2, 7)))
                {
                    Main.noEquipmentCooldown = false;
                }
            }
            else if (GUI.Button(btn.BtnRect(7, false, "itemmanager"), "I N F I N I T E   E Q U I P M E N T : O F F", Navigation.HighlighedCheck(OffStyle, Highlighted, 2, 7)))
            {
                Main.noEquipmentCooldown = true;
            }
            if (GUI.Button(btn.BtnRect(8, false, "itemmanager"), "S T A C K   I N V E N T O R Y", Navigation.HighlighedCheck(buttonStyle, Highlighted, 2, 8)))
            {
                ItemManager.StackInventory();
            }
            if (GUI.Button(btn.BtnRect(9, false, "itemmanager"), "C L E A R   I N V E N T O R Y", Navigation.HighlighedCheck(buttonStyle, Highlighted, 2, 9)))
            {
                ItemManager.ClearInventory();
            }
        }

        public static void DrawTeleMenu(float x, float y, float widthSize, int mulY, GUIStyle BGstyle, GUIStyle buttonStyle, GUIStyle LabelStyle, GUIStyle Highlighted)
        {
            GUI.Box(new Rect(x + 0f, y + 0f, widthSize + 10, 50f + 45 * mulY), "", BGstyle);
            GUI.Label(new Rect(x + 5f, y + 5f, widthSize + 5, 85f), "T E L E P O R T E R   M E N U", LabelStyle);

            if (GUI.Button(btn.BtnRect(1, false, "tele"), "S K I P   S T A G E", Navigation.HighlighedCheck(buttonStyle, Highlighted, 3, 1)))
                Teleporter.skipStage();
            if (GUI.Button(btn.BtnRect(2, false, "tele"), "I N S T A N T   T E L E P O R T E R", Navigation.HighlighedCheck(buttonStyle, Highlighted, 3, 2)))
                Teleporter.InstaTeleporter();
            if (GUI.Button(btn.BtnRect(3, false, "tele"), "A D D   M O U N T A I N - C O U N T : " + TeleporterInteraction.instance.shrineBonusStacks.ToString(), Navigation.HighlighedCheck(buttonStyle, Highlighted, 3, 3)))
                Teleporter.addMountain();
            if (GUI.Button(btn.BtnRect(4, false, "tele"), "S P A W N   A L L   P O R T A L S", Navigation.HighlighedCheck(buttonStyle, Highlighted, 3, 4)))
                Teleporter.SpawnPortals("all");
            if (GUI.Button(btn.BtnRect(5, false, "tele"), "S P A W N   B L U E   P O R T A L", Navigation.HighlighedCheck(buttonStyle, Highlighted, 3, 5)))
                Teleporter.SpawnPortals("newt");
            if (GUI.Button(btn.BtnRect(6, false, "tele"), "S P A W N   C E L E S T A L   P O R T A L", Navigation.HighlighedCheck(buttonStyle, Highlighted, 3, 6)))
                Teleporter.SpawnPortals("blue");
            if (GUI.Button(btn.BtnRect(7, false, "tele"), "S P A W N   G O L D   P O R T A L", Navigation.HighlighedCheck(buttonStyle, Highlighted, 3, 7)))
                Teleporter.SpawnPortals("gold");
        }

        public static void DrawESPMenu(float x, float y, float widthSize, int mulY, GUIStyle BGstyle, GUIStyle buttonStyle, GUIStyle OnStyle, GUIStyle OffStyle, GUIStyle LabelStyle, GUIStyle Highlighted)
        {
            GUI.Box(new Rect(x + 0f, y + 0f, widthSize + 10, 50f + 45 * mulY), "", BGstyle);
            GUI.Label(new Rect(x + 5f, y + 5f, widthSize + 5, 85f), "R E N D E R   M E N U", LabelStyle);

            if (Main.renderActiveMods)
            {
                if (GUI.Button(btn.BtnRect(1, false, "ESP"), "A C T I V E   M O D S : O N", Navigation.HighlighedCheck(OnStyle, Highlighted, 4, 1)))
                {
                    Main.renderActiveMods = false;
                }
            }
            else if (GUI.Button(btn.BtnRect(1, false, "ESP"), "A C T I V E   M O D S : O F F", Navigation.HighlighedCheck(OffStyle, Highlighted, 4, 1)))
            {
                Main.renderActiveMods = true;
            }
            if (Main.renderInteractables)
            {
                if (GUI.Button(btn.BtnRect(2, false, "ESP"), "I N T E R A C T A B L E S   E S P : O N", Navigation.HighlighedCheck(OnStyle, Highlighted, 4, 2)))
                {
                    Main.renderInteractables = false;
                }
            }
            else if (GUI.Button(btn.BtnRect(2, false, "ESP"), "I N T E R A C T A B L E S   E S P : O F F", Navigation.HighlighedCheck(OffStyle, Highlighted, 4, 2)))
            {
                Main.renderInteractables = true;
            }
            if (Main.renderMobs)
            {
                if (GUI.Button(btn.BtnRect(3, false, "ESP"), "M O B   E S P : O N\n<color=red>Warning: May lag/crash game </color>", Navigation.HighlighedCheck(OnStyle, Highlighted, 4, 3)))
                {
                    Main.renderMobs = false;
                }
            }
            else if (GUI.Button(btn.BtnRect(3, false, "ESP"), "M O B   E S P : O F F\n<color=red>Warning: May lag/crash game </color>", Navigation.HighlighedCheck(OffStyle, Highlighted, 4, 3)))
            {
                Main.renderMobs = true;
            }
        }

        public static void DrawLobbyMenu(float x, float y, float widthSize, int mulY, GUIStyle BGstyle, GUIStyle buttonStyle, GUIStyle LabelStyle, GUIStyle Highlighted)
        {
            GUI.Box(new Rect(x + 0f, y + 0f, widthSize + 10, 50f + 45 * mulY), "", BGstyle);
            GUI.Label(new Rect(x + 5f, y + 5f, widthSize + 5, 85f), "L O B B Y   M A N A G E M E N T   M E N U", LabelStyle);

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
                            if (GUI.Button(btn.BtnRect(buttonPlacement, false, "lobby"), $"K I C K  <color=yellow>{Main.Players[i]}</color>", Navigation.HighlighedCheck(buttonStyle, Highlighted, 5, buttonPlacement)))
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

        public static void CharacterWindowMethod(float x, float y, float widthSize, int mulY, GUIStyle BGstyle, GUIStyle buttonStyle, GUIStyle LabelStyle, GUIStyle Highlighted)
        {
            GUI.Box(new Rect(x + 0f, y + 0f, widthSize + 10, 50f + 45 * 15), "", BGstyle);
            GUI.Label(new Rect(x + 5f, y + 5f, widthSize + 5, 85f), "C H A R A C T E R   M E N U", LabelStyle);

            characterScrollPosition = GUI.BeginScrollView(new Rect(x + 0f, y + 0f, widthSize + 10, 50f + 45 * 15), characterScrollPosition, new Rect(x + 0f, y + 0f, widthSize + 10, 50f + 45 * mulY), false, true);
            PlayerMod.ChangeCharacter(buttonStyle, Highlighted, "character");
            GUI.EndScrollView();
        }

        public static void DrawItemMenu(float x, float y, float widthSize, int mulY, GUIStyle BGstyle, GUIStyle buttonStyle, GUIStyle LabelStyle, GUIStyle Highlighted)
        {
            GUI.Box(new Rect(x + 0f, y + 0f, widthSize + 20, 50f + 45 * 15), "", BGstyle);
            GUI.Label(new Rect(x + 5f, y + 5f, widthSize + 10, 85f), "I T E M   M E N U", LabelStyle);

            itemSpawnerScrollPosition = GUI.BeginScrollView(new Rect(x + 0f, y + 0f, widthSize + 10, 50f + 45 * 15), itemSpawnerScrollPosition, new Rect(x + 0f, y + 0f, widthSize + 10, 50f + 45 * mulY), false, true);
            ItemManager.GiveItem(buttonStyle, Highlighted, "itemSpawner");
            GUI.EndScrollView();
        }

        public static void DrawEquipmentMenu(float x, float y, float widthSize, int mulY, GUIStyle BGstyle, GUIStyle buttonStyle, GUIStyle LabelStyle, GUIStyle offStyle, GUIStyle Highlighted)
        {
            GUI.Box(new Rect(x + 0f, y + 0f, widthSize + 20, 50f + 45 * 15), "", BGstyle);
            GUI.Label(new Rect(x + 5f, y + 5f, widthSize + 10, 85f), "E Q U I P M E N T   L I S T", LabelStyle);

            equipmentSpawnerScrollPosition = GUI.BeginScrollView(new Rect(x + 0f, y + 0f, widthSize + 10, 50f + 45 * 15), equipmentSpawnerScrollPosition, new Rect(x + 0f, y + 0f, widthSize + 10, 50f + 45 * mulY), false, true);
            ItemManager.GiveEquipment(buttonStyle, Highlighted, "equipmentSpawner");
            GUI.EndScrollView();
        }

        public static void DrawBuffMenu(float x, float y, float widthSize, int mulY, GUIStyle BGstyle, GUIStyle buttonStyle, GUIStyle LabelStyle, GUIStyle offStyle, GUIStyle Highlighted)
        {
            GUI.Box(new Rect(x + 0f, y + 0f, widthSize + 20, 50f + 45 * 15), "", BGstyle);
            GUI.Label(new Rect(x + 5f, y + 5f, widthSize + 10, 85f), "B U F F   L I S T", LabelStyle);

            buffMenuScrollPosition = GUI.BeginScrollView(new Rect(x + 0f, y + 0f, widthSize + 10, 50f + 45 * 15), buffMenuScrollPosition, new Rect(x + 0f, y + 0f, widthSize + 10, 50f + 45 * mulY), false, true);
            PlayerMod.GiveBuff(buttonStyle, Highlighted, "giveBuff");
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
    }
}