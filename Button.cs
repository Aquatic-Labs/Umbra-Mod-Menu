using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UmbraMenu
{
    public class Button
    {
        public int position;
        public string buttonText;
        public bool isMulButton = false;
        public bool justText = false;
        public bool enabled = false;

        public void Enable()
        {
            enabled = true;
        }

        public void Disable()
        {
            enabled = false;
        }
    }
}
