using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Stats : MonoBehaviour
{
    [SerializeField] private Player _player;
    private float currenthp;
    private float maxhp;
    [SerializeField] private Image bar;

    private void OnEnable()
    {
        _player.DamageTaken += SetBar;
    }

    private void OnDisable()
    {
        _player.DamageTaken -= SetBar;
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SetBar(float hp)
    {
        currenthp = _player.Hp;
        maxhp = _player.MaximumHp;
        bar.fillAmount = currenthp / maxhp;
    }


}
