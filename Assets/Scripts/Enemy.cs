using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Enemy : MonoBehaviour, IAttackable, ILockable
{
    // TextMeshProUGUI _text;
    public string _spell = "testtext";
    [SerializeField] float hp;
    [SerializeField] GameObject FloatingText;
 
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
        ShowDamage(damageInput);
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

    void ShowDamage( float damage )
    {
        GameObject gameObject = Instantiate(FloatingText, transform.position, Quaternion.identity);
        gameObject.GetComponentInChildren<TextMesh>().text = damage.ToString();
    }

}
