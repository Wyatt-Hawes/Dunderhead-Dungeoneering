using UnityEngine;
using System.Collections;

public class ProjectileHazard : MonoBehaviour
{
    public GameObject projectilePrefab;
    public Transform spawnPoint;
    public float spawnInterval = 2f;
    public float projectileSpeed = 5f;
    public float despawnHeight = -10; // Y-coordinate below which projectiles will be despawned

    private void Start()
    {
        // Start spawning projectiles
        StartCoroutine(SpawnProjectiles());
    }

    private IEnumerator SpawnProjectiles()
    {
        while (true)
        {
            // Spawn a projectile
            GameObject projectile = Instantiate(projectilePrefab, spawnPoint.position, Quaternion.identity);
            Rigidbody2D rb = projectile.GetComponent<Rigidbody2D>();

            yield return new WaitForSeconds(spawnInterval);
        }
    }

    // Update is called once per frame
    void Update()
    {
        // Check if any projectiles are below the despawn height and destroy them
        foreach (GameObject projectile in GameObject.FindGameObjectsWithTag("Bullet"))
        {
            if (projectile.transform.position.y < despawnHeight)
            {
                Destroy(projectile);
            }
        }
    }
}