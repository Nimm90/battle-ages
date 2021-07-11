using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Age : ScriptableObject
{
    [SerializeField] private string ageName;
    [SerializeField] private City[] cities;
    //TODO -> SKILLS / TECHS

    public string AgeName { get => ageName; }
    public City[] Cities { get => cities; }
}
