using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using RoR2;
using System.Text;
using System.Threading;


namespace UmbraMenu.Menus
{
    public sealed class Player : NormalMenu
    {
        public static bool SkillToggle, AimBotToggle, GodToggle;
        public static ulong XPToGive = 50;
        public static uint MoneyToGive = 50, CoinsToGive = 50;

        private static bool reviveDoOnce = true;

        public MulButton giveMoney;
        public MulButton giveCoins;
        public MulButton giveExperience;
        public TogglableButton toggleStatsMod;
        public TogglableButton toggleChangeCharacter;
        public TogglableButton toggleBuff;
        public NormalButton removeBuffs;
        public TogglableButton toggleAimbot;
        public TogglableButton toggleGod;
        public TogglableButton toggleSkillCD;
        public TogglableButton unlockAll;

        public Player() : base(1, 0, new Rect(374, 10, 20, 20), "PLAYER MENU")
        {
            void ToggleStatsMenu() => UmbraMenu.menus[8].ToggleMenu();
            void ToggleCharacterListMenu() => UmbraMenu.menus[10].ToggleMenu();
            void ToggleBuffListMenu() => UmbraMenu.menus[11].ToggleMenu();
            void DoNothing() => Utility.StubbedFunction();

            giveMoney = new MulButton(this, 1, $"GIVE MONEY : {MoneyToGive}", GiveMoney, IncreaseMoney, DecreaseMoney);
            giveCoins = new MulButton(this, 2, $"GIVE LUNAR COINS : {CoinsToGive}", GiveLunarCoins, IncreaseCoins, DecreaseCoins);
            giveExperience = new MulButton(this, 3, $"GIVE EXPERIENCE : {XPToGive}", GiveXP, IncreaseXP, DecreaseXP);
            toggleStatsMod = new TogglableButton(this, 4, "STATS MENU : OFF", "STATS MENU : ON", ToggleStatsMenu, ToggleStatsMenu);
            toggleChangeCharacter = new TogglableButton(this, 5, "CHANGE CHARACTER : OFF", "CHANGE CHARACTER : ON", ToggleCharacterListMenu, ToggleCharacterListMenu);
            toggleBuff = new TogglableButton(this, 6, "GIVE BUFF MENU : OFF", "GIVE BUFF MENU : ON", ToggleBuffListMenu, ToggleBuffListMenu);
            removeBuffs = new NormalButton(this, 7, "REMOVE ALL BUFFS", RemoveAllBuffs);
            toggleAimbot = new TogglableButton(this, 8, "AIMBOT : OFF", "AIMBOT : ON", ToggleAimbot, ToggleAimbot);
            toggleGod = new TogglableButton(this, 9, "GOD MODE : OFF", "GOD MODE : ON", ToggleGodMode, ToggleGodMode);
            toggleSkillCD = new TogglableButton(this, 10, "INFINITE SKILLS : OFF", "INFINITE SKILLS : ON", ToggleSkillCD, ToggleSkillCD);
            unlockAll = new TogglableButton(this, 11, "UNLOCK ALL", "CONFIRM?", DoNothing, UnlockAll);

            giveMoney.MulChange += UpdateGiveMoney;
            giveCoins.MulChange += UpdateGiveCoins;
            giveExperience.MulChange += UpdateGiveXP;

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
                unlockAll
            });
            ActivatingButton = UmbraMenu.mainMenu.togglePlayer;
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
            XPToGive = 50;
            MoneyToGive = 50;
            CoinsToGive = 50;
            base.Reset();
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

        #region Player Hack Functions
        public static void RemoveAllBuffs()
        {
            foreach (BuffDef buffDef in UmbraMenu.buffs)
            {
                try
                {
                    while (UmbraMenu.LocalPlayerBody.HasBuff(buffDef))
                    {
                        UmbraMenu.LocalPlayerBody.RemoveBuff(buffDef);
                    }
                }
                catch
                {
                    continue;
                }
            }
        }

        public static void GiveXP()
        {
            UmbraMenu.LocalPlayer.GiveExperience(XPToGive);
        }

        public static void GiveMoney()
        {
            UmbraMenu.LocalPlayer.GiveMoney(MoneyToGive);
        }

        public static void GiveLunarCoins()
        {
            UmbraMenu.LocalNetworkUser.AwardLunarCoins(CoinsToGive);
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
                Vector3 direction = hurtBox.transform.position - aimRay.origin;
                inputBank.aimDirection = direction;
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
                        UmbraMenu.LocalPlayerBody.AddBuff(BuffCatalog.FindBuffIndex("Intangible"));
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
                        int itemELCCount = UmbraMenu.LocalPlayerInv.GetItemCount(ItemCatalog.FindItemIndex("ExtraLifeConsumed"));
                        int itemELCount = UmbraMenu.LocalPlayerInv.GetItemCount(ItemCatalog.FindItemIndex("ExtraLife"));

                        UmbraMenu.LocalHealth.SetField<bool>("wasAlive", false);
                        if (UmbraMenu.LocalHealth.health < 1 && reviveDoOnce)
                        {
                            reviveDoOnce = false;
                            if (itemELCount == 0)
                            {
                                ItemList.GiveItem(ItemCatalog.FindItemIndex("ExtraLife"));
                            }
                            UmbraMenu.LocalHealth.SetField<bool>("wasAlive", true);

                        } 
                        else if (UmbraMenu.LocalHealth.health > 0)
                        {
                            reviveDoOnce = true;
                        }

                        if (itemELCount > 0 && UmbraMenu.LocalHealth.health < 1)
                        {
                            UmbraMenu.LocalHealth.SetField<bool>("wasAlive", true);
                        }
                        else if (itemELCount > 0)
                        {
                            UmbraMenu.LocalPlayerInv.RemoveItem(ItemCatalog.FindItemIndex("ExtraLife"), itemELCCount);
                        }

                        if (itemELCCount > 0)
                        {
                            UmbraMenu.LocalPlayerInv.RemoveItem(ItemCatalog.FindItemIndex("ExtraLifeConsumed"), itemELCCount);
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

                        RemoveAllBuffs();
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
                        if (itemELCount > 0)
                        {
                            UmbraMenu.LocalPlayerInv.RemoveItem(ItemCatalog.FindItemIndex("ExtraLife"), itemELCount);
                        }
                        if (itemELCCount > 0)
                        {
                            UmbraMenu.LocalPlayerInv.RemoveItem(ItemCatalog.FindItemIndex("ExtraLifeConsumed"), itemELCCount);
                        }
                        reviveDoOnce = true;
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
        #endregion

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

        #region Mul Button Event Update Methods
        public void UpdateGiveMoney(object sender, EventArgs e)
        {
            giveMoney.SetText($"GIVE MONEY : {MoneyToGive}");
        }

        public void UpdateGiveCoins(object sender, EventArgs e)
        {
            giveCoins.SetText($"GIVE LUNAR COINS : {CoinsToGive}");
        }

        public void UpdateGiveXP(object sender, EventArgs e)
        {
            giveExperience.SetText($"GIVE EXPERIENCE : {XPToGive}");
        }
        #endregion
    }
}

