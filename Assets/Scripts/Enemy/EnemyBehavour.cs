using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehavour : MonoBehaviour
{


    public Vector2 currentPosition;
    public GameObject player;
    public Transform arm;
    public IEnemyBehaviourState currentState;

    public Animator _animator;
    Transform _transform;
    bool isFlipped = false;


    // Start is called before the first frame update
    void Start()
    {
        _transform = transform;
        player = GameObject.FindGameObjectWithTag("Player");
        currentState = new Idle();
    }

    // Update is called once per frame
    void Update()
    {
        currentState.Perform(this);
    }




}


public interface IEnemyBehaviourState
{
    void Perform(EnemyBehavour enemy);
    void ChangeState();
}

public class Idle: IEnemyBehaviourState
{

    EnemyBehavour eb;

    public void ChangeState()
    {
        if (Vector2.Distance(eb.transform.position, eb.player.transform.position) < 10)
        {
            eb._animator.Play("Walk");
            eb.currentState = new ChasePlayer();
        }
    }

    public void Perform(EnemyBehavour enemy)
    {
        if (eb == null)
        {
            eb = enemy;
        }
        if (eb.currentPosition != null)
        {
            eb.currentPosition = new Vector2(eb.transform.position.x, eb.transform.position.y);
        }
        ChangeState();
    }
}


public class ChasePlayer : IEnemyBehaviourState
{


    EnemyBehavour eb;
    public void ChangeState()
    {
        if (Vector2.Distance(eb.transform.position, eb.player.transform.position) >= 10)
        {

            eb._animator.Play("idle");
            eb.currentState = new Retreat();
        }
        else if (Vector2.Distance(eb.transform.position, eb.player.transform.position) <= 1.6)

        {
            eb._animator.Play("idle");
            eb.currentState = new AttackPlayer();
        }
    }

    public void Perform(EnemyBehavour enemy)
    {
        if (eb == null)
        {
            eb = enemy;
        }
        Chase();
        ChangeState();
    }

    void Chase()
    { 
        if (Vector2.Distance(eb.transform.position, eb.player.transform.position) > 1.6)
        {
            Vector2 dir = eb.player.transform.position - eb.transform.position;
            eb.gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(dir.x, dir.y).normalized * 1.5f;
        }
    }
}



public class AttackPlayer : IEnemyBehaviourState
{
    float timer = 0;
    float waitTime = 1.5f;
    EnemyBehavour eb;
    public void ChangeState()
    {
        if (Vector2.Distance(eb.transform.position, eb.player.transform.position) > 2)
        {

            eb._animator.Play("Walk");
            eb.currentState = new ChasePlayer();
        }
    }

    public void Perform(EnemyBehavour enemy)
    {
        if (eb == null)
        {
            eb = enemy;
        }
        if (timer>waitTime)
        {
            Attack();
            timer = 0;
        }
        // Debug.Log(Vector2.Distance(eb.arm.position, eb.player.transform.position));

        timer += Time.deltaTime;
        ChangeState();
    }

    public void Attack()
    {
        if (Vector2.Distance(eb.arm.position, eb.player.transform.position) <= 1.3 )
        {
            eb._animator.Play("attack");
             Debug.Log(Vector2.Distance(eb.arm.position, eb.player.transform.position));
            //eb.player.GetComponent<Player>().TakeDamage(20);
            Debug.Log("attacking player");
        }
    }

}



public class Retreat: IEnemyBehaviourState
{
    EnemyBehavour eb;
    float timer = 0f;
    float waitTime = 5f;
    public void ChangeState()
    {
         if (Vector2.Distance(eb.transform.position, eb.player.transform.position) < 5)
        {
            eb.currentState = new ChasePlayer();
        } else if(timer >= waitTime)
        {
            eb.currentState = new Idle();
        }

    }

    public void Perform(EnemyBehavour enemy)
    {
        if (eb == null)
        {
            eb = enemy;
        }
        timer += Time.deltaTime;
        ChangeState();
        }
}