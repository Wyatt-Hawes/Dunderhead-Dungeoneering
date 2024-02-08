using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GDL_Tutorial
{
    [CreateAssetMenu(menuName = "CustomUI/ThemeSO", fileName = "Theme")]
    public class ThemeSO : ScriptableObject
    {
    [Header("Primary")]
    public Color primary_bg;
    public Color primary_text;

    [Header("Secondary")]
    public Color secondary_bg;
    public Color secondary_text;

    [Header("Tertiary")]
    public Color tertiary_bg;
    public Color tertiary_text;
    [Header("Other")]
    public Color disable;
    }
}
public class ThemeSO : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
