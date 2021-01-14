using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RoR2;
using UnityEngine;

namespace UmbraMenu.Menus
{
    public class ItemList : Menu
    {
        private static readonly IMenu itemsList = new ListMenu(12, new Rect(1503, 10, 20, 20), "I T E M S   M E N U");

        public ItemList() : base(itemsList)
        {
            if (UmbraMenu.characterCollected)
            {
                int buttonPlacement = 1;
                List<Button> buttons = new List<Button>();
                for (int i = 0; i < UmbraMenu.items.Count; i++)
                {
                    ItemIndex itemIndex = UmbraMenu.items[i];
                    void ButtonAction() => GiveItem(itemIndex);
                    Color32 itemColor = ColorCatalog.GetColor(ItemCatalog.GetItemDef(itemIndex).colorIndex);
                    if (itemColor.r <= 105 && itemColor.g <= 105 && itemColor.b <= 105)
                    {
                        string itemName = Util.GenerateColoredString(Language.GetString(ItemCatalog.GetItemDef(itemIndex).nameToken), new Color32(255, 255, 255, 255));
                        Button button = new Button(new NormalButton(this, buttonPlacement, itemName, ButtonAction));
                        buttons.Add(button);
                        buttonPlacement++;
                    }
                    else
                    {
                        string itemName = Util.GenerateColoredString(Language.GetString(ItemCatalog.GetItemDef(itemIndex).nameToken), itemColor);
                        Button button = new Button(new NormalButton(this, buttonPlacement, itemName, ButtonAction));
                        buttons.Add(button);
                        buttonPlacement++;
                    }
                }
                AddButtons(buttons);
                SetActivatingButton(Utility.FindButtonById(3, 3));
                SetPrevMenuId(3);
            }
        }

        public override void Draw()
        {
            if (IsEnabled())
            {
                SetWindow();
                base.Draw();
            }
        }

        private void GiveItem(ItemIndex itemIndex)
        {
            var localUser = LocalUserManager.GetFirstLocalUser();
            if (localUser.cachedMasterController && localUser.cachedMasterController.master)
            {
                if (Items.isDropItemForAll)
                {
                    Items.DropItemMethod(itemIndex);
                }
                else if (Items.isDropItemFromInventory)
                {
                    if (Items.CurrentInventory().Contains(itemIndex.ToString()))
                    {
                        UmbraMenu.LocalPlayerInv.RemoveItem(itemIndex, 1);
                        Items.DropItemMethod(itemIndex);
                    }
                    else
                    {
                        Chat.AddMessage($"<color=yellow> You do not have that item and therefore cannot drop it from your inventory.</color>");
                        Chat.AddMessage($" ");
                    }
                }
                else
                {
                    UmbraMenu.LocalPlayerInv.GiveItem(itemIndex, 1);
                }
            }
        }
    }
}
