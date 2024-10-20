using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Playanimation : MonoBehaviour
{
    public UnityEvent evento;
    
    void Start()
    {
        evento.Invoke();
    }
}
