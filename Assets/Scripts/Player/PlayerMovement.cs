using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float _speed = 10;
    IPlayerInputMovement inputMethodKeyboard;
    Rigidbody2D _rb;

    bool _isFlipped = false;

    public event Action<float> OnMovement;
    public event Action OnFlipped;

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
        if (_rb.velocity.x < 0 && _isFlipped == false)
        {
            _isFlipped = true;
            if (OnFlipped != null)
            {
                OnFlipped();
            }
        }
        else if (_rb.velocity.x > 0 && _isFlipped == true)
        {
            _isFlipped = false;
            if (OnFlipped != null)
            {
                OnFlipped();
            }
        }
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
