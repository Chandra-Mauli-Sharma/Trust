using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    public NavMeshAgent agent;

    public Transform player;

    public LayerMask whatIsGround, whatIsPlayer;

    public Vector3 walkPoint;
    bool walkPointSet;

    public float walkPointRange;
    public float timeBetweenAttacks;
    bool alreadyAttacked;

    public float sightRange,attackRange;
    public bool playerInSightRange,playerInAttackRange;

    private void Awake()
    {
        player=GameObject.FindGameObjectWithTag("Player").transform;
        agent= GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        playerInSightRange=Physics.CheckSphere(transform.position,sightRange,whatIsPlayer);
        playerInAttackRange=Physics.CheckSphere(transform.position,attackRange,whatIsPlayer);
        if(!playerInAttackRange && !playerInSightRange){
            Patroling();
        }
        if(!playerInAttackRange && playerInSightRange){
            ChasePlayer();
            
        }
        if(playerInAttackRange && playerInSightRange){
            AttackPlayer();
        }

    }

    private void AttackPlayer()
    {
        agent.SetDestination(transform.position);
        transform.LookAt(player);

        if(!alreadyAttacked)
        {
            agent.SetDestination(player.position);
        }
    }

    private void ResetAttack()
    {
        alreadyAttacked=false;
    }

    private void ChasePlayer()
    {
        agent.SetDestination(player.position);
    }

    private void Patroling()
    {
        if(!walkPointSet) SearchWalkPoint();
        if(walkPointSet)
        {
            agent.SetDestination(walkPoint);   
        }

        Vector3 distanceToWalkPoint = transform.position-walkPoint;

        if(distanceToWalkPoint.magnitude<1f)
        {
            walkPointSet=false;
        }
    }
    	


    private void SearchWalkPoint()
    {
        float randomZ= UnityEngine.Random.Range(-walkPointRange,walkPointRange);
        float randomX= UnityEngine.Random.Range(-walkPointRange,walkPointRange);

        walkPoint = new Vector3(transform.position.x+randomX,transform.position.y,transform.position.z+randomZ);

        if(Physics.Raycast(walkPoint,-transform.up,2f,whatIsGround))
        {
            walkPointSet=true;
        }
    }

    
}
