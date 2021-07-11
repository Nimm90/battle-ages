using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCommand : ICommand
{
    private Transform _target;
    private Vector3 _direction;
    private float _speed;

    public MoveCommand(Transform target, Vector3 direction, float speed)
    {
        _target = target;
        _direction = direction;
        _speed = speed;
    }

    public void Execute()
    {
        _target.position += _direction * _speed * Time.deltaTime;
    }
}
