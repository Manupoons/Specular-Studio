using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AudioFader : MonoBehaviour
{
    public AudioSource audioSource;
    public float fadeDuration = 2.0f;

    public void FadeOut()
    {
        StartCoroutine(FadeOutAudio());
    }

    public void FadeIn()
    {
        StartCoroutine(FadeInAudio());
    }

    private IEnumerator FadeOutAudio()
    {
        float startVolume = audioSource.volume;

        for (float t = 0; t < fadeDuration; t += Time.deltaTime)
        {
            audioSource.volume = Mathf.Lerp(startVolume, 0, t / fadeDuration);
            yield return null;
        }

        audioSource.volume = 0;
        audioSource.Stop();
    }

    private IEnumerator FadeInAudio()
    {
        if (!audioSource.isPlaying)
        {
            audioSource.volume = 0;
            audioSource.Play();
        }

        for (float t = 0; t < fadeDuration; t += Time.deltaTime)
        {
            audioSource.volume = Mathf.Lerp(0, 0.5f, t / fadeDuration);
            yield return null;
        }

        audioSource.volume = 0.5f;
    }
}
