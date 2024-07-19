using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public  class DamageAction : ActionBase
{
    [SerializeField] private int _damage;
    public override void Execute(object data = null)
    {
        if (data != null)
        {
            if (data is Collision collision)
            {
                collision.gameObject.GetComponent<Health>().TakeDamage(_damage);
            }
            else if (data is Collider collider)
            {
                collider.gameObject.GetComponent<Health>().TakeDamage(_damage);
            }
        }
    }
}
