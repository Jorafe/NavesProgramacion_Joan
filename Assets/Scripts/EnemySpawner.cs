using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public float spawnInterval = 2f;
    private float nextSpawnTime;

    void Update()
    {
        if (Time.time >= nextSpawnTime)
        {
            SpawnEnemy();
            nextSpawnTime = Time.time + spawnInterval;
        }
    }

    void SpawnEnemy()
    {
        Enemy enemy = EnemyPool.Instance.GetEnemy();
        if (enemy != null)
        {
            enemy.transform.position = new Vector3(Random.Range(-8f, 8f), 6f, 0); // Aparece en la parte superior
            enemy.gameObject.SetActive(true);
        }
    }
}
