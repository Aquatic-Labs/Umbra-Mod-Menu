using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace UmbraMenu
{
    public sealed class Keybind
    {
        public static Keybind OpenMainMenu;
        public KeyCode KeyCode;
        public string Name;

        public Keybind (string name, KeyCode keyCode)
        {
            this.KeyCode = keyCode;
            this.Name = name;
        }
    }
}
