using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ISubject
{
    List<IObserver> Observers { get; }

    void Notify(IEvent ev);

    void AddObserver(IObserver observer);
    void RemoveObserver(IObserver observer);
}
