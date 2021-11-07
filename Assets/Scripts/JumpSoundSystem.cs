using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpSoundSystem : MonoBehaviour
{
    public AudioSource audioSource;
    public List<AudioClip> audioClips_jump;

    private DynamicSoundSystem dynamicSoundSystem;

    private void Start()
    {
        dynamicSoundSystem = FindObjectOfType<DynamicSoundSystem>();
    }


    public void PlayJumpSound()
    {
        dynamicSoundSystem.OnJumpStarted();

        int i = Random.Range(0, audioClips_jump.Count);
        AudioClip newAudioClip = audioClips_jump[i];

        audioSource.clip = newAudioClip;
        audioSource.Play();
    }



}
