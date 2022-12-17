using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Stats : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField]
    private float currenthp;
    [SerializeField]
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
        currenthp = _player.GetComponent<Player>().Hp;
        maxhp = _player.GetComponent<Player>().MaximumHp;
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
