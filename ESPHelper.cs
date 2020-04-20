using UnityEngine;

namespace RoRCheats
{
    public static class ESPHelper
    {
        private static Texture2D _coloredLineTexture;
        private static Color _coloredLineColor;

        public static void DrawLine(Vector2 lineStart, Vector2 lineEnd, Color color)
        {
            DrawLine(lineStart, lineEnd, color, 1);
        }

        public static void DrawBox(float x, float y, float w, float h, Color color)
        {
            DrawLine(new Vector2(x, y), new Vector2(x + w, y), color);
            DrawLine(new Vector2(x, y), new Vector2(x, y + h), color);
            DrawLine(new Vector2(x + w, y), new Vector2(x + w, y + h), color);
            DrawLine(new Vector2(x, y + h), new Vector2(x + w, y + h), color);
        }

        public static void DrawLine(Vector2 lineStart, Vector2 lineEnd, Color color, int thickness)
        {
            if (_coloredLineTexture == null || _coloredLineColor != color)
            {
                _coloredLineColor = color;
                _coloredLineTexture = new Texture2D(1, 1);
                _coloredLineTexture.SetPixel(0, 0, _coloredLineColor);
                _coloredLineTexture.wrapMode = 0;
                _coloredLineTexture.Apply();
            }

            DrawLineStretched(lineStart, lineEnd, _coloredLineTexture, thickness);
        }

        public static void DrawLineStretched(Vector2 lineStart, Vector2 lineEnd, Texture2D texture, int thickness)
        {
            var vector = lineEnd - lineStart;
            float pivot = 57.29578f * Mathf.Atan(vector.y / vector.x);
            if (vector.x < 0f)
            {
                pivot += 180f;
            }

            if (thickness < 1)
            {
                thickness = 1;
            }

            int yOffset = (int)Mathf.Ceil((float)(thickness / 2));

            GUIUtility.RotateAroundPivot(pivot, lineStart);
            GUI.DrawTexture(new Rect(lineStart.x, lineStart.y - (float)yOffset, vector.magnitude, (float)thickness), texture);
            GUIUtility.RotateAroundPivot(-pivot, lineStart);
        }

        public static void DrawLine(Vector2 lineStart, Vector2 lineEnd, Texture2D texture)
        {
            DrawLine(lineStart, lineEnd, texture, 1);
        }

        public static void DrawLine(Vector2 lineStart, Vector2 lineEnd, Texture2D texture, int thickness)
        {
            var vector = lineEnd - lineStart;
            float pivot = 57.29578f * Mathf.Atan(vector.y / vector.x);

            if (vector.x < 0f)
            {
                pivot += 180f;
            }

            if (thickness < 1)
            {
                thickness = 1;
            }

            int num2 = (int)Mathf.Ceil((float)(thickness / 2));
            var rect = new Rect(lineStart.x, lineStart.y - (float)num2, Vector2.Distance(lineStart, lineEnd), (float)thickness);
            GUIUtility.RotateAroundPivot(pivot, lineStart);
            GUI.BeginGroup(rect);
            int num3 = Mathf.RoundToInt(rect.width);
            int num4 = Mathf.RoundToInt(rect.height);

            for (int i = 0; i < num4; i += texture.height)
            {
                for (int j = 0; j < num3; j += texture.width)
                {
                    GUI.DrawTexture(new Rect((float)j, (float)i, (float)texture.width, (float)texture.height), texture);
                }
            }

            GUI.EndGroup();
            GUIUtility.RotateAroundPivot(-pivot, lineStart);
        }
    }
}
