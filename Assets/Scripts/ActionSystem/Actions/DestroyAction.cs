using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyAction : ActionBase
{
    [SerializeField] private GameObject _objectToDestroy;
    [SerializeField] private float _timeToDestroy;

    public override void Execute(object data = null)
    {
        Destroy(_objectToDestroy, _timeToDestroy);
    }
}
