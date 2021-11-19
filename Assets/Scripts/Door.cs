using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Door : MonoBehaviour
{
    [SerializeField] private string nextSceneStr;
    //[SerializeField] private GameObject uiElement;

    private void OnTriggerEnter(Collider other)
    {
        
        
        if(other.CompareTag("Player"))
        {
            //uiElement.SetActive(true)
            

            if (true)
            {
                SceneManager.LoadScene(nextSceneStr);
            }
        }
    }

    //private void OnTriggerExit(Collider other)
    //{
    //    if(other.CompareTag("Player"))
    //    {
    //        uiElement.SetActive(false);
    //    }
    //}
}
