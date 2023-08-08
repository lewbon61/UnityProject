using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private float currentPlayerHealth;

    public float startingHealth;


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

        if (currentPlayerHealth <= 0)
        {
            currentPlayerHealth = 0;
            Debug.Log("YOU ARE DIE");
        }
    }

    public float GetCurrentPlayerHealth()
    {
        return currentPlayerHealth;
    }



}
