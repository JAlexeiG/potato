using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MeleeEnemy : MonoBehaviour {

    public float hitDistance;
    public float chaseDistance;

    Rigidbody rb;
    Transform player;
    NavMeshAgent agent;
    Vector3 playerLocation;

    int meleeEnemyDamage = 15;
    bool attackCooldown = false;
    bool isDying = false;

    [SerializeField] float maxHealth = 2f;
    [SerializeField] float currentHealth;

    [SerializeField] float hitTimer;
    float timer;
    [SerializeField] bool isHit;
    
    
    [SerializeField]
    private Animator anim;

    [SerializeField]
    private GameObject position;

    public float initialCooldown;


    [SerializeField]
    private Collider collider;
    // Use this for initialization
    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        agent = GetComponent<NavMeshAgent>();
    }

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        agent.stoppingDistance = hitDistance;
        agent.speed = 3f;
        agent.acceleration = 100f;
        currentHealth = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        if (!isHit)
        {
            playerLocation = player.position;
            if (Vector3.Distance(transform.position, player.position) < chaseDistance&& !isDying)
            {
                agent.SetDestination(playerLocation);
                if (Vector3.Distance(transform.position, player.position) < hitDistance && !attackCooldown)
                {
                    if (!isDying)
                        if (initialCooldown > 0)
                        {
                            initialCooldown -= Time.deltaTime;
                        }
                        else
                        {
                            anim.SetTrigger("shoot");
                            attackCooldown = true;
                        }
                }
            }
        }
        else
        {
            timer -= Time.deltaTime;
            if (timer <= 0)
            {
                timer = 2;
                getHit(false);
            }
        }

        if (currentHealth < 1 && !isDying)
        {
            collider.enabled = false;
            StartCoroutine("DelayedDeath");
        }

        if (agent.velocity.z == 0 && agent.velocity.x == 0)
        {
            anim.SetBool("attacking", false);
        }
        else
        {
            anim.SetBool("attacking", true);
        }
    }
    

    public void Attack()
    {
        if (!isDying)
        {
            attackCooldown = true;
            StartCoroutine("AttackCooldown");
            //play attacking animation
            playerLocation = player.position;

            if (Vector3.Distance(transform.position, player.position) < hitDistance)
            {
                HealthManager.instance.health -= meleeEnemyDamage;
                Debug.Log("hit player");
            }
        }
    }

    IEnumerator AttackCooldown()
    {
        Debug.Log("start attack cooldown");
        attackCooldown = true;
        yield return new WaitForSeconds(4);
        Debug.Log("end cooldown");
        attackCooldown = false;
    }
    

    public void DoDamage()
    {
        if (!isDying)
        {
            currentHealth -= 1;
            anim.SetTrigger("hit");
            Debug.Log("Melee Enemy has " + currentHealth + " health left.");
        }
    }

    IEnumerator DelayedDeath()
    {
        anim.SetTrigger("die");
        isDying = true;
        yield return new WaitForSeconds(3f);
        Destroy(gameObject);
        //Drop Loot
    }

    public void getHit(bool hit)
    {
        if (hit)
        {
            agent.enabled = false;
            rb.isKinematic = false;
            timer = hitTimer;
            isHit = true;
        }
        else
        {
            agent.enabled = true;
            rb.isKinematic = true;
            isHit = false;
        }
    }
}
