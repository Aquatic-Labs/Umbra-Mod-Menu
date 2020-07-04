using System;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;
using RoR2;
using UnityEngine.Networking;

namespace UmbraRoR 
{
    public class ItemManager 
    {
        public static int itemsToRoll = 5;
        public static bool isDropItemForAll = false;
        public static bool isDropItemFromInventory = false;
        public static int allItemsQuantity = 1;

        const Int16 HandleItemId = 99;
        const Int16 HandleEquipmentId = 98;

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
        static void SendDropItem(GameObject player, ItemIndex itemIndex)
        {
            NetworkServer.SendToAll(HandleItemId, new DropItemPacket
            {
                Player = player,
                ItemIndex = itemIndex
            });
        }
        static void SendDropEquipment(GameObject player, EquipmentIndex equipmentIndex)
        {
            NetworkServer.SendToAll(HandleEquipmentId, new DropEquipmentPacket
            {
                Player = player,
                EquipmentIndex = equipmentIndex
            });
        }
        [RoR2.Networking.NetworkMessageHandler(msgType = HandleItemId, client = true)]
        static void HandleDropItem(NetworkMessage netMsg)
        {
            var dropItem = netMsg.ReadMessage<DropItemPacket>();
            var body = dropItem.Player.GetComponent<CharacterBody>();
            PickupDropletController.CreatePickupDroplet(PickupCatalog.FindPickupIndex(dropItem.ItemIndex), body.transform.position + Vector3.up * 1.5f, Vector3.up * 20f + body.transform.forward * 2f);
        }
        [RoR2.Networking.NetworkMessageHandler(msgType = HandleEquipmentId, client = true)]
        static void HandleDropEquipment(NetworkMessage netMsg)
        {
            var dropEquipment = netMsg.ReadMessage<DropEquipmentPacket>();
            var body = dropEquipment.Player.GetComponent<CharacterBody>();
            PickupDropletController.CreatePickupDroplet(PickupCatalog.FindPickupIndex(dropEquipment.EquipmentIndex), body.transform.position + Vector3.up * 1.5f, Vector3.up * 20f + body.transform.forward * 2f);
        }

        public static void DropItemMethod(ItemIndex itemIndex)
        {
            var user = RoR2.LocalUserManager.GetFirstLocalUser();
            var networkClient = NetworkClient.allClients.FirstOrDefault();
            if (networkClient != null)
            {
                networkClient.RegisterHandlerSafe(HandleItemId, HandleDropItem);
            }
            SendDropItem(user.cachedBody.gameObject, itemIndex);
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

        //clears inventory, duh.
        public static void ClearInventory()
        {
            if (Main.LocalPlayerInv)
            {
                //Loops through every item in ItemIndex enum
                foreach (string itemName in Enum.GetNames(typeof(ItemIndex)))
                {
                    ItemIndex itemIndex = (ItemIndex)Enum.Parse(typeof(ItemIndex), itemName); //Convert itemName string to and ItemIndex
                    Main.LocalPlayerInv.ResetItem(itemIndex); int itemCount = Main.LocalPlayerInv.GetItemCount(itemIndex);
                    //If an item exists, delete the whole stack of it
                    if (itemCount >= 0) // Just > doesnt delete from top bar
                    {
                        Main.LocalPlayerInv.RemoveItem(itemIndex, itemCount);
                        Main.LocalPlayerInv.ResetItem(itemIndex);
                        Main.LocalPlayerInv.itemAcquisitionOrder.Remove(itemIndex);

                        //Destroys BeetleGuardAllies on inventory clear, other wise they dont get removed until next stage.
                        //TODO: Find a way to refresh UI/Remove beetle guard health from ui on the left
                        if (itemName == "BeetleGland")
                        {
                            var localUser = RoR2.LocalUserManager.GetFirstLocalUser();
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
                            var bullseyeSearch = new RoR2.BullseyeSearch();
                            bullseyeSearch.filterByLoS = false;
                            bullseyeSearch.maxDistanceFilter = float.MaxValue;
                            bullseyeSearch.maxAngleFilter = float.MaxValue;
                            bullseyeSearch.RefreshCandidates();
                            var hurtBoxList = bullseyeSearch.GetResults();
                            foreach (var hurtbox in hurtBoxList)
                            {
                                var mob = HurtBox.FindEntityObject(hurtbox);
                                string mobName = mob.name.Replace("Body(Clone)", "");
                                if (mobName == "BeetleGuardAlly")
                                {
                                    UnityEngine.GameObject.Destroy(mob);
                                }
                            }
                        }
                    }
                }
                Main.LocalPlayerInv.SetEquipmentIndex(EquipmentIndex.None);
            }
        }

        // random items
        public static void RollItems(string ammount)
        {
            try
            {
                int num;
                TextSerialization.TryParseInvariant(ammount, out num);
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

        public static void StackInventory()
        {
            //Does the same thing as the shrine of order. Orders all your items into stacks of several random items.
            Main.LocalPlayerInv.ShrineRestackInventory(Run.instance.runRNG);
        }

        //Draws list of items and gives item selected
        public static void GiveItem(GUIStyle buttonStyle, string buttonName)
        {
            //Removes null items and no icon items from item list. Might change if requested.
            string[] unreleasedItems = { "AACannon", "PlasmaCore", "LevelBonus", "CooldownOnCrit", "PlantOnHit", "MageAttunement", "BoostHp", "BoostDamage", "CritHeal", "BurnNearby", "CrippleWardOnLevel", "ExtraLifeConsumed", "Ghost", "HealthDecay", "DrizzlePlayerHelper", "MonsoonPlayerHelper", "TempestOnKill", "BoostAttackSpeed", "Count", "None" };
            int buttonPlacement = 1;
            foreach (string itemName in Enum.GetNames(typeof(ItemIndex)))
            {
                bool unreleasednullItem = unreleasedItems.Any(itemName.Contains);
                if (!unreleasednullItem)
                {
                    if (GUI.Button(btn.BtnRect(buttonPlacement, false, buttonName), itemName, buttonStyle))
                    {
                        Debug.Log($"Button Drew: {buttonPlacement}");
                        ItemIndex itemIndex = (ItemIndex)Enum.Parse(typeof(ItemIndex), itemName);
                        var localUser = LocalUserManager.GetFirstLocalUser();
                        if (localUser.cachedMasterController && localUser.cachedMasterController.master)
                        {
                            if (isDropItemForAll)
                            {
                                DropItemMethod(itemIndex);
                            }
                            else if (isDropItemFromInventory)
                            {
                                if (CurrentInventory().Contains(itemName))
                                {
                                    Main.LocalPlayerInv.RemoveItem(itemIndex, 1);
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
                                Main.LocalPlayerInv.GiveItem(itemIndex, 1);
                            }
                        }
                    }
                    buttonPlacement++;
                }
                //Since "Ghost" is unreleased item, "GhostOnKill" was getting removed from item list.
                else if (itemName == "GhostOnKill")
                {
                    if (GUI.Button(btn.BtnRect(buttonPlacement, false, buttonName), itemName, buttonStyle))
                    {
                        ItemIndex itemIndex = (ItemIndex)Enum.Parse(typeof(ItemIndex), itemName);
                        var localUser = LocalUserManager.GetFirstLocalUser();
                        if (localUser.cachedMasterController && localUser.cachedMasterController.master)
                        {
                            if (isDropItemForAll)
                            {
                                DropItemMethod(itemIndex);
                            }
                            else if (isDropItemFromInventory)
                            {
                                if (CurrentInventory().Contains(itemName))
                                {
                                    Main.LocalPlayerInv.RemoveItem(itemIndex, 1);
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
                                Main.LocalPlayerInv.GiveItem(itemIndex, 1);
                            }
                        }
                    }
                    buttonPlacement++;
                }
            }
        }

        //Draws list of equipment and gives equipment selected
        public static void GiveEquipment(GUIStyle buttonStyle, string buttonName)
        {
            //Removes null equipment and no icon equipment from item list. Might change if requested.
            string[] unreleasedEquipment = { "SoulJar", "AffixYellow", "AffixGold", "GhostGun", "OrbitalLaser", "Enigma", "LunarPotion", "SoulCorruptor", "Count" };
            int buttonPlacement = 1;
            foreach (string equipmentName in Enum.GetNames(typeof(EquipmentIndex)))
            {
                bool unreleasednullEquipment = unreleasedEquipment.Any(equipmentName.Contains);
                if (!unreleasednullEquipment)
                {
                    if (GUI.Button(btn.BtnRect(buttonPlacement, false, buttonName), equipmentName, buttonStyle))
                    {
                        EquipmentIndex equipmentIndex = (EquipmentIndex)Enum.Parse(typeof(EquipmentIndex), equipmentName);
                        var localUser = LocalUserManager.GetFirstLocalUser();
                        if (localUser.cachedMasterController && localUser.cachedMasterController.master)
                        {
                            if (isDropItemForAll)
                            {
                                DropEquipmentMethod(equipmentIndex);
                            }
                            else if (isDropItemFromInventory)
                            {
                                if (Main.LocalPlayerInv.currentEquipmentIndex == equipmentIndex)
                                {
                                    Main.LocalPlayerInv.SetEquipmentIndex(EquipmentIndex.None);
                                    DropEquipmentMethod(equipmentIndex);
                                }
                                else
                                {
                                    Chat.AddMessage($"<color=yellow> You do not have that equipment and therefore cannot drop it from your inventory.</color>");
                                    Chat.AddMessage($" ");
                                }
                            }
                            else
                            {
                                Main.LocalPlayerInv.SetEquipmentIndex(equipmentIndex);
                            }
                        }
                    }
                    buttonPlacement++;
                }
            }
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
