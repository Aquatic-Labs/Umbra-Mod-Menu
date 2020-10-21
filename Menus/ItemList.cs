using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RoR2;
using UnityEngine;

namespace UmbraMenu.MenuButtons
{
    public class ItemList
    {
        private static readonly ListMenu currentMenu = null; // (ListMenu)Utility.FindMenuById(12);

        public static void AddButtonsToMenu()
        {
            List<Button> buttons = new List<Button>();

            int buttonPlacement = 1;
            for (int i = 0; i < UmbraMenu.items.Count; i++)
            {
                ItemIndex itemIndex = UmbraMenu.items[i];
                void ButtonAction() => GiveItem(itemIndex);
                Color32 itemColor = ColorCatalog.GetColor(ItemCatalog.GetItemDef(itemIndex).colorIndex);
                if (itemColor.r <= 105 && itemColor.g <= 105 && itemColor.b <= 105)
                {
                    string itemName = Util.GenerateColoredString(Language.GetString(ItemCatalog.GetItemDef(itemIndex).nameToken), new Color32(255, 255, 255, 255));
                    //Button button = new Button(currentMenu, buttonPlacement, itemName, ButtonAction);
                    //buttons.Add(button);
                    buttonPlacement++;
                }
                else
                {
                    string itemName = Util.GenerateColoredString(Language.GetString(ItemCatalog.GetItemDef(itemIndex).nameToken), itemColor);
                    //Button button = new Button(currentMenu, buttonPlacement, itemName, ButtonAction);
                    //buttons.Add(button);
                    buttonPlacement++;
                }
            }
            currentMenu.Buttons = buttons;
        }

        private static void GiveItem(ItemIndex itemIndex)
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
