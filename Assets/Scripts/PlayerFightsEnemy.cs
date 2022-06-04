using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerFightsEnemy : MonoBehaviour
{
    public TextMatcher textMatcher;
    // Start is called before the first frame update

    private void OnEnable()
    {
        gameObject.GetComponent<PlayerEnemyQueue>().enemyDetected += SpellCast;
    }
    void Start()
    {
        textMatcher = GameObject.Find("TextMatcher").GetComponent<TextMatcher>();
    }

    void SpellCast(GameObject enemyObject)
    {
        textMatcher.SetCurrentText(enemyObject.gameObject.GetComponent<Enemy>()._spell);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
