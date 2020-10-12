using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace UmbraMenu
{
    public class MulButton
    {
        public Menu parentMenu;
        public int position;
        public Rect rect;
        public string text;
        public bool enabled = false;
        public GUIStyle style = Styles.BtnStyle;
        public Action Action, IncreaseAction, DecreaseAction;
        private bool highlighted = false;

        public bool Highlighted
        {
            get
            {
                return highlighted;
            }
            set
            {
                enabled = value;
                if (highlighted)
                {

                }
                else
                {

                }
                parentMenu.AddMulButton(this);
            }
        }

        public MulButton(Menu parentMenu, int position, string text, Action Action, Action IncreaseAction, Action DecreaseAction)
        {
            this.parentMenu = parentMenu;
            this.position = position;
            this.text = text;
            this.Action = Action;
            this.IncreaseAction = IncreaseAction;
            this.DecreaseAction = DecreaseAction;
        }
    }
}
