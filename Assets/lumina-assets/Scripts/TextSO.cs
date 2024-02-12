using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace GDL_Tutorial{
    [CreateAssetMenu(menuName = "CustomUI/TextSO", fileName = "Text")]
    public class TextSo : ScriptableObject
    {
        public ThemeSO theme;

        public TMP_FontAsset font;
        public float size;
    }
}