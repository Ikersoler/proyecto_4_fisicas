using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] private GameObject enemyPrefab;
    [SerializeField] private GameObject powerupPrefab;

    private float spawnLimit = 8f;

    private int enemiesInScene;
    private int enemiesPerWave= 1;


    private void Start()
    {
        SpawnEnemyWaves(enemiesPerWave);

        Instantiate(powerupPrefab,
            GenerateRandomPosition(),
            Quaternion.identity);
    }


    private void Update()
    {
        //enemiesInScene = FindObjectsOfType<Enemy>().Length;
        


        if (enemiesInScene <= 0)
        {
            enemiesPerWave++;
            SpawnEnemyWaves(enemiesPerWave);
        }
    }

    private void SpawnEnemyWaves(int enemysToSpawn)
    {
        for (int i = 0; i < enemysToSpawn; i++)
        {
            Instantiate(enemyPrefab,
            GenerateRandomPosition(),
            Quaternion.identity);
            enemiesInScene++;
        }
    }
    public void EnemyDestroy()
    {
        enemiesInScene--;
    }




    private Vector3 GenerateRandomPosition()
    {
        float x = Random.Range(-spawnLimit, spawnLimit);
        float z = Random.Range(-spawnLimit, spawnLimit);

        return new Vector3(x, 0, z);
    }







}
