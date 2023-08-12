using UnityEngine;

public class InteractiveEventTrigger : MonoBehaviour
{
    public delegate void EventHandler();
    public event EventHandler Trigger;

    protected void RaiseEvent()
    {
        Trigger?.Invoke();
    }
}
