using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehavour : MonoBehaviour
{


    public Vector2 currentPosition;
    public GameObject player;
    public IEnemyBehaviourState currentState;
    
    // Start is called before the first frame update
    void Start()
    {
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
            eb.currentState = new AttackPlayer();
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


public class AttackPlayer : IEnemyBehaviourState
{


    EnemyBehavour eb;
    public void ChangeState()
    {
        if (Vector2.Distance(eb.transform.position, eb.player.transform.position) >= 10)
        {
            eb.currentState = new Retreat();
        }
    }

    public void Perform(EnemyBehavour enemy)
    {
        if (eb == null)
        {
            eb = enemy;
        }
               Attack();
        ChangeState();
    }

    void Attack()
    { 
        if (Vector2.Distance(eb.transform.position, eb.player.transform.position) > 1.6)
        {
            Vector2 dir = eb.player.transform.position - eb.transform.position;
             eb.transform.Translate(dir.normalized * 3 * Time.deltaTime);
            /* eb.gameObject.GetComponent<Rigidbody2D>().MovePosition(new Vector2(
                eb.transform.position.x + dir.x * 3 * Time.deltaTime,
                eb.transform.position.y + dir.y * 3 * Time.deltaTime
                )); */
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
            eb.currentState = new AttackPlayer();
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



