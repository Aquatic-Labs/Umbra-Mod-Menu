using System.Collections.Generic;
using UnityEngine;

namespace UmbraMenu
{
    public interface IMenu
    {
        int Id { get; set; }
        int NumberOfButtons { get; set; }
        bool Enabled { get; set; }
        bool IfDragged { get; set; }
        float WidthSize { get; set; }
        Button ActivatingButton { get; set; }
        List<Button> Buttons { get; set; }
        Vector2 CurrentScrollPosition { get; set; }
        int PrevMenuId { get; set; }
        Rect Rect { get; set; }
        string Title { get; set; }
        void SetWindow();
        void Draw();
        void Reset();
    }
}
