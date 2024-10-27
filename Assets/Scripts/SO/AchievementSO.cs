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

    private const string EarnedKeyPrefix = "AchievementEarned_";

    public bool Earned
    {
        get => PlayerPrefs.GetInt(EarnedKeyPrefix + name, 0) == 1;
        private set
        {
            PlayerPrefs.SetInt(EarnedKeyPrefix + name, value ? 1 : 0);
            PlayerPrefs.Save();
        }
    }

    public void EarnAchievement()
    {
        if (!Earned)
        {
            Earned = true;
        }
    }
}
