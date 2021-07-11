using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Factory;

public class SpawnerSprite : Spawner
{
    public GameObject Create(Sprite sprite, Transform parent, string name = "Sprite")
    {
        GameObject c = new GameObject(name);
        c.AddComponent<SpriteRenderer>().sprite = sprite;
        c.transform.parent = parent;
        c.transform.localPosition = Vector3.zero;

        return c;
    }
}
