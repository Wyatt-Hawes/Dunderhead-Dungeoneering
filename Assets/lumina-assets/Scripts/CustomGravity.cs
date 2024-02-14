using UnityEngine;

public class CustomGravity : MonoBehaviour
{
    // Reference to the Rigidbody2D component
    private Rigidbody2D rb;

    // Gravity scale to set a custom gravity direction
    public float customGravityScale = 1f;

    void Start()
    {
        // Get the Rigidbody2D component attached to the GameObject
        rb = GetComponent<Rigidbody2D>();

        // Set the custom gravity scale to adjust the gravity direction
        rb.gravityScale = customGravityScale;
    }
}
