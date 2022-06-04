using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Enemy : MonoBehaviour, Attackable
{
    // TextMeshProUGUI _text;
    public string _spell = "testtext";

    public void Die()
    {
        Destroy(gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {
        // _text.text = _spell;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

public interface Attackable
{
    void Die();
}
