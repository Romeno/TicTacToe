using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class SettingsView : MonoBehaviour
{
    #region PlayerActions

    public void SoundChanged(float value)
    {
        mainMixer.SetFloat("soundVolume", Mathf.Log10(value) * 20);
    }

    public void MusicChanged(float value)
    {
        mainMixer.SetFloat("musicVolume", Mathf.Log10(value) * 20);
    }

    #endregion

    public AudioMixer mainMixer;
}

