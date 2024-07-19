using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HideObject : ActionBase
{
    [SerializeField] private Vector3 _hidePosition;

    public override void Execute(object data = null)
    {
        gameObject.transform.position = _hidePosition;
    }
}