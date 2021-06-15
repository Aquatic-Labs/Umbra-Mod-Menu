using UnityEngine;

namespace UmbraMenu
{
    public sealed class Keybind
    {
        public KeyCode KeyCode;
        public string Name;

        public Keybind (string name, KeyCode keyCode)
        {
            this.KeyCode = keyCode;
            this.Name = name;
        }
    }
}
