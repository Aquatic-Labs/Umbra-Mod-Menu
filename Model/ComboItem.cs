using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Umbra_Mod_Menu.Model
{
    internal class ComboItem
    {
        public int ID { get; set; }
        public string Text { get; set; }
        public string Data { get; set; }

        public ComboItem(int iD, string text, string data = "")
        {
            ID = iD;
            Text = text;
            Data = data;
        }
    }
}
