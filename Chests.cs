using RoR2;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace UmbraRoR
{
    class Chests : MonoBehaviour
    {
        public static List<PurchaseInteraction> purchaseInteractions = new List<PurchaseInteraction>();
        public static List<ChestBehavior> chests = new List<ChestBehavior>();

        public static void EnableChests()
        {
            if (Main.onChestsEnable)
            {
                DumpInteractables(null);
                SceneDirector.onPostPopulateSceneServer += DumpInteractables;
                Main.onChestsEnable = false;
            }
            else
            {
                return;
            }
        }
        public static void DisableChests()
        {
            if (!Main.onChestsEnable)
            {
                SceneDirector.onPostPopulateSceneServer -= DumpInteractables;
                Main.onChestsEnable = true;
            }
            else
            {
                return;
            }
        }

        private static void DumpInteractables(SceneDirector obj)
        {
            purchaseInteractions = FindObjectsOfType<PurchaseInteraction>().ToList();
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

                if (Main.renderInteractables)
                {
                    GUI.Label(new Rect(chestBoundingVector.x - 50f, (float)Screen.height - chestBoundingVector.y + 35f, 100f, 50f), $"Selected Chest", Main.selectedChestStyle);
                }
                else
                {
                    GUI.Label(new Rect(chestBoundingVector.x - 50f, (float)Screen.height - chestBoundingVector.y + 35f, 100f, 50f), $"Selected Chest\n{dropNameColored}", Main.selectedChestStyle);
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
            if (Main.equipment.Contains(equipmentDrop) && equipmentDrop != EquipmentIndex.None)
            {
                return true;
            }
            return false;
        }
    }
}
