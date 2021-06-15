using System;
using System.Collections.Generic;
using System.Linq;
using RoR2;
using UnityEngine;
using UnityEngine.Networking;

namespace UmbraMenu.Model.Cheats
{
    public static class Items
    {
        public static bool isDropItemForAll, isDropItemFromInventory, noEquipmentCD;

        private static readonly WeightedSelection<List<ItemIndex>> weightedSelection = BuildRollItemsDropTable();
        public static int itemsToRoll = 5;
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
            if (UmbraMod.LocalPlayerInv)
            {
                // Loops through every item in ItemIndex enum
                foreach (ItemIndex itemIndex in CurrentInventory())
                {
                    // If an item exists, delete the whole stack of it
                    UmbraMod.LocalPlayerInv.itemAcquisitionOrder.Remove(itemIndex);
                    UmbraMod.LocalPlayerInv.ResetItem(itemIndex);
                    int itemCount = UmbraMod.LocalPlayerInv.GetItemCount(itemIndex);
                    UmbraMod.LocalPlayerInv.RemoveItem(itemIndex, itemCount);

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
                UmbraMod.LocalPlayerInv.SetEquipmentIndex(EquipmentIndex.None);
            }
            Player.RemoveAllBuffs();
        }

        // random items
        public static void RollItems()
        {
            try
            {
                int num = itemsToRoll;
                if (num > 0)
                {
                    for (int i = 0; i < num; i++)
                    {
                        List<ItemIndex> list = weightedSelection.Evaluate(UnityEngine.Random.value);
                        UmbraMod.LocalPlayerInv.GiveItem(list[UnityEngine.Random.Range(0, list.Count)], 1);
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

            List<ItemIndex> tier1 = new List<ItemIndex>();
            List<ItemIndex> tier2 = new List<ItemIndex>();
            List<ItemIndex> tier3 = new List<ItemIndex>();
            List<ItemIndex> lunar = new List<ItemIndex>();
            List<ItemIndex> boss = UmbraMod.Instance.bossItems;

            foreach (ItemIndex itemIndex in ItemCatalog.tier1ItemList)
            {
                tier1.Add(itemIndex);
            }
            foreach (ItemIndex itemIndex in ItemCatalog.tier2ItemList)
            {
                tier2.Add(itemIndex);
            }
            foreach (ItemIndex itemIndex in ItemCatalog.tier3ItemList)
            {
                tier3.Add(itemIndex);
            }
            foreach (ItemIndex itemIndex in ItemCatalog.lunarItemList)
            {
                lunar.Add(itemIndex);
            }



            weightedSelection.AddChoice(tier1, 63.5f);
            weightedSelection.AddChoice(tier2, 27f);
            weightedSelection.AddChoice(tier3, 3.5f);
            weightedSelection.AddChoice(boss, 3.5f);
            weightedSelection.AddChoice(lunar, 2.5f);
            return weightedSelection;
        }

        //Gives all items
        public static void GiveAllItems()
        {
            if (UmbraMod.LocalPlayerInv)
            {
                foreach (ItemIndex itemIndex in UmbraMod.Instance.items)
                {
                    ItemDef itemDef = ItemCatalog.GetItemDef(itemIndex);
                    string itemName = itemDef.name;


                    //plantonhit kills you when you pick it up
                    if (itemName == "PlantOnHit" || itemName == "HealthDecay" || itemName == "TonicAffliction" || itemName == "BurnNearby" || itemName == "CrippleWardOnLevel" || itemName == "Ghost" || itemName == "ExtraLifeConsumed")
                        continue;
                    UmbraMod.LocalPlayerInv.GiveItem(itemIndex, allItemsQuantity);
                }
            }
        }

        //Does the same thing as the shrine of order. Orders all your items into stacks of several random items.
        public static void StackInventory()
        {
            UmbraMod.LocalPlayerInv.ShrineRestackInventory(Run.instance.runRNG);
        }

        //Sets equipment cooldown to 0 if its on cooldown
        public static void NoEquipmentCooldown()
        {
            EquipmentState equipment = UmbraMod.LocalPlayerInv.GetEquipment((uint)UmbraMod.LocalPlayerInv.activeEquipmentSlot);

            if (equipment.chargeFinishTime != Run.FixedTimeStamp.zero)
            {
                UmbraMod.LocalPlayerInv.SetEquipment(new EquipmentState(equipment.equipmentIndex, Run.FixedTimeStamp.zero, equipment.charges), (uint)UmbraMod.LocalPlayerInv.activeEquipmentSlot);
            }
        }

        //Gets players current items to make sure they can drop item from inventory if enabled
        public static List<ItemIndex> CurrentInventory()
        {
            var currentInventory = new List<ItemIndex>();

            string[] unreleasedItems = { "Count", "None" };

            foreach (ItemIndex itemIndex in ItemCatalog.allItems)
            {
                ItemDef itemDef = ItemCatalog.GetItemDef(itemIndex);
                bool unreleasednullItem = unreleasedItems.Any(itemDef.name.Contains);
                if (!unreleasednullItem)
                {
                    int itemCount = UmbraMod.LocalPlayerInv.GetItemCount(itemIndex);
                    if (itemCount > 0) // If item is in inventory
                    {
                        currentInventory.Add(itemIndex); // add to list
                    }
                }
            }
            return currentInventory;
        }

        public static void GiveItem(ItemIndex itemIndex)
        {
            var localUser = LocalUserManager.GetFirstLocalUser();
            if (localUser.cachedMasterController && localUser.cachedMasterController.master)
            {
                if (isDropItemForAll)
                {
                    DropItemMethod(itemIndex);
                }
                else if (isDropItemFromInventory)
                {
                    if (CurrentInventory().Contains(itemIndex))
                    {
                        UmbraMod.LocalPlayerInv.RemoveItem(itemIndex, 1);
                        DropItemMethod(itemIndex);
                    }
                    else
                    {
                        Chat.AddMessage($"<color=yellow> You do not have that item and therefore cannot drop it from your inventory.</color>");
                        Chat.AddMessage($" ");
                    }
                }
                else
                {
                    UmbraMod.LocalPlayerInv.GiveItem(itemIndex, 1);
                }
            }
        }

        public static void GiveEquipment(EquipmentIndex equipIndex)
        {
            var localUser = LocalUserManager.GetFirstLocalUser();
            if (localUser.cachedMasterController && localUser.cachedMasterController.master)
            {
                if (isDropItemForAll)
                {
                    DropEquipmentMethod(equipIndex);
                }
                else if (isDropItemFromInventory)
                {
                    if (UmbraMod.LocalPlayerInv.currentEquipmentIndex == equipIndex)
                    {
                        UmbraMod.LocalPlayerInv.SetEquipmentIndex(EquipmentIndex.None);
                        DropEquipmentMethod(equipIndex);
                    }
                    else
                    {
                        Chat.AddMessage($"<color=yellow> You do not have that equipment and therefore cannot drop it.</color>");
                        Chat.AddMessage($" ");
                    }
                }
                else
                {
                    UmbraMod.LocalPlayerInv.SetEquipmentIndex(equipIndex);
                }
            }
        }
    }
}
