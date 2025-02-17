using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPool : MonoBehaviour
{
    public static EnemyPool Instance;
    public GameObject enemyPrefab;
    public int poolSize = 10;
    private Queue<Enemy> enemyPool = new Queue<Enemy>();

    void Awake()
    {
        Instance = this;
        for (int i = 0; i < poolSize; i++)
        {
            Enemy enemy = Instantiate(enemyPrefab).GetComponent<Enemy>();
            enemy.gameObject.SetActive(false);
            enemyPool.Enqueue(enemy);
        }
    }

    public Enemy GetEnemy()
    {
        if (enemyPool.Count > 0)
        {
            return enemyPool.Dequeue();
        }
        return null;
    }

    public void ReturnEnemy(Enemy enemy)
    {
        enemyPool.Enqueue(enemy);
    }
}
