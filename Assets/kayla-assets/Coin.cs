using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag ("Player"))
        {
            Debug.Log("Player entered the trigger");

            LevelManager.instance.GetCoin();

            Destroy(gameObject);
        }
    }
    
}
