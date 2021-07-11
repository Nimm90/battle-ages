using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoDestroy : MonoBehaviour
{
    [SerializeField] private float _lifetime = 1f;

    private void Update()
    {
        _lifetime -= Time.deltaTime;

        if (_lifetime <= 0) Destroy(gameObject);
    }
}
