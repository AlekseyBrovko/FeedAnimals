using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] private GameObject[] animalPrefabs;

    private float _spawnRangeX = 20;
    private float _spawnPosZ = 20;
    private float _sideSpawnMinZ = 0;
    private float _sideSpawnMaxZ = 15;
    private float _sideSpawnX = 30;

    private float _startDelay = 2;
    private float _spawnInterval = 1.5f;

    private void Start()
    {
        InvokeRepeating("SpawnRandomAnimal", _startDelay, _spawnInterval);
        InvokeRepeating("SpawnLeftAnimal", _startDelay, _spawnInterval);
        InvokeRepeating("SpawnRightAnimal", _startDelay, _spawnInterval);
    }
    
    private void SpawnRandomAnimal() 
    {
        Vector3 spawnPos = new Vector3(Random.Range(-_spawnRangeX, _spawnRangeX), 0, _spawnPosZ);
        int animalIndex = Random.Range(0, animalPrefabs.Length);
        Instantiate(animalPrefabs[animalIndex], spawnPos, animalPrefabs[animalIndex].transform.rotation);
    }

    private void SpawnLeftAnimal()
    {
        int animalIndex = Random.Range(0, animalPrefabs.Length);
        Vector3 spawnPos = new Vector3(-_sideSpawnX, 0, Random.Range(_sideSpawnMinZ, _sideSpawnMaxZ));
        Vector3 rotation = new Vector3(0, 90, 0);
        Instantiate(animalPrefabs[animalIndex], spawnPos, Quaternion.Euler(rotation));
    }

    private void SpawnRightAnimal()
    {
        int animalIndex = Random.Range(0, animalPrefabs.Length);
        Vector3 spawnPos = new Vector3(_sideSpawnX, 0, Random.Range(_sideSpawnMinZ, _sideSpawnMaxZ));
        Vector3 rotation = new Vector3(0, -90, 0);
        Instantiate(animalPrefabs[animalIndex], spawnPos, Quaternion.Euler(rotation));
    }

}
