using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{

    private NavMeshAgent agent;
    public GameManager StateManager;
    private Transform player;

    public LayerMask whatIsGround, whatIsPlayer;

    //Patrolling
    public Vector3 walkPoint;
    bool walkPointSet;
    public float walkPointRange;

    //States
    public SphereCollider sightRange;
    public bool playerInSightRange, playerInAttackRange;

    public CapsuleCollider AttackRange;

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        agent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
      //Check for sight and range
      // if (sightRange.)


        if (playerInSightRange == true)
        {
            ChasePlayer();
            
        }
        else if (playerInSightRange == false)
        {
            Patrolling();
        }
        
    }

    private void OnTriggerEnter(Collider other)
    {
        playerInSightRange = true;
    }

    private void OnTriggerExit(Collider other)
    {
        playerInSightRange = false;
    }

    

    private void Patrolling()

    {
        if (!walkPointSet) SearchWalkPoint();

        if (walkPointSet)
            agent.SetDestination(walkPoint);

        Vector3 distanceToWalkPoint = transform.position - walkPoint;

        // Walkpoint reached
        if (distanceToWalkPoint.magnitude < 1f)
            walkPointSet = false;
    }

    private void SearchWalkPoint()
    {
        //Calculate random point in range
        float randomZ = Random.Range(-walkPointRange, walkPointRange);
        float randomX = Random.Range(-walkPointRange, walkPointRange);

        walkPoint = new Vector3(transform.position.x + randomX, transform.position.y, transform.position.z + randomZ);

        if (Physics.Raycast(walkPoint, -transform.up, 2f, whatIsGround))
            walkPointSet = true;
    }


    private void ChasePlayer()

    {
        agent.SetDestination(player.position); 

    }
}
