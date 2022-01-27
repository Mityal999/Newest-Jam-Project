using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayerChanger : MonoBehaviour
{
    public AudioClip newAudioClip;
    public float volume;

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            MusicPlayer musicPlayer = FindObjectOfType<MusicPlayer>();
            musicPlayer.ChangeMusic(newAudioClip);
            musicPlayer.ChangeVolume(volume);

            Destroy(gameObject);
        }
    }

}
