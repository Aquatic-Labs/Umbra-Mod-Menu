using UnityEngine;

namespace UmbraMenu
{
    public static class Textures
    {
        private static Texture2D onTexture, onPressTexture, offTexture, offPressTexture, highlightTexture, highlightPressTexture, cornerTexture, backTexture, btnTexture, btnPressTexture, btnTextureLabel;
        private static Texture2D NewTexture2D { get { return new Texture2D(1, 1); } }

        #region Textures
        public static Texture2D BtnTexture
        {
            get
            {
                if (btnTexture == null)
                {
                    btnTexture = NewTexture2D;
                    btnTexture.SetPixel(0, 0, new Color32(85, 85, 85, 240));
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
                    btnPressTexture.SetPixel(0, 0, new Color32(79, 79, 79, 240));
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
                    onPressTexture.SetPixel(0, 0, new Color32(30, 30, 30, 240));
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
                    onTexture.SetPixel(0, 0, new Color32(47, 47, 47, 240));
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
                    offPressTexture.SetPixel(0, 0, new Color32(79, 79, 79, 240));
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
                    offTexture.SetPixel(0, 0, new Color32(85, 85, 85, 240));
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
