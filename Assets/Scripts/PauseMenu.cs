using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool gameIsPaused = false;

    public GameObject pauseMenuUI;
    public GameObject settingsWindow;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if(gameIsPaused)
            {
                Resume();
            }
            else
            {
                Paused();
            }

        }
    }

    public void Resume()
    {
        PlayerMovement.instance.enabled = true;
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1.0f;
        gameIsPaused = false;
    }
 
    private void Paused()
    {
        // Empeche les mouvements du joueur
        PlayerMovement.instance.enabled = false;
        pauseMenuUI.SetActive(true);
        // stoppe le temps
        Time.timeScale = 0;
        gameIsPaused = true;
    }

    public void OpenSettingsWindow()
    {
        this.settingsWindow.SetActive(true);
    }

    public void CloseSettingsWindow()
    {
        this.settingsWindow.SetActive(false);
    }

    public void loadMainMenu()
    {
        DontDestroyOnLoadScene.instance.RemoveFromDontDestroyOnLoad();
        Resume();
        SceneManager.LoadScene("MainMenu");
    }
}
