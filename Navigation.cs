using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace UmbraMenu
{
    class Navigation
    {
        public void PressButton(Button button)
        {
            button?.Action?.Invoke();
        }

        public void IncreaseValue(Button button)
        {
            button?.IncreaseAction?.Invoke();
        }

        public void DecreaseValue(Button button)
        {
            button?.DecreaseAction?.Invoke();
        }
    }
}
