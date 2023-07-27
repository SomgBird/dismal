using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeMaterialComponent : InteractiveComponent
{
    [SerializeField] private Material newMaterial;
    [SerializeField] private GameObject target;
    
    public override bool PerformInteraction(Player player)
    {
        UpdateMaterial();
        return true;
    }

    private void UpdateMaterial()
    {
        target.GetComponent<MeshRenderer>().material = newMaterial;
    }
}
