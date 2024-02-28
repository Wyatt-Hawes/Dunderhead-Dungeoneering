using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class VolumeController : MonoBehaviour
{
    [SerializeField] private AudioMixer myMixer;
    [SerializeField] private Slider volumeBar;

    public void Start()
    {
        volumeBar.value = PlayerPrefs.GetFloat("volume");
        float volume = volumeBar.value;
        myMixer.SetFloat("vol", volume);
    }

    public void volumeControl()
    {
        float volume = volumeBar.value;
        myMixer.SetFloat("vol", volume);
        PlayerPrefs.SetFloat("volume", volume);
    }
}
