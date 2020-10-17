using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RoR2;
using UnityEngine;

namespace UmbraMenu.MenuButtons
{
    public class ChestItemList
    {
        private static readonly ListMenu currentMenu = (ListMenu)Utility.FindMenuById(14);

        public static void AddButtonsToMenu()
        {
            List<Buttons> buttons = new List<Buttons>();

            if (IsClosestChestEquip())
            {
                for (int i = 0; i < UmbraMenu.equipment.Count; i++)
                {
                    var equipmentIndex = UmbraMenu.equipment[i];
                    if (equipmentIndex != EquipmentIndex.None)
                    {
                        void ButtonAction() => SetChestEquipment(equipmentIndex);
                        if (equipmentIndex != EquipmentIndex.AffixYellow)
                        {
                            Color32 equipColor = ColorCatalog.GetColor(EquipmentCatalog.GetEquipmentDef(equipmentIndex).colorIndex);
                            string equipmentName = Util.GenerateColoredString(Language.GetString(EquipmentCatalog.GetEquipmentDef(equipmentIndex).nameToken), ColorCatalog.GetColor(EquipmentCatalog.GetEquipmentDef(equipmentIndex).colorIndex));
                            Button button = new Button(currentMenu, i + 1, equipmentName, ButtonAction);
                            buttons.Add(button);
                        }
                        else
                        {
                            string equipmentName = Util.GenerateColoredString(equipmentIndex.ToString(), ColorCatalog.GetColor(ColorCatalog.ColorIndex.Equipment));
                            Button button = new Button(currentMenu, i + 1, equipmentName, ButtonAction);
                            buttons.Add(button);
                        }
                    }
                }
            }
            else
            {
                for (int i = 0; i < UmbraMenu.items.Count; i++)
                {
                    var itemIndex = UmbraMenu.items[i];
                    void ButtonAction() => SetChestItem(itemIndex);
                    Color32 itemColor = ColorCatalog.GetColor(ItemCatalog.GetItemDef(itemIndex).colorIndex);
                    if (itemColor.r <= 105 && itemColor.g <= 105 && itemColor.b <= 105)
                    {
                        string itemName = Util.GenerateColoredString(Language.GetString(ItemCatalog.GetItemDef(itemIndex).nameToken), new Color32(0, 0, 0, 255));
                        Button button = new Button(currentMenu, i + 1, itemName, ButtonAction);
                        buttons.Add(button);
                    }
                    else
                    {
                        string itemName = Util.GenerateColoredString(Language.GetString(ItemCatalog.GetItemDef(itemIndex).nameToken), itemColor);
                        Button button = new Button(currentMenu, i + 1, itemName, ButtonAction);
                        buttons.Add(button);
                    }
                }
            }
            currentMenu.buttons = buttons;
        }

        public static List<PurchaseInteraction> purchaseInteractions = new List<PurchaseInteraction>();
        public static List<ChestBehavior> chests = new List<ChestBehavior>();
        public static bool onChestsEnable = true;

        public static void EnableChests()
        {
            if (onChestsEnable)
            {
                DumpInteractables(null);
                SceneDirector.onPostPopulateSceneServer += DumpInteractables;
                onChestsEnable = false;
            }
            else
            {
                return;
            }
        }

        public static void DisableChests()
        {
            if (!onChestsEnable)
            {
                SceneDirector.onPostPopulateSceneServer -= DumpInteractables;
                onChestsEnable = true;
            }
            else
            {
                return;
            }
        }

        private static void DumpInteractables(SceneDirector obj)
        {
            purchaseInteractions = UnityEngine.Object.FindObjectsOfType<PurchaseInteraction>().ToList();
            chests = ConvertPurchaseInteractsToChests();
        }

        public static List<ChestBehavior> ConvertPurchaseInteractsToChests()
        {
            List<ChestBehavior> chests = new List<ChestBehavior>();
            foreach (PurchaseInteraction purchaseInteraction in purchaseInteractions)
            {
                var chest = purchaseInteraction?.gameObject.GetComponent<ChestBehavior>();
                if (chest)
                {
                    chests.Add(chest);
                }
            }
            return chests;
        }

        public static ChestBehavior FindClosestChest()
        {
            Dictionary<float, ChestBehavior> chestsWithDistance = new Dictionary<float, ChestBehavior>();
            foreach (var chest in chests)
            {
                if (chest)
                {
                    string dropName = Language.GetString(chest.GetField<PickupIndex>("dropPickup").GetPickupNameToken());
                    if (dropName != null && dropName != "???")
                    {
                        float distanceToChest = Vector3.Distance(Camera.main.transform.position, chest.transform.position);
                        chestsWithDistance.Add(distanceToChest, chest);
                    }
                }
            }
            var keys = chestsWithDistance.Keys.ToList();
            keys.Sort();
            float leastDistance = keys[0];
            chestsWithDistance.TryGetValue(leastDistance, out ChestBehavior closestChest);
            return closestChest;
        }

        public static void RenderClosestChest()
        {
            var chest = FindClosestChest();
            Vector3 chestPosition = Camera.main.WorldToScreenPoint(chest.transform.position);
            var chestBoundingVector = new Vector3(chestPosition.x, chestPosition.y, chestPosition.z);
            if (chestBoundingVector.z > 0.01)
            {
                string dropNameColored = Util.GenerateColoredString(Language.GetString(chest.GetField<PickupIndex>("dropPickup").GetPickupNameToken()), chest.GetField<PickupIndex>("dropPickup").GetPickupColor());
                float distanceToChest = Vector3.Distance(Camera.main.transform.position, FindClosestChest().transform.position);
                float width = 100f * (distanceToChest / 100);
                if (width > 125)
                {
                    width = 125;
                }
                float height = 100f * (distanceToChest / 100);
                if (height > 125)
                {
                    height = 125;
                }

                if (Render.renderInteractables)
                {
                    GUI.Label(new Rect(chestBoundingVector.x - 50f, (float)Screen.height - chestBoundingVector.y + 35f, 100f, 50f), $"Selected Chest", Styles.selectedChestStyle);
                }
                else
                {
                    GUI.Label(new Rect(chestBoundingVector.x - 50f, (float)Screen.height - chestBoundingVector.y + 35f, 100f, 50f), $"Selected Chest\n{dropNameColored}", Styles.selectedChestStyle);
                }
                ESPHelper.DrawBox(chestBoundingVector.x - width / 2, (float)Screen.height - chestBoundingVector.y - height / 2, width, height, new Color32(0, 0, 255, 255));
            }
        }

        public static void SetChestItem(ItemIndex itemIndex)
        {
            var chest = FindClosestChest();
            chest.SetField<PickupIndex>("dropPickup", PickupCatalog.FindPickupIndex(itemIndex));
        }

        public static void SetChestEquipment(EquipmentIndex euipmentIndex)
        {
            var chest = FindClosestChest();
            chest.SetField<PickupIndex>("dropPickup", PickupCatalog.FindPickupIndex(euipmentIndex));
        }

        public static bool IsClosestChestEquip()
        {
            var chest = FindClosestChest();
            var equipmentDrop = chest.GetField<PickupIndex>("dropPickup").equipmentIndex;
            if (UmbraMenu.equipment.Contains(equipmentDrop) && equipmentDrop != EquipmentIndex.None)
            {
                return true;
            }
            return false;
        }
    }
}
