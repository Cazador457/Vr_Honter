using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    private IPatrol _patrolMovement;

    public Transform[] patrolPoints;
    private NavMeshAgent agent;
    private int patrolIndex;
    public void Initialized(IPatrol patrol)
    {
        _patrolMovement = patrol;
    }

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        _patrolMovement?.Destination(agent, patrolPoints, patrolIndex);
    }

    void Update()
    {
        _patrolMovement?.ChangeDestination(agent, patrolPoints, patrolIndex) ;
    }
}
