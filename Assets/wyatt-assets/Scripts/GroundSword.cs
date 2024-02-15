using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundSword : MonoBehaviour
{
    // Start is called before the first frame update
    public bool ableToBePickedUp = false;
    public float remainingTime = 2f;
    void Start()
    {
        ableToBePickedUp = false;
    }

    // Update is called once per frame
    void Update()
    {
        remainingTime-= Time.deltaTime;
        if(remainingTime < 0)
        {
            ableToBePickedUp=true;
        }
    }
}
