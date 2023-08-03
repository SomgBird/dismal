using System;
using System.Collections;
using System.Collections.Generic;
using Ink.Runtime;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;

public class DialogueManager : Singleton<DialogueManager>
{
    [Header("Dialogue UI")] 
    [SerializeField] private GameObject dialoguePanel;
    [SerializeField] private TextMeshProUGUI dialogueText;

    private Story currentStory;

    public bool DialogueIsPlaying { get; private set; }
    
    
    private void Start()
    {
        DialogueIsPlaying = false;
        dialoguePanel.SetActive(false);
    }

    private void Update()
    {
        if (!DialogueIsPlaying)
        {
            return;
        }

        if (currentStory.currentChoices.Count == 0 &&
            InputManager.Instance.SubmitPressed)
        {
            InputManager.Instance.RegisterSubmitPressed();
            ContinueStory();
        }
    }
    
    public void EnterDialogueMode(TextAsset inkJSON)
    {
        currentStory = new Story(inkJSON.text);
        DialogueIsPlaying = true;
        dialoguePanel.SetActive(true);
        ContinueStory();
    }

    private void ContinueStory()
    {
        if (currentStory.canContinue)
            dialogueText.text = currentStory.Continue();
        else
            ExitDialogueMode();
    }

    private void ExitDialogueMode()
    {
        DialogueIsPlaying = false;
        dialoguePanel.SetActive(false);
        dialogueText.text = "";
    }
}
