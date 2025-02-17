using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShip : MonoBehaviour
{
    public float moveSpeed = 5f;
    public GameObject bulletPrefab;
    public Transform bulletSpawnPoint;

    void Update()
    {
        Move();
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
    }

    void Move()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        transform.Translate(Vector3.right * horizontalInput * moveSpeed * Time.deltaTime);
    }

    void Shoot()
    {
        Bullet bullet = BulletPool.Instance.GetBullet();
        if (bullet != null)
        {
            bullet.transform.position = bulletSpawnPoint.position;
            bullet.gameObject.SetActive(true);
        }
    }
}
