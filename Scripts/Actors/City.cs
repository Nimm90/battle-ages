using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class City : Actor
{
    public override ActorStats Stats => _stats;
    [SerializeField] private CityStats _stats;

    private void OnMouseDown()
    {
        if (CurrentLife <= 0) return;

        Interact();
        TakeDamage(this, 1);
    }
}
