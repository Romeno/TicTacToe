using UnityEngine;
using System.Collections;


public static class AudioUtil
{
    public static IEnumerator FadeOut(AudioSource audioSource, float fadeTime)
    {
        float startVolume = audioSource.volume;

        while (audioSource.volume > 0)
        {
            audioSource.volume -= startVolume * Time.deltaTime / fadeTime;

            yield return null;
        }

        audioSource.Stop();
        audioSource.volume = startVolume;
    }

    public static IEnumerator FadeIn(AudioSource audioSource, float fadeTime, float newVolume = 1.0f)
    {
        audioSource.volume = 0;
        audioSource.Play();

        while (true)
        {
            audioSource.volume += newVolume * Time.deltaTime / fadeTime;
            if (audioSource.volume >= newVolume)
            {
                audioSource.volume = newVolume;
                break;
            }

            yield return null;
        }
    }
}



