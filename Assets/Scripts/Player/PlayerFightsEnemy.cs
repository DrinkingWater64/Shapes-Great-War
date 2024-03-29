using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerFightsEnemy : MonoBehaviour
{
    [SerializeField] float damageOutput;
    public TextMatcher textMatcher;
    GameObject _currentEnemy;
    // Start is called before the first frame update

    private void OnEnable()
    {
        gameObject.GetComponent<PlayerEnemyQueue>().enemyDetected += LockEnemy;
        gameObject.GetComponent<PlayerEnemyQueue>().enemySwitched += LockNewEnemy;
        gameObject.GetComponent<PlayerEnemyQueue>().enemiesEmptied += HandleNullEnemy;
        textMatcher.TextMatched += dealDamage;

    }

    private void OnDisable()
    {
        gameObject.GetComponent<PlayerEnemyQueue>().enemyDetected -= SpellCast;
        textMatcher.TextMatched -= dealDamage;
        gameObject.GetComponent<PlayerEnemyQueue>().enemySwitched -= LockNewEnemy;
        gameObject.GetComponent<PlayerEnemyQueue>().enemiesEmptied -= HandleNullEnemy;
        
    }
    void Start()
    {
        
    }

    private void Awake()
    {
        textMatcher = GameObject.Find("TextMatcher").GetComponent<TextMatcher>();
    }

    void TurnOnTextMatcher()
    {
            if (textMatcher.gameObject.activeSelf == false)
                textMatcher.gameObject.SetActive(true);
    }

    void LockEnemy(GameObject enemyObject)
    {
        if (enemyObject != null)
        {
            TurnOnTextMatcher();
            _currentEnemy = enemyObject;
            _currentEnemy.GetComponent<Enemy>().LockedOn();
            SpellCast(_currentEnemy);
        }
    }

    void LockNewEnemy(GameObject newEnemy)
    {
        if (newEnemy != null)
        {
            _currentEnemy.GetComponent<Enemy>().Unlocked();
            LockEnemy(newEnemy);
        }
    }

    void HandleNullEnemy()
    {
        textMatcher.ResetTextMatcher();
        _currentEnemy.GetComponent<Enemy>().Unlocked();
        _currentEnemy = null;
        Debug.LogWarning("Null handled");
    }

    void SpellCast(GameObject enemyObject)
    {
        textMatcher.SetCurrentText(enemyObject.gameObject.GetComponent<Enemy>()._spell);
    }

    void dealDamage()
    {
        _currentEnemy.GetComponent<Enemy>().TakeDamage(damageOutput);
        if (_currentEnemy != null)
        {
            SpellCast(_currentEnemy);
        }
    }

    // Update is called once per frame
}
