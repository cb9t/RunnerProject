using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthCondition : ConditionBase
{
    [SerializeField] private Health _health;

    public override bool Check(object data = null)
    {
        return _health.CurrentHealth <= 0;
    }
    
}
