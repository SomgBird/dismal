using UnityEngine;

public class InteractiveEvent : MonoBehaviour
{
    [SerializeField] private GameObject componentContainer;
    [SerializeField] private InteractiveEventTrigger eventTrigger;

    private InteractiveComponent[] components;
    
    private void Start()
    {
        components = componentContainer.GetComponents<InteractiveComponent>();
        eventTrigger.Trigger += PerformInteraction;
    }

    private void PerformInteraction()
    {
        foreach (InteractiveComponent component in components)
        {
            if (!component.PerformInteraction())
            {
                Debug.Log("Cannot continue interaction!");
                break;
            }
        }
    }
}
