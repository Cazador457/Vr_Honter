using UnityEngine;
using UnityEngine.AI;
using System.Collections;

public class EnemyMele : Enemy
{
    [Header("Resources")]
    private PatrolForPoints _patrolMovement;

    [Header("Patrol")]
    public Transform[] patrolPoints;
    private NavMeshAgent agent;
    private int patrolIndex;
    public float arrival = 1.2f;

    public Transform player;

    [Header("Vision Settings")]
    public float visionRange = 10f;
    public float visionAngle = 45f;
    public LayerMask visionMask;

    private bool isChasing = false;
    private Coroutine chaseRoutine;

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        _patrolMovement = new PatrolForPoints(agent, patrolPoints, patrolIndex,arrival);
    }

    void Update()
    {
        if (!isChasing)
        {
            _patrolMovement?.ChangeDestination();
            CheckVision();
        }
        else
        {
            if (!CanSeePlayer())
            {
                StopChasing();
            }
        }
    }

    void CheckVision()
    {
        if (player == null) return;

        Vector3 direction = player.position - transform.position;
        float distance = direction.magnitude;

        if (distance <= visionRange)
        {
            float angle = Vector3.Angle(transform.forward, direction);

            if (angle <= visionAngle)
            {
                RaycastHit hit;
                if (Physics.Raycast(transform.position + Vector3.up, direction.normalized,
                    out hit, visionRange, visionMask))
                {
                    if (hit.transform.CompareTag("Player"))
                    {
                        StartChasing();
                    }
                }
            }
        }
    }
    void StartChasing()
    {
        if (isChasing) return;

        isChasing = true;

        if (chaseRoutine != null)
            StopCoroutine(chaseRoutine);

        chaseRoutine = StartCoroutine(ChasePlayer());
    }
    IEnumerator ChasePlayer()
    {
        while (isChasing && player != null)
        {
            agent.SetDestination(player.position);
            yield return new WaitForSeconds(0.2f);
        }
    }
    void StopChasing()
    {
        isChasing = false;

        if (chaseRoutine != null)
            StopCoroutine(chaseRoutine);

        chaseRoutine = null;
    }
    bool CanSeePlayer()
    {
        Vector3 direction = player.position - transform.position;
        float distance = direction.magnitude;

        if (distance > visionRange)
            return false;

        float angle = Vector3.Angle(transform.forward, direction);
        if (angle > visionAngle)
            return false;

        RaycastHit hit;
        if (Physics.Raycast(transform.position + Vector3.up, direction.normalized,
            out hit, visionRange, visionMask))
        {
            return hit.transform.CompareTag("Player");
        }

        return false;
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, visionRange);
    }
    public override void OnEnable()
    {
        health = 350f;
    }
}
