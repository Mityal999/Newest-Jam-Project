using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayer : MonoBehaviour
{
    public bool playOnAwake;

    private AudioSource _audioSource;


    

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
        _audioSource = GetComponent<AudioSource>();

        if (playOnAwake)
        {
            PlayMusic();
        }
    }

    public void PlayMusic()
    {
        if (_audioSource.isPlaying) return;

        _audioSource.Play();
    }

    public void StopMusic()
    {
        _audioSource.Stop();
    }
}
