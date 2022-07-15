using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coomer_boss_walk : StateMachineBehaviour
{
    GameObject _player;
    Rigidbody2D _rb;
    Transform _transform;
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        _player = GameObject.FindGameObjectWithTag("Player");
        _rb = animator.GetComponentInParent<Rigidbody2D>();
        _transform = animator.GetComponentInParent<Transform>();
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (Vector2.Distance(_transform.position, _player.transform.position) > .01)
        {
            Vector2 dir = _player.transform.position - _transform.position;
            _rb.velocity = new Vector2(dir.x, dir.y).normalized * 1.5f;
        }
        else
        {
            animator.SetTrigger("Attack");
        }

        
    }

    //OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.ResetTrigger("Attack");
    }


}
