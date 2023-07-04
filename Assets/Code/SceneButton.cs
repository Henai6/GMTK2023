using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class SceneButton : MonoBehaviour, IPointerClickHandler
{
    public string sceneName;

    public void OnPointerClick(PointerEventData eventData)
    {
        if (sceneName == null)
        {
            Debug.LogWarning("This button is not configured " + this.name);
        }
        else
        {
            SceneManager.LoadScene(sceneName);
        }
    }
}
