using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WASDmovement :  IPlayerInputMovement
{

    Transform _transform;

    public WASDmovement(Transform transform)
    {
        this._transform = transform;
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

        /*_transform.gameObject.GetComponent<Rigidbody2D>().MovePosition(new Vector2(
        (_transform.position.x + directoin.normalized.x * speed * Time.deltaTime),
        _transform.position.y + directoin.normalized.y * speed * Time.deltaTime));
        */

        _transform.gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(directoin.x, directoin.y).normalized * speed;

        Debug.Log("move");

        // _transform.Translate(directoin.normalized * speed * Time.deltaTime);
    }
}
