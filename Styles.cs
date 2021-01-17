using System;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Collections.Generic;
using RoR2;
using UnityEngine;

namespace UmbraMenu
{
    public static class Styles
    {
        private static GUIStyle mainBgStyle, onStyle, offStyle, labelStyle, titleStyle, btnStyle, itemBtnStyle, cornerStyle, highlightBtnStyle, activeModsStyle, renderTeleporterStyle, renderMobsStyle, renderInteractablesStyle, renderSecretsStyle, watermarkStyle, statsStyle, selectedChestStyle;

        public static GUIStyle CreateGUIStyle(Texture2D normalBackground, Texture2D activeBackground, Color color, int fontSize, FontStyle font, TextAnchor textAlignmnet, bool wrapWords = false)
        {
            GUIStyle GUIStyle = new GUIStyle();
            GUIStyle.normal.background = normalBackground;
            GUIStyle.onNormal.background = normalBackground;
            GUIStyle.active.background = activeBackground;
            GUIStyle.onActive.background = activeBackground;
            GUIStyle.normal.textColor = color;
            GUIStyle.onNormal.textColor = color;
            GUIStyle.active.textColor = color;
            GUIStyle.onActive.textColor = color;
            GUIStyle.fontSize = fontSize;
            GUIStyle.fontStyle = font;
            GUIStyle.alignment = textAlignmnet;
            GUIStyle.wordWrap = wrapWords;
            return GUIStyle;
        }

        private static void BuildStyles()
        {
            mainBgStyle = CreateGUIStyle(Textures.BackTexture, Textures.BackTexture, Color.HSVToRGB(0.5256f, 0.9286f, 0.9333f), 15, FontStyle.Normal, TextAnchor.UpperCenter);
            cornerStyle = CreateGUIStyle(Textures.BtnTexture, Textures.BackTexture, Color.HSVToRGB(0.5256f, 0.9286f, 0.9333f), 18, FontStyle.Normal, TextAnchor.UpperCenter);
            labelStyle = CreateGUIStyle(null, null, Color.grey, 18, FontStyle.Normal, TextAnchor.UpperCenter);
            statsStyle = CreateGUIStyle(null, null, Color.grey, 18, FontStyle.Normal, TextAnchor.MiddleLeft);
            titleStyle = CreateGUIStyle(null, null, Color.HSVToRGB(0.5256f, 0.9286f, 0.9333f), 18, FontStyle.Normal, TextAnchor.UpperCenter);
            activeModsStyle = CreateGUIStyle(null, null, Color.HSVToRGB(0.5256f, 0.9286f, 0.9333f), 18, FontStyle.Normal, TextAnchor.MiddleLeft, true);
            renderInteractablesStyle = CreateGUIStyle(null, null, Color.green, 14, FontStyle.Normal, TextAnchor.MiddleLeft);
            renderSecretsStyle = CreateGUIStyle(null, null, Color.HSVToRGB(0.5065f, 1.0000f, 1.0000f), 14, FontStyle.Normal, TextAnchor.MiddleLeft);
            renderTeleporterStyle = CreateGUIStyle(null, null, Color.white, 14, FontStyle.Normal, TextAnchor.MiddleLeft);
            renderMobsStyle = CreateGUIStyle(null, null, Color.red, 14, FontStyle.Normal, TextAnchor.MiddleLeft);
            selectedChestStyle = CreateGUIStyle(null, null, Color.blue, 14, FontStyle.Normal, TextAnchor.MiddleRight);
            watermarkStyle = CreateGUIStyle(null, null, Color.HSVToRGB(0.5256f, 0.9286f, 0.9333f), 14, FontStyle.Normal, TextAnchor.MiddleLeft);
            offStyle = CreateGUIStyle(Textures.OffTexture, Textures.OffPressTexture, Color.HSVToRGB(0.5256f, 0.9286f, 0.9333f), 15, FontStyle.Normal, TextAnchor.MiddleCenter);
            onStyle = CreateGUIStyle(Textures.OnTexture, Textures.OnPressTexture, Color.HSVToRGB(0.5256f, 0.9286f, 0.9333f), 15, FontStyle.Normal, TextAnchor.MiddleCenter);
            btnStyle = CreateGUIStyle(Textures.BtnTexture, Textures.BtnPressTexture, Color.HSVToRGB(0.5256f, 0.9286f, 0.9333f), 15, FontStyle.Normal, TextAnchor.MiddleCenter);
            itemBtnStyle = CreateGUIStyle(Textures.BtnTexture, Textures.BtnPressTexture, Color.HSVToRGB(0.5256f, 0.9286f, 0.9333f), 15, FontStyle.Normal, TextAnchor.MiddleCenter);
            highlightBtnStyle = CreateGUIStyle(Textures.HighlightTexture, Textures.HighlightPressTexture, Color.HSVToRGB(0.5256f, 0.9286f, 0.9333f), 15, FontStyle.Normal, TextAnchor.MiddleCenter);
        }

        #region Styles

        public static GUIStyle MainBgStyle
        {
            get
            {
                if (mainBgStyle == null)
                {
                    mainBgStyle = CreateGUIStyle(Textures.BackTexture, Textures.BackTexture, Color.HSVToRGB(0.5256f, 0.9286f, 0.9333f), 15, FontStyle.Normal, TextAnchor.UpperCenter);
                }
                return mainBgStyle;
            }
        }

        public static GUIStyle CornerStyle
        {
            get
            {
                if (cornerStyle == null)
                {
                    cornerStyle = CreateGUIStyle(Textures.BtnTexture, Textures.BackTexture, Color.HSVToRGB(0.5256f, 0.9286f, 0.9333f), 18, FontStyle.Normal, TextAnchor.UpperCenter);
                }
                return cornerStyle;
            }
        }
        public static GUIStyle LabelStyle
        {
            get
            {
                if (labelStyle == null)
                {
                    labelStyle = CreateGUIStyle(null, null, Color.grey, 18, FontStyle.Normal, TextAnchor.UpperCenter);
                }
                return labelStyle;
            }
        }

        public static GUIStyle StatsStyle
        {
            get
            {
                if (statsStyle == null)
                {
                    statsStyle = CreateGUIStyle(null, null, Color.grey, 18, FontStyle.Normal, TextAnchor.MiddleLeft);
                }
                return statsStyle;
            }
        }

        public static GUIStyle TitleStyle
        {
            get
            {
                if (titleStyle == null)
                {
                    titleStyle = CreateGUIStyle(null, null, Color.HSVToRGB(0.5256f, 0.9286f, 0.9333f), 18, FontStyle.Normal, TextAnchor.UpperCenter);
                }
                return titleStyle;
            }
        }

        public static GUIStyle ActiveModsStyle
        {
            get
            {
                if (activeModsStyle == null)
                {
                    activeModsStyle = CreateGUIStyle(null, null, Color.HSVToRGB(0.5256f, 0.9286f, 0.9333f), 18, FontStyle.Normal, TextAnchor.MiddleLeft, true);
                }
                return activeModsStyle;
            }
        }

        public static GUIStyle RenderInteractablesStyle
        {
            get
            {
                if (renderInteractablesStyle == null)
                {
                    renderInteractablesStyle = CreateGUIStyle(null, null, Color.green, 14, FontStyle.Normal, TextAnchor.MiddleLeft);
                }
                return renderInteractablesStyle;
            }
        }


        public static GUIStyle RenderTeleporterStyle
        {
            get
            {
                if (renderTeleporterStyle == null)
                {
                    renderTeleporterStyle = CreateGUIStyle(null, null, Color.white, 14, FontStyle.Normal, TextAnchor.MiddleLeft);
                }
                return renderTeleporterStyle;
            }
        }


        public static GUIStyle RenderMobsStyle
        {
            get
            {
                if (renderMobsStyle == null)
                {
                    renderMobsStyle = CreateGUIStyle(null, null, Color.red, 14, FontStyle.Normal, TextAnchor.MiddleLeft);
                }
                return renderMobsStyle;
            }
        }


        public static GUIStyle SelectedChestStyle
        {
            get
            {
                if (selectedChestStyle == null)
                {
                    selectedChestStyle = CreateGUIStyle(null, null, Color.HSVToRGB(0.5256f, 0.9286f, 0.9333f), 14, FontStyle.Normal, TextAnchor.MiddleRight);
                }
                return selectedChestStyle;
            }
        }

        public static GUIStyle WatermarkStyle
        {
            get
            {
                if (watermarkStyle == null)
                {
                    watermarkStyle = CreateGUIStyle(null, null, Color.HSVToRGB(0.5256f, 0.9286f, 0.9333f), 14, FontStyle.Normal, TextAnchor.MiddleLeft);
                }
                return watermarkStyle;
            }
        }

        public static GUIStyle OffStyle
        {
            get
            {
                if (offStyle == null)
                {
                    offStyle = CreateGUIStyle(Textures.OffTexture, Textures.OffPressTexture, Color.HSVToRGB(0.5256f, 0.9286f, 0.9333f), 15, FontStyle.Normal, TextAnchor.MiddleCenter);
                }
                return offStyle;
            }
        }

        public static GUIStyle OnStyle
        {
            get
            {
                if (onStyle == null)
                {
                    onStyle = CreateGUIStyle(Textures.OnTexture, Textures.OnPressTexture, Color.HSVToRGB(0.5256f, 0.9286f, 0.9333f), 15, FontStyle.Normal, TextAnchor.MiddleCenter);
                }
                return onStyle;
            }
        }

        public static GUIStyle BtnStyle
        {
            get
            {
                if (btnStyle == null)
                {
                    btnStyle = CreateGUIStyle(Textures.BtnTexture, Textures.BtnPressTexture, Color.HSVToRGB(0.5256f, 0.9286f, 0.9333f), 15, FontStyle.Normal, TextAnchor.MiddleCenter);
                }
                return btnStyle;
            }
        }

        public static GUIStyle ItemBtnStyle
        {
            get
            {
                if (itemBtnStyle == null)
                {
                    itemBtnStyle = CreateGUIStyle(Textures.BtnTexture, Textures.BtnPressTexture, Color.HSVToRGB(0.5256f, 0.9286f, 0.9333f), 15, FontStyle.Normal, TextAnchor.MiddleCenter);
                }
                return itemBtnStyle;
            }
        }


        public static GUIStyle HighlightBtnStyle
        {
            get
            {
                if (highlightBtnStyle == null)
                {
                    highlightBtnStyle = CreateGUIStyle(Textures.HighlightTexture, Textures.HighlightPressTexture, Color.HSVToRGB(0.5256f, 0.9286f, 0.9333f), 15, FontStyle.Normal, TextAnchor.MiddleCenter);
                }
                return highlightBtnStyle;
            }
        }

        public static GUIStyle RenderSecretsStyle
        {
            get
            {
                if (renderSecretsStyle == null)
                {

                    renderSecretsStyle = CreateGUIStyle(null, null, Color.HSVToRGB(0.5065f, 1.0000f, 1.0000f), 14, FontStyle.Normal, TextAnchor.MiddleLeft);

                }
                return renderSecretsStyle;
            }
        }
        #endregion
    }
}
