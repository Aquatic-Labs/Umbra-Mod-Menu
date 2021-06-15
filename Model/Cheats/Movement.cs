using System;
using System.Collections.Generic;
using UnityEngine;
using RoR2;

namespace UmbraMenu.Model.Cheats
{
    public static class Movement
    {
        public static bool jumpPackToggle, flightToggle, alwaysSprintToggle;
        public static int jumpPackMul = 1;

        public static void AlwaysSprint()
        {
            var isMoving = UmbraMod.LocalNetworkUser.inputPlayer.GetAxis("MoveVertical") != 0f || UmbraMod.LocalNetworkUser.inputPlayer.GetAxis("MoveHorizontal") != 0f;
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
                    UmbraMod.LocalPlayerBody.bodyFlags |= CharacterBody.BodyFlags.IgnoreFallDamage;
                }

                var forwardDirection = UmbraMod.LocalPlayerBody.GetComponent<InputBankTest>().moveVector.normalized;
                var aimDirection = UmbraMod.LocalPlayerBody.GetComponent<InputBankTest>().aimDirection.normalized;
                var upDirection = UmbraMod.LocalPlayerBody.GetComponent<InputBankTest>().moveVector.y + 1;
                var downDirection = UmbraMod.LocalPlayerBody.GetComponent<InputBankTest>().moveVector.y - 1;
                var isForward = Vector3.Dot(forwardDirection, aimDirection) > 0f;

                var isSprinting = alwaysSprintToggle ? UmbraMod.LocalPlayerBody.isSprinting : UmbraMod.LocalNetworkUser.inputPlayer.GetButton("Sprint");
                var isJumping = UmbraMod.LocalNetworkUser.inputPlayer.GetButton("Jump");
                var isGoingDown = Input.GetKey(KeyCode.X);
                // ReSharper disable once CompareOfFloatsByEqualityOperator
                var isStrafing = UmbraMod.LocalNetworkUser.inputPlayer.GetAxis("MoveVertical") != 0f;

                if (isSprinting)
                {
                    if (!alwaysSprintToggle && !UmbraMod.LocalNetworkUser.inputPlayer.GetButton("Sprint"))
                    {
                        UmbraMod.LocalPlayerBody.isSprinting = false;
                    }

                    UmbraMod.LocalPlayerBody.characterMotor.velocity = forwardDirection * 100f;
                    UmbraMod.LocalPlayerBody.characterMotor.velocity.y = upDirection * 0.510005f;
                    if (isStrafing)
                    {
                        if (isForward)
                        {
                            UmbraMod.LocalPlayerBody.characterMotor.velocity.y = aimDirection.y * 100f;
                        }
                        else
                        {
                            UmbraMod.LocalPlayerBody.characterMotor.velocity.y = aimDirection.y * -100f;
                        }
                    }
                }
                else
                {
                    UmbraMod.LocalPlayerBody.characterMotor.velocity = forwardDirection * 50;
                    UmbraMod.LocalPlayerBody.characterMotor.velocity.y = upDirection * 0.510005f;
                    if (isStrafing)
                    {
                        if (isForward)
                        {
                            UmbraMod.LocalPlayerBody.characterMotor.velocity.y = aimDirection.y * 50;
                        }
                        else
                        {
                            UmbraMod.LocalPlayerBody.characterMotor.velocity.y = aimDirection.y * -50;
                        }
                    }
                }
                if (isJumping)
                {
                    UmbraMod.LocalPlayerBody.characterMotor.velocity.y = upDirection * 100;
                }
                if (isGoingDown)
                {
                    UmbraMod.LocalPlayerBody.characterMotor.velocity.y = downDirection * 100;
                }
            }
            catch { }
        }

        public static void JumpPack()
        {
            try
            {
                if (Utility.GetCurrentCharacter().ToString() != "Loader")
                {
                    UmbraMod.LocalPlayerBody.bodyFlags |= CharacterBody.BodyFlags.IgnoreFallDamage;
                }

                var forwardDirection = UmbraMod.LocalPlayerBody.GetComponent<InputBankTest>().moveVector.normalized;
                var aimDirection = UmbraMod.LocalPlayerBody.GetComponent<InputBankTest>().aimDirection.normalized;
                var upDirection = UmbraMod.LocalPlayerBody.GetComponent<InputBankTest>().moveVector.y + 1;
                var downDirection = UmbraMod.LocalPlayerBody.GetComponent<InputBankTest>().moveVector.y - 1;
                var isForward = Vector3.Dot(forwardDirection, aimDirection) > 0f;

                var isJumping = UmbraMod.LocalNetworkUser.inputPlayer.GetButton("Jump");
                // ReSharper disable once CompareOfFloatsByEqualityOperator

                if (isJumping)
                {
                    UmbraMod.LocalPlayerBody.characterMotor.velocity.y = upDirection += 0.75f * jumpPackMul;
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
            catch (NullReferenceException) { }
        }
    }
}
