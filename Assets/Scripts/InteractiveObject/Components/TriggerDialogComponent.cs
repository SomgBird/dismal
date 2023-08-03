using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerDialogComponent : InteractiveComponent
{
    [SerializeField] private TextAsset dialogTextAsset;
    
    public override bool PerformInteraction(Player player)
    {
        DialogueManager.Instance.EnterDialogueMode(dialogTextAsset);
        return true;
    }
}
