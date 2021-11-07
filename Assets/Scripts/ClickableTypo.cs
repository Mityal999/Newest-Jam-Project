using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClickableTypo : MonoBehaviour
{
    public Text changingText;
    public GameObject typoscreen;
    public string typoText;


    public void OnRayHit()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            ShowTypo();
        }
    }

    private void ShowTypo()
    {
        typoscreen.GetComponentInChildren<Text>().text = typoText;
        typoscreen.SetActive(true);
        Destroy(gameObject);
    }

}