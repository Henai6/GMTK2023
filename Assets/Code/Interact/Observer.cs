using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Observer Pattern
public abstract class Observer : MonoBehaviour
{
    public int eventIndex;
    private void OnEnable()
    {
        EventDispatcher.Instance.onIndexedEvent += EventCall;
    }
    private void OnDisable()
    {
        EventDispatcher.Instance.onIndexedEvent -= EventCall;
    }
    protected virtual void EventCall(int i)
    {
        if (i != eventIndex) return;
    }
}