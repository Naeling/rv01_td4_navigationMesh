using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NavMeshScript : MonoBehaviour
{

    public Transform t_target;
    private NavMeshAgent navMeshAgent;

    private void Start()
    {
        Debug.Log("Hi, I'm a new car !");
        navMeshAgent = GetComponent<NavMeshAgent>();
        if (t_target != null)
        {
            navMeshAgent.SetDestination(t_target.position);
        }
    }

    public void UpdateDestination(Transform t)
    {
        if (navMeshAgent == null)
        {
            navMeshAgent = GetComponent<NavMeshAgent>();
        }
        navMeshAgent.SetDestination(t.position);
    }
}
