using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float _speed = 10;
    IPlayerInputMovement inputMethodMouse;
    IPlayerInputMovement inputMethodKeyboard;


    private void OnEnable()
    {

    }

    void ResetMouse()
    {
        inputMethodMouse = new MouseMovement(transform);
    }


    private void Awake()
    {

        inputMethodMouse = new MouseMovement(transform);
        inputMethodKeyboard = new WASDmovement(transform);
    }
    void Update() { 

        inputMethodKeyboard.Move(_speed);
        inputMethodMouse.Move(_speed);
        
    }
}
