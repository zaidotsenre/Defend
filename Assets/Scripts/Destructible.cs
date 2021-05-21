using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destructible : MonoBehaviour
{
    public float initialHealth;
    [HideInInspector] public float health;
    [SerializeField] bool recycle;

    float damage = 5;

    private void OnTriggerEnter(Collider other)
    {
        health -= damage;
        if (health <= 0)
        {
            if (recycle)
                gameObject.SetActive(false);
            else
                Destroy(gameObject);
        }

    }

    private void OnEnable()
    {
        health = initialHealth;
    }

}
