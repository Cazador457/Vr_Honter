using System;
using UnityEngine;
using UnityEngine.AI;
public class Enemy : MonoBehaviour
{
    [Header("Patrol")]
    public Transform[] patrolPoints;
    private NavMeshAgent _agent;
    private int _patrolIndex;
    private float _arrive = 0.5f;

    [Header("Stats")]
    public float health = 50f;
    public event Action onDeath;
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
    //Stats
    public void TakeDamage(float damage)
    {
        health -= damage;
        if (health <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        onDeath?.Invoke();

        gameObject.SetActive(false);
        health = 50f;
    }

    void OnEnable()
    {
        health = 50f;
    }
}
