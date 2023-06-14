using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class MusicControl : MonoBehaviour
{
    [SerializeField] private AudioMixer audioMixer;
    private bool soundOn = false;
    private const string volumee = "volume";
    [SerializeField] private AudioSource BGMusic;
    
    public void SetVolume(float volume)
    {
        audioMixer.SetFloat(volumee, volume);
    }

    public void OnSound()
    {
        AudioListener.volume = 1f;
        //AudioSource a = new AudioSource();
        //a.Play();
        BGMusic.Play();
        soundOn = true;
        PlayerPrefs.SetInt("SoundOn", 1);
    }

    public void OffSound()
    {
        BGMusic.Pause();
        soundOn = false;
        PlayerPrefs.SetInt("SoundOn", 0);
    }
}
