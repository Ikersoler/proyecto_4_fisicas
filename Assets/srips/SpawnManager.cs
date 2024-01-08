using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] private GameObject enemyPrefab;

    private float spawnlimit = 8f;



    private void Start()
    {
        Instantiate(enemyPrefab,
            new Vector3(0, 0, 8),
            Quaternion.identity);

    }

    private Vector3 GenerateRandomPosition()
    {
        float x = Random.Range(-spawnlimit, spawnlimit);
        float z = Random.Range(-spawnlimit, spawnlimit);

        return new Vector3(x, 0, z);
    }
    






}
