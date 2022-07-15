using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Pool;

public class Enemy : MonoBehaviour, IAttackable, ILockable
{
    // TextMeshProUGUI _text;
    public string _spell = "testtext";
    [SerializeField] float hp;
    [SerializeField] GameObject FloatingText;
    [SerializeField] FloatingTextPool FTpool;
    [SerializeField] GameObject LockIndector;
    [SerializeField] GameObject player;
    [SerializeField] float flipperCapLeft;
    [SerializeField] float flipperCapRight;
    bool isFlipped = false;

    Transform _transform;

    private void Awake()
    {
        FTpool = GameObject.Find("FloatingTextPool").GetComponent<FloatingTextPool>();
    }

    public void Die()
    {
        Destroy(gameObject);
    }

    public void IsDead()
    {
        if (hp <= 0.0f)
        {
            Die();
        }
    }

    public void LockedOn()
    {
        LockIndector.SetActive(true);
        Debug.Log("locked");
    }

    public void TakeDamage(float damageInput)
    {
        hp -= damageInput;
        FTpool.SpawnPrefab(damageInput.ToString(), transform);
    }

    public void Unlocked()
    {

        LockIndector.SetActive(false);
    }



    // Start is called before the first frame update
    void Start()
    {
        _transform = transform;
        player = GameObject.FindGameObjectWithTag("Player");
        // _text.text = _spell;
    }

    // Update is called once per frame
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

    }

    void FlipBody()
    {
        Vector3 currentScale = _transform.localScale;
        currentScale.x *= -1;
        _transform.localScale = currentScale;
    }


   
}





