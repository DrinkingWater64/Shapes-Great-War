using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Enemy : MonoBehaviour, Attackable
{
    // TextMeshProUGUI _text;
    public string _spell = "testtext";
    [SerializeField] float hp;
 
    public void Die()
    {
        Destroy(gameObject);
    }

    public void IsDead()
    {
        if (hp <= 0.0f)
        {
            Die();
        }
    }

    public void TakeDamage(float damageInput)
    {
        hp -= damageInput;
    }



    // Start is called before the first frame update
    void Start()
    {
        // _text.text = _spell;
    }

    // Update is called once per frame
    void Update()
    {
        IsDead();
    }
}

public interface Attackable
{
    void Die();
    public void TakeDamage(float damageInput);

    void IsDead();
}
