
using UnityEngine;
using UnityEditor;
using System.Text.RegularExpressions;

namespace SolClovser.EditorScriptLabel.EditorTool
{
    [CustomEditor(typeof(MonoBehaviour), true)]
    public class EditorScriptLabel : Editor
    {
        private StyleConfig _styleConfigConfig;
        private GUIStyle _textStyle;
        private GUIStyle _backgroundStyle;
        private string _className;

        public void OnEnable()
        {
            _styleConfigConfig =  Resources.Load<StyleConfig>("Style Config");
            _className = target.GetType().Name;
        
            _textStyle = new GUIStyle();
            _textStyle.fontSize = _styleConfigConfig.fontSize;
            _textStyle.fontStyle = _styleConfigConfig.fontStyle;
            _textStyle.normal.textColor = _styleConfigConfig.fontColor;
            _textStyle.font = _styleConfigConfig.font;

            _backgroundStyle = new GUIStyle();
            _backgroundStyle.normal.background = _styleConfigConfig.backgroundTexture;
        }

        public override void OnInspectorGUI()
        {
            EditorGUILayout.BeginVertical(_backgroundStyle ,GUILayout.Height(_styleConfigConfig.boxHeight));
            EditorGUILayout.Space(_styleConfigConfig.boxHeight / 2f);

            EditorGUILayout.LabelField(
                _styleConfigConfig.allUpperCase ? ProcessCamelCase(_className).ToUpper() : ProcessCamelCase(_className),
                _textStyle);

            EditorGUILayout.Space(_styleConfigConfig.boxHeight / 2f);
            EditorGUILayout.EndVertical();
            EditorGUILayout.Space(_styleConfigConfig.spacingAfterLabel);
            DrawDefaultInspector();
        }

        private string ProcessCamelCase(string str)
        {
            // Splitting code taken from
            // https://social.msdn.microsoft.com/Forums/vstudio/en-US/791963c8-9e20-4e9e-b184-f0e592b943b0/split-a-camel-case-string?forum=csharpgeneral
        
            return Regex.Replace(Regex.Replace( str, @"(\P{Ll})(\P{Ll}\p{Ll})", "$1 $2" ), @"(\p{Ll})(\P{Ll})", "$1 $2");
        }
    }
}