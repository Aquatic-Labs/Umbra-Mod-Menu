using System;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;
using RoR2;
using UnityEngine.Networking;

namespace UmbraRoR 
{
    public class ItemManager : MonoBehaviour
    {
        public static int itemsToRoll = 5;
        public static bool isDropItemForAll = false;
        public static bool isDropItemFromInventory = false;
        public static int allItemsQuantity = 1;

        #region Drop Item Handle
        const Int16 HandleItemId = 99;

        class DropItemPacket : MessageBase
        {
            public GameObject Player;
            public ItemIndex ItemIndex;

            public override void Serialize(NetworkWriter writer)
            {
                writer.Write(Player);
                writer.Write((UInt16)ItemIndex);
            }

            public override void Deserialize(NetworkReader reader)
            {
                Player = reader.ReadGameObject();
                ItemIndex = (ItemIndex)reader.ReadUInt16();
            }
        }

        static void SendDropItem(GameObject player, ItemIndex itemIndex)
        {
            NetworkServer.SendToAll(HandleItemId, new DropItemPacket
            {
                Player = player,
                ItemIndex = itemIndex
            });
        }

        [RoR2.Networking.NetworkMessageHandler(msgType = HandleItemId, client = true)]
        static void HandleDropItem(NetworkMessage netMsg)
        {
            var dropItem = netMsg.ReadMessage<DropItemPacket>();
            var body = dropItem.Player.GetComponent<CharacterBody>();
            PickupDropletController.CreatePickupDroplet(PickupCatalog.FindPickupIndex(dropItem.ItemIndex), body.transform.position + Vector3.up * 1.5f, Vector3.up * 20f + body.transform.forward * 2f);
        }

        public static void DropItemMethod(ItemIndex itemIndex)
        {
            var user = LocalUserManager.GetFirstLocalUser();
            var networkClient = NetworkClient.allClients.FirstOrDefault();
            if (networkClient != null)
            {
                networkClient.RegisterHandlerSafe(HandleItemId, HandleDropItem);
            }
            SendDropItem(user.cachedBody.gameObject, itemIndex);
        }
        #endregion

        #region Drop Equipment Handle
        const Int16 HandleEquipmentId = 98;

        class DropEquipmentPacket : MessageBase
        {
            public GameObject Player;
            public EquipmentIndex EquipmentIndex;
            public override void Serialize(NetworkWriter writer)
            {
                writer.Write(Player);
                writer.Write((UInt16)EquipmentIndex);
            }

            public override void Deserialize(NetworkReader reader)
            {
                Player = reader.ReadGameObject();
                EquipmentIndex = (EquipmentIndex)reader.ReadUInt16();
            }
        }

        static void SendDropEquipment(GameObject player, EquipmentIndex equipmentIndex)
        {
            NetworkServer.SendToAll(HandleEquipmentId, new DropEquipmentPacket
            {
                Player = player,
                EquipmentIndex = equipmentIndex
            });
        }

        [RoR2.Networking.NetworkMessageHandler(msgType = HandleEquipmentId, client = true)]
        static void HandleDropEquipment(NetworkMessage netMsg)
        {
            var dropEquipment = netMsg.ReadMessage<DropEquipmentPacket>();
            var body = dropEquipment.Player.GetComponent<CharacterBody>();
            PickupDropletController.CreatePickupDroplet(PickupCatalog.FindPickupIndex(dropEquipment.EquipmentIndex), body.transform.position + Vector3.up * 1.5f, Vector3.up * 20f + body.transform.forward * 2f);
        }

        public static void DropEquipmentMethod(EquipmentIndex equipmentIndex)
        {
            var user = RoR2.LocalUserManager.GetFirstLocalUser();
            var networkClient = NetworkClient.allClients.FirstOrDefault();
            if (networkClient != null)
            {
                networkClient.RegisterHandlerSafe(HandleEquipmentId, HandleDropEquipment);
            }
            SendDropEquipment(user.cachedBody.gameObject, equipmentIndex);
        }
        #endregion

        // Clears inventory, duh.
        public static void ClearInventory()
        {
            if (Main.LocalPlayerInv)
            {
                // Loops through every item in ItemIndex enum
                foreach (string itemName in CurrentInventory())
                {
                    ItemIndex itemIndex = (ItemIndex)Enum.Parse(typeof(ItemIndex), itemName); //Convert itemName string to and ItemIndex
                    // If an item exists, delete the whole stack of it
                    Main.LocalPlayerInv.itemAcquisitionOrder.Remove(itemIndex);
                    Main.LocalPlayerInv.ResetItem(itemIndex);
                    int itemCount = Main.LocalPlayerInv.GetItemCount(itemIndex);
                    Main.LocalPlayerInv.RemoveItem(itemIndex, itemCount);

                    // Destroys BeetleGuardAllies on inventory clear, other wise they dont get removed until next stage.
                    var localUser = LocalUserManager.GetFirstLocalUser();
                    var controller = localUser.cachedMasterController;
                    if (!controller)
                    {
                        return;
                    }
                    var body = controller.master.GetBody();
                    if (!body)
                    {
                        return;
                    }

                    var bullseyeSearch = new BullseyeSearch
                    {
                        filterByLoS = false,
                        maxDistanceFilter = float.MaxValue,
                        maxAngleFilter = float.MaxValue
                    };
                    bullseyeSearch.RefreshCandidates();
                    var hurtBoxList = bullseyeSearch.GetResults();
                    foreach (var hurtbox in hurtBoxList)
                    {
                        var mob = HurtBox.FindEntityObject(hurtbox);
                        string mobName = mob.name.Replace("Body(Clone)", "");
                        if (mobName == "BeetleGuardAlly")
                        {
                            var health = mob.GetComponent<HealthComponent>();
                            health.Suicide();
                        }
                    }
                }
                Main.LocalPlayerInv.SetEquipmentIndex(EquipmentIndex.None);
            }
            PlayerMod.RemoveAllBuffs();
        }

        // random items
        public static void RollItems(string ammount)
        {
            try
            {
                TextSerialization.TryParseInvariant(ammount, out int num);
                if (num > 0)
                {
                    for (int i = 0; i < num; i++)
                    {
                        List<ItemIndex> list = Main.weightedSelection.Evaluate(UnityEngine.Random.value);
                        Main.LocalPlayerInv.GiveItem(list[UnityEngine.Random.Range(0, list.Count)], 1);
                    }
                }
            }
            catch (ArgumentException)
            {
            }
        }

        //Builds loot table for RollItems()
        public static WeightedSelection<List<ItemIndex>> BuildRollItemsDropTable()
        {
            WeightedSelection<List<ItemIndex>> weightedSelection = new WeightedSelection<List<ItemIndex>>(8);
            ItemIndex itemIndex = ItemIndex.Syringe;
            ItemIndex itemCount = (ItemIndex)ItemCatalog.itemCount;

            List<ItemIndex> tier1 = new List<ItemIndex>();
            List<ItemIndex> tier2 = new List<ItemIndex>();
            List<ItemIndex> tier3 = new List<ItemIndex>();
            List<ItemIndex> lunar = new List<ItemIndex>();
            List<ItemIndex> boss = new List<ItemIndex>();

            while (itemIndex < itemCount)
            {
                ItemDef itemDef = ItemCatalog.GetItemDef(itemIndex);
                switch (itemDef.tier)
                {
                    case ItemTier.Tier1:
                        {
                            tier1.Add(itemIndex);
                            break;
                        }

                    case ItemTier.Tier2:
                        {
                            tier2.Add(itemIndex);
                            break;
                        }

                    case ItemTier.Tier3:
                        {
                            tier3.Add(itemIndex);
                            break;
                        }

                    case ItemTier.Lunar:
                        {
                            lunar.Add(itemIndex);
                            break;
                        }

                    case ItemTier.Boss:
                        {
                            boss.Add(itemIndex);
                            break;
                        }
                }
                itemIndex++;
            }

            weightedSelection.AddChoice(tier1, 70f);
            weightedSelection.AddChoice(tier2, 22f);
            weightedSelection.AddChoice(tier3, 3f);
            weightedSelection.AddChoice(lunar, 2.5f);
            weightedSelection.AddChoice(boss, 2.5f);
            return weightedSelection;
        }

        //Gives all items
        public static void GiveAllItems()
        {
            if (Main.LocalPlayerInv)
            {
                foreach (string itemName in Enum.GetNames(typeof(ItemIndex)))
                {
                    //plantonhit kills you when you pick it up
                    if (itemName == "PlantOnHit" || itemName == "HealthDecay" || itemName == "TonicAffliction" || itemName == "BurnNearby" || itemName == "CrippleWardOnLevel" || itemName == "Ghost" || itemName == "ExtraLifeConsumed")
                        continue;
                    ItemIndex itemIndex = (ItemIndex)Enum.Parse(typeof(ItemIndex), itemName);
                    Main.LocalPlayerInv.GiveItem(itemIndex, allItemsQuantity);
                }
            }
        }

        //Does the same thing as the shrine of order. Orders all your items into stacks of several random items.
        public static void StackInventory()
        {
            Main.LocalPlayerInv.ShrineRestackInventory(Run.instance.runRNG);
        }

        //Sets equipment cooldown to 0 if its on cooldown
        public static void NoEquipmentCooldown()
        {
            EquipmentState equipment = Main.LocalPlayerInv.GetEquipment((uint)Main.LocalPlayerInv.activeEquipmentSlot);

            if (equipment.chargeFinishTime != Run.FixedTimeStamp.zero)
            {
                Main.LocalPlayerInv.SetEquipment(new EquipmentState(equipment.equipmentIndex, Run.FixedTimeStamp.zero, equipment.charges), (uint)Main.LocalPlayerInv.activeEquipmentSlot);
            }
        }

        //Gets players current items to make sure they can drop item from inventory if enabled
        public static List<string> CurrentInventory()
        {
            var currentInventory = new List<string>();

            string[] unreleasedItems = { "Count", "None" };
            foreach (string itemName in Enum.GetNames(typeof(ItemIndex)))
            {
                bool unreleasednullItem = unreleasedItems.Any(itemName.Contains);
                if (!unreleasednullItem)
                {
                    ItemIndex itemIndex = (ItemIndex)Enum.Parse(typeof(ItemIndex), itemName); //Convert itemName string to an ItemIndex
                    int itemCount = Main.LocalPlayerInv.GetItemCount(itemIndex);
                    if (itemCount > 0) // If item is in inventory
                    {
                        currentInventory.Add(itemName); // add to list
                    }
                }
            }
            return currentInventory;
        }
    }
}
