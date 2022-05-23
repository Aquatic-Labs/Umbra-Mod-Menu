using UnityEngine;

namespace UmbraMenu.monsoon
{
    public class Renderer
    {
        public static GUIStyle StringStyle { get; set; } = new GUIStyle(GUI.skin.label);

        public static Color Color
        {
            get { return GUI.color; }
            set { GUI.color = value; }
        }

        public static void DrawLine(Vector2 from, Vector2 to, Color color)
        {
            Color = color;
            DrawLine(from, to);
        }
        public static void DrawLine(Vector2 from, Vector2 to)
        {
            var angle = Vector2.SignedAngle(from, to);
            GUIUtility.RotateAroundPivot(angle, from);
            DrawBox(from, Vector2.right * (from - to).magnitude, false);
            GUIUtility.RotateAroundPivot(-angle, from);
        }

        public static void DrawBox(Vector2 position, Vector2 size, Color color, bool centered = true)
        {
            Color = color;
            DrawBox(position, size, centered);
        }
        public static void DrawBox(Vector2 position, Vector2 size, bool centered = true)
        {
            var upperLeft = centered ? position - size / 2f : position;
            GUI.DrawTexture(new Rect(upperLeft, size), Texture2D.whiteTexture, ScaleMode.StretchToFill);
        }

        public static void DrawString(Vector2 position, string label, GUIStyle style, bool centered = true)
        {
            var content = new GUIContent(label);
            var size = StringStyle.CalcSize(content);
            var upperLeft = centered ? position - size / 2f : position;
            GUI.Label(new Rect(upperLeft, size), content, style);
        }
    }
}
