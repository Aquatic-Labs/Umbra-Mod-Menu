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

        public static GUIStyle HighlightedCheckButton(GUIStyle defaultStyle, Button button)
        {
            if (UmbraMenu.navigationToggle)
            {
                if (button.parentMenu.highlighted && button.Highlighted)
                {
                    return Styles.HighlightBtnStyle;
                }
                else
                {
                    return defaultStyle;
                }
            }
            return defaultStyle;
        }

        public static GUIStyle HighlightedCheckMulButton(GUIStyle defaultStyle, MulButton button)
        {
            if (UmbraMenu.navigationToggle)
            {
                if (button.parentMenu.highlighted && button.Highlighted)
                {
                    return Styles.HighlightBtnStyle;
                }
                else
                {
                    return defaultStyle;
                }
            }
            return defaultStyle;
        }

        public static GUIStyle HighlightedCheckTogglableButton(GUIStyle defaultStyle, TogglableButton button)
        {
            if (UmbraMenu.navigationToggle)
            {
                if (button.parentMenu.highlighted && button.Highlighted)
                {
                    return Styles.HighlightBtnStyle;
                }
                else
                {
                    return defaultStyle;
                }
            }
            return defaultStyle;
        }

        public static GUIStyle HighlightedCheckTogglableMulButton(GUIStyle defaultStyle, TogglableMulButton button)
        {
            if (UmbraMenu.navigationToggle)
            {
                if (button.parentMenu.highlighted && button.Highlighted)
                {
                    return Styles.HighlightBtnStyle;
                }
                else
                {
                    return defaultStyle;
                }
            }
            return defaultStyle;
        }
    }
}
