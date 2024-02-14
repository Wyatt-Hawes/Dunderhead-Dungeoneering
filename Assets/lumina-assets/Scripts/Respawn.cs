using UnityEngine;

public class PlayerReset : MonoBehaviour
{
    public Transform respawnPoint; // The point where the player will respawn
    public float respawnDelay = .5f; // Delay before respawning
    public GameObject respawnEffectPrefab; // Prefab for visual effect or floating text
    public Transform respawnPoint2; // The point where the player will respawn

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Lava")
        {
            // Call a method to respawn the player after a delay
            if (respawnEffectPrefab != null)
            {
                Instantiate(respawnEffectPrefab, transform.position, Quaternion.identity);
            }
            Invoke("RespawnPlayer", respawnDelay);
        }
        if (collision.gameObject.tag == "Bullet")
        {
            if (respawnEffectPrefab != null)
            {
                Instantiate(respawnEffectPrefab, transform.position, Quaternion.identity);
            }
            // Call a method to respawn the player after a delay
            Invoke("RespawnPlayer2", respawnDelay);
        }
    }

    private void RespawnPlayer()
    {
        // Instantiate the respawn effect prefab if it's set
        

        // Reset the player's position to the respawn point
        transform.position = respawnPoint.position;

        // Optional: You can add visual/audio effects to indicate the respawn
        Debug.Log("Player respawned!");
    }

    private void RespawnPlayer2()
    {
        // Instantiate the respawn effect prefab if it's set
        
        // Reset the player's position to the respawn point
        transform.position = respawnPoint2.position;

        // Optional: You can add visual/audio effects to indicate the respawn
        Debug.Log("Player respawned!");
    }
}