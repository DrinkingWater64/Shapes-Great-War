using UnityEngine;

public class KeyBoardMovement : IPlayerInputMovement
    {

    Transform _transform;

    public KeyBoardMovement(Transform transform)
    {
        _transform = transform;
    }
        public void Move(float _speed)
        {
            if (Input.GetKey(KeyCode.K))
            {
                _transform.Translate(Vector3.up* _speed * Time.deltaTime);
            }
            if (Input.GetKey(KeyCode.H))
            {
                _transform.Translate(Vector3.left * _speed * Time.deltaTime);
            }
            if (Input.GetKey(KeyCode.J))
            {
                _transform.Translate(Vector3.down * _speed * Time.deltaTime);
            }
            if (Input.GetKey(KeyCode.L))
            {
                _transform.Translate(Vector3.right * _speed * Time.deltaTime);
            }
        }

        
    }
