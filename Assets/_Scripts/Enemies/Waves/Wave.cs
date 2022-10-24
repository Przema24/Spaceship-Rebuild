public class Wave 
{
    public int enemyIndex;
    public int EnemyToSpawnCount;
    public int[] arraySpawnPoints;
    public float time;

    public Wave(int enemyIndex, int EnemyToSpawnCount, int[] arraySpawnPoints, float time)
    {
        this.enemyIndex = enemyIndex;
        this.EnemyToSpawnCount = EnemyToSpawnCount;
        this.arraySpawnPoints = arraySpawnPoints;
        this.time = time;
    }
}
