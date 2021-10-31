using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioSource source;

    public AudioClip maintheme;
    
    private string MUSICVOLUME = "MusicVolume";

    private float MusicVolume
    {
        get => PlayerPrefs.GetFloat(MUSICVOLUME,1);
        set => PlayerPrefs.SetFloat(MUSICVOLUME,value);
    }

    public void Play(AudioClip clip, bool loop = true)
    {
        source.clip = clip;
        source.loop = loop;
        source.volume = MusicVolume;
        source.Play();
    }

    public void Stop()
    {
        source.Stop();
    }

    public void PlayMainTheme()
    {
        Play(maintheme);
    }
}
