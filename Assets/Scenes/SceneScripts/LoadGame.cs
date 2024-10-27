using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadGame : MonoBehaviour
{
    public SceneFade fadeController;
    public string nextSceneName;
    public float delay = 7f;

    void Start()
    {
        StartCoroutine(LoadSceneAfterDelay());
    }

    IEnumerator LoadSceneAfterDelay()
    {

        yield return new WaitForSeconds(delay);
        fadeController.FadeOut();

        SceneManager.LoadScene(nextSceneName);
    }
}
