using UnityEngine;
using UnityEngine.AI;
public interface IPatrol
{
    void Destination(NavMeshAgent agent, Transform[] patrolPoints, int patrolIndex);

    void ChangeDestination(NavMeshAgent agent, Transform[] patrolPoints, int patrolIndex);
}
