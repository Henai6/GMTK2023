using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool isGamePaused = false;
    public GameObject pausePanel;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isGamePaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    public void Resume()
    {
        Cursor.visible = false;
        pausePanel.SetActive(false);
        Time.timeScale = 1;
        isGamePaused = false;
    }

    public void Pause()
    {
        Cursor.visible = true;
        pausePanel.SetActive(true);
        Time.timeScale = 0;
        isGamePaused = true;
    }

    public static void ExitGame()
    {
        Application.Quit();
    }

    public void RetryLevel()
    {
        Cursor.visible = false;
        pausePanel.SetActive(false);
        Time.timeScale = 1;
        isGamePaused = false;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
