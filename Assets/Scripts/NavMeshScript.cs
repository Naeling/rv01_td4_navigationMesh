using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NavMeshScript : MonoBehaviour {

    public Transform T_target;
    private NavMeshAgent navMeshAgent;

	void Start () {
        navMeshAgent = GetComponent<NavMeshAgent>();
        navMeshAgent.SetDestination(T_target.position);
	}
	
	void Update () {
		
	}
}
