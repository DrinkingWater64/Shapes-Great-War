using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float _speed = 10;
    IPlayerInputMovement inputMethodKeyboard;
    Rigidbody2D _rb;

    public event Action<float> OnMovement;

    private void OnEnable()
    {

    }

    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    private void Awake()
    {
        inputMethodKeyboard = new WASDmovement(transform);
    }
    void Update() {
    }

    private void FixedUpdate()
    {
         if (InputManager.instance.mode == InputMode.COMMAND)
        {
            inputMethodKeyboard.Move(_speed);

        }
        else if (InputManager.instance.mode == InputMode.INSERT && gameObject.GetComponent<Rigidbody2D>().velocity != Vector2.zero)
        {
            gameObject.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        } 
        if (OnMovement != null)
        {
            OnMovement(_rb.velocity.magnitude);
        }
    }
}
