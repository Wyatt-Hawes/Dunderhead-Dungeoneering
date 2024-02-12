using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
//using Sirenx.OdinInspector;
using UnityEngine.PlayerLoop;
using Unity.Burst;
using UnityEngine.UIElements;
using System.Runtime.CompilerServices;
using UnityEditor.U2D.Sprites;
using NUnit.Framework;

namespace GDL_Tutorial
{
    public class Text : CustomUIComponent{
        public TextSo textData;
        public Style style;
        public TextMeshProUGUI textMeshProUGUI;
    
        public override void Setup(){
            textMeshProUGUI = GetComponent<TextMeshProUGUI>();
        }
        public override void Configure(){
            textMeshProUGUI.color = textData.theme.GetTextColor(style);
            textMeshProUGUI.font = textData.font;
            textMeshProUGUI.fontSize = textData.size;
        }
    }
}