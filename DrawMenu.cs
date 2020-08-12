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
                DrawButton(2, "main", "<color=yellow>等待进入游戏.</color>", buttonStyle, justText: true);
                DrawButton(3, "main", "<color=#11ccee>看你吗，进游戏.\n 再看鲨了你.</color>", buttonStyle, justText: true);
                DrawButton(4, "main", "<color=#11ccee>三天之内鲨了你.\nAcher0ns/Umbra-Mod-Menu</color>", buttonStyle, justText: true);
            }
            else if (Updates.upToDate || Updates.devBuild)
            {
                DrawButton(2, "main", "<color=yellow>等待进入游戏.</color>", buttonStyle, justText: true);
                DrawButton(3, "main", "<color=#11ccee>看你吗，进游戏.\n 再看鲨了你.</color>", buttonStyle, justText: true);
                DrawButton(4, "main", "<color=#11ccee>三天之内鲨了你.</color>", buttonStyle, justText: true);
            }
        }

        public static void DrawMainMenu(float x, float y, float widthSize, float mulY, GUIStyle BGstyle, GUIStyle OnStyle, GUIStyle OffStyle, GUIStyle ButtonStyle)
        {
            if (Main._isPlayerMod)
            {
                DrawButton(1, "main", "玩家 : 开", OnStyle);
            }
            else
            {
                DrawButton(1, "main", "玩家 : 关", OffStyle);
            }

            if (Main._isMovementOpen)
            {
                DrawButton(2, "main", "移动 : 开", OnStyle);
            }
            else
            {
                DrawButton(2, "main", "移动 : 关", OffStyle);
            }

            if (Main._isItemManagerOpen)
            {
                DrawButton(3, "main", "物品 : ON", OnStyle);
            }
            else
            {
                DrawButton(3, "main", "物品 : 关", OffStyle);
            }

            if (Main._isSpawnMenuOpen)
            {
                DrawButton(4, "main", "生成 : 开", OnStyle);
            }
            else
            {
                DrawButton(4, "main", "生成 : 关", OffStyle);
            }

            if (Main._isTeleMenuOpen)
            {
                DrawButton(5, "main", "传送 : 开", OnStyle);
            }
            else
            {
                DrawButton(5, "main", "传送 : 关", OffStyle);
            }

            if (Main._isESPMenuOpen)
            {
                DrawButton(6, "main", "渲染 : 开", OnStyle);
            }
            else
            {
                DrawButton(6, "main", "渲染 : 关", OffStyle);
            }

            if (Main._isLobbyMenuOpen)
            {
                DrawButton(7, "main", "大厅 : 开", OnStyle);
            }
            else
            {
                DrawButton(7, "main", "大厅 : 关", OffStyle);
            }

            if (Main.unloadConfirm)
            {
                DrawButton(8, "main", "确定 ?", ButtonStyle);
            }
            else
            {
                DrawButton(8, "main", "关闭Poke", ButtonStyle);
            }
        }

        public static void DrawPlayerModMenu(float x, float y, float widthSize, int mulY, GUIStyle BGstyle, GUIStyle buttonStyle, GUIStyle OnStyle, GUIStyle OffStyle, GUIStyle LabelStyle)
        {
            GUI.Box(new Rect(x + 0f, y + 0f, widthSize + 10, 50f + 45 * mulY), "", BGstyle);
            GUI.Label(new Rect(x + 5f, y + 5f, widthSize + 5, 85f), "玩家   菜单", LabelStyle);

            DrawButton(1, "playermod", $"获取   $ : {PlayerMod.moneyToGive}", buttonStyle, isMultButton: true);
            DrawButton(2, "playermod", $"获取   月球硬币 : {PlayerMod.coinsToGive}", buttonStyle, isMultButton: true);
            DrawButton(3, "playermod", $"获取   经验 : {PlayerMod.xpToGive}", buttonStyle, isMultButton: true);

            if (Main._isEditStatsOpen)
            {
                DrawButton(4, "playermod", "属性   菜单 : ON", OnStyle);
            }
            else
            {
                DrawButton(4, "playermod", "属性   菜单 : OFF", OffStyle);
            }
            if (Main._isChangeCharacterMenuOpen)
            {
                DrawButton(5, "playermod", "改变角色 : ON", OnStyle);
            }
            else
            {
                DrawButton(5, "playermod", "改变角色 : OFF", OffStyle);
            }
            if (Main._isBuffMenuOpen)
            {
                DrawButton(6, "playermod", "获取   B U F F   菜单 : 开", OnStyle);
            }
            else
            {
                DrawButton(6, "playermod", "获取   B U F F   菜单 : 关", OffStyle);
            }

            DrawButton(7, "playermod", "清除所有 B U F F", buttonStyle);

            if (Main.aimBot)
            {
                DrawButton(8, "playermod", " : 开", OnStyle);
            }
            else
            {
                DrawButton(8, "playermod", " : 关", OffStyle);
            }
            if (Main.godToggle)
            {
                DrawButton(9, "playermod", "无敌 : 开", OnStyle);
            }
            else
            {
                DrawButton(9, "playermod", "无敌 : 关", OffStyle);
            }
            if (Main.skillToggle)
            {
                DrawButton(10, "playermod", "技能无CD : 开", OnStyle);
            }
            else
            {
                DrawButton(10, "playermod", "技能无CD : 关", OffStyle);
            }
            DrawButton(11, "playermod", "全部解锁", buttonStyle);
        }

        public static void DrawMovementMenu(float x, float y, float widthSize, int mulY, GUIStyle BGstyle, GUIStyle buttonStyle, GUIStyle OnStyle, GUIStyle OffStyle, GUIStyle LabelStyle)
        {
            GUI.Box(new Rect(x + 0f, y + 0f, widthSize + 10, 50f + 45 * mulY), "", BGstyle);
            GUI.Label(new Rect(x + 5f, y + 5f, widthSize + 10, 85f), "移动   菜单", LabelStyle);

            if (Main.alwaysSprint)
            {
                DrawButton(1, "movement", "疾跑 : 开", OnStyle);
            }
            else
            {
                DrawButton(1, "movement", "疾跑 : 关", OffStyle);
            }

            if (Main.FlightToggle)
            {
                DrawButton(2, "movement", "你在哪 爷飞过去 : 开", OnStyle);
            }
            else
            {
                DrawButton(2, "movement", "你在哪 爷飞过去 : 关", OffStyle);
            }

            if (Main.jumpPackToggle)
            {
                DrawButton(3, "movement", "无重力 : 开", OnStyle);
            }
            else
            {
                DrawButton(3, "movement", "无重力 : 关", OffStyle);
            }
        }

        public static void DrawItemManagementMenu(float x, float y, float widthSize, int mulY, GUIStyle BGstyle, GUIStyle buttonStyle, GUIStyle OnStyle, GUIStyle OffStyle, GUIStyle LabelStyle)
        {
            GUI.Box(new Rect(x + 0f, y + 0f, widthSize + 10, 50f + 45 * mulY), "", BGstyle);
            GUI.Label(new Rect(x + 5f, y + 5f, widthSize + 5, 85f), "物品   菜单", LabelStyle);

            DrawButton(1, "itemmanager", $"获取   所有物品 : {ItemManager.allItemsQuantity}", buttonStyle, isMultButton: true);
            DrawButton(2, "itemmanager", $"随机   物品 : {ItemManager.itemsToRoll}", buttonStyle, isMultButton: true);

            if (Main._isItemSpawnMenuOpen)
            {
                DrawButton(3, "itemmanager", "生成物品   菜单 : 开", OnStyle);
            }
            else
            {
                DrawButton(3, "itemmanager", "生成物品   菜单 : 关", OffStyle);
            }
            if (Main._isEquipmentSpawnMenuOpen)
            {
                DrawButton(4, "itemmanager", "装备   生成   菜单 : 开", OnStyle);
            }
            else
            {
                DrawButton(4, "itemmanager", "装备   生成   菜单 : 关", OffStyle);
            }
            if (ItemManager.isDropItemForAll)
            {
                DrawButton(5, "itemmanager", "掉落   物品 / 装备 : 开", OnStyle);
            }
            else
            {
                DrawButton(5, "itemmanager", "掉落   物品 / 装备 : 关", OffStyle);
            }
            if (ItemManager.isDropItemFromInventory)
            {
                DrawButton(6, "itemmanager", "掉落自   库存 : 开", OnStyle);
            }
            else
            {
                DrawButton(6, "itemmanager", "掉落自   库存 : 关", OffStyle);
            }
            if (Main.noEquipmentCooldown)
            {
                DrawButton(7, "itemmanager", "无装备CD : 开", OnStyle);
            }
            else
            {
                DrawButton(7, "itemmanager", "无装备CD : 关", OffStyle);
            }

            DrawButton(8, "itemmanager", "堆   库存", buttonStyle);
            DrawButton(9, "itemmanager", "清理   库存", buttonStyle);
        }

        public static void DrawSpawnMenu(float x, float y, float widthSize, int mulY, GUIStyle BGstyle, GUIStyle buttonStyle, GUIStyle OnStyle, GUIStyle OffStyle, GUIStyle LabelStyle)
        {
            GUI.Box(new Rect(x + 0f, y + 0f, widthSize + 10, 50f + 45 * mulY), "", BGstyle);
            GUI.Label(new Rect(x + 5f, y + 5f, widthSize + 10, 85f), "生成   菜单", LabelStyle);

            DrawButton(1, "spawn", $"最小距离 : {Spawn.minDistance}", buttonStyle, isMultButton: true);
            DrawButton(2, "spawn", $"最大距离 : {Spawn.maxDistance}", buttonStyle, isMultButton: true);
            DrawButton(3, "spawn", $"阵营 : {Spawn.team[Spawn.teamIndex]}", buttonStyle, isMultButton: true);

            if (Main._isSpawnListMenuOpen)
            {
                DrawButton(4, "spawn", "生成   列表 : 开", OnStyle);
            }
            else
            {
                DrawButton(4, "spawn", "生成   列表 : 关", OffStyle);
            }

            DrawButton(5, "spawn", "杀死所有敌人", buttonStyle);
            DrawButton(6, "spawn", "杀死所有物品", buttonStyle);
        }

        public static void DrawTeleMenu(float x, float y, float widthSize, int mulY, GUIStyle BGstyle, GUIStyle buttonStyle, GUIStyle LabelStyle)
        {
            GUI.Box(new Rect(x + 0f, y + 0f, widthSize + 10, 50f + 45 * mulY), "", BGstyle);
            GUI.Label(new Rect(x + 5f, y + 5f, widthSize + 5, 85f), "传送   菜单", LabelStyle);

            DrawButton(1, "tele", "跳关", buttonStyle);
            DrawButton(2, "tele", "快速   传送", buttonStyle);
            DrawButton(3, "tele", $"添加 : {TeleporterInteraction.instance.shrineBonusStacks}", buttonStyle);
            DrawButton(4, "tele", "生成   全部  球体", buttonStyle);
            DrawButton(5, "tele", "生成   蓝色   球体", buttonStyle);
            DrawButton(6, "tele", "生成   天蓝色   球体", buttonStyle);
            DrawButton(7, "tele", "生成   金色   球体", buttonStyle);
        }

        public static void DrawRenderMenu(float x, float y, float widthSize, int mulY, GUIStyle BGstyle, GUIStyle buttonStyle, GUIStyle OnStyle, GUIStyle OffStyle, GUIStyle LabelStyle)
        {
            GUI.Box(new Rect(x + 0f, y + 0f, widthSize + 10, 50f + 45 * mulY), "", BGstyle);
            GUI.Label(new Rect(x + 5f, y + 5f, widthSize + 5, 85f), "渲染   菜单", LabelStyle);

            if (Main.renderActiveMods)
            {
                DrawButton(1, "透视", "提示 : 开", OnStyle);
            }
            else
            {
                DrawButton(1, "透视", "提示 : 关", OffStyle);
            }

            if (Main.renderInteractables)
            {
                DrawButton(2, "透视", "物品 : 开", OnStyle);
            }
            else
            {
                DrawButton(2, "透视", "物品 : 关", OffStyle);
            }

            if (Main.renderMobs)
            {
                DrawButton(3, "透视", "怪物  : O N\n<color=red>注意: 也许会 掉帧或游戏崩溃 </color>", OnStyle);
            }
            else
            {
                DrawButton(3, "透视", "怪物 : O F F\n<color=red>注意: 也许会 掉帧或游戏崩溃 </color>", OffStyle);
            }
        }

        public static void DrawLobbyMenu(float x, float y, float widthSize, int mulY, GUIStyle BGstyle, GUIStyle buttonStyle, GUIStyle LabelStyle)
        {
            GUI.Box(new Rect(x + 0f, y + 0f, widthSize + 10, 50f + 45 * mulY), "", BGstyle);
            GUI.Label(new Rect(x + 5f, y + 5f, widthSize + 5, 85f), "大厅   菜单", LabelStyle);

            if (Main._CharacterCollected)
            {
                Lobby.GetPlayers(Main.Players); //update this asap
                int buttonPlacement = 1;
                for (int i = 0; i < Main.Players.Length; i++)
                {
                    try
                    {
                        if (Main.Players[i] != null)
                        {
                            DrawButton(buttonPlacement, "lobby", $"踢出  <color=yellow>{Main.Players[i]}</color>", buttonStyle);
                            buttonPlacement++;
                        }
                    }
                    catch (NullReferenceException)
                    {
                        Debug.LogWarning("UmbraRoR: 没有选择玩家");
                    }
                }
            }
        }

        public static void CharacterWindowMethod(float x, float y, float widthSize, int mulY, GUIStyle BGstyle, GUIStyle buttonStyle, GUIStyle LabelStyle)
        {
            GUI.Box(new Rect(x + 0f, y + 0f, widthSize + 10, 50f + 45 * 15), "", BGstyle);
            GUI.Label(new Rect(x + 5f, y + 5f, widthSize + 5, 85f), "角色   菜单", LabelStyle);

            characterScrollPosition = GUI.BeginScrollView(new Rect(x + 0f, y + 0f, widthSize + 10, 50f + 45 * 15), characterScrollPosition, new Rect(x + 0f, y + 0f, widthSize + 10, 50f + 45 * mulY), false, true);
            PlayerMod.ChangeCharacter(buttonStyle, "character");
            GUI.EndScrollView();
        }

        public static void DrawBuffMenu(float x, float y, float widthSize, int mulY, GUIStyle BGstyle, GUIStyle buttonStyle, GUIStyle LabelStyle, GUIStyle offStyle)
        {
            GUI.Box(new Rect(x + 0f, y + 0f, widthSize + 20, 50f + 45 * 15), "", BGstyle);
            GUI.Label(new Rect(x + 5f, y + 5f, widthSize + 10, 85f), "B U F F S   列表", LabelStyle);

            buffMenuScrollPosition = GUI.BeginScrollView(new Rect(x + 0f, y + 0f, widthSize + 10, 50f + 45 * 15), buffMenuScrollPosition, new Rect(x + 0f, y + 0f, widthSize + 10, 50f + 45 * mulY), false, true);
            PlayerMod.GiveBuff(buttonStyle, "giveBuff");
            GUI.EndScrollView();
        }

        public static void DrawStatsModMenu(float x, float y, float widthSize, int mulY, GUIStyle BGstyle, GUIStyle buttonStyle, GUIStyle OnStyle, GUIStyle OffStyle, GUIStyle LabelStyle)
        {
            GUI.Box(new Rect(x + 0f, y + 0f, widthSize + 10, 50f + 45 * mulY), "", BGstyle);
            GUI.Label(new Rect(x + 5f, y + 5f, widthSize + 10, 85f), "属性   菜单", LabelStyle);

            if (Main.damageToggle)
            {
                DrawButton(1, "statsmod", $"伤害 ( 开 ) : {PlayerMod.damagePerLvl}", OnStyle, true);
            }
            else
            {
                DrawButton(1, "statsmod", $"伤害 ( 关 ) : {PlayerMod.damagePerLvl}", OffStyle, true);
            }
            if (Main.critToggle)
            {
                DrawButton(2, "statsmod", $"暴击 ( 开 ) : {PlayerMod.CritPerLvl}", OnStyle, true);
            }
            else
            {
                DrawButton(2, "statsmod", $"暴击 ( 关 ) : {PlayerMod.CritPerLvl}", OffStyle, true);
            }
            if (Main.attackSpeedToggle)
            {
                DrawButton(3, "statsmod", $"攻击速度 ( 开 ) : {PlayerMod.attackSpeed}", OnStyle, true);
            }
            else
            {
                DrawButton(3, "statsmod", $"攻击速度 ( 关 ) : {PlayerMod.attackSpeed}", OffStyle, true);
            }
            if (Main.armorToggle)
            {
                DrawButton(4, "statsmod", $"护甲 ( 开 ) : {PlayerMod.armor}", OnStyle, true);
            }
            else
            {
                DrawButton(4, "statsmod", $"护甲 ( 关 ) : {PlayerMod.armor}", OffStyle, true);
            }
            if (Main.moveSpeedToggle)
            {
                DrawButton(5, "statsmod", $"移动速度 ( 开 ) : {PlayerMod.movespeed}", OnStyle, true);
            }
            else
            {
                DrawButton(5, "statsmod", $"移动速度 ( 关 ) : {PlayerMod.movespeed}", OffStyle, true);
            }
            if (Main._isStatMenuOpen)
            {
                DrawButton(6, "statsmod", "显示   属性 : 开", OnStyle);
            }
            else
            {
                DrawButton(6, "statsmod", "显示   属性 : 关", OffStyle);
            }
        }

        public static void DrawItemMenu(float x, float y, float widthSize, int mulY, GUIStyle BGstyle, GUIStyle buttonStyle, GUIStyle LabelStyle)
        {
            GUI.Box(new Rect(x + 0f, y + 0f, widthSize + 20, 50f + 45 * 15), "", BGstyle);
            GUI.Label(new Rect(x + 5f, y + 5f, widthSize + 10, 85f), "物品   列表", LabelStyle);

            itemSpawnerScrollPosition = GUI.BeginScrollView(new Rect(x + 0f, y + 0f, widthSize + 10, 50f + 45 * 15), itemSpawnerScrollPosition, new Rect(x + 0f, y + 0f, widthSize + 10, 50f + 45 * mulY), false, true);
            int buttonPlacement = 1;
            foreach (var itemIndex in Main.items)
            {
                string itemName = itemIndex.ToString();
                DrawButton(buttonPlacement, "itemSpawner", itemName, buttonStyle);
                buttonPlacement++;
            }
            GUI.EndScrollView();
        }

        public static void DrawEquipmentMenu(float x, float y, float widthSize, int mulY, GUIStyle BGstyle, GUIStyle buttonStyle, GUIStyle LabelStyle, GUIStyle offStyle)
        {
            GUI.Box(new Rect(x + 0f, y + 0f, widthSize + 20, 50f + 45 * 15), "", BGstyle);
            GUI.Label(new Rect(x + 5f, y + 5f, widthSize + 10, 85f), "装备   列表", LabelStyle);

            equipmentSpawnerScrollPosition = GUI.BeginScrollView(new Rect(x + 0f, y + 0f, widthSize + 10, 50f + 45 * 15), equipmentSpawnerScrollPosition, new Rect(x + 0f, y + 0f, widthSize + 10, 50f + 45 * mulY), false, true);
            int buttonPlacement = 1;
            foreach (var equipmentIndex in Main.equipment)
            {
                string equipmentName = equipmentIndex.ToString();
                DrawButton(buttonPlacement, "equipmentSpawner", equipmentName, buttonStyle);
                buttonPlacement++;
            }
            GUI.EndScrollView();
        }

        public static void DrawSpawnMobMenu(float x, float y, float widthSize, int mulY, GUIStyle BGstyle, GUIStyle buttonStyle, GUIStyle LabelStyle)
        {
            GUI.Box(new Rect(x + 0f, y + 0f, widthSize + 20, 50f + 45 * 15), "", BGstyle);
            GUI.Label(new Rect(x + 5f, y + 5f, widthSize + 10, 85f), "生成   列表", LabelStyle);

            spawnScrollPosition = GUI.BeginScrollView(new Rect(x + 0f, y + 0f, widthSize + 10, 50f + 45 * 15), spawnScrollPosition, new Rect(x + 0f, y + 0f, widthSize + 10, 50f + 45 * mulY), false, true);
            Spawn.SpawnMob(buttonStyle, "spawnMob");
            GUI.EndScrollView();
        }

        public static void DrawStatsMenu(float x, float y, float widthSize, int mulY, GUIStyle BGstyle, GUIStyle buttonStyle, GUIStyle LabelStyle)
        {
            GUI.Box(new Rect(x + 0f, y + 0f, widthSize, 50f + 45 * mulY), "", BGstyle);
            GUI.Label(new Rect(x + 5f, y + 5f, widthSize + 5, 50f), "属性   菜单", LabelStyle);

            DrawButton(1, "stats", $"伤害 : {Main.LocalPlayerBody.damage}", buttonStyle, justText: true);
            DrawButton(2, "stats", $"暴击 : {Main.LocalPlayerBody.crit}", buttonStyle, justText: true);
            DrawButton(3, "stats", $"攻击速度 : {Main.LocalPlayerBody.attackSpeed}", buttonStyle, justText: true);
            DrawButton(4, "stats", $"护甲 : {Main.LocalPlayerBody.armor}", buttonStyle, justText: true);
            DrawButton(5, "stats", $"K K P : {Main.LocalPlayerBody.regen}", buttonStyle, justText: true);
            DrawButton(6, "stats", $"移动速度 : {Main.LocalPlayerBody.moveSpeed}", buttonStyle, justText: true);
            DrawButton(7, "stats", $"连跳 : {Main.LocalPlayerBody.maxJumpCount}", buttonStyle, justText: true);
            DrawButton(8, "stats", $"经验 : {Main.LocalPlayerBody.experience}", buttonStyle, justText: true);
            DrawButton(9, "stats", $"击杀数: {Main.LocalPlayerBody.killCount}", buttonStyle, justText: true);

        }

        // A Wrapper Method For Drawing Buttons
        public static void DrawButton(int position, string id, string text, GUIStyle defaultStyle, bool isMultButton = false, bool justText = false)
        {
            Rect rect;
            Rect menuBg;
            GUIStyle highlighted = Main.HighlightBtnStyle;
            float menuIndex;
            int intraMenuIndex = position - 1;
            int btnY = 5 + 45 * position;
            // Rect for buttons
            // It automatically position buttons based on id and position. There is no need to change it
            switch (id)
            {
                case "main":
                    {
                        menuIndex = 0;
                        menuBg = Main.mainRect;
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
                        menuBg = Main.playerModRect;
                        Main.PlayerModMulY = position;
                        Main.PlayerModBtnY = btnY;
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
                        menuBg = Main.characterRect;
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
                        menuBg = Main.buffMenuRect;
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
                        menuBg = Main.editStatsRect;
                        Main.editStatsMulY = position;
                        Main.editStatsBtnY = btnY;
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

                case "movement":
                    {
                        menuIndex = 2f;
                        menuBg = Main.movementRect;
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
                        menuBg = Main.itemManagerRect;
                        Main.ItemManagerMulY = position;
                        Main.ItemManagerBtnY = btnY;
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
                        menuBg = Main.itemSpawnerRect;
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
                        menuBg = Main.equipmentSpawnerRect;
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
                        menuBg = Main.spawnRect;
                        Main.spawnMulY = position;
                        Main.spawnBtnY = btnY;
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
                        menuBg = Main.spawnListRect;
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
                        menuBg = Main.teleRect;
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

                case "透视":
                    {
                        menuIndex = 6f;
                        menuBg = Main.ESPRect;
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
                        menuBg = Main.lobbyRect;
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

                case "stats":
                    {
                        menuIndex = 99f;
                        menuBg = Main.statRect;
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

                default:
                    {
                        menuBg = Main.mainRect;
                        menuIndex = 0;
                        rect = new Rect(Main.mainRect.x + 5, Main.mainRect.y + 5 + 45 * position, Main.widthSize - 90, 40);
                        break;
                    }
            }

            // Creates the button and its OnClick action based on PressBtn() input
            // Dont want text to be highlighted so remove that from the Button() call
            if (justText && isMultButton)
            {
                throw new Exception($"justText and isMultButton cannot both be true. Thrown in \"{text}\" button.");
            }
            else if (justText)
            {
                GUI.Button(rect, text, defaultStyle);
            }
            else if (isMultButton)
            {
                if (GUI.Button(rect, text, Navigation.HighlighedCheck(defaultStyle, highlighted, menuIndex, position)))
                {
                    Navigation.PressBtn(menuIndex, intraMenuIndex);
                }
                if (GUI.Button(new Rect(menuBg.x + Main.widthSize - 80, menuBg.y + btnY, 40, 40), "-", Main.OffStyle))
                {
                    Navigation.DecreaseValue(menuIndex, intraMenuIndex);
                }
                if (GUI.Button(new Rect(menuBg.x + Main.widthSize - 35, menuBg.y + btnY, 40, 40), "+", Main.OffStyle))
                {
                    if (Spawn.minDistance < Spawn.maxDistance)
                    {
                        Navigation.IncreaseValue(menuIndex, intraMenuIndex);
                    }
                }
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
