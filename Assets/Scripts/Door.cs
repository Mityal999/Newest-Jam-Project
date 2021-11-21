using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Door : MonoBehaviour
{
    public int levelIndex;

    private LevelChanger levelChanger;

    private void Start()
    {
        levelChanger = FindObjectOfType<LevelChanger>();
    }


    private void OnTriggerEnter(Collider other)
    {        
        if(other.CompareTag("Player"))
        {
            levelChanger.FadeToLevel(levelIndex);
        }
    }

}
