using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerClickInteraction : InteractiveEventTrigger
{
    [SerializeField] private GameObject interactionPositionMarker;
    public Vector3 InteractionPosition => interactionPositionMarker.transform.position;

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
