using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    public int selectedLevel;
    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void SelectLevel(int level)
    {
        SceneManager.LoadScene(level);
    }

    public void QuitGame()
    {
        print("Quit Game!");
        Application.Quit();
    }
}
