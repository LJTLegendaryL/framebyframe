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
        if (level != 0)
            SceneManager.LoadScene("Level " + level.ToString());
        else
            SceneManager.LoadScene("Main Menu");
    }

    public void QuitGame()
    {
        print("Quit Game!");
        Application.Quit();
    }

    public void checkPanels()
    {
        print("Checking Panels");
    }

    public void Settings()
    {
        print("Go to settings");
    }
}
