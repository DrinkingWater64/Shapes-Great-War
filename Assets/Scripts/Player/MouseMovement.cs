using System;
using UnityEngine;

public class MouseMovement : IPlayerInputMovement
{


    Vector2 _lastPosition;
    bool _isMoving;
    Transform _transform;

    public MouseMovement(Transform transform)
    {
        this._transform = transform;
    }


    public void Move(float _speed)
    {
        if (Input.GetMouseButtonDown(0))
        {
            _lastPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            _isMoving = true;

            Debug.LogWarning("mouse moves ");
        }

        if (_isMoving && (Vector2)_transform.position != _lastPosition)
        {
            _transform.position = Vector2.MoveTowards(_transform.position, _lastPosition, _speed * Time.deltaTime);
        }
        else
        {
            _isMoving = false;
        }
    }

    private void OnGUI()
    {
        
    }

}
