using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class MusicControl : MonoBehaviour
{
    public AudioMixer audioMixer;
    bool soundOn = false;
    
    public void SetVolume(float volume)
    {
        audioMixer.SetFloat("volume", volume);
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
            AudioListener.volume = 1f;
        }
        else
        {
            AudioListener.volume = 0f;
        }
    }
}
