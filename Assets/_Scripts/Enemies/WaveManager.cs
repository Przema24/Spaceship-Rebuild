using UnityEngine;

public class WaveManager : MonoBehaviour
{
    private float timer;
    private Vector2 randomPosition = new Vector2(0,0);

    public Enemy[] enemies;
    //public BigInsect biglInsect;
    public struct Wave
    {
        public int stage;
        public int smallInsectNumber;
        public int bigInsectNumber;
    }

    private void Start()
    {
        Wave nextWave = new Wave();
        nextWave.stage = 1;
        nextWave.smallInsectNumber = 10;
        nextWave.bigInsectNumber = 0;

        timer = 1f;
    }

    private void Update()
    {
        timer -= Time.deltaTime;

        if (timer <= 0)
        {
            timer = 1f;
            SpawnEnemy();
        }
    }

    private void SpawnEnemy()
    {
        int randomIndex = Random.Range(0, 1);
        randomPosition.x = Random.Range(-8, 8);
        randomPosition.y = Random.Range(6, 8);
        Instantiate<Enemy>(enemies[randomIndex], randomPosition, Quaternion.identity);
    }
}
