using System.Collections.Generic;
using RoR2;
using UnityEngine;

namespace UmbraMenu.Menus
{
    public class EquipmentList : ListMenu
    {
        public EquipmentList() : base(13, 3, new Rect(1503, 10, 20, 20), "EQUIPMENT MENU")
        {
            int buttonPlacement = 1;
            List<Button> buttons = new List<Button>();
            for (int i = 0; i < UmbraMenu.equipment.Count; i++)
            {
                var equipmentIndex = UmbraMenu.equipment[i];
                if (equipmentIndex != EquipmentIndex.None && equipmentIndex != EquipmentCatalog.FindEquipmentIndex("AffixYellow"))
                {
                    void ButtonAction() => GiveEquipment(equipmentIndex);
                    Color32 equipColor = ColorCatalog.GetColor(EquipmentCatalog.GetEquipmentDef(equipmentIndex).colorIndex);
                    string equipmentName = Util.GenerateColoredString(Language.GetString(EquipmentCatalog.GetEquipmentDef(equipmentIndex).nameToken), ColorCatalog.GetColor(EquipmentCatalog.GetEquipmentDef(equipmentIndex).colorIndex));
                    Button button = new NormalButton(this, buttonPlacement, equipmentName, ButtonAction);
                    buttons.Add(button);
                    buttonPlacement++;
                }
                else
                {
                    void ButtonAction() => GiveEquipment(equipmentIndex);
                    string equipmentName = Util.GenerateColoredString(equipmentIndex.ToString(), ColorCatalog.GetColor(ColorCatalog.ColorIndex.Equipment));
                    Button button = new NormalButton(this, buttonPlacement, equipmentName, ButtonAction);
                    buttons.Add(button);
                    buttonPlacement++;
                }
            }
            AddButtons(buttons);
            ActivatingButton = UmbraMenu.itemsMenu.toggleEquipmentListMenu;
        }

        public override void Draw()
        {
            if (IsEnabled())
            {
                SetWindow();
                base.Draw();
            }
        }

        private void GiveEquipment(EquipmentIndex equipIndex)
        {
            var localUser = LocalUserManager.GetFirstLocalUser();
            if (localUser.cachedMasterController && localUser.cachedMasterController.master)
            {
                if (Items.isDropItemForAll)
                {
                    Items.DropEquipmentMethod(equipIndex);
                }
                else if (Items.isDropItemFromInventory)
                {
                    if (UmbraMenu.LocalPlayerInv.currentEquipmentIndex == equipIndex)
                    {
                        UmbraMenu.LocalPlayerInv.SetEquipmentIndex(EquipmentIndex.None);
                        Items.DropEquipmentMethod(equipIndex);
                    }
                    else
                    {
                        Chat.AddMessage($"<color=yellow> You do not have that equipment and therefore cannot drop it.</color>");
                        Chat.AddMessage($" ");
                    }
                }
                else
                {
                    UmbraMenu.LocalPlayerInv.SetEquipmentIndex(equipIndex);
                }
            }
        }
    }
}