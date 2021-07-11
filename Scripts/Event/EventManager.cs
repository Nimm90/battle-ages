using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager : MonoBehaviour
{
    private List<IEvent> queuedEvents = new List<IEvent>();
    private List<IEvent> events = new List<IEvent>();

    private int maxUndo = 20;
    private IEvent currentEvent;

    public static EventManager instance;

    private void Awake()
    {
        //SINGLETON
        if (instance != null) Destroy(gameObject);
        else instance = this;
    }

    private void Update()
    {
        for (int i = queuedEvents.Count - 1; i > 0; i--)
        {
            StartCoroutine(ProcessEvent(queuedEvents[i]));
        }
    }

    private IEnumerator ProcessEvent(IEvent e)
    {
        float eventProcessingTime = 0f;

        while (eventProcessingTime <= e.Timeout)
        {
            eventProcessingTime += Time.deltaTime;

            e.Do();

            yield return null;
        }

        if(queuedEvents.Contains(e)) RemoveEventFromQueue(e);
    }

    public void CompleteEvent(IEvent e)
    {
        int index = events.IndexOf(currentEvent);
        events.RemoveRange(index + 1, events.Count - index - 1);

        events.Add(e);
        currentEvent = e;

        if (events.Count > maxUndo) events.RemoveAt(0);
    }

    public void QueueEvent(IEvent e)
    {
        queuedEvents.Add(e);
    }

    public void RemoveEventFromQueue(IEvent e)
    {
        if (events.Count == 0) return;

        if (e == currentEvent)
        {
            if (events.Count > 1)
                currentEvent = events[events.IndexOf(currentEvent) - 1];
            else currentEvent = null;
        }

        queuedEvents.Remove(e);
    }

    public void Undo()
    {
        events[events.IndexOf(currentEvent)].Undo();
    }
}
