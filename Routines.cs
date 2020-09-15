using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UmbraMenu
{
    public class Routines
    {
        public void CharacterRoutine()
        {
            UmbraMenu.GetCharacter();
        }

        /*public void LowResolutionRoutine()
        {
            if (lowResolutionMonitor)
            {
                Utility.MenusOpenKeys();
                LowResolutionMonitor();
            }
        }

        public void DevBuildRoutine()
        {
            if (Updates.devBuild)
            {
                if (_CharacterCollected)
                {
                    if (devDoOnce)
                    {
                        godToggle = true;
                        FlightToggle = true;
                        alwaysSprint = true;
                        LocalPlayer.GiveMoney(10000);
                        devDoOnce = false;
                    }
                }
            }
        }

        public void ESPRoutine()
        {
            if (renderInteractables)
            {
                Render.Interactables();
            }
            if (renderMobs)
            {
                Render.Mobs();
            }
            if (renderActiveMods)
            {
                Render.ActiveMods();
            }
            if (_isChestItemListOpen)
            {
                Chests.RenderClosestChest();
            }
        }

        public void EquipCooldownRoutine()
        {
            if (noEquipmentCooldown)
            {
                ItemManager.NoEquipmentCooldown();
            }
        }

        public void StatsRoutine()
        {
            if (UmbraMenu._CharacterCollected)
            {
                if (skillToggle)
                {
                    LocalSkills.ApplyAmmoPack();
                }
            }
        }

        public void AimBotRoutine()
        {
            if (aimBot)
                PlayerMod.AimBot();
        }

        public void GodRoutine()
        {
            if (godToggle)
            {
                PlayerMod.GodMode();
            }
            else
            {
                LocalHealth.godMode = false;
            }
        }

        public void SprintRoutine()
        {
            if (alwaysSprint)
                Movement.AlwaysSprint();
        }

        public void FlightRoutine()
        {
            if (FlightToggle)
            {
                Movement.Flight();
            }
        }

        public void ModStatsRoutine()
        {
            if (_CharacterCollected)
            {
                if (damageToggle)
                {
                    PlayerMod.LevelPlayersDamage();
                }
                if (critToggle)
                {
                    PlayerMod.LevelPlayersCrit();
                }
                if (attackSpeedToggle)
                {
                    PlayerMod.SetplayersAttackSpeed();
                }
                if (armorToggle)
                {
                    PlayerMod.SetplayersArmor();
                }
                if (moveSpeedToggle)
                {
                    PlayerMod.SetplayersMoveSpeed();
                }
                LocalPlayerBody.RecalculateStats();
            }
        }

        public void UpdateNavIndexRoutine()
        {
            if (navigationToggle)
            {
                Navigation.UpdateIndexValues();
            }
        }

        public void JumpPackRoutine()
        {
            if (jumpPackToggle)
            {
                Movement.JumpPack();
            }
        }*/
    }
}
