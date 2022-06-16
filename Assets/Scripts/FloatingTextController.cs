using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class FloatingTextController : MonoBehaviour
{

    private IObjectPool<FloatingTextController> floatingTextPool;

    public void SetPool(IObjectPool<FloatingTextController> pool)
    {
        floatingTextPool = pool;
    }
    void Start()
    {
    }

    void FloatText(){
        
        floatingTextPool.Release(this);
    }

    private void OnEnable()
    {
        
        Invoke("FloatText", 2f);
    }


    void Update()
    {
        
    }
}
