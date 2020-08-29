using System;
using UnityEngine;
using RoR2;

namespace UmbraRoR
{
    class Movement : MonoBehaviour
    {
        public static int jumpPackMul = 1;

        public static void AlwaysSprint()
        {
            var isMoving = Main.LocalNetworkUser.inputPlayer.GetAxis("MoveVertical") != 0f || Main.LocalNetworkUser.inputPlayer.GetAxis("MoveHorizontal") != 0f;
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
                if (PlayerMod.GetCurrentCharacter().ToString() != "Loader")
                {
                    Main.LocalPlayerBody.bodyFlags |= CharacterBody.BodyFlags.IgnoreFallDamage;
                }

                var forwardDirection = Main.LocalPlayerBody.GetComponent<InputBankTest>().moveVector.normalized;
                var aimDirection = Main.LocalPlayerBody.GetComponent<InputBankTest>().aimDirection.normalized;
                var upDirection = Main.LocalPlayerBody.GetComponent<InputBankTest>().moveVector.y + 1;
                var downDirection = Main.LocalPlayerBody.GetComponent<InputBankTest>().moveVector.y - 1;
                var isForward = Vector3.Dot(forwardDirection, aimDirection) > 0f;

                var isSprinting = Main.alwaysSprint ? Main.LocalPlayerBody.isSprinting : Main.LocalNetworkUser.inputPlayer.GetButton("Sprint");
                var isJumping = Main.LocalNetworkUser.inputPlayer.GetButton("Jump");
                var isGoingDown = Input.GetKey(KeyCode.X);
                // ReSharper disable once CompareOfFloatsByEqualityOperator
                var isStrafing = Main.LocalNetworkUser.inputPlayer.GetAxis("MoveVertical") != 0f;

                if (isSprinting)
                {
                    if (!Main.alwaysSprint && !Main.LocalNetworkUser.inputPlayer.GetButton("Sprint"))
                    {
                        Main.LocalPlayerBody.isSprinting = false;
                    }

                    Main.LocalPlayerBody.characterMotor.velocity = forwardDirection * 100f;
                    Main.LocalPlayerBody.characterMotor.velocity.y = upDirection * 0.510005f;
                    if (isStrafing)
                    {
                        if (isForward)
                        {
                            Main.LocalPlayerBody.characterMotor.velocity.y = aimDirection.y * 100f;
                        }
                        else
                        {
                            Main.LocalPlayerBody.characterMotor.velocity.y = aimDirection.y * -100f;
                        }
                    }
                }
                else
                {
                    Main.LocalPlayerBody.characterMotor.velocity = forwardDirection * 50;
                    Main.LocalPlayerBody.characterMotor.velocity.y = upDirection * 0.510005f;
                    if (isStrafing)
                    {
                        if (isForward)
                        {
                            Main.LocalPlayerBody.characterMotor.velocity.y = aimDirection.y * 50;
                        }
                        else
                        {
                            Main.LocalPlayerBody.characterMotor.velocity.y = aimDirection.y * -50;
                        }
                    }
                }
                if (isJumping)
                {
                    Main.LocalPlayerBody.characterMotor.velocity.y = upDirection * 100;
                }
                if (isGoingDown)
                {
                    Main.LocalPlayerBody.characterMotor.velocity.y = downDirection * 100;
                }
            }
            catch (NullReferenceException) { }
        }

        public static void JumpPack()
        {
            try
            {
                if (PlayerMod.GetCurrentCharacter().ToString() != "Loader")
                {
                    Main.LocalPlayerBody.bodyFlags |= CharacterBody.BodyFlags.IgnoreFallDamage;
                }

                var forwardDirection = Main.LocalPlayerBody.GetComponent<InputBankTest>().moveVector.normalized;
                var aimDirection = Main.LocalPlayerBody.GetComponent<InputBankTest>().aimDirection.normalized;
                var upDirection = Main.LocalPlayerBody.GetComponent<InputBankTest>().moveVector.y + 1;
                var downDirection = Main.LocalPlayerBody.GetComponent<InputBankTest>().moveVector.y - 1;
                var isForward = Vector3.Dot(forwardDirection, aimDirection) > 0f;

                var isJumping = Main.LocalNetworkUser.inputPlayer.GetButton("Jump");
                // ReSharper disable once CompareOfFloatsByEqualityOperator

                if (isJumping)
                {
                    Main.LocalPlayerBody.characterMotor.velocity.y = upDirection += 0.75f * jumpPackMul;
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
