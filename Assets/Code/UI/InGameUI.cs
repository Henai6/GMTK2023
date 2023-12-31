using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InGameUI : MonoBehaviour
{
    public GameObject gameOverPanel;
    public GameObject pausePanel;
    public GameObject quitButton;
    public GameObject sureButton;
    public GameObject cancelButton;
    public void RetryGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("TetrisGameScene");
    }
    public void BackToStartMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("StartMenuScene");
    }
    public void QuitButton()
    {
        sureButton.SetActive(true);
        cancelButton.SetActive(true);
        quitButton.SetActive(false);
    }

    public void SureButton()
    {
        Time.timeScale = 0f;
        gameOverPanel.SetActive(true);
    }

    public void CancelButton()
    {
        Time.timeScale = 1f;
        pausePanel.SetActive(false);

        sureButton.SetActive(false);
        cancelButton.SetActive(false);
        quitButton.SetActive(true);

    }

    public void PauseButton()
    {
        Time.timeScale = 0f;
        pausePanel.SetActive(true);
    }
}
