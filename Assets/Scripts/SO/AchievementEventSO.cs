using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName="New achievement event", menuName="SO/Events/Achievement event")]
public class AchievementEventSO : EventSO<AchievementSO>
{
    public AchievementSO achievement;
    public void Raise() => RaiseEvent(achievement);
}