using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventSO<T> : ScriptableObject
{
    private List<IGameEventListener<T>> listenerList = new List<IGameEventListener<T>>();
    public void AddListener(IGameEventListener<T> listener)
    {
        if (listenerList.Contains(listener)) return;

        listenerList.Add(listener);
    }

    public void RemoveListener(IGameEventListener<T> listener)
    {
        if (!listenerList.Contains(listener)) return;

        listenerList.Remove(listener);
    }

    public void RaiseEvent(T item)
    {
        for (int i = listenerList.Count-1; i >=0; i--)
        {
            listenerList[i].OnEventRaised(item);
        }
    }
}
