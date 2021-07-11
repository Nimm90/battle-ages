using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Enemy", menuName = "Scriptable Object/Actor/Enemy", order = 2)]
public class EnemyStats : ActorStats
{
    [SerializeField] private List<GameObject> drops;
    [SerializeField] private int experience;

    public List<GameObject> Drops { get => drops; }
    public int Experience { get => experience; }
}

