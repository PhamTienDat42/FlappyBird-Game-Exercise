using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class MusicControl : MonoBehaviour
{
    [SerializeField] private AudioMixer audioMixer;
    private bool soundOn = false;
    private const string volumee = "volume";
    
    public void SetVolume(float volume)
    {
        audioMixer.SetFloat(volumee, volume);
    }

    public void OnSound()
    {
        AudioListener.volume = 1f;
        soundOn = true;
    }

    public void OffSound()
    {
        AudioListener.volume = 0f;
        soundOn = false;
    }

    public void SoundPlay()
    {
        if(soundOn == true)
        {
            AudioSource a = new AudioSource();
            a.Play();
        }
        else
        {         
            AudioSource a = new AudioSource();
            a.Pause();
        }
    }
}
