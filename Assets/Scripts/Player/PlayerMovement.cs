using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float _speed = 10;
    IPlayerInputMovement inputMethod;

    private void Awake()
    {

        // inputMethod = new MouseMovement(transform);
        inputMethod = new KeyBoardMovement(transform);
    }
    void Update()
    {
        inputMethod.Move(_speed);
    }
}
