using System;
using System.Collections.Generic;
using System.Linq;
using RoR2;
using UnityEngine;
using UnityEngine.Networking;
using Items = UmbraMenu.Model.Cheats.Items;


namespace UmbraMenu.View
{
    public class ItemsMenu : NormalMenu
    {
        public bool IsDropItemForAll
        {
            get
            {
                return Items.isDropItemForAll;
            }
            set
            {
                Items.isDropItemForAll = value;
                if (Items.isDropItemFromInventory && Items.isDropItemForAll)
                {
                    Items.isDropItemFromInventory = false;
                    toggleDropInvItems.SetEnabled(false);
                }
            }
        }

        public bool IsDropItemFromInventory
        {
            get
            {
                return Items.isDropItemFromInventory;
            }
            set
            {
                Items.isDropItemFromInventory = value;
                if (Items.isDropItemFromInventory && Items.isDropItemForAll)
                {
                    Items.isDropItemForAll = false;
                    toggleDropItems.SetEnabled(false);
                }
            }
        }

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

        public ItemsMenu() : base(3, 0, new Rect(738, 10, 20, 20), "ITEMS MENU")
        {
            void ToggleItemsListMenu() => UmbraModGUI.Instance.menus[12].ToggleMenu();
            void ToggleEquipmentListMenu() => UmbraModGUI.Instance.menus[13].ToggleMenu();

            giveAllItems = new MulButton(this, 1, $"GIVE ALL ITEMS : {Items.allItemsQuantity}", Items.GiveAllItems, IncreaseGiveAllQuantity, DecreaseGiveAllQuantity);
            rollItems = new MulButton(this, 2, $"ROLL ITEMS : {Items.itemsToRoll}", Items.RollItems, IncreaseItemsToRoll, DecreaseItemsToRoll);
            toggleItemListMenu = new TogglableButton(this, 3, "ITEM SPAWN MENU : OFF", "ITEM SPAWN MENU : ON", ToggleItemsListMenu, ToggleItemsListMenu);
            toggleEquipmentListMenu = new TogglableButton(this, 4, "EQUIPMENT SPAWN MENU : OFF", "EQUIPMENT SPAWN MENU : ON", ToggleEquipmentListMenu, ToggleEquipmentListMenu);
            toggleDropItems = new TogglableButton(this, 5, "DROP ITEMS : OFF", "DROP ITEMS : ON", ToggleDrop, ToggleDrop);
            toggleDropInvItems = new TogglableButton(this, 6, "DROP FROM INVENTORY : OFF", "DROP FROM INVENTORY : ON", ToggleDropFromInventory, ToggleDropFromInventory);
            toggleEquipmentCD = new TogglableButton(this, 7, "INFINITE EQUIPMENT : OFF", "INFINITE EQUIPMENT : ON", ToggleEquipmentCD, ToggleEquipmentCD);
            stackInventory = new NormalButton(this, 8, "STACK INVENTORY", Items.StackInventory);
            clearInventory = new NormalButton(this, 9, "CLEAR INVENTORY", Items.ClearInventory);
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
            ActivatingButton = UmbraModGUI.Instance.mainMenu.toggleItems;
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
            Items.isDropItemForAll = false;
            Items.isDropItemFromInventory = false;
            Items.noEquipmentCD = false;
            Items.itemsToRoll = 5;
            Items.allItemsQuantity = 1;
            base.Reset();
        }

        public void UpdateGiveAll(object sender, EventArgs e)
        {
            giveAllItems.SetText($"GIVE ALL ITEMS : {Items.allItemsQuantity}");
        }

        public void UpdateRollItems(object sender, EventArgs e)
        {
            rollItems.SetText($"ROLL ITEMS : {Items.itemsToRoll}");
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
            Items.noEquipmentCD = !Items.noEquipmentCD;
        }

        private void ToggleChestItemListMenu()
        {
            UmbraModGUI.Instance.menus[14].ToggleMenu();
        }
        #endregion

        #region Increase/Decrease Value Actions
        public void IncreaseItemsToRoll()
        {
            if (Items.itemsToRoll >= 5)
                Items.itemsToRoll += 5;
        }

        public void IncreaseGiveAllQuantity()
        {
            if (Items.allItemsQuantity >= 1)
                Items.allItemsQuantity += 1;
        }

        public void DecreaseItemsToRoll()
        {
            if (Items.itemsToRoll > 5)
                Items.itemsToRoll -= 5;
        }

        public void DecreaseGiveAllQuantity()
        {
            if (Items.allItemsQuantity > 1)
                Items.allItemsQuantity -= 1;
        }
        #endregion
    }
}