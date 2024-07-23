using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyToSpawn;

    public float timeToSpawn;
    private float Spawncounter;

    public Transform minSpawn, maxSpawn; //spawn points

    private Transform target;

    private float despawnDistance;

    private List<GameObject> spawnedEnemies = new List<GameObject>();

    public int checkPerFrame;
    private int enemyToCheck;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Spawncounter = timeToSpawn;

        target = PlayerHealth.instance.transform;

        despawnDistance = Vector3.Distance(transform.position, maxSpawn.position) + 4f;
    }

    // Update is called once per frame
    void Update()
    {
        Spawncounter -= Time.deltaTime;
        if (Spawncounter <= 0)
        {
            Spawncounter = timeToSpawn;

            //Instantiate(enemyToSpawn, transform.position, transform.rotation);

           GameObject newEnemy = Instantiate(enemyToSpawn, SelectSpawnPoint(), transform.rotation);

            spawnedEnemies.Add(newEnemy); 
        }

        transform.position = target.position;

        int checkTarget = enemyToCheck + checkPerFrame;
        while (enemyToCheck < checkTarget)
        {
            if (enemyToCheck < spawnedEnemies.Count)
            {
                if (spawnedEnemies[enemyToCheck] != null)
                {
                    if (Vector3.Distance(transform.position, spawnedEnemies[enemyToCheck].transform.position) > despawnDistance)
                    {
                        Destroy(spawnedEnemies[enemyToCheck]);

                        spawnedEnemies.RemoveAt(enemyToCheck);
                        checkTarget--;
                    }
                    else
                    {
                        enemyToCheck++;
                    }
                }else
                {
                    spawnedEnemies.RemoveAt(enemyToCheck);
                    checkTarget--;
                }
            }
            else
            {
                enemyToCheck = 0;
                checkTarget = 0;
            }
        }
    }

    public Vector3 SelectSpawnPoint()
    {
        Vector3 spawnPoint = Vector3.zero;

        bool spawnVerticalEdge = Random.Range(0f, 1f) > .5f; ;  // check 

        if (spawnVerticalEdge)
        {
            spawnPoint.y = Random.Range(minSpawn.position.y, maxSpawn.position.y);

            if(Random.Range(0f, 1f) > .5f)
            {
                spawnPoint.x = maxSpawn.position.x;
            }
            else
            {
                spawnPoint.x = minSpawn.position.x;
            }
        }     
        else
            spawnPoint.x = Random.Range(minSpawn.position.x, maxSpawn.position.x);

        if (Random.Range(0f, 1f) > .5f)
        {
            spawnPoint.y = maxSpawn.position.y;
        }
        else
        {
            spawnPoint.y = minSpawn.position.y;
        }
    
        return spawnPoint;
    }
}
