using UnityEngine;

namespace RoRCheats
{
    internal class btn
    {
        static public Rect BtnRect(int y, bool isMultButton, string buttonType)
        {
            if (buttonType.Equals("main"))
            {

                Main.MainMulY = y;
                if (isMultButton)
                {
                    return new Rect(Main.mainRect.x + 5, Main.mainRect.y + 5 + 45 * y, Main.widthSize - 90, 40);
                }
                else
                {
                    return new Rect(Main.mainRect.x + 5, Main.mainRect.y + 5 + 45 * y, Main.widthSize, 40);
                }


            }
            else if (buttonType.Equals("stats"))
            {
                Main.StatMulY = y;
                if (isMultButton)
                {
                    return new Rect(Main.statRect.x + 5, Main.statRect.y + 5 + 45 * y, Main.widthSize - 90, 40);
                }
                else
                {
                    return new Rect(Main.statRect.x + 5, Main.statRect.y + 5 + 45 * y, Main.widthSize - 150, 40);
                }

            }
            else if (buttonType.Equals("tele"))
            {
                Main.TeleMulY = y;
                if (isMultButton)
                {
                    return new Rect(Main.teleRect.x + 5, Main.teleRect.y + 5 + 45 * y, Main.widthSize - 90, 40);
                }
                else
                {
                    return new Rect(Main.teleRect.x + 5, Main.teleRect.y + 5 + 45 * y, Main.widthSize, 40);
                }

            }
            else if (buttonType.Equals("itemSpawner"))
            {
                Main.itemSpawnerMulY = y;
                if (isMultButton)
                {
                    return new Rect(Main.itemSpawnerRect.x + 5, Main.itemSpawnerRect.y + 5 + 45 * y, Main.widthSize - 90, 40);
                }
                else
                {
                    return new Rect(Main.itemSpawnerRect.x + 5, Main.itemSpawnerRect.y + 5 + 45 * y, Main.widthSize, 40);
                }
            }
            else if (buttonType.Equals("equipmentSpawner"))
            {
                Main.equipmentSpawnerMulY = y;
                if (isMultButton)
                {
                    return new Rect(Main.equipmentSpawnerRect.x + 5, Main.equipmentSpawnerRect.y + 5 + 45 * y, Main.widthSize - 90, 40);
                }
                else
                {
                    return new Rect(Main.equipmentSpawnerRect.x + 5, Main.equipmentSpawnerRect.y + 5 + 45 * y, Main.widthSize, 40);
                }

            }
            else if (buttonType.Equals("character"))
            {
                Main.CharacterMulY = y;
                if (isMultButton)
                {
                    return new Rect(Main.characterRect.x + 5, Main.characterRect.y + 5 + 45 * y, Main.widthSize - 90, 40);
                }
                else
                {
                    return new Rect(Main.characterRect.x + 5, Main.characterRect.y + 5 + 45 * y, Main.widthSize, 40);
                }

            }
            else if (buttonType.Equals("lobby"))
            {
                Main.LobbyMulY = y;
                if (isMultButton)
                {
                    return new Rect(Main.lobbyRect.x + 5, Main.lobbyRect.y + 5 + 45 * y, Main.widthSize - 90, 40);
                }
                else
                {
                    return new Rect(Main.lobbyRect.x + 5, Main.lobbyRect.y + 5 + 45 * y, Main.widthSize, 40);
                }

            }
            else if (buttonType.Equals("playermod"))
            {
                Main.PlayerModMulY = y;
                Main.PlayerModBtnY = 5 + 45 * y;
                if (isMultButton)
                {
                    return new Rect(Main.playerModRect.x + 5, Main.playerModRect.y + 5 + 45 * y, Main.widthSize - 90, 40);
                }
                else
                {
                    return new Rect(Main.playerModRect.x + 5, Main.playerModRect.y + 5 + 45 * y, Main.widthSize, 40);
                }

            }
            else if (buttonType.Equals("itemmanager"))
            {
                Main.ItemManagerMulY = y;
                Main.ItemManagerBtnY = 5 + 45 * y;
                if (isMultButton)
                {
                    return new Rect(Main.itemManagerRect.x + 5, Main.itemManagerRect.y + 5 + 45 * y, Main.widthSize - 90, 40);
                }
                else
                {
                    return new Rect(Main.itemManagerRect.x + 5, Main.itemManagerRect.y + 5 + 45 * y, Main.widthSize, 40);
                }

            }

            else
            {
                return new Rect(Main.itemSpawnerRect.x + 5, Main.itemSpawnerRect.y + 5 + 45 * y, Main.widthSize, 40);
            }
        }
    }
}