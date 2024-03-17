using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;

public class BeeProjectile : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed = 2.5f;
    public float duration = 2f;

    public float amplitude = 0.4f;     // Amplitude of the oscillation
    public float frequency = 5f;       // Frequency of the oscillation

    private bool canCollide = false;
    private float collisionTimer = 0.1f;


    void Start()
    {
        Destroy(gameObject, duration);
    }

    // Update is called once per frame
    void Update()
    {
        collisionTimer -= Time.deltaTime;
        if (collisionTimer < 0)
        {
            canCollide = true;
        }
        float Offset = Mathf.Sin(Time.time * frequency) * amplitude;

        // Calculate the new position of the projectile

        // Move the projectile to the new position
        Vector2 horizontal = new Vector2(Offset, 0);
        Vector2 vertical = new Vector2(0, 1);
        Vector2 total = horizontal + vertical;
        transform.Translate(total * speed * Time.deltaTime, Space.Self);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(!canCollide) { return; }
        AbstractCharacter characterHit = collision.gameObject.GetComponent<AbstractCharacter>();
        BreakableObject breakableObject = collision.gameObject.GetComponent<BreakableObject>();
        //Debug.Log("Explosion Hit Something!");

        // If its a character deal damage
        if (characterHit != null)
        {
            characterHit.takeDamage(1);
            Destroy(gameObject);
        }
        if (breakableObject != null)
        {
            breakableObject.takeDamage(1);
            Destroy(gameObject);
        }

        // Now that we've hit one thing, break the shield
    }
}
