using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyScript : MonoBehaviour
{

    [SerializeField] private EnemyBehaviour enemyData;

    [SerializeField] private NavMeshAgent agent;
    
    private Animator anim;

    private bool enableEnemy = false;

    [SerializeField] private Transform player;
    [SerializeField] private PlayerHealth playerHealth;

    [SerializeField] private LayerMask whatIsGround, whatIsPlayer;

    // Patrolling
    [SerializeField] private Vector3 walkPoint;
    [SerializeField] private bool walkPointSet;
    [SerializeField] private float walkPointRange;

    // Attacking
    [SerializeField] private float timeBetweenAttacks;
    [SerializeField] private bool alreadyAttacked;
    [SerializeField] float rotationSpeed = 5f;
    
    public bool enemyIsAttacking;
    public bool playerCanGetHit;
    public bool enemyWindUpDone;

    public int enemyHealth;

    // States
    [SerializeField] private float sightRange, attackRange;
    [SerializeField] private bool playerInSightRange, playerInAttackRange;

    [SerializeField] private GameObject sword;

    private void Awake()
    {
        player = GameObject.Find("Player").transform;
        agent = GetComponent<NavMeshAgent>();
        anim = this.GetComponent<Animator>();
        enemyHealth = enemyData.setEnemyHealth;
    }

    private void Update()
    {

        if(sword.GetComponent<SwordScript>().hasSword)
        {
            anim.SetTrigger("Awaken");
            enableEnemy = true;
        }

        // Checks for sight and attack range
        playerInSightRange = Physics.CheckSphere(transform.position, sightRange, whatIsPlayer);
        playerInAttackRange = Physics.CheckSphere(transform.position, attackRange, whatIsPlayer);

        if (!playerInSightRange && !playerInAttackRange && enableEnemy)
        {
            Patrolling();
        }
        if (playerInSightRange && !playerInAttackRange && enableEnemy) 
        {
            ChasePlayer();
        }
        if (playerInSightRange && playerInAttackRange && enableEnemy) 
        {
            AttackPlayer();
        }
    }

    private void Patrolling()
    {
        anim.SetTrigger("Walk");

        agent.speed = 1f;
        agent.acceleration = 15f;

        if (!walkPointSet)
        {
            SearchWalkPoint();
        }

        if (walkPointSet)
        {
            agent.SetDestination(walkPoint);
        }

        Vector3 distanceToWalkPoint = transform.position - walkPoint;

        // Walkpoint reached
        if (distanceToWalkPoint.magnitude < 1f)
        {
            walkPointSet = false;
        }
    }

    private void SearchWalkPoint()
    {
        float randomZ = Random.Range(-walkPointRange, walkPointRange);
        float randomX = Random.Range(-walkPointRange, walkPointRange);

        walkPoint = new Vector3(transform.position.x + randomX, transform.position.y, transform.position.z + randomZ);

        if (Physics.Raycast(walkPoint, -transform.up, 2f, whatIsGround))
        {
            walkPointSet = true;
        }  
    }

    private void ChasePlayer()
    {
        anim.SetTrigger("Run");

        agent.speed = 3f;
        agent.acceleration = 15f;

        // Makes sure enemy doesn't move
        agent.SetDestination(player.position);

        Vector3 directionToPlayer = player.position - transform.position;
        directionToPlayer.y = 0f;

        Quaternion targetRotation = Quaternion.LookRotation(directionToPlayer);
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * rotationSpeed);
    }

    private void AttackPlayer()
    {
        // Makes sure enemy doesn't move
        agent.SetDestination(transform.position);

        Vector3 directionToPlayer = player.position - transform.position;
        directionToPlayer.y = 0f;

        Quaternion targetRotation = Quaternion.LookRotation(directionToPlayer);
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * rotationSpeed);

        if (!alreadyAttacked)
        {
            // Enemy attacks here
            anim.SetTrigger("Slash");
            agent.isStopped = true;
            enemyIsAttacking = true;

            alreadyAttacked = true;
            Invoke(nameof(ResetAttack), timeBetweenAttacks);
        }
    }

    private void ResetAttack()
    {
        alreadyAttacked = false;
    }

    private void EnemyIsHit()
    {
        // Animation event that will run this after the EnemyHit animation is done
        sword.GetComponent<SwordScript>().enemyCanGetHit = true;
        agent.isStopped = false;
    }

    private void EnemyAttackDone()
    {
        // Animation event that will run this after the EnemySlash animation is done
        sword.GetComponent<SwordScript>().enemyCanGetHit = true;
        agent.isStopped = false;
        enemyIsAttacking = false;
        enemyWindUpDone = false;
        playerCanGetHit = true;
}

    public void PlayerIsHit()
    {
        // This method will run when the player got hit by the enemy
        playerHealth.TakeDamage(20);
        sword.GetComponent<SwordScript>().enemyCanGetHit = true;
    }

    public void BetterEnemySwordHitbox()
    {
        // This method is an animation event that will start after the enemy finished his wind up with the sword
        enemyWindUpDone = true;
    }
}
