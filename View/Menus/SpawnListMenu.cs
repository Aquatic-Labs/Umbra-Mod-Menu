using System.Collections.Generic;
using UnityEngine;
using RoR2;
using Umbra = UmbraMenu.Model.UmbraMod;
using Spawn = UmbraMenu.Model.Cheats.Spawn;

namespace UmbraMenu.View
{
    public class SpawnListMenu : ListMenu
    {
        private bool onSpawnListEnable = true;

        public SpawnListMenu() : base(15, 4, new Rect(1503, 10, 20, 20), "SPAWN CARDS MENU")
        {
            ActivatingButton = UmbraModGUI.Instance.spawnMenu.toggleSpawnListMenu;
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
            DisableSpawnList();
            base.Reset();
        }

        protected override void OnEnable()
        {
            EnableSpawnList();
            List<Button> buttons = new List<Button>();
            for (int i = 0; i < Umbra.Instance.spawnCards.Count; i++)
            {
                var spawnCard = Umbra.Instance.spawnCards[i];
                string cardName = spawnCard.ToString();
                string category = "";
                string buttonText = "";
                if (cardName.Contains("MultiCharacterSpawnCard"))
                {
                    cardName = cardName.Replace(" (RoR2.MultiCharacterSpawnCard)", "");
                    category = "CharacterSpawnCard";
                    buttonText = cardName.Replace("csc", "");
                }
                else if (cardName.Contains("CharacterSpawnCard"))
                {
                    cardName = cardName.Replace(" (RoR2.CharacterSpawnCard)", "");
                    category = "CharacterSpawnCard";
                    buttonText = cardName.Replace("csc", "");
                }
                else if (cardName.Contains("InteractableSpawnCard"))
                {
                    cardName = cardName.Replace(" (RoR2.InteractableSpawnCard)", "");
                    category = "InteractableSpawnCard";
                    buttonText = cardName.Replace("isc", "");
                }
                else if (cardName.Contains("BodySpawnCard"))
                {
                    cardName = cardName.Replace(" (RoR2.BodySpawnCard)", "");
                    category = "BodySpawnCard";
                    buttonText = cardName.Replace("bsc", "");
                }
                string path = $"SpawnCards/{category}/{cardName}";

                void ButtonAction() => Spawn.SummonSpawnCard(spawnCard);
                NormalButton button = new NormalButton(this, i + 1, buttonText, ButtonAction);
                buttons.Add(button);
            }
            AddButtons(buttons);
            base.OnEnable();
        }

        protected override void OnDisable()
        {
            DisableSpawnList();
            base.OnDisable();
        }

        private void EnableSpawnList()
        {
            if (onSpawnListEnable)
            {
                DumpInteractables(null);
                SceneDirector.onPostPopulateSceneServer += DumpInteractables;
                onSpawnListEnable = false;
            }
            else
            {
                return;
            }
        }

        private void DisableSpawnList()
        {
            if (!onSpawnListEnable)
            {
                SceneDirector.onPostPopulateSceneServer -= DumpInteractables;
                onSpawnListEnable = true;
            }
            else
            {
                return;
            }
        }

        private void DumpInteractables(SceneDirector obj)
        {
            Umbra.Instance.spawnCards = Model.Utility.GetSpawnCards();
        }
    }
}
