using UnityEngine;
using UnityEngine.AI;
public class Patrol:MonoBehaviour
{
    public float speed;
    public int damage;
    public Transform[] patrolPoints;
    private NavMeshAgent _agent;
    private int _patrolIndex;
    private float _arrive;

    public virtual void Destination()
    {
        _agent = GetComponent<NavMeshAgent>();
        if (patrolPoints.Length > 0)
        {
            _patrolIndex = 0;
            _agent.SetDestination(patrolPoints[_patrolIndex].position);
        }
    }
    void ChangeDestination()
    {
        if (!_agent.pathPending && _agent.remainingDistance < _arrive)
        {
            _patrolIndex = (_patrolIndex + 1) % patrolPoints.Length;
            _agent.SetDestination(patrolPoints[_patrolIndex].position);
        }
    }
}
