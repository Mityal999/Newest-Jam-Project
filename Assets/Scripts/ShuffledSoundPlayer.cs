using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShuffledSoundPlayer : MonoBehaviour
{
    public List<AudioClip> audioClips;
    public AudioSource audioSource;



    public void StartPlaying()
    {
        StartCoroutine("ShuffledPlaying");
    }

    public IEnumerator ShuffledPlaying()
    {
        while (true)
        {
            int i = Random.Range(0, audioClips.Count);
            AudioClip newAudioClip = audioClips[i];

            audioSource.clip = newAudioClip;
            audioSource.Play();

            yield return new WaitForSeconds(newAudioClip.length);
        }
    }

    public void StopPlaying()
    {
        StopCoroutine("ShuffledPlaying");
    }


    public void PlayOnce()
    {
        int i = Random.Range(0, audioClips.Count);
        AudioClip newAudioClip = audioClips[i];

        audioSource.clip = newAudioClip;
        audioSource.Play();
    }


}
