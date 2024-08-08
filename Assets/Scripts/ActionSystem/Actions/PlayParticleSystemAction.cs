using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayExplosionEffectsAction : ActionBase
{
    [SerializeField] private GameObject _explosionEffects;
    [SerializeField] private float _delayTime;

    public override void Execute(object data = null)
    {
        if (data != null)
        {
            if (data is Collision collision)
            {
                var spawnPoint = collision.gameObject.transform.position;
                var instance = Instantiate(_explosionEffects, spawnPoint, Quaternion.identity);
                Destroy(instance, _delayTime);
            }
            else if (data is Collider collider)
            {
                var spawnPoint = collider.gameObject.transform.position;
                var instance = Instantiate(_explosionEffects, spawnPoint, Quaternion.identity);
                Destroy(instance, _delayTime);
            }
            else
            {
                var spawnPoint = gameObject.transform.position;
                var instance = Instantiate(_explosionEffects, spawnPoint, Quaternion.identity);
                Destroy(instance, _delayTime);
            }

        }
    }
}
