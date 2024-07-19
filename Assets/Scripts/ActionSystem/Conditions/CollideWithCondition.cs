using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollideWithCondition : ConditionBase
{
    [SerializeField] private LayerMask _mask;

    public override bool Check(object data = null)
    {
        if(data == null)
        { 
            return false; 
        }

        if(data is Collision collision)
        {
            return _mask == (_mask | (1 << collision.gameObject.layer));
        }

        if (data is Collider collider)
        {
            return _mask == (_mask | (1 << collider.gameObject.layer));   
        }
        return false;
    }
}
