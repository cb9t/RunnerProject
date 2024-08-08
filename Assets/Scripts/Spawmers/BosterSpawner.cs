using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BosterSpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] _prefab;

    [SerializeField] private float[] _spawnPositionX;
    [SerializeField] private float _spawnPositionZ;
    [SerializeField] private float _spawnPositionY;

    [SerializeField] private Vector2 _delayRangePerSpawn;

    private void Start()
    {
        StartCoroutine(SpawnBoster());
    }

    private IEnumerator SpawnBoster()
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(_delayRangePerSpawn.x, _delayRangePerSpawn.y));
            GenerateBoster();
        }
    }
    private void GenerateBoster()
    {
        var trackForInstans = Random.Range(0, _spawnPositionX.Length);
        var positionForInstans = new Vector3(_spawnPositionX[trackForInstans], _spawnPositionY, _spawnPositionZ);
        var objectForInstans = _prefab[Random.Range(0, _prefab.Length)];
        Instantiate(objectForInstans, positionForInstans, Quaternion.identity, gameObject.transform);
    }

}
