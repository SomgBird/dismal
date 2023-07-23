using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerNavMeshController : MonoBehaviour
{
    public NavMeshAgent NavMeshAgent { get; private set; }

    [SerializeField] private GameObject destinationMark;
    
    private void Awake()
    {
        NavMeshAgent = GetComponent<NavMeshAgent>();
    }

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
