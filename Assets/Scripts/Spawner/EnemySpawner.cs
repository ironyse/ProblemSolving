using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private Transform[] spawnLocations;

    public string enemyTag = "Enemy";
    public int maxSpawnAmount = 6;
    public float spawnDelay = 5f;

    private float spawnTimer;

    ObjectPooler objPooler;

    private void Start()
    {
        objPooler = ObjectPooler.Instance;
    }

    private void Update()
    {        
        spawnTimer -= Time.deltaTime;
        if (spawnTimer <= 0f)
        {
            Enemy[] enemies = FindObjectsOfType<Enemy>();
            if (enemies.Length < maxSpawnAmount)
            {
                // spawn enemy
                SpawnEnemy();
                spawnTimer = spawnDelay;
            }            
        }
    }

    private void SpawnEnemy()
    {
        int randInt = Random.Range(0, spawnLocations.Length-1);
        Transform spawnLocation = spawnLocations[randInt];
        objPooler.SpawnFromPool(enemyTag, spawnLocation.position, Quaternion.identity);
    }
}
