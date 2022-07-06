using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour, IAttackable
{

    [SerializeField] private float hp;

    public void Die()
    {
        Debug.LogWarning("Player Died");
    }

    public void IsDead()
    {
        if (hp <= 0)
        {
            Die();
        }
    }

    public void TakeDamage(float damageInput)
    {
        hp = hp - damageInput;
    }

    void Start()
    {
        
    }

    void Update()
    {
        
    }
}
