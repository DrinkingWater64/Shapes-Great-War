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
        textMatcher.TextMatched += dealDamage;
    }

    private void OnDisable()
    {
        gameObject.GetComponent<PlayerEnemyQueue>().enemyDetected -= SpellCast;
        textMatcher.TextMatched -= dealDamage;
        
    }
    void Start()
    {
    }

    private void Awake()
    {
        
        textMatcher = GameObject.Find("TextMatcher").GetComponent<TextMatcher>();
    }

    void LockEnemy(GameObject enemyObject)
    {
        _currentEnemy = enemyObject;
        SpellCast(_currentEnemy);
    }

    void SpellCast(GameObject enemyObject)
    {
        textMatcher.SetCurrentText(enemyObject.gameObject.GetComponent<Enemy>()._spell);
    }

    void dealDamage()
    {
        _currentEnemy.GetComponent<Enemy>().TakeDamage(damageOutput);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
