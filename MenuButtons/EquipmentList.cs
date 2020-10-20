using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RoR2;
using UnityEngine;

namespace UmbraMenu.MenuButtons
{
    public class EquipmentList
    {
        private static readonly ListMenu currentMenu = (ListMenu)Utility.FindMenuById(13);

        public static void AddButtonsToMenu()
        {
            List<IButton> buttons = new List<IButton>();

            int buttonPlacement = 1;
            for (int i = 0; i < UmbraMenu.equipment.Count; i++)
            {
                var equipmentIndex = UmbraMenu.equipment[i];
                if (equipmentIndex != EquipmentIndex.None && equipmentIndex != EquipmentIndex.AffixYellow)
                {
                    void ButtonAction() => GiveEquipment(equipmentIndex);
                    Color32 equipColor = ColorCatalog.GetColor(EquipmentCatalog.GetEquipmentDef(equipmentIndex).colorIndex);
                    string equipmentName = Util.GenerateColoredString(Language.GetString(EquipmentCatalog.GetEquipmentDef(equipmentIndex).nameToken), ColorCatalog.GetColor(EquipmentCatalog.GetEquipmentDef(equipmentIndex).colorIndex));
                    Button button = new Button(currentMenu, buttonPlacement, equipmentName, ButtonAction);
                    buttons.Add(button);
                    buttonPlacement++;
                }
                else
                {
                    void ButtonAction() => GiveEquipment(equipmentIndex);
                    string equipmentName = Util.GenerateColoredString(equipmentIndex.ToString(), ColorCatalog.GetColor(ColorCatalog.ColorIndex.Equipment));
                    Button button = new Button(currentMenu, buttonPlacement, equipmentName, ButtonAction);
                    buttons.Add(button);
                    buttonPlacement++;
                }
            }
            currentMenu.buttons = buttons;
        }

        private static void GiveEquipment(EquipmentIndex equipIndex)
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
