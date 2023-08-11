using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    //public static event Action OnPlayerDeath;

    [SerializeField] private float currentPlayerHealth;

    public float startingHealth;

    private bool isDead;

    public GameOverManager gameOverManager;

    public void Start()
    {
        ResetPlayerHealth();
    }

    public void ResetPlayerHealth()
    {
        currentPlayerHealth = startingHealth;
    }

    public void DamagePlayer(float amt)
    {
        currentPlayerHealth -= amt;

        if (currentPlayerHealth <= 0 && !isDead)
        {
            isDead = true;
            currentPlayerHealth = 0;
            Debug.Log("YOU ARE DIE");
            gameOverManager.gameOver();
            
            //OnPlayerDeath?.Invoke();
        }
    }

    public float GetCurrentPlayerHealth()
    {
        return currentPlayerHealth;
    }



}
