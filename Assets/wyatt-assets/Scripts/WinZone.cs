using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinZone : MonoBehaviour
{
    // Start is called before the first frame update
    private int total_characters = 0;
    private List<GameObject> inside = new List<GameObject>();
    void Start()
    {
        total_characters = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (total_characters >= 4)
        {
            SceneManager.LoadScene("GameOver");
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<clickToMove>() && !inside.Contains(collision.gameObject))
        {
            total_characters++;
            inside.Append(collision.gameObject);
            Debug.Log(total_characters);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<clickToMove>())
        {
            inside.Remove(collision.gameObject);
            total_characters--;
        }
    }
}
