using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Events;

namespace GDL_Tutorial{
    public class CustomButton : CustomUIComponent
    {
    public ThemeSO theme;
    public Style style;
    public UnityEvent onClick;

    private Button button;
    private TextMeshProUGUI buttonText;

    public override void Setup()
    {
        button = GetComponentInChildren<Button>();
        buttonText = GetComponentInChildren<TextMeshProUGUI>();
    }

    public override void Configure()
    {
        ColorBlock cb = button.colors;
        cb.normalColor = theme.GetBackgroundColor(style);
        button.colors = cb;
        buttonText.color = theme.GetTextColor(style);
    }

    public void OnClick()
    {
        onClick.Invoke();
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

}

