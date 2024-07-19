using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealAction : ActionBase
{
    public override void Execute(object data = null)
    {
        if (data != null)
        {
            if (data is Collision collision)
            {
                collision.gameObject.GetComponent<Health>().Heal();
            }
            else if (data is Collider collider)
            {
                collider.gameObject.GetComponent<Health>().Heal();
            }
        }
    }
}
