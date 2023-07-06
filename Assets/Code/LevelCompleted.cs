using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelCompleted : MonoBehaviour
{
    public string sceneName;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (sceneName != null)
            {
                SceneManager.LoadScene(sceneName);
            }
            else
            {
                SceneManager.LoadScene("StartMenuScene");
            }
        }
    }
}
