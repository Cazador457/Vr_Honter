using UnityEngine;
using UnityEngine.AI;
using System;
public class LightMovPatrol : MonoBehaviour
{
    [Header("Resources")]
    private PatrolForPoints _patrolMovement;
    public static Action OnPursuit;

    [Header("Patrol")]
    public Transform[] patrolPoints;
    private NavMeshAgent agent;
    private int patrolIndex;
    public float arrival = 1.2f;

    public void Initialized()
    {
        _patrolMovement = new PatrolForPoints(agent, patrolPoints, patrolIndex,arrival);
    }
    void Start()
    {
        //_patrolMovement = new PatrolForPoints(agent, patrolPoints, patrolIndex);
        agent = GetComponent<NavMeshAgent>();
        Initialized();
        _patrolMovement?.Destination();
    }
    void Update()
    {
        _patrolMovement?.ChangeDestination();
    }
    public void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            OnPursuit?.Invoke();
        }
            
    }
}
