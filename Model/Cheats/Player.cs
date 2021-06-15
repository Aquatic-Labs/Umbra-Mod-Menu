using System;
using System.Collections.Generic;
using System.Linq;
using RoR2;
using UnityEngine;
using System.Text;

namespace UmbraMenu.Model.Cheats
{
    public static class Player
    {
        public static bool SkillToggle, AimBotToggle, GodToggle;
        public static ulong XPToGive = 50;
        public static uint moneyToGive = 50, coinsToGive = 50;

        private static bool reviveDoOnce = true;

        public static int DamagePerLevel = 10, CritPerLevel = 1, AttackSpeed = 1, Armor = 0, MoveSpeed = 7, Multiplier = 10;
        public static bool changedFromDefault;

        public static void ApplyBuff(BuffDef buffDef)
        {
            var localUser = LocalUserManager.GetFirstLocalUser();
            if (localUser.cachedMasterController && localUser.cachedMasterController.master)
            {
                UmbraMod.Instance.LocalPlayerBody.AddBuff(buffDef);
            }
        }

        public static void RemoveAllBuffs()
        {
            foreach (BuffDef buffDef in UmbraMod.Instance.buffs)
            {
                try
                {
                    while (UmbraMod.Instance.LocalPlayerBody.HasBuff(buffDef))
                    {
                        UmbraMod.Instance.LocalPlayerBody.RemoveBuff(buffDef);
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
            UmbraMod.Instance.LocalPlayer.GiveExperience(XPToGive);
        }

        public static void GiveMoney()
        {
            UmbraMod.Instance.LocalPlayer.GiveMoney(moneyToGive);
        }

        public static void GiveLunarCoins()
        {
            UmbraMod.Instance.LocalNetworkUser.AwardLunarCoins(coinsToGive);
        }

        public static void AimBot()
        {
            if (View.GUIUtility.CursorIsVisible())
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
            switch (UmbraMod.Instance.GodVersion)
            {
                case 0:
                    {
                        // works
                        // Normal
                        UmbraMod.Instance.LocalHealth.godMode = true;
                        break;
                    }

                case 1:
                    {
                        // works
                        // Buff
                        UmbraMod.Instance.LocalPlayerBody.AddBuff(BuffCatalog.FindBuffIndex("Intangible"));
                        break;
                    }

                case 2:
                    {
                        // works
                        // Regen
                        UmbraMod.Instance.LocalHealth.Heal(float.MaxValue, new ProcChainMask(), false);
                        break;
                    }

                case 3:
                    {
                        // works
                        // Negative
                        UmbraMod.Instance.LocalHealth.SetField<bool>("wasAlive", false);
                        break;
                    }

                case 4:
                    {
                        // works
                        // Revive
                        int itemELCCount = UmbraMod.Instance.LocalPlayerInv.GetItemCount(ItemCatalog.FindItemIndex("ExtraLifeConsumed"));
                        int itemELCount = UmbraMod.Instance.LocalPlayerInv.GetItemCount(ItemCatalog.FindItemIndex("ExtraLife"));

                        UmbraMod.Instance.LocalHealth.SetField<bool>("wasAlive", false);
                        if (UmbraMod.Instance.LocalHealth.health < 1 && reviveDoOnce)
                        {
                            reviveDoOnce = false;
                            if (itemELCount == 0)
                            {
                                Items.GiveItem(ItemCatalog.FindItemIndex("ExtraLife"));
                            }
                            UmbraMod.Instance.LocalHealth.SetField<bool>("wasAlive", true);

                        }
                        else if (UmbraMod.Instance.LocalHealth.health > 0)
                        {
                            reviveDoOnce = true;
                        }

                        if (itemELCount > 0 && UmbraMod.Instance.LocalHealth.health < 1)
                        {
                            UmbraMod.Instance.LocalHealth.SetField<bool>("wasAlive", true);
                        }
                        else if (itemELCount > 0)
                        {
                            UmbraMod.Instance.LocalPlayerInv.RemoveItem(ItemCatalog.FindItemIndex("ExtraLife"), itemELCCount);
                        }

                        if (itemELCCount > 0)
                        {
                            UmbraMod.Instance.LocalPlayerInv.RemoveItem(ItemCatalog.FindItemIndex("ExtraLifeConsumed"), itemELCCount);
                        }
                        break;
                    }


                default:
                    break;
            }
        }

        public static void DisabledGodMode()
        {
            switch (UmbraMod.Instance.GodVersion)
            {
                case 0:
                    {
                        UmbraMod.Instance.LocalHealth.godMode = false;
                        break;
                    }

                case 1:
                    {

                        RemoveAllBuffs();
                        break;
                    }

                case 3:
                    {
                        if (UmbraMod.Instance.LocalHealth.health < 0)
                        {
                            UmbraMod.Instance.LocalHealth.health = 1;
                        }
                        UmbraMod.Instance.LocalHealth.SetField<bool>("wasAlive", true);
                        break;
                    }

                case 4:
                    {
                        if (UmbraMod.Instance.LocalHealth.health < 0)
                        {
                            UmbraMod.Instance.LocalHealth.health = 1;
                        }
                        UmbraMod.Instance.LocalHealth.SetField<bool>("wasAlive", true);

                        int itemELCount = UmbraMod.Instance.LocalPlayerInv.GetItemCount(ItemCatalog.FindItemIndex("ExtraLife"));
                        int itemELCCount = UmbraMod.Instance.LocalPlayerInv.GetItemCount(ItemCatalog.FindItemIndex("ExtraLifeConsumed"));
                        if (itemELCount > 0)
                        {
                            UmbraMod.Instance.LocalPlayerInv.RemoveItem(ItemCatalog.FindItemIndex("ExtraLife"), itemELCount);
                        }
                        if (itemELCCount > 0)
                        {
                            UmbraMod.Instance.LocalPlayerInv.RemoveItem(ItemCatalog.FindItemIndex("ExtraLifeConsumed"), itemELCCount);
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
            var unlockables = UmbraMod.Instance.unlockables;
            foreach (var unlockable in unlockables)
            {
                NetworkUser networkUser = Util.LookUpBodyNetworkUser(UmbraMod.Instance.LocalPlayerBody);
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
                    NetworkUser networkUser = Util.LookUpBodyNetworkUser(UmbraMod.Instance.LocalPlayerBody);
                    if (networkUser)
                    {
                        networkUser.ServerHandleUnlock(unlockableDef);
                    }
                }
            }
        }

        public static void LevelPlayersDamage()
        {
            try
            {
                changedFromDefault = true;
                UmbraMod.Instance.LocalPlayerBody.levelDamage = (float)DamagePerLevel;
                UmbraMod.Instance.LocalPlayerBody.RecalculateStats();
            }
            catch (NullReferenceException)
            {
                Debug.Log("Stats2");

            }
        }

        public static void LevelPlayersCrit()
        {
            try
            {
                changedFromDefault = true;
                UmbraMod.Instance.LocalPlayerBody.levelCrit = (float)CritPerLevel;
                UmbraMod.Instance.LocalPlayerBody.RecalculateStats();
            }
            catch (NullReferenceException)
            {
                Debug.Log("Stats1");
            }
        }

        public static void SetPlayersAttackSpeed()
        {
            try
            {
                changedFromDefault = true;
                UmbraMod.Instance.LocalPlayerBody.baseAttackSpeed = AttackSpeed;
                UmbraMod.Instance.LocalPlayerBody.RecalculateStats();
            }
            catch (NullReferenceException)
            {
                Debug.Log("Stats3");

            }
        }

        public static void SetPlayersArmor()
        {
            try
            {
                changedFromDefault = true;
                UmbraMod.Instance.LocalPlayerBody.baseArmor = Armor;
                UmbraMod.Instance.LocalPlayerBody.RecalculateStats();
            }
            catch (NullReferenceException)
            {
                Debug.Log("Stats4");

            }
        }

        public static void SetPlayersMoveSpeed()
        {
            try
            {
                changedFromDefault = true;
                UmbraMod.Instance.LocalPlayerBody.baseMoveSpeed = MoveSpeed;
                UmbraMod.Instance.LocalPlayerBody.RecalculateStats();
            }
            catch (NullReferenceException)
            {
                Debug.Log("Stats5");

            }
        }

        public static void ChangeCharacter(int prefabIndex)
        {
            GameObject newBody = BodyCatalog.FindBodyPrefab(UmbraMod.Instance.bodyPrefabs[prefabIndex].name);
            if (newBody == null) return;
            var localUser = LocalUserManager.GetFirstLocalUser();
            if (localUser == null || localUser.cachedMasterController == null || localUser.cachedMasterController.master == null) return;
            var master = localUser.cachedMasterController.master;

            master.bodyPrefab = newBody;
            master.Respawn(master.GetBody().transform.position, master.GetBody().transform.rotation);
            UmbraMod.Instance.GetCharacter();
            if (GodToggle)
            {
                GodToggle = false;
                DisabledGodMode();
                GodToggle = true;
            }

            if (Player.changedFromDefault)
            {
                UmbraMod.Instance.LocalPlayerBody.levelDamage = (float)DamagePerLevel;
                UmbraMod.Instance.LocalPlayerBody.levelCrit = (float)CritPerLevel;
                UmbraMod.Instance.LocalPlayerBody.baseAttackSpeed = AttackSpeed;
                UmbraMod.Instance.LocalPlayerBody.baseArmor = Armor;
                UmbraMod.Instance.LocalPlayerBody.baseMoveSpeed = MoveSpeed;
            }
        }
    }
}
