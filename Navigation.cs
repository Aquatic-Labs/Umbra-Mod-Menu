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

        public void IncreaseValue(MulButton button)
        {
            button?.IncreaseAction?.Invoke();
        }

        public void DecreaseValue(MulButton button)
        {
            button?.DecreaseAction?.Invoke();
        }
    }
}
