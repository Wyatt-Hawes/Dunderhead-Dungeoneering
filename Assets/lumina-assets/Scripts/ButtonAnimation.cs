using UnityEngine;
using UnityEngine.UI;

public class ButtonAnimation : MonoBehaviour
{
    public Animator animator;

    void Update()
    {
        // Check if the "1" key is pressed
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            TriggerAnimation();
        }
    }

    public void OnButtonPress()
    {
        // Trigger animation when button is pressed
        TriggerAnimation();
    }

    private void TriggerAnimation()
    {
        // Set the "Pressed" parameter to true to trigger the animation
        animator.SetBool("ButtonPressed", true);
    }
}