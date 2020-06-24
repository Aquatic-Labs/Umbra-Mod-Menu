using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UmbraRoR
{
    class Navigation
    {
        public int MenuIndex = 0;
        public int IntraMenuIndex = 0;
        public string[] MenuList = { "Main", "Player", "Item", "Teleporter", "Render", "Lobby" };
        public string[] MainBtnNav = { "PlayerMod", "ItemMang", "Teleporter", "Render", "LobbyMang" };
        public string[] PlayerBtnNav = { "GiveMoney", "GiveCoin", "GiveXP", "DmgPerLVL", "CritPerLVL", "AttSpeed", "Armor", "MoveSpeed", "StatMenu", "BuffMenu", "RemoveBuffs", "Aimbot", "AutoSprint", "Flight", "GodMode", "NoSkillCD", "UnlockAll" };
        public string[] ItemBtnNav = { "GiveAll", "RollItems", "ItemMenu", "EquipMenu", "DropItems", "NoEquipCD", "StackShrine", "ClearInv" };
        public string[] TeleBtnNav = { "Skip", "InstaTP", "Mountain", "SpawnAll", "SpawnBlue", "SpawnCele", "SpawnGold" };
        public string[] RenderBtnNav = { "InteractESP", "MobESP" };
        public string[] LobbyBtnNav = { "Player1", "Player2", "Player3", "Player4" };
    }
}
