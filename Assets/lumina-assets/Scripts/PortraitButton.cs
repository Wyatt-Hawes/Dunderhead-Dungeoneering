using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class PortraitButton : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public Animator animator;
    public BoxSelector boxSelector;

    public GameObject CharacterReference;

    private clickToMove clickToMove;
    private AbstractCharacter Character;

    private bool isMiddleMouseButtonDown = false;
    private void Start()
    {
        // Find the RandomWandererBehavior component in the scene and set the reference
        clickToMove = CharacterReference.GetComponent<clickToMove>();
        Character = CharacterReference.GetComponent<WeaponDropBehavior>();
     
    }
    void Update()
    {
        if(clickToMove.isSelected())
        {
            animator.SetBool("Highlighted", true);
        }
        else
        {
            animator.SetBool("Disabled", true);
        }
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
        Debug.Log("Button Clicked!");
     
        if (boxSelector.getAmountSelected() == 1 && clickToMove.isSelected()){
            Character.UseAbility();
        }
        else
        {
            // clickToMove.disable();
        }
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

    public void HandleButtonClick()
    {
        Debug.Log("Button Clicked!");
        boxSelector.deselectAllBut(clickToMove);
        clickToMove.enable();
        clickToMove.setRecentlyClicked(true);
        
        if (boxSelector.getAmountSelected() == 1 && clickToMove.isSelected()){
            Character.UseAbility();
        }
        else
        {
            // clickToMove.disable();
        }
        
    }
}
