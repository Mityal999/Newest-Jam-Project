using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Door : MonoBehaviour
{
    [SerializeField] private string level2;
    [SerializeField] private GameObject uiElement;

    private void OnTriggerEnter(Collider other)
    {
        
        
        if(other.CompareTag("Player"))
        {
            uiElement.SetActive(true);
            

            if (Input.GetKeyDown(KeyCode.E))
            {
                SceneManager.LoadScene(level2);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            uiElement.SetActive(false);
        }
    }
}
