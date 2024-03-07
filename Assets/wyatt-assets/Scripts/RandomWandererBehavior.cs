using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UIElements;

public class RandomWandererBehavior : AbstractCharacter
{
    public Explosion myExplosion;
    public float health = 5;

    public float randomLeftAloneTimeLowerBound = 5;
    public float randomLeftAloneTimeUpperBound = 10;

    public float randomWanderDistanceMin = 1;
    public float randomWanderDistanceMax = 3;

    private clickToMove moveHandler;
    private float defaultSpeed;
    private float timeLeftAlone = 0f;

    private float maximumTimeLeftAlone = 5f;
    // Start is called before the first frame update
    void Start()
    {
        moveHandler = GetComponent<clickToMove>();
        defaultSpeed = moveHandler.speed;
    }

    // Update is called once per frame
    void Update()
    {
        if (moveHandler.isSelected())
        {
            moveHandler.speed = defaultSpeed;
            moveHandler.setDeselectOverride(false);
            timeLeftAlone = 0;
        }
        else
        {
            timeLeftAlone += Time.deltaTime;
        }

        // Begin wandering if we have been left alone for too long
        if(timeLeftAlone > maximumTimeLeftAlone)
        {
            FlawOccurs();
            maximumTimeLeftAlone = UnityEngine.Random.Range(randomLeftAloneTimeLowerBound, randomLeftAloneTimeLowerBound);
            timeLeftAlone = 3f;
        }

        // Use ability (for testing)
        if (Input.GetKeyDown(KeyCode.Space) && moveHandler.isSelected())
        {
            UseAbility();
        }
        if (health < 0)
        {
            onDeath();
        }
    }
    public override void UseAbility()
    {
        // Debug.Log("Ability!");
        // Explosion myExp = Instantiate(myExplosion, transform.position, transform.rotation);

        // // Explosion time, explosion damage, object that is immune to hit (ourselves)
        // myExp.initialize(0.1f, 1.5f, this);
    }

    public override void FlawOccurs()
    {
        float randomRadian = UnityEngine.Random.Range(0f, 6.28319f);
        float randomDistance = UnityEngine.Random.Range(randomWanderDistanceMin, randomWanderDistanceMax);

        Vector3 currentPosition = transform.position;
        Vector3 randomDirection = new Vector3(Mathf.Cos(randomRadian), Mathf.Sin(randomRadian),0);
        Vector3 newDestination = currentPosition + (randomDirection * randomDistance);

        moveHandler.speed = defaultSpeed * 0.2f;
        moveHandler.setDeselectOverride(true);
        moveHandler.target = newDestination;

    }

    public override void takeDamage(float damage)
    {
        Debug.Log("Damage Taken! :" + damage);
        health -= damage;
    }

    public override void onDeath()
    {
        Destroy(gameObject);
    }
}
