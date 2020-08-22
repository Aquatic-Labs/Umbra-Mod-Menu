using RoR2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace UmbraRoR
{
    class Chests : MonoBehaviour
    {
        public static List<PurchaseInteraction> purchaseInteractions = new List<PurchaseInteraction>();//FindObjectsOfType<PurchaseInteraction>().ToList();
        public static List<ChestBehavior> chests = new List<ChestBehavior>();//ConvertPurchaseInteractsToChests();
        public static float tier1Chance = 0.8f;
        public static float tier2Chance = 0.2f;
        public static float tier3Chance = 0.01f;

        public static void Enable()
        {
            if (Main.onChestsEnable)
            {
                purchaseInteractions = FindObjectsOfType<PurchaseInteraction>().ToList();
                chests = ConvertPurchaseInteractsToChests();
                Main.onChestsEnable = false;
            }
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
                float distanceToChest = Vector3.Distance(Camera.main.transform.position, chest.transform.position);
                chestsWithDistance.Add(distanceToChest, chest);
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
                GUI.Label(new Rect(chestBoundingVector.x - 50f, (float)Screen.height - chestBoundingVector.y + 50f, 100f, 50f), "Selected Chest", Main.selectedChestStyle);
                ESPHelper.DrawBox(chestBoundingVector.x - width / 2, (float)Screen.height - chestBoundingVector.y - height / 2, width, height, new Color32(0, 255, 0, 255));
            }
        }

        public static void SetChestItem(ItemIndex itemIndex)
        {
            var chest = FindClosestChest();
            chest.SetField<PickupIndex>("dropPickup", PickupCatalog.FindPickupIndex(itemIndex));
        }

        public static void SetChestChance()
        {
            foreach (var chest in chests)
            {
                chest.tier1Chance = tier1Chance;
                chest.tier2Chance = tier2Chance;
                chest.tier3Chance = tier3Chance;
                chest.RollItem();
            }
        }
    }
}
