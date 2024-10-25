using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class AchievementChecker : MonoBehaviour
{
    public AchievementSO achievement;

    public UnityEvent AchievementEarned;

    public void Check()
    {
        if (achievement.AmountToCheck.Value == achievement.TargetAmount)
        {
            achievement.Earned = true;
            AchievementEarned?.Invoke();
        }
    } 
}
