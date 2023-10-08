using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Serialization;

public class NavMeshManager : Singleton<NavMeshManager>
{
    [SerializeField] private NavMeshAgent navMeshAgentInstance;
    [SerializeField] private GameObject destinationMark;
    
    public NavMeshAgent NavMeshAgentInstance => navMeshAgentInstance;
    
    private void Update()
    {
        // PlayerNavMeshAgent.destination = destinationPoint;
    }

    public void SetDestination(Vector3 destinationPoint)
    {
        NavMeshAgentInstance.SetDestination(destinationPoint);
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
