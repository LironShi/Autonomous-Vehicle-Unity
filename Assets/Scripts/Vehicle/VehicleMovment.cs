using UnityEngine;
using UnityEngine.AI;

namespace Vehicle
{
    public class VehicleMovment : MonoBehaviour
    {
        public Transform target;
        private NavMeshAgent _agent;
    
    
        void Awake()
        {
            _agent = GetComponent<NavMeshAgent>();
        }
    
        void Start()
        {
            if (target != null)
                _agent.SetDestination(target.position);
        }
    }
}
