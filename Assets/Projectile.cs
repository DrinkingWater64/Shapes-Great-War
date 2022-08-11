using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{


    [SerializeField]
    float _damageInput;
    [SerializeField]
    GameObject _player;
    void Start()
    {
        _player = GameObject.FindGameObjectWithTag("Player");
    }

    void Update()
    {
        
    }



    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("trigger work pls");

         if (collision.CompareTag("Player"))
        {
            _player.GetComponent<Player>().TakeDamage(_damageInput);
            Debug.Log("projectile damgae");
        }
    }

}
