using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class Sound
{

    public string audioName;
    public AudioClip audioClip;
    [Range(0, 1f)]
    public float volume;
    [Range(0f, 1f)]
    public float pitch;
    [HideInInspector]
    public AudioSource audioSource;
    public bool audioLoop;



}