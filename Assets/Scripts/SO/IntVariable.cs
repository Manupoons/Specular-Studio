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
            PlayerPrefs.Save();
        }
    }

    private void OnEnable()
    {
        playerPrefsKey = $"IntVariable_{name}";
    }

    public void IncreaseValue()
    {
        Value++;
    }

    public void SetZero()
    {
        Value = 0;
    }
}
