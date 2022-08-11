using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Player : MonoBehaviour, IAttackable
{
    public event Action<float> DamageTaken;

    [SerializeField] private float hp;
    [SerializeField] private float maximumHp;

    public float Hp { get => hp;
        set 
        {
            if (value > maximumHp)
            {
                hp = maximumHp;
            }
            else if (value < 0)
            {
                hp = 0;
            }
            else
            {
                hp = value;
            }
        } 
    }

    public float MaximumHp { get => maximumHp; set => maximumHp = value; }

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
        // hp = hp - damageInput;
        Hp = hp - damageInput;
        DamageTaken(hp);
    }

    void Start()
    {
        
    }

    void Update()
    {
        
    }
}
