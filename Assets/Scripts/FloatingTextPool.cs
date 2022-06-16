using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class FloatingTextPool : MonoBehaviour
{
    [SerializeField] FloatingTextController FloatingTextPrefab;
    private IObjectPool<FloatingTextController> floatingTextPool;

    private void Awake()
    {
        floatingTextPool = new ObjectPool<FloatingTextController>(CreateFunction, OnGet, OnRelease, OnDestroyAction, maxSize: 1);
    }

    private void OnDestroyAction(FloatingTextController obj)
    {
        Destroy(obj.gameObject);
    }

    private void OnGet(FloatingTextController obj)
    {
        obj.gameObject.SetActive(true);
        obj.transform.position = transform.position;
    }

    private void OnRelease(FloatingTextController obj)
    {
        obj.gameObject.SetActive(false);
    }

    private FloatingTextController CreateFunction()
    {
        FloatingTextController floatingText = Instantiate(FloatingTextPrefab);
        floatingText.SetPool(floatingTextPool);
        return floatingText;
    }

    public void SpawnPrefab()
    {
        floatingTextPool.Get();
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            SpawnPrefab();

        }
    }
}
