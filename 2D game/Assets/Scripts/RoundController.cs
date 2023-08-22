using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoundController : MonoBehaviour
{

    public GameObject basicEnemy;

    public GameObject speedRoach;

    //public Enemies enemies;

    public float timeBetweenWaves;
    public float timeBeforeRoundStarts;
    public float timeVariable;
    
    public bool isRoundGoing;
    public bool isIntermission;
    public bool isStartOfRound;
    //public bool isGameOver;

    public int round;

    //public GameObject playerHealth;

    private void Start()
    {
        isRoundGoing = false;
        isIntermission = false;
        isStartOfRound = true;
        //isGameOver = false;

        timeVariable = Time.time + timeBeforeRoundStarts;

        round = 1;
    }

    private void SpawnEnemies()
    {
        StartCoroutine("ISpawnEnemies");
    }

    IEnumerator ISpawnEnemies()
    {
        for (int i = 0; i < round; i++)
        {
            GameObject newEnemy = Instantiate(basicEnemy,MapGenerator.startTile.transform.position,Quaternion.identity);
            yield return new WaitForSeconds(1f);
        }
    }

    private void Update()
    {
        if (isStartOfRound)
        {
            if (Time.time >= timeVariable)
            {
                isStartOfRound = false;
                isRoundGoing = true;
                //isGameOver = false;

                SpawnEnemies();
                return;
            }
        }
        else if (isIntermission)
        {
            if (Time.time >= timeVariable)
            {
                isIntermission = false;
                isRoundGoing = true;
                //isGameOver = false;

                SpawnEnemies();
            }
        }
        else if (isRoundGoing)
        {
            if (Enemies.enemies.Count > 0)
            {

            }
            //else if(playerHealth.GetComponent<PlayerHealth>().GetCurrentPlayerHealth(currentPlayerHealth <= 0))
           // {
                //isGameOver = true;
                //isRoundGoing = false;
                //isIntermission = false;
            //}
            
            else
            {
                isIntermission = true;
                isRoundGoing = false;
                //isGameOver = false;

                timeVariable = Time.time + timeBetweenWaves;

                round++;
            }
        }
        //else if (isGameOver)
        //{
            //basicEnemy.SetActive(false);
        //}
    }
}
