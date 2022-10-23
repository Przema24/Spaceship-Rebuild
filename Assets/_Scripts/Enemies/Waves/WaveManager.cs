using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveManager : MonoBehaviour
{
    /* Class manage enemy waves, spawn insects, (to-do) load data from other script 
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
            SpawnEnemies();
        }
    }

    private void EndStage()
    {
        // todo
        Debug.Log(enemyList.Count);
    }
    
    private void SpawnEnemies()
    {
        switch(stage)
        {
            case 1:
                {
                    Wave wave_A = new Wave(WaveData.enemyIndex, WaveData.EnemyToSpawnCount, WaveData.arraySpawnPoints, WaveData.timeA);
                    StartCoroutine(SpawnA(wave_A.enemyIndex, wave_A.EnemyToSpawnCount, wave_A.arraySpawnPoint, wave_A.time));
                }
                break;
            case 2:
                {
                    
                }
                break;
        }

    }

    
    IEnumerator SpawnA(int enemyIndex, int EnemyToSpawnCount, int[] arraySpawnPoint, float time)
    {
        while (EnemyToSpawnCount > 0)
        {
            yield return new WaitForSeconds(time);

            int Index = enemyIndex;

            enemyList.Add(Instantiate(enemies[Index], spawnPoints[arraySpawnPoint[spawnCounter_A++]].transform.position, Quaternion.identity));
            EnemyToSpawnCount--;

            
        }
        waveEnd = true;
    }

}
