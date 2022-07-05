using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float _speed = 10;
    IPlayerInputMovement inputMethodKeyboard;


    private void OnEnable()
    {

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
    }
}
