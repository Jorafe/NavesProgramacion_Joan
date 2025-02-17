using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletPool : MonoBehaviour
{
    public static BulletPool Instance;
    public GameObject bulletPrefab;
    public int poolSize = 20;
    private Queue<Bullet> bulletPool = new Queue<Bullet>();

    void Awake()
    {
        Instance = this;
        for (int i = 0; i < poolSize; i++)
        {
            Bullet bullet = Instantiate(bulletPrefab).GetComponent<Bullet>();
            bullet.gameObject.SetActive(false);
            bulletPool.Enqueue(bullet);
        }
    }

    public Bullet GetBullet()
    {
        if (bulletPool.Count > 0)
        {
            return bulletPool.Dequeue();
        }
        return null;
    }

    public void ReturnBullet(Bullet bullet)
    {
        bulletPool.Enqueue(bullet);
    }
}
