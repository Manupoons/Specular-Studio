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
}
