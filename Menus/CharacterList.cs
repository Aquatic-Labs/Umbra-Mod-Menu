using RoR2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace UmbraMenu.MenuButtons
{
    public class CharacterList
    {
        private static readonly Menu currentMenu = new Menu(null);

        public static void AddButtonsToMenu()
        {
            List<Button> buttons = new List<Button>();
            for (int i = 0; i < UmbraMenu.bodyPrefabs.Count; i++)
            {
                int prefabIndex = i;
                void ButtonAction() => ChangeCharacter(prefabIndex);
                Button button = new Button(new NormalButton(currentMenu, i + 1, UmbraMenu.bodyPrefabs[i].name.Replace("Body", ""), ButtonAction));
                buttons.Add(button);
            }
            //currentMenu.Buttons = buttons;
        }

        private static void ChangeCharacter(int prefabIndex)
        {
            GameObject newBody = BodyCatalog.FindBodyPrefab(UmbraMenu.bodyPrefabs[prefabIndex].name);
            if (newBody == null) return;
            var localUser = LocalUserManager.GetFirstLocalUser();
            if (localUser == null || localUser.cachedMasterController == null || localUser.cachedMasterController.master == null) return;
            var master = localUser.cachedMasterController.master;

            master.bodyPrefab = newBody;
            master.Respawn(master.GetBody().transform.position, master.GetBody().transform.rotation);
            Utility.SoftResetMenu();
        }
    }
}
