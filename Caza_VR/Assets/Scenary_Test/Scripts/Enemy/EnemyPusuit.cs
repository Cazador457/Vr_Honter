using UnityEngine;
using UnityEngine.AI;

public class EnemyPusuit : Enemy
{
    public Transform target;
    private NavMeshAgent agent;
    private float stopRange=1.5f;
    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }
    public override void OnEnable()
    {
        LightMovPatrol.OnPursuit += Pursuit;
        
    }
    private void OnDisable()
    {
        LightMovPatrol.OnPursuit -= Pursuit;
    }
    void Pursuit()
    {
        float distance = Vector3.Distance(agent.nextPosition, target.position);
        if (distance > stopRange)
        {
            agent.SetDestination(target.position);
        }
        else if (distance < stopRange)
        {
            ataak();
        }
    }
    private void ataak()
    {
        Debug.Log("Atacando");
    }
}
