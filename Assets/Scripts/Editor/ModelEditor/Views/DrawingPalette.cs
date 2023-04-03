using System;
using Common;
using Editor.ModelEditor.Helpers;
using UnityEngine;

namespace Editor.ModelEditor.Views
{
    public class DrawingPalette
    {
        private string _modelsDataPath = string.Empty;
        private string _searchValue = string.Empty;
        private DrawerHelper _drawerHelper;

        public event Action ClickOkButtonEvent;
        public event Action ClickSaveButtonEvent;

        public DrawingPalette()
        {
            _drawerHelper = new DrawerHelper();
        }

        public void DrawWindowElements(Rect position)
        {
            var boxStyle = new GUIStyle(GUI.skin.window);
            DrawToolbar(position, boxStyle);
            DrawLeftMenuBarWithFunctionButtons(position, boxStyle);
            DrawScrollView(position, boxStyle);
        }

        private void DrawToolbar(Rect position, GUIStyle style)
        {
            GUILayout.Space(5f);
            GUI.Box(new Rect(0f, 0f, position.width, Constants.ToolbarHeight), GUIContent.none, style);

            GUILayout.BeginHorizontal();
            GUILayout.Space(5f);
            _drawerHelper.DrawLabel(Constants.ModelsDataPathLabel, 55f);
            _modelsDataPath = GUILayout.TextField(_modelsDataPath, 100, GUILayout.ExpandWidth(true));

            GUILayout.Space(20f);
            _drawerHelper.DrawButton(Constants.OkButtonName, ClickOkButtonEvent, 75f);
            
            GUILayout.Space(10f);
            _drawerHelper.DrawButton(Constants.SaveButtonName, ClickSaveButtonEvent, 75f);

            GUILayout.Space(20f);
            GUILayout.EndHorizontal();

            GUILayout.BeginHorizontal();
            GUILayout.EndHorizontal();
        }

        private void DrawLeftMenuBarWithFunctionButtons(Rect position, GUIStyle style)
        {
            var topBarRect = new Rect(0f, Constants.ToolbarHeight, position.width, Constants.ToolbarHeight);
            GUI.Box(topBarRect, GUIContent.none, style);

            GUILayout.BeginArea(topBarRect);
            GUILayout.Space(5f);

            GUILayout.BeginHorizontal();
            GUILayout.Space(5f);
            _drawerHelper.DrawButton(Constants.AddModelDataButtonText, 
                OnPressedAddModelDataButton, 20f);
            
            GUILayout.Space(5f);
            _drawerHelper.DrawButton(Constants.SubtractModelDataButtonText, 
                OnPressedSubtractModelDataButton, 20f);
            
            GUILayout.Space(10f);

            _drawerHelper.DrawLabel(Constants.SearchFieldLabel, 55f);
            _searchValue = GUILayout.TextField(_searchValue,
                100, GUILayout.ExpandWidth(true));

            GUILayout.Space(5f);
            
            GUILayout.EndHorizontal();
            GUILayout.EndArea();
        }

        private void DrawScrollView(Rect position, GUIStyle style)
        {
            var rect = new Rect(0f, Constants.ToolbarHeight * 2f, position.width, 
                position.height - Constants.ToolbarHeight);
            
            GUI.Box(rect, GUIContent.none, style);
        }

        private void OnPressedAddModelDataButton()
        {
        }
        
        private void OnPressedSubtractModelDataButton()
        {
        }
    }
}