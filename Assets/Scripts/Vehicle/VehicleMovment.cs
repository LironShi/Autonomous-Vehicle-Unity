using UnityEngine;
using UnityEngine.AI;

public class VehicleMovment : MonoBehaviour
{
    public Transform target;
    private NavMeshAgent agent;
    
    
    void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
    }
    
    void Start()
    {
        if (target != null)
            agent.SetDestination(target.position);
    }
}
