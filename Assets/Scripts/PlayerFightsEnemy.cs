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
        textMatcher.TextMatched += dealDamage;
    }

    private void OnDisable()
    {
        gameObject.GetComponent<PlayerEnemyQueue>().enemyDetected -= SpellCast;
        textMatcher.TextMatched -= dealDamage;
        gameObject.GetComponent<PlayerEnemyQueue>().enemySwitched -= LockNewEnemy;
        
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
        if (enemyObject != null)
        {
            _currentEnemy = enemyObject;
            _currentEnemy.GetComponent<Enemy>().LockedOn();
            SpellCast(_currentEnemy);
        }
        else
        {
            _currentEnemy = enemyObject;
        }
    }

    void LockNewEnemy(GameObject newEnemy)
    {
        if (newEnemy != null)
        {
            _currentEnemy.GetComponent<Enemy>().Unlocked();
            LockEnemy(newEnemy);
        }
        else
        {   
            Debug.Log("null enemy");
        }
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
