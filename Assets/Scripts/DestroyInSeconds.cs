using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyInSeconds : MonoBehaviour
{
    [SerializeField] float destroyAfter;
    void Start()
    {
        Destroy(gameObject, destroyAfter);
    }

}
