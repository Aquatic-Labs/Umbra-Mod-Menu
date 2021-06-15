using System.Collections.Generic;
using System.Linq;
using RoR2;
using UnityEngine;
using Umbra = UmbraMenu.Model.UmbraMod;
using Chests = UmbraMenu.Model.Cheats.Chests;

namespace UmbraMenu.View
{
    public class ChestItemListMenu : ListMenu
    {
        public bool IsClosestChestEquip
        {
            get
            {
                return Chests.isClosestChestEquip;
            }

            set
            {
                bool temp = Chests.isClosestChestEquip;
                Chests.isClosestChestEquip = value;
                if (temp != Chests.isClosestChestEquip)
                {
                    OnEnable();
                }
            }
        }

        public ChestItemListMenu() : base(14, 3, new Rect(1503, 10, 20, 20), "CHEST ITEMS MENU")
        {
            ActivatingButton = UmbraModGUI.Instance.itemsMenu.toggleChestItemMenu;
        }

        protected override void OnEnable()
        {
            Chests.EnableChests();
            List<Button> buttons = new List<Button>();
            if (Chests.isClosestChestEquip)
            {
                for (int i = 0; i < Umbra.Instance.equipment.Count; i++)
                {
                    var equipmentIndex = Umbra.Instance.equipment[i];
                    if (equipmentIndex != EquipmentIndex.None)
                    {
                        void ButtonAction() => Chests.SetChestEquipment(equipmentIndex);
                        if (equipmentIndex != EquipmentCatalog.FindEquipmentIndex("AffixYellow"))
                        {
                            Color32 equipColor = ColorCatalog.GetColor(EquipmentCatalog.GetEquipmentDef(equipmentIndex).colorIndex);
                            string equipmentName = Util.GenerateColoredString(Language.GetString(EquipmentCatalog.GetEquipmentDef(equipmentIndex).nameToken), ColorCatalog.GetColor(EquipmentCatalog.GetEquipmentDef(equipmentIndex).colorIndex));
                            NormalButton button = new NormalButton(this, i + 1, equipmentName, ButtonAction);
                            buttons.Add(button);
                        }
                        else
                        {
                            string equipmentName = Util.GenerateColoredString(equipmentIndex.ToString(), ColorCatalog.GetColor(ColorCatalog.ColorIndex.Equipment));
                            NormalButton button = new NormalButton(this, i + 1, equipmentName, ButtonAction);
                            buttons.Add(button);
                        }
                    }
                }
            }
            else
            {
                for (int i = 0; i < Umbra.Instance.items.Count; i++)
                {
                    var itemIndex = Umbra.Instance.items[i];
                    void ButtonAction() => Chests.SetChestItem(itemIndex);
                    Color32 itemColor = ColorCatalog.GetColor(ItemCatalog.GetItemDef(itemIndex).colorIndex);
                    if (itemColor.r <= 105 && itemColor.g <= 105 && itemColor.b <= 105)
                    {
                        string itemName = Util.GenerateColoredString(Language.GetString(ItemCatalog.GetItemDef(itemIndex).nameToken), new Color32(0, 0, 0, 255));
                        NormalButton button = new NormalButton(this, i + 1, itemName, ButtonAction);
                        buttons.Add(button);
                    }
                    else
                    {
                        string itemName = Util.GenerateColoredString(Language.GetString(ItemCatalog.GetItemDef(itemIndex).nameToken), itemColor);
                        NormalButton button = new NormalButton(this, i + 1, itemName, ButtonAction);
                        buttons.Add(button);
                    }
                }
            }
            AddButtons(buttons);
            base.OnEnable();
        }

        protected override void OnDisable()
        {
            Chests.DisableChests();
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
            Chests.isClosestChestEquip = false;
            Chests.DisableChests();
            base.Reset();
        }
    }
}