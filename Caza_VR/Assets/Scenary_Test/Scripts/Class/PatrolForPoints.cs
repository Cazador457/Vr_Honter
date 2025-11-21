using UnityEngine;
using UnityEngine.AI;

public class PatrolForPoints : IPatrol
{
    public NavMeshAgent agent;
    public Transform[] patrolPoints;
    public int patrolIndex;
    public float arrival = 1.2f;

    public PatrolForPoints(NavMeshAgent agent, Transform[] patrolPoints, int patrolIndex, float arrival)
    {
        this.agent = agent;
        this.patrolPoints = patrolPoints;
        this.patrolIndex = patrolIndex;
        this.arrival = arrival;
    }

    public void Destination()
    {
        if (patrolPoints == null || patrolPoints.Length == 0)
            return;

        patrolIndex = 0;
        agent.SetDestination(patrolPoints[patrolIndex].position);
    }

    public void ChangeDestination()
    {
        if (patrolPoints == null || patrolPoints.Length == 0)
            return;

        if (!agent.pathPending && agent.remainingDistance < arrival)
        {
            patrolIndex = (patrolIndex + 1) % patrolPoints.Length;
            agent.SetDestination(patrolPoints[patrolIndex].position);
        }
    }
}
