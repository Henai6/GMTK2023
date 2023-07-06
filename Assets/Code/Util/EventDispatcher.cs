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

    public event Action<int> onIndexedEvent;
    public void IndexedEvent(int i)
    {
        onIndexedEvent?.Invoke(i);
    }
}