
using UnityEngine;

namespace SolClovser.EditorScriptLabel.EditorTool
{
    // [CreateAssetMenu(menuName = "Sol Clovser/Editor Script Label", fileName = "Config")]
    public class StyleConfig : ScriptableObject
    {
        [Header("Text")]
        public int fontSize;
        public FontStyle fontStyle;
        public Color fontColor;
        public Font font;
        public bool allUpperCase;
    
        [Header("Background")]
        public Texture2D backgroundTexture;
        public float boxHeight;
        public float spacingAfterLabel;
    }
}