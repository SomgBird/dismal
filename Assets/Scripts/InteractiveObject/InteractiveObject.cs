using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractiveObject : MonoBehaviour
{
    [SerializeField] private GameObject componentContainer;
    [SerializeField] private GameObject interactionPosition;

    public Vector3 InteractionPosition => interactionPosition.transform.position;

    private InteractiveComponent[] components;

    // Start is called before the first frame update
    void Start()
    {
        components = componentContainer.GetComponents<InteractiveComponent>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void PerformInteraction(Player player)
    {
        foreach (InteractiveComponent component in components)
        {
            if (!component.PerformInteraction(player))
            {
                Debug.Log("Cannot continue interaction!");
                break;
            }
        }
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
