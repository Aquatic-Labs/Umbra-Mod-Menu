using System.Collections.Generic;
using System.Linq;
using RoR2;
using UnityEngine;

namespace UmbraMenu.Model.Cheats
{
    public static class Chests
    {
        public static List<PurchaseInteraction> purchaseInteractions = new List<PurchaseInteraction>();
        public static List<ChestBehavior> chests = new List<ChestBehavior>();
        public static bool onChestsEnable = true;

        public static bool isClosestChestEquip = false;

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
                PickupDef pickupDef = PickupCatalog.GetPickupDef(chest.GetField<PickupIndex>("dropPickup"));
                string dropName = Language.GetString(pickupDef.nameToken);
                if (dropName != null && dropName != "???")
                {
                    float distanceToChest = Vector3.Distance(Camera.main.transform.position, chest.transform.position);
                    chestsWithDistance.Add(distanceToChest, chest);
                }
            }
            var keys = chestsWithDistance.Keys.ToList();
            keys.Sort();
            float leastDistance = keys[0];
            chestsWithDistance.TryGetValue(leastDistance, out ChestBehavior closestChest);
            return closestChest;
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

        public static bool CheckClosestChestEquip()
        {
            var chest = FindClosestChest();
            PickupDef pickupDef = PickupCatalog.GetPickupDef(chest.GetField<PickupIndex>("dropPickup"));
            var equipmentDrop = pickupDef.equipmentIndex;
            if (UmbraMod.Instance.equipment.Contains(equipmentDrop) && equipmentDrop != EquipmentIndex.None)
            {
                return true;
            }
            return false;
        }
    }
}
