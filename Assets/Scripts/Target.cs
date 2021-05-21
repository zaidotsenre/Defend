using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    [SerializeField] HealthBar healthBar;
    GameManager gameManager;
    Destructible destructible;

    private void Start()
    {
        //gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
        destructible = GetComponent<Destructible>();
    }

    private void Update()
    {
        healthBar.UpdateHealthBar(destructible.health / destructible.initialHealth);
    }

    private void OnDisable()
    {
        GameManager.instance.gameOver.Invoke();
    }
}
