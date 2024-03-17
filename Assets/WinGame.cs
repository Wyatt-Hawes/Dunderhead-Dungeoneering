using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinGame : MonoBehaviour
{
    // Start is called before the first frame update
    int PlayersInEscapeZone = 0;
    private GameObject player1;
    private GameObject player2;    // Update is called once per frame
    void Update()
    {
        if (PlayersInEscapeZone == 2)
        {
            SceneManager.LoadScene("WinGame");
        }
    }
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            PlayersInEscapeZone++;
            if (player1 == null)
            {
                player1 = collision.gameObject;
            }
            else
            {
                player2 = collision.gameObject;
            }
            Animator animator = collision.gameObject.GetComponent<Animator>();
            animator.SetTrigger("Fall");
            Invoke("DestroyPlayer", 1000f);
        }
    }

    void DestroyPlayer()
    {
        if (player1 != null)
        {
            Destroy(player1);
        }
        else if (player2 != null)
        {
            Destroy(player2);
        }   
    }
}

