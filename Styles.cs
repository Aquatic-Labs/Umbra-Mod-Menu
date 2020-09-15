using System;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Collections.Generic;
using RoR2;
using UnityEngine;

namespace UmbraMenu
{
    public class Styles
    {
        public static GUIStyle MainBgStyle, StatBgSytle, TeleBgStyle, OnStyle, OffStyle, LabelStyle, TitleStyle, BtnStyle, ItemBtnStyle, CornerStyle, DisplayStyle, BgStyle, HighlightBtnStyle, ActiveModsStyle, renderTeleporterStyle, renderMobsStyle, renderInteractablesStyle, renderSecretsStyle, WatermarkStyle, StatsStyle, selectedChestStyle;

        public GUIStyle CreateGUIStyle(Texture2D normalBackground, Texture2D activeBackground, Color color, int fontSize, FontStyle font, TextAnchor textAlignmnet, bool wrapWords = false)
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

        public void BuildStyles()
        {
            MainBgStyle = CreateGUIStyle(Textures.BackTexture, Textures.BackTexture, Color.HSVToRGB(0.5256f, 0.9286f, 0.9333f), 15, FontStyle.Normal, TextAnchor.UpperCenter);
            CornerStyle = CreateGUIStyle(Textures.BtnTexture, Textures.BackTexture, Color.HSVToRGB(0.5256f, 0.9286f, 0.9333f), 18, FontStyle.Normal, TextAnchor.UpperCenter);
            LabelStyle = CreateGUIStyle(null, null, Color.grey, 18, FontStyle.Normal, TextAnchor.UpperCenter);
            StatsStyle = CreateGUIStyle(null, null, Color.grey, 18, FontStyle.Normal, TextAnchor.MiddleLeft);
            TitleStyle = CreateGUIStyle(null, null, Color.HSVToRGB(0.5256f, 0.9286f, 0.9333f), 18, FontStyle.Normal, TextAnchor.UpperCenter);
            ActiveModsStyle = CreateGUIStyle(null, null, Color.HSVToRGB(0.5256f, 0.9286f, 0.9333f), 18, FontStyle.Normal, TextAnchor.MiddleLeft, true);
            renderInteractablesStyle = CreateGUIStyle(null, null, Color.green, 14, FontStyle.Normal, TextAnchor.MiddleLeft);
            renderSecretsStyle = CreateGUIStyle(null, null, Color.HSVToRGB(0.5065f, 1.0000f, 1.0000f), 14, FontStyle.Normal, TextAnchor.MiddleLeft);
            renderTeleporterStyle = CreateGUIStyle(null, null, Color.white, 14, FontStyle.Normal, TextAnchor.MiddleLeft);
            renderMobsStyle = CreateGUIStyle(null, null, Color.red, 14, FontStyle.Normal, TextAnchor.MiddleLeft);
            selectedChestStyle = CreateGUIStyle(null, null, Color.blue, 14, FontStyle.Normal, TextAnchor.MiddleRight);
            WatermarkStyle = CreateGUIStyle(null, null, Color.HSVToRGB(0.5256f, 0.9286f, 0.9333f), 14, FontStyle.Normal, TextAnchor.MiddleLeft);
            OffStyle = CreateGUIStyle(Textures.OffTexture, Textures.OffPressTexture, Color.HSVToRGB(0.5256f, 0.9286f, 0.9333f), 15, FontStyle.Normal, TextAnchor.MiddleCenter);
            OnStyle = CreateGUIStyle(Textures.OnTexture, Textures.OnPressTexture, Color.HSVToRGB(0.5256f, 0.9286f, 0.9333f), 15, FontStyle.Normal, TextAnchor.MiddleCenter);
            BtnStyle = CreateGUIStyle(Textures.BtnTexture, Textures.BtnPressTexture, Color.HSVToRGB(0.5256f, 0.9286f, 0.9333f), 15, FontStyle.Normal, TextAnchor.MiddleCenter);
            ItemBtnStyle = CreateGUIStyle(Textures.BtnTexture, Textures.BtnPressTexture, Color.HSVToRGB(0.5256f, 0.9286f, 0.9333f), 15, FontStyle.Normal, TextAnchor.MiddleCenter);
            HighlightBtnStyle = CreateGUIStyle(Textures.HighlightTexture, Textures.HighlightPressTexture, Color.HSVToRGB(0.5256f, 0.9286f, 0.9333f), 15, FontStyle.Normal, TextAnchor.MiddleCenter);
        }
    }
}
