﻿using UnityEngine;
using System;

public class KeyBoardMovement : IPlayerInputMovement
{

    Transform _transform;
    
    public KeyBoardMovement(Transform transform)
    {
        _transform = transform;
    }
    public void Move(float _speed)
    {
        Vector2 directoin = Vector2.zero;
        if (Input.GetKey(KeyCode.K))
        {
            directoin += Vector2.up;
        }
        if (Input.GetKey(KeyCode.H))
        {
            directoin += Vector2.left;
        }
        if (Input.GetKey(KeyCode.J))
        {
            directoin += Vector2.down;
        }
        if (Input.GetKey(KeyCode.L))
        {
            directoin += Vector2.right;
        }

        _transform.gameObject.GetComponent<Rigidbody2D>().MovePosition(new Vector2(
            (_transform.position.x + directoin.x * _speed),
             _transform.position.y + directoin.y * _speed));

        Debug.Log("moving");

       // _transform.Translate(directoin.normalized * _speed * Time.deltaTime);
    }




}
