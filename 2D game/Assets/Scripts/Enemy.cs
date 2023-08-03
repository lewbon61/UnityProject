using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
   
    [SerializeField]
    private float enemyHealth;

    [SerializeField]
    private float movementSpeed;

    [SerializeField]
    private int killReward;

    [SerializeField]
    private int damage;

    private GameObject targetTile;
 
    public GameObject moneyManager;

    public GameObject playerHealth;


    private void Awake()
    {
        Enemies.enemies.Add(gameObject);
    }

    private void Start()
    {
        initializeEnemy();
        moneyManager = GameObject.Find("MoneyManager");
        playerHealth = GameObject.Find("PlayerHealth");
    }

    private void initializeEnemy()
    {
        targetTile = MapGenerator.startTile;
    }


    public void takeDamage(float amount)
    {
        enemyHealth -= amount;

        if (enemyHealth <= 0)
        {
            die();
            moneyManager.GetComponent<MoneyManager>().AddMoney(killReward);
        }
    }

    private void die()
    {  
        Enemies.enemies.Remove(gameObject);
        Destroy(transform.gameObject);
        
    }

    private void moveEnemy()
    {
          transform.position = Vector3.MoveTowards(transform.position, targetTile.transform.position, movementSpeed * Time.deltaTime);
    }

    private void checkPosition()
    {
            if (targetTile != null && targetTile != MapGenerator.endTile)
            {
                float distance = (transform.position - targetTile.transform.position).magnitude;

                if (distance < 0.001f)
                {
                    int currentIndex = MapGenerator.pathTiles.IndexOf(targetTile);

                    targetTile = MapGenerator.pathTiles[currentIndex + 1];
                    //Debug.Log("Yippee");
                }
                
            }

            else if (targetTile = MapGenerator.endTile)
            {
                die();
                playerHealth.GetComponent<PlayerHealth>().DamagePlayer(damage);
            }
    }

    private void Update()
    {
        checkPosition();
        moveEnemy();

        takeDamage(0);
    }

}
