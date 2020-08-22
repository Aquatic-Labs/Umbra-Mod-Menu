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

        public static void Enabled()
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
    }
}
