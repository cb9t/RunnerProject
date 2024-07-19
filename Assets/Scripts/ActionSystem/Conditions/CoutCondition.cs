using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoutCondition : ConditionBase
{
    [SerializeField] private int _count;

    public override bool Check(object data  = null)
    {
        return _count-- > 0;
    }
}
