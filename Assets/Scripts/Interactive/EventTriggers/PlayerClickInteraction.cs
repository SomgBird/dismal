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
}
