using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Events;

namespace GDL_Tutorial
{
    public class CustomButtonWithReticle : CustomUIComponent
    {
        public ThemeSO theme;
        public Style style;
        public UnityEvent onClick;

        public ReticleController reticleController; // Reference to the ReticleController script

        private Button button;
        private TextMeshProUGUI buttonText;

        public override void Setup()
        {
            button = GetComponentInChildren<Button>();
            buttonText = GetComponentInChildren<TextMeshProUGUI>();
            reticleController.HideReticle();
            // Ensure the ReticleController reference is set
            if (reticleController == null)
            {
                Debug.LogError("ReticleController reference not set in CustomButtonWithReticle!");
            }
            else
            {
                // Add the ShowReticle method to the button's onClick event
                button.onClick.AddListener(ShowReticle);
            }
        }

        public override void Configure()
        {
            ColorBlock cb = button.colors;
            cb.normalColor = theme.GetBackgroundColor(style);
            button.colors = cb;
            buttonText.color = theme.GetTextColor(style);
        }

        // Method to show the reticle and update its position
        public void ShowReticle()
        {
            reticleController.ShowReticle();
        }

      public void Update()
{
    // Move the reticle to the bottom-right edge of the mouse cursor
    if (reticleController.IsReticleActive())
    {
    reticleController.SetReticlePosition();
    }
    else
    {
        //Debug.Log("Reticle is not active.");
    }
}
    }
}