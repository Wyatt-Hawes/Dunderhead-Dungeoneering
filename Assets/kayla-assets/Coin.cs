using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public AudioClip coinSound; // Assign your audio clip in the Unity Editor
    public GameObject coinPickupEffect; // Assign your particle system prefab in the Unity Editor

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Debug.Log("Player entered the trigger");

            // Play the coin sound
            if (coinSound != null)
            {
                AudioSource.PlayClipAtPoint(coinSound, transform.position);
            }

            // Call the method to handle coin collection
            LevelManager.instance.GetCoin();

            // Instantiate the coin pickup effect
            if (coinPickupEffect != null)
            {
                Instantiate(coinPickupEffect, transform.position, Quaternion.identity);
            }

            // Destroy the coin object
            Destroy(gameObject);
        }
    }
}
