using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New int variable",menuName = "SO/Variables/Int Variable")]

public class IntVariable : ScriptableObject
{
    public int Value;
    
    public void IncreaseValue()
    {
        Value++;
    }
}
