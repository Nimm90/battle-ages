using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class CustomEvent : IEvent
{
    public const int DEFAULT_PRIORITY = 0;
    public const float DEFAULT_TIMEOUT = 0.005f;

    public int Priority => _priority;
    protected int _priority;

    public float Timeout { get => _timeout; }
    protected float _timeout;

    public CustomEvent(int priority = DEFAULT_PRIORITY, float timeout = DEFAULT_TIMEOUT)
    {
        _priority = priority;
        _timeout = timeout;
    }

    public void Do()
    {
        Debug.Log("Processing Event: " + this);

        //IF EVENT COMPLETE
        EventManager.instance.CompleteEvent(this);
    }

    public void Undo()
    {
        Debug.Log("Undid Event: " + this);
    }
}
