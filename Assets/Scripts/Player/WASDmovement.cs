using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WASDmovement :  IPlayerInputMovement
{

    Transform _transform;
    Rigidbody2D _rb;

    public WASDmovement(Transform transform)
    {
        this._transform = transform;
        _rb = _transform.gameObject.GetComponent<Rigidbody2D>();
    }
    public void Move(float speed)
    {
             Vector2 directoin = Vector2.zero;
        if (InputManager.instance.GetKey(KeyBindingActions.Up))
        {
            directoin += Vector2.up;
        }
        if (InputManager.instance.GetKey(KeyBindingActions.Down))
        {
            directoin += Vector2.down;
        }
        if (InputManager.instance.GetKey(KeyBindingActions.Left))
        {
            directoin += Vector2.left;
        }
        if (InputManager.instance.GetKey(KeyBindingActions.Right))
        {
            directoin += Vector2.right;
        }

        _rb.velocity = new Vector2(directoin.x, directoin.y).normalized * speed;


    }
}
