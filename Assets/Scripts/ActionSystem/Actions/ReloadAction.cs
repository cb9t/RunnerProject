using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReloadAction : ActionBase
{
    [SerializeField] private bool _rockets;
    [SerializeField] private bool _bombs;
    public override void Execute(object data = null)
    {
        if (data != null)
        {
            if (data is Collision collision)
            {
               var target = collision.gameObject.GetComponent<WeaponsController>();
               if (_rockets) target.ReloadRockets();
               if (_bombs) target.ReloadBombs();
            }
            else if (data is Collider collider)
            {
                var target = collider.gameObject.GetComponent<WeaponsController>();
                if (_rockets) target.ReloadRockets();
                if (_bombs) target.ReloadBombs();
            }
        }
    }
}
