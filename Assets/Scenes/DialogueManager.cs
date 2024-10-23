using System;
using System.Collections;
using System.Collections.Generic;
using DialogueEditor;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UIElements;

public class DialogueManager : MonoBehaviour
{

    public UnityEvent dialog;

    private void Start()
    {
        dialog?.Invoke();
    }

    private void Update()
    {
        if (ConversationManager.Instance != null)
        {
            UpdateConversationInput();
        }
    }

    private void UpdateConversationInput()
    {
        if (ConversationManager.Instance.IsConversationActive)
        {
            if (Input.GetKeyDown(KeyCode.Space))
                ConversationManager.Instance.SelectPreviousOption();
        }
    }
}
