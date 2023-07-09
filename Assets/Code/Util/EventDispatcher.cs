using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Observer Pattern

public class EventDispatcher
{
    private static EventDispatcher instance;
    private EventDispatcher() { }
    public static EventDispatcher Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new EventDispatcher();
            }
            return instance;
        }
    }

    //0 = lostHealth, 1 = getHealth (for these two, plz use ScoringManager.Instance.LostHealth()/GetHealth()),
    //2 = pieces attached, 3 = OnTick, 4 = line completed, 5 = gameover
    public event Action<int> onIndexedEvent;
    public void IndexedEvent(int i)
    {
        onIndexedEvent?.Invoke(i);
    }

    //1 = left; 0 = up; 3 = right; 2 = down;
    public event Action<int> onMoveEvent;
    public void MoveEvent(int i)
    {
        onMoveEvent?.Invoke(i);
    }

    public event Action onAllMoveEvent;
    public void AllMoveEvent()
    {
        //for(int i=0; i<4; i++) onMoveEvent?.Invoke(i);
        onAllMoveEvent?.Invoke();
    }


}