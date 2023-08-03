using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class InputManager : Singleton<InputManager>
{
    public bool MoveInput { get; private set; }
    public bool InteractionScheduled { get; private set; }
    private bool interactInput;
    public bool InteractInput
    {
        get
        {
            bool i = interactInput;
            interactInput = false;
            return i;

        }
        private set => interactInput = value;
    }

    public bool SubmitPressed { get; private set; }
    
    public Vector3 DestinationPosition  { get; set; }
    public InteractiveObject InteractionTarget { get; private set; }

    private Vector2 mousePosition;

    private bool isMouseOverUI;

    
    public void Update()
    {
        isMouseOverUI = EventSystem.current.IsPointerOverGameObject();
    }

    public void OnActionInput(InputAction.CallbackContext context)
    {
        if (isMouseOverUI)
            return;
        
        if (context.started)
        {
            mousePosition = Mouse.current.position.ReadValue();
            Ray ray = Camera.main.ScreenPointToRay(mousePosition);

            if (Physics.Raycast(ray, out RaycastHit hit))
            {
                switch (hit.collider.tag)
                {
                    case "Walkable":
                        SetMovement(hit);
                        break;
                    case "Interactive":
                        SetInteraction(hit);
                        break;
                    default:
                        // TODO: play a sound effect?
                        break;
                }
            }
        }

        if (context.canceled)
        {
            MoveInput = false;
            InteractInput = false;
        }
    }
    
    
    public void OnSubmitPressed(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            SubmitPressed = true;
        }
        else if (context.canceled)
        {
            SubmitPressed = false;
        } 
    }
    
    public void RegisterSubmitPressed() 
    {
        SubmitPressed = false;
    }


    public void SetMovement(RaycastHit hit)
    {
        DestinationPosition = hit.point;
        MoveInput = true;
        ClearInteraction();
    }

    public void SetInteraction(RaycastHit hit)
    {
        InteractionTarget = hit.transform.GetComponentInParent<InteractiveObject>();
        DestinationPosition = InteractionTarget.InteractionPosition;
        InteractInput = true;
        InteractionScheduled = true;
    }

    public void ClearInteraction()
    {
        InteractionScheduled = false;
        InteractionTarget = null;
        
    }
}
