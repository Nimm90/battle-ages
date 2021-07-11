using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IEvent
{
    int Priority { get; }
    float Timeout { get; }

    void Do();
    void Undo();
}
