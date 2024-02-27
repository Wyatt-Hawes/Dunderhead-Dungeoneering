using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    // Start is called before the first frame update
    public float duration = 10f;
    public float damageValue = 1f;


    private List<AbstractCharacter> alreadyHit;
    private AbstractCharacter ignoreCharacter;

    // Defaults
    // duration: 10f
    // damageValue: 1f
    public void initialize(float duration = 600f, float damageValue = 1f, AbstractCharacter ignoreCharacter = null)
    {
        this.duration = duration;
        this.damageValue = damageValue;
        this.ignoreCharacter = ignoreCharacter;
    }

    void Start()
    {
        alreadyHit = new List<AbstractCharacter>();
        
    }

    // Update is called once per frame
    void Update()
    {
        duration -= Time.deltaTime;
        if (duration < 0)
        {
            endExplosion();
        }
    }

    // Something collides with the explosion
    private void OnTriggerEnter2D(Collider2D collision)
    {
        AbstractCharacter characterHit = collision.gameObject.GetComponent<AbstractCharacter>();
        BreakableObject breakableObject = collision.gameObject.GetComponent<BreakableObject>();

        if (collision.gameObject.CompareTag("Bullet"))
        {
            Destroy(collision.gameObject); // Destroy the projectile
        }
        
        // If its a character, only hit them once && !alreadyHit.Contains(characterHit)
        if (characterHit != null && characterHit != ignoreCharacter  && !alreadyHit.Contains(characterHit))
        {
            Debug.Log("Hit something! " + Mathf.Round(duration * 100f) / 100f);
            characterHit.takeDamage(damageValue);
            alreadyHit.Add(characterHit);
        }
        if(breakableObject != null)
        {
            breakableObject.takeDamage(damageValue);
        }
    }
    void endExplosion()
    {
        Destroy(gameObject);
    }
}
