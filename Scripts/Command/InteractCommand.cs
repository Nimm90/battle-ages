using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractCommand : IFeedbackCommand
{
    protected Actor _owner;

    public GameObject Feedback => _feedbackInteraction;
    protected GameObject _feedbackSelfInteraction, _feedbackInteraction;

    protected bool _canInteractWithSelf = false;
    public bool CanInteractWithSelf { get => _canInteractWithSelf; }

    public InteractCommand(Actor owner, GameObject feedbackInteraction, bool canInteractWithSelf)
    {
        _owner = owner;
        _feedbackInteraction = feedbackInteraction;
        _feedbackSelfInteraction = feedbackInteraction;
        _canInteractWithSelf = canInteractWithSelf;
    }

    public InteractCommand(Actor owner, GameObject feedbackInteraction, GameObject feedbackSelfInteraction, bool canInteractWithSelf)
    {
        _owner = owner;
        _feedbackInteraction = feedbackInteraction;
        _feedbackSelfInteraction = feedbackSelfInteraction;
        _canInteractWithSelf = canInteractWithSelf;
    }

    public void Execute()
    {
        if (_feedbackInteraction != null)
            GameObject.Instantiate(_feedbackInteraction, _owner.transform.position, Quaternion.identity);
        else
            Debug.LogWarning($"No interaction feedback for {_owner.name}!");
    }

    public void Execute(Actor interactor)
    {
        if(_canInteractWithSelf && interactor == _owner)
        {
            if(_feedbackSelfInteraction != null)
                GameObject.Instantiate(_feedbackSelfInteraction, _owner.transform.position, Quaternion.identity);
            else
                Debug.LogWarning($"No SELF interaction feedback for {_owner.name}!");
        }
        else Execute();
    }
}
