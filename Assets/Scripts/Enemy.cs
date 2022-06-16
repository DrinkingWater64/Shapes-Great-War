using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Pool;

public class Enemy : MonoBehaviour, IAttackable, ILockable
{
    // TextMeshProUGUI _text;
    public string _spell = "testtext";
    [SerializeField] float hp;
    [SerializeField] GameObject FloatingText;


    private void Awake()
    {
    }

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

    public void LockedOn()
    {
        gameObject.transform.GetChild(1).gameObject.SetActive(true);
    }

    public void TakeDamage(float damageInput)
    {
        hp -= damageInput;
    }

    public void Unlocked()
    {
        gameObject.transform.GetChild(1).gameObject.SetActive(false);
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
