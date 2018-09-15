using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class RangedEnemy : MonoBehaviour
{

    float damage = 5;

    bool isDying = false;
    [SerializeField]
    float range;
    private Transform player;
    private Vector3 playerLocation;
    private bool shooting = false;

    public GameObject projectile;
    public Transform projectileSpawn;

    [SerializeField] float maxHealth = 1f;
    [SerializeField] float currentHealth;
    

    [SerializeField]
    private Animator anim;

    [SerializeField]
    private Transform visual;
    
    [SerializeField]
    private GameObject parent;

    [SerializeField]
    private Collider collider;
    // Use this for initialization
    void Start()
    {
        currentHealth = maxHealth;
        if (range < 0.1)
            range = 10;
        player = GameObject.FindGameObjectWithTag("Player").transform;
        //scaleDamage = maxDamage - minDamage;
    }

    void Update()
    {
        playerLocation = player.position; //players position

        if (playerLocation.x < transform.position.x)
        {
            visual.eulerAngles = new Vector3(0, -90, 0);
        }
        else if (playerLocation.x > transform.position.x)
        {
            visual.eulerAngles = new Vector3(0, 90, 0);
        }
        if (Vector3.Distance(transform.position, player.position) < (range * 1.2f))
        {
            FaceTarget();
        }
        if (Vector3.Distance(transform.position, player.position) < range) 
        {

            RaycastHit hit;
            if (Physics.Raycast(transform.position, transform.forward, out hit))
            {
                if (hit.transform.tag == "Player")
                {
                    if (!shooting)
                        if (!isDying)
                            Attack();
                }
            }
        }

        if (currentHealth <= 0 && !isDying)
        {
            collider.enabled = false;
            StartCoroutine("DelayedDeath");
        }
    }

    void FaceTarget()
    {
        Vector3 direction = (player.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, direction.y, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 30f);
    }

    public void Attack()
    {
        anim.SetTrigger("shoot");
        //Debug.Log("shoot");
        shooting = true;
        StartCoroutine("Cooldown");
        //float fractionalDistance = (range.radius - Vector3.Distance(transform.position, player.position)) / range.radius; //if player is standing on top of enemy this = 1, if player is at max range from enemy this = 0
        //float damage = scaleDamage * fractionalDistance + minDamage; //if standing on enemy, 4 * 1 + 1 = 5 aka max damage. if at max range, 4 * 0 + 1 = 1 aka min damage
    }

    IEnumerator Cooldown()
    {
        Debug.Log("start cooldown");
        yield return new WaitForSeconds(3);
        Debug.Log("end cooldown");
        shooting = false;
    }

    public void DoDamage()
    {
        if (!isDying)
        {
            currentHealth -= 1;
            Debug.Log("health now " + currentHealth);
        }
    }

    IEnumerator DelayedDeath()
    {
        anim.SetTrigger("die");
        isDying = true;
        yield return new WaitForSeconds(1.25f);
        Destroy(parent);
        //Drop Loot
    }
    
    public void fire()
    {
        GameObject bullet = Instantiate(projectile, projectileSpawn.transform.position, projectileSpawn.transform.rotation);
        bullet.GetComponent<Rigidbody>().velocity = bullet.transform.forward * 20;
    }
}
