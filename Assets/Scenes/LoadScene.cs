using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour
{
    public bool AsAdditive = false;
    
    public void Load(string nameScene)
    {
        SceneManager.LoadScene(nameScene, AsAdditive ? LoadSceneMode.Additive : LoadSceneMode.Single);
    }
}
