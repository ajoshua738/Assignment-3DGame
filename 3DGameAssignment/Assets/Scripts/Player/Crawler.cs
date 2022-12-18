using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Crawler : MonoBehaviour
{
    public NavMeshAgent crawler;
    public Transform player;
    Vector3 dest;

    public LayerMask whatIsGround, whatIsPlayer;

    //Patroling

    public Vector3 walkPoint; //Destination for crawler to walk to
    bool walkPointSet; // To confirm set a walk point if its in the map
    public float walkPointRange; //to check distance between crawler and the walk point. if <1, then walkPointSet = false

    //Attacking
    public float timeBetweenAttacks;
    bool alreadyAttacked;


    //States
    public float sightRange, attackRange;
    public bool playerInSightRange, playerInAttackRange;


    private void Awake()
    {

        player = GameObject.FindWithTag("Player").transform;
        crawler = GetComponent<NavMeshAgent>();
    }


    private void Update()
    {
        //Check if player is in sight
        playerInSightRange = Physics.CheckSphere(transform.position, sightRange, whatIsPlayer);

        if (!playerInSightRange)
        {
            Patrolling();
        }

        if (playerInSightRange)
        {
            Chasing();
        }
    }

    private void Patrolling()
    {
        //if no walk point set, find one
        if (!walkPointSet)
        {
            SearchWalkPoint();
        }

        //if found walk point, go to it
        if (walkPointSet)
        {
            crawler.SetDestination(walkPoint);
        }

        Vector3 distanceToWalkPoint = transform.position - walkPoint;

        //walkpoint reach, find new one
        if(distanceToWalkPoint.magnitude < 1.0f)
        {
            walkPointSet = false;
        }
    }

    private void SearchWalkPoint()
    {
        //Calculate random point in map

        float randomZ = Random.Range(-walkPointRange, walkPointRange);
        float randomX = Random.Range(-walkPointRange, walkPointRange);

        walkPoint = new Vector3(transform.position.x + randomX, transform.position.y, transform.position.z + randomZ);



        //if walkpoint is not in map
        if(Physics.Raycast(walkPoint, -transform.up, 2f, whatIsGround))
        {
            walkPointSet = true;
        }




    }


    private void Chasing()
    {

        crawler.SetDestination(player.position);

    }


    private void Attacking()
    {



    }



    /*private void Update()
    {
        dest = player.position;
        crawler.destination = dest;
      
    }*/

}
