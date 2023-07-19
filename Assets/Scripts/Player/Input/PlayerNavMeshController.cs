using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerNavMeshController : MonoBehaviour
{
    private NavMeshAgent navMeshAgent;

    [SerializeField] private Transform destinationTransform;
    
    private void Awake()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        navMeshAgent.destination = destinationTransform.position;
    }

    public void SetDestination(Vector3 position)
    {
        destinationTransform.transform.position = position;
    } 
}
