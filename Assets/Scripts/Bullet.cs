using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 10f;

    void Update()
    {
        transform.Translate(Vector3.up * speed * Time.deltaTime);
        if (transform.position.y > 6) // Suponiendo que 6 es el límite superior de la cámara
        {
            ReturnToPool();
        }
    }

    public void ReturnToPool()
    {
        gameObject.SetActive(false);
        BulletPool.Instance.ReturnBullet(this);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            Debug.Log("Impacto con enemigo: " + other.name);
            other.GetComponent<Enemy>().ReturnToPool();
            ReturnToPool();
        }
    }
}