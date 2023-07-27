using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarUI : MonoBehaviour
{
    public PlayerHealth playerHealth;

    public Image healthBarBar;

    public void Update()
    {
        healthBarBar.fillAmount = playerHealth.GetCurrentPlayerHealth() / playerHealth.startingHealth;
    }
}
