using System;
using System.Collections.Generic;
using UnityEngine;
using RoR2;
using Movement = UmbraMenu.Model.Cheats.Movement;


namespace UmbraMenu.View
{
    public sealed class MovementMenu : NormalMenu
    {
        public TogglableButton toggleAlwaysSprint;
        public TogglableButton toggleFlight;
        public TogglableButton toggleJumpPack;

        public MovementMenu() : base(2, 0, new Rect(374, 560, 20, 20), "MOVEMENT MENU")
        {
            toggleAlwaysSprint = new TogglableButton(this, 1, "ALWAYS SPRINT : OFF", "ALWAYS SPRINT : ON", ToggleSprint, ToggleSprint);
            toggleFlight = new TogglableButton(this, 2, "FLIGHT : OFF", "FLIGHT : ON", ToggleFlight, ToggleFlight);
            toggleJumpPack = new TogglableButton(this, 3, "JUMP PACK : OFF", "JUMP PACK : ON", ToggleJump, ToggleJump);

            AddButtons(new List<Button>()
            {
                toggleAlwaysSprint,
                toggleFlight,
                toggleJumpPack
            });
            ActivatingButton = UmbraModGUI.Instance.mainMenu.toggleMovement;
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
            Movement.jumpPackToggle = false;
            Movement.flightToggle = false;
            Movement.alwaysSprintToggle = false;
            Movement.jumpPackMul = 1;
            base.Reset();
        }

        private static void ToggleFlight()
        {
            Movement.flightToggle = !Movement.flightToggle;
        }

        private static void ToggleSprint()
        {
            Movement.alwaysSprintToggle = !Movement.alwaysSprintToggle;
        }

        private static void ToggleJump()
        {
            Movement.jumpPackToggle = !Movement.jumpPackToggle;
        }
    }
}
