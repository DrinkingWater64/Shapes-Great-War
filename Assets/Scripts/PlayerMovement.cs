using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float _speed = 10;
    [SerializeField] Vector2 _lastPosition;
    [SerializeField] bool _isMoving;

    void Update()
    {
        MoveToMousePoint();
    }

    private void OnGUI()
    {
        if (Input.GetMouseButtonDown(0))
        {
            _lastPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            _isMoving = true;
        }
    }

    void MoveToMousePoint()
    {
        if (_isMoving && (Vector2)transform.position != _lastPosition)
        {
            transform.position = Vector2.MoveTowards(transform.position, _lastPosition, _speed * Time.deltaTime);
        }
        else
        {
            _isMoving = false;
        }
    }
}
