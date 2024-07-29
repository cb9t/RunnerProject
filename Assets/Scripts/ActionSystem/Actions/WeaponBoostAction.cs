using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponBoostAction : ActionBase
{ 
    [SerializeField] private float _boostTime;
    public override void Execute(object data = null)
    {
        if (data != null)
        {
            if (data is Collision collision)
            {
                collision.gameObject.GetComponent<WeaponsController>().BulletBoost(_boostTime);
            }
            else if (data is Collider collider)
            {
                collider.gameObject.GetComponent<WeaponsController>().BulletBoost(_boostTime);
            }
            
        }
    }
    //private IEnumerator BulletBoost(GameObject gameObject)
    //{
    //    gameObject.GetComponent<WeaponsController>().isBulletBoost = true;
    //
    //    yield return new WaitForSeconds(_boostTime);
    //
    //    gameObject.GetComponent<WeaponsController>().isBulletBoost = false;
    //
    //    StopCoroutine(BulletBoost(gameObject));
    //}
}
