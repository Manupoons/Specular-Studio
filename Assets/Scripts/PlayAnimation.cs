using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Playanimation : MonoBehaviour
{
    public Animator animacion;
    
    void Start()
    {
        animacion.SetTrigger("Play");
    }
}
