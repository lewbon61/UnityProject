using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    private float currentPlayerHealth;

    public float startingHealth;

    public void ResetPlayerHralth()
    {
        currentPlayerHealth = startingHealth;
    }

    public void DamagePlayer(float amt)
    {
        currentPlayerHealth -= amt;
    }

    public float GetCurrentPlayerHealth()
    {
        return currentPlayerHealth;
    }

}
