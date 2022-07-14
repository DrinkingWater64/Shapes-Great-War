using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerAnimControl : MonoBehaviour
{
    [SerializeField]
    Animator _animator;
    Transform _transform;


    [SerializeField]
    PlayerMovement playerMovement;


    private void OnEnable()
    {
        playerMovement.OnMovement += PlayerMovement_OnMovementStart;
        playerMovement.OnFlipped += PlayerMovement_OnFlipped;
    }

    private void PlayerMovement_OnFlipped()
    {
        Vector3 currentScale = _transform.localScale;
        currentScale.x *= -1;
        _transform.localScale = currentScale;

        Debug.Log("flippppp");
    }

    private void OnDisable()
    {
        playerMovement.OnMovement -= PlayerMovement_OnMovementStart;
        playerMovement.OnFlipped -= PlayerMovement_OnFlipped;
    }

    private void PlayerMovement_OnMovementStart(float velocity)
    {
        _animator.SetFloat("BodyVelocity", velocity);
    }


    // Start is called before the first frame update
    void Start()
    {
        _transform = gameObject.transform;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

}
