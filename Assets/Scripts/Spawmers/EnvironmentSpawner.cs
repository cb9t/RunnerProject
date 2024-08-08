using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnvironmentSpawner : MonoBehaviour
{
    [Header("Types of prefabs")]
    [SerializeField] private GameObject _prefabChunk;
    [SerializeField] private GameObject[] _prefabOnRoad;
    [SerializeField] private GameObject[] _prefabNearRoad;
    [SerializeField] private GameObject[] _prefabOnSides;
    [SerializeField] private GameObject[] _prefabMounts;

    [Space]
    [Header("Positions for spawn")]
    [SerializeField] private Vector2 _positionOnRoad;
    [SerializeField] private Vector2 _positionNearRoad;
    [SerializeField] private Vector2 _positionOnSides;
    [SerializeField] private float _positionMounts;

    [SerializeField] private float _positionZ;
    [SerializeField] private float _sizeChunk;

    [SerializeField] private Vector2 _countObjectsOnRoad;
    [SerializeField] private Vector2 _countObjectsOnSides;
    [SerializeField] private float _dictancePerObjectNearRoad;

    private Transform _lastChunk;

    private void Start()
    {
        var spawnPositionZ = 0f;
        for (float i = spawnPositionZ; i < _positionZ; i += _sizeChunk)
        {
            var spawnPosition = new Vector3(0f, 0f, spawnPositionZ);
            GenerateChunk(spawnPosition);
            spawnPositionZ += _sizeChunk;
        }
    }
    private void FixedUpdate()
    {
        var lastChunkPosition = _lastChunk.transform.position.z;
        if (lastChunkPosition < (_positionZ - _sizeChunk))
        {
            var spawnPosition = new Vector3(0f, 0f, _positionZ);
            GenerateChunk(spawnPosition);
        }
    }
    private void GenerateChunk(Vector3 spawnPosition)
    {
        var chunk = Instantiate(_prefabChunk, spawnPosition, Quaternion.identity, gameObject.transform);
        GenerateOnRoad(chunk);
        GenerateNearRoad(chunk);
        GenerateOnSides(chunk);
        GenerateMounts(chunk);
        _lastChunk = chunk.transform;
    }
    private void GenerateOnRoad(GameObject chunk)
    {
        var countObjectsPerSpawn = Random.Range(_countObjectsOnRoad.x, _countObjectsOnRoad.y);
        for (int i = 1; i <= countObjectsPerSpawn; i++)
        {
            var objectForSpawn = _prefabOnRoad[Random.Range(0, _prefabOnRoad.Length)];
            var positionForSpawn = new Vector3(
                Random.Range(_positionOnRoad.x, _positionOnRoad.y),
                0f,
                Random.Range(chunk.transform.position.z - (_sizeChunk / 2), chunk.transform.position.z + (_sizeChunk / 2)));
            var rotationForSpawn = Quaternion.Euler(0f,(Random.Range(0f,360f)),0f);
            Instantiate(objectForSpawn, positionForSpawn, rotationForSpawn, chunk.transform);
        }
    }
    private void GenerateNearRoad(GameObject chunk)
    {
        var pozitionZ = (chunk.transform.position.z - (_sizeChunk/2)) + _dictancePerObjectNearRoad;

        for (float i = pozitionZ; i < (chunk.transform.position.z + (_sizeChunk / 2)); i += _dictancePerObjectNearRoad)
        {
          for (int n = -1; n <= 1; n += 2)
          {
              var objectForSpawn = _prefabNearRoad[Random.Range(0, _prefabNearRoad.Length)];
              var positionForSpawn = new Vector3((Random.Range(_positionNearRoad.x, _positionNearRoad.y)  * n), 0f, pozitionZ);
              var rotationForSpawn = Quaternion.Euler(0f, (Random.Range(0f, 360f)), 0f);
              Instantiate(objectForSpawn, positionForSpawn, rotationForSpawn, chunk.transform);
           }
            pozitionZ += _dictancePerObjectNearRoad;
        }
    }
    private void GenerateOnSides(GameObject chunk) 
    {
        for (int n = -1; n <= 1; n += 2)
        {
            var countObjectsPerSpawn = Random.Range(_countObjectsOnRoad.x, _countObjectsOnRoad.y);
            for (int i = 1; i <= countObjectsPerSpawn; i++)
            {
               var objectForSpawn = _prefabOnSides[Random.Range(0, _prefabOnSides.Length)];
               var positionForSpawn = new Vector3(
                   Random.Range(_positionOnSides.x, _positionOnSides.y) * n,
                   0f,
                   Random.Range(chunk.transform.position.z - (_sizeChunk / 2), chunk.transform.position.z + (_sizeChunk / 2)));
               var rotationForSpawn = Quaternion.Euler(0f, (Random.Range(0f, 360f)), 0f);
               Instantiate(objectForSpawn, positionForSpawn, rotationForSpawn, chunk.transform); 
            }
        }
    }
    private void GenerateMounts(GameObject chunk)
    {
        for (int n = -1; n <= 1; n += 2)
        {
            var countObjectsPerSpawn = Random.Range(0f, 2f);
            for (int i = 1; i <= countObjectsPerSpawn; i++)
            {
                var objectForSpawn = _prefabMounts[Random.Range(0, _prefabMounts.Length)];
                var positionForSpawn = new Vector3(_positionMounts * n, 0f, chunk.transform.position.z);
                var rotationForSpawn = Quaternion.Euler(0f, (Random.Range(0f, 360f)), 0f);
                Instantiate(objectForSpawn, positionForSpawn, rotationForSpawn, chunk.transform);
            }
        }
    }


}
