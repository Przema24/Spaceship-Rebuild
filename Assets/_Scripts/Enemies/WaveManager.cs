using System.Collections;
using UnityEngine;

public class WaveManager : MonoBehaviour
{
    // Class manage enemy waves, spawn insects, (to-do) load data from other script 
    public int stage;
    public int enemiesRemainToEndOfWave;
    public Transform[] spawnPoints;
    public Enemy[] enemies;


    public int enemiesOnBoard = 0;
    

    private bool waveStart = true;
    private bool waveEnd = false;
    private float timer;
    private Vector2 randomPosition = new Vector2(0,0);
    private int k = 0;

    private int[] enemyQueue;


    private void Start()
    {
        // TODO load data
        enemyQueue = new int [3];

        stage = 1;


        timer = 0.8f;

    }

    private void FixedUpdate()
    {
        timer -= Time.deltaTime;

        if (waveEnd && enemiesOnBoard <= 0)
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
        Debug.Log("koniec");
    }
    
    private void SpawnEnemy()
    {
        switch(stage)
        {
            case 1:
                {
                    enemyQueue[0] = 20;
                    enemyQueue[1] = 0;

                    enemiesRemainToEndOfWave = enemyQueue[0];

                    NextEnemy(enemyQueue);
                }
                break;
        }

    }

    private void NextEnemy(int[] enemyQueue)
    {
        StartCoroutine(Spawn());
    }

    
    IEnumerator Spawn()
    {
        while (enemiesRemainToEndOfWave > 0)
        {
            yield return new WaitForSeconds(0.8f);

            int Index = enemyQueue[1];
            int[] randomSpawnPoint = new int[] {1,2,3,4,5,
                6,16,15,14,13,
                12,11,7,8,9,
                10,9,8,7,6};


            Instantiate(enemies[Index], spawnPoints[randomSpawnPoint[k++]].transform.position, Quaternion.identity);
            enemiesRemainToEndOfWave--;
            enemiesOnBoard++;

            if (enemiesRemainToEndOfWave <= 0)
            {
                waveEnd = true;
            }
        }
    }


        
            

    
        
    
}
