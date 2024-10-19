using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadLevel : MonoBehaviour
{
    public Animator transition;
    public float transitionTime = 1f;
    
    public void LoadNextLevel(string sceneName)
    {
        StartCoroutine(LoadTransition(sceneName));
    }

    IEnumerator LoadTransition(string sceneName)
    {
        transition.SetTrigger("start");
        yield return new WaitForSeconds(transitionTime);
        SceneManager.LoadScene(sceneName);
    }
}
