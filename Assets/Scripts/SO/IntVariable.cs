using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New int variable",menuName = "SO/Variables/Int Variable")]

public class IntVariable : ScriptableObject
{
    private string playerPrefsKey;

    public int Value
    {
        get => PlayerPrefs.GetInt(playerPrefsKey, 0);
        set
        {
            PlayerPrefs.SetInt(playerPrefsKey, value);
            PlayerPrefs.Save(); // Ensures the value is written immediately
        }
    }

    private void OnEnable()
    {
        // Set a unique key based on the object name to avoid conflicts
        playerPrefsKey = $"IntVariable_{name}";
    }

    public void IncreaseValue()
    {
        Value++; // This will automatically update PlayerPrefs
    }

    public void SetZero()
    {
        Value = 0;
    }
}
