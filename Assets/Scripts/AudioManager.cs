using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioClip[] playlist;
    public AudioSource audioSource;

    private int musicIndex = 0;

    public void Start()
    {
        audioSource.clip = playlist[musicIndex];
        audioSource.Play();
    }

    public void Update()
    {
        if (!audioSource.isPlaying)
        {
            PlayNextSong();
        }
    }

    public void PlayNextSong()
    {
        musicIndex = (musicIndex + 1) % playlist.Length;
        audioSource.clip = playlist[musicIndex];
        audioSource.Play();
    }
}