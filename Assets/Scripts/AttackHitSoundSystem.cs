using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackHitSoundSystem : MonoBehaviour
{
    public AudioSource audioSource;
    public List<AudioClip> audioClips_weakHit;
    public List<AudioClip> audioClips_normalHit;
    public List<AudioClip> audioClips_strongHit;


    public AudioSource audioSource2;
    public List<AudioClip> audioClips_sway;




    public void PlayWeakHit()
    {
        int i = Random.Range(0, audioClips_weakHit.Count);
        AudioClip newAudioClip = audioClips_weakHit[i];

        audioSource.clip = newAudioClip;
        audioSource.Play();
    }

    public void PlayNormalHit()
    {
        int i = Random.Range(0, audioClips_normalHit.Count);
        AudioClip newAudioClip = audioClips_normalHit[i];

        audioSource.clip = newAudioClip;
        audioSource.Play();
    }

    public void PlayStrongHit()
    {
        int i = Random.Range(0, audioClips_strongHit.Count);
        AudioClip newAudioClip = audioClips_strongHit[i];

        audioSource.clip = newAudioClip;
        audioSource.Play();
    }

    public void PlaySway()
    {
        int i = Random.Range(0, audioClips_sway.Count);
        AudioClip newAudioClip = audioClips_sway[i];

        audioSource2.clip = newAudioClip;
        audioSource2.Play();
    }


}
