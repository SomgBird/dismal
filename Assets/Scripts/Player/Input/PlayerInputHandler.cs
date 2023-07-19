using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputHandler : MonoBehaviour
{
    public bool MoveInput { get; private set; }
    
    public Vector3 DestinationPosition  { get; set; }

    private Vector2 mousePosition;


    public void OnActionInput(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            mousePosition = Mouse.current.position.ReadValue();
            Ray ray = Camera.main.ScreenPointToRay(mousePosition);

            if (Physics.Raycast(ray, out RaycastHit hit))
            {
                switch (hit.collider.tag)
                {
                    case "Walkable":
                        SetMovementTask(hit);
                        break;
                    case "Interactive":
                        break;
                }
            }
        }

        if (context.canceled)
        {
            MoveInput = false;
        }
    }


    private void SetMovementTask(RaycastHit hit)
    {
        DestinationPosition = hit.point;
        MoveInput = true;
        //TODO: move to state machine
        GetComponent<PlayerNavMeshController>().SetDestination(DestinationPosition);
    } 
}
