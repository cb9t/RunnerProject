using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private float[] _tracksPosition;
    [SerializeField] private Vector2 _timePerSpawn;

    

    [Space]
    [Header("Ground Enemy")]
    [SerializeField] private GameObject[] _groundEnemy;
    [SerializeField] private float _positionYGround;
    [SerializeField] private float _positionZGround;
    [SerializeField] private float _positionZGroundRandom;
    [Space]
    [Header("Flying Enemy")]
    [SerializeField] private GameObject[] _flyEnemy;
    [SerializeField] private float _positionYFly;
    [SerializeField] private float _positionZFly;
    [SerializeField] private float _positionZFlyRandom;

    [Space]
    [Header("Boosters")]
    [SerializeField] private GameObject[] _boosters;
    [SerializeField] private Vector2 _timeBosterSpawn;


    private void Start()
    {
        StartCoroutine(Spawn());
        StartCoroutine(SpawnBooster());
    }
    private void SpawnFlyEnemy()
    {
        var objcetsPerSpawn = Random.Range(1, _tracksPosition.Length+1);
        

        if (objcetsPerSpawn == 1)
        {
            var trackForInstans = Random.Range(0, _tracksPosition.Length-1);
            var positionForInstans = new Vector3(_tracksPosition[trackForInstans], _positionYFly, _positionZFly);
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
                    var positionZ = Random.Range(_positionZFly - _positionZFlyRandom, _positionZFly + _positionZFlyRandom);
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
                var positionZ = Random.Range(_positionZFly - _positionZFlyRandom, _positionZFly + _positionZFlyRandom);
                var positionForInstans = new Vector3(_tracksPosition[i], _positionYFly, positionZ);
                var enemyForInstans = _flyEnemy[Random.Range(0, _flyEnemy.Length)];
                Instantiate(enemyForInstans, positionForInstans, Quaternion.identity);
            }
        }
    }
    private void SpawnGroundEnemy()
    {
        var objcetsPerSpawn = Random.Range(1, _tracksPosition.Length + 1);


        if (objcetsPerSpawn == 1)
        {
            var trackForInstans = Random.Range(0, _tracksPosition.Length - 1);
            var positionForInstans = new Vector3(_tracksPosition[trackForInstans], _positionYGround, _positionZGround);
            var enemyForInstans = _groundEnemy[Random.Range(0, _groundEnemy.Length)];
            Instantiate(enemyForInstans, positionForInstans, Quaternion.identity);
        }
        if (objcetsPerSpawn == 2)
        {
            var trackForInstans = Random.Range(0, _tracksPosition.Length - 1);

            for (int i = 0; i < _tracksPosition.Length; i++)
            {
                if (i != trackForInstans)
                {
                    var positionZ = Random.Range(_positionZGround - _positionZGroundRandom, _positionZGround + _positionZGroundRandom);
                    var positionForInstans = new Vector3(_tracksPosition[i], _positionYGround, positionZ);
                    var enemyForInstans = _groundEnemy[Random.Range(0, _groundEnemy.Length)];
                    Instantiate(enemyForInstans, positionForInstans, Quaternion.identity);
                }
            }
        }
        if (objcetsPerSpawn == 3)
        {
            for (int i = 0; i < objcetsPerSpawn; i++)
            {
                var positionZ = Random.Range(_positionZGround - _positionZGroundRandom, _positionZGround + _positionZGroundRandom);
                var positionForInstans = new Vector3(_tracksPosition[i], _positionYGround, positionZ);
                var enemyForInstans = _groundEnemy[Random.Range(0, _groundEnemy.Length)];
                Instantiate(enemyForInstans, positionForInstans, Quaternion.identity);
            }
        }
    }
    private void GenerateBooster()
    {
        var trackForInstans = Random.Range(0, _tracksPosition.Length - 1);
        var positionForInstans = new Vector3(_tracksPosition[trackForInstans], _positionYFly, _positionZFly);
        var objectForInstans = _boosters[Random.Range(0, _boosters.Length)];
        Instantiate(objectForInstans, positionForInstans, Quaternion.identity);
    }

    private IEnumerator Spawn()
    {
        while (true) 
        {
            SpawnFlyEnemy();
            SpawnGroundEnemy();
            yield return new WaitForSeconds(Random.Range(_timePerSpawn.y,_timePerSpawn.x));
        }
    }
    private IEnumerator SpawnBooster()
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(_timeBosterSpawn.x, _timeBosterSpawn.y));
            GenerateBooster();
        }
        
    }
    
}
