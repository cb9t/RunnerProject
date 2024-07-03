using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private float[] _tracksPosition;
    [SerializeField] private float _positionZ;
    [SerializeField] private float _positionZRandom;
    [SerializeField] private Vector2 _timePerSpawn;

    [Space]
    [Header("Ground Enemy")]
    [SerializeField] private GameObject[] _groundEnemy;
    [SerializeField] private float _positionYGround;
    [Space]
    [Header("Flying Enemy")]
    [SerializeField] private GameObject[] _flyEnemy;
    [SerializeField] private float _positionYFly;

    private void Start()
    {
        StartCoroutine(Spawn());
    }
    private void SpawnFlyEnemy()
    {
        var objcetsPerSpawn = Random.Range(1, _tracksPosition.Length+1);
        

        if (objcetsPerSpawn == 1)
        {
            var trackForInstans = Random.Range(0, _tracksPosition.Length-1);
            var positionForInstans = new Vector3(_tracksPosition[trackForInstans], _positionYFly, _positionZ);
            var enemyForInstans = _flyEnemy[Random.Range(0, _flyEnemy.Length)];
            Instantiate(enemyForInstans, positionForInstans, Quaternion.identity);
        }
        if (objcetsPerSpawn == 2)
        {
            var trackForInstans = Random.Range(0, _tracksPosition.Length-1);

            for (int i = 0; i < _tracksPosition.Length; i++)
            {
                if (i !=trackForInstans)
                {
                    var positionZ = Random.Range(_positionZ - _positionZRandom, _positionZ + _positionZRandom);
                    var positionForInstans = new Vector3(_tracksPosition[i], _positionYFly, positionZ);
                    var enemyForInstans = _flyEnemy[Random.Range(0, _flyEnemy.Length)];
                    Instantiate(enemyForInstans, positionForInstans, Quaternion.identity);
                }
            }
        }
        if (objcetsPerSpawn == 3)
        {
            for (int i = 0; i < objcetsPerSpawn; i++)
            {
                var positionZ = Random.Range(_positionZ - _positionZRandom, _positionZ + _positionZRandom);
                var positionForInstans = new Vector3(_tracksPosition[i], _positionYFly, positionZ);
                var enemyForInstans = _flyEnemy[Random.Range(0, _flyEnemy.Length)];
                Instantiate(enemyForInstans, positionForInstans, Quaternion.identity);
            }
        }
    }
    private IEnumerator Spawn()
    {
        while (true) 
        {
            SpawnFlyEnemy();
            yield return new WaitForSeconds(Random.Range(_timePerSpawn.y,_timePerSpawn.x));
        }
    }
    
}
