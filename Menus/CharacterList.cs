using RoR2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace UmbraMenu.Menus
{
    public class CharacterList : Menu
    {
        private static readonly IMenu characterList = new ListMenu(10, new Rect(1503, 10, 20, 20), "CHARACTERS MENU");

        public CharacterList() : base(characterList)
        {
            if (UmbraMenu.characterCollected)
            {
                List<Button> buttons = new List<Button>();
                for (int i = 0; i < UmbraMenu.bodyPrefabs.Count; i++)
                {
                    int prefabIndex = i;
                    void ButtonAction() => ChangeCharacter(prefabIndex);
                    Button button = new Button(new NormalButton(this, i + 1, UmbraMenu.bodyPrefabs[i].name.Replace("Body", ""), ButtonAction));
                    buttons.Add(button);
                }
                AddButtons(buttons);
                SetActivatingButton(Utility.FindButtonById(1, 5));
                SetPrevMenuId(1);
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
            Utility.SoftResetMenu(true);
        }
    }
}
