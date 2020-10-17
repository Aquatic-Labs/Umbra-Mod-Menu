using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using RoR2;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace UmbraMenu.MenuButtons
{
    public class Player
    {
        private static readonly Menu currentMenu = (Menu)Utility.FindMenuById(1);

        public static bool skillToggle, aimBotToggle, godToggle;

        private static ulong xpToGive = 50;
        public static ulong XPToGive
        {
            get
            {
                return xpToGive;
            }
            set
            {
                xpToGive = value;
                giveExperience.text = $"G I V E   E X P E R I E N C E : {xpToGive}";
            }
        }
        private static uint moneyToGive = 50, coinsToGive = 50;
        public static uint MoneyToGive
        {
            get
            {
                return moneyToGive;
            }
            set
            {
                moneyToGive = value;
                giveMoney.text = $"G I V E   M O N E Y : {moneyToGive}";
            }
        }
        public static uint CoinsToGive
        {
            get
            {
                return coinsToGive;
            }
            set
            {
                coinsToGive = value;
                giveCoins.text = $"G I V E   L U N A R   C O I N S : {coinsToGive}";
            }
        }

        private static void ToggleStatsMenu() => ToggleMenu(UmbraMenu.menus[8]);
        private static void ToggleCharacterListMenu() => ToggleMenu(UmbraMenu.listMenus[0]);
        private static void ToggleBuffListMenu() => ToggleMenu(UmbraMenu.listMenus[1]);
        public static MulButton giveMoney = new MulButton(currentMenu, 1, $"G I V E   M O N E Y : {MoneyToGive}", GiveMoney, IncreaseMoney, DecreaseMoney);
        public static MulButton giveCoins = new MulButton(currentMenu, 2, $"G I V E   L U N A R   C O I N S : {CoinsToGive}", GiveLunarCoins, IncreaseCoins, DecreaseCoins);
        public static MulButton giveExperience = new MulButton(currentMenu, 3, $"G I V E   E X P E R I E N C E : {XPToGive}", GiveXP, IncreaseXP, DecreaseXP);
        public static TogglableButton toggleStatsMod = new TogglableButton(currentMenu, 4, "S T A T S   M E N U : O F F", "S T A T S   M E N U : O N", ToggleStatsMenu, ToggleStatsMenu);
        public static TogglableButton toggleChangeCharacter = new TogglableButton(currentMenu, 5, "C H A N G E   C H A R A C T E R : O F F", "C H A N G E   C H A R A C T E R : O N", ToggleCharacterListMenu, ToggleCharacterListMenu);
        public static TogglableButton toggleBuff = new TogglableButton(currentMenu, 6, "G I V E   B U F F   M E N U : O F F", "G I V E   B U F F   M E N U : O N", ToggleBuffListMenu, ToggleBuffListMenu);
        public static Button removeBuffs = new Button(currentMenu, 7, "R E M O V E   A L L   B U F F S", RemoveAllBuffs);
        public static TogglableButton toggleAimbot = new TogglableButton(currentMenu, 8, "A I M B O T : O F F", "A I M B O T : O N", ToggleAimbot, ToggleAimbot);
        public static TogglableButton toggleGod = new TogglableButton(currentMenu, 9, "G O D   M O D E : O F F", "G O D   M O D E : O N", ToggleGodMode, ToggleGodMode);
        public static TogglableButton toggleSkillCD = new TogglableButton(currentMenu, 10, "I N F I N I T E   S K I L L S : O F F", "I N F I N I T E   S K I L L S : O N", ToggleSkillCD, ToggleSkillCD);
        public static Button unlockAll = new Button(currentMenu, 11, "U N L O C K   A L L", UnlockAll);

        private static List<Buttons> buttons = new List<Buttons>()
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
        };

        public static void AddButtonsToMenu()
        {
            currentMenu.buttons = buttons;
        }

        public static void ToggleMenu(Menu menu)
        {
            menu.enabled = !menu.enabled;
        }

        public static void ToggleMenu(ListMenu menu)
        {
            menu.enabled = !menu.enabled;
        }

        public static void ToggleAimbot()
        {
            aimBotToggle = !aimBotToggle;
        }

        public static void ToggleGodMode()
        {
            godToggle = !godToggle;
        }

        public static void ToggleSkillCD()
        {
            skillToggle = !skillToggle;
        }

        public static void RemoveAllBuffs()
        {
            foreach (string buffName in Enum.GetNames(typeof(BuffIndex)))
            {
                BuffIndex buffIndex = (BuffIndex)Enum.Parse(typeof(BuffIndex), buffName);
                while (UmbraMenu.LocalPlayerBody.HasBuff(buffIndex))
                {
                    UmbraMenu.LocalPlayerBody.RemoveBuff(buffIndex);
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
                Vector3 direction = hurtBox.transform.position - aimRay.origin;
                inputBank.aimDirection = direction;
            }
        }

        public static void GodMode()
        {
            UmbraMenu.LocalHealth.godMode = true;
        }

        public static void UnlockAll()
        {
            //Goes through resource file containing all unlockables... Easily updatable, just paste "RoR2.UnlockCatalog" and GetAllUnlockable does the rest.
            //This is needed to unlock logs
            foreach (var unlockableName in UmbraMenu.unlockableNames)
            {
                var unlockableDef = UnlockableCatalog.GetUnlockableDef(unlockableName);
                NetworkUser networkUser = Util.LookUpBodyNetworkUser(UmbraMenu.LocalPlayerBody);
                if (networkUser)
                {
                    networkUser.ServerHandleUnlock(unlockableDef);
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
            }

            //All items and equipments
            foreach (string itemName in Enum.GetNames(typeof(ItemIndex)))
            {
                ItemIndex itemIndex = (ItemIndex)Enum.Parse(typeof(ItemIndex), itemName);
                profile.DiscoverPickup(PickupCatalog.FindPickupIndex(itemIndex));
            }

            foreach (string equipmentName in Enum.GetNames(typeof(EquipmentIndex)))
            {
                EquipmentIndex equipmentIndex = (EquipmentIndex)Enum.Parse(typeof(EquipmentIndex), equipmentName);
                profile.DiscoverPickup(PickupCatalog.FindPickupIndex(equipmentIndex));
            }
        }

        #region Increase/Decrease Value Actions
        public static void IncreaseMoney()
        {
            if (MoneyToGive >= 50)
                MoneyToGive += 50;
        }

        public static void IncreaseCoins()
        {
            if (CoinsToGive >= 10)
                CoinsToGive += 10;
        }

        public static void IncreaseXP()
        {
            if (XPToGive >= 50)
                XPToGive += 50;
        }

        public static void DecreaseMoney()
        {
            if (MoneyToGive > 50)
               MoneyToGive -= 50;
        }

        public static void DecreaseCoins()
        {
            if (CoinsToGive > 10)
                CoinsToGive -= 10;
        }

        public static void DecreaseXP()
        {
            if (XPToGive > 50)
                XPToGive -= 50;
        }
        #endregion
    }
}
