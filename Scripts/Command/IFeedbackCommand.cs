using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IFeedbackCommand : ICommand
{
    GameObject Feedback { get; }
}
