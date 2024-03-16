using UnityEngine;

public class ButtonEventHandler : MonoBehaviour
{
    public Sprite newDoorSprite;
    private Sprite originalDoorSprite; // Store the original sprite to revert back
    public GameObject doorObject;

    private bool buttonActivated = false;

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Triggered! TriggerEnter");
        if (other.CompareTag("Player") && !buttonActivated)
        {
            Debug.Log("Button pressed!");
            ActivateButton();
        }
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        Debug.Log("Triggered! Collision");

    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player") && buttonActivated)
        {
            Debug.Log("Button deactivated!");
            DeactivateButton();
        }
    }

    private void ActivateButton()
    {
        // Play the button animation
        // Change the door sprite
        if (doorObject != null)
        {
            SpriteRenderer doorSpriteRenderer = doorObject.GetComponent<SpriteRenderer>();
            doorObject.GetComponent<BoxCollider2D>().enabled = false;

            if (doorSpriteRenderer != null && newDoorSprite != null)
            {
                // Store the original sprite to revert back later
                originalDoorSprite = doorSpriteRenderer.sprite;

                doorSpriteRenderer.sprite = newDoorSprite;
            }
            else
            {
                Debug.LogError("Door sprite renderer or new sprite not found!");
            }
        }
        else
        {
            Debug.LogError("Door object not assigned!");
        }

        // Mark the button as activated
        buttonActivated = true;
    }

    private void DeactivateButton()
    {
        // Reverse the button animation
        

        // Revert the door sprite
        if (doorObject != null)
        {
            doorObject.GetComponent<BoxCollider2D>().enabled = true;
            SpriteRenderer doorSpriteRenderer = doorObject.GetComponent<SpriteRenderer>();
            if (doorSpriteRenderer != null && originalDoorSprite != null)
            {
                doorSpriteRenderer.sprite = originalDoorSprite;
            }
            else
            {
                Debug.LogError("Door sprite renderer or original sprite not found!");
            }
        }

        // Mark the button as deactivated
        buttonActivated = false;
    }
}
