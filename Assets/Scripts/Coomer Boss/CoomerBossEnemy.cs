using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class CoomerBossEnemy : Enemy
{
    private Animator _animator;
    [SerializeField]
    private float _newHP;
    [SerializeField]
    Transform shooterPoint;
    [SerializeField]
    GameObject shooterPrefab;
    void Start()
    {
        _animator = gameObject.GetComponent<Animator>();
        _newHP = hp/2;
        _transform = transform;
        player = GameObject.FindGameObjectWithTag("Player");
        // _text.text = _spell;
    }

    void Update()
    {
        IsDead();
        Vector3 dir = _transform.position - player.transform.position;
        if (dir.x >= flipperCapLeft && isFlipped == false)
        {
            isFlipped = true;
            FlipBody();
        }
        else if(dir.x < flipperCapRight && isFlipped == true)
        {
            isFlipped = false;
            FlipBody();
        }

        if (hp < _newHP)
        {
            GoSecondStage();
        }

    }

    private void GoSecondStage()
    {
        _animator.SetTrigger("SecondStage");
    }

    void shootWave()
    {
        Vector2 shootDir = player.transform.position - shooterPoint.position;
        float rotZ = Mathf.Atan2(shootDir.x, shootDir.y) * Mathf.Rad2Deg;
        shooterPoint.rotation = Quaternion.Euler(0f, 0f, - rotZ );

        GameObject ist =  Instantiate(shooterPrefab, shooterPoint.position,  shooterPoint.rotation);
        ist.GetComponent<Rigidbody2D>().velocity = shootDir.normalized * 5;

    }
}
