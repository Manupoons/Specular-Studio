using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

[CreateAssetMenu(fileName = "New achievement", menuName = "SO/Achievements/Achievement")]

public class AchievementSO : ScriptableObject
{
    public String Title;
    public String Description;

    public Sprite Sprite;

    public IntVariable AmountToCheck;

    public int TargetAmount;

    public bool Earned;
}
