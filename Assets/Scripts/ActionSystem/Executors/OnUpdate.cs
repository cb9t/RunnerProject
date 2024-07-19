using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnUpdate : ExecutorBase
{
    [SerializeField] ConditionBase _conditionSecond;
    private void FixedUpdate()
    {
        if (_conditionSecond == null || _conditionSecond.Check()) Execute(gameObject);
    }
    
}
