using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AudioFader : MonoBehaviour
{
    public AudioSource audioSource; // Assign your audio source in the inspector
    public float fadeDuration = 2.0f; // Duration for both fade-in and fade-out

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

        // Gradually reduce volume to zero
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
        // Only start playing if the audio is not already playing
        if (!audioSource.isPlaying)
        {
            audioSource.volume = 0; // Start volume at zero for fade-in
            audioSource.Play(); // Start playing the audio source
        }

        // Gradually increase volume to its original level
        for (float t = 0; t < fadeDuration; t += Time.deltaTime)
        {
            audioSource.volume = Mathf.Lerp(0, 0.5f, t / fadeDuration);
            yield return null;
        }

        audioSource.volume = 0.5f; // Ensure volume is fully restored
    }
}
