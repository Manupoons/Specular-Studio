using UnityEngine;
using UnityEngine.UI;
using Object = UnityEngine.Object;

public class LockedAchievementChecker : MonoBehaviour
{
    private GridLayoutGroup gridLayout;
    private AchievementSO[] achievementList;
    
    public GameObject AchievementSlot;

    private void Start()
    {
        gridLayout = GetComponent<GridLayoutGroup>();
        achievementList = Resources.LoadAll<AchievementSO>("");

        foreach (AchievementSO achievement in achievementList)
        {
            GameObject instantiatedAchievement = Instantiate(AchievementSlot, gridLayout.transform);
            if (achievement.Earned)
            {
                instantiatedAchievement.GetComponent<AchievementConfig>().ConfigAchievement(achievement);
            }
        }
    }
}