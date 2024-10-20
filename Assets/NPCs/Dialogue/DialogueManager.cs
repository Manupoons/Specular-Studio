using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Subtegral.DialogueSystem.DataContainers;

namespace Subtegral.DialogueSystem.Runtime
{
    public class DialogueManager : MonoBehaviour
    {
        [SerializeField] private List<DialogueContainer> narratives; // List to hold multiple narratives
        [SerializeField] private TextMeshProUGUI dialogueText;
        [SerializeField] private Button choicePrefab;
        [SerializeField] private Transform buttonContainer;
        [SerializeField] private Button nextNarrativeButton; // Button to go to next narrative

        private int currentNarrativeIndex = 0; // Track the current narrative
        private bool narrativeEnded = false;   // Flag to check if current narrative ended

        private void Start()
        {
            StartNarrative(currentNarrativeIndex);
        }

        private void StartNarrative(int narrativeIndex)
        {
            if (narrativeIndex < narratives.Count)
            {
                var narrativeData = narratives[narrativeIndex].NodeLinks.First(); // Entrypoint node
                ProceedToNarrative(narrativeData.TargetNodeGUID);
            }
        }

        private void ProceedToNarrative(string narrativeDataGUID)
        {
            var dialogue = narratives[currentNarrativeIndex]; // Get the current narrative
            var text = dialogue.DialogueNodeData.Find(x => x.NodeGUID == narrativeDataGUID).DialogueText;
            var choices = dialogue.NodeLinks.Where(x => x.BaseNodeGUID == narrativeDataGUID);
            
            // Update dialogue text
            dialogueText.text = ProcessProperties(text);

            // Destroy old buttons
            var buttons = buttonContainer.GetComponentsInChildren<Button>();
            for (int i = 0; i < buttons.Length; i++)
            {
                Destroy(buttons[i].gameObject);
            }

            // If there are choices, create buttons for them
            if (choices.Any())
            {
                narrativeEnded = false;
                foreach (var choice in choices)
                {
                    var button = Instantiate(choicePrefab, buttonContainer);
                    button.GetComponentInChildren<Text>().text = ProcessProperties(choice.PortName);
                    button.onClick.AddListener(() => ProceedToNarrative(choice.TargetNodeGUID));
                }
            }
            else
            {
                // No choices means this is the end of the current narrative
                narrativeEnded = true;
                ShowNextNarrativeButton();
            }
        }

        private void ShowNextNarrativeButton()
        {
            nextNarrativeButton.gameObject.SetActive(true);
            nextNarrativeButton.onClick.RemoveAllListeners(); // Remove previous listeners
            nextNarrativeButton.onClick.AddListener(() =>
            {
                nextNarrativeButton.gameObject.SetActive(false); // Hide button when clicked
                currentNarrativeIndex++; // Move to next narrative
                if (currentNarrativeIndex < narratives.Count)
                {
                    StartNarrative(currentNarrativeIndex); // Start the next narrative
                }
            });
        }

        private string ProcessProperties(string text)
        {
            var dialogue = narratives[currentNarrativeIndex]; // Get the current narrative's properties
            foreach (var exposedProperty in dialogue.ExposedProperties)
            {
                text = text.Replace($"[{exposedProperty.PropertyName}]", exposedProperty.PropertyValue);
            }
            return text;
        }
    }

}