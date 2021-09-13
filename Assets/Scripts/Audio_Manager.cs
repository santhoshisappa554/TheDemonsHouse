using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Audio_Manager : MonoBehaviour
{
    public Sound[] sounds;
    public static Audio_Manager instance;
    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }
        foreach (Sound item in sounds)
        {
            item.audioSource = gameObject.AddComponent<AudioSource>();
            item.audioSource.clip = item.audioClip;
            item.audioSource.volume = item.volume;
            item.audioSource.pitch = item.pitch;
            item.audioSource.loop = item.audioLoop;
        }
    }
    public void PlayAudio(string name)
    {
        Sound s = Array.Find(sounds, Sound => Sound.audioName == name);
        if (s == null)
        {
            Debug.LogWarning("Audio name" + name + "Not found");
            return;
        }
        s.audioSource.Play();
    }
    public void StopPlayAudio(string name)
    {
        Sound s = Array.Find(sounds, Sound => Sound.audioName == name);
        if (s == null)
        {
            Debug.LogWarning("Audio name" + name + "Not found");
            return;
        }
        s.audioSource.Stop();
    }
    public void SetVolume(String name, float volumeValue)
    {
        Sound s = Array.Find(sounds, Sound => Sound.audioName == name);
        if (s == null)
        {
            Debug.LogWarning("Audio name" + name + "Not found");
            return;
        }
        else
        {
            s.audioSource.volume = volumeValue;
        }
    }
}
