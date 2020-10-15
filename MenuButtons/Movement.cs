using System;
using System.Collections.Generic;
using UnityEngine;
using RoR2;


namespace UmbraMenu.MenuButtons
{
    public class Movement
    {
        private static readonly Menu currentMenu = (Menu)Utility.FindMenuById(2);

        public static bool jumpPackToggle, flightToggle, alwaysSprintToggle;

        public static TogglableButton toggleAlwaysSprint = new TogglableButton(currentMenu, 1, "A L W A Y S   S P R I N T : O F F", "A L W A Y S   S P R I N T : O N", ToggleSprint, ToggleSprint);
        public static TogglableButton toggleFlight = new TogglableButton(currentMenu, 2, "F L I G H T : O F F", "F L I G H T : O N", ToggleFlight, ToggleFlight);
        public static TogglableButton toggleJumpPack = new TogglableButton(currentMenu, 3, "J U M P - P A C K : O F F", "J U M P - P A C K : O N", ToggleJump, ToggleJump);

        public static List<Buttons> buttons = new List<Buttons>()
        {
            toggleAlwaysSprint,
            toggleFlight,
            toggleJumpPack
        };

        public static void AddButtonsToMenu()
        {
            currentMenu.buttons = buttons;
        }

        public static int jumpPackMul = 1;

        public static void AlwaysSprint()
        {
            var isMoving = UmbraMenu.LocalNetworkUser.inputPlayer.GetAxis("MoveVertical") != 0f || UmbraMenu.LocalNetworkUser.inputPlayer.GetAxis("MoveHorizontal") != 0f;
            var localUser = LocalUserManager.GetFirstLocalUser();
            if (localUser == null || localUser.cachedMasterController == null || localUser.cachedMasterController.master == null) return;

            var controller = localUser.cachedMasterController;
            var body = controller.master.GetBody();
            if (body && !body.isSprinting && !localUser.inputPlayer.GetButton("Sprint"))
            {
                if (isMoving)
                {
                    body.isSprinting = true;
                }
            }
        }

        public static void Flight()
        {
            try
            {
                if (Utility.GetCurrentCharacter().ToString() != "Loader")
                {
                    UmbraMenu.LocalPlayerBody.bodyFlags |= CharacterBody.BodyFlags.IgnoreFallDamage;
                }

                var forwardDirection = UmbraMenu.LocalPlayerBody.GetComponent<InputBankTest>().moveVector.normalized;
                var aimDirection = UmbraMenu.LocalPlayerBody.GetComponent<InputBankTest>().aimDirection.normalized;
                var upDirection = UmbraMenu.LocalPlayerBody.GetComponent<InputBankTest>().moveVector.y + 1;
                var downDirection = UmbraMenu.LocalPlayerBody.GetComponent<InputBankTest>().moveVector.y - 1;
                var isForward = Vector3.Dot(forwardDirection, aimDirection) > 0f;

                var isSprinting = alwaysSprintToggle ? UmbraMenu.LocalPlayerBody.isSprinting : UmbraMenu.LocalNetworkUser.inputPlayer.GetButton("Sprint");
                var isJumping = UmbraMenu.LocalNetworkUser.inputPlayer.GetButton("Jump");
                var isGoingDown = Input.GetKey(KeyCode.X);
                // ReSharper disable once CompareOfFloatsByEqualityOperator
                var isStrafing = UmbraMenu.LocalNetworkUser.inputPlayer.GetAxis("MoveVertical") != 0f;

                if (isSprinting)
                {
                    if (!alwaysSprintToggle && !UmbraMenu.LocalNetworkUser.inputPlayer.GetButton("Sprint"))
                    {
                        UmbraMenu.LocalPlayerBody.isSprinting = false;
                    }

                    UmbraMenu.LocalPlayerBody.characterMotor.velocity = forwardDirection * 100f;
                    UmbraMenu.LocalPlayerBody.characterMotor.velocity.y = upDirection * 0.510005f;
                    if (isStrafing)
                    {
                        if (isForward)
                        {
                            UmbraMenu.LocalPlayerBody.characterMotor.velocity.y = aimDirection.y * 100f;
                        }
                        else
                        {
                            UmbraMenu.LocalPlayerBody.characterMotor.velocity.y = aimDirection.y * -100f;
                        }
                    }
                }
                else
                {
                    UmbraMenu.LocalPlayerBody.characterMotor.velocity = forwardDirection * 50;
                    UmbraMenu.LocalPlayerBody.characterMotor.velocity.y = upDirection * 0.510005f;
                    if (isStrafing)
                    {
                        if (isForward)
                        {
                            UmbraMenu.LocalPlayerBody.characterMotor.velocity.y = aimDirection.y * 50;
                        }
                        else
                        {
                            UmbraMenu.LocalPlayerBody.characterMotor.velocity.y = aimDirection.y * -50;
                        }
                    }
                }
                if (isJumping)
                {
                    UmbraMenu.LocalPlayerBody.characterMotor.velocity.y = upDirection * 100;
                }
                if (isGoingDown)
                {
                    UmbraMenu.LocalPlayerBody.characterMotor.velocity.y = downDirection * 100;
                }
            }
            catch (NullReferenceException) { }
        }

        public static void JumpPack()
        {
            try
            {
                if (Utility.GetCurrentCharacter().ToString() != "Loader")
                {
                    UmbraMenu.LocalPlayerBody.bodyFlags |= CharacterBody.BodyFlags.IgnoreFallDamage;
                }

                var forwardDirection = UmbraMenu.LocalPlayerBody.GetComponent<InputBankTest>().moveVector.normalized;
                var aimDirection = UmbraMenu.LocalPlayerBody.GetComponent<InputBankTest>().aimDirection.normalized;
                var upDirection = UmbraMenu.LocalPlayerBody.GetComponent<InputBankTest>().moveVector.y + 1;
                var downDirection = UmbraMenu.LocalPlayerBody.GetComponent<InputBankTest>().moveVector.y - 1;
                var isForward = Vector3.Dot(forwardDirection, aimDirection) > 0f;

                var isJumping = UmbraMenu.LocalNetworkUser.inputPlayer.GetButton("Jump");
                // ReSharper disable once CompareOfFloatsByEqualityOperator

                if (isJumping)
                {
                    UmbraMenu.LocalPlayerBody.characterMotor.velocity.y = upDirection += 0.75f * jumpPackMul;
                    jumpPackMul++;

                    if (jumpPackMul > 200)
                    {
                        jumpPackMul = 200;
                    }
                }
                else
                {
                    jumpPackMul = 1;
                }
            }
            catch (NullReferenceException) 
            {
                Debug.Log("Jump - Pack is throwing a NullReferenceException");
            }
        }

        private static void ToggleFlight()
        {
            flightToggle = !flightToggle;
        }

        private static void ToggleSprint()
        {
            alwaysSprintToggle = !alwaysSprintToggle;
        }

        private static void ToggleJump()
        {
            jumpPackToggle = !jumpPackToggle;
        }
    }
}
