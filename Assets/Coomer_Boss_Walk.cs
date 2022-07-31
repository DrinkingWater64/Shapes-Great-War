using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coomer_Boss_Walk : StateMachineBehaviour
{

    GameObject _player;
    Rigidbody2D _rb;
    Transform _transform;

    [SerializeField]
    float footMinimumDistance;
    [SerializeField]
    float footMaximumDistance;
    [SerializeField]
    float footMinimumHeight;
    [SerializeField]
    float footMaximumHeight;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        _player = GameObject.FindGameObjectWithTag("Player");
        _rb = animator.GetComponent<Rigidbody2D>();
        _transform = animator.GetComponent<Transform>();
       
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        Vector2 dir = _player.transform.position - _transform.position;
        _rb.velocity = new Vector2(dir.x, dir.y).normalized * 1.5f;
        if (Vector2.Distance(_player.transform.position, _transform.position) < 1)
        {
            animator.SetTrigger("Attack");
        }
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.ResetTrigger("Attack");
    }

}
