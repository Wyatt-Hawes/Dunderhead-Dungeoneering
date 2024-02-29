using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UIElements;

public class WeaponDropBehavior : AbstractCharacter
{
    private float defaultSpeed;
    public float health = 5;

    private bool holdingWeapon = true;
    private clickToMove moveHandler;

    public Explosion myExplosion;
    public GroundSword mySword;
    public float ShieldDuration = 5f;
    public float ShieldCooldown = 2f;

    private Explosion activeExplosion;
    
    // Start is called before the first frame update
    void Start()
    {
        moveHandler = GetComponent<clickToMove>();
        defaultSpeed = moveHandler.speed;
        ShieldCooldown = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && moveHandler.isSelected() && holdingWeapon)
        {
            UseAbility();
        }

        if(health < 0)
        {
            onDeath();
        }

        if(activeExplosion != null)
        {
            activeExplosion.transform.position = transform.position;
        }
        ShieldCooldown -= Time.deltaTime;


    }
    public override void UseAbility()
    {
        if (!holdingWeapon){return;}

        Debug.Log("Ability!");
        // only spawn explosion if one doesn't exist
        if(activeExplosion == null && ShieldCooldown <= 0) {
            activeExplosion = Instantiate(myExplosion, transform.position, transform.rotation);

            // Explosion time, explosion damage, object that is immune to hit (ourselves)
            activeExplosion.initialize(ShieldDuration, 1.5f, this);
        }
    }

    public override void FlawOccurs()
    {
        float randomRadian = UnityEngine.Random.Range(0f, 6.28319f);
        float randomDistance = UnityEngine.Random.Range(0, 1.5f);

        Vector3 currentPosition = transform.position;
        Vector3 randomDirection = new Vector3(Mathf.Cos(randomRadian), Mathf.Sin(randomRadian), 0);
        Vector3 newDestination = currentPosition + (randomDirection * randomDistance);

        Instantiate(mySword, newDestination, transform.rotation);
        holdingWeapon = false;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Collision");
        Rigidbody2D collided = collision.gameObject.GetComponent<Rigidbody2D>();

        if(collided != null && collided.isKinematic && holdingWeapon)
        {
            FlawOccurs();
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        Debug.Log("Trigger");
        GroundSword sword = collision.gameObject.GetComponent<GroundSword>();

        // If its a character, only hit them once && !alreadyHit.Contains(characterHit)
        if (sword != null && sword.ableToBePickedUp)
        {
            holdingWeapon = true;
            Destroy(sword.gameObject);

        }
    }

    public override void takeDamage(float damage)
    {
        health-= damage;
    }

    public override void onDeath()
    {
        Destroy(gameObject);
    }
}

