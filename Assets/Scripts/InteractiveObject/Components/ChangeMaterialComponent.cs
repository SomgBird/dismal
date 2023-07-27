using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeMaterialComponent : InteractiveComponent
{
    [SerializeField] private Material newMaterial;
    [SerializeField] private GameObject target;
    
    public override void PerformInteraction(Player player)
    {
        base.PerformInteraction(player);

        target.GetComponent<MeshRenderer>().material = newMaterial;
    }
}
