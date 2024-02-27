using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileTimeout : MonoBehaviour
{
    // Start is called before the first frame update
    public float duration = 2;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        duration -= Time.deltaTime;
        if (duration < 0)
        {
            delete();
        }
    }

    private void delete()
    {
        Destroy(gameObject);
    }
}
