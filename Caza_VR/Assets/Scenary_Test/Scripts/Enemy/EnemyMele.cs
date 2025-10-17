using UnityEngine;
using UnityEngine.AI;
using System;

public class EnemyMele : Enemy
{
    [Header("Resources")]
    private PatrolForPoints _patrolMovement;

    [Header("Patrol")]
    public Transform[] patrolPoints;
    private NavMeshAgent agent;
    private int patrolIndex;

    public void Initialized()
    {
        _patrolMovement = new PatrolForPoints(agent, patrolPoints, patrolIndex);
    }

    //Patrol
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        Initialized();
        _patrolMovement?.Destination();
    }

    void Update()
    {
        _patrolMovement?.ChangeDestination();
    }
}
