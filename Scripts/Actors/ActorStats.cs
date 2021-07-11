using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActorStats : ScriptableObject
{
    [SerializeField] private int maxLife = 100;
    [SerializeField] private GameObject interactFeedback, selfInteractFeedback, takeDamageFeedback, dieFeedback;

    public int MaxLife { get => maxLife; }
    public GameObject InteractFeedback { get => interactFeedback; }
    public GameObject SelfInteractFeedback { get => selfInteractFeedback; }
    public GameObject TakeDamageFeedback { get => takeDamageFeedback; }
    public GameObject DieFeedback { get => dieFeedback; }
}
