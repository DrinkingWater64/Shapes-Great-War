using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StompAttack : MonoBehaviour
{

    [SerializeField]
    float _damageInput;

    GameObject _player;
    // Start is called before the first frame update
    void Start()
    {
        _player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {

    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
         if (collision.gameObject == _player)
        {
            _player.GetComponent<Player>().TakeDamage(_damageInput);
            Debug.Log("Kick damgae");
        }
  
    }

}
