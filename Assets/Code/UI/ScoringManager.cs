using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoringManager
{
    private static ScoringManager instance;
    public static ScoringManager Instance => instance ?? (instance = new ScoringManager());
    private ScoringManager() { _health = 3; _score = 0; }

    private int _score;
    private int _health;
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
    public int GetHealth()
    {
        EventDispatcher.Instance.IndexedEvent(1);
        return _health;
    }
    public void LostHealth()
    {
        _health -= 1;
        EventDispatcher.Instance.IndexedEvent(0);
    }
    public void ReplenshHealth()
    {
        _health += 1;
        _health = Mathf.Min(_health, 3);
        EventDispatcher.Instance.IndexedEvent(1);
    }
}
