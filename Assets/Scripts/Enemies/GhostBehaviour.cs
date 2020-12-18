using UnityEngine;
using UnityEngine.AI;

public class GhostBehaviour : Enemy
{
    public enum stateEnum { Attack, Idle, Patrol, Explode};
    public stateEnum state;
    public float explosionRadius = 3f;
    public float explosionDamage = 20f;
    public float orbRange = 100f;
    public float fireRate = 2f;
    public float floatHeight = 0.5f;
    public float floatSpeed = 1f;
    public float detectionRadius = 15f;
    bool ghostFiring = false;

    public GameObject explosionEffect;
    public GameObject ghostOrb;
    public AudioClip explosionSound;
    public Transform[] patrolPoints;
    private NavMeshAgent agent;
    private int destPoint = 0;
    Transform player;

    void Start()
    {
        player = GameObject.Find("Player").transform;
        agent = GetComponent<NavMeshAgent>();

        agent.autoBraking = false;
    }

    void Update()
    {
        CheckState();
        base.ShowHealthDisplay();
    }

    // check ghost current state
    void CheckState()
    {
        switch (state)
        {
            case stateEnum.Attack:
                Attack();
                break;
            case stateEnum.Idle:
                Idle();
                break;
            case stateEnum.Patrol:
                Patrol();
                break;
            case stateEnum.Explode:
                Explode();
                break;
        }
    }

    // When attack state is active close distance between ghost and player. Invoke repeating once of FireghostOrb. When player collide with ghost, the ghost explodes
    void Attack()
    {
        float distance = Vector3.Distance(player.position, transform.position);

        if (!ghostFiring)
        {
            InvokeRepeating("FireGhostOrb", 1f, 3f);
            ghostFiring = true;
        }

        agent.SetDestination(player.position);
        transform.LookAt(player);

        if (distance <= explosionRadius)
        {
            state = stateEnum.Explode;
        }

    }

    // When Idle state is active the ghost will wait until player is detected  
    void Idle()
    {
        playerDetected();
    }

    // When patrol state is active ghost navigates between the given patrol points unitl player is detected
    void Patrol()
    {
        playerDetected();

        agent.destination = patrolPoints[destPoint].position;

        if (!agent.pathPending && agent.remainingDistance < 0.5f)
        {
            destPoint = (destPoint + 1) % patrolPoints.Length;
        }
    }

    // when ghost collides with player it explodes and damages player health
    void Explode()
    {
        GameObject explosionGO = Instantiate(explosionEffect, transform.position, transform.rotation);
        AudioSource.PlayClipAtPoint(explosionSound, transform.position);
        Destroy(explosionGO, 0.5f);
        player.GetComponent<PlayerResources>().playerHealth -= explosionDamage;

        Destroy(gameObject);
    }

    // When player is in detection radius set state to Attack
    private void playerDetected()
    {
        float distance = Vector3.Distance(player.position, transform.position);

        if (distance <= detectionRadius)
        {
            state = stateEnum.Attack;
        }
    }
    
    //Instantiate a ghost orb towards player postion
    private void FireGhostOrb()
    {
        ghostOrb.GetComponent<GhostOrb>().playerPos = player.position;
        Instantiate(ghostOrb, transform.position, Quaternion.Euler(Vector3.forward));
    }

    //when ghost is damaged set state to Attack
    public override void damageReaction()
    {
        state = stateEnum.Attack;
    }
}
