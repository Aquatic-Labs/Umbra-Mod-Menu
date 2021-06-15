using RoR2;
using System.Collections.Generic;
using UnityEngine;
using Umbra = UmbraMenu.Model.UmbraMod;
using Player = UmbraMenu.Model.Cheats.Player;

namespace UmbraMenu.View
{
    public class CharacterListMenu : ListMenu
    {
        public CharacterListMenu() : base(10, 1, new Rect(1503, 10, 20, 20), "CHARACTERS MENU")
        {
            List<Button> buttons = new List<Button>();
            for (int i = 0; i < Umbra.Instance.bodyPrefabs.Count; i++)
            {
                int prefabIndex = i;
                void ButtonAction() => Player.ChangeCharacter(prefabIndex);
                NormalButton button = new NormalButton(this, i + 1, Umbra.Instance.bodyPrefabs[i].name.Replace("Body", ""), ButtonAction);
                buttons.Add(button);
            }
            AddButtons(buttons);
            ActivatingButton = UmbraModGUI.Instance.playerMenu.toggleChangeCharacter;
        }

        public override void Draw()
        {
            if (IsEnabled())
            {
                SetWindow();
                base.Draw();
            }
        }
    }
}
