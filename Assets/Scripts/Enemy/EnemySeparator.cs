using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class EnemySeparator : MonoBehaviour
{

    [SerializeField] GameObject[] enemies;
    public float SpaceBetween = 1.5f;
    // Start is called before the first frame update
    void Start()
    {
        enemies = GameObject.FindGameObjectsWithTag("enemy");
    }

    // Update is called once per frame
    void Update()
    {
        foreach(GameObject go in enemies)
        {
            if (go != gameObject)
            {
                if (go == null)
                {
                    enemies = enemies.Where<GameObject>(val => val != go).ToArray();
                }
                else
                {
                    float distance = Vector2.Distance(go.transform.position, this.transform.position);
                    if (distance <= SpaceBetween)
                    {
                        Vector2 dir = transform.position - go.transform.position;
                        transform.Translate(dir * Time.deltaTime * 3);
                    }
                }
            }
        }
    }
}
