using UnityEngine;
using UnityEngine.AI;
using System;

public class EnemyMele : Enemy, IPath
{
    [Header("Resources")]
    private PatrolForPoints _patrolMovement;

    [Header("Patrol")]
    public Transform[] patrolPoints;
    private NavMeshAgent agent;
    private int patrolIndex;
    private int currentPoint = 0;

    public void Initialized()
    {
        _patrolMovement = new PatrolForPoints(agent, patrolPoints, patrolIndex);
    }
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
    public void OnSpawned(Transform[] optionalRoute = null)
    {
        if (optionalRoute != null && optionalRoute.Length > 0)
        {
            patrolPoints = optionalRoute;
            currentPoint = 0;
        }
    }
}
