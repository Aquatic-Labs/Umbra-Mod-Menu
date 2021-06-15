using System.Collections.Generic;
using RoR2;
using UnityEngine;
using Umbra = UmbraMenu.Model.UmbraMod;
using Items = UmbraMenu.Model.Cheats.Items;

namespace UmbraMenu.View
{
    public class EquipmentListMenu : ListMenu
    {
        public EquipmentListMenu() : base(13, 3, new Rect(1503, 10, 20, 20), "EQUIPMENT MENU")
        {
            int buttonPlacement = 1;
            List<Button> buttons = new List<Button>();
            for (int i = 0; i < Umbra.Instance.equipment.Count; i++)
            {
                var equipmentIndex = Umbra.Instance.equipment[i];
                if (equipmentIndex != EquipmentIndex.None && equipmentIndex != EquipmentCatalog.FindEquipmentIndex("AffixYellow"))
                {
                    void ButtonAction() => Items.GiveEquipment(equipmentIndex);
                    Color32 equipColor = ColorCatalog.GetColor(EquipmentCatalog.GetEquipmentDef(equipmentIndex).colorIndex);
                    string equipmentName = Util.GenerateColoredString(Language.GetString(EquipmentCatalog.GetEquipmentDef(equipmentIndex).nameToken), ColorCatalog.GetColor(EquipmentCatalog.GetEquipmentDef(equipmentIndex).colorIndex));
                    Button button = new NormalButton(this, buttonPlacement, equipmentName, ButtonAction);
                    buttons.Add(button);
                    buttonPlacement++;
                }
                else
                {
                    void ButtonAction() => Items.GiveEquipment(equipmentIndex);
                    string equipmentName = Util.GenerateColoredString(equipmentIndex.ToString(), ColorCatalog.GetColor(ColorCatalog.ColorIndex.Equipment));
                    Button button = new NormalButton(this, buttonPlacement, equipmentName, ButtonAction);
                    buttons.Add(button);
                    buttonPlacement++;
                }
            }
            AddButtons(buttons);
            ActivatingButton = UmbraModGUI.Instance.itemsMenu.toggleEquipmentListMenu;
        }

        public override void Draw()
        {
            if (IsEnabled())
            {
                SetWindow();
                base.Draw();
            }
        }
    }
}