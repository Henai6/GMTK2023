using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreTest : MonoBehaviour
{
    public void AddOne()
    {
        ScoringManager.Instance.AddScore(1);
    }

    public void AddTen()
    {
        ScoringManager.Instance.AddScore(10);
    }
    public void Clear()
    {
        ScoringManager.Instance.ClearScore();
    }
    public void Lost1hp()
    {
        ScoringManager.Instance.LostHealth();
    }
}
