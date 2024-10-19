using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EventListener<T> : MonoBehaviour,IGameEventListener<T>
{
    public EventSO<T> eventToListen;
    public UnityEvent<T> onEventRaised;
    private void OnEnable()
    {
        eventToListen.AddListener(this);
    }

    private void OnDisable()
    {
        eventToListen.RemoveListener(this);
    }

    public void OnEventRaised(T item)
    {
        onEventRaised?.Invoke(item);
    }
}
