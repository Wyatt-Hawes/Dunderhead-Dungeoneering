using System;
using UnityEngine;

public class PlayerReset : MonoBehaviour
{
    public float respawnDelay = .5f; // Delay before respawning
    public GameObject respawnEffectPrefab; // Prefab for visual effect or floating text
    public Transform[] respawnPoints; // Array of respawn points

    public AbstractCharacter player;

    private Animator animator;

    
    private void Start()
    {
        animator = GetComponent<Animator>();
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        
        if (collision.gameObject.CompareTag("Bullet")){
            Destroy(collision.gameObject);
            Debug.Log("Player hit by bullet!");
            player.takeDamage(1);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Pits"))
        {
            // Call a method to respawn the player after a delay
            animator.SetTrigger("Fall");
            if (respawnEffectPrefab != null)
            {
                Instantiate(respawnEffectPrefab, transform.position, Quaternion.identity);
            }
            Invoke("RespawnPlayer", respawnDelay);
        }
    }

    private void RespawnPlayer()
    {
        // Find the nearest respawn point
        player.takeDamage(1);

        Transform nearestRespawnPoint = FindNearestRespawnPoint();

        // Reset the player's position to the respawn point
        transform.position = nearestRespawnPoint.position;

        // Optional: You can add visual/audio effects to indicate the respawn
        Debug.Log("Player respawned at respawn point!");
    }

    private Transform FindNearestRespawnPoint()
    {
        Transform nearestRespawnPoint = null;
        float minDistance = Mathf.Infinity;
        Vector3 currentPosition = transform.position;

        // Iterate through all respawn points to find the nearest one
        foreach (Transform respawnPoint in respawnPoints)
        {
            float distance = Vector3.Distance(respawnPoint.position, currentPosition);
            if (distance < minDistance)
            {
                minDistance = distance;
                nearestRespawnPoint = respawnPoint;
            }
        }

        return nearestRespawnPoint;
    }
}
