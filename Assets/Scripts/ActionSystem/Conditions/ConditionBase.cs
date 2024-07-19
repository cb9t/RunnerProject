using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ConditionBase : MonoBehaviour
{
    public abstract bool Check(object data = null);
}
