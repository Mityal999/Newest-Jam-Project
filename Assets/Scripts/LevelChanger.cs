using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelChanger : MonoBehaviour
{
   

    public void FadeToNextLevel()
    {
        FadeToLevel(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void FadeToCurrentLevel()
    {
        FadeToLevel(SceneManager.GetActiveScene().buildIndex);
    }

    public void FadeToLevel(int levelIndex)
    {
        SceneManager.LoadScene(levelIndex);
    }

}
