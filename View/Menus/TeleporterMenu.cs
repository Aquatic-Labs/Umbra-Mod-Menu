using UnityEngine;
using RoR2;
using System.Collections.Generic;
using System.Linq;
using System;
using Teleporter = UmbraMenu.Model.Cheats.Teleporter;

namespace UmbraMenu.View
{
    public class TeleporterMenu : NormalMenu
    {
        public NormalButton skipStage;
        public NormalButton instaTele;
        public NormalButton addMountain;
        public NormalButton spawnAll;
        public NormalButton spawnBlue;
        public NormalButton spawnCele;
        public NormalButton spawnGold;

        public TeleporterMenu() : base(5, 0, new Rect(10, 425, 20, 20), "TELEPORTER MENU")
        {
            void SpawnAllPortals() => Teleporter.SpawnPortals("all");
            void SpawnBluePortal() => Teleporter.SpawnPortals("blue");
            void SpawnCelestalPortal() => Teleporter.SpawnPortals("cele");
            void SpawnGoldPortal() => Teleporter.SpawnPortals("gold");
            skipStage = new NormalButton(this, 1, "SKIP STAGE", Teleporter.SkipStage);
            instaTele = new NormalButton(this, 2, "INSTA TELE/PURPLE CHARGE", Teleporter.InstaTeleporter);
            addMountain = new NormalButton(this, 3, $"ADD MOUNTAIN-COUNT : {Teleporter.mountainStacks}", Teleporter.AddMountain);
            spawnAll = new NormalButton(this, 4, "SPAWN ALL PORTALS", SpawnAllPortals);
            spawnBlue = new NormalButton(this, 5, "SPAWN BLUE PORTAL", SpawnBluePortal);
            spawnCele = new NormalButton(this, 6, "SPAWN CELESTAL PORTAL", SpawnCelestalPortal);
            spawnGold = new NormalButton(this, 7, "SPAWN GOLD PORTAL", SpawnGoldPortal);

            addMountain.Click += UpdateMountainStackButton;

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
            ActivatingButton = UmbraModGUI.Instance.mainMenu.toggleTeleporter;
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
            Teleporter.mountainStacks = 0;
            base.Reset();
        }

        private void UpdateMountainStackButton(object sender, EventArgs e)
        {
            addMountain.SetText($"ADD MOUNTAIN-COUNT : {Teleporter.mountainStacks}");
        }
    }
}
