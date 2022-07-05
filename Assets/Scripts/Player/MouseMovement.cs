using System;
using UnityEngine;

public class MouseMovement : IPlayerInputMovement
{


    Vector2 _lastPosition;
    bool _isMoving;
    Transform _transform;
    Vector2 dir;

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
            dir = _lastPosition - (Vector2)_transform.position;
        }
        

        if (_isMoving && (Vector2)_transform.position != _lastPosition)
        {
            // _transform.position = Vector2.MoveTowards(_transform.position, _lastPosition, _speed * Time.deltaTime);
            _transform.gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(dir.x, dir.y).normalized * _speed;
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
