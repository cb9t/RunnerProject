using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerEnemy : MonoBehaviour
{
    [SerializeField] private GameObject[] _prefab;

    [SerializeField] private float[] _spawnPositionX;
    [SerializeField] private float _spawnPositionZ;
    [SerializeField] private float _spawnPositionY;
    
    [SerializeField] private float _spawnStartPositionZ;
    [SerializeField] private float _distancePerSpawn;
    [SerializeField] private float _positionZRandomRange;

    private float _spawnPointZ;
    private float _lastObjectPositionZ;
    private GameObject _lastObject;
    private float _triggerSpawnPoint;

    private void Start()
    {
        _spawnPointZ = _spawnStartPositionZ;

        for (float i = _spawnStartPositionZ; i < _spawnPositionZ ; i += _distancePerSpawn)
        {
            GenerateEnemy();
            _spawnPointZ += _distancePerSpawn;
        }

    }
    private void FixedUpdate()
    {
        _lastObjectPositionZ = _lastObject.transform.position.z;
        if (_lastObjectPositionZ < _triggerSpawnPoint)
        {
            GenerateEnemy();
        } 
    }
    private void GenerateEnemy()
    {
        var objcetsPerSpawn = Random.Range(1, _spawnPositionX.Length + 1);

        if (objcetsPerSpawn == 1)
        {
            var trackForInstans = Random.Range(0, _spawnPositionX.Length - 1);
            var positionForInstans = new Vector3(_spawnPositionX[trackForInstans], _spawnPositionY, _spawnPointZ);
            var enemyForInstans = _prefab[Random.Range(0, _prefab.Length)];
            var instans = Instantiate(enemyForInstans, positionForInstans, Quaternion.identity, gameObject.transform);
            _lastObject = instans.gameObject;
        }
        if (objcetsPerSpawn == 2)
        {
            var trackForInstans = Random.Range(0, _spawnPositionX.Length - 1);

            for (int i = 0; i < _spawnPositionX.Length; i++)
            {
                if (i != trackForInstans)
                {
                    var positionZ = Random.Range(_spawnPointZ - _positionZRandomRange, _spawnPointZ + _positionZRandomRange);
                    var positionForInstans = new Vector3(_spawnPositionX[i], _spawnPositionY, positionZ);
                    var enemyForInstans = _prefab[Random.Range(0, _prefab.Length)];
                    var instans = Instantiate(enemyForInstans, positionForInstans, Quaternion.identity, gameObject.transform);
                    _lastObject = instans.gameObject;
                }
            }
        }
        if (objcetsPerSpawn == 3)
        {
            for (int i = 0; i < objcetsPerSpawn; i++)
            {
                var positionZ = Random.Range(_spawnPointZ - _positionZRandomRange, _spawnPointZ + _positionZRandomRange);
                var positionForInstans = new Vector3(_spawnPositionX[i], _spawnPositionY, positionZ);
                var enemyForInstans = _prefab[Random.Range(0, _prefab.Length)];
                var instans = Instantiate(enemyForInstans, positionForInstans, Quaternion.identity, gameObject.transform);
                _lastObject = instans.gameObject;
            }
        }

        
        _triggerSpawnPoint = _lastObject.transform.position.z - _distancePerSpawn;
    }
}
