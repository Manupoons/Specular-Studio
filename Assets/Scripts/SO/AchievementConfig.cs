using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class AchievementConfig : MonoBehaviour
{
    public Image Icon;
    public TextMeshProUGUI Title;
    public TextMeshProUGUI Description;
    
    public void ConfigAchievement(AchievementSO achievement)
    {
        Icon.sprite = achievement.Sprite;
        Title.text = achievement.Title;
        Description.text = achievement.Description;
    }
}
