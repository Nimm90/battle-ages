using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Citizen : Actor
{
    public override ActorStats Stats => _stats;
    private CitizenStats _stats;
}
