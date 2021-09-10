using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using Random = UnityEngine.Random;

public class EnemyAI : MonoBehaviour
{
    
    public NavMeshAgent agent;
    public Transform player;
    public GameObject ground;
    public LayerMask whatIsGround, whatIsPlayer;
    public float health;
    public float currentHealth;
    public bool isEnemyHitted = false;
    
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
    
    //States
    public float sightRange, attackRange;
    public bool playerInsightRange, playerInAttackRange;

    private void Awake()
    {
        player = GameObject.Find("Player").transform;
        
        agent = GetComponent<NavMeshAgent>();

        currentHealth = health;
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
        agent.SetDestination(player.position);
    }
    
    private void AttackPlayer()
    {
        //Make sure enemy doesn't move
        agent.SetDestination(transform.position);
        transform.LookAt(player);
        
        if (!alreadyAttacked)
        {
            //print("Fuoco");
            //Attack code here
            /*
            Rigidbody rb = Instantiate(projectile, transform.position, Quaternion.identity).GetComponent<Rigidbody>();
            rb.AddForce(transform.forward * 32f, ForceMode.Impulse);
            rb.AddForce(transform.up * 8f, ForceMode.Impulse);
            //End of attack code
        
            alreadyAttacked = true;
            Invoke(nameof(ResetAttack), timeBetweenAttacks);
            */
        }
    }

    private void ResetAttack()
    {
        alreadyAttacked = false;
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        if (currentHealth <= 0) Invoke(nameof(DestroyEnemy), 0.5f);
    }

    public void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "FireBall")
        {
            TakeDamage(150);
        }
            
        
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Sword" && isEnemyHitted == false)
        {
            print("Enemy Colpita - Entrata in collisione");
            TakeDamage(25);
            isEnemyHitted = true;
        } 
    } 

    public void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Sword")
        {
            print("Enemy Colpita - Uscita dalla collisione");
            isEnemyHitted = false;
        } 
    } 

    private void DestroyEnemy()
    {
        Destroy(gameObject);
        print("Enemy Distrutta");

    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRange);
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, sightRange);
    }
}
