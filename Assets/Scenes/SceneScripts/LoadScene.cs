using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour
{
    public SceneFade fadeController;
    public bool AsAdditive = false;

    public void Load(string sceneName)
    {
        fadeController.FadeOut();
        
        StartCoroutine(LoadSceneAfterFadeOut(sceneName));
    }

    private IEnumerator LoadSceneAfterFadeOut(string nameScene)
    {
        yield return new WaitForSeconds(2f);

        SceneManager.LoadScene(nameScene, AsAdditive ? LoadSceneMode.Additive : LoadSceneMode.Single);
    }
}
