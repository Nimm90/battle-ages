using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DieCommand : IFeedbackCommand
{
    protected Actor _actor;

    public GameObject Feedback => _feedback;
    protected GameObject _feedback;

    public DieCommand(Actor actor, GameObject feedback)
    {
        _actor = actor;
        _feedback = feedback;
    }

    public virtual void Execute()
    {
        GameObject.Instantiate(_feedback);
        GameObject.Destroy(_actor.gameObject);
    }
}
