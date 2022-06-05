using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerEnemyQueue : MonoBehaviour
{

    public event Action<GameObject> enemyDetected;
    public List<GameObject> _gameObjects = new List<GameObject>();

    GameObject _currentEnemy;
    void Start()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("enemy") && !_gameObjects.Contains(collision.gameObject))
        {
            _gameObjects.Add(collision.gameObject);
            _currentEnemy = _gameObjects[0];
            enemyDetected(_gameObjects[0]);
            
        }
    }

    void ProcessEnemies()
    {
        if (_gameObjects.Count > 0)
        {
            if (_currentEnemy == null)
            {
                _gameObjects.Remove(_currentEnemy);
                UpdateEnemies();   
            }
        }
    }

    void UpdateEnemies()
    {
            if (_gameObjects.Count > 0) 
            { 
                _currentEnemy = _gameObjects[0];
                enemyDetected(_gameObjects[0]);
                Debug.Log("New enemy");
            }
            else
            {
                    Debug.Log("Clean slate");
            }
 
    }

    private void Update()
    {
        ProcessEnemies();
    }
}
