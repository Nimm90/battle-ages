using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventDie : CustomEvent
{
    private Actor _actor;
    public Actor Actor { get => _actor; }

    public EventDie(Actor actor,
        int priority = DEFAULT_PRIORITY, float timeout = DEFAULT_TIMEOUT) : base(priority, timeout)
    {
        _actor = actor;
    }
}
