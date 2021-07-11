using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventTakeDamage : CustomEvent
{
    public int Damage { get => _damage; }
    private int _damage;

    public Actor Victim { get => _victim; }
    public Actor Perpetrator { get => _perpetrator; }
    private Actor _victim, _perpetrator;

    public EventTakeDamage(Actor victim, Actor perpetrator, int damage,
        int priority = DEFAULT_PRIORITY, float timeout = DEFAULT_TIMEOUT) : base(priority, timeout)
    {
        _victim = victim;
        _perpetrator = perpetrator;
        _damage = damage;
    }
}
