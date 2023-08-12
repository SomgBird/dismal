using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class InteractiveComponent : MonoBehaviour
{
    public virtual bool PerformInteraction()
    {
        return true;
    }
}
