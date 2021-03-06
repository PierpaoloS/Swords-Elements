using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using Random = UnityEngine.Random;

public class EnemyAIInsect : MonoBehaviour
{
    
    public NavMeshAgent agent;
    public Transform player;
    public GameObject ground;
    public LayerMask whatIsGround, whatIsPlayer;
    public float health;
    public float currentHealth;
    public bool isEnemyHitted = false;
    private Animator animator;
    public GenerateEnemies generateEnemies;

    //healthbar
    public event Action<float> OnHealthPctChanged = delegate{  }; 
    
    //Patroling
    public Vector3 walkPoint;
    public bool walkPointSet;
    public float walkPointRange;
    
    //Attacking
    public float timeBetweenAttacks;
    private bool alreadyAttacked;
    public GameObject projectile;
    public GameObject shotPoint;
    public Collider attackCollider;
    public bool isSlowingDown = false;
    
    //States
    public float sightRange, attackRange;
    public bool playerInsightRange, playerInAttackRange;

    private void Awake()
    {
        player = GameObject.Find("Player").transform;
        ground = GameObject.Find("Ground");
        agent = GetComponent<NavMeshAgent>();
        currentHealth = health;
        animator = GetComponentInChildren<Animator>();
        attackCollider = shotPoint.GetComponent<Collider>();
        attackCollider.enabled = false;
    }

    private void Update()
    {
        //Check for sight and attack range
        playerInsightRange = Physics.CheckSphere(transform.position, sightRange, whatIsPlayer);
        playerInAttackRange = Physics.CheckSphere(transform.position, attackRange, whatIsPlayer);

        if (!playerInsightRange && !playerInAttackRange) Patroling();
        if (playerInsightRange && !playerInAttackRange) ChasePlayer();
        if (playerInsightRange && playerInAttackRange) AttackPlayer();
        
    }

    private void Patroling()
    {
        if (!walkPointSet) SearchWalkPoint();

        if (walkPointSet)
            agent.SetDestination(walkPoint);

        Vector3 distanceToWalkPoint = transform.position - walkPoint;
        
        //Walkpoint reached
        if (distanceToWalkPoint.magnitude < 1f)
            walkPointSet = false;
    }

    private void SearchWalkPoint()
    {
        //Calculate random point in range
        float randomZ = Random.Range(-walkPointRange, walkPointRange);
        float randomX = Random.Range(-walkPointRange, walkPointRange);
        float consY = transform.position.y;
        if(consY <= ground.transform.position.y){
            consY = consY - ground.transform.position.y;
        }
        walkPoint = new Vector3(transform.position.x + randomX, consY/*transform.position.y*/, transform.position.z + randomZ);

        if (Physics.Raycast(walkPoint, -transform.up, 2f, whatIsGround))
            walkPointSet = true;
    }
    private void ChasePlayer()
    {
        animator.SetTrigger("Run Forward");
        attackCollider.enabled = false;
        agent.SetDestination(player.position);
    }
    
    private void AttackPlayer()
    {
        //Make sure enemy doesn't move
        agent.SetDestination(transform.position);
        transform.LookAt(player);
        
        if (!alreadyAttacked)
        {
            print("Insetto attacca");
            //Attack code here
            attackCollider.enabled = true;
            animator.SetTrigger("Stab Attack");
            //End of attack code
        
            alreadyAttacked = true;
            Invoke(nameof(ResetAttack), timeBetweenAttacks);
            
        }
    }

    private void ResetAttack()
    {
        alreadyAttacked = false;
    }

    public void TakeDamage(float damage)
    {
        currentHealth += damage;
        float currentHealthPct = (float) currentHealth / (float) health;
        OnHealthPctChanged(currentHealthPct);
        if (currentHealth <= 0) Invoke(nameof(DestroyEnemy), 0.5f);
    }
    
    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Sword" && isEnemyHitted == false)
        {
            //print("Enemy Colpita - Entrata in collisione");
            TakeDamage(-25f);
            isEnemyHitted = true;
        } 
        if (other.gameObject.tag == "FireBall")
        {
            TakeDamage(-50f);
        }

        if (other.gameObject.tag == "Ice" )
        {
            if (!isSlowingDown)
            {
                isSlowingDown = true;
                ChangeVelocity(1);
            }
            TakeDamage(-0.5f);
        }
        
    }
    public void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Sword")
        {
            //print("Enemy Colpita - Uscita dalla collisione");
            isEnemyHitted = false;
        } 
    }

    public void ChangeVelocity(int speed)
    {
        agent.speed = speed;
        Invoke("ResetVelocity", 3f);
    }

    public void ResetVelocity()
    {
        isSlowingDown = false;
        agent.speed = 5;
    }
    
    private void DestroyEnemy()
    {
        animator.SetTrigger("Die");
        generateEnemies.insectCount -= 1;
        Destroy(gameObject, 1.5f);
        Destroy(this);
        //print("Enemy Distrutta");

    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRange);
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, sightRange);
    }
}
