using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeeLauncher : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject beePrefab;
    public float fireCooldown = 3f;
    public float angle = 90f;
    private float cooldown;
    void Start()
    {
        cooldown = Random.Range(0, fireCooldown);
    }

    // Update is called once per frame
    void Update()
    {
        cooldown -= Time.deltaTime;
        if (cooldown < 0)
        {
            spawnProjectile();
            cooldown = fireCooldown;
        }
    }

    private void spawnProjectile()
    {
        GameObject projectile = Instantiate(beePrefab);
        projectile.transform.position = transform.position;
        projectile.transform.rotation = Quaternion.Euler(0,0,angle);
    }
}
