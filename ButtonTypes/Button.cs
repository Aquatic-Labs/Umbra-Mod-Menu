using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace UmbraMenu
{
    public class Button
    {
        public IButton _button;

        public Button(IButton button)
        {
            _button = button;
        }

        public void Draw()
        {
            _button.Draw();
        }
    }
}
