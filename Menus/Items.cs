using System;
using System.Collections.Generic;
using System.Linq;
using RoR2;
using UnityEngine;
using UnityEngine.Networking;


namespace UmbraMenu.Menus
{
    public class Items : NormalMenu
    {
        public static bool isDropItemForAll, isDropItemFromInventory, noEquipmentCD;
        public bool IsDropItemForAll
        {
            get
            {
                return isDropItemForAll;
            }
            set
            {
                isDropItemForAll = value;
                if (isDropItemFromInventory && isDropItemForAll)
                {
                    isDropItemFromInventory = false;
                    toggleDropInvItems.SetEnabled(false);
                }
            }
        }
        public bool IsDropItemFromInventory
        {
            get
            {
                return isDropItemFromInventory;
            }
            set
            {
                isDropItemFromInventory = value;
                if (isDropItemFromInventory && isDropItemForAll)
                {
                    isDropItemForAll = false;
                    toggleDropItems.SetEnabled(false);
                }
            }
        }

        private readonly WeightedSelection<List<ItemIndex>> weightedSelection = BuildRollItemsDropTable();
        public static int ItemsToRoll = 5;
        public static int AllItemsQuantity = 1;

        public MulButton giveAllItems;
        public MulButton rollItems;
        public TogglableButton toggleItemListMenu;
        public TogglableButton toggleEquipmentListMenu;
        public TogglableButton toggleDropItems;
        public TogglableButton toggleDropInvItems;
        public TogglableButton toggleEquipmentCD;
        public NormalButton stackInventory;
        public NormalButton clearInventory;
        public TogglableButton toggleChestItemMenu;

        public Items() : base(3, 0, new Rect(738, 10, 20, 20), "ITEMS MENU")
        {
            void ToggleItemsListMenu() => UmbraMenu.menus[12].ToggleMenu();
            void ToggleEquipmentListMenu() => UmbraMenu.menus[13].ToggleMenu();

            giveAllItems = new MulButton(this, 1, $"GIVE ALL ITEMS : {AllItemsQuantity}", GiveAllItems, IncreaseGiveAllQuantity, DecreaseGiveAllQuantity);
            rollItems = new MulButton(this, 2, $"ROLL ITEMS : {ItemsToRoll}", RollItems, IncreaseItemsToRoll, DecreaseItemsToRoll);
            toggleItemListMenu = new TogglableButton(this, 3, "ITEM SPAWN MENU : OFF", "ITEM SPAWN MENU : ON", ToggleItemsListMenu, ToggleItemsListMenu);
            toggleEquipmentListMenu = new TogglableButton(this, 4, "EQUIPMENT SPAWN MENU : OFF", "EQUIPMENT SPAWN MENU : ON", ToggleEquipmentListMenu, ToggleEquipmentListMenu);
            toggleDropItems = new TogglableButton(this, 5, "DROP ITEMS : OFF", "DROP ITEMS : ON", ToggleDrop, ToggleDrop);
            toggleDropInvItems = new TogglableButton(this, 6, "DROP FROM INVENTORY : OFF", "DROP FROM INVENTORY : ON", ToggleDropFromInventory, ToggleDropFromInventory);
            toggleEquipmentCD = new TogglableButton(this, 7, "INFINITE EQUIPMENT : OFF", "INFINITE EQUIPMENT : ON", ToggleEquipmentCD, ToggleEquipmentCD);
            stackInventory = new NormalButton(this, 8, "STACK INVENTORY", StackInventory);
            clearInventory = new NormalButton(this, 9, "CLEAR INVENTORY", ClearInventory);
            toggleChestItemMenu = new TogglableButton(this, 10, "CHANGE CHEST ITEM : OFF", "CHANGE CHEST ITEM : ON", ToggleChestItemListMenu, ToggleChestItemListMenu);

            giveAllItems.Click += UpdateGiveAll;
            rollItems.Click += UpdateRollItems;

            AddButtons(new List<Button>()
            {
                giveAllItems,
                rollItems,
                toggleItemListMenu,
                toggleEquipmentListMenu,
                toggleDropItems,
                toggleDropInvItems,
                toggleEquipmentCD,
                stackInventory,
                clearInventory,
                toggleChestItemMenu
            });
            ActivatingButton = UmbraMenu.mainMenu.toggleItems;
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
            isDropItemForAll = false;
            isDropItemFromInventory = false;
            noEquipmentCD = false;
            ItemsToRoll = 5;
            AllItemsQuantity = 1;
            base.Reset();
        }

        public void UpdateGiveAll(object sender, EventArgs e)
        {
            giveAllItems.SetText($"GIVE ALL ITEMS : {AllItemsQuantity}");
        }

        public void UpdateRollItems(object sender, EventArgs e)
        {
            rollItems.SetText($"ROLL ITEMS : {ItemsToRoll}");
        }

        #region Toggle cheat functions
        private void ToggleDrop()
        {
            IsDropItemForAll = !IsDropItemForAll;
        }

        private void ToggleDropFromInventory()
        {
            IsDropItemFromInventory = !IsDropItemFromInventory;
        }

        private void ToggleEquipmentCD()
        {
            noEquipmentCD = !noEquipmentCD;
        }

        private void ToggleChestItemListMenu()
        {
            /*if (toggleChestItemMenu.IsEnabled())
            {
                ChestItemList.DisableChests();
                chestItemList = false;
            }
            else
            {
                ChestItemList.EnableChests();
                chestItemList = true;
            }*/
            UmbraMenu.menus[14].ToggleMenu();
        }
        #endregion

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
        public void ClearInventory()
        {
            if (UmbraMenu.LocalPlayerInv)
            {
                // Loops through every item in ItemIndex enum
                foreach (ItemIndex itemIndex in CurrentInventory())
                {
                    // If an item exists, delete the whole stack of it
                    UmbraMenu.LocalPlayerInv.itemAcquisitionOrder.Remove(itemIndex);
                    UmbraMenu.LocalPlayerInv.ResetItem(itemIndex);
                    int itemCount = UmbraMenu.LocalPlayerInv.GetItemCount(itemIndex);
                    UmbraMenu.LocalPlayerInv.RemoveItem(itemIndex, itemCount);

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
                UmbraMenu.LocalPlayerInv.SetEquipmentIndex(EquipmentIndex.None);
            }
            Player.RemoveAllBuffs();
        }

        // random items
        public void RollItems()
        {
            try
            {
                int num = ItemsToRoll;
                if (num > 0)
                {
                    for (int i = 0; i < num; i++)
                    {
                        List<ItemIndex> list = weightedSelection.Evaluate(UnityEngine.Random.value);
                        UmbraMenu.LocalPlayerInv.GiveItem(list[UnityEngine.Random.Range(0, list.Count)], 1);
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
            List<ItemIndex> boss = UmbraMenu.bossItems;

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
        public void GiveAllItems()
        {
            if (UmbraMenu.LocalPlayerInv)
            {
                foreach (ItemIndex itemIndex in UmbraMenu.items)
                {
                    ItemDef itemDef = ItemCatalog.GetItemDef(itemIndex);
                    string itemName = itemDef.name;


                    //plantonhit kills you when you pick it up
                    if (itemName == "PlantOnHit" || itemName == "HealthDecay" || itemName == "TonicAffliction" || itemName == "BurnNearby" || itemName == "CrippleWardOnLevel" || itemName == "Ghost" || itemName == "ExtraLifeConsumed")
                        continue;
                    UmbraMenu.LocalPlayerInv.GiveItem(itemIndex, AllItemsQuantity);
                }
            }
        }

        //Does the same thing as the shrine of order. Orders all your items into stacks of several random items.
        public void StackInventory()
        {
            UmbraMenu.LocalPlayerInv.ShrineRestackInventory(Run.instance.runRNG);
        }

        //Sets equipment cooldown to 0 if its on cooldown
        public static void NoEquipmentCooldown()
        {
            EquipmentState equipment = UmbraMenu.LocalPlayerInv.GetEquipment((uint)UmbraMenu.LocalPlayerInv.activeEquipmentSlot);

            if (equipment.chargeFinishTime != Run.FixedTimeStamp.zero)
            {
                UmbraMenu.LocalPlayerInv.SetEquipment(new EquipmentState(equipment.equipmentIndex, Run.FixedTimeStamp.zero, equipment.charges), (uint)UmbraMenu.LocalPlayerInv.activeEquipmentSlot);
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
                    int itemCount = UmbraMenu.LocalPlayerInv.GetItemCount(itemIndex);
                    if (itemCount > 0) // If item is in inventory
                    {
                        currentInventory.Add(itemIndex); // add to list
                    }
                }
            }
            return currentInventory;
        }

        #region Increase/Decrease Value Actions
        public void IncreaseItemsToRoll()
        {
            if (ItemsToRoll >= 5)
                ItemsToRoll += 5;
        }

        public void IncreaseGiveAllQuantity()
        {
            if (AllItemsQuantity >= 1)
                AllItemsQuantity += 1;
        }

        public void DecreaseItemsToRoll()
        {
            if (ItemsToRoll > 5)
                ItemsToRoll -= 5;
        }

        public void DecreaseGiveAllQuantity()
        {
            if (AllItemsQuantity > 1)
                AllItemsQuantity -= 1;
        }
        #endregion
    }
}