using System.Collections.Generic;
using System.Linq;
using RoR2;
using UnityEngine;

namespace UmbraMenu.Menus
{
    public class ChestItemList : ListMenu
    {
        public static List<PurchaseInteraction> purchaseInteractions = new List<PurchaseInteraction>();
        public static List<ChestBehavior> chests = new List<ChestBehavior>();
        public bool onChestsEnable = true;

        private bool isClosestChestEquip = false;
        public bool IsClosestChestEquip
        {
            get
            {
                return isClosestChestEquip;
            }

            set
            {
                bool temp = isClosestChestEquip;
                isClosestChestEquip = value;
                if (temp != isClosestChestEquip)
                {
                    OnEnable();
                }
            }
        }

        public ChestItemList() : base(14, 3, new Rect(1503, 10, 20, 20), "CHEST ITEMS MENU")
        {
            ActivatingButton = UmbraMenu.itemsMenu.toggleChestItemMenu;
        }

        protected override void OnEnable()
        {
            EnableChests();
            List<Button> buttons = new List<Button>();
            if (isClosestChestEquip)
            {
                for (int i = 0; i < UmbraMenu.equipment.Count; i++)
                {
                    var equipmentIndex = UmbraMenu.equipment[i];
                    if (equipmentIndex != EquipmentIndex.None)
                    {
                        void ButtonAction() => SetChestEquipment(equipmentIndex);
                        if (equipmentIndex != EquipmentCatalog.FindEquipmentIndex("AffixYellow"))
                        {
                            Color32 equipColor = ColorCatalog.GetColor(EquipmentCatalog.GetEquipmentDef(equipmentIndex).colorIndex);
                            string equipmentName = Util.GenerateColoredString(Language.GetString(EquipmentCatalog.GetEquipmentDef(equipmentIndex).nameToken), ColorCatalog.GetColor(EquipmentCatalog.GetEquipmentDef(equipmentIndex).colorIndex));
                            NormalButton button = new NormalButton(UmbraMenu.chestItemListMenu, i + 1, equipmentName, ButtonAction);
                            buttons.Add(button);
                        }
                        else
                        {
                            string equipmentName = Util.GenerateColoredString(equipmentIndex.ToString(), ColorCatalog.GetColor(ColorCatalog.ColorIndex.Equipment));
                            NormalButton button = new NormalButton(UmbraMenu.chestItemListMenu, i + 1, equipmentName, ButtonAction);
                            buttons.Add(button);
                        }
                    }
                }
            }
            else
            {
                for (int i = 0; i < UmbraMenu.items.Count; i++)
                {
                    var itemIndex = UmbraMenu.items[i];
                    void ButtonAction() => SetChestItem(itemIndex);
                    Color32 itemColor = ColorCatalog.GetColor(ItemCatalog.GetItemDef(itemIndex).colorIndex);
                    if (itemColor.r <= 105 && itemColor.g <= 105 && itemColor.b <= 105)
                    {
                        string itemName = Util.GenerateColoredString(Language.GetString(ItemCatalog.GetItemDef(itemIndex).nameToken), new Color32(0, 0, 0, 255));
                        NormalButton button = new NormalButton(UmbraMenu.chestItemListMenu, i + 1, itemName, ButtonAction);
                        buttons.Add(button);
                    }
                    else
                    {
                        string itemName = Util.GenerateColoredString(Language.GetString(ItemCatalog.GetItemDef(itemIndex).nameToken), itemColor);
                        NormalButton button = new NormalButton(UmbraMenu.chestItemListMenu, i + 1, itemName, ButtonAction);
                        buttons.Add(button);
                    }
                }
            }
            AddButtons(buttons);
            base.OnEnable();
        }

        protected override void OnDisable()
        {
            DisableChests();
            base.OnDisable();
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
            isClosestChestEquip = false;
            DisableChests();
            base.Reset();
        }

        public void EnableChests()
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

        public void DisableChests()
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

        private void DumpInteractables(SceneDirector obj)
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

        public static void RenderClosestChest()
        {
            var chest = FindClosestChest();
            Vector3 chestPosition = Camera.main.WorldToScreenPoint(chest.transform.position);
            var chestBoundingVector = new Vector3(chestPosition.x, chestPosition.y, chestPosition.z);
            if (chestBoundingVector.z > 0.01)
            {
                PickupDef pickupDef = PickupCatalog.GetPickupDef(chest.GetField<PickupIndex>("dropPickup"));
                string dropNameColored = Util.GenerateColoredString(Language.GetString(pickupDef.nameToken), pickupDef.baseColor);
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

                if (Render.renderInteractables)
                {
                    GUI.Label(new Rect(chestBoundingVector.x - 50f, (float)Screen.height - chestBoundingVector.y + 35f, 100f, 50f), $"Selected Chest", Styles.SelectedChestStyle);
                }
                else
                {
                    GUI.Label(new Rect(chestBoundingVector.x - 50f, (float)Screen.height - chestBoundingVector.y + 35f, 100f, 50f), $"Selected Chest\n{dropNameColored}", Styles.SelectedChestStyle);
                }
                ESPHelper.DrawBox(chestBoundingVector.x - width / 2, (float)Screen.height - chestBoundingVector.y - height / 2, width, height, new Color32(17, 204, 238, 255));
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

        public static bool CheckClosestChestEquip()
        {
            var chest = FindClosestChest();
            PickupDef pickupDef = PickupCatalog.GetPickupDef(chest.GetField<PickupIndex>("dropPickup"));
            var equipmentDrop = pickupDef.equipmentIndex;
            if (UmbraMenu.equipment.Contains(equipmentDrop) && equipmentDrop != EquipmentIndex.None)
            {
                return true;
            }
            return false;
        }
    }
}