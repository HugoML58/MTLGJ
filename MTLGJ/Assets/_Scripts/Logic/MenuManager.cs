using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public void GoToMenu()
    {
        SceneManager.LoadSceneAsync(0);
    }

    public void LoadGame()
    {
        SceneManager.LoadSceneAsync(1);
    }

    public void quit()
    {
        Application.Quit();
    }
}
