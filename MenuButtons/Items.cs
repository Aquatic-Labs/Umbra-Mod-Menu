using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine.Experimental.Rendering;
using RoR2;
using UnityEngine;
using UnityEngine.Networking;


namespace UmbraMenu.MenuButtons
{
    public class Items
    {
        private static readonly Menu currentMenu = (Menu)Utility.FindMenuById(3);

        private static readonly WeightedSelection<List<ItemIndex>> weightedSelection = BuildRollItemsDropTable();
        private static int itemsToRoll = 5;
        public static int ItemsToRoll
        {
            get
            {
                return itemsToRoll;
            }
            set
            {
                itemsToRoll = value;
                rollItems.text = $"R O L L   I T E M S : {itemsToRoll}";
            }
        }
        public static bool isDropItemForAll, isDropItemFromInventory, noEquipmentCD;
        private static int allItemsQuantity = 1;
        public static int AllItemsQuantity
        {
            get
            {
                return allItemsQuantity;
            }
            set
            {
                allItemsQuantity = value;
                giveAllItems.text = $"G I V E   A L L   I T E M S : {allItemsQuantity}";
            }
        }

        private static void ToggleItemsListMenu() => ToggleMenu(UmbraMenu.menus[11]);
        private static void ToggleEquipmentListMenu() => ToggleMenu(UmbraMenu.listMenus[12]);
        private static void ToggleChestItemListMenu() => ToggleMenu(UmbraMenu.listMenus[13]);

        public static MulButton giveAllItems = new MulButton(currentMenu, 1, $"G I V E   A L L   I T E M S : {AllItemsQuantity}", GiveAllItems, IncreaseGiveAllQuantity, DecreaseGiveAllQuantity);
        public static MulButton rollItems = new MulButton(currentMenu, 2, $"R O L L   I T E M S : {ItemsToRoll}", RollItems, IncreaseItemsToRoll, DecreaseItemsToRoll);
        public static TogglableButton toggleItemListMenu = new TogglableButton(currentMenu, 3, "I T E M   S P A W N   M E N U : O F F", "I T E M   S P A W N   M E N U : O N", ToggleItemsListMenu, ToggleItemsListMenu);
        public static TogglableButton toggleEquipmentListMenu = new TogglableButton(currentMenu, 4, "E Q U I P M E N T   S P A W N   M E N U : O F F", "E Q U I P M E N T   S P A W N   M E N U : O N", ToggleEquipmentListMenu, ToggleEquipmentListMenu);
        public static TogglableButton toggleDropItems = new TogglableButton(currentMenu, 5, "D R O P   I T E M S / E Q U I P M E N T : O F F", "D R O P   I T E M S / E Q U I P M E N T : O N", ToggleDrop, ToggleDrop);
        public static TogglableButton toggleDropInvItems = new TogglableButton(currentMenu, 6, "D R O P   F R O M   I N V E N T O R Y : O F F", "D R O P   F R O M   I N V E N T O R Y : O N", ToggleDropFromInventory, ToggleDropFromInventory);
        public static TogglableButton toggleEquipmentCD = new TogglableButton(currentMenu, 7, "I N F I N I T E   E Q U I P M E N T : O F F", "I N F I N I T E   E Q U I P M E N T : O N", ToggleEquipmentCD, ToggleEquipmentCD);
        public static Button stackInventory = new Button(currentMenu, 8, "S T A C K   I N V E N T O R Y", StackInventory);
        public static Button clearInventory = new Button(currentMenu, 9, "C L E A R   I N V E N T O R Y", ClearInventory);
        public static TogglableButton toggleChestItemMenu = new TogglableButton(currentMenu, 10, "C H A N G E   C H E S T   I T E M : O F F", "C H A N G E   C H E S T   I T E M : O N", ToggleChestItemListMenu, ToggleChestItemListMenu);

        private static List<Buttons> buttons = new List<Buttons>()
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
        };

        public static void AddButtonsToMenu()
        {
            currentMenu.buttons = buttons;
        }

        private static void ToggleMenu(Menu menu)
        {
            menu.enabled = !menu.enabled;
        }

        private static void ToggleMenu(ListMenu menu)
        {
            menu.enabled = !menu.enabled;
        }

        #region Toggle cheat functions
        private static void ToggleDrop()
        {
            isDropItemForAll = !isDropItemForAll;
        }

        private static void ToggleDropFromInventory()
        {
            isDropItemFromInventory = !isDropItemFromInventory;
        }

        private static void ToggleEquipmentCD()
        {
            noEquipmentCD = !noEquipmentCD;
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
        public static void ClearInventory()
        {
            if (UmbraMenu.LocalPlayerInv)
            {
                // Loops through every item in ItemIndex enum
                foreach (string itemName in CurrentInventory())
                {
                    ItemIndex itemIndex = (ItemIndex)Enum.Parse(typeof(ItemIndex), itemName); //Convert itemName string to and ItemIndex
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
            if (UmbraMenu.LocalPlayerInv)
            {
                foreach (string itemName in Enum.GetNames(typeof(ItemIndex)))
                {
                    //plantonhit kills you when you pick it up
                    if (itemName == "PlantOnHit" || itemName == "HealthDecay" || itemName == "TonicAffliction" || itemName == "BurnNearby" || itemName == "CrippleWardOnLevel" || itemName == "Ghost" || itemName == "ExtraLifeConsumed")
                        continue;
                    ItemIndex itemIndex = (ItemIndex)Enum.Parse(typeof(ItemIndex), itemName);
                    UmbraMenu.LocalPlayerInv.GiveItem(itemIndex, allItemsQuantity);
                }
            }
        }

        //Does the same thing as the shrine of order. Orders all your items into stacks of several random items.
        public static void StackInventory()
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
                    int itemCount = UmbraMenu.LocalPlayerInv.GetItemCount(itemIndex);
                    if (itemCount > 0) // If item is in inventory
                    {
                        currentInventory.Add(itemName); // add to list
                    }
                }
            }
            return currentInventory;
        }

        #region Increase/Decrease Value Actions
        public static void IncreaseItemsToRoll()
        {
            if (ItemsToRoll >= 5)
                ItemsToRoll += 5;
        }

        public static void IncreaseGiveAllQuantity()
        {
            if (AllItemsQuantity >= 1)
                AllItemsQuantity += 1;
        }

        public static void DecreaseItemsToRoll()
        {
            if (ItemsToRoll > 5)
                ItemsToRoll -= 5;
        }

        public static void DecreaseGiveAllQuantity()
        {
            if (AllItemsQuantity > 1)
                AllItemsQuantity -= 1;
        }
        #endregion
    }
}
