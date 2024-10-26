using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckForSuero : MonoBehaviour
{
    public GameObject player1;
    public GameObject player2;
    public IntVariable suero;
    
    void Start()
    {
        if (suero.Value == 1)
        {
            player1.SetActive(true);
            player2.SetActive(false);
        }
        else if (suero.Value == 0)
        {
            player1.SetActive(false);            
            player2.SetActive(true);            
        }
    }
}
