using System;
using UnityEditor;
using UnityEngine;

namespace Editor.ModelEditor.Helpers
{
    public class DrawerHelper
    {
        private Vector2 _drag;
        private Vector2 _offset;

        public void DrawButton(string butName, Action action, float width = 0f, float height = 0f)
        {
            var style = new GUIStyle("Button");

            if (width != 0f)
            {
                style.fixedWidth = width;
            }
            
            if (height != 0f)
            {
                style.fixedHeight = height;
            }

            if (GUILayout.Button(butName, style))
            {
                action?.Invoke();
            }
        }

        public void DrawLabel(string text, float width = 0f, float height = 0f)
        {
            var style = new GUIStyle("Label");
            
            if (width != 0f)
            {
                style.fixedWidth = width;
            }
            
            if (height != 0f)
            {
                style.fixedHeight = height;
            }

            GUILayout.Label(text, style);
        }
        
        public void DrawFrame(Rect rect, Color color)
        {
            Handles.color = color;

            var p0 = rect.position;
            var p1 = p0 + Vector2.right * rect.width;
            var p2 = p1 + Vector2.up * rect.height;
            var p3 = p0 + Vector2.up * rect.height;
            
            Handles.DrawLine(p0, p1);
            Handles.DrawLine(p1, p2);
            Handles.DrawLine(p2, p3);
            Handles.DrawLine(p3, p0);
        }
    }
}