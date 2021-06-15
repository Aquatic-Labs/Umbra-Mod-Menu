using UnityEngine;
using RoR2;
using System.Collections.Generic;
using System;
using System.Linq;
using Spawn = UmbraMenu.Model.Cheats.Spawn;

namespace UmbraMenu.View
{
    public class SpawnMenu : NormalMenu
    {
        public MulButton changeMinDistance;
        public MulButton changeMaxDistance;
        public MulButton changeTeamIndex;
        public TogglableButton toggleSpawnListMenu;
        public NormalButton killAll;
        public NormalButton destroyInteractables;

        public SpawnMenu() : base(4, 0, new Rect(738, 515, 20, 20), "SPAWN MENU")
        {

            Action DoNothing = () => { return; };

            changeMinDistance = new MulButton(this, 1, $"MIN DISTANCE : {Spawn.minDistance}", DoNothing, IncreaseMinDistance, DecreaseMinDistance);
            changeMaxDistance = new MulButton(this, 2, $"MAX DISTANCE : {Spawn.maxDistance}", DoNothing, IncreaseMaxDistance, DecreaseMaxDistance);
            changeTeamIndex = new MulButton(this, 3, $"TEAM : {Spawn.team[Spawn.teamIndex]}", DoNothing, IncreaseTeamIndex, DecreaseTeamIndex);
            toggleSpawnListMenu = new TogglableButton(this, 4, "SPAWN LIST : OFF", "SPAWN LIST : ON", ToggleSpawnListMenu, ToggleSpawnListMenu);
            killAll = new NormalButton(this, 5, "KILL ALL", Spawn.KillAllMobs);
            destroyInteractables = new NormalButton(this, 6, "DESTROY INTERACTABLES", Spawn.DestroySpawnedInteractables);

            changeMinDistance.MulChange += UpdateMinDist;
            changeMaxDistance.MulChange += UpdateMaxDist;
            changeTeamIndex.MulChange += UpdateTeamIndex;

            AddButtons(new List<Button>()
            {
                changeMinDistance,
                changeMaxDistance,
                changeTeamIndex,
                toggleSpawnListMenu,
                killAll,
                destroyInteractables
            });
            ActivatingButton = UmbraModGUI.Instance.mainMenu.toggleSpawn;
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
            Spawn.teamIndex = 0;
            Spawn.minDistance = 3f;
            Spawn.maxDistance = 40f;
            base.Reset();
        }

        public void UpdateMinDist(object sender, EventArgs e)
        {
            changeMinDistance.SetText($"MIN DISTANCE : {Spawn.minDistance}");
        }

        public void UpdateMaxDist(object sender, EventArgs e)
        {
            changeMaxDistance.SetText($"MAX DISTANCE : {Spawn.maxDistance}");
        }

        public void UpdateTeamIndex(object sender, EventArgs e)
        {
            changeTeamIndex.SetText($"TEAM : {Spawn.team[Spawn.teamIndex]}");
        }

        private void ToggleSpawnListMenu()
        {
            UmbraModGUI.Instance.menus[15].ToggleMenu();
        }

        #region Increase/Decrease Value Actions
        public void IncreaseMinDistance()
        {
            if (Spawn.minDistance < Spawn.maxDistance)
            {
                Spawn.minDistance += 1;
            }
        }

        public void IncreaseMaxDistance()
        {
            if (Spawn.maxDistance >= Spawn.minDistance)
            {
                Spawn.maxDistance += 1;
            }
        }
        public void IncreaseTeamIndex()
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

        public void DecreaseMinDistance()
        {
            if (Spawn.minDistance > 0)
            {
                Spawn.minDistance -= 1;
            }
        }

        public void DecreaseMaxDistance()
        {
            if (Spawn.maxDistance > Spawn.minDistance)
            {
                Spawn.maxDistance -= 1;
            }
        }

        public void DecreaseTeamIndex()
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
        #endregion
    }
}
