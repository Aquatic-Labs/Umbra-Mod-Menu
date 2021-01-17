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
        private IButton _button;

        public Button(IButton button)
        {
            _button = button;
        }

        public void Draw()
        {
            _button.Draw();
        }

        public void SetText(string newText)
        {
            _button.Text = newText;
        }

        public void SetOnText(string newText)
        {
            _button.OnText = newText;
        }

        public void SetOffText(string newText)
        {
            _button.OffText = newText;
        }

        public string GetOnText()
        {
            return _button.OnText;
        }

        public string GetOffText()
        {
            return _button.OffText;
        }

        public bool IsEnabled()
        {
            return _button.Enabled;
        }

        public void SetEnabled(bool value)
        {
            _button.Enabled = value;
        }

        public void ToggleButton()
        {
            _button.Enabled = !_button.Enabled;
        }

        public int GetId()
        {
            return _button.Position;
        }

        public Menu GetParentMenu()
        {
            return _button.ParentMenu;
        }

        public Action GetAction()
        {
            return _button.Action;
        }

        public Action GetIncreaseAction()
        {
            return _button.IncreaseAction;
        }

        public Action GetDecreaseAction()
        {
            return _button.DecreaseAction;
        }
    }
}
