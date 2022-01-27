using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lev3Triggwe : MonoBehaviour
{
    public AudioClip newAudioClip;

    public GameObject bossObj;
    public GameObject turnAround;

    public float volume;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            MusicPlayer musicPlayer = FindObjectOfType<MusicPlayer>();
            musicPlayer.ChangeMusic(newAudioClip);
            musicPlayer.ChangeVolume(volume);


            bossObj.SetActive(true);
            turnAround.SetActive(true);


            Destroy(turnAround, 1f);
            Destroy(gameObject, 1f);
        }
    }
}
