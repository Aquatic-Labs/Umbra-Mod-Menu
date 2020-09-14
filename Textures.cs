using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

namespace UmbraMenu
{
    public static class Textures
    {
        public static Texture2D onTexture, onPressTexture, offTexture, offPressTexture, highlightTexture, highlightPressTexture, cornerTexture, backTexture, btnTexture, btnPressTexture, btnTextureLabel;
        public static Texture2D NewTexture2D { get { return new Texture2D(1, 1); } }

        /*public Texture2D CreateTexture(Color32 color)
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
        }*/

        #region Textures
        public static Texture2D BtnTexture
        {
            get
            {
                if (btnTexture == null)
                {
                    btnTexture = NewTexture2D;
                    btnTexture.SetPixel(0, 0, new Color32(105, 105, 105, 240));
                    btnTexture.Apply();
                }
                return btnTexture;
            }
        }

        public static Texture2D BtnTextureLabel
        {
            get
            {
                if (BtnTextureLabel == null)
                {
                    btnTextureLabel = NewTexture2D;
                    btnTextureLabel.SetPixel(0, 0, new Color32(255, 0, 0, 255));
                    btnTextureLabel.Apply();
                }
                return BtnTextureLabel;
            }
        }

        public static Texture2D BtnPressTexture
        {
            get
            {
                if (btnPressTexture == null)
                {
                    btnPressTexture = NewTexture2D;
                    btnPressTexture.SetPixel(0, 0, new Color32(99, 99, 99, 240));
                    btnPressTexture.Apply();
                }
                return btnPressTexture;
            }
        }

        public static Texture2D OnPressTexture
        {
            get
            {
                if (onPressTexture == null)
                {
                    onPressTexture = NewTexture2D;
                    onPressTexture.SetPixel(0, 0, new Color32(50, 50, 50, 240));
                    onPressTexture.Apply();
                }
                return onPressTexture;
            }
        }

        public static Texture2D OnTexture
        {
            get
            {
                if (onTexture == null)
                {
                    onTexture = NewTexture2D;
                    onTexture.SetPixel(0, 0, new Color32(67, 67, 67, 240));
                    onTexture.Apply();
                }
                return onTexture;
            }
        }

        public static Texture2D OffPressTexture
        {
            get
            {
                if (offPressTexture == null)
                {
                    offPressTexture = NewTexture2D;
                    offPressTexture.SetPixel(0, 0, new Color32(99, 99, 99, 240));
                    offPressTexture.Apply();
                }
                return offPressTexture;
            }
        }

        public static Texture2D OffTexture
        {
            get
            {
                if (offTexture == null)
                {
                    offTexture = NewTexture2D;
                    offTexture.SetPixel(0, 0, new Color32(105, 105, 105, 240));
                    // byte[] FileData = File.ReadAllBytes(Directory.GetCurrentDirectory() + "/BepInEx/plugins/UmbraRoR/Resources/Images/OffStyle.png");
                    // offtexture.LoadImage(FileData);
                    offTexture.Apply();
                }
                return offTexture;
            }
        }
        public static Texture2D BackTexture
        {
            get
            {
                if (backTexture == null)
                {
                    backTexture = NewTexture2D;
                    //backtexture.SetPixel(0, 0, new Color32(0, 0, 0, 158));
                    backTexture.SetPixel(0, 0, new Color32(0, 0, 0, 120));
                    backTexture.Apply();
                }
                return backTexture;
            }
        }

        public static Texture2D CornerTexture
        {
            get
            {
                if (cornerTexture == null)
                {
                    cornerTexture = NewTexture2D;
                    // ToHtmlStringRGBA  new Color(33, 150, 243, 1)
                    cornerTexture.SetPixel(0, 0, new Color32(42, 42, 42, 0));

                    cornerTexture.Apply();
                }
                return cornerTexture;
            }
        }

        public static Texture2D HighlightTexture
        {
            get
            {
                if (highlightTexture == null)
                {
                    highlightTexture = NewTexture2D;
                    highlightTexture.SetPixel(0, 0, new Color32(0, 0, 0, 0));
                    highlightTexture.Apply();
                }
                return highlightTexture;
            }
        }

        public static Texture2D HighlightPressTexture
        {
            get
            {
                if (highlightPressTexture == null)
                {
                    highlightPressTexture = NewTexture2D;
                    highlightPressTexture.SetPixel(0, 0, new Color32(0, 0, 0, 0));
                    highlightPressTexture.Apply();
                }
                return highlightPressTexture;
            }
        }

        #endregion Textures
    }
}
