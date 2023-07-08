using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoringManager
{
    private static ScoringManager instance;
    public static ScoringManager Instance => instance ?? (instance = new ScoringManager());
    private ScoringManager() { }

    private int _score;
    public int GetScore()
    {
        return _score;
    }
    public void AddScore(int s)
    {
        _score += s;
    }
    public void ClearScore()
    {
        _score = 0;
    }
}
