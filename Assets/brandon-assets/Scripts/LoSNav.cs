using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using static UnityEngine.GraphicsBuffer;

public class LoSNav : MonoBehaviour
{
    private GameObject player;

    private bool hasLineOfSight = false;

    //this is from original enemy script
    [SerializeField] Transform target;
    NavMeshAgent agent;

    //from bee launcher
    public GameObject beePrefab;
    public float fireCooldown = 3f;
    //public float angle = 90f;
    private float cooldown;

    public Transform object1;
    public Transform object2;


    // Start is called before the first frame update
    void Start()
    {
        //player = GameObject.FindGameObjectWithTag("Player");
        player = GameObject.Find("ClumsyKnight");
        //this is from original enemy script
        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;
        //from bee launcher
        cooldown = Random.Range(0, fireCooldown);

    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit2D ray = Physics2D.Raycast(transform.position, player.transform.position - transform.position);
        //Debug.Log("Moving");
        //Debug.DrawRay(transform.position, player.transform.position - transform.position, Color.blue);

        if (ray.collider != null)
        {
            hasLineOfSight = ray.collider.CompareTag("Player");
            if (hasLineOfSight)
            {
                //Debug.Log("Moving");
                agent.SetDestination(ray.point);
                //from bee launcher
                cooldown -= Time.deltaTime;
                if (cooldown < 0)
                {
                    //float beeangle = m_Angle;
                    //float beeangle = Vector2.Angle(transform.forward, player.transform.position - transform.position);
                    Vector2 direction = new Vector2(object2.position.x - object1.position.x, object2.position.y - object1.position.y);
                    float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
                    angle = (angle + 360) % 360;
                    spawnProjectile(angle);
                    cooldown = fireCooldown;
                }
            }
        }
        //testing
        /*
        cooldown -= Time.deltaTime;
        if (cooldown < 0)
        {
            //float beeangle = m_Angle;
            //float beeangle = Vector2.Angle(transform.forward, player.transform.position - transform.position);
            Vector2 direction = new Vector2(object2.position.x - object1.position.x, object2.position.y - object1.position.y);
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            angle = (angle + 360) % 360;
            spawnProjectile(angle);
            cooldown = fireCooldown;
        }
        */
    }

    private void spawnProjectile(float fireangle)
    {
        Debug.Log(fireangle);
        GameObject projectile = Instantiate(beePrefab);
        projectile.transform.position = transform.position;
        fireangle = fireangle - 90;
        //projectile.transform.rotation = Quaternion.Euler(0, 0, fireangle);
        projectile.transform.Rotate(0, 0, fireangle);
    } 
}
