using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerDialogComponent : InteractiveComponent
{
    [SerializeField] private TextAsset dialogTextAsset;
    
    public override bool PerformInteraction()
    {
        DialogueManager.Instance.EnterDialogueMode(dialogTextAsset);
        return true;
    }
}
