using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    [Header("Spawn Props")]
    public float spawnInterval;


    [Space]
    [Header("Object Refs")]
    public Transform[] spawnPoints;
    public GameObject[] enemyTypes;

    private float nextSpawnTime = 0.5f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.fixedTime > nextSpawnTime) {
            nextSpawnTime += spawnInterval;
            Instantiate(enemyTypes[Random.Range(0, enemyTypes.Length)], spawnPoints[Random.Range(0, spawnPoints.Length)]);
        }
    }
}
