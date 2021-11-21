using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayerChanger : MonoBehaviour
{
    public AudioClip newAudioClip;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            MusicPlayer musicPlayer = FindObjectOfType<MusicPlayer>();
            musicPlayer.ChangeMusic(newAudioClip);

            Destroy(gameObject, 1f);
        }
    }

}
