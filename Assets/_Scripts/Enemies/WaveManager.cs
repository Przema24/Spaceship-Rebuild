using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveManager : MonoBehaviour
{
    /* 
     * Class manage enemy waves, spawn insects, (to-do) load data from other script 
       enemyQueue[0] - number of enemies
       enemyQueue[1] - a prefab index of enemies to spawn
       nextSpawnPoint - an array of spawn points to spawn enemies 
     */

    public List<Enemy> enemyList;

    public int stage;
    public Transform[] spawnPoints;
    public Enemy[] enemies;


    //public int enemiesOnBoard;

    // counters help with Spawn function
    int spawnCounter_A = 0;
    int spawnCounter_B = 0;


    private bool waveStart = true;
    private bool waveEnd = false;

    private void Awake()
    {
        enemyList = new List<Enemy>();
    }

    private void Start()
    {
        // TODO load data

        stage = 1;
    }

    private void FixedUpdate()
    {

        if (waveEnd && enemyList.Count <= 0)
        {
            EndStage();
        }

        if (waveStart)
        {
            waveStart = false;
            SpawnEnemy();
        }
    }

    private void EndStage()
    {
        // todo
        Debug.Log(enemyList.Count);
    }
    
    private void SpawnEnemy()
    {
        switch(stage)
        {
            case 1:
                {
                    
                    int[] enemyQueue = new int[2];
                    enemyQueue[0] = 20;
                    enemyQueue[1] = 0;
                    int[] arraySpawnPoint = new int[] {1,2,3,4,5,
                    6,16,15,14,13,
                    12,11,7,8,9,
                    10,9,8,7,6};
                    float time1 = 0.8f;


                    int[] enemyQueue2 = new int[2];
                    enemyQueue2[0] = 6;
                    enemyQueue2[1] = 1;
                    int[] arraySpawnPoint2 = new int[] { 4, 8, 12, 16, 10, 14 };
                    float time2 = 2f;


                    StartCoroutine(SpawnA(enemyQueue, arraySpawnPoint, time1));
                    StartCoroutine(SpawnB(enemyQueue2, arraySpawnPoint2, time2));
                    
                }
                break;
            case 2:
                {
                    
                }
                break;
        }

    }

    
    IEnumerator SpawnA(int[] enemyQueue, int[] arraySpawnPoint, float time)
    {
        while (enemyQueue[0] > 0)
        {
            yield return new WaitForSeconds(time);

            int Index = enemyQueue[1];

            enemyList.Add(Instantiate(enemies[Index], spawnPoints[arraySpawnPoint[spawnCounter_A++]].transform.position, Quaternion.identity));
            enemyQueue[0]--;

            
        }
        waveEnd = true;
    }

    IEnumerator SpawnB(int[] enemyQueue, int[] arraySpawnPoint, float time)
    {
        while (enemyQueue[0] > 0)
        {
            yield return new WaitForSeconds(time);

            int Index = enemyQueue[1];

            enemyList.Add(Instantiate(enemies[Index], spawnPoints[arraySpawnPoint[spawnCounter_B++]].transform.position, Quaternion.identity));
            enemyQueue[0]--;
            
        }
    }








}
