using UnityEngine;
using RoR2;
using System.Collections.Generic;
using System;
using System.Linq;


namespace UmbraMenu.Menus
{
    public class Teleporter : Menu
    {
        private static readonly IMenu teleporter = new NormalMenu(5, new Rect(10, 425, 20, 20), "TELEPORTER MENU");
        private static int mountainStacks = 0;

        public Button skipStage;
        public Button instaTele;
        public Button addMountain;
        public Button spawnAll;
        public Button spawnBlue;
        public Button spawnCele;
        public Button spawnGold;

        public Teleporter() : base(teleporter)
        {
            if (UmbraMenu.characterCollected)
            {
                void SpawnAllPortals() => SpawnPortals("all");
                void SpawnBluePortal() => SpawnPortals("blue");
                void SpawnCelestalPortal() => SpawnPortals("cele");
                void SpawnGoldPortal() => SpawnPortals("gold");
                skipStage = new Button(new NormalButton(this, 1, "SKIP STAGE", SkipStage));
                instaTele = new Button(new NormalButton(this, 2, "INSTANT TELEPORTER", InstaTeleporter));
                addMountain = new Button(new NormalButton(this, 3, $"ADD MOUNTAIN-COUNT : {mountainStacks}", AddMountain));
                spawnAll = new Button(new NormalButton(this, 4, "SPAWN ALL PORTALS", SpawnAllPortals));
                spawnBlue = new Button(new NormalButton(this, 5, "SPAWN BLUE PORTAL", SpawnBluePortal));
                spawnCele = new Button(new NormalButton(this, 6, "SPAWN CELESTAL PORTAL", SpawnCelestalPortal));
                spawnGold = new Button(new NormalButton(this, 7, "SPAWN GOLD PORTAL", SpawnGoldPortal));

                AddButtons(new List<Button>()
                {
                    skipStage,
                    instaTele,
                    addMountain,
                    spawnAll,
                    spawnBlue,
                    spawnCele,
                    spawnGold
                });
                SetActivatingButton(Utility.FindButtonById(0, 5));
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
            mountainStacks = 0;
            base.Reset();
        }

        public void InstaTeleporter()
        {
            if (TeleporterInteraction.instance)
            {
                TeleporterInteraction.instance.holdoutZoneController.baseChargeDuration = 1;
            }
        }

        public void SkipStage()
        {
            Run.instance.AdvanceStage(Run.instance.nextStageScene);
        }

        public void AddMountain()
        {
            TeleporterInteraction.instance.AddShrineStack();
            mountainStacks = TeleporterInteraction.instance.shrineBonusStacks;
            addMountain.SetText($"ADD MOUNTAIN-COUNT : {mountainStacks}");
        }

        public void SpawnPortals(string portal)
        {
            if (TeleporterInteraction.instance)
            {
                if (portal.Equals("gold"))
                {
                    Debug.Log("UmbraMenu : Spawned Gold Portal");
                    TeleporterInteraction.instance.Network_shouldAttemptToSpawnGoldshoresPortal = true;
                    TeleporterInteraction.instance.shouldAttemptToSpawnGoldshoresPortal = true;
                }
                else if (portal.Equals("blue"))
                {
                    Debug.Log("UmbraMenu : Spawned Shop Portal");
                    TeleporterInteraction.instance.Network_shouldAttemptToSpawnShopPortal = true;
                    TeleporterInteraction.instance.shouldAttemptToSpawnShopPortal = true;
                }
                else if (portal.Equals("cele"))
                {
                    Debug.Log("UmbraMenu : Spawned Celestal Portal");
                    TeleporterInteraction.instance.Network_shouldAttemptToSpawnMSPortal = true;
                    TeleporterInteraction.instance.shouldAttemptToSpawnMSPortal = true;
                }
                else if (portal.Equals("all"))
                {
                    Debug.Log("UmbraMenu : Spawned All Portals");
                    TeleporterInteraction.instance.Network_shouldAttemptToSpawnGoldshoresPortal = true;
                    TeleporterInteraction.instance.Network_shouldAttemptToSpawnShopPortal = true;
                    TeleporterInteraction.instance.Network_shouldAttemptToSpawnMSPortal = true;

                    TeleporterInteraction.instance.shouldAttemptToSpawnGoldshoresPortal = true;
                    TeleporterInteraction.instance.shouldAttemptToSpawnShopPortal = true;
                    TeleporterInteraction.instance.shouldAttemptToSpawnMSPortal = true;
                }
            }
        }
    }
}
