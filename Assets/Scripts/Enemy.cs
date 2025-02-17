using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed = 2f;
    private float speedIncreaseInterval = 10f;
    private float speedIncreaseAmount = 0.5f;
    private float gameTime = 0f;

    void Update()
    {
        gameTime += Time.deltaTime;
        
        if (gameTime >= speedIncreaseInterval)
        {
            speed += speedIncreaseAmount;
            gameTime = 0f; // Reiniciar el contador
            Debug.Log("Velocidad aumentada: " + speed);
        }
        
        transform.Translate(Vector3.down * speed * Time.deltaTime);
        if (transform.position.y < -6) // Suponiendo que -6 es el límite inferior de la cámara
        {
            ReturnToPool();
        }
    }

    public void ReturnToPool()
    {
        gameObject.SetActive(false);
        EnemyPool.Instance.ReturnEnemy(this);
    }
}
