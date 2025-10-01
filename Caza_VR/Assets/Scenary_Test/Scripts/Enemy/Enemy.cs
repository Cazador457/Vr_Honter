using UnityEngine;
using UnityEngine.AI;
public class Enemy : MonoBehaviour
{
    public int damage;
    [Header("Patrol")]
    public Transform[] patrolPoints;
    private NavMeshAgent _agent;
    private int _patrolIndex;
    private float _arrive = 1f;
    
     void Start()
    {
        Destination();
    }
    void Update()
    {
        ChangeDestination();
    }
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
        if (patrolPoints.Length == 0) return;
        if (!_agent.pathPending && _agent.remainingDistance < _arrive)
        {
            _patrolIndex = (_patrolIndex + 1) % patrolPoints.Length;
            _agent.SetDestination(patrolPoints[_patrolIndex].position);
        }
    }
}
