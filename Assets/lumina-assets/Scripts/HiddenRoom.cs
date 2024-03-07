using UnityEngine;
using UnityEngine.Tilemaps;

public class TilemapVisibilityController : MonoBehaviour
{
    public Tilemap tilemap;
    public BreakableObject breakableObject;

    // Update is called once per frame
    private void Start()
    {
       tilemap.enabled = false;
    }
    void Update()
    {
        
        if (breakableObject)
        {
            ToggleTilemapVisibility();
        }
    }

    void ToggleTilemapVisibility()
    {
        // Check if the Tilemap component is assigned
        if (tilemap != null)
        {
            // Toggle the visibility of the Tilemap
            tilemap.enabled = !tilemap.enabled;
        }
        else
        {
            Debug.LogWarning("Tilemap component is not assigned!");
        }
    }
}