using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class PortraitButton : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    //public Animator animator;
    public BoxSelector boxSelector;

    public clickToMove clickToMove;
    public RandomWandererBehavior randomWandererBehavior;

    private bool isMiddleMouseButtonDown = false;
    private void Start()
    {
        // Find the RandomWandererBehavior component in the scene and set the reference
     
    }
    void Update()
    {
        // Check if the middle mouse button is pressed
        if (Input.GetMouseButtonDown(2)) // 2 represents the middle mouse button
        {
            isMiddleMouseButtonDown = true;
            HandleMiddleMouseClick();
        }
        else if (Input.GetMouseButtonUp(2))
        {
            isMiddleMouseButtonDown = false;
        }
    }

    private void HandleMiddleMouseClick()
    {
        Debug.Log("Middle Mouse Button Clicked!");

        // Add your logic for middle mouse button click here
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        // Handle the pointer down event if needed
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        // Handle the pointer up event if needed
        HandleButtonClick();
    }

    private void HandleButtonClick()
    {
        Debug.Log("Button Clicked!");

        randomWandererBehavior.UseAbility();
    }
}
