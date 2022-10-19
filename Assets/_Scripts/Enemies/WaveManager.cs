using System.Collections.Generic;
using UnityEngine;

public class WaveManager : MonoBehaviour
{
    // Class manage enemy waves, spawn insects, (to-do) load data from other script 
    public int stage;
    public int enemiesRemainToEndOfWave;

    public int enemiesOnBoard = 0;

    private bool waveEnd = false;
    private float timer;
    private Vector2 randomPosition = new Vector2(0,0);

    public Enemy[] enemies;
    




    private void Start()
    {
        // TODO load data

        stage = 1;
        enemiesRemainToEndOfWave = 20;

        timer = 1f;

    }

    private void Update()
    {
        timer -= Time.deltaTime;

        if (waveEnd && enemiesOnBoard <= 0)
        {
            EndStage();
        }

        if (timer <= 0)
        {
            timer = 1f;
            SpawnEnemy();
        }
    }

    private void EndStage()
    {
        // todo end stage
    }
    
    private void SpawnEnemy()
    {
        switch(stage)
        {
            case 1:
                {
                    if (enemiesRemainToEndOfWave > 0)
                    {
                        int randomIndex = Random.Range(0, 1);
                        randomPosition.x = Random.Range(-8, 8);
                        randomPosition.y = Random.Range(6, 8);
                        Instantiate(enemies[randomIndex], randomPosition, Quaternion.identity);
                        enemiesRemainToEndOfWave--;
                        enemiesOnBoard++;
                        
                        if (enemiesRemainToEndOfWave <= 0)
                        {
                            waveEnd = true;
                        }
                    }
                }
                break;
        }

    }


  
}
