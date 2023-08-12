using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerClickInteraction : InteractiveEventTrigger
{
    [SerializeField] private GameObject interactionPosition;
    public Vector3 InteractionPosition => interactionPosition.transform.position;

    public void PerformInteraction()
    {
        RaiseEvent();
    }
    
    private void OnDrawGizmos()
    {
        Vector3 from = InteractionPosition;
        Vector3 to = new(from.x, from.y + 1.5f, from.z);
        Gizmos.color = Color.blue;
        Gizmos.DrawLine(from, to);
        Gizmos.DrawWireSphere(from, 0.3f);
    }
}
