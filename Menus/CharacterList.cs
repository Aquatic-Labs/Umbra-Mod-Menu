using RoR2;
using System.Collections.Generic;
using UnityEngine;

namespace UmbraMenu.Menus
{
    public class CharacterList : ListMenu
    {
        public CharacterList() : base(10, 1, new Rect(1503, 10, 20, 20), "CHARACTERS MENU")
        {
            List<Button> buttons = new List<Button>();
            for (int i = 0; i < UmbraMenu.bodyPrefabs.Count; i++)
            {
                int prefabIndex = i;
                void ButtonAction() => ChangeCharacter(prefabIndex);
                Button button = new NormalButton(this, i + 1, UmbraMenu.bodyPrefabs[i].name.Replace("Body", ""), ButtonAction);
                buttons.Add(button);
            }
            AddButtons(buttons);
            ActivatingButton = UmbraMenu.playerMenu.toggleChangeCharacter;
        }

        public override void Draw()
        {
            if (IsEnabled())
            {
                SetWindow();
                base.Draw();
            }
        }

        private void ChangeCharacter(int prefabIndex)
        {
            GameObject newBody = BodyCatalog.FindBodyPrefab(UmbraMenu.bodyPrefabs[prefabIndex].name);
            if (newBody == null) return;
            var localUser = LocalUserManager.GetFirstLocalUser();
            if (localUser == null || localUser.cachedMasterController == null || localUser.cachedMasterController.master == null) return;
            var master = localUser.cachedMasterController.master;

            master.bodyPrefab = newBody;
            master.Respawn(master.GetBody().transform.position, master.GetBody().transform.rotation);
            UmbraMenu.GetCharacter();
            if (Player.GodToggle)
            {
                Player.GodToggle = false;
                Player.DisabledGodMode();
                Player.GodToggle = true;
            }

            if (UmbraMenu.statsModMenu.changedFromDefault)
            {
                UmbraMenu.LocalPlayerBody.levelDamage = (float)UmbraMenu.statsModMenu.DamagePerLevel;
                UmbraMenu.LocalPlayerBody.levelCrit = (float)UmbraMenu.statsModMenu.CritPerLevel;
                UmbraMenu.LocalPlayerBody.baseAttackSpeed = UmbraMenu.statsModMenu.AttackSpeed;
                UmbraMenu.LocalPlayerBody.baseArmor = UmbraMenu.statsModMenu.Armor;
                UmbraMenu.LocalPlayerBody.baseMoveSpeed = UmbraMenu.statsModMenu.MoveSpeed;
            }
        }
    }
}
