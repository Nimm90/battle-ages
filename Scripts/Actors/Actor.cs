using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Actor : MonoBehaviour, ISubject, IInteractable
{
    public abstract ActorStats Stats { get; }

    [SerializeField] private int ownerID = -1;
    public int OwnerID { get => ownerID; set => Debug.Log("Owner ID Logic not implemented!"); }

    private int currentLife = 100;
    public int CurrentLife { get => currentLife; set => currentLife = value; }

    //COMMANDS
    private DieCommand _dieCommand;
    private InteractCommand _interactCommand;

    protected virtual void Awake()
    {
        currentLife = Stats.MaxLife;
    }

    protected virtual void Start()
    {
        //COMMANDS
        _dieCommand = new DieCommand(this, Stats.DieFeedback);
        _interactCommand = new InteractCommand(this, Stats.InteractFeedback, Stats.SelfInteractFeedback);
    }

    public void TakeDamage(Actor attacker, int damage)
    {
        if (CurrentLife <= 0) return;

        CurrentLife -= damage;
        AddEvent(new EventTakeDamage(this, attacker, damage, 0, 0.1f));

        //TAKE DAMAGE COMMAND?
        //GameObject.Instantiate(Stats.TakeDamageFeedback, transform.position, Quaternion.identity);

        if (CurrentLife <= 0)
        {
            AddEvent(new EventDie(this));
            _dieCommand.Execute();
        }
    }

    #region Event Queue

    public void AddEvent(IEvent e)
    {
        EventManager.instance?.QueueEvent(e);
        Notify(e);
    }

    #endregion

    #region Observer

    public List<IObserver> Observers => _observers;
    private List<IObserver> _observers = new List<IObserver>();

    public void Notify(IEvent ev)
    {
        foreach (var observer in _observers)
            observer.OnNotify(this, ev);
    }

    public void AddObserver(IObserver observer)
    {
        _observers.Add(observer);
    }

    public void RemoveObserver(IObserver observer)
    {
        _observers.Remove(observer);
    }

    #endregion

    public void Interact()
    {
        _interactCommand.Execute();
    }
}
