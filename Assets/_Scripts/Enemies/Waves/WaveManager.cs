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
                    int[] spawnPoints = WaveData.ArraySpawnPoints_1;
                    Wave wave = new Wave(0 , 20, spawnPoints, 0.8f);

                    int[] spawnPoints2 = WaveData.ArraySpawnPoints_2;
                    Wave wave2 = new Wave(1, 6, spawnPoints2, 1.4f);

                    Wave[] waves = { wave, wave2 };

                    foreach(Wave w in waves)
                    {
                        StartCoroutine(Spawn(w));
                    }
                }
                break;
            case 2:
                {
                    //Wave wave = new Wave(WaveData.enemyIndex, WaveData.EnemyToSpawnCount, WaveData.firstArraySpawnPoints, WaveData.timeA);
                    //StartCoroutine(Spawn(wave));
                }
                break;
        }

    }

    
    IEnumerator Spawn(Wave wave)
    {
        int spawnCounter = 0;
        while (wave.EnemyToSpawnCount > 0)
        {
            yield return new WaitForSeconds(wave.time);

            int Index = wave.enemyIndex;

            enemyList.Add(Instantiate(enemies[Index], spawnPoints[wave.arraySpawnPoints[spawnCounter++]].transform.position, Quaternion.identity));
            wave.EnemyToSpawnCount--;
        }
        waveEnd = true;
        spawnCounter = 0;
    }

}
