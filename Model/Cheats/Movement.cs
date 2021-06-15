using System;
using System.Collections.Generic;
using UnityEngine;
using RoR2;
using Umbra = UmbraMenu.Model.UmbraMod;

namespace UmbraMenu.Model.Cheats
{
    public static class Movement
    {
        public static bool jumpPackToggle, flightToggle, alwaysSprintToggle;
        public static int jumpPackMul = 1;

        public static void AlwaysSprint()
        {
            var isMoving = Umbra.Instance.LocalNetworkUser.inputPlayer.GetAxis("MoveVertical") != 0f || Umbra.Instance.LocalNetworkUser.inputPlayer.GetAxis("MoveHorizontal") != 0f;
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
                    Umbra.Instance.LocalPlayerBody.bodyFlags |= CharacterBody.BodyFlags.IgnoreFallDamage;
                }

                var forwardDirection = Umbra.Instance.LocalPlayerBody.GetComponent<InputBankTest>().moveVector.normalized;
                var aimDirection = Umbra.Instance.LocalPlayerBody.GetComponent<InputBankTest>().aimDirection.normalized;
                var upDirection = Umbra.Instance.LocalPlayerBody.GetComponent<InputBankTest>().moveVector.y + 1;
                var downDirection = Umbra.Instance.LocalPlayerBody.GetComponent<InputBankTest>().moveVector.y - 1;
                var isForward = Vector3.Dot(forwardDirection, aimDirection) > 0f;

                var isSprinting = alwaysSprintToggle ? Umbra.Instance.LocalPlayerBody.isSprinting : Umbra.Instance.LocalNetworkUser.inputPlayer.GetButton("Sprint");
                var isJumping = Umbra.Instance.LocalNetworkUser.inputPlayer.GetButton("Jump");
                var isGoingDown = Input.GetKey(KeyCode.X);
                // ReSharper disable once CompareOfFloatsByEqualityOperator
                var isStrafing = Umbra.Instance.LocalNetworkUser.inputPlayer.GetAxis("MoveVertical") != 0f;

                if (isSprinting)
                {
                    if (!alwaysSprintToggle && !Umbra.Instance.LocalNetworkUser.inputPlayer.GetButton("Sprint"))
                    {
                        Umbra.Instance.LocalPlayerBody.isSprinting = false;
                    }

                    Umbra.Instance.LocalPlayerBody.characterMotor.velocity = forwardDirection * 100f;
                    Umbra.Instance.LocalPlayerBody.characterMotor.velocity.y = upDirection * 0.510005f;
                    if (isStrafing)
                    {
                        if (isForward)
                        {
                            Umbra.Instance.LocalPlayerBody.characterMotor.velocity.y = aimDirection.y * 100f;
                        }
                        else
                        {
                            Umbra.Instance.LocalPlayerBody.characterMotor.velocity.y = aimDirection.y * -100f;
                        }
                    }
                }
                else
                {
                    Umbra.Instance.LocalPlayerBody.characterMotor.velocity = forwardDirection * 50;
                    Umbra.Instance.LocalPlayerBody.characterMotor.velocity.y = upDirection * 0.510005f;
                    if (isStrafing)
                    {
                        if (isForward)
                        {
                            Umbra.Instance.LocalPlayerBody.characterMotor.velocity.y = aimDirection.y * 50;
                        }
                        else
                        {
                            Umbra.Instance.LocalPlayerBody.characterMotor.velocity.y = aimDirection.y * -50;
                        }
                    }
                }
                if (isJumping)
                {
                    Umbra.Instance.LocalPlayerBody.characterMotor.velocity.y = upDirection * 100;
                }
                if (isGoingDown)
                {
                    Umbra.Instance.LocalPlayerBody.characterMotor.velocity.y = downDirection * 100;
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
                    Umbra.Instance.LocalPlayerBody.bodyFlags |= CharacterBody.BodyFlags.IgnoreFallDamage;
                }

                var forwardDirection = Umbra.Instance.LocalPlayerBody.GetComponent<InputBankTest>().moveVector.normalized;
                var aimDirection = Umbra.Instance.LocalPlayerBody.GetComponent<InputBankTest>().aimDirection.normalized;
                var upDirection = Umbra.Instance.LocalPlayerBody.GetComponent<InputBankTest>().moveVector.y + 1;
                var downDirection = Umbra.Instance.LocalPlayerBody.GetComponent<InputBankTest>().moveVector.y - 1;
                var isForward = Vector3.Dot(forwardDirection, aimDirection) > 0f;

                var isJumping = Umbra.Instance.LocalNetworkUser.inputPlayer.GetButton("Jump");
                // ReSharper disable once CompareOfFloatsByEqualityOperator

                if (isJumping)
                {
                    Umbra.Instance.LocalPlayerBody.characterMotor.velocity.y = upDirection += 0.75f * jumpPackMul;
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
