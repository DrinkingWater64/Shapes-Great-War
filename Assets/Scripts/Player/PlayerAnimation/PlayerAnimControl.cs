using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerAnimControl : MonoBehaviour
{
    [SerializeField]
    Animator _animator;


    [SerializeField]
    PlayerMovement playerMovement;


    private void OnEnable()
    {
        playerMovement.OnMovement += PlayerMovement_OnMovementStart;
    }

    private void OnDisable()
    {
        playerMovement.OnMovement -= PlayerMovement_OnMovementStart;
    }

    private void PlayerMovement_OnMovementStart(float velocity)
    {
        _animator.SetFloat("BodyVelocity", velocity);
    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

}
