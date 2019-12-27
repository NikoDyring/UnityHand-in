using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using  UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField]
    private GameObject optionsWindow;
    [SerializeField]
    private GameObject mainWindow;

    public void PlayGame()
    {
        SceneManager.LoadScene("Level_01");
    }

    public void OpenOptions()
    {
        mainWindow.SetActive(false);
        optionsWindow.SetActive(true);
    }

    public void SaveOptions()
    {
        // TODO: Implement Playerprefs here.
        optionsWindow.SetActive(false);
        mainWindow.SetActive(true);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
