using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerEnemyQueue : MonoBehaviour
{

    public event Action<GameObject> enemyDetected;
    public List<GameObject> _gameObjects = new List<GameObject>();
    [SerializeField]
    GameObject _currentEnemy;
    [SerializeField]
    int _currentIndex;
    void Start()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("enemy") && !_gameObjects.Contains(collision.gameObject))
        {
            AddEnemiesToList(collision.gameObject);
        }
    }

    void AddEnemiesToList(GameObject newObject)
    {
        if (!_gameObjects.Contains(newObject))
        {
            _gameObjects.Add(newObject);
            if (_gameObjects.Count == 1)
            {
                SetCurrentEnemy(_gameObjects[0]);
                enemyDetected(_gameObjects[0]);
            }
        }

    }



    void ProcessEnemies()
    {
        if (_gameObjects.Count > 0)
        {
            if (_currentEnemy == null)
            {
                _gameObjects.Remove(_currentEnemy);
                UpdateEnemiesAfterDelete();   
            }
        }
    }



    void UpdateEnemiesAfterDelete()
    {
            if (_gameObjects.Count > 0) 
            { 
                SetCurrentEnemy(_gameObjects[0]);
                enemyDetected(_gameObjects[0]);
                Debug.Log("New enemy");
            }
            else
            {
                    Debug.Log("Clean slate");
            }
 
    }

    void SwitchEnemyForward()
    {
        int nextIndex = (_currentIndex + 1) % _gameObjects.Count;
        SetCurrentEnemy(_gameObjects[nextIndex], nextIndex);
        enemyDetected(_currentEnemy);
    }

    void SwitchEnemyBackward()
    {
        int len = _gameObjects.Count;
        int prevIndex = (_currentIndex + len - 1) % len;
        SetCurrentEnemy(_gameObjects[prevIndex], prevIndex);
        enemyDetected(_currentEnemy);
    }





    void SetCurrentEnemy(GameObject newObject)
    {
        _currentEnemy = newObject;
        _currentIndex = _gameObjects.IndexOf(_currentEnemy);
    }

    void SetCurrentEnemy(GameObject newgameObject, int newindex)
    {
        _currentEnemy = newgameObject;
        _currentIndex = newindex;
    }

    private void Update()
    {
        if (!Input.GetKey(KeyCode.LeftShift) && Input.GetKeyDown(KeyCode.Tab))
        {
            Debug.Log("Going forward");
            SwitchEnemyForward();
        }
        ProcessEnemies();

        if (Input.GetKey(KeyCode.LeftShift) && Input.GetKeyDown(KeyCode.Tab))
        {
            Debug.Log("going back");
            SwitchEnemyBackward();

        }
    }
}
