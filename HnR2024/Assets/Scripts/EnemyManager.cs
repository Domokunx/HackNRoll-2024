using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    [Header("Spawn Props")]
    public float maxSpawnInterval;
    public float minSpawnInterval;

    [Space]
    [Header("Object Refs")]
    public Transform[] spawnPoints;
    public GameObject[] enemyTypes;

    private float nextSpawnTime = 0.5f;
    private float nextBossSpawnTime = 15f;
    private float nextBigBossSpawnTime = 30f;

    // Update is called once per frame
    void Update()
    {
        if (Time.timeSinceLevelLoad > nextSpawnTime) {
            nextSpawnTime += maxSpawnInterval - Mathf.Lerp(minSpawnInterval, 
                                                           maxSpawnInterval, 
                                                           Mathf.Clamp01(nextSpawnTime / 180));

            Instantiate(enemyTypes[0], spawnPoints[Random.Range(0, spawnPoints.Length)]);
        }

        if (Time.timeSinceLevelLoad > nextBossSpawnTime)
        {
            nextBossSpawnTime += 15;

            Instantiate(enemyTypes[1], spawnPoints[Random.Range(0, spawnPoints.Length)]);
        }

        if (Time.timeSinceLevelLoad > nextBigBossSpawnTime)
        {
            nextBigBossSpawnTime += 30;

            Instantiate(enemyTypes[2], spawnPoints[Random.Range(0, spawnPoints.Length)]);
        }
    }
}
