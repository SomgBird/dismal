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
}
