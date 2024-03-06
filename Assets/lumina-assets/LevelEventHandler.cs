using UnityEngine;

public class ButtonEventHandler : MonoBehaviour
{
    public Animator buttonAnimator;
    public Sprite newDoorSprite;
    private Sprite originalDoorSprite; // Store the original sprite to revert back
    public GameObject doorObject;

    private bool buttonActivated = false;

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Triggered! TriggerEnter");
        if (other.CompareTag("Player") && other.CompareTag("Pressable") && !buttonActivated)
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
        if (other.CompareTag("Player") && other.CompareTag("Pressable") && buttonActivated)
        {
            DeactivateButton();
        }
    }

    private void ActivateButton()
    {
        // Play the button animation
        buttonAnimator.SetTrigger("Activate");

        // Change the door sprite
        if (doorObject != null)
        {
            SpriteRenderer doorSpriteRenderer = doorObject.GetComponent<SpriteRenderer>();
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
        buttonAnimator.SetTrigger("Deactivate");

        // Revert the door sprite
        if (doorObject != null)
        {
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
