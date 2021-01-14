using System;

namespace UmbraMenu
{
    public interface IButton
    {
        bool Enabled { get; set; }
        string Text { get; set; }
        string OnText { get; set; }
        string OffText { get; set; }
        int Position { get; set; }
        Menu ParentMenu { get; set; }
        Action Action { get; set; }
        Action IncreaseAction { get; set; }
        Action DecreaseAction { get; set; }
        void Draw();
    };
}
