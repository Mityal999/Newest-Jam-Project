using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class WinScreenLoadMenu : MonoBehaviour
{
    public void LoadMenu()
    {
        MusicPlayer musicPlayer = FindObjectOfType<MusicPlayer>();
        Destroy(musicPlayer.gameObject);

        Cursor.visible = true;

        SceneManager.LoadScene(0);
    }
}
