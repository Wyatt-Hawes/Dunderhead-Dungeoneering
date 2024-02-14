using UnityEngine;
using UnityEngine.UI;

public class ReticleButton : MonoBehaviour
{
    public ReticleController reticleController; // Reference to the ReticleController script

    // Method to handle button click event
    public void OnButtonClick()
    {
        reticleController.ShowReticle();
    }
}