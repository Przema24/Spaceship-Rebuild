public class Wave 
{
    public float waveStartTimer;
    public int enemyIndex;
    public int EnemyToSpawnCount;
    public int[] arraySpawnPoints;
    public float time;

    public Wave(float waveStartTimer, int enemyIndex, int EnemyToSpawnCount, int[] arraySpawnPoints, float time)
    {
        this.waveStartTimer = waveStartTimer;
        this.enemyIndex = enemyIndex;
        this.EnemyToSpawnCount = EnemyToSpawnCount;
        this.arraySpawnPoints = arraySpawnPoints;
        this.time = time;
    }
}
