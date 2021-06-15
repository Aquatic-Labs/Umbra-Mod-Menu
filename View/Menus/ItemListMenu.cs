using System.Collections.Generic;
using RoR2;
using UnityEngine;
using Umbra = UmbraMenu.Model.UmbraMod;
using Items = UmbraMenu.Model.Cheats.Items;

namespace UmbraMenu.View
{
    public class ItemListMenu : ListMenu
    {
        public ItemListMenu() : base(12, 3, new Rect(1503, 10, 20, 20), "ITEMS MENU")
        {
            int buttonPlacement = 1;
            List<Button> buttons = new List<Button>();
            for (int i = 0; i < Umbra.Instance.items.Count; i++)
            {
                ItemIndex itemIndex = Umbra.Instance.items[i];
                void ButtonAction() => Items.GiveItem(itemIndex);
                Color32 itemColor = ColorCatalog.GetColor(ItemCatalog.GetItemDef(itemIndex).colorIndex);
                if (itemColor.r <= 105 && itemColor.g <= 105 && itemColor.b <= 105)
                {
                    string itemName = Util.GenerateColoredString(Language.GetString(ItemCatalog.GetItemDef(itemIndex).nameToken), new Color32(255, 255, 255, 255));
                    Button button = new NormalButton(this, buttonPlacement, itemName, ButtonAction);
                    buttons.Add(button);
                    buttonPlacement++;
                }
                else
                {
                    string itemName = Util.GenerateColoredString(Language.GetString(ItemCatalog.GetItemDef(itemIndex).nameToken), itemColor);
                    Button button = new NormalButton(this, buttonPlacement, itemName, ButtonAction);
                    buttons.Add(button);
                    buttonPlacement++;
                }
            }
            AddButtons(buttons);
            ActivatingButton = UmbraModGUI.Instance.itemsMenu.toggleItemListMenu;
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