using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseCaster : MonoBehaviour
{
    public GameObject pauseCanvas;

    private CursorController cursorController;

    private bool isPaused = false;



    private void Start()
    {
        cursorController = FindObjectOfType<CursorController>();
    }


    public void PauseGame()
    {
        Time.timeScale = 0;
        pauseCanvas.SetActive(true);
        cursorController.EnableCursor();
        isPaused = true;
    }

    public void ResumeGame()
    {
        Time.timeScale = 1;
        pauseCanvas.SetActive(false);
        cursorController.DisableCursor();
        isPaused = false;
    }

    public void ResumeToMenu()
    {
        Time.timeScale = 1;
        pauseCanvas.SetActive(false);
        cursorController.EnableCursor();
        isPaused = false;
    }


    private void Update()
    {
        if (!isPaused & Input.GetKeyDown(KeyCode.Escape))
        {
            PauseGame();
        }
        else if (isPaused & Input.GetKeyDown(KeyCode.Escape))
        {
            ResumeGame();
        }
    }

}
