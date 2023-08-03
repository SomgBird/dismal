using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Serialization;

public class NavMeshManager : Singleton<NavMeshManager>
{
    [SerializeField] private NavMeshAgent navMeshAgent;
    [SerializeField] private GameObject destinationMark;
    
    public NavMeshAgent NavMeshAgent => navMeshAgent;
    
    private void Update()
    {
        // PlayerNavMeshAgent.destination = destinationPoint;
    }

    public void SetDestination(Vector3 destinationPoint)
    {
        NavMeshAgent.SetDestination(destinationPoint);
        destinationMark.transform.position = destinationPoint;
    }
    
    public void ShowDestinationMark()
    {
        destinationMark.SetActive(true);
    }

    public void ClearDestinationMark()
    {
        destinationMark.SetActive(false);
    }
}
