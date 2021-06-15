using System;
using UnityEngine;

namespace UmbraMenu.View
{
    public class MulButton : Button
    {
        private readonly Action IncreaseAction, DecreaseAction;

        public delegate void MulChangeEventHandler(object sender, EventArgs e);
        public event MulChangeEventHandler MulChange;

        public MulButton(Menu parentMenu, int position, string text, Action Action, Action IncreaseAction, Action DecreaseAction) : base(parentMenu, position, text, Action, Styles.BtnStyle)
        {
            this.IncreaseAction = IncreaseAction;
            this.DecreaseAction = DecreaseAction;

            void clickEvent(object sender, EventArgs e) => Action?.Invoke();
            Click += clickEvent;
        }

        public override void Draw()
        {
            int btnY = 5 + 45 * Position;
            rect = new Rect(ParentMenu.GetRect().x + 5, ParentMenu.GetRect().y + btnY, ParentMenu.GetWidthSize() - 90, 40);

            if (GUI.Button(rect, Text, Navigation.HighlighedCheck(style, ParentMenu.GetId(), Position)))
            {
                OnClick();
            }
            DrawMulButtons();
        }

        private void DrawMulButtons()
        {
            Rect menuBg = ParentMenu.GetRect();
            int btnY = 5 + 45 * Position;
            if (GUI.Button(new Rect(menuBg.x + ParentMenu.GetWidthSize() - 80, menuBg.y + btnY, 40, 40), "-", Styles.OffStyle))
            {
                DecreaseAction?.Invoke();
                OnMulChange();
            }
            if (GUI.Button(new Rect(menuBg.x + ParentMenu.GetWidthSize() - 35, menuBg.y + btnY, 40, 40), "+", Styles.OffStyle))
            {
                IncreaseAction?.Invoke();
                OnMulChange();
            }
        }

        protected override void OnClick()
        {
            base.OnClick();
            Draw();
        }

        protected virtual void OnMulChange()
        {
            MulChange?.Invoke(this, EventArgs.Empty);
            Draw();
        }

        public void NavMulUpdate()
        {
            MulChange?.Invoke(this, EventArgs.Empty);
        }

        public Action GetIncreaseAction()
        {
            return IncreaseAction;
        }

        public Action GetDecreaseAction()
        {
            return DecreaseAction;
        }
    }
}
