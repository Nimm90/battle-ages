using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Citizen", menuName = "Scriptable Object/Actor/Citizen", order = 1)]
public class CitizenStats : ActorStats
{
    [SerializeField] private float movementSpeed = 5f;
    [SerializeField] private float rotationSpeed = 5f;

    public float MovementSpeed { get => movementSpeed; }
    public float RotationSpeed { get => rotationSpeed; }
}
