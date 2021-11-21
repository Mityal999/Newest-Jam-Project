using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lev3Triggwe : MonoBehaviour
{
    public AudioClip newAudioClip;

    public GameObject bossObj;
    public GameObject turnAround;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            MusicPlayer musicPlayer = FindObjectOfType<MusicPlayer>();
            musicPlayer.ChangeMusic(newAudioClip);


            bossObj.SetActive(true);
            turnAround.SetActive(true);


            Destroy(turnAround, 2f);
            Destroy(gameObject, 2f);
        }
    }
}
