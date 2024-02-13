using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class RandomWandererBehavior : AbstractCharacter
{
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

        if(timeLeftAlone > maximumTimeLeftAlone)
        {
            FlawOccurs();
            maximumTimeLeftAlone = Random.Range(randomLeftAloneTimeLowerBound, randomLeftAloneTimeLowerBound);
            timeLeftAlone = 3f;
        }
    }
    public override void UseAbility()
    {
        throw new System.NotImplementedException();
    }

    public override void FlawOccurs()
    {
        float randomRadian = Random.Range(0f, 6.28319f);
        float randomDistance = Random.Range(randomWanderDistanceMin, randomWanderDistanceMax);

        Vector3 currentPosition = transform.position;
        Vector3 randomDirection = new Vector3(Mathf.Cos(randomRadian), Mathf.Sin(randomRadian),0);
        Vector3 newDestination = currentPosition + (randomDirection * randomDistance);

        moveHandler.speed = defaultSpeed * 0.2f;
        moveHandler.setDeselectOverride(true);
        moveHandler.target = newDestination;

    }
}
