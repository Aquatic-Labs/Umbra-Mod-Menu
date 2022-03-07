using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using RoR2;
using System.Text;


namespace UmbraMenu.Menus
{
    public sealed class Player : Menu
    {
        private static readonly IMenu player = new NormalMenu(1, new Rect(374, 10, 20, 20), "PLAYER MENU");

        public static bool SkillToggle, AimBotToggle, GodToggle;
        public static ulong xpToGive = 50;
        public static uint moneyToGive = 50, coinsToGive = 50;

        public ulong XPToGive
        {
            get
            {
                return xpToGive;
            }

            set
            {
                xpToGive = value;
                giveExperience.SetText($"GIVE EXPERIENCE : {xpToGive}");
            }
        }
        public uint MoneyToGive
        {
            get
            {
                return moneyToGive;
            }

            set
            {
                moneyToGive = value;
                giveMoney.SetText($"GIVE MONEY : {moneyToGive}");
            }
        }
        public uint CoinsToGive
        {
            get
            {
                return coinsToGive;
            }

            set
            {
                coinsToGive = value;
                giveCoins.SetText($"GIVE LUNAR COINS : {coinsToGive}");
            }
        }

        public Button giveMoney;
        public Button giveCoins;
        public Button giveExperience;
        public Button toggleStatsMod;
        public Button toggleChangeCharacter;
        public Button toggleBuff;
        public Button removeBuffs;
        public Button toggleAimbot;
        public Button toggleGod;
        public Button toggleSkillCD;
        public Button respawn;
        public Button unlockAll;

        public Player() : base(player)
        {
            if (UmbraMenu.characterCollected)
            {
                void ToggleStatsMenu() => UmbraMenu.menus[8].ToggleMenu();
                void ToggleCharacterListMenu() => UmbraMenu.menus[10].ToggleMenu();
                void ToggleBuffListMenu() => UmbraMenu.menus[11].ToggleMenu();
                void DoNothing() => Utility.StubbedFunction();

                giveMoney = new Button(new MulButton(this, 1, $"GIVE MONEY : {moneyToGive}", GiveMoney, IncreaseMoney, DecreaseMoney));
                giveCoins = new Button(new MulButton(this, 2, $"GIVE LUNAR COINS : {coinsToGive}", GiveLunarCoins, IncreaseCoins, DecreaseCoins));
                giveExperience = new Button(new MulButton(this, 3, $"GIVE EXPERIENCE : {xpToGive}", GiveXP, IncreaseXP, DecreaseXP));
                toggleStatsMod = new Button(new TogglableButton(this, 4, "STATS MENU : OFF", "STATS MENU : ON", ToggleStatsMenu, ToggleStatsMenu));
                toggleChangeCharacter = new Button(new TogglableButton(this, 5, "CHANGE CHARACTER : OFF", "CHANGE CHARACTER : ON", ToggleCharacterListMenu, ToggleCharacterListMenu));
                toggleBuff = new Button(new TogglableButton(this, 6, "GIVE BUFF MENU : OFF", "GIVE BUFF MENU : ON", ToggleBuffListMenu, ToggleBuffListMenu));
                removeBuffs = new Button(new NormalButton(this, 7, "REMOVE ALL BUFFS", RemoveAllBuffs));
                toggleAimbot = new Button(new TogglableButton(this, 8, "AIMBOT : OFF", "AIMBOT : ON", ToggleAimbot, ToggleAimbot));
                toggleGod = new Button(new TogglableButton(this, 9, "GOD MODE : OFF", "GOD MODE : ON", ToggleGodMode, ToggleGodMode));
                toggleSkillCD = new Button(new TogglableButton(this, 10, "INFINITE SKILLS : OFF", "INFINITE SKILLS : ON", ToggleSkillCD, ToggleSkillCD));
                respawn = new Button(new NormalButton(this, 11, "RESPAWN", respawnPlayer));
                unlockAll = new Button(new TogglableButton(this, 12, "UNLOCK ALL", "CONFIRM?", DoNothing, UnlockAll));

                AddButtons(new List<Button>()
                {
                    giveMoney,
                    giveCoins,
                    giveExperience,
                    toggleStatsMod,
                    toggleChangeCharacter,
                    toggleBuff,
                    removeBuffs,
                    toggleAimbot,
                    toggleGod,
                    toggleSkillCD,
                    respawn,
                    unlockAll
                });
                SetActivatingButton(Utility.FindButtonById(0, 1));
                SetPrevMenuId(0);
            }
        }

        public override void Draw()
        {
            if (IsEnabled())
            {
                SetWindow();
                base.Draw();
            }
        }

        public override void Reset()
        {
            SkillToggle = false;
            AimBotToggle = false;
            GodToggle = false;
            xpToGive = 50;
            moneyToGive = 50;
            coinsToGive = 50;
            base.Reset();
        }

        public void ToggleMenu(Menu menu)
        {
            menu.ToggleMenu();
        }

        public void ToggleAimbot()
        {
            AimBotToggle = !AimBotToggle;
        }

        public void ToggleGodMode()
        {
            GodToggle = !GodToggle;
            if (!GodToggle)
            {
                DisabledGodMode();
            }
        }

        public static void ToggleSkillCD()
        {
            SkillToggle = !SkillToggle;
        }

        public static void respawnPlayer()
        {
            UmbraMenu.LocalPlayer.GetComponent<CharacterMaster>().RespawnExtraLife();
        }

        public static void RemoveAllBuffs()
        {
            foreach (BuffIndex buffIndex in UmbraMenu.buffs)
            {
                try
                {
                    while (UmbraMenu.LocalPlayerBody.HasBuff(buffIndex))
                    {
                        UmbraMenu.LocalPlayerBody.RemoveBuff(buffIndex);
                    }
                }
                catch (Exception e)
                {
                    Debug.Log(e);
                    continue;
                }
            }
        }

        // self explanatory
        public static void GiveXP()
        {
            UmbraMenu.LocalPlayer.GiveExperience(xpToGive);
        }

        public static void GiveMoney()
        {
            UmbraMenu.LocalPlayer.GiveMoney(moneyToGive);
        }

        //uh, duh.
        public static void GiveLunarCoins()
        {
            UmbraMenu.LocalNetworkUser.AwardLunarCoins(coinsToGive);
        }

        public static void AimBot()
        {
            if (Utility.CursorIsVisible())
            {
                return;
            }

            var localUser = LocalUserManager.GetFirstLocalUser();
            var controller = localUser.cachedMasterController;
            if (!controller)
            {
                return;
            }

            var body = controller.master.GetBody();
            if (!body)
            {
                return;
            }

            var inputBank = body.GetComponent<InputBankTest>();
            var aimRay = new Ray(inputBank.aimOrigin, inputBank.aimDirection);
            var bullseyeSearch = new BullseyeSearch();
            var team = body.GetComponent<TeamComponent>();
            bullseyeSearch.teamMaskFilter = TeamMask.all;
            bullseyeSearch.teamMaskFilter.RemoveTeam(team.teamIndex);
            bullseyeSearch.filterByLoS = true;
            bullseyeSearch.searchOrigin = aimRay.origin;
            bullseyeSearch.searchDirection = aimRay.direction;
            bullseyeSearch.sortMode = BullseyeSearch.SortMode.Distance;
            bullseyeSearch.maxDistanceFilter = float.MaxValue;
            bullseyeSearch.maxAngleFilter = 20f;// ;// float.MaxValue;
            bullseyeSearch.RefreshCandidates();
            var hurtBox = bullseyeSearch.GetResults().FirstOrDefault();
            if (hurtBox)
            {
                //todo check if the player is the railgunner

                HurtBox selectedBox = null;
                foreach (HurtBox box in hurtBox.hurtBoxGroup.hurtBoxes)
                {
                    if (box.isSniperTarget)
                    {
                        selectedBox = box;
                        break;
                    }
                }
                if (selectedBox != null)
                {
                    Vector3 dir = selectedBox.transform.position - aimRay.origin;
                    inputBank.aimDirection = dir;
                }
                else
                {
                    Vector3 direction = hurtBox.transform.position - aimRay.origin;
                    inputBank.aimDirection = direction;
                }
            }
        }

        public static void EnableGodMode()
        {
            switch (UmbraMenu.GodVersion)
            {
                case 0:
                    {
                        // works
                        // Normal
                        UmbraMenu.LocalHealth.godMode = true;
                        break;
                    }

                case 1:
                    {
                        // works
                        // Buff
                        if (!UmbraMenu.LocalPlayerBody.HasBuff(BuffCatalog.FindBuffIndex("bdIntangible")))
                        {
                            UmbraMenu.LocalPlayerBody.AddBuff(BuffCatalog.FindBuffIndex("bdIntangible"));
                        }
                        break;
                    }

                case 2:
                    {
                        // works
                        // Regen
                        UmbraMenu.LocalHealth.Heal(float.MaxValue, new ProcChainMask(), false);
                        break;
                    }

                case 3:
                    {
                        // works
                        // Negative
                        UmbraMenu.LocalHealth.SetField<bool>("wasAlive", false);
                        break;
                    }

                case 4:
                    {
                        // works
                        // Revive
                        UmbraMenu.LocalHealth.SetField<bool>("wasAlive", false);
                        int itemELCount = UmbraMenu.LocalPlayerInv.GetItemCount(ItemCatalog.FindItemIndex("ExtraLife"));
                        int itemELCCount = UmbraMenu.LocalPlayerInv.GetItemCount(ItemCatalog.FindItemIndex("ExtraLifeConsumed"));
                        if (UmbraMenu.LocalHealth.health < 1)
                        {
                            if (itemELCount == 0)
                            {
                                ItemList.GiveItem(ItemCatalog.FindItemIndex("ExtraLife"));
                                UmbraMenu.LocalHealth.SetField<bool>("wasAlive", true);
                            }
                        }
                        if (itemELCCount > 0)
                        {
                            UmbraMenu.LocalPlayerInv.RemoveItem(ItemCatalog.FindItemIndex("ExtraLifeConsumed"), itemELCCount);
                        }
                        if (itemELCount > 0)
                        {
                            UmbraMenu.LocalPlayerInv.RemoveItem(ItemCatalog.FindItemIndex("ExtraLifeConsumed"), itemELCount);
                        }
                        break;
                    }


                default:
                    break;
            }
        }

        public static void DisabledGodMode()
        {
            switch (UmbraMenu.GodVersion)
            {
                case 0:
                    {
                        UmbraMenu.LocalHealth.godMode = false;
                        break;
                    }

                case 1:
                    {
                        UmbraMenu.LocalPlayerBody.RemoveBuff(BuffCatalog.FindBuffIndex("bdIntangible"));
                        break;
                    }

                case 3:
                    {
                        if (UmbraMenu.LocalHealth.health < 0)
                        {
                            UmbraMenu.LocalHealth.health = 1;
                        }
                        UmbraMenu.LocalHealth.SetField<bool>("wasAlive", true);
                        break;
                    }

                case 4:
                    {
                        if (UmbraMenu.LocalHealth.health < 0)
                        {
                            UmbraMenu.LocalHealth.health = 1;
                        }
                        UmbraMenu.LocalHealth.SetField<bool>("wasAlive", true);
                        int itemELCount = UmbraMenu.LocalPlayerInv.GetItemCount(ItemCatalog.FindItemIndex("ExtraLife"));
                        int itemELCCount = UmbraMenu.LocalPlayerInv.GetItemCount(ItemCatalog.FindItemIndex("ExtraLifeConsumed"));
                        if (itemELCCount > 0)
                        {
                            UmbraMenu.LocalPlayerInv.RemoveItem(ItemCatalog.FindItemIndex("ExtraLifeConsumed"), itemELCCount);
                        }
                        if (itemELCount > 0)
                        {
                            UmbraMenu.LocalPlayerInv.RemoveItem(ItemCatalog.FindItemIndex("ExtraLifeConsumed"), itemELCount);
                        }
                        break;
                    }

                default:
                    break;
            }
        }

        public static void UnlockAll()
        {
            //This is needed to unlock logs
            var unlockables = UmbraMenu.unlockables;
            foreach (var unlockable in unlockables)
            {
                NetworkUser networkUser = Util.LookUpBodyNetworkUser(UmbraMenu.LocalPlayerBody);
                if (networkUser)
                {
                    networkUser.ServerHandleUnlock(unlockable.Value);
                }
            }

            //Gives all achievements.
            var achievementManager = AchievementManager.GetUserAchievementManager(LocalUserManager.GetFirstLocalUser());
            foreach (var achievement in AchievementManager.allAchievementDefs)
            {
                achievementManager.GrantAchievement(achievement);
            }

            //Give all survivors
            var profile = LocalUserManager.GetFirstLocalUser().userProfile;
            foreach (var survivor in SurvivorCatalog.allSurvivorDefs)
            {
                if (profile.statSheet.GetStatValueDouble(RoR2.Stats.PerBodyStatDef.totalTimeAlive, survivor.bodyPrefab.name) == 0.0)
                    profile.statSheet.SetStatValueFromString(RoR2.Stats.PerBodyStatDef.totalTimeAlive.FindStatDef(survivor.bodyPrefab.name), "0.1");
                if (profile.statSheet.GetStatValueULong(RoR2.Stats.PerBodyStatDef.totalWins, survivor.bodyPrefab.name) == 0L)
                    profile.statSheet.SetStatValueFromString(RoR2.Stats.PerBodyStatDef.totalWins.FindStatDef(survivor.bodyPrefab.name), "1");
                if (profile.statSheet.GetStatValueULong(RoR2.Stats.PerBodyStatDef.timesPicked, survivor.bodyPrefab.name) == 0L)
                    profile.statSheet.SetStatValueFromString(RoR2.Stats.PerBodyStatDef.timesPicked.FindStatDef(survivor.bodyPrefab.name), "1");
            }

            //All items and equipments
            foreach (ItemIndex itemIndex in ItemCatalog.allItems)
            {
                profile.DiscoverPickup(PickupCatalog.FindPickupIndex(itemIndex));
            }

            foreach (EquipmentIndex equipmentIndex in EquipmentCatalog.allEquipment)
            {
                profile.DiscoverPickup(PickupCatalog.FindPickupIndex(equipmentIndex));
            }

            //All Eclipse unlockables as well
            StringBuilder stringBuilder = HG.StringBuilderPool.RentStringBuilder();
            foreach (SurvivorDef survivorDef in SurvivorCatalog.allSurvivorDefs)
            {
                for (int i = 2; i < 9; i++)
                {
                    stringBuilder.Clear().Append("Eclipse.").Append(survivorDef.cachedName).Append(".").AppendInt(i, 0U, uint.MaxValue);
                    UnlockableDef unlockableDef = UnlockableCatalog.GetUnlockableDef(stringBuilder.ToString());
                    NetworkUser networkUser = Util.LookUpBodyNetworkUser(UmbraMenu.LocalPlayerBody);
                    if (networkUser)
                    {
                        networkUser.ServerHandleUnlock(unlockableDef);
                    }
                }
            }
        }

        #region Increase/Decrease Value Actions
        public void IncreaseMoney()
        {
            if (MoneyToGive >= 50)
                MoneyToGive += 50;
        }

        public void IncreaseCoins()
        {
            if (CoinsToGive >= 10)
                CoinsToGive += 10;
        }

        public void IncreaseXP()
        {
            if (XPToGive >= 50)
                XPToGive += 50;
        }

        public void DecreaseMoney()
        {
            if (MoneyToGive > 50)
                MoneyToGive -= 50;
        }

        public void DecreaseCoins()
        {
            if (CoinsToGive > 10)
                CoinsToGive -= 10;
        }

        public void DecreaseXP()
        {
            if (XPToGive > 50)
                XPToGive -= 50;
        }
        #endregion
    }
}

