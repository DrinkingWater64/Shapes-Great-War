using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerEnemyQueue : MonoBehaviour
{

    public event Action<GameObject> enemyDetected;
    public List<GameObject> _gameObjects = new List<GameObject>();
    void Start()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("enemy") && !_gameObjects.Contains(collision.gameObject))
        {
            _gameObjects.Add(collision.gameObject);
            enemyDetected(_gameObjects[0]);
        }
    }
}
