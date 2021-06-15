using UnityEngine;

namespace UmbraMenu.Model
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
