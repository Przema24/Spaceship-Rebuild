using System.Collections.Generic;
using UnityEngine;

public class WaveManager : MonoBehaviour
{
    // Class manage enemy waves, spawn insects, (to-do) load data from other script 
    public int stage;
    public int insectsRemain;

    private bool waveStart = false;
    private float timer;
    private Vector2 randomPosition = new Vector2(0,0);

    public Enemy[] enemies;
    public List<Enemy> enemiesOnBoard;




    private void Start()
    {
        // TODO load data

        stage = 1;
        insectsRemain = 20;

        timer = 1f;

        enemiesOnBoard = new List<Enemy>();
    }

    private void Update()
    {
        timer -= Time.deltaTime;

        if (waveStart && enemiesOnBoard.Count <= 0)
        {
            EndStage();
        }

        if (timer <= 0)
        {
            timer = 1f;
            SpawnEnemy();
        }
    }

    private void OnEnable()
    {
        Enemy.OnDeath += RemoveInsectFromList;
    }

    private void OnDisable()
    {
        Enemy.OnDeath -= RemoveInsectFromList;
    }

    private void EndStage()
    {
        // to do stage complete
    }
    
    private void SpawnEnemy()
    {
        switch(stage)
        {
            case 1:
                {
                    if (insectsRemain > 0)
                    {
                        int randomIndex = Random.Range(0, 1);
                        randomPosition.x = Random.Range(-8, 8);
                        randomPosition.y = Random.Range(6, 8);
                        enemiesOnBoard.Add(Instantiate(enemies[randomIndex], randomPosition, Quaternion.identity));
                        insectsRemain--;
                        waveStart = true;
                    }
                }
                break;
        }

    }

    public void RemoveInsectFromList(Enemy enemy)
    {
        enemy.DropGold(enemy.gold);
        enemiesOnBoard.Remove(enemy);
        Debug.Log(GameManager.Instance.gameData.playerGold);
    }

  
}
