using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public static EnemyManager instance;

    [Header("Spawn Props")]
    public float maxSpawnInterval;
    public float minSpawnInterval;

    [Space]
    [Header("Object Refs")]
    public Transform[] spawnPoints;
    public GameObject[] enemyTypes;

    private float nextSpawnTime = 0.5f;
    private float nextBossSpawnTime = 15f;
    private float nextBossSpawnInterval = 15f;
    private float nextBigBossSpawnTime = 40f;
    private float nextBigBossSpawnInterval = 40f;
    private float nextObfuscatorBossSpawnTime = 30f;
    private float nextObfuscatorBossSpawnInterval = 30f;

    private void Start()
    {
        instance = this;
    }
    // Update is called once per frame
    void Update()
    {
        if (Time.timeSinceLevelLoad > nextSpawnTime) {
            nextSpawnTime += maxSpawnInterval - Mathf.Lerp(minSpawnInterval, 
                                                           maxSpawnInterval, 
                                                           Mathf.Clamp01(nextSpawnTime / 150));

            Instantiate(enemyTypes[0], spawnPoints[Random.Range(0, spawnPoints.Length)]);
        }

        if (Time.timeSinceLevelLoad > nextBossSpawnTime)
        {
            nextBossSpawnTime += nextBossSpawnInterval;
            nextBossSpawnInterval -= 0.25f;

            Instantiate(enemyTypes[1], spawnPoints[Random.Range(0, spawnPoints.Length)]);
        }

        if (Time.timeSinceLevelLoad > nextBigBossSpawnTime)
        {
            nextBigBossSpawnTime += nextBigBossSpawnInterval;
            nextBigBossSpawnInterval -= 0.1f;

            Instantiate(enemyTypes[2], spawnPoints[Random.Range(0, spawnPoints.Length)]);
        }

        if (Time.timeSinceLevelLoad > nextObfuscatorBossSpawnTime)
        {
            nextObfuscatorBossSpawnTime += nextObfuscatorBossSpawnInterval;
            nextObfuscatorBossSpawnInterval -= 0.175f;

            Instantiate(enemyTypes[3], spawnPoints[Random.Range(0, spawnPoints.Length)]);
        }
    }

    public void IncreaseSpawnIntervals()
    {
        nextObfuscatorBossSpawnInterval += 0.25f;
        nextBigBossSpawnInterval += 0.1f;
        nextBossSpawnInterval += 0.3f;
    }
}
