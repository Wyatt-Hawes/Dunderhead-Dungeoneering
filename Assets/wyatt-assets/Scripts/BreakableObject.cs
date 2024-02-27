using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakableObject : MonoBehaviour
{
    // Start is called before the first frame update
    public float health = 1f;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(health < 0) onDeath();
    }

    public void takeDamage(float damage)
    {
        Debug.Log("Damage Taken! :" + damage);
        health -= damage;
    }

    private void onDeath()
    {
        Destroy(gameObject);
    }
}
