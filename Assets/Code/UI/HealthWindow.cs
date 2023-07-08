using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HealthWindow : MonoBehaviour
{
    public GameObject hp3;
    public GameObject hp2;
    public GameObject hp1;
    private void OnEnable()
    {
        EventDispatcher.Instance.onIndexedEvent += HealthChanged;
    }
    private void OnDisable()
    {
        EventDispatcher.Instance.onIndexedEvent -= HealthChanged;
    }
    public void HealthChanged(int i)
    {
        if (ScoringManager.Instance.GetHealth()==3)
        {
            hp3.SetActive(false); hp2.SetActive(false); hp1.SetActive(false);
        }
        else if (ScoringManager.Instance.GetHealth() == 2)
        {
            hp3.SetActive(true); hp2.SetActive(false); hp1.SetActive(false);
        }
        else if (ScoringManager.Instance.GetHealth() == 1)
        {
            hp3.SetActive(true); hp2.SetActive(true); hp1.SetActive(false);
        }
        else
        {
            hp3.SetActive(true); hp2.SetActive(true); hp1.SetActive(true);
            Debug.Log("Game Over");
        }
    }
}