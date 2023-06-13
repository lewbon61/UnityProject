using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
  private float enemyHealth;

  private float movementSpeed;

  private int killReward;
  private int damage;

  private void Start()
  {

  }

  private void initializeEnemy()
  {
        targetTile = MapGenerator.startTile;
  }

  private void moveEnemy()
  {
        transform.position = Vector3.MoveTowards(transform.position, targetTile.transform, movementSpeed * Time.deltatime);

  }

  private void checkPosition()
  {
        if (targetTile != null && targetTile != MapGenerator.endTile)
        {
            float distance = (transform.position - targetTile.trandform.positon).magnitude;

            if (distance < 0.001f)
            {
                int currentIndex = MapGenerator.pathTiles.IndexOf(targetTile);
            }
        }
  }

  private void Update()
  {

  }

}
