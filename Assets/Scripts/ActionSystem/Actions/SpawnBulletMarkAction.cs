using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;

public class SpawnBulletMarkAction : ActionBase
{
    [SerializeField] private GameObject _prefab;
    [SerializeField] private bool _inverNormal;
    [SerializeField] private bool _parentMarkToHiteedObject;
    [SerializeField] private float _timeToDestroy;
    [SerializeField] private LayerMask _ignorMask;
    private GameObject _instance;


    public override void Execute(object data = null)
    {
        if (data != null)
        {
            if (data is Collision collision)
            {
                if (_ignorMask != (_ignorMask | (1 << collision.gameObject.layer)))
                {
                    var contactPoint = collision.GetContact(0);
                    var rotation = Quaternion.LookRotation(_inverNormal ? -contactPoint.normal : contactPoint.normal);
                    _instance = Instantiate(_prefab, contactPoint.point, rotation);

                    if (_parentMarkToHiteedObject)
                    {
                        _instance.transform.SetParent(collision.transform);
                    }
                }
                
            }
            else if (data is Collider collider)
            {
                if (_ignorMask != (_ignorMask | (1 << collider.gameObject.layer)))
                {
                    var contactPoint = collider.ClosestPoint(transform.position);
                    var conractDirection = (transform.position - contactPoint).normalized;
                    var rotation = Quaternion.LookRotation(_inverNormal ? -conractDirection : conractDirection);
                    _instance = Instantiate(_prefab, contactPoint, rotation);

                    if (_parentMarkToHiteedObject)
                    {
                        _instance.transform.SetParent(collider.transform);
                    }
                }
                
            }
            else
            {
                _instance = Instantiate(_prefab, transform.position, transform.rotation);
            }
            Destroy(_instance,_timeToDestroy);
        }
    }
}
