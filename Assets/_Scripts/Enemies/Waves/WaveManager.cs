using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WaveManager : MonoBehaviour
{
    /* Class manage enemy waves, spawn insects, (to-do) load data from other script 
     */

    public List<Enemy> enemyList;

    public int stage;
    public Transform[] spawnPoints;
    public Enemy[] enemies;

    int[] spawnPoint;


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
        waveStart = false;
        stage++;

        Invoke("ReturnToShop", 2f);
    }
    
    private void ReturnToShop()
    {
        SceneManager.LoadScene("Shop");
    }

    private void SpawnEnemies()
    {
        switch(stage)
        {
            case 1:
                {
                    Wave1();
                }
                break;
            case 2:
                {
                    Wave2();
                }
                break;
        }

    }

    
    IEnumerator Spawn(Wave wave)
    {
        yield return new WaitForSeconds(wave.waveStartTimer);

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


    // WAVES METHODS

    private void Wave1()
    {
        spawnPoint = WaveData.leftWave;
        Wave wave1 = new Wave(0, 0, 18, spawnPoint, 1.4f);

        spawnPoint = WaveData.rightWave;
        Wave wave2 = new Wave(14f, 0, 18, spawnPoint, 1.4f);

        Wave[] waves = { wave1, wave2 };

        foreach (Wave w in waves)
        {
            StartCoroutine(Spawn(w));
        }
    }

    private void Wave2()
    {
        spawnPoint = WaveData.leftWave;
        Wave wave1 = new Wave(0, 0, 18, spawnPoint, 1.4f);

        spawnPoint = WaveData.leftWave;
        Wave wave2 = new Wave(4f, 1, 18, spawnPoint, 1.4f);

        spawnPoint = WaveData.rightWave;
        Wave wave3 = new Wave(4f, 1, 18, spawnPoint, 1.4f);

        spawnPoint = WaveData.rightWave;
        Wave wave4 = new Wave(14f, 0, 18, spawnPoint, 1.4f);

        Wave[] waves = { wave1, wave2, wave3, wave4 };

        foreach (Wave w in waves)
        {
            StartCoroutine(Spawn(w));
        }
    }
}
