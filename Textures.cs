using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

namespace UmbraMenu
{
    class Textures
    {
        public Texture2D onTexture, onPressTexture, offTexture, offPressTexture, highlightTexture, highlightPressTexture, cornerTexture, backTexture, btnTexture, btnPressTexture, btnTextureLabel;
        public Texture2D CreateTexture(Color32 color)
        {
            Texture2D textureVar = new Texture2D(1, 1);
            textureVar.SetPixel(0, 0, color);
            textureVar.Apply();
            return textureVar;
        }

        public void BuildTextures()
        {
            btnTexture = CreateTexture(new Color32(105, 105, 105, 240));
            btnTextureLabel = CreateTexture(new Color32(255, 0, 0, 255));
            btnPressTexture = CreateTexture(new Color32(99, 99, 99, 240));
            onPressTexture = CreateTexture(new Color32(50, 50, 50, 240));
            onTexture = CreateTexture(new Color32(67, 67, 67, 240));
            offPressTexture = CreateTexture(new Color32(99, 99, 99, 240));
            offTexture = CreateTexture(new Color32(105, 105, 105, 240));
            backTexture = CreateTexture(new Color32(0, 0, 0, 120));
            cornerTexture = CreateTexture(new Color32(42, 42, 42, 0));
            highlightTexture = CreateTexture(new Color32(0, 0, 0, 0));
            highlightPressTexture = CreateTexture(new Color32(0, 0, 0, 0));
        }
    }
}
