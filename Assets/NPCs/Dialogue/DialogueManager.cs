using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Subtegral.DialogueSystem.DataContainers;
using UnityEngine.Events;

namespace Subtegral.DialogueSystem.Runtime
{
    public class DialogueManager : MonoBehaviour
    {
        [SerializeField] private List<DialogueContainer> narratives;
        [SerializeField] private TextMeshProUGUI dialogueText;
        [SerializeField] private Button choicePrefab;
        [SerializeField] private Transform buttonContainer;
        [SerializeField] private Button nextNarrativeButton;
        [SerializeField] private UnityEvent onNarrativeSequenceComplete;

        private int currentNarrativeIndex = 0;

        private void Start()
        {
            StartNarrative(currentNarrativeIndex);
        }

        private void StartNarrative(int narrativeIndex)
        {
            if (narrativeIndex < narratives.Count)
            {
                var narrativeData = narratives[narrativeIndex].NodeLinks.First();
                ProceedToNarrative(narrativeData.TargetNodeGUID);
            }
        }

        private void ProceedToNarrative(string narrativeDataGUID)
        {
            var dialogue = narratives[currentNarrativeIndex];
            var text = dialogue.DialogueNodeData.Find(x => x.NodeGUID == narrativeDataGUID).DialogueText;
            var choices = dialogue.NodeLinks.Where(x => x.BaseNodeGUID == narrativeDataGUID);
            
            dialogueText.text = ProcessProperties(text);

            var buttons = buttonContainer.GetComponentsInChildren<Button>();
            for (int i = 0; i < buttons.Length; i++)
            {
                Destroy(buttons[i].gameObject);
            }

            if (choices.Any())
            {
                foreach (var choice in choices)
                {
                    var button = Instantiate(choicePrefab, buttonContainer);
                    //button.GetComponentInChildren<Text>().text = ProcessProperties(choice.PortName);
                    button.onClick.AddListener(() => ProceedToNarrative(choice.TargetNodeGUID));
                }
            }
            else
            {
                ShowNextNarrativeButton();
            }
        }

        private void ShowNextNarrativeButton()
        {
            nextNarrativeButton.gameObject.SetActive(true);
            nextNarrativeButton.onClick.RemoveAllListeners();
            nextNarrativeButton.onClick.AddListener(() =>
            {
                nextNarrativeButton.gameObject.SetActive(false);
                currentNarrativeIndex++;
                if (currentNarrativeIndex < narratives.Count)
                {
                    StartNarrative(currentNarrativeIndex);
                }
                else
                {
                    Debug.Log("Entra");
                    onNarrativeSequenceComplete?.Invoke();
                }
            });
        }

        private string ProcessProperties(string text)
        {
            var dialogue = narratives[currentNarrativeIndex];
            foreach (var exposedProperty in dialogue.ExposedProperties)
            {
                text = text.Replace($"[{exposedProperty.PropertyName}]", exposedProperty.PropertyValue);
            }
            return text;
        }
    }

}